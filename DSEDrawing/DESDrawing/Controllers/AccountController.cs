using DESDrawing.Models;
using DESDrawing.Models.DBRepository;
using DESDrawing.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESDrawing.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        #region Login (Vaishnavi)
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountModel obj)
        {
            if (ModelState.IsValid)
            {
                AccountModel model = new AccountModel();
                AccountDB ADB = new AccountDB();
                model = ADB.CheckUserLogin(obj);
            
                if (model.Flag != 0)
                {
                    SessionManager.UserId = model.UserID;
                    SessionManager.Name = model.FullName;
                    SessionManager.Mobile = model.Mobile;
                    SessionManager.Email = model.Email;
                    SessionManager.Role = model.Role;
                    SessionManager.RoleName = model.RoleName;
                    SessionManager.DiscomId = model.DiscomID;
                    SessionManager.DistrictId = model.DistrictID;
                    SessionManager.ZoneId = model.ZoneID;
                    SessionManager.RegionId = model.RegionID;
                    SessionManager.UserPermissionDt = ADB.GetFormPermissionDetails(Convert.ToInt32(model.UserID));
                    if (model.RoleName == "Admin ")
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Director");
                    }
                }
                else
                {
                    TempData["code"] = "0";
                    TempData["Msg"] = model.message;
                    return View(obj);
                }
            }
            return View();

        }
        #endregion

        #region
        public ActionResult UserLogout()
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Login", "Account");
        }
        #endregion

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ChangePassword(AccountModel model)
        {
            AccountModel changePassword = new AccountModel();
            changePassword = AccountDB.ChangePassword(model);
            if (changePassword.response == "success")
            {
                var newpassword = model.NewPassword;
                var confirmpassword = model.ConfirmPassword;
                if (newpassword == confirmpassword)
                {
                    TempData["Msg"] = changePassword.message;
                    TempData["code"] = "1";
                }
                else
                {
                    TempData["Msg"] = changePassword.message;
                    TempData["code"] = "0";
                }
            }
            else
            {
                TempData["Msg"] = changePassword.message;
                TempData["code"] = "0";
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}