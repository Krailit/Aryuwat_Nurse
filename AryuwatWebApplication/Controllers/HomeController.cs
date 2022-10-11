using AryuwatWebApplication.Entity;
using AryuwatWebApplication.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            public int ID { get; set; }
            public string Patient_Name { get; set; }
            public string CN { get; set; }
            public string Room { get; set; }
            public DateTime? Start { get; set; }
            public DateTime? End { get; set; }
            public DateTime? Meeting { get; set; }
            public string PATH { get; set; }
        }

        public string TableCustomer ()
        {
            string query = @"SELECT TOP 10 * from (					
                                    select
	                                    cus.PrefixCode + cus.Tname + ' ' + cus.TsurName Patient_Name,
	                                    cus.ID,
	                                    cus.CN,
	                                    cus.BranchID,
	                                    MR.Room_Name Room,
                                        RD.Start_Date Start,
                                        case 
		                                    when RD.Start_Date is not null
		                                    then DATEADD(DAY,RD.Qty_Date , RD.Start_Date) 
		                                    else null 
	                                    end [End],
										AD.Alert_Date as Meeting,
										cus.Is_Active
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
									WHERE Is_Active = 1 ";
            return query;
        }

        [AllowJsonGet]
        [HttpGet, ActionName("TableCustomer")]
        public async Task<JsonResult> TableCustomer(string searchtxt)
        {
            try
            {
                using (var context = new OPD_SystemEntities())
                {
                    string query = TableCustomer();
                    query += "and Patient_Name like '%" + searchtxt + "%'";
                    string BranchAuth = Request.Cookies["OPD"]["BranchAuth"];
                    var splitBranch = BranchAuth.Split(',');
                    bool firstflag = true;
                    foreach(var items in splitBranch)
                    {
                        if (firstflag)
                        {
                            query += " and";
                            firstflag = !firstflag;
                        }
                        else
                        {
                            query += " or";
                        }
                        query += " BranchID like '%" + items + "%'";
                    }

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

        [AllowJsonGet]
        [HttpGet, ActionName("DeleteAttachfile")]
        public async Task<JsonResult> DeleteAttachfile(int? AttachId)
        {
            try
            {
                if (AttachId > 0)
                {
                    using (var context = new OPD_SystemEntities())
                    {
                        var result = context.FileOPDs.Where(x => x.Id == AttachId).FirstOrDefault();
                        if(result != null)
                        {
                            context.FileOPDs.Remove(result);
                            context.SaveChanges(); 
                            return Json(new { ContentEncoding = 200 });
                        }
                        return Json(null);
                    }
                }
                return Json(null);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public void ResizeStream(int imageSize, Stream filePath, string outputPath)
        {
            var image = System.Drawing.Image.FromStream(filePath);

            int thumbnailSize = imageSize;
            int newWidth, newHeight;

            if (image.Width > image.Height)
            {
                newWidth = thumbnailSize;
                newHeight = image.Height * thumbnailSize / image.Width;
            }
            else
            {
                newWidth = image.Width * thumbnailSize / image.Height;
                newHeight = thumbnailSize;
            }

            var thumbnailBitmap = new Bitmap(newWidth, newHeight);

            var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbnailGraph.DrawImage(image, imageRectangle);

            thumbnailBitmap.Save(outputPath, image.RawFormat);
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            image.Dispose();
        }

        [HttpPost, ActionName("UploadFile")]
        public JsonResult UploadFile(string CN,string Detail, HttpPostedFileBase AttachFileData)
        {
            try
            {
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];

                using (var context = new OPD_SystemEntities())
                {
                    if (AttachFileData != null && AttachFileData.ContentLength > 0)
                    {
                        int ScaleIMG = Convert.ToInt32(ConfigurationManager.AppSettings["ScaleIMG"]);
                        var hpf = AttachFileData as HttpPostedFileBase;
                        var fileName = Path.GetFileName(AttachFileData.FileName);
                        var newFileName = "OPD_" + CN + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "." + AttachFileData.FileName.Split('.').ElementAt(1);
                        ResizeStream(ScaleIMG, hpf.InputStream, Path.Combine(Server.MapPath("~/AttachFile_Aryuwat"), newFileName));
                        //var path = Path.Combine(Server.MapPath("~/AttachFile_Aryuwat"), newFileName);
                        //AttachFileData.SaveAs(path);
                        FileOPD fopd = new FileOPD();
                        fopd.FileName = newFileName;
                        fopd.Detail = Detail;
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
                    var datetomorrow = DateTime.Now.AddDays(1);
                    var TempData = (from AD in context.Alert_Detail.Where(x => x.Is_Active == true && x.Alert_Type == 2 && x.Publish == true && x.Alert_Date == datetomorrow.Date)
                                    join CUS in context.Customers.Where(x => x.Is_Active == true) on AD.FK_Customer_ID equals CUS.ID
                                    select new
                                    {
                                       ID = AD.ID,
                                       PatientName = CUS.PrefixCode + CUS.Tname + " " + CUS.TsurName,
                                       Date = AD.Alert_Date,
                                       Description = AD.Description,
                                    }).ToList(); 
                    foreach(var items in TempData)
                    {
                        var client = new RestClient("https://notify-api.line.me/api/notify");
                        var request = new RestRequest("", Method.Post);
                        request.AddHeader("Authorization", "Bearer " + Convert.ToString(lineToken).Trim());
                        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
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
                                        (select top 1 DateChange FROM[OPD_System].[dbo].[PatientChange] where Type = 1  and [Count] = pt.[Count] and FK_Customer_ID = " + tmpCustomerID + @") as oneNextChange,
	                                    (select top 1 DateChange FROM[OPD_System].[dbo].[PatientChange] where Type = 2  and [Count] = pt.[Count] and FK_Customer_ID = " + tmpCustomerID + @") as twoNextChange
                                        FROM[OPD_System].[dbo].[PatientChange] pt  where FK_Customer_ID = " + tmpCustomerID + @"
	                                    order by [Count] desc";
                        var resultquery = context.Database.SqlQuery<MedicalExpireModel>(query).ToList();
                        var result = context.PatientChanges.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true).ToList();
                        if (result.Count > 0)
                        {
                            var onelastchange = result.Where(x => x.Type == 1).OrderByDescending(x => x.ID).FirstOrDefault()?.DateChange;
                            var onenextchange = result.Where(x => x.Type == 1).OrderByDescending(x => x.ID).FirstOrDefault()?.NextDateChange;
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
        public JsonResult GetPatientData(int? tmpCustomerID,string ToDate,string EndDate)
        {
            try
            {
                using (var context = new OPD_SystemEntities())
                {
                    if (tmpCustomerID != 0)
                    {
                        //var test = context.PatientDatas.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true).ToList();
                        var ConToDate = Convert.ToDateTime(ToDate);
                        var ConEndDate = Convert.ToDateTime(EndDate);
                        var result = context.PatientDatas.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true && (x.Date >= ConToDate.Date && x.Date <= ConEndDate.Date)).ToList();
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
                    //PC.NextDateChange = type == 1 ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(15);                    
                    PC.NextDateChange = DateTime.Now.AddDays(15);
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

        [HttpPost, ActionName("UpdateMeetingAlert")]
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
                var pDatetxt = jsonData["Datetxt"];
                string pHour = Convert.ToString(jsonData["Hour"]);
                string pMinute = Convert.ToString(jsonData["Minute"]);
                string pT = Convert.ToString(jsonData["T"]);
                string pR = Convert.ToString(jsonData["R"]);
                string pBP = Convert.ToString(jsonData["BP"]);
                string pO2 = Convert.ToString(jsonData["O2"]);
                string pPulseSBP = Convert.ToString(jsonData["PulseSBP"]);
                string pPulseDBP = Convert.ToString(jsonData["PulseDBP"]);
                string pIn_Oral = Convert.ToString(jsonData["In_Oral"]);
                string pIn_Parenteral = Convert.ToString(jsonData["In_Parenteral"]);
                string pOut_Stools = Convert.ToString(jsonData["Out_Stools"]);
                string pOut_Urine = Convert.ToString(jsonData["Out_Urine"]);
                using (var context = new OPD_SystemEntities())
                {
                    DateTime dateparse = Convert.ToDateTime(pDatetxt);
                    //DateTime dateparse = DateTime.ParseExact(pDate, "MMM dd, yyyy", cultureinfo);
                    var chkdata = context.PatientDatas.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Date == dateparse && x.Time == pHour+":"+pMinute && x.Is_Active == true).ToList();
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
                    PD.Time = pHour+":"+ pMinute;
                    PD.T = String.IsNullOrEmpty(pT) ? null : pT;
                    PD.R = pR;
                    PD.BP = String.IsNullOrEmpty(pBP) ? null : pBP;
                    PD.O2 = pO2;
                    PD.PulseDBP = pPulseDBP;
                    PD.PulseSBP = pPulseSBP;
                    PD.In_Oral = pIn_Oral;
                    PD.In_Parenteral = pIn_Parenteral;
                    PD.Out_Stools = pOut_Stools;
                    PD.Out_Urine = pOut_Urine;
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


        [HttpPost, ActionName("CheckMeeting")]
        public JsonResult CheckMeeting()
        {
            try
            {
                AlertRemark alertRemark = new AlertRemark();
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];
                using (var context = new OPD_SystemEntities())
                {
                    string patientName = "";
                    var datetomorrow = DateTime.Now.AddDays(1);
                    var TempData = (from AD in context.Alert_Detail.Where(x => x.Is_Active == true && x.Publish == true && x.Alert_Type == 2 && x.Alert_Date == datetomorrow.Date)
                                    join CUS in context.Customers.Where(x => x.Is_Active == true) on AD.FK_Customer_ID equals CUS.ID
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

        [HttpPost, ActionName("CheckRemark")]
        public JsonResult CheckRemark(int? tmpCustomerID)
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
                        var RemarkData = context.Alert_Detail.Where(x => x.Is_Active == true && x.Publish == true && x.Alert_Type == 1 && x.FK_Customer_ID == tmpCustomerID && (x.Alert_Date != null && DbFunctions.TruncateTime(x.Alert_Date.Value) == DbFunctions.TruncateTime(DateTime.Now))).ToList();
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
            var result = new TempPatientData();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        string query = TableCustomer();
                        query += "and CN = '" + customerCN + "'";

                        result = context.Database.SqlQuery<TempPatientData>(query).FirstOrDefault();

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
            var result = new TempPatientData();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        string FTPFile = ConfigurationManager.AppSettings["FTPFile"];
                        string query = TableCustomer();
                        query += "and CN = '" + customerCN + "'";

                        result = context.Database.SqlQuery<TempPatientData>(query).FirstOrDefault();

                        result.PATH = FTPFile;

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
            public TempPatientData data { get; set; }
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
                        string query = TableCustomer();
                        query += "and CN = '" + customerCN + "'";

                        result.data = context.Database.SqlQuery<TempPatientData>(query).FirstOrDefault();
                        result.chart = null;
                        result.chart2 = null;
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

        #region bkPatientData 01/06/2021
        //public ActionResult PatientData(string customerCN)
        //{
        //    var result = new ChartShow();
        //    try
        //    {
        //        if (!String.IsNullOrEmpty(customerCN))
        //        {
        //            using (var context = new OPD_SystemEntities())
        //            {
        //                string query = TableCustomer();
        //                query += "and CN = '" + customerCN + "'";

        //                result.data = context.Database.SqlQuery<TempPatientData>(query).FirstOrDefault();

        //                List<object> TempT = new List<object>();
        //                var date8dayago = DateTime.Now.AddDays(-8);
        //                var date7dayago = DateTime.Now.AddDays(-7);
        //                var date6dayago = DateTime.Now.AddDays(-6);
        //                var date5dayago = DateTime.Now.AddDays(-5);
        //                var date4dayago = DateTime.Now.AddDays(-4);
        //                var date3dayago = DateTime.Now.AddDays(-3);
        //                var date2dayago = DateTime.Now.AddDays(-2);
        //                var date1dayago = DateTime.Now.AddDays(-1);
        //                var FetchData = context.PatientDatas.Where(x => x.Date >= date8dayago && x.Date <= DateTime.Now && x.FK_Customer_ID == result.data.ID && x.Is_Active == true).ToList();

        //                #region 7sbp
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(0)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "00:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(0.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "00:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(1)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "01:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(1.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "01:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(2)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "02:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(2.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "02:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(3)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "03:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(3.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "03:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(4)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "04:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(4.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "04:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(5)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "05:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(5.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "05:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(6)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "06:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(6.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "06:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(7)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "07:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(7.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "07:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(8)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "08:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(8.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "08:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(9)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "09:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(9.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "09:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(10)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "10:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(10.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "10:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(11)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "11:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(11.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "11:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(12)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "12:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(12.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "12:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(13)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "13:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(13.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "13:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(14)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "14:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(14.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "14:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(15)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "15:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(15.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "15:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(16)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "16:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(16.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "16:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(17)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "17:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(17.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "17:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(18)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "18:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(18.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "18:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(19)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "19:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(19.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "19:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(20)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "20:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(20.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "20:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(21)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "21:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(21.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "21:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(22)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "22:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(22.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "22:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(23)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "23:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(23.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "23:30").FirstOrDefault()?.T) });
        //                #endregion

        //                #region 6sbp
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(0)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "00:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(0.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "00:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(1)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "01:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(1.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "01:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(2)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "02:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(2.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "02:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(3)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "03:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(3.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "03:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(4)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "04:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(4.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "04:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(5)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "05:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(5.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "05:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(6)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "06:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(6.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "06:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(7)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "07:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(7.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "07:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(8)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "08:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(8.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "08:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(9)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "09:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(9.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "09:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(10)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "10:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(10.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "10:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(11)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "11:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(11.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "11:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(12)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "12:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(12.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "12:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(13)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "13:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(13.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "13:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(14)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "14:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(14.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "14:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(15)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "15:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(15.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "15:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(16)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "16:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(16.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "16:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(17)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "17:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(17.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "17:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(18)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "18:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(18.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "18:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(19)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "19:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(19.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "19:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(20)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "20:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(20.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "20:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(21)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "21:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(21.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "21:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(22)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "22:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(22.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "22:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(23)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "23:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(23.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "23:30").FirstOrDefault()?.T) });
        //                #endregion

        //                #region 5sbp
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(0)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "00:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(0.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "00:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(1)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "01:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(1.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "01:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(2)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "02:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(2.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "02:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(3)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "03:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(3.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "03:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(4)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "04:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(4.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "04:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(5)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "05:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(5.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "05:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(6)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "06:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(6.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "06:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(7)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "07:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(7.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "07:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(8)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "08:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(8.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "08:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(9)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "09:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(9.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "09:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(10)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "10:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(10.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "10:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(11)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "11:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(11.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "11:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(12)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "12:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(12.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "12:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(13)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "13:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(13.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "13:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(14)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "14:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(14.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "14:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(15)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "15:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(15.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "15:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(16)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "16:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(16.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "16:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(17)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "17:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(17.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "17:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(18)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "18:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(18.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "18:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(19)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "19:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(19.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "19:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(20)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "20:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(20.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "20:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(21)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "21:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(21.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "21:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(22)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "22:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(22.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "22:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(23)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "23:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(23.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "23:30").FirstOrDefault()?.T) });
        //                #endregion

        //                #region 4sbp
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(0)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "00:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(0.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "00:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(1)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "01:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(1.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "01:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(2)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "02:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(2.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "02:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(3)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "03:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(3.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "03:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(4)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "04:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(4.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "04:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(5)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "05:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(5.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "05:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(6)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "06:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(6.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "06:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(7)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "07:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(7.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "07:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(8)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "08:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(8.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "08:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(9)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "09:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(9.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "09:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(10)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "10:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(10.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "10:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(11)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "11:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(11.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "11:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(12)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "12:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(12.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "12:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(13)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "13:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(13.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "13:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(14)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "14:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(14.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "14:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(15)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "15:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(15.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "15:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(16)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "16:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(16.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "16:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(17)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "17:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(17.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "17:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(18)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "18:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(18.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "18:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(19)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "19:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(19.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "19:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(20)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "20:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(20.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "20:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(21)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "21:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(21.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "21:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(22)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "22:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(22.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "22:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(23)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "23:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(23.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "23:30").FirstOrDefault()?.T) });
        //                #endregion

        //                #region 3sbp
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(0)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "00:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(0.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "00:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(1)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "01:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(1.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "01:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(2)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "02:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(2.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "02:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(3)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "03:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(3.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "03:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(4)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "04:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(4.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "04:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(5)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "05:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(5.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "05:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(6)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "06:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(6.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "06:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(7)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "07:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(7.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "07:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(8)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "08:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(8.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "08:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(9)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "09:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(9.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "09:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(10)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "10:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(10.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "10:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(11)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "11:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(11.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "11:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(12)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "12:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(12.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "12:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(13)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "13:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(13.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "13:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(14)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "14:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(14.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "14:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(15)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "15:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(15.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "15:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(16)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "16:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(16.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "16:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(17)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "17:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(17.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "17:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(18)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "18:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(18.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "18:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(19)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "19:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(19.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "19:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(20)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "20:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(20.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "20:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(21)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "21:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(21.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "21:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(22)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "22:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(22.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "22:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(23)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "23:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(23.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "23:30").FirstOrDefault()?.T) });
        //                #endregion

        //                #region 2sbp
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(0)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "00:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(0.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "00:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(1)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "01:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(1.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "01:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(2)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "02:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(2.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "02:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(3)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "03:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(3.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "03:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(4)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "04:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(4.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "04:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(5)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "05:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(5.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "05:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(6)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "06:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(6.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "06:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(7)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "07:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(7.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "07:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(8)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "08:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(8.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "08:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(9)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "09:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(9.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "09:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(10)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "10:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(10.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "10:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(11)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "11:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(11.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "11:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(12)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "12:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(12.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "12:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(13)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "13:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(13.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "13:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(14)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "14:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(14.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "14:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(15)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "15:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(15.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "15:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(16)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "16:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(16.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "16:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(17)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "17:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(17.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "17:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(18)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "18:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(18.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "18:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(19)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "19:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(19.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "19:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(20)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "20:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(20.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "20:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(21)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "21:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(21.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "21:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(22)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "22:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(22.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "22:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(23)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "23:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(23.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "23:30").FirstOrDefault()?.T) });
        //                #endregion

        //                #region 1sbp
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(0)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "00:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(0.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "00:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(1)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "01:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(1.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "01:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(2)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "02:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(2.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "02:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(3)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "03:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(3.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "03:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(4)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "04:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(4.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "04:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(5)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "05:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(5.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "05:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(6)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "06:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(6.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "06:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(7)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "07:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(7.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "07:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(8)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "08:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(8.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "08:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(9)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "09:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(9.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "09:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(10)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "10:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(10.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "10:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(11)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "11:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(11.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "11:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(12)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "12:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(12.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "12:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(13)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "13:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(13.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "13:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(14)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "14:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(14.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "14:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(15)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "15:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(15.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "15:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(16)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "16:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(16.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "16:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(17)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "17:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(17.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "17:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(18)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "18:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(18.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "18:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(19)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "19:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(19.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "19:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(20)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "20:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(20.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "20:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(21)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "21:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(21.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "21:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(22)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "22:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(22.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "22:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(23)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "23:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(23.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "23:30").FirstOrDefault()?.T) });
        //                #endregion

        //                #region todaysbp
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(0)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "00:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(0.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "00:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(1)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "01:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(1.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "01:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(2)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "02:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(2.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "02:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(3)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "03:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(3.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "03:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(4)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "04:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(4.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "04:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(5)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "05:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(5.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "05:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(6)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "06:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(6.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "06:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(7)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "07:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(7.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "07:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(8)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "08:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(8.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "08:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(9)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "09:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(9.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "09:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(10)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "10:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(10.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "10:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(11)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "11:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(11.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "11:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(12)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "12:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(12.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "12:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(13)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "13:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(13.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "13:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(14)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "14:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(14.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "14:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(15)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "15:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(15.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "15:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(16)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "16:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(16.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "16:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(17)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "17:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(17.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "17:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(18)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "18:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(18.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "18:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(19)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "19:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(19.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "19:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(20)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "20:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(20.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "20:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(21)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "21:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(21.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "21:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(22)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "22:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(22.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "22:30").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(23)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "23:00").FirstOrDefault()?.T) });
        //                TempT.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(23.50)),
        //                    Convert.ToDouble(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "23:30").FirstOrDefault()?.T) });
        //                #endregion

        //                List<object> TempBP = new List<object>();

        //                #region 7DBP
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(0)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "00:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(0.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "00:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(1)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "01:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(1.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "01:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(2)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "02:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(2.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "02:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(3)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "03:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(3.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "03:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(4)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "04:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(4.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "04:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(5)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "05:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(5.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "05:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(6)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "06:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(6.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "06:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(7)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "07:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(7.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "07:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(8)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "08:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(8.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "08:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(9)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "09:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(9.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "09:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(10)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "10:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(10.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "10:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(11)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "11:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(11.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "11:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(12)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "12:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(12.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "12:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(13)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "13:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(13.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "13:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(14)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "14:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(14.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "14:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(15)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "15:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(15.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "15:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(16)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "16:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(16.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "16:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(17)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "17:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(17.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "17:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(18)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "18:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(18.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "18:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(19)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "19:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(19.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "19:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(20)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "20:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(20.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "20:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(21)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "21:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(21.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "21:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(22)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "22:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(22.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "22:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(23)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "23:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date7dayago.Date.AddHours(23.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date7dayago.Date && x.Time == "23:30").FirstOrDefault()?.BP) });
        //                #endregion

        //                #region 6DBP
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(0)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "00:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(0.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "00:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(1)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "01:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(1.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "01:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(2)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "02:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(2.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "02:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(3)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "03:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(3.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "03:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(4)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "04:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(4.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "04:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(5)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "05:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(5.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "05:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(6)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "06:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(6.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "06:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(7)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "07:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(7.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "07:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(8)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "08:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(8.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "08:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(9)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "09:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(9.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "09:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(10)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "10:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(10.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "10:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(11)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "11:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(11.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "11:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(12)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "12:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(12.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "12:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(13)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "13:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(13.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "13:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(14)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "14:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(14.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "14:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(15)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "15:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(15.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "15:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(16)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "16:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(16.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "16:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(17)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "17:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(17.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "17:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(18)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "18:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(18.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "18:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(19)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "19:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(19.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "19:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(20)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "20:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(20.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "20:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(21)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "21:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(21.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "21:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(22)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "22:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(22.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "22:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(23)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "23:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date6dayago.Date.AddHours(23.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date6dayago.Date && x.Time == "23:30").FirstOrDefault()?.BP) });
        //                #endregion

        //                #region 5DBP
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(0)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "00:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(0.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "00:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(1)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "01:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(1.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "01:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(2)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "02:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(2.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "02:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(3)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "03:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(3.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "03:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(4)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "04:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(4.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "04:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(5)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "05:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(5.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "05:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(6)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "06:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(6.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "06:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(7)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "07:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(7.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "07:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(8)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "08:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(8.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "08:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(9)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "09:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(9.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "09:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(10)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "10:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(10.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "10:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(11)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "11:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(11.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "11:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(12)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "12:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(12.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "12:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(13)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "13:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(13.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "13:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(14)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "14:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(14.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "14:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(15)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "15:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(15.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "15:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(16)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "16:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(16.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "16:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(17)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "17:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(17.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "17:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(18)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "18:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(18.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "18:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(19)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "19:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(19.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "19:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(20)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "20:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(20.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "20:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(21)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "21:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(21.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "21:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(22)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "22:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(22.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "22:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(23)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "23:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date5dayago.Date.AddHours(23.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date5dayago.Date && x.Time == "23:30").FirstOrDefault()?.BP) });
        //                #endregion

        //                #region 4DBP
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(0)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "00:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(0.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "00:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(1)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "01:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(1.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "01:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(2)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "02:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(2.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "02:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(3)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "03:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(3.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "03:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(4)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "04:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(4.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "04:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(5)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "05:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(5.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "05:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(6)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "06:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(6.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "06:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(7)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "07:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(7.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "07:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(8)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "08:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(8.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "08:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(9)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "09:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(9.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "09:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(10)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "10:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(10.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "10:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(11)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "11:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(11.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "11:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(12)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "12:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(12.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "12:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(13)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "13:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(13.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "13:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(14)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "14:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(14.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "14:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(15)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "15:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(15.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "15:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(16)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "16:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(16.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "16:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(17)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "17:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(17.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "17:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(18)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "18:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(18.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "18:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(19)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "19:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(19.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "19:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(20)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "20:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(20.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "20:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(21)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "21:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(21.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "21:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(22)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "22:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(22.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "22:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(23)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "23:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date4dayago.Date.AddHours(23.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date4dayago.Date && x.Time == "23:30").FirstOrDefault()?.BP) });
        //                #endregion

        //                #region 3DBP
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(0)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "00:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(0.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "00:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(1)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "01:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(1.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "01:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(2)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "02:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(2.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "02:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(3)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "03:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(3.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "03:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(4)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "04:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(4.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "04:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(5)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "05:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(5.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "05:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(6)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "06:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(6.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "06:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(7)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "07:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(7.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "07:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(8)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "08:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(8.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "08:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(9)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "09:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(9.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "09:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(10)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "10:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(10.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "10:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(11)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "11:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(11.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "11:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(12)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "12:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(12.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "12:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(13)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "13:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(13.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "13:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(14)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "14:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(14.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "14:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(15)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "15:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(15.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "15:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(16)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "16:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(16.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "16:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(17)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "17:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(17.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "17:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(18)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "18:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(18.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "18:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(19)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "19:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(19.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "19:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(20)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "20:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(20.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "20:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(21)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "21:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(21.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "21:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(22)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "22:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(22.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "22:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(23)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "23:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date3dayago.Date.AddHours(23.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date3dayago.Date && x.Time == "23:30").FirstOrDefault()?.BP) });
        //                #endregion

        //                #region 2DBP
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(0)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "00:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(0.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "00:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(1)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "01:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(1.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "01:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(2)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "02:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(2.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "02:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(3)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "03:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(3.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "03:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(4)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "04:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(4.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "04:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(5)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "05:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(5.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "05:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(6)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "06:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(6.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "06:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(7)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "07:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(7.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "07:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(8)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "08:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(8.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "08:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(9)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "09:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(9.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "09:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(10)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "10:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(10.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "10:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(11)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "11:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(11.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "11:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(12)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "12:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(12.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "12:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(13)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "13:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(13.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "13:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(14)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "14:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(14.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "14:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(15)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "15:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(15.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "15:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(16)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "16:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(16.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "16:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(17)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "17:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(17.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "17:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(18)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "18:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(18.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "18:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(19)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "19:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(19.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "19:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(20)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "20:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(20.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "20:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(21)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "21:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(21.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "21:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(22)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "22:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(22.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "22:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(23)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "23:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date2dayago.Date.AddHours(23.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date2dayago.Date && x.Time == "23:30").FirstOrDefault()?.BP) });
        //                #endregion

        //                #region 1DBP
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(0)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "00:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(0.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "00:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(1)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "01:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(1.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "01:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(2)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "02:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(2.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "02:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(3)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "03:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(3.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "03:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(4)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "04:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(4.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "04:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(5)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "05:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(5.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "05:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(6)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "06:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(6.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "06:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(7)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "07:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(7.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "07:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(8)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "08:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(8.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "08:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(9)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "09:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(9.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "09:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(10)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "10:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(10.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "10:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(11)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "11:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(11.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "11:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(12)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "12:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(12.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "12:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(13)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "13:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(13.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "13:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(14)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "14:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(14.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "14:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(15)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "15:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(15.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "15:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(16)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "16:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(16.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "16:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(17)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "17:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(17.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "17:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(18)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "18:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(18.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "18:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(19)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "19:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(19.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "19:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(20)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "20:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(20.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "20:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(21)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "21:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(21.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "21:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(22)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "22:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(22.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "22:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(23)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "23:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(date1dayago.Date.AddHours(23.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == date1dayago.Date && x.Time == "23:30").FirstOrDefault()?.BP) });
        //                #endregion

        //                #region todayDBP
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(0)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "00:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(0.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "00:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(1)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "01:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(1.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "01:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(2)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "02:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(2.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "02:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(3)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "03:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(3.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "03:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(4)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "04:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(4.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "04:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(5)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "05:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(5.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "05:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(6)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "06:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(6.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "06:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(7)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "07:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(7.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "07:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(8)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "08:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(8.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "08:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(9)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "09:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(9.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "09:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(10)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "10:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(10.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "10:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(11)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "11:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(11.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "11:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(12)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "12:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(12.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "12:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(13)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "13:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(13.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "13:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(14)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "14:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(14.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "14:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(15)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "15:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(15.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "15:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(16)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "16:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(16.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "16:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(17)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "17:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(17.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "17:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(18)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "18:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(18.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "18:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(19)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "19:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(19.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "19:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(20)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "20:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(20.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "20:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(21)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "21:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(21.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "21:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(22)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "22:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(22.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "22:30").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(23)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "23:00").FirstOrDefault()?.BP) });
        //                TempBP.Add(new List<object> { Convert.ToDateTime(DateTime.Now.Date.AddHours(23.50)),
        //                    Convert.ToInt32(FetchData.Where(x => x.Date == DateTime.Now.Date && x.Time == "23:30").FirstOrDefault()?.BP) });
        //                #endregion

        //                result.chart = TempT;
        //                result.chart2 = TempBP;

        //                return View(result);
        //            }
        //        }
        //        else
        //        {
        //            return View(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(result);
        //    }
        //}

        #endregion

        [HttpPost, ActionName("PatientChartData")]
        public JsonResult PatientChartData(string tempData)
        {
            var result = new ChartShow();
            try
            {
                if (!String.IsNullOrEmpty(tempData))
                {
                    using (var context = new OPD_SystemEntities())
                    {
                        dynamic jsData = JsonConvert.DeserializeObject(tempData);
                        int? tmpCustomerID = Convert.ToInt32(jsData.tmpCustomerID);
                        DateTime ConToDate = Convert.ToDateTime(jsData.ToDateSearch);
                        DateTime ConEndDate = Convert.ToDateTime(jsData.EndDateSearch);
                        string search = jsData.Search;
                        string PatientName = jsData.PatientName;
                        string PatientRoom = jsData.PatientRoom;

                        List<object> TempT = new List<object>();
                        List<object> TempBP = new List<object>();
                        var FetchData = context.PatientDatas.Where(x => x.Date >= ConToDate.Date && x.Date <= ConEndDate.Date && x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true).OrderBy(x => x.Date).ThenBy(x => x.Time).ToList();

                        foreach (var items in FetchData)
                        {
                            TempT.Add(new List<object> { Convert.ToDateTime(items.Date.ToString().Split(' ').ElementAt(0) + " " +  items.Time),
                            Convert.ToDouble(items.T) });

                            TempBP.Add(new List<object> { Convert.ToDateTime(items.Date.ToString().Split(' ').ElementAt(0) + " " +  items.Time),
                            Convert.ToInt32(items.BP) });
                        }

                        result.chart = TempT;
                        result.chart2 = TempBP;

                        return Json(new { ContentEncoding = 200, data = result });
                    }
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public ActionResult MedicalExpire(string customerCN)
        {
            var result = new TempPatientData();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        string query = TableCustomer();
                        query += "and CN = '" + customerCN + "'";

                        result = context.Database.SqlQuery<TempPatientData>(query).FirstOrDefault();

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
            var result = new TempPatientData();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        string query = TableCustomer();
                        query += "and CN = '" + customerCN + "'";

                        result = context.Database.SqlQuery<TempPatientData>(query).FirstOrDefault();

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
            var result = new TempPatientData();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        string query = TableCustomer();
                        query += "and CN = '" + customerCN + "'";

                        result = context.Database.SqlQuery<TempPatientData>(query).FirstOrDefault();

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
            var result = new TempPatientData();
            try
            {
                if (!String.IsNullOrEmpty(customerCN))
                {
                    using (var context = new OPD_SystemEntities())
                    {

                        string query = TableCustomer();
                        query += "and CN = '" + customerCN + "'";

                        result = context.Database.SqlQuery<TempPatientData>(query).FirstOrDefault();

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

        [AllowJsonGet]
        [HttpGet, ActionName("GetDataPatient")]
        public async Task<JsonResult> GetDataPatient(TableSearchReceive tempData)
        {
            using (var context = new OPD_SystemEntities())
            {
                try
                {
                    int tmpCustomerID = Convert.ToInt32(tempData.filter1);
                    var ConToDate = Convert.ToDateTime(tempData.filter2);
                    var ConEndDate = Convert.ToDateTime(tempData.filter3);
                    string search = tempData.filter4;
                    var res = new List<PatientData>();
                    if (!String.IsNullOrEmpty(search))
                    {
                        res = (from a in context.PatientDatas
                               where ((a.Time ?? "").Contains(search) || (a.BP ?? "").Contains(search) || (a.In_Oral ?? "").Contains(search) || (a.In_Parenteral ?? "").Contains(search) || (a.O2 ?? "").Contains(search) || (a.Out_Stools ?? "").Contains(search) || (a.Out_Urine ?? "").Contains(search) || (a.PulseDBP ?? "").Contains(search) || (a.PulseSBP ?? "").Contains(search) || (a.R ?? "").Contains(search) || (a.T ?? "").Contains(search))
                               select a
                                   ).Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true && (x.Date >= ConToDate.Date && x.Date <= ConEndDate.Date)).ToList();
                    }
                    else
                    {
                        res = context.PatientDatas.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true && (x.Date >= ConToDate.Date && x.Date <= ConEndDate.Date)).ToList();
                    }
                    var result = new List<PatientData>();
                    int? total = res.Count();
                    if (total.HasValue ? total.Value > 0 : false)
                    {
                        int? last_page = (int)Math.Ceiling((double)total / (double)tempData.per_page);
                        bool sortType = tempData.sort.Split('|')[1].Equals("asc");
                        string sortName = tempData.sort.Split('|')[0];
                        if (sortType)
                        {
                            if (sortName == "BP")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.BP) ? int.Parse("0") : int.Parse(x.BP)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "Date")
                            {
                                result = res.OrderBy(x => x.Date).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "In_Oral")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.In_Oral) ? int.Parse("0") : int.Parse(x.In_Oral)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "In_Parenteral")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.In_Parenteral) ? int.Parse("0") : int.Parse(x.In_Parenteral)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "O2")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.O2) ? int.Parse("0") : int.Parse(x.O2)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "Out_Stools")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.Out_Stools) ? int.Parse("0") : int.Parse(x.Out_Stools)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "Out_Urine")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.Out_Urine) ? int.Parse("0") : int.Parse(x.Out_Urine)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "PulseDBP")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.PulseDBP) ? int.Parse("0") : int.Parse(x.PulseDBP)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "PulseSBP")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.PulseSBP) ? int.Parse("0") : int.Parse(x.PulseSBP)).ThenBy(x => string.IsNullOrEmpty(x.PulseDBP) ? int.Parse("0") : int.Parse(x.PulseDBP)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "R")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.R) ? int.Parse("0") : int.Parse(x.R)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "T")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.T) ? double.Parse("0") : double.Parse(x.T)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "Time")
                            {
                                result = res.OrderBy(x => string.IsNullOrEmpty(x.Time) ? int.Parse("0") : int.Parse(x.Time.Replace(":", ""))).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else
                            {
                                result = res.OrderBy(x => x.ID).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                        }
                        else
                        {
                            if (sortName == "BP")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.BP) ? int.Parse("0") : int.Parse(x.BP)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "Date")
                            {
                                result = res.OrderByDescending(x => x.Date).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "In_Oral")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.In_Oral) ? int.Parse("0") : int.Parse(x.In_Oral)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "In_Parenteral")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.In_Parenteral) ? int.Parse("0") : int.Parse(x.In_Parenteral)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "O2")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.O2) ? int.Parse("0") : int.Parse(x.O2)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "Out_Stools")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.Out_Stools) ? int.Parse("0") : int.Parse(x.Out_Stools)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "Out_Urine")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.Out_Urine) ? int.Parse("0") : int.Parse(x.Out_Urine)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "PulseDBP")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.PulseDBP) ? int.Parse("0") : int.Parse(x.PulseDBP)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "PulseSBP")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.PulseSBP) ? int.Parse("0") : int.Parse(x.PulseSBP)).ThenByDescending(x => string.IsNullOrEmpty(x.PulseDBP) ? int.Parse("0") : int.Parse(x.PulseDBP)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "R")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.R) ? int.Parse("0") : int.Parse(x.R)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "T")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.T) ? double.Parse("0") : double.Parse(x.T)).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else if (sortName == "Time")
                            {
                                result = res.OrderByDescending(x => string.IsNullOrEmpty(x.Time) ? int.Parse("0") : int.Parse(x.Time.Replace(":",""))).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                            else
                            {
                                result = res.OrderByDescending(x => x.ID).Skip(((int)tempData.page - 1) * (int)tempData.per_page).Take(Convert.ToInt32(tempData.per_page)).ToList();
                            }
                        }
                        TableSearchRespose temp = new TableSearchRespose
                        {
                            total = total,
                            per_page = tempData.per_page,
                            current_page = tempData.page,
                            last_page = last_page,
                            next_page_url = tempData.page < last_page ? string.Format("{0}?page={1}", BaseURL(), tempData.page + 1) : null,
                            prev_page_url = tempData.page > 1 ? string.Format("{0}?page={1}", BaseURL(), tempData.page - 1) : null,
                            from = tempData.page >= 1 ? ((tempData.per_page * (tempData.page - 1)) + 1) : null,
                            to = tempData.page >= 1 ? ((tempData.page - 1) * tempData.per_page) + result.Count : null,
                            data = result
                        };
                        return Json(temp);
                    }
                    else
                    {
                        return Json(null);
                    }
                }
                catch (Exception ex)
                {
                    return Json(null);
                }
            }
        }

        public void ReportPatientDataEXCEL(string tempData)
        {
            using (var context = new OPD_SystemEntities())
            {
                try
                {
                    if (tempData != null)
                    {
                        dynamic jsData = JsonConvert.DeserializeObject(tempData);
                        int? tmpCustomerID = Convert.ToInt32(jsData.tmpCustomerID);
                        DateTime ConToDate = Convert.ToDateTime(jsData.ToDateSearch);
                        DateTime ConEndDate = Convert.ToDateTime(jsData.EndDateSearch);
                        string search = jsData.Search;
                        string PatientName = jsData.PatientName;
                        string PatientRoom = jsData.PatientRoom;
                        var res = new List<PatientData>();
                        if (!String.IsNullOrEmpty(search))
                        {
                            res = (from a in context.PatientDatas
                                   where ((a.Time ?? "").Contains(search) || (a.BP ?? "").Contains(search) || (a.In_Oral ?? "").Contains(search) || (a.In_Parenteral ?? "").Contains(search) || (a.O2 ?? "").Contains(search) || (a.Out_Stools ?? "").Contains(search) || (a.Out_Urine ?? "").Contains(search) || (a.PulseDBP ?? "").Contains(search) || (a.PulseSBP ?? "").Contains(search) || (a.R ?? "").Contains(search) || (a.T ?? "").Contains(search))
                                   select a
                                       ).Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true && (x.Date >= ConToDate.Date && x.Date <= ConEndDate.Date)).ToList();
                        }
                        else
                        {
                            res = context.PatientDatas.Where(x => x.FK_Customer_ID == tmpCustomerID && x.Is_Active == true && (x.Date >= ConToDate.Date && x.Date <= ConEndDate.Date)).ToList();
                        }


                        ExcelPackage pck = new ExcelPackage();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

                        ws.Cells["A1"].Value = "ผลการตรวจวัดข้อมูล" + PatientName + " ห้องเลขที่: " + PatientRoom + " ตั้งแต่วันที่ " + ConToDate.ToString("dd/MM/yyyy") + " ถึง " + ConEndDate.ToString("dd/MM/yyyy");
                        ws.Cells["A1:K1"].Merge = true;
                        ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells["A1"].Style.Font.Size = 14;

                        ws.Cells["A3"].Value = "Date";
                        ws.Cells["B3"].Value = "Time";
                        ws.Cells["C3"].Value = "T";
                        ws.Cells["D3"].Value = "BP";
                        ws.Cells["E3"].Value = "R";
                        ws.Cells["F3"].Value = "P";
                        ws.Cells["G3"].Value = "O2";
                        ws.Cells["H3"].Value = "IN Oral";
                        ws.Cells["I3"].Value = "IN Parenteral";
                        ws.Cells["J3"].Value = "OUT Stools";
                        ws.Cells["K3"].Value = "OUT Urine";

                        ws.Cells["A1:K3"].Style.Font.Bold = true;

                        if (res != null)
                        {
                            var index = 4;
                            foreach (var item in res)
                            {
                                ws.Cells[string.Format("A{0}", index)].Value = Convert.ToDateTime(item.Date).ToString("MMM dd, yyyy");
                                ws.Cells[string.Format("B{0}", index)].Value = item.Time;
                                ws.Cells[string.Format("C{0}", index)].Value = item.T;
                                ws.Cells[string.Format("D{0}", index)].Value = String.IsNullOrEmpty(item.PulseSBP) ? null : item.PulseSBP + "/" + item.PulseDBP;
                                ws.Cells[string.Format("E{0}", index)].Value = item.R;
                                ws.Cells[string.Format("F{0}", index)].Value = item.BP;
                                ws.Cells[string.Format("G{0}", index)].Value = item.O2;
                                ws.Cells[string.Format("H{0}", index)].Value = item.In_Oral;
                                ws.Cells[string.Format("I{0}", index)].Value = item.In_Parenteral;
                                ws.Cells[string.Format("J{0}", index)].Value = item.Out_Stools;
                                ws.Cells[string.Format("K{0}", index)].Value = item.Out_Urine;
                                index++;
                            }
                            ws.Cells[string.Format("A3:k{0}", index - 1)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            ws.Cells[string.Format("A3:k{0}", index - 1)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            ws.Cells[string.Format("A3:k{0}", index - 1)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            ws.Cells[string.Format("A3:k{0}", index - 1)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        }

                        ws.Cells["A:AZ"].AutoFitColumns();
                        ws.PrinterSettings.PaperSize = ePaperSize.A4;
                        ws.PrinterSettings.FitToPage = true;
                        ws.PrinterSettings.Orientation = eOrientation.Landscape;
                        ws.PrinterSettings.FitToHeight = 0;
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment; filename= " + "PatientDataReport" + ".xlsx");
                        Response.BinaryWrite(pck.GetAsByteArray());
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

    }
}