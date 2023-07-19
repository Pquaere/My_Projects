using HRPayroll.Models;
using HRPayroll.Models.DBRepository;
using HRPayroll.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using HRPayroll.Models.Manager;
using ClosedXML.Excel;

namespace HRPayroll.Controllers
{
    [AuthorizeAdmin]

    public class EmployeeController : Controller
    {
        // GET: Employee
        MasterDB objDB = new MasterDB();
        EmployeeDB EmpDB = new EmployeeDB();
        Common com = new Common();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult EmployeeDashboard()
        {
            return View();
        }

        public ActionResult EmployeeRegistration(string EmpId, string type)
        {
            EmpReg model = new EmpReg();
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            IEnumerable<SelectListItem> EmployeeType = MasterDB.Dropdown(3, 0);
            ViewBag.EmployeeType = EmployeeType;
            IEnumerable<SelectListItem> States = objDB.BindStateDropdown();
            ViewBag.States = States;
            ViewBag.Paycommission = MasterDB.Dropdown(37, 0);
            ViewBag.GradePay = MasterDB.Dropdown(6, 0);
            ViewBag.PayScale = MasterDB.Dropdown(16, 0);
            ViewBag.Level = MasterDB.Dropdown(17, 0);
            ViewBag.Increment = new List<SelectListItem>();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.ClassCategory = MasterDB.Dropdown(10, 0);
            ViewBag.ModeOfRecruitment = MasterDB.Dropdown(23, 0);
            ViewBag.Quota = MasterDB.Dropdown(24, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            ViewBag.Relation = MasterDB.Dropdown(25, 0);
            ViewBag.PaymentHead = objDB.PaymentHeadDropdown();
            ViewBag.GpfType = MasterDB.Dropdown(26, 0);


            ViewBag.ReportingPerson = EmpDB.BindReportingPerson(SessionManager.OfficeID, Convert.ToInt32(EmpId));


            if (!string.IsNullOrEmpty(EmpId))
            {
                TempData["Type"] = type;
                model = EmpDB.EmpRegById(Convert.ToInt32(EmpId));
                if (model.EmpGender == "M")
                {
                    model.EmpGender = "1";
                }
                else if (model.EmpGender == "F")
                {
                    model.EmpGender = "2";

                }
                else { }


                type = model.EmpCategory.ToString();

            }
            else
            {
                model = new EmpReg();
                model.EmpCategory = Convert.ToInt32(type);
            }

            return View(model);
        }

        public JsonResult GetSubCategory(string DepartmentId)
        {
            var res = EmpDB.BindSubCategory(Convert.ToInt32(DepartmentId));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIncrement(string LevelId)
        {
            var res = EmpDB.BindIncrement(Convert.ToInt32(LevelId));
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrictByState(string stateId)
        {
            var res = EmpDB.BindDistrict(Convert.ToInt32(stateId));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOffice(string district)
        {
            var res = EmpDB.BindOffice(Convert.ToInt32(district));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetRportingPerson(string Office)
        //{
        //    var res = EmpDB.BindReportingPerson(Convert.ToInt32(Office));
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult SaveEmployeeRegistration(EmpReg model)
        {
            EmpReg objresult = new EmpReg();
            model.UserId = SessionManager.UserId;
            if (model.EId > 0)
            {
                objresult = EmpDB.EditEmployeeRegistration(model);
            }
            else
            {
                objresult = EmpDB.SaveEmployeeRegistration(model);
            }
            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
                return RedirectToAction("EmployeeRegistration", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
                return RedirectToAction("EmployeeRegistration", "Employee");
            }

        }

        public ActionResult RegisteredEmployee(ListEmpReg model)
        {
            ListEmpReg obj = new ListEmpReg();
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            obj.lst = EmpDB.EmpRegList(model);
            obj.EmpType = model.EmpployeType.ToString();
            obj.SubDepartment = model.SubDepartment;
            return View(obj);
        }

        #region EmpPF/GPF/NPS Detail
        [HttpGet]
        public ActionResult EmpPFGPF(int? ID)
        {
            MasterDB objDB = new MasterDB();
            EmployeePF model = new EmployeePF();
            ViewBag.Category = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            IEnumerable<SelectListItem> Bank = objDB.BindBankDropdown();
            ViewBag.Bank = Bank;
            return View(model);
        }
        [HttpPost]
        public ActionResult EmpPFGPF(EmployeePF model)
        {
            EmployeePF result = new EmployeePF();
            if (model.ID > 0)
            {
                result = EmployeeDB.UpdatePFGPFAcc(model);
            }
            else
            {
                result = EmployeeDB.AddPFGPFAcc(model);
            }
            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("EmpPFGPF", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            MasterDB objDB = new MasterDB();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            List<SelectListItem> SubDepartment = objDB.GetSubDepartment(model.Fk_DepartmentId);
            ViewBag.SubDepartment = SubDepartment;
            List<SelectListItem> Employee = MasterDB.Dropdown(5, model.Fk_SubDeptId);
            ViewBag.Employee = Employee;
            ViewBag.Category = MasterDB.Dropdown(3, 0);
            IEnumerable<SelectListItem> Bank = objDB.BindBankDropdown();
            ViewBag.Bank = Bank;

            return View(model);
        }

        public JsonResult GetSubDepartment(int DepartmentId)
        {
            MasterDB objDB = new MasterDB();
            List<SelectListItem> modelresult = objDB.GetSubDepartment(DepartmentId);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmployeeType(int empCategory)
        {
            MasterDB objDB = new MasterDB();
            List<SelectListItem> modelresult = objDB.GetEmpCategory(empCategory);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployee(int TypeId)
        {
            MasterDB objDB = new MasterDB();
            List<SelectListItem> modelresult = objDB.GetEmployee(TypeId);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInrementDetail(int LevelID)
        {
            MasterDB objDB = new MasterDB();
            List<SelectListItem> modelresult = objDB.GetInrementDetail(LevelID);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetContracturalEmp(int SubDeptId, string dept)
        {
            List<SelectListItem> modelresult1 = MasterDB.ContracturalEmployeeBind(SubDeptId, Convert.ToInt32(dept));
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmpCode(int SubDeptId,int wtypeid=1)
        {
            List<SelectListItem> modelresult1 = MasterDB.Dropdown(5, SubDeptId);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmployeeForLic(string WTypeId, string DepartmentId, string SubDeptId, string PFMSCode, string DeptEmpCode, string EmpName)
        {
            if (string.IsNullOrEmpty(WTypeId))
            {
                WTypeId = "0";
            } 
            if (string.IsNullOrEmpty(DepartmentId))
            {
                DepartmentId = "0";
            } if (string.IsNullOrEmpty(SubDeptId))
            {
                SubDeptId = "0";
            }

            List<SelectListItem> modelresult1 = MasterDB.BindDropdownForLic(Convert.ToInt32(WTypeId), Convert.ToInt32(DepartmentId), Convert.ToInt32(SubDeptId), PFMSCode, DeptEmpCode, EmpName);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetEmp(int SubDeptId, int WTypeId)
        {
            List<SelectListItem> modelresult1 = MasterDB.Dropdown1( SubDeptId, WTypeId);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmpDetails(string EmpID)
        {
            EmployeePF model = new EmployeePF();
            if (string.IsNullOrEmpty(EmpID))
            {
                model.Fk_EmpId = 0;
            }
            else
            {
                model.Fk_EmpId = Convert.ToInt32(EmpID);
            }
            model = MasterDB.GetEmpDetail(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetEmpSalDetails(string EmpID)
        {
            EmployeePF model = new EmployeePF();
            if (string.IsNullOrEmpty(EmpID))
            {
                model.Fk_EmpId = 0;
            }

            else
            {
                model.Fk_EmpId = Convert.ToInt32(EmpID);
            }
            model = MasterDB.GetEmpSalDetail(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Update_Salary

        [HttpGet]
        public ActionResult UpdateEmpSalary(int? ID)
        {
            MasterDB objDB = new MasterDB();
            EmployeePF model = new EmployeePF();
            ViewBag.Paycommission = MasterDB.Dropdown(11, 0);
            ViewBag.GradePay = MasterDB.Dropdown(6, 0);
            ViewBag.PayScale = MasterDB.Dropdown(16, 0);
            ViewBag.Level = MasterDB.Dropdown(17, 0);
            ViewBag.Increment = new List<SelectListItem>();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateEmpSalary(EmployeePF model)
        {
            EmployeePF result = new EmployeePF();
            if (model.ID > 0)
            {
                result = EmployeeDB.UpdateEmpSalary(model);
            }
            else
            {
                // result = EmployeeDB.AddPFGPFAcc(model);
            }
            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("UpdateEmpSalary", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            ViewBag.Paycommission = MasterDB.Dropdown(11, 0);
            ViewBag.GradePay = MasterDB.Dropdown(6, 0);
            ViewBag.PayScale = MasterDB.Dropdown(16, 0);
            ViewBag.Level = MasterDB.Dropdown(17, 0);
            ViewBag.Increment = new List<SelectListItem>();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            return View(model);
        }

        public JsonResult GetEmpSalDetail(int SubDeptId, string DptEpCode, string PFMSCODE, string EmpName)
        {
            List<SelectListItem> modelresult1 = objDB.GetEmpSalDetail(SubDeptId, DptEpCode, PFMSCODE, EmpName);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmpLeaveDetail(string EmpID, string DptEpCode, string PFMSCODE, string EmpName)
        {
            EmployeePF model = new EmployeePF();
            model.Fk_EmpId = Convert.ToInt32(EmpID);
            model.DptEmpCode = DptEpCode;
            model.PFMSCODE = PFMSCODE;
            model.EmpName = EmpName;
            model = MasterDB.GetEmpLeaveDetail(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region EmpLeaveInsert

        public ActionResult AddEmpLeave(int? ID)
        {
            MasterDB objDB = new MasterDB();
            EmployeePF model = new EmployeePF();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Employee = new List<SelectListItem>();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmpLeave(EmployeePF model)
        {
            EmployeePF result = new EmployeePF();
            if (model.ID > 0)
            {
                result = EmployeeDB.UpdateEmpSalary(model);
            }
            else
            {
                result = EmployeeDB.AddEmpLeave(model);
            }
            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("AddEmpLeave", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }


        #endregion





        #region Request Leave
        [HttpGet]
        public ActionResult LeaveRequest()
        {
            EmpLeaveRequest model = new EmpLeaveRequest();
            IEnumerable<SelectListItem> ddlLeaveType = MasterDB.Dropdown(13, 0);
            ViewBag.LeaveType = ddlLeaveType;
            return View(model);
        }
        [HttpPost]
        public ActionResult LeaveRequest(EmpLeaveRequest model)
        {
            EmpLeaveRequest obj = new EmpLeaveRequest();
            IEnumerable<SelectListItem> ddlLeaveType = MasterDB.Dropdown(13, 0);
            ViewBag.LeaveType = ddlLeaveType;
            obj = EmpDB.SaveEmpLeaveRequest(model);
            if (obj.flag == 1)
            {
                TempData["code"] = "1";
                TempData["Msg"] = obj.msg;
                return View();
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = obj.msg;
                return View(model);
            }
        }
        #endregion

        #region EmpEarningAndDeductionDetail
        [HttpGet]
        public ActionResult EmpEarningAndDeductionDetail(int? ID)

        {
            EmpEarningAndDeductionDetails Model = new EmpEarningAndDeductionDetails();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            ViewBag.Level = MasterDB.Dropdown(17, 0);
            ViewBag.Increment = new List<SelectListItem>();
            ViewBag.GradePay = MasterDB.Dropdown(6, 0);
            return View(Model);
        }

        [HttpPost]
        public JsonResult GetEmployeeDetail1(string EmpID)
        {
            EmpEarningAndDeductionDetails model = new EmpEarningAndDeductionDetails();

            EmployeeDB bs = new EmployeeDB();
            model.EmpId = Convert.ToInt32(EmpID);
            model = bs.BindEmployeeDetailDropdown1(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add_EmpEarningAndDeductionDetail(EmpEarningAndDeductionDetails model)
        {
            EmpEarningAndDeductionDetails objresult = new EmpEarningAndDeductionDetails();
           

            if (model.SaveUpdate == "Update")
            {
                objresult = EmpDB.UpdateEmpEarningAndDeductionDetail(model);
            }
            else
            {
                objresult = EmpDB.SaveEmpEarningAndDeductionDetail(model);
            }

            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
            }
            return RedirectToAction("EmpEarningAndDeductionDetail", "Employee");
        }
        public JsonResult GetEmpSalDetailbyPFMSCODE(string DptEpCode)
        {
            List<SelectListItem> modelresult1 = objDB.GetEmpSalDetailPFMSCode(DptEpCode);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Earning and Deduction Contractual
        public JsonResult GetEmployeeDetail2(string EmpID)
        {
            EDContractual model = new EDContractual();
            model.EmpId = Convert.ToInt32(EmpID);
            model = EmployeeDB.BindEmployeeDetailDropdown2(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EarningandDeductionContractual(int? ID)
        {
            EDContractual model = new EDContractual();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            return View(model);
        }
        [HttpPost]
        public ActionResult EarningandDeductionContractual(EDContractual model)
        {
            EDContractual result = new EDContractual();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            if (model.SaveUpdate == "Update")
            {
                result = EmpDB.UpdateEDContractual(model);
            }
            else
            {
                result = EmpDB.SaveEDContractual(model);
            }

            if (result.flag != 0 || result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
            }
            return RedirectToAction("EarningandDeductionContractual", "Employee");
        }


        #endregion

        #region AttendanceRegularization
        [HttpGet]
        public ActionResult AttendanceRegular(int? ID)
        {
            AttendanceReg model = new AttendanceReg();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                // model = EmployeeDB.GetAttenRegByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AttendanceRegular(AttendanceReg model)
        {
            AttendanceReg result = new AttendanceReg();
            if (model.ID > 0)
            {
                //result = EmployeeDB.UpdateAttenReg(model);
            }
            else
            {
                result = EmployeeDB.AttenReg(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("AttendanceRegularList", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }
        public ActionResult AttendanceRegularList()
        {
            AttendanceReg model = new AttendanceReg();
            model = EmployeeDB.ListAttenReg(model);
            return View(model);
        }

        #endregion

        #region BonusGenerate
        public ActionResult BonusReport()
        {
            ReportBonus model = new ReportBonus();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            return View(model);
        }
        [HttpPost]
        public ActionResult BonusReport(ReportBonus model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            model = EmployeeDB.BonusReport(model);
            return View(model);
        }

        public ActionResult GenerateSalaryBonus()
        {
            EmployeePF model = new EmployeePF();
            ViewBag.Category = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            return View(model);
        }

        [HttpPost]
        public ActionResult GenerateSalaryBonus(EmployeePF model)
        {
            EmployeePF result = new EmployeePF();

            result = EmployeeDB.GenerateBonus(model);

            if (result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.message;
                return RedirectToAction("GenerateSalaryBonus", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
            }
            return View(model);
        }
        #endregion

        #region LeaveEncashment

        public ActionResult EmpLeaveEncashment()
        {
            InternalTransfer model = new InternalTransfer();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.EmployeeType= new List<SelectListItem>();
            ViewBag.Encashment = MasterDB.Dropdown(28, 0);
            ViewBag.Encashment1 = MasterDB.Dropdown(29, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            ViewBag.District = objDB.BindDistrictDropdown();
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            return View(model);

        }

        [HttpPost]
        public ActionResult EmpLeaveEncashment(InternalTransfer model)
        {
            InternalTransfer result = new InternalTransfer();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.EmployeeType = new List<SelectListItem>();
            ViewBag.Encashment = MasterDB.Dropdown(28, 0);
            ViewBag.Encashment1 = MasterDB.Dropdown(29, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            ViewBag.District = objDB.BindDistrictDropdown();
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);

            result = EmployeeDB.AddEmpLeaveEncashment(model);

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("EmpLeaveEncashment", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
            }

            return View(model);

        }

        #endregion

        #region EmpGISDetail
        public ActionResult EmpGISDetail()
        {
            EmpGIS model = new EmpGIS();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.District = objDB.BindDistrictDropdown();
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            return View(model);

        }

        [HttpPost]
        public ActionResult EmpGISDetail(EmpGIS model)
        {
            EmpGIS result = new EmpGIS();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.District = objDB.BindDistrictDropdown();
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            if (model.GISId > 0)
            {
                result = EmployeeDB.UpdateEmpGIS(model);
            }
            else
            {
                result = EmployeeDB.AddEmpGIS(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("EmpGISDetail", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
            }

            return View(model);

        }

        #endregion



        public JsonResult UploadFileForRegistration(HttpPostedFileBase File)
        {
            string Dirpath = "~/Content/writereaddata/Registration/";
            string path = "";
            string filename = File.FileName;
            bool res = false;
            string msg = "";
            if (!Directory.Exists(Server.MapPath(Dirpath)))
            {
                Directory.CreateDirectory(Server.MapPath(Dirpath));
            }
            string ext = Path.GetExtension(File.FileName);
            var status = com.ValidateImagePDF_FileExtWithSize(File, 2048);
            if (status == "Valid")
            {

                filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + filename;
                string completepath = Path.Combine(Server.MapPath(Dirpath), filename);
                if (System.IO.File.Exists(completepath))
                {
                    System.IO.File.Delete(completepath);
                }

                File.SaveAs(completepath);
                path = Dirpath + filename;
                res = true;
            }
            else
            {
                msg = status;
            }
            return Json(new { result = res, fpath = path, mesg = msg });
        }
        #region Transfer Empolyee
        #region Transfer/Promotion Employee Form 
        public ActionResult InternalTransfer()
        {
            InternalTransfer model = new InternalTransfer();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            ViewBag.SubDept = objDB.GetSubDepartment(0);
            ViewBag.Emptype = MasterDB.Dropdown(30, 0);
            return View(model);
        }

        public JsonResult SearchEmpByNameorCode(InternalTransfer model)
        {
            List<InternalTransfer> modelresult1 = EmpDB.SerachEmpolyee(model);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InternalTransferSave(InternalTransfer model)
        {
            InternalTransfer modelresult = new InternalTransfer();
            if (model.EmpId > 0)
            {
                modelresult = EmpDB.SaveInternalTransfer(model);
            }

            if (modelresult.flag != 0 || modelresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = modelresult.message;
                return RedirectToAction("InternalTransfer", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = modelresult.message;
                return RedirectToAction("InternalTransfer", "Employee");
            }
        }
        #endregion
        #region  Employee Transfer Form 
        public ActionResult EmployeeTransfer()
        {
            EmployeeTransfer model = new EmployeeTransfer();
            ViewBag.DistrictList = objDB.GetDistricts(0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult EmployeeTransferSave(EmployeeTransfer model)
        {
            EmployeeTransfer modelresult = new EmployeeTransfer();
            if (model.EmpId > 0)
            {
                modelresult = EmpDB.SaveEmployeeTransfer(model);
            }

            if (modelresult.flag != 0 || modelresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = modelresult.message;
                return RedirectToAction("EmployeeTransfer", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = modelresult.message;
                return RedirectToAction("EmployeeTransfer", "Employee");
            }
        }
        #endregion
        #region Accept/Rollback Employee
        public ActionResult Accept_RollbackEmployee()
        {
            Accept_RollbackEmployee model = new Accept_RollbackEmployee();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Emp = MasterDB.Dropdown(33, SessionManager.OfficeID);
            ViewBag.Bank = objDB.BindBankDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult Accept_RollbackEmployee(Accept_RollbackEmployee model)
        {
            Accept_RollbackEmployee modelresult = new Accept_RollbackEmployee();
            if (model.EmpId > 0)
            {
                modelresult = EmpDB.Accept_RollbackEmployee(model);
            }

            if (modelresult.flag != 0 || modelresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = modelresult.message;
                return RedirectToAction("Accept_RollbackEmployee", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = modelresult.message;
                return RedirectToAction("Accept_RollbackEmployee", "Employee");
            }
        }
        #endregion
        #endregion
        #region Generate Salary (Shalini)
        public ActionResult GenerateSalary()
        {
            GenerateSalary model = new GenerateSalary();
            ViewBag.Type = MasterDB.Dropdown(3, 0).Take(3);

            ViewBag.Department = MasterDB.Dropdown(4, SessionManager.OfficeID);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View(model);
        }
        [HttpPost]
        public ActionResult GenerateSalary(GenerateSalary model)
        {
            GenerateSalary obj = new GenerateSalary();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, SessionManager.OfficeID);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            obj = EmpDB.GenerateSalary(model);

            if (obj.flag == 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = obj.message;
                return RedirectToAction("GenerateSalary", "Employee");

            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = obj.message;
                return RedirectToAction("GenerateSalary", "Employee");
            }
        }


        public JsonResult GetEmployeeDropdown(string WTypeId, string DepartmentId, string Fk_SubDeptId)
        {
            var res = EmpDB.BindEmployeeByWorkingType(Convert.ToInt32(WTypeId), Convert.ToInt32(DepartmentId), Convert.ToInt32(Fk_SubDeptId));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region EmpLoan 
        [HttpGet]
        public ActionResult EmployeeLoan(int? ID)
        {
            EmployeeLoan model = new EmployeeLoan();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.Loan = MasterDB.Dropdown(36, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveEmpLoanDetails(EmployeeLoan model)
        {
            EmployeeLoan objresult = new EmployeeLoan();
            objresult = EmpDB.SaveLoanDetail(model);
            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
            }
            return RedirectToAction("EmployeeLoan", "Employee");
        }


        public JsonResult GetEmpbyDptEpCodeAndPFMSCode(int WTypeId, string subDeptId, string EmpName, string DptEpCode, string PFMSCode)
        {
            List<SelectListItem> modelresult1 = objDB.GetEmpbyDptEpCodeAndPFMSCode(WTypeId,Convert.ToInt32(subDeptId), EmpName, DptEpCode, PFMSCode);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmpbyDptEpCode(string DptEpCode)
        {
            List<SelectListItem> modelresult1 = objDB.GetEmpbyDptEpCode(DptEpCode);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Payslip 
        [HttpGet]
        public ActionResult PaySlip(PaySlip model)
        {
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View(model);
        }

        public ActionResult RptHQEmpPaySlip(PaySlip model)
        {
            model = EmpDB.RptHQEmpPaySlip(model);
            return View(model);
        }
        public ActionResult ContPaySlip(PaySlip model)
        {
            model = EmpDB.ContPaySlip(model);
            return View(model);
        }
        public ActionResult RptDPPaySlip(PaySlip model)
        {

            model = EmpDB.RptDPPaySlip(model);
            return View(model);
        }

        [HttpGet]
        public ActionResult SalarySummary(SalarySummary model)
        {
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View(model);
        }

        public ActionResult SalarySummarySlips(SalarySummary model)
        {
            SalarySummary oj = new SalarySummary();
            oj = EmployeeDB.SummarySlips(model);
            return View(model);
        }

        #endregion

        #region Daily Wages Earnings & Deductions Master 

        public ActionResult DAilyWagesEarDed()
        {
            DAilyWagesEarDed Model = new DAilyWagesEarDed();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();

            return View(Model);
        }



        public ActionResult Add_DAilyWagesEarDed(DAilyWagesEarDed model)
        {
            DAilyWagesEarDed objresult = new DAilyWagesEarDed();

            if (model.SaveUpdate == "Update")
            {
                objresult = EmpDB.UpdateDAilyWagesEarDed(model);
            }
            else
            {
                objresult = EmpDB.SaveDAilyWagesEarDed(model);
            }

            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
            }
            return RedirectToAction("DAilyWagesEarDed", "Employee");
        }
        #endregion

        #region ClearEmpPreDataForm


        public ActionResult ClearEmpData()
        {

            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ClearData model = new ClearData();
            return View(model);
        }
        [HttpPost]
        public ActionResult ClearEmpData(ClearData model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ClearData result = new ClearData();
            if (model.Earnhead == null)
            {
                result = EmployeeDB.ClearDedData(model);
            }
            else
            {
                result = EmployeeDB.ClearEarnData(model);
            }
            result.Fk_DepartmentId = model.Fk_DepartmentId;
            result.Fk_SubDeptId = model.Fk_SubDeptId;
            result.Earnhead = model.Earnhead;
            result.Dedhead = model.Dedhead;
            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return View(result);
                // return RedirectToAction("ClearEmpData", "Employee");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
                return View(result);
            }


        }

        #endregion
        #region Employee Delete From Salary Bill 

        public ActionResult EmpSalaryDelete()
        {
            EmpLeaveDelete Model = new EmpLeaveDelete();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.WorkingType = MasterDB.Dropdown(3, 0);
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View(Model);
        }

        public ActionResult EmployeeSalaryDelete1(EmpLeaveDelete model)
        {

            model = EmployeeDB.GetEmployeeSalary(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SalaryDelete(EmpLeaveDelete model)
        {
            EmpLeaveDelete obj = new EmpLeaveDelete();
            obj = EmpDB.SalaryDelete(model);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        #region Employee Present Status (Priyanshu)

        public ActionResult EmpStatus()
        {
            EmpStatus Model = new EmpStatus();
            return View(Model);
        }

        public ActionResult GetEmpStatus(EmpStatus model)
        {
            EmpStatus obj = new EmpStatus();
            obj = EmployeeDB.GetEmpStatus(model);
            return PartialView("_EmployeeStaus", obj);
        }

        #endregion

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
                return RedirectToAction("DAArrear", "Employee", obj);
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = "Something Went Wrong !";
            }
            return RedirectToAction("DAArrear", "Employee", obj);
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
            //if (model.BasicSal == 0)
            //{
                obj = objDB.GetDataForManageDAArrear(model);
            //}
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
                    return RedirectToAction("ManageDAArrear", "Employee");
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

        #region officePayment

        public ActionResult OfficePayment()
        {
            OfficePayment obj = new OfficePayment();
            obj = AdminDB.OfficePaymentDetails();
            ViewBag.FY_Year = AdminDB.BindFinancialYear();
            return View(obj);
        }

        public ActionResult SaveOfficePayment(OfficePayment model)
        {
            OfficePayment obj = new OfficePayment();
            obj = AdminDB.SaveOfficePaymentDetails(model);
            if (obj.Flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = obj.message;
                return RedirectToAction("OfficePayment", "Employee");

            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = obj.message;
                return RedirectToAction("OfficePayment", "Employee");
            }

        }

        #endregion


        #region EmployeeLic 
        [HttpGet]
        public ActionResult EmployeeLIC()
        {
            EmployeeLIC model = new EmployeeLIC();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult EmployeeLIC(EmployeeLIC model)
        {
            EmployeeLIC result = new EmployeeLIC();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            List<SelectListItem> SubDepartment = objDB.GetSubDepartment(model.Fk_DepartmentId);
            ViewBag.SubDepartment = SubDepartment;
            List<SelectListItem> Employee = MasterDB.Dropdown(5, model.Fk_SubDeptId); ;
            ViewBag.Employee = Employee;
            ViewBag.Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Bank = objDB.BindBankDropdown();
            if (model.ID > 0)
            {
                result = EmpDB.UpdateEmpLIC(model);
            }
            else
            {
                result = EmpDB.SaveEmpLIC(model);
            }
            if (result.flag != 0 || result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
                return View(model);
            }
            return View(model);
        }
        public JsonResult GetEmployeeDetail(string EmpID)
        {
            EmployeeLIC model = new EmployeeLIC();
            model.EmpId = Convert.ToInt32(EmpID);
            model = EmployeeDB.BindEmployeeDetailDropdown(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Search Employee 
        public ActionResult SearchEmployee(EmpSearch model)
        {

            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            //ViewBag.Employee = new List<SelectListItem>();
            model.list = EmpDB.EmpList(model);
            if (model.list.Count > 0)
            {
                TempData["WTypeId"] = model.WTypeId;
                TempData["OfficeId"] = model.OfficeId;
                TempData["Agencytypeid"] = model.Agencytypeid;
                TempData["Fk_distictId"] = model.Fk_distictId;
                TempData["Fk_DepartmentId"] = model.Fk_DepartmentId;
                TempData["Fk_SubDeptId"] = model.Fk_SubDeptId;
                TempData["EmpName"] = model.EmpName;
                TempData["PFMSCode"] = model.PFMSCode;
                TempData["dptempcode"] = model.dptempcode;
                TempData["SalaryStatus"] = model.SalaryStatus;
            }
            return View(model);
        }
        public ActionResult TotalEmployeeExportExcel()
        {
            EmpSearch model = new EmpSearch();

            int WTypeId = Convert.ToInt32(TempData.Peek("WTypeId"));
            int OfficeId = Convert.ToInt32(TempData.Peek("OfficeId"));
            int Agencytypeid = Convert.ToInt32(TempData.Peek("Agencytypeid"));
            int Fk_distictId = Convert.ToInt32(TempData.Peek("Fk_distictId"));
            int Fk_DepartmentId = Convert.ToInt32(TempData.Peek("Fk_DepartmentId"));
            int Fk_SubDeptId = Convert.ToInt32(TempData.Peek("Fk_SubDeptId"));
            string EmpName = Convert.ToString(TempData.Peek("EmpName"));
            string PFMSCode = Convert.ToString(TempData.Peek("PFMSCode"));
            string dptempcode = Convert.ToString(TempData.Peek("dptempcode"));
            string SalaryStatus = Convert.ToString(TempData.Peek("SalaryStatus"));

            if (WTypeId != 0 || OfficeId != 0 || Agencytypeid != 0 || Fk_distictId != 0 || Fk_DepartmentId != 0 || Fk_SubDeptId != 0 || !String.IsNullOrEmpty(EmpName) || !String.IsNullOrEmpty(PFMSCode) || !String.IsNullOrEmpty(dptempcode) || !String.IsNullOrEmpty(SalaryStatus))
            {
                model.WTypeId = Convert.ToInt32(TempData.Peek("WTypeId"));
                model.OfficeId = Convert.ToInt32(TempData.Peek("OfficeId"));
                model.Agencytypeid = Convert.ToInt32(TempData.Peek("Agencytypeid"));
                model.Fk_distictId = Convert.ToInt32(TempData.Peek("Fk_distictId"));
                model.Fk_DepartmentId = Convert.ToInt32(TempData.Peek("Fk_DepartmentId"));
                model.Fk_SubDeptId = Convert.ToInt32(TempData.Peek("Fk_SubDeptId"));
                model.EmpName = Convert.ToString(TempData.Peek("EmpName"));
                model.PFMSCode = Convert.ToString(TempData.Peek("PFMSCode"));
                model.dptempcode = Convert.ToString(TempData.Peek("dptempcode"));
                model.SalaryStatus = Convert.ToString(TempData.Peek("SalaryStatus"));
            }

            string filename = string.Empty;
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            var result = EmpDB.EmpList(model);

            if (result != null)
            {
                if (result.Count() > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Sr.No.", typeof(string));
                    dt.Columns.Add("Office Name", typeof(string));
                    dt.Columns.Add("Employee Name", typeof(string));
                    dt.Columns.Add("Father Name", typeof(string));
                    dt.Columns.Add("Department Name", typeof(string));
                    dt.Columns.Add("Sub Department Name", typeof(string));
                    dt.Columns.Add("Department Code", typeof(string));
                    dt.Columns.Add("PFMS Code", typeof(string));
                    dt.Columns.Add("Salary Status", typeof(string));
                    dt.Columns.Add("Designation Name", typeof(string));
                    int i = 0;
                    foreach (var res in result)
                    {
                        filename = "EmpList_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
                        i++;
                        DataRow dr = dt.NewRow();
                        dr["Sr.No."] = i;
                        dr["Office Name"] = res.OfficeName;
                        dr["Employee Name"] = res.EmpName;
                        dr["Father Name"] = res.FatherName;
                        dr["Department Name"] = res.DepartmentName;
                        dr["Sub Department Name"] = res.SubDepartmentName;
                        dr["Department Code"] = res.dptempcode;
                        dr["PFMS Code"] = res.PFMSCode;
                        dr["Salary Status"] = res.SalaryStatus;
                        dr["Designation Name"] = res.DesignationName;
                        dt.Rows.Add(dr);
                    }

                    var gv = new GridView();
                    gv.DataSource = dt;
                    gv.DataBind();
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=" + filename);
                    Response.ContentType = "application/ms-excel";
                    Response.Charset = "";
                    StringWriter objStringWriter = new StringWriter();
                    string headerTable = @"<Table border=1><tr rowspan=2 align=center><td colspan=10><h3>Hr Payroll Employee List</h3></td></tr><tr align=center>   </tr> <tr rowspan=2 align=center></tr> <tr><td colspan=10 style='text-align:left;'> <b> Report As On : </b>" + DateTime.Now.ToString("dd/MM/yyyy") + "</td></tr> <tr align=right> </tr> </Table>";
                    Response.Write(headerTable);
                    HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

                    gv.RenderControl(objHtmlTextWriter);
                    Response.Output.Write(objStringWriter.ToString());
                    Response.Flush();
                    Response.End();
                    return RedirectToAction("SearchEmployee");
                }
                else
                {
                    return RedirectToAction("SearchEmployee");
                }
            }
            else
            {
                return RedirectToAction("SearchEmployee");
            }

        }

        #endregion
        #region
        public JsonResult GetEmployeeForParmanent(int SubDeptId, string DptEpCode, string PFMSCODE, string EmpName)
        {
            List<SelectListItem> modelresult1 = objDB.GetEmployeeForParmanent(SubDeptId, DptEpCode, PFMSCODE, EmpName);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmployeeForDW(int SubDeptId, string DptEpCode, string PFMSCODE, string EmpName)
        {
            List<SelectListItem> modelresult1 = objDB.GetEmployeeForDW(SubDeptId, DptEpCode, PFMSCODE, EmpName);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Finalize Data
        public ActionResult FrmFinalizeData(FrmFinalizeData model)
        {

            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model = objDB.GetFrmFinalizeData();
            return View(model);
        } 
        public ActionResult GetFinalizeData(FrmFinalizeData model)
        {

            model = EmployeeDB.GetFinalizeData(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FinalizeData(FrmFinalizeData model)
        {

            model = EmpDB.FinalizeData(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion 

        public JsonResult GetEmployeeDetailforDw(string EmpID)
        {
            DAilyWagesEarDed model = new DAilyWagesEarDed();

            EmployeeDB bs = new EmployeeDB();
            model.EmpId = Convert.ToInt32(EmpID);
            model = bs.BindEmployeeDetailDropdownDW(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        #region UnsettleData  
        public ActionResult FrmUnsettleData(FrmUnsettleData model)
        {
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model = objDB.GetFrmUnsettleData();
            return View(model);
        }


        public ActionResult GetUnsettleData(FrmUnsettleData model)
        {
            model = EmployeeDB.GetUnsettleData(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UnsettleData(FrmUnsettleData model)
        {
            model = EmpDB.UnsettleData(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region GenExcelForBonus  
        public ActionResult GenExcelForBonus(ExcelForBonus model)
        { 
            ViewBag.Department = MasterDB.Dropdown(4, 0); 
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0); 
            return View(model);
        } 
        public ActionResult GenerateExcelforBonus(ExcelForBonus model)
        {

            model.List = EmpDB.GenerateExcelforBonus(model);

            DataTable dt = new DataTable("BonusReport");
            dt.Columns.AddRange(new DataColumn[17] {
            new DataColumn("EmpId"),
            new DataColumn("Department"),
            new DataColumn("SubDepartment"),
            new DataColumn("DeptEmpCode"),
            new DataColumn("PFMSCode"),
            new DataColumn("EmpName"),
            new DataColumn("FatherName"),
            new DataColumn("FinYear"),
            new DataColumn("DOB"),
            new DataColumn("DOR"),
            new DataColumn("DOJ"),
            new DataColumn("PF Account"),
            new DataColumn("Status(Y/N)"),
            new DataColumn("PF(Y/N)"),
            new DataColumn("OtherAllowances"),
            new DataColumn("OtherDeductions"),
            new DataColumn("Remarks"),

            });

            foreach (var item in model.List)
            {
                dt.Rows.Add(item.EmpId, item.Department, item.SubDepartment, item.DPTEmpCode, item.pfmscode, item.EmpName, item.FatherName, item.FinYear, item.DOB, item.DOR, item.DOJ, item.PFAccount, item.Status, item.PFStatus, item.OtherAllAmt, item.OtherDedAmt, item.Remarks);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BonusReport.xlsx");
                }
            }
            return View();
        }
        #endregion
    }
}

