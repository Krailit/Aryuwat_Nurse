using AryuwatWebApplication.Entity;
using AryuwatWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
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

        [AllowJsonGet]
        [HttpGet, ActionName("TableCustomer")]
        public async Task<JsonResult> TableCustomer()
        {
            try
            {
                using (var context = new OPD_SystemEntities())
                {

                    var result = context.Customers.ToList();

                    return Json(new { ContentEncoding = 200, data = result });
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

        [HttpPost, ActionName("GetPatientChange")]
        public JsonResult GetPatientChange(int? customer_id)
        {
            try
            {
                string username = HttpContext.Request.Cookies.Get("OPD")["Username"];

                using (var context = new OPD_SystemEntities())
                {
                    if (customer_id != 0)
                    {
                        var result = context.PatientChanges.Where(x => x.FK_Customer_ID == customer_id && x.Is_Active == true).ToList();
                        if (result.Count > 0)
                        {
                            var onelastchange = result.Where(x => x.Type == 1).OrderByDescending(x => x.ID).FirstOrDefault().DateChange;
                            var onenextchange = result.Where(x => x.Type == 1).OrderByDescending(x => x.ID).FirstOrDefault().NextDateChange;
                            var twolastchange = result.Where(x => x.Type == 2).OrderByDescending(x => x.ID).FirstOrDefault().DateChange;
                            var twonextchange = result.Where(x => x.Type == 2).OrderByDescending(x => x.ID).FirstOrDefault().NextDateChange;
                            return Json(new { ContentEncoding = 200, data = result, onelastchange = onelastchange, onenextchange = onenextchange, twolastchange = twolastchange, twonextchange = twonextchange });
                        }
                    }
                    return Json(new { ContentEncoding = 400 });
                }
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

        public ActionResult PatientData(string customerCN)
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
    }
}