using HRPayroll.Filters;
using HRPayroll.Models;
using HRPayroll.Models.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


namespace HRPayroll.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        AdminDB ADB = new AdminDB();
        MasterDB objDB = new MasterDB();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        #region
        [HttpGet]
        public ActionResult ApproveOrDeclineLeave()
        {
            EmpLeaveRequest model = new EmpLeaveRequest();
            model.EmployeeListForLeave = ADB.EmployeeLeavelist();
            return View(model);
        }
        [HttpPost]
        public ActionResult ApproveOrDeclineLeaveByAdmin(EmpLeaveRequest model)
        {
            EmpLeaveRequest obj = new EmpLeaveRequest();
            obj = ADB.Approve_Decline_Leave(model);
            TempData["code"] = "1";
            TempData["Msg"] = obj.msg;
            return View(obj);
        }
        public ActionResult Attendance(Attendances model)
        {
            model = AdminDB.AttendanceList(model);
            return View(model);
        }

        public ActionResult MonthlyAttendance(string month, string year)
        {
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            // List<SelectListItem> attelist = ADB.MonthlyAttendance(month, year);
            return View();
        }
        [HttpPost]
        public JsonResult MonthlyAttendance1(string month, string year)
        {
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            var attelist = ADB.MonthlyAttendance(month, year);
            return Json(attelist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateAttendance(Attendances model)
        {
            if (model.EmpList != null || model.EmpList.Count() > 0)
            {
                var EmpData = "<EmpList>";
                foreach (var item in model.EmpList)
                {
                    EmpData += "<EmpData><EmpId>" + item.EmpId + "</EmpId>";
                    EmpData += "<InTime>" + item.InTime + "</InTime>";
                    EmpData += "<OutTime>" + item.OutTime + "</OutTime>";
                    EmpData += "<Date>" + item.AttendanceDate + "</Date>";
                    EmpData += "</EmpData>";
                }
                EmpData += "</EmpList>";
                model.XmlData = EmpData;
                var res = AdminDB.UpdateAttendanceDetail(model);
                if (res != null)
                {
                    if (res.flag > 0)
                    {
                        TempData["code"] = "1";
                        TempData["Msg"] = res.message;
                        return RedirectToAction("Attendance", "Admin");
                    }
                    else
                    {
                        TempData["code"] = "0";
                        TempData["Msg"] = res.message;
                    }
                }
            }
            return View(model);
        }
        #endregion

       

        #region DAArrear
        [HttpGet]
        public ActionResult DAArrear()
        {
            MasterDB objDB = new MasterDB();
            ViewBag.Type = MasterDB.Dropdown(3, 0).Take(3);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            var obj = objDB.GetDataForDAArrear();
            return View(obj);
        }
        [HttpPost]
        public ActionResult DAArrear(DAArrear model)
        {
            DAArrear obj = new DAArrear();
            MasterDB objDB = new MasterDB();
            ViewBag.Type = MasterDB.Dropdown(3, 0).Take(3);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model.FRYear = model.FromYear + "-" + model.FromMonth.ToString("00") + "-01";
            model.TYear = model.ToYear + "-" + model.ToMonth.ToString("00") + "-01";
            obj.List = objDB.GetDAArrearList(model);
            return View(obj);
        }
        public ActionResult GenerateDA(DAArrear model)
        {
            DAArrear obj = new DAArrear();
            MasterDB objDB = new MasterDB();
            if (model.EmpIDList != null)
            {
                foreach (var i in model.EmpIDList)
                {
                    model.EMPid = i.EMPid;
                    model.Month = i.Month;
                    model.Year = i.Year;
                    model.BasicSal = i.BasicSal;
                    model.DueDA = i.DueDA;
                    model.DrawDA = i.DrawDA;
                    model.WorkDays = i.WorkDays;
                    obj = objDB.GenerateDAArrear(model);
                }
            }
            if (obj.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = "Added Successfully!";
                return RedirectToAction("DAArrear", "Admin", obj);
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = "Something Went Wrong !";
            }
            return RedirectToAction("DAArrear", "Admin", obj);
        }
        [HttpGet]
        public ActionResult ManageDAArrear()
        {
            DAArrear model = new DAArrear();
            MasterDB objDB = new MasterDB();
            ViewBag.Type = MasterDB.Dropdown(3, 0).Take(3);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.ddlMonth = MasterDB.Dropdown(15, 0);
            var obj = objDB.GetDataForDAArrear();
            return View(obj);
        }
        [HttpPost]
        public ActionResult ManageDAArrear(DAArrear model)
        {
            DAArrear obj = new DAArrear();
            MasterDB objDB = new MasterDB();
            ViewBag.Type = MasterDB.Dropdown(3, 0).Take(3);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.ddlMonth = MasterDB.Dropdown(15, 0);
            if (model.BasicSal == 0)
            {
                obj = objDB.GetDataForManageDAArrear(model);
            }            
            if (obj != null)
            {
                model.BasicSal = obj.BasicSal;
                model.WorkDays = obj.WorkDays;
                model.DrawDA = obj.DrawDA;
                model.DueDA = obj.DueDA;
                obj = objDB.ManageDAArrear(model);
                if (obj.flag > 0)
                {
                    TempData["code"] = "1";
                    TempData["Msg"] = "Updated Successfully!";
                    return RedirectToAction("ManageDAArrear", "Admin");
                }
                else
                {
                    TempData["code"] = "0";
                    TempData["Msg"] = "Something Went wrong!";

                }
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = "No Data Found!";
                return View(model);

            }
            return View(obj);
        }
        #endregion
        #region
        public ActionResult SaveOfficePayment(OfficePayment model)
        {
            OfficePayment obj = new OfficePayment();
            obj = AdminDB.SaveOfficePaymentDetails(model);
            if (obj.Flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = obj.message;
                return RedirectToAction("OfficePayment", "Admin");

            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = obj.message;
                return RedirectToAction("OfficePayment", "Admin");
            }

        }

        #endregion

     

        #region  Leave Insert
        public ActionResult LeaveInsert()
        {
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View();
        }

        public JsonResult GetEmployeeByCategory(string WorkingType)
        {
            var res = AdminDB.BindEmployeeByWtfId(Convert.ToInt32(WorkingType));
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmpLeaveDetails(Leave model)
        {
            var res = AdminDB.GetEmpLeaveDetails(model);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEmpLeaveRecord(Leave model)
        {
            var res = AdminDB.SavfeEmpLeaveRecord(model);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region User Registration
        [HttpGet]
        public ActionResult UserRegistration()
        {
            User model = new User();
            ViewBag.UserType = MasterDB.Dropdown(34, 0);
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Circle = MasterDB.Dropdown(8, 0);
            ViewBag.DistrictList = objDB.GetDistricts(0);
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            ViewBag.SubDept = objDB.GetSubDepartment(0);
            ViewBag.Emptype = MasterDB.Dropdown(30, 0);
            ViewBag.DesignationOfficer = AdminDB.BindDesignationOfficer();
            ViewBag.DesignationStaff = AdminDB.BindDesignationStaff();
            // model.mapdept = AdminDB.GetDepartmentforcheckbox();
            return View(model);
        } 
        [HttpPost]
        public ActionResult UserRegistration(User model)
        {
            User result = new User();
            if (model.DepartmentsLst != null)
            {
                model.Departments = string.Join(",", model.DepartmentsLst);
            }
            result = ADB.SaveUser(model);
            if (result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = "User Save Successfully!";
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = "Something Went wrong!";

            }
            return RedirectToAction("UserRegistration", "Admin");
        }

        public JsonResult GetDepartmentforcheckbox(string OfficeId)
        {
           var res= AdminDB.GetDepartmentforcheckbox(Convert.ToInt32(OfficeId));

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UserRegList(User model)
        {
            ViewBag.UserType = MasterDB.Dropdown(34, 0);
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Circle = MasterDB.Dropdown(8, 0);
            ViewBag.DistrictList = objDB.GetDistricts(0);
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            ViewBag.SubDept = objDB.GetSubDepartment(0);
            ViewBag.Emptype = MasterDB.Dropdown(30, 0);
            ViewBag.DesignationOfficer = AdminDB.BindDesignationOfficer();
            ViewBag.DesignationStaff = AdminDB.BindDesignationStaff();
            User obj = new User();
            obj.UList = AdminDB.UserList(model);


            return View(obj);
        }
        #endregion
    }
}