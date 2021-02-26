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
                        Response.Cookies["OPD"]["TName"] = chkLogin.TName == null ? null : chkLogin.TName.ToString();
                        Response.Cookies["OPD"]["Username"] = chkLogin.Username == null ? null : chkLogin.Username.ToString();
                        Response.Cookies["OPD"]["IdCard"] = chkLogin.IdCard == null ? null : chkLogin.IdCard.ToString();
                        Response.Cookies["OPD"]["PersonnelType"] = chkLogin.PersonnelType == null ? null : chkLogin.PersonnelType.ToString();
                        Response.Cookies["OPD"]["UserGroup"] = chkLogin.UserGroup == null ? null : chkLogin.UserGroup.ToString();
                        Response.Cookies["OPD"]["ImageFilename"] = chkLogin.ImageFilename == null ? null : chkLogin.ImageFilename.ToString();
                        Response.Cookies["OPD"].Expires = DateTime.Now.AddMinutes(180);
                        return Json(new { status = 200 });
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