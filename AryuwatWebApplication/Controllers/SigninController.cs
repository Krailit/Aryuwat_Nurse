using AryuwatWebApplication.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AryuwatWebApplication.Controllers
{
    public class SigninController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        [HttpPost]
        public ActionResult Login(string tempdata)
        {
            using (var context = new OPD_SystemEntities())
            {
                try
                {
                    var JsData = JObject.Parse(tempdata);
                    string txtUser = JsData["user"].ToString(), txtPass = JsData["pass"].ToString();
                    var chkLogin = context.Personnels.Where(x => x.Username == txtUser && x.Passwords == txtPass && x.Active == "Y").FirstOrDefault();
                    if(chkLogin != null)
                    {
                        Response.Cookies["OPD"]["ID"] = chkLogin.ID.ToString();
                        Response.Cookies["OPD"]["TName"] = chkLogin.TName == null ? null : Base64Encode(chkLogin.TName.ToString());
                        Response.Cookies["OPD"]["Username"] = chkLogin.Username == null ? null : Base64Encode(chkLogin.Username.ToString());
                        Response.Cookies["OPD"]["IdCard"] = chkLogin.IdCard == null ? null : chkLogin.IdCard.ToString();
                        Response.Cookies["OPD"]["PersonnelType"] = chkLogin.PersonnelType == null ? null : Base64Encode(chkLogin.PersonnelType.ToString());
                        Response.Cookies["OPD"]["UserGroup"] = chkLogin.UserGroup == null ? null : Base64Encode(chkLogin.UserGroup.ToString());
                        Response.Cookies["OPD"]["ImageFilename"] = chkLogin.ImageFilename == null ? null : Base64Encode(chkLogin.ImageFilename.ToString());
                        Response.Cookies["OPD"].Expires = DateTime.Now.AddMinutes(180);
                        return Json(new { status = 200, data = Response.Cookies["OPD"] });
                    }
                    return Json(new { status = 400 });
                }
                catch (Exception ex)
                {
                    return Json(new { status = 400 });
                }
            }
        }
    }
}