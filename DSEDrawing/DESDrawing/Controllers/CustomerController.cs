using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DESDrawing.Models;
using DESDrawing.Models.Manager;
using DESDrawing.Models.DBRepository;

namespace DESDrawing.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerDB CDB = new CustomerDB();
        public ActionResult Index()
        {
            return View();
        }
        #region Customer Login (Shalini)
        //[Route("Login")]
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer obj)
        {
            if (ModelState.IsValid)
            {
                Customer model = new Customer();
                model = CDB.CheckCustomerLogin(obj);
                if (model.flag != 0)
                {
                    SessionManager.CustomerID = model.CustomerID;
                    SessionManager.UserId = model.CustomerID;       
                    SessionManager.Name = model.Customer_Name;
                    SessionManager.Email = model.Email;
                    SessionManager.Mobile = model.Phone_Number;
                    SessionManager.FK_District_id = model.FK_District_id;
                    return RedirectToAction("Dashboard", "Applicant");
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

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(AccountModel model)
        {
            AccountModel changePassword = new AccountModel();
            changePassword = AccountDB.CustomerChangePassword(model);
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


        #region Customer Register (Shalini)
        [Route("Registration")]
        [HttpGet]
        public ActionResult CustomerRegister()
        {
            Customer model = new Customer();
            ViewBag.City = CDB.BindDistrictDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult CustomerRegister(Customer model)
        {
            Customer objresponse = new Customer();
            ViewBag.City = CDB.BindDistrictDropdown();
            objresponse = CDB.CustomerReg(model);
            if (objresponse.flag == 1)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresponse.message;
                return RedirectToAction("Customerlogin", "Customer");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresponse.message;
                return View(model);
            }
        }
        #endregion

        #region Customer Logout
        [Route("Logout")]
        public ActionResult CustomerLogout()
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Customerlogin", "Customer");
        }
        #endregion
    }
}