using HRPayroll.Filters;
using HRPayroll.Models;
using HRPayroll.Models.DBRepository;
using HRPayroll.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using static HRPayroll.Models.Common;

namespace HRPayroll.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        AccountMasterDb acDb = new AccountMasterDb();

        #region CreateResponse
        /// <summary>
        /// Creates a successfull response with redirection and default MessageStream -> MessageStream.RecordUpdatedSuccessfully .
        /// </summary>
        /// <param name="Action"></param>
        /// <param name="Controller"></param>
        //private void CreateResponse(string Action, string Controller)
        //{
        //    ViewBag.ResponseURL = Url.Action(Action, Controller);
        //    ViewBag.ResponseMessage = MessageStream.RecordUpdatedSuccessfully;
        //    ViewBag.ResponseType = ResponseType.Success;
        //}

        /// <summary>
        /// Creates a successfull response with redirection and message.
        /// </summary>
        /// <param name="Action"></param>
        /// <param name="Controller"></param>
        /// <param name="Message"></param>
        private void CreateResponse(string Action, string Controller, string Message)
        {
            ViewBag.ResponseURL = Url.Action(Action, Controller);
            ViewBag.ResponseMessage = Message;
            ViewBag.ResponseType = ResponseType.Success;
        }

        /// <summary>
        /// Creates a response with customized parameters. Keep action and controller empty / blank if redirection is not required.
        /// </summary>
        /// <param name="Action"></param>
        /// <param name="Controller"></param>
        /// <param name="Message"></param>
        /// <param name="ResponseType_success_warning_error_OR_info"></param>
        private void CreateResponse(string Action, string Controller, string Message, string ResponseType_success_warning_error_OR_info, bool UseTempData = false, string ResponseTitle = "")
        {
            if (!string.IsNullOrEmpty(Action))
            {
                ViewBag.ResponseURL = Url.Action(Action, Controller);
                if (UseTempData)
                    TempData["ResponseURL"] = Url.Action(Action, Controller);
            }

            ViewBag.ResponseMessage = Message;
            ViewBag.ResponseType = ResponseType_success_warning_error_OR_info;
            if (!string.IsNullOrEmpty(ResponseTitle)) ViewBag.ResponseTitle = ResponseTitle;

            if (UseTempData)
            {
                TempData["ResponseMessage"] = Message;
                TempData["ResponseType"] = ResponseType_success_warning_error_OR_info;
            }
        }

        private void FlushCreateResponse()
        {
            TempData.Remove("ResponseURL");
            TempData.Remove("ResponseMessage");
            TempData.Remove("ResponseType");
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(EmpLogin obj)
        {
                EmpLogin model = new EmpLogin();
                model = acDb.UserLogin(obj);

                if (model.flag > 0)
                {
                    SessionManager.UserId = model.UserId;
                    SessionManager.Name = model.EOName;
                    SessionManager.AgencyTypeId = model.FK_AgencyTypeId;
                    SessionManager.UTypeId = model.UTypeId;
                    SessionManager.WTypeId = model.WTypeId;
                    SessionManager.CircleId = model.CircleId;
                    SessionManager.OfficeID = model.Officeid;
                    SessionManager.DepId = model.DepId;
                    SessionManager.OfficeName = model.OfficeName;
                    SessionManager.WorkingType = model.WorkingType;
                    SessionManager.PayclerkName = model.PayclerkName;
                    SessionManager.PayclerkMobileNo = model.PayclerkMobileNo;
                    SessionManager.Mobile = model.EOMobileNo;
                    SessionManager.EOName = model.EOName;
                    SessionManager.OptName = model.OptName;
                    SessionManager.OptNo = model.OptNo;

                    return RedirectToAction("Dashboard", "Employee");
                }
                else
                {
                    TempData["code"] = "0";
                    TempData["Msg"] = model.message;
                    return View(obj);
                }
           
           // return View();
        }

        [AuthorizeAdmin]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [AuthorizeAdmin]
        [HttpPost]
        public ActionResult ChangePassword(EmpLogin model)
        {
            EmpLogin changePassword = new EmpLogin();
            changePassword = AccountMasterDb.ChangePassword(model);
            if (changePassword.flag>0)
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

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(EmpLogin model)
        {
            EmpLogin forgotPwd = new EmpLogin();
            forgotPwd = AccountMasterDb.ForgotPassword(model);
            
                if (forgotPwd.flag>0)
                {
                MailMessage mail = new MailMessage();
                mail.To.Add(model.EmailId);
                mail.From = new MailAddress("", "HRPay Roll");
                mail.Subject = "Forgot Password";
                string Body = "Hi,<br/>&nbsp;&nbsp; Greetings From HRPay Roll,Directorate of Employee Local Bodies, Uttar Pradesh.Your Password is : "+ forgotPwd.Password+ " .This is System Generated E-Mail.Do Not Reply";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("", "");
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {

                }
                TempData["Msg"] = forgotPwd.message;
                    TempData["code"] = "1";
                }
                else
                {
                    TempData["Msg"] = forgotPwd.message;
                    TempData["code"] = "0";
                }

               return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index", "Home");
        }
        #region Employeelogin 
        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult EmployeeLogin(EmpLogin obj)
        {
            EmpLogin model = new EmpLogin();
            model = acDb.EmployeeLogin(obj);
            if (model.flag > 0)
            {
                SessionManager.UserId = model.UserId;
                SessionManager.EmpId = model.EmpId;
                SessionManager.Name = model.UserName;
                SessionManager.EmpCode = model.EmpCode;
                SessionManager.AgencyTypeId = model.FK_AgencyTypeId;
                SessionManager.UTypeId = model.UTypeId;
                SessionManager.WTypeId = model.WTypeId;
                SessionManager.CircleId = model.CircleId;
                SessionManager.OfficeID = model.Officeid;
                SessionManager.DepId = model.DepId;            
                SessionManager.WorkingType = model.WorkingType;
                SessionManager.PayclerkMobileNo = model.PayclerkMobileNo;
                SessionManager.Mobile = model.EOMobileNo;
                SessionManager.CompanyId = model.CompanyId;
                return RedirectToAction("EmployeeDashboard", "Employee");

            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.message;
                return View(obj);
            }
                    
           
        }
        public ActionResult EmpLogout()
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EmpForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmpForgotPassword(EmpLogin model)
        {
            EmpLogin forgotPwd = new EmpLogin();
            forgotPwd = AccountMasterDb.EmpForgotPassword(model);

            if (forgotPwd.flag > 0)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(model.EmailId);
                mail.From = new MailAddress("", "HRPay Roll");
                mail.Subject = "Forgot Password";
                string Body = "Hi,<br/>&nbsp;&nbsp; Greetings From HRPay Roll,Directorate of Employee Local Bodies, Uttar Pradesh.Your Password is : " + forgotPwd.Password + " .This is System Generated E-Mail.Do Not Reply";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("", "");
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {

                }
                TempData["Msg"] = forgotPwd.message;
                TempData["code"] = "1";
            }
            else
            {
                TempData["Msg"] = forgotPwd.message;
                TempData["code"] = "0";
            }

            return View();
        }
        //[HttpGet]
        //public ActionResult EmpChangePassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult EmpChangePassword(EmpLogin model)
        //{
        //    EmpLogin changePassword = new EmpLogin();
        //    changePassword = AccountMasterDb.User_ChangePassword(model);
        //    if (changePassword.flag > 0)
        //    {
        //        var newpassword = model.NewPassword;
        //        var confirmpassword = model.ConfirmPassword;
        //        if (newpassword == confirmpassword)
        //        {
        //            TempData["Msg"] = changePassword.message;
        //            TempData["code"] = "1";
        //        }
        //        else
        //        {
        //            TempData["Msg"] = changePassword.message;
        //            TempData["code"] = "0";
        //        }
        //    }
        //    else
        //    {
        //        TempData["Msg"] = changePassword.message;
        //        TempData["code"] = "0";
        //    }
        //    return View();
        //}
        #endregion

        #region Adminlogin 
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(EmpLogin obj)
        {
            EmpLogin model = new EmpLogin();
            model = acDb.AdminLogin(obj);
            if (model.flag > 0)
            {
                SessionManager.UserId = model.UserId;
                SessionManager.Name = model.UserName;
                SessionManager.EmpCode = model.EmpCode;
                SessionManager.UTypeId = model.UTypeId;
                SessionManager.OfficeID = model.Officeid;
                SessionManager.DepId = model.DepId;
                SessionManager.Mobile = model.EOMobileNo;
                return RedirectToAction("Dashboard", "Admin");

            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.message;
                return View(obj);
            }


        }
        public ActionResult AdminLogout()
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region AccountMaster

        [HttpGet]
        public ActionResult AccountTypeList(int? Page)
        {
            AccountType model = new AccountType();
            if (Page == null || Page == 0)
            {
                Page = 1;
            }
            model.Page = Page;
            model.Size = 10;
            int totalRecords = 0;
            model.list = acDb.GetAllAccountType<AccountTypeList>(model);
            if (model.list.Count() > 0)
            {
                totalRecords = Convert.ToInt32(model.list[0].TotalRecord);
                var pager = new Pager(totalRecords, model.Page, 10);
                model.Pager = pager;
                return View(model);
            }
            else
            {
                model.list = new List<AccountTypeList>();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult AccountType(int? Id)
        {
            AccountType model = new AccountType();
            if (Convert.ToInt32(Id) > 0)
            {
                model.AC_Type_Id = Convert.ToInt32(Id);
                model = acDb.GetAccountTypeById<AccountType>(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AccountType(AccountType model)
        {
            if (ModelState.IsValid)
            {
                model = acDb.InsertUpdateAccountType<AccountType>(model);
                if (model.flag == 1)
                {
                    CreateResponse("AccountTypeList", "Account", model.msg, ResponseType.Success);
                }
                else
                {
                    CreateResponse("", "", model.msg, ResponseType.Error);
                }
            }
            else
            {
                CreateResponse("", "", "Error occured while submitting your request !", ResponseType.Error);
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteAccountType(string id)
        {
            AccountType model = new AccountType();
            if (Convert.ToInt32(id) > 0)
            {
                model.AC_Type_Id = Convert.ToInt32(id);
                model = acDb.DeleteAccountTypeById<AccountType>(model);
            }
            else
            {
                model.flag = 2;
                model.msg = "Error occurred while processing your request !";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult FinancialYearList(int? Page)
        {
            FinancialYear model = new FinancialYear();
            if (Page == null || Page == 0)
            {
                Page = 1;
            }
            model.Page = Page;
            model.Size = 10;
            int totalRecords = 0;
            model.list = acDb.GetAllFinancialYear<FinancialYearList>(model);
            if (model.list.Count() > 0)
            {
                totalRecords = Convert.ToInt32(model.list[0].TotalRecord);
                var pager = new Pager(totalRecords, model.Page, 10);
                model.Pager = pager;
                return View(model);
            }
            else
            {
                model.list = new List<FinancialYearList>();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult FinancialYear(int? Id)
        {
            FinancialYear model = new FinancialYear();
            if (Convert.ToInt32(Id) > 0)
            {
                model.Id = Convert.ToInt32(Id);
                model = acDb.GetFinancialYearById<FinancialYear>(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult FinancialYear(FinancialYear model)
        {
            if (ModelState.IsValid)
            {
                model = acDb.InsertUpdateFinancialYear<FinancialYear>(model);
                if (model.flag == 1)
                {
                    CreateResponse("FinancialYearList", "Account", model.msg, ResponseType.Success);
                }
                else
                {
                    CreateResponse("", "", model.msg, ResponseType.Error);
                }
            }
            else
            {
                CreateResponse("", "", "Error occured while submitting your request !", ResponseType.Error);
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteFinancialYear(string id)
        {
            FinancialYear model = new FinancialYear();
            if (Convert.ToInt32(id) > 0)
            {
                model.Id = Convert.ToInt32(id);
                model = acDb.DeleteFinancialYearById<FinancialYear>(model);
            }
            else
            {
                model.flag = 2;
                model.msg = "Error occurred while processing your request !";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult VoucherTypesList(int? Page)
        {
            VoucherTypes model = new VoucherTypes();
            if (Page == null || Page == 0)
            {
                Page = 1;
            }
            model.Page = Page;
            model.Size = 10;
            int totalRecords = 0;
            model.list = acDb.GetAllVoucherTypes<VoucherTypesList>(model);
            if (model.list.Count() > 0)
            {
                totalRecords = Convert.ToInt32(model.list[0].TotalRecord);
                var pager = new Pager(totalRecords, model.Page, 10);
                model.Pager = pager;
                return View(model);
            }
            else
            {
                model.list = new List<VoucherTypesList>();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult VoucherTypes(int? Id)
        {
            VoucherTypes model = new VoucherTypes();
            ViewBag.FnYear = acDb.GetAllFinancialYear();
            if (Convert.ToInt32(Id) > 0)
            {
                model.Voucher_Type_Id = Convert.ToInt32(Id);
                model = acDb.GetVoucherTypesById<VoucherTypes>(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult VoucherTypes(VoucherTypes model)
        {
            ViewBag.FnYear = acDb.GetAllFinancialYear();
            if (ModelState.IsValid)
            {
                model = acDb.InsertUpdateVoucherTypes<VoucherTypes>(model);
                if (model.flag == 1)
                {
                    CreateResponse("VoucherTypesList", "Account", model.msg, ResponseType.Success);
                }
                else
                {
                    CreateResponse("", "", model.msg, ResponseType.Error);
                }
            }
            else
            {
                CreateResponse("", "", "Error occured while submitting your request !", ResponseType.Error);
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteVoucherTypes(string id)
        {
            VoucherTypes model = new VoucherTypes();
            if (Convert.ToInt32(id) > 0)
            {
                model.Voucher_Type_Id = Convert.ToInt32(id);
                model = acDb.DeleteVoucherTypesById<VoucherTypes>(model);
            }
            else
            {
                model.flag = 2;
                model.msg = "Error occurred while processing your request !";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AccountGroupList(int? Page)
        {
            AccountGroup model = new AccountGroup();
            if (Page == null || Page == 0)
            {
                Page = 1;
            }
            model.Page = Page;
            model.Size = 10;
            int totalRecords = 0;
            model.list = acDb.GetAllAccountGroup<AccountGroupList>(model);
            if (model.list.Count() > 0)
            {
                totalRecords = Convert.ToInt32(model.list[0].TotalRecord);
                var pager = new Pager(totalRecords, model.Page, 10);
                model.Pager = pager;
                return View(model);
            }
            else
            {
                model.list = new List<AccountGroupList>();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult AccountGroup(int? Id)
        {
            AccountGroup model = new AccountGroup();
            ViewBag.AccountType = acDb.GetAllAccountType();
            ViewBag.AccountGroups = acDb.GetAccountGroups();
            if (Convert.ToInt32(Id) > 0)
            {
                model.Group_Id = Convert.ToInt32(Id);
                model = acDb.GetAccountGroupById<AccountGroup>(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AccountGroup(AccountGroup model)
        {
            ViewBag.AccountType = acDb.GetAllAccountType();
            ViewBag.AccountGroups = acDb.GetAccountGroups();
            ModelState["Account_Perent_Group_Id"].Errors.Clear();
            if (ModelState.IsValid)
            {
                model = acDb.InsertUpdateAccountGroup<AccountGroup>(model);
                if (model.flag == 1)
                {
                    CreateResponse("AccountGroupList", "Account", model.msg, ResponseType.Success);
                }
                else
                {
                    CreateResponse("", "", model.msg, ResponseType.Error);
                }
            }
            else
            {
                CreateResponse("", "", "Error occured while submitting your request !", ResponseType.Error);
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteAccountGroup(string id)
        {
            AccountGroup model = new AccountGroup();
            if (Convert.ToInt32(id) > 0)
            {
                model.Group_Id = Convert.ToInt32(id);
                model = acDb.DeleteAccountGroupById<AccountGroup>(model);
            }
            else
            {
                model.flag = 2;
                model.msg = "Error occurred while processing your request !";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AccountLedgerList(int? Page)
        {
            AccountLedger model = new AccountLedger();
            if (Page == null || Page == 0)
            {
                Page = 1;
            }
            model.Page = Page;
            model.Size = 10;
            int totalRecords = 0;
            model.list = acDb.GetAllAccountLedger<AccountLedgerList>(model);
            if (model.list.Count() > 0)
            {
                totalRecords = Convert.ToInt32(model.list[0].TotalRecord);
                var pager = new Pager(totalRecords, model.Page, 10);
                model.Pager = pager;
                return View(model);
            }
            else
            {
                model.list = new List<AccountLedgerList>();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult AccountLedger(int? Id)
        {
            AccountLedger model = new AccountLedger();
            ViewBag.AccountType = acDb.GetAllAccountType();
            ViewBag.AccountGroups = acDb.GetAccountGroups();
            ViewBag.FnYear = acDb.GetAllFinancialYear();
            if (Convert.ToInt32(Id) > 0)
            {
                model.Ledger_Id = Convert.ToInt32(Id);
                model = acDb.GetAccountLedgerById<AccountLedger>(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AccountLedger(AccountLedger model)
        {
            ViewBag.AccountType = acDb.GetAllAccountType();
            ViewBag.AccountGroups = acDb.GetAccountGroups();
            ViewBag.FnYear = acDb.GetAllFinancialYear();
            if (ModelState.IsValid)
            {
                model = acDb.InsertUpdateAccountLedger<AccountLedger>(model);
                if (model.flag == 1)
                {
                    CreateResponse("AccountLedgerList", "Account", model.msg, ResponseType.Success);
                }
                else
                {
                    CreateResponse("", "", model.msg, ResponseType.Error);
                }
            }
            else
            {
                CreateResponse("", "", "Error occured while submitting your request !", ResponseType.Error);
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteAccountLedger(string id)
        {
            AccountLedger model = new AccountLedger();
            if (Convert.ToInt32(id) > 0)
            {
                model.Ledger_Id = Convert.ToInt32(id);
                model = acDb.DeleteAccountLedgerById<AccountLedger>(model);
            }
            else
            {
                model.flag = 2;
                model.msg = "Error occurred while processing your request !";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}