using AryuwatWebApplication.Entity;
using AryuwatWebApplication.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AryuwatWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private string BaseURL()
        {
            HttpRequestBase request = HttpContext.Request;
            string appUrl = HttpRuntime.AppDomainAppVirtualPath;
            if (appUrl != "/") appUrl = "/" + appUrl;
            return string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);
        }

        public ActionResult Index()
        {
            return View();
        }

        private SqlParameter[] ConvertParamToArr(List<SqlParameter> parameters)
        {
            SqlParameter[] sqls = new SqlParameter[parameters.Count];
            for (int i = 0; i < parameters.Count; i++)
            {
                sqls[i] = parameters[i];
            }
            return sqls;
        }

        public class TempPatientData
        {
            public string Patient_Name { get; set; }
            public string CN { get; set; }
            public string Room { get; set; }
            public DateTime? Start { get; set; }
            public DateTime? End { get; set; }
            public DateTime? Meeting { get; set; }
        }

        [AllowJsonGet]
        [HttpGet, ActionName("TableCustomer")]
        public async Task<JsonResult> TableCustomer(string searchtxt)
        {
            try
            {
                using (var context = new OPD_SystemEntities())
                {
                    string query = @"SELECT * from (					
                                    select
	                                    cus.PrefixCode + cus.Tname + ' ' + cus.TsurName Patient_Name,
	                                    cus.CN,
	                                    MR.Room_Name Room,
                                        RD.Start_Date Start,
                                        case 
		                                    when RD.Start_Date is not null
		                                    then DATEADD(DAY,RD.Qty_Date , RD.Start_Date) 
		                                    else null 
	                                    end [End],
										AD.Alert_Date as Meeting
                                    FROM [OPD_System].[dbo].[Customers] cus
                                    --(select top 1 ID as MOID from [OPD_System].[dbo].MedicalOrder where CN = cus.CN order by ID desc)
                                    Outer Apply
	                                    (
		                                    SELECT TOP 1 *
		                                    FROM [OPD_System].[dbo].MedicalOrder MO
		                                    WHERE MO.CN = cus.CN and Room_Status = 1
		                                    ORDER BY MO.ID DESC
	                                    ) MO
                                    --Left Join [OPD_System].[dbo].MedicalOrder MO on cus.CN = MO.CN
                                    Outer Apply
	                                    (
		                                    SELECT TOP 1 *
		                                    FROM [OPD_System].[dbo].Room_Detail RD
		                                    WHERE RD.FK_MO_ID = MO.ID
		                                    ORDER BY RD.ID DESC
	                                    ) RD
                                    --Left Join [OPD_System].[dbo].Room_Detail RD on MO.ID = RD.FK_MO_ID and RD.Is_Active = 1
                                    Left Join [OPD_System].[dbo].Master_Room MR on RD.FK_Room_ID = MR.ID and MR.Is_Active = 1
									Outer Apply
	                                    (
		                                    SELECT TOP 1 *
		                                    FROM [OPD_System].[dbo].Alert_Detail AD
		                                    WHERE AD.FK_Customer_ID = CUS.ID AND AD.Is_Active = 1 and AD.Alert_Type = 2
		                                    ORDER BY AD.Alert_Date DESC
	                                    ) AD
									 ) a
									WHERE Patient_Name like '%" + searchtxt + "%'";

                    var resultquery = context.Database.SqlQuery<TempPatientData>(query).ToList();
                    //var result = (from cus in context.Customers
                    //              join med in context.MedicalOrders.Where(x => x.Room_Status == true) on cus.CN equals med.CN into med2
                    //              from med3 in med2
                    //              join rd in context.Room_Detail.Where(x => x.Is_Active == true) on med3.ID equals rd.FK_MO_ID into rd2
                    //              from rd3 in rd2
                    //              join mr in context.Master_Room.Where(x => x.Is_Active == true) on rd3.FK_Room_ID equals mr.ID into mr2
                    //              from mr3 in mr2
                    //              select new TempPatientData
                    //              {
                    //                  Patient_Name = (cus.PrefixCode ?? "") + (cus.Tname ?? "") + " " + (cus.TsurName ?? ""),
                    //                  CN = cus.CN ?? "",
                    //                  Room = mr3.Room_Name ?? "",
                    //                  Start = rd3.Start_Date,
                    //                  End = EntityFunctions.AddDays(rd3.Start_Date, (Int32?)(rd3.Qty_Date)),
                    //                  //End = rd3.Start_Date != null ? rd3.Start_Date.Value.AddDays(0/*Convert.ToDouble(rd3.Qty_Date)*/) : DateTime.Now,
                    //                  //End = Convert.ToDateTime(rd3.Start_Date).AddDays(Convert.ToDouble(rd3 == null ? 0 : rd3.Qty_Date)),
                    //                  //Meeting = null
                    //              }).ToList();

                    return Json(new { ContentEncoding = 200, data = resultquery });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [AllowJsonGet]
        [HttpGet, ActionName("GetAttachfile")]
        public async Task<JsonResult> GetAttachfile(string customerCN)
        {
            try
            {
                using (var context = new OPD_SystemEntities())
                {

                    var result = context.FileOPDs.Where(x => x.CN == customerCN).ToList();

                    return Json(new { ContentEncoding = 200, data = result });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("UploadFile")]
        public JsonResult UploadFile(string CN, HttpPostedFileBase AttachFileData)
        {
            try
            {
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];

                using (var context = new OPD_SystemEntities())
                {
                    if (AttachFileData != null && AttachFileData.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(AttachFileData.FileName);
                        var newFileName = "OPD_" + CN + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "." + AttachFileData.FileName.Split('.').ElementAt(1);
                        var path = Path.Combine(Server.MapPath("~/AttachFile_Aryuwat"), newFileName);
                        AttachFileData.SaveAs(path);
                        FileOPD fopd = new FileOPD();
                        fopd.FileName = newFileName;
                        fopd.Detail = AttachFileData.FileName;
                        fopd.DateScan = DateTime.Now;
                        fopd.CN = CN;
                        fopd.ENSave = username;
                        fopd.DateSave = DateTime.Now;
                        context.FileOPDs.Add(fopd);
                        context.SaveChanges();
                    }
                    return Json(new { ContentEncoding = 200 });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("sendnoti")]
        public JsonResult sendnoti()
        {
            try
            {
                string msg = "";
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];

                using (var context = new OPD_SystemEntities())
                {
                    string lineToken = ConfigurationManager.AppSettings["LineToken"];
                    var client = new RestClient("https://notify-api.line.me/api/notify");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", "Bearer " + Convert.ToString(lineToken).Trim());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    var datetomorrow = DateTime.Now.AddDays(1);
                    var TempData = (from AD in context.Alert_Detail.Where(x => x.Is_Active == true && x.Alert_Type == 2 && x.Publish == true && x.Alert_Date == datetomorrow.Date)
                                    join CUS in context.Customers.Where(x => x.Is_Active == true) on AD.ID equals CUS.ID
                                    select new
                                    {
                                       ID = AD.ID,
                                       PatientName = CUS.PrefixCode + CUS.Tname + " " + CUS.TsurName,
                                       Date = AD.Alert_Date,
                                       Description = AD.Description,
                                    }).ToList(); 
                    foreach(var items in TempData)
                    {
                        msg = "\r\n*Meeting*";
                        msg += "\r\nPatientName : ";
                        msg += items.PatientName + "\r\nMeeting Date : " + Convert.ToDateTime(items.Date).ToString("dd/MM/yyyy") + "\r\nDescription :\r\n" + items.Description;
                        request.AddParameter("application/x-www-form-urlencoded", $"message={msg}", ParameterType.RequestBody);
                        var dispublish = context.Alert_Detail.Where(x => x.ID == items.ID).FirstOrDefault();
                        if (dispublish != null)
                        {
                            dispublish.Publish = false;
                            dispublish.Update_By = username;
                            dispublish.Update_Date = DateTime.Now;
                            context.SaveChanges();
                        }
                        var response = client.Execute(request);
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            return Json(new { ContentEncoding = 400 });
                        }
                    }
                    return Json(new { ContentEncoding = 200 });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("GetPatientChange")]
        public JsonResult GetPatientChange(int? tmpCustomerID)
        {
            try
            {
                using (var context = new OPD_SystemEntities())
                {
                    if (tmpCustomerID != 0)
                    {
                        string query = @"SELECT distinct pt.[Count] as dataCount,
                                        (select top 1 NextDateChange FROM[OPD_System].[dbo].[PatientChange] where Type = 1  and [Count] = pt.[Count] and FK_Customer_ID = " + tmpCustomerID + @") as oneNextChange,
	                                    (select top 1 NextDateChange FROM[OPD_System].[dbo].[PatientChange] where Type = 2  and [Count] = pt.[Count] and FK_Customer_ID = " + tmpCustomerID + @") as twoNextChange
                                        FROM[OPD_System].[dbo].[PatientChange] pt  where FK_Customer_ID = " + tmpCustomerID + @"
	                                    order by [Count] desc";
                        var resultquery = context.Database.SqlQuery<MedicalExpireModel>(query).ToList();
                        var result = context.PatientChanges.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true).ToList();
                        if (result.Count > 0)
                        {
                            var onelastchange = result.Where(x => x.Type == 1).OrderByDescending(x => x.ID).FirstOrDefault().DateChange;
                            var onenextchange = result.Where(x => x.Type == 1).OrderByDescending(x => x.ID).FirstOrDefault().NextDateChange;
                            var twolastchange = result.Where(x => x.Type == 2).OrderByDescending(x => x.ID).FirstOrDefault()?.DateChange;
                            var twonextchange = result.Where(x => x.Type == 2).OrderByDescending(x => x.ID).FirstOrDefault()?.NextDateChange;
                            return Json(new { ContentEncoding = 200, data = resultquery, onelastchange = onelastchange, onenextchange = onenextchange, twolastchange = twolastchange, twonextchange = twonextchange });
                        }
                        return Json(new { ContentEncoding = 201, data = result });
                    }
                    return Json(new { ContentEncoding = 400 });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("GetDataRemark")]
        public JsonResult GetDataRemark(int? tmpCustomerID)
        {
            try
            {
                using (var context = new OPD_SystemEntities())
                {
                    if (tmpCustomerID != 0)
                    {
                        var result = context.Alert_Detail.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true && x.Alert_Type == 1).ToList();
                        return Json(new { ContentEncoding = 200, data = result });
                    }
                    return Json(new { ContentEncoding = 400 });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("GetDataMeeting")]
        public JsonResult GetDataMeeting(int? tmpCustomerID)
        {
            try
            {
                using (var context = new OPD_SystemEntities())
                {
                    if (tmpCustomerID != 0)
                    {
                        var result = context.Alert_Detail.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true && x.Alert_Type == 2).ToList();
                        return Json(new { ContentEncoding = 200, data = result });
                    }
                    return Json(new { ContentEncoding = 400 });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("GetPatientData")]
        public JsonResult GetPatientData(int? tmpCustomerID)
        {
            try
            {
                using (var context = new OPD_SystemEntities())
                {
                    if (tmpCustomerID != 0)
                    {
                        var result = context.PatientDatas.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true).ToList();
                        return Json(new { ContentEncoding = 200, data = result });
                    }
                    return Json(new { ContentEncoding = 400 });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("UpdateMedical")]
        public JsonResult UpdateMedical(int? type, int? tmpCustomerID)
        {
            try
            {
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];

                using (var context = new OPD_SystemEntities())
                {
                    var chkdata = context.PatientChanges.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Type == type && x.Is_Active == true).OrderByDescending(x => x.ID).FirstOrDefault()?.Count;
                    PatientChange PC = new PatientChange();
                    PC.DateChange = DateTime.Now;
                    PC.NextDateChange = DateTime.Now.AddMonths(1);
                    PC.Type = type;
                    PC.Count = chkdata == null ? 1 : chkdata + 1;
                    PC.FK_Customer_ID = tmpCustomerID;
                    PC.Publish = true;
                    PC.Is_Active = true;
                    PC.Create_By = username;
                    PC.Create_Date = DateTime.Now;
                    context.PatientChanges.Add(PC);
                    context.SaveChanges();
                    return Json(new { ContentEncoding = 200 , data = PC });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("AddAlert")]
        public JsonResult AddAlert(string tmpData, int? tmpCustomerID)
        {
            try
            {
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];
                dynamic jsonData = JsonConvert.DeserializeObject(tmpData);
                var modelTopic = Convert.ToString(jsonData[0]["modelTopic"]);
                var modelDescription = Convert.ToString(jsonData[0]["modelDescription"]);
                var modelDate = Convert.ToDateTime(jsonData[0]["modelDate"]);
                var modelPulish = Convert.ToBoolean(jsonData[0]["modelPulish"]);
                var modelType = Convert.ToInt32(jsonData[0]["modelType"]);

                using (var context = new OPD_SystemEntities())
                {
                    Alert_Detail AD = new Alert_Detail();
                    AD.Alert_Type = 1;
                    AD.Alert_Date = modelDate;
                    AD.Topic = modelTopic;
                    AD.Description = modelDescription;
                    AD.Publish = modelPulish;
                    AD.FK_Customer_ID = tmpCustomerID;
                    AD.Remark_Type = modelType;
                    AD.Is_Active = true;
                    AD.Create_By = username;
                    AD.Create_Date = DateTime.Now;
                    context.Alert_Detail.Add(AD);
                    context.SaveChanges();
                    return Json(new { ContentEncoding = 200 , data = AD });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("UpdateAlert")]
        public JsonResult UpdateAlert(string tmpData, int? tmpCustomerID)
        {
            try
            {
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];
                dynamic jsonData = JsonConvert.DeserializeObject(tmpData);
                int modelID = Convert.ToInt32(jsonData[0]["modelID"]);
                var modelTopic = Convert.ToString(jsonData[0]["modelTopic"]);
                var modelDescription = Convert.ToString(jsonData[0]["modelDescription"]);
                var modelDate = Convert.ToDateTime(jsonData[0]["modelDate"]);
                var modelActive = Convert.ToBoolean(jsonData[0]["modelPulish"]);
                var modelType = Convert.ToInt32(jsonData[0]["modelType"]);

                using (var context = new OPD_SystemEntities())
                {
                    var chkdata = context.Alert_Detail.Where(x => x.FK_Customer_ID == tmpCustomerID && x.ID == modelID && x.Alert_Type == 1 && x.Is_Active == true).OrderByDescending(x => x.ID).FirstOrDefault();
                    if (chkdata != null)
                    {
                        chkdata.Alert_Date = modelDate;
                        chkdata.Topic = modelTopic;
                        chkdata.Description = modelDescription;
                        chkdata.Publish = modelActive;
                        chkdata.FK_Customer_ID = tmpCustomerID;
                        chkdata.Remark_Type = modelType;
                        chkdata.Update_By = username;
                        chkdata.Update_Date = DateTime.Now;
                        context.SaveChanges();
                        return Json(new { ContentEncoding = 200, data = chkdata });
                    }
                        return Json(new { ContentEncoding = 400 });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("AddMeetingAlert")]
        public JsonResult AddMeetingAlert(string tmpData, int? tmpCustomerID)
        {
            try
            {
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];
                dynamic jsonData = JsonConvert.DeserializeObject(tmpData);
                var modelTopic = Convert.ToString(jsonData[0]["modelTopic"]);
                var modelDescription = Convert.ToString(jsonData[0]["modelDescription"]);
                var modelDate = Convert.ToDateTime(jsonData[0]["modelDate"]);
                var modelPulish = Convert.ToBoolean(jsonData[0]["modelPulish"]);

                using (var context = new OPD_SystemEntities())
                {
                    Alert_Detail AD = new Alert_Detail();
                    AD.Alert_Type = 2;
                    AD.Alert_Date = modelDate;
                    AD.Topic = modelTopic;
                    AD.Description = modelDescription;
                    AD.Publish = modelPulish;
                    AD.FK_Customer_ID = tmpCustomerID;
                    AD.Is_Active = true;
                    AD.Create_By = username;
                    AD.Create_Date = DateTime.Now;
                    context.Alert_Detail.Add(AD);
                    context.SaveChanges();
                    return Json(new { ContentEncoding = 200 , data = AD });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("UpdateMeeetingAlert")]
        public JsonResult UpdateMeeetingAlert(string tmpData, int? tmpCustomerID)
        {
            try
            {
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];
                dynamic jsonData = JsonConvert.DeserializeObject(tmpData);
                int modelID = Convert.ToInt32(jsonData[0]["modelID"]);
                var modelTopic = Convert.ToString(jsonData[0]["modelTopic"]);
                var modelDescription = Convert.ToString(jsonData[0]["modelDescription"]);
                var modelDate = Convert.ToDateTime(jsonData[0]["modelDate"]);
                var modelActive = Convert.ToBoolean(jsonData[0]["modelPulish"]);

                using (var context = new OPD_SystemEntities())
                {
                    var chkdata = context.Alert_Detail.Where(x => x.FK_Customer_ID == tmpCustomerID && x.ID == modelID && x.Alert_Type == 2 && x.Is_Active == true).OrderByDescending(x => x.ID).FirstOrDefault();
                    if (chkdata != null)
                    {
                        chkdata.Alert_Date = modelDate;
                        chkdata.Topic = modelTopic;
                        chkdata.Description = modelDescription;
                        chkdata.Publish = modelActive;
                        chkdata.FK_Customer_ID = tmpCustomerID;
                        chkdata.Update_By = username;
                        chkdata.Update_Date = DateTime.Now;
                        context.SaveChanges();
                        return Json(new { ContentEncoding = 200, data = chkdata });
                    }
                        return Json(new { ContentEncoding = 400 });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("UpdateDataPatient")]
        public JsonResult UpdateDataPatient(string tmpData, int? tmpCustomerID)
        {
            CultureInfo cultureinfo = new CultureInfo("en-US");
            try
            {
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];
                dynamic jsonData = JsonConvert.DeserializeObject(tmpData);
                string pDate = Convert.ToString(jsonData["Date"]);
                string pTime = Convert.ToString(jsonData["Time"]);
                string pT = Convert.ToString(jsonData["T"]);
                string pR = Convert.ToString(jsonData["R"]);
                string pBP = Convert.ToString(jsonData["BP"]);
                string pO2 = Convert.ToString(jsonData["O2"]);
                string pPulseSBP = Convert.ToString(jsonData["PulseSBP"]);
                string pPulseDBP = Convert.ToString(jsonData["PulseDBP"]);
                using (var context = new OPD_SystemEntities())
                {
                    DateTime dateparse = DateTime.ParseExact(pDate, "MMM dd, yyyy", cultureinfo);
                    var chkdata = context.PatientDatas.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Date == dateparse && x.Time == pTime && x.Is_Active == true).ToList();
                    foreach(var items in chkdata)
                    {
                        items.Is_Active = false;
                        items.Update_By = username;
                        items.Update_Date = DateTime.Now;
                        context.SaveChanges();
                    }
                    PatientData PD = new PatientData();
                    PD.FK_Customer_ID = tmpCustomerID;
                    PD.Date = dateparse;//Convert.ToDateTime(pDate);
                    PD.Time = pTime;
                    PD.T = pT;
                    PD.R = pR;
                    PD.BP = pBP;
                    PD.O2 = pO2;
                    PD.PulseDBP = pPulseDBP;
                    PD.PulseSBP = pPulseSBP;
                    PD.Is_Active = true;
                    PD.Create_By = username;
                    PD.Create_Date = DateTime.Now;
                    context.PatientDatas.Add(PD);
                    context.SaveChanges();
                    return Json(new { ContentEncoding = 200 , data = PD });
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public partial class AlertRemark
        {
            public List<PatientChange> PatientChangeData { get; set; }
            public List<Alert_Detail> RemarkData { get; set; }
        }


        [HttpPost, ActionName("CheckRemark")]
        public JsonResult CheckRemark()
        {
            try
            {
                AlertRemark alertRemark = new AlertRemark();
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];
                using (var context = new OPD_SystemEntities())
                {
                    string patientName = "";
                    var datetomorrow = DateTime.Now.AddDays(1);
                    var TempData = (from AD in context.Alert_Detail.Where(x => x.Is_Active == true && x.Alert_Type == 2 && x.Publish == true && x.Alert_Date == datetomorrow.Date)
                                    join CUS in context.Customers.Where(x => x.Is_Active == true) on AD.ID equals CUS.ID
                                    select new
                                    {
                                        PatientName = CUS.PrefixCode + CUS.Tname + " " + CUS.TsurName
                                    }).ToList();
                    foreach (var items in TempData)
                    {
                        patientName += items.PatientName + ", ";
                    }
                    if(!String.IsNullOrEmpty(patientName))
                    {
                        patientName = patientName.Substring(0, patientName.Length - 2);
                        return Json(new { ContentEncoding = 200 , data = patientName});
                    }
                    else
                    {
                        return Json(new { ContentEncoding = 400 });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost, ActionName("CheckMeeting")]
        public JsonResult CheckMeeting(int? tmpCustomerID)
        {
            try
            {
                AlertRemark alertRemark = new AlertRemark();
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];
                if (tmpCustomerID != null)
                {
                    using (var context = new OPD_SystemEntities())
                    {
                        var PatientChangeData = context.PatientChanges.Where(x => x.Is_Active == true && x.Publish == true && x.FK_Customer_ID == tmpCustomerID && (x.NextDateChange != null && DbFunctions.TruncateTime(x.NextDateChange.Value) == DbFunctions.TruncateTime(DateTime.Now))).ToList();
                        alertRemark.PatientChangeData = PatientChangeData;
                        foreach (var items in PatientChangeData)
                        {
                            items.Publish = false;
                            items.Update_By = username;
                            items.Update_Date = DateTime.Now;
                            context.SaveChanges();
                        }
                        var RemarkData = context.Alert_Detail.Where(x => x.Is_Active == true && x.Publish == true && x.FK_Customer_ID == tmpCustomerID && (x.Alert_Date != null && DbFunctions.TruncateTime(x.Alert_Date.Value) == DbFunctions.TruncateTime(DateTime.Now))).ToList();
                        alertRemark.RemarkData = RemarkData;
                        foreach (var items in RemarkData)
                        {
                            items.Publish = false;
                            items.Update_By = username;
                            items.Update_Date = DateTime.Now;
                            context.SaveChanges();
                        }
                        if (PatientChangeData.Count > 0 || RemarkData.Count > 0)
                        {
                            return Json(new { ContentEncoding = 200, data = alertRemark });
                        }
                        else
                        {
                            return Json(null);
                        }
                    }
                }
                return Json(null);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public ActionResult PatientDetail(string customerCN)
        {
            var result = new Customer();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        result = context.Customers.Where(x => x.CN == customerCN).FirstOrDefault();

                        return View(result);
                    }
                }
                else
                {
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                return View(result);
            }
        }

        public ActionResult Attachfile(string customerCN)
        {
            var result = new Customer();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        result = context.Customers.Where(x => x.CN == customerCN).FirstOrDefault();

                        return View(result);
                    }
                }
                else
                {
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                return View(result);
            }
        }

        public partial class ChartShow
        {
            public List<object> chart { get; set; }
            public List<object> chart2 { get; set; }
            public Customer data { get; set; }
        }

        public ActionResult PatientData(string customerCN)
        {
            var result = new ChartShow();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {
                        result.data = context.Customers.Where(x => x.CN == customerCN).FirstOrDefault();

                        List<object> TempPulseSBP = new List<object>();
                        var date8dayago = DateTime.Now.AddDays(-8);
                        var date7dayago = DateTime.Now.AddDays(-7);
                        var date6dayago = DateTime.Now.AddDays(-6);
                        var date5dayago = DateTime.Now.AddDays(-5);
                        var date4dayago = DateTime.Now.AddDays(-4);
                        var date3dayago = DateTime.Now.AddDays(-3);
                        var date2dayago = DateTime.Now.AddDays(-2);
                        var date1dayago = DateTime.Now.AddDays(-1);
                        var FetchData = context.PatientDatas.Where(x => x.Date >= date8dayago && x.Date <= DateTime.Now && x.FK_Customer_ID == result.data.ID && x.Is_Active == true).ToList();
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseSBP) });

                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseSBP) });

                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseSBP) });

                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseSBP) });

                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseSBP) });

                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseSBP) });

                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseSBP) });

                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "02:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "06:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "10:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "14:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "18:00").FirstOrDefault()?.PulseSBP) });
                        TempPulseSBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "22:00").FirstOrDefault()?.PulseSBP) });
                        //TempPulseSBP.Add(new List<object> { Convert.ToDateTime("2564/2/17 22:00:00"), 140 });

                        List<object> TempPulseDBP = new List<object>();
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseDBP) });

                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseDBP) });

                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseDBP) });

                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseDBP) });

                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseDBP) });

                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseDBP) });

                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "02:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "06:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "10:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "14:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "18:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "22:00").FirstOrDefault()?.PulseDBP) });

                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(2)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "02:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(6)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "06:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(10)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "10:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(14)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "14:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(18)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "18:00").FirstOrDefault()?.PulseDBP) });
                        TempPulseDBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(22)),
                            Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "22:00").FirstOrDefault()?.PulseDBP) });
                        //TempPulseDBP.Add(new List<object> { Convert.ToDateTime("2564/2/17 22:00:00"), 85 });

                        result.chart = TempPulseSBP;
                        result.chart2 = TempPulseDBP;

                        return View(result);
                    }
                }
                else
                {
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                return View(result);
            }
        }

        public ActionResult MedicalExpire(string customerCN)
        {
            var result = new Customer();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        result = context.Customers.Where(x => x.CN == customerCN).FirstOrDefault();

                        return View(result);
                    }
                }
                else
                {
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                return View(result);
            }
        }

        public ActionResult Remark(string customerCN)
        {
            var result = new Customer();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        result = context.Customers.Where(x => x.CN == customerCN).FirstOrDefault();

                        return View(result);
                    }
                }
                else
                {
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                return View(result);
            }
        }

        public ActionResult Meeting(string customerCN)
        {
            var result = new Customer();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        result = context.Customers.Where(x => x.CN == customerCN).FirstOrDefault();

                        return View(result);
                    }
                }
                else
                {
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                return View(result);
            }
        }

        public ActionResult Test(string customerCN)
        {
            var result = new Customer();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        result = context.Customers.Where(x => x.CN == customerCN).FirstOrDefault();

                        return View(result);
                    }
                }
                else
                {
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                return View(result);
            }
        }
    }
}