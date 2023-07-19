using ClosedXML.Excel;
using HRPayroll.Filters;
using HRPayroll.Models;
using HRPayroll.Models.DBRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace HRPayroll.Controllers
{
    [AuthorizeAdmin]
    public class ReportsController : Controller
    {
        // GET: Reports
        EmployeeDB EmpDB = new EmployeeDB();
        MasterDB objDB = new MasterDB();
        public ActionResult Index()
        {
            return View();
        }

        #region Loan Report
        [HttpGet]
        public ActionResult LoanReport()
        {
            LoanReport model = new LoanReport();
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);

            ViewBag.LoanType = MasterDB.BindLoanType();


            return View(model);
        }
        [HttpPost]
        public ActionResult LoanReport(LoanReport model)
        {
            LoanReport obj = new LoanReport();
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.LoanType = MasterDB.BindLoanType();
            obj.LoanReportLists = EmpDB.LoanReport(model);
            obj.Year = model.Year;
            obj.Month = model.Month;
            obj.Wtype = model.Wtype;
            obj.EmpType = model.EmpType;
            obj.SalaryType = model.SalaryType;
            obj.Department = model.Department;
            obj.SubDepartment = model.SubDepartment;
            obj.EmployeeID = model.EmployeeID;
            obj.LoanType = model.LoanType;
            return View(obj);
        }
        [HttpPost]
        public JsonResult GetEmployeeType(string empCategory)
        {
            MasterDB objDB = new MasterDB();
            List<SelectListItem> modelresult = objDB.GetEmpCategory(Convert.ToInt32(empCategory));
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSubCategory(string DepartmentId)
        {
            var res = EmpDB.BindSubCategory(Convert.ToInt32(DepartmentId));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmpForLoan(string Year, string Month, string EmpType, string Department, string SubDepartment, string EmployeeID, string empCategory)
        {
            if (string.IsNullOrEmpty(EmpType))
            {
                EmpType = "0";
            }
            if (string.IsNullOrEmpty(Department))
            {
                Department = "0";
            }
            if (string.IsNullOrEmpty(SubDepartment))
            {
                SubDepartment = "0";
            }
            if (string.IsNullOrEmpty(EmployeeID))
            {
                EmployeeID = "0";
            }
            if (string.IsNullOrEmpty(empCategory))
            {
                empCategory = "0";
            }
            var res = AdminDB.BindEmpForLoan(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(EmpType), Convert.ToInt32(Department), Convert.ToInt32(SubDepartment), Convert.ToInt32(EmployeeID), Convert.ToInt32(empCategory));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BindDepartmentByWorkingType(string Year, string Month, string EmpType, string Department, string SubDepartment, string EmployeeID, string empCategory)
        {
            if (string.IsNullOrEmpty(EmpType))
            {
                EmpType = "0";
            }
            if (string.IsNullOrEmpty(Department))
            {
                Department = "0";
            }
            if (string.IsNullOrEmpty(SubDepartment))
            {
                SubDepartment = "0";
            }
            if (string.IsNullOrEmpty(EmployeeID))
            {
                EmployeeID = "0";
            }
            if (string.IsNullOrEmpty(empCategory))
            {
                empCategory = "0";
            }

            var res = AdminDB.BindDepartmentForLoan(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(EmpType), Convert.ToInt32(Department), Convert.ToInt32(SubDepartment), Convert.ToInt32(EmployeeID), Convert.ToInt32(empCategory));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDepartmnetSubGategory(string Year, string Month, string EmpType, string Department, string SubDepartment, string EmployeeID, string empCategory)
        {
            if (string.IsNullOrEmpty(EmpType))
            {
                EmpType = "0";
            }
            if (string.IsNullOrEmpty(Department))
            {
                Department = "0";
            }
            if (string.IsNullOrEmpty(SubDepartment))
            {
                SubDepartment = "0";
            }
            if (string.IsNullOrEmpty(EmployeeID))
            {
                EmployeeID = "0";
            }
            if (string.IsNullOrEmpty(empCategory))
            {
                empCategory = "0";
            }
            var res = AdminDB.BindSubDepartmentForLoan(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(EmpType), Convert.ToInt32(Department), Convert.ToInt32(SubDepartment), Convert.ToInt32(EmployeeID), Convert.ToInt32(empCategory));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Leave Report 
        public ActionResult RptEmpLeaveDetail(RptEmpLeaveDetail model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View(model);
        }
        public ActionResult Show_RptEmpLeaveDetail(RptEmpLeaveDetail model)
        {
            RptEmpLeaveDetail obj = new RptEmpLeaveDetail();
            obj = EmployeeDB.GetRptEmpLeaveDetail(model);
            return PartialView("_RptEmpLeaveDetail", obj);
        }
        #endregion

        #region LIC Report 
        public ActionResult RptEmpLicdetail(RptEmpLicdetail model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View(model);
        }
        public JsonResult filldepartment(RptEmpLicdetail model)
        {
            EmployeeDB objDB = new EmployeeDB();
            List<SelectListItem> modelresult = objDB.Getfilldepartment(model);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult filldepartment1(RptEmpLicdetail model)
        {
            EmployeeDB objDB = new EmployeeDB();
            List<SelectListItem> modelresult = objDB.Getfilldepartment1(model);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSubDepartment(int DepartmentId)
        {
            MasterDB objDB = new MasterDB();
            List<SelectListItem> modelresult = objDB.GetSubDepartment(DepartmentId);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Show_RptLicDetail(RptEmpLicdetail model)
        {
            RptEmpLicdetail obj = new RptEmpLicdetail();
            obj = EmpDB.GetRptEmpLicDetail(model);
            return PartialView("_RptEmpLicDetail", obj);
        }
        #endregion

        #region DeductionReport
        [HttpGet]
        public ActionResult DeductionReport()
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View();
        }

        [HttpPost]
        public ActionResult DeductionReport(DeductionReport model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model = EmployeeDB.DeductionReport(model);
            return View(model);
        }
        #endregion

        #region DAReport
        [HttpGet]
        public ActionResult DAReport()
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
        public ActionResult DAReport(DAArrear model)
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
            obj.List = objDB.GetDAArrearReport(model);
            return View(obj);
        }
        #endregion

        #region AdvanceLoanReport
        public ActionResult AdvanceLoanReport()
        {
            AdvanceLoan model = new AdvanceLoan();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            return View(model);
        }
        public JsonResult GetAdvanceLoanDetail(int EmpId, string Status, string Type)
        {
            AdvanceLoan model = new AdvanceLoan();
            model.Fk_EmpId = EmpId;
            model.Status = Status;
            model.Type = Type;
            if (Status == "O")
            {
                // model.QryP = "'A','C','S'";
                model.QryP = "";
            }
            else if (Status == "A")
            {
                // model.QryP = "'A'";
                model.QryP = "A";
            }
            else if (Status == "C")
            {
                model.QryP = "C";
            }
            else if (Status == "S")
            {
                model.QryP = "S";
            }
            model = EmployeeDB.GetAdvLoanDetail(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ServiceBook
        public ActionResult EmpServiceBook()
        {
            ServiceBook model = new ServiceBook();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            return View();
        }
        public JsonResult GetEmpServiceDetails(string EmpId)
        {
            ServiceBook model = new ServiceBook();
            if (string.IsNullOrEmpty(EmpId))
            {
                model.Fk_EmpId = 0;
            }

            else
            {
                model.Fk_EmpId = Convert.ToInt32(EmpId);
            }
            model = MasterDB.GetEmpServiceDetail(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region CompensativeReport
        [HttpGet]
        public ActionResult CompensativeReport()
        {
            Compensative model = new Compensative();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            return View(model);
        }
        [HttpPost]
        public ActionResult CompensativeReport(Compensative model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            model = EmployeeDB.CompensativeReport(model);
            return View(model);
        }

        #endregion

        #region Financial Year Deduction Detail Report
        [HttpGet]
        public ActionResult FinancialDedReport()
        {
            Financial model = new Financial();
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.LoanType = MasterDB.BindLoanType();
            return View(model);
        }
        [HttpPost]
        public ActionResult FinancialDedReport(Financial model)
        {
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.LoanType = MasterDB.BindLoanType();
            model.list = objDB.DedList(model);
            return View(model);
        }
        #endregion

        #region VariationReport
        [HttpGet]
        public ActionResult variationReport()
        {
            MasterDB objDB = new MasterDB();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            var obj = objDB.GetDataForVariationReport();
            return View(obj);
        }
        [HttpPost]
        public ActionResult variationReport(VariationReport model)
        {
            VariationReport obj = new VariationReport();
            MasterDB objDB = new MasterDB();
            ViewBag.Type = MasterDB.Dropdown(3, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            obj.List = objDB.GetVariationReport(model);
            obj.Year = model.Year;
            obj.Month = model.Month;
            return View(obj);
        }
        public ActionResult DeptwiseVariationReport(string eid, string fmid, string fyid)
        {
            VariationReport obj = new VariationReport();
            obj.List = objDB.DeptWiseVariationReport(eid, fmid, fyid);
            obj.Month = Convert.ToInt32(fmid);
            obj.Year = fyid;
            return View(obj);
        }
        public ActionResult SubDeptwiseVariationReport(string eid, string fmid, string fyid, string WTypeId)
        {
            VariationReport obj = new VariationReport();
            obj.List = objDB.SubDeptWiseVariationReport(eid, fmid, fyid, WTypeId);
            return View(obj);
        }
        public ActionResult EmpWiseVariationReport(string eid, string fmid, string fyid, string WTypeId)
        {
            VariationReport obj = new VariationReport();
            obj.List = objDB.SubDeptWiseVariationReport(eid, fmid, fyid, WTypeId);
            return View(obj);
        }
        #endregion

        #region Employee Payment Report (Priyanshu )
        public ActionResult Rptemppayment(Rptemppayment model)
        {
            MasterDB obj = new MasterDB();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Bank = obj.BindBankDropdown();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View(model);
        }

        public JsonResult GetEmpSalDetail(int SubDeptId, string DptEpCode, string PFMSCODE, string EmpName)
        {
            MasterDB objDB = new MasterDB();
            List<SelectListItem> modelresult1 = objDB.GetEmpSalDetail(SubDeptId, DptEpCode, PFMSCODE, EmpName);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSections(Rptemppayment model)
        {
            // ViewBag.GetSections = EmpDB.GetSections(model);
            return Json(ViewBag.GetSections, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Show_RptemppaymentDetail(Rptemppayment model)
        {
            Rptemppayment obj = new Rptemppayment();
            obj = EmployeeDB.GetRptemppaymentDetail(model);
            return PartialView("_Rptemppayment", obj);
        }
        #endregion

        #region Leave Deduction Report - Custom 
        public ActionResult LeaveDedReport(LeaveDedReport model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model = objDB.GetLeaveDedReport();
            return View(model);
        }


        public JsonResult GetULBHeadWiseLeaveDeduction(LeaveDedReport model)
        {
            LeaveDedReport obj = new LeaveDedReport();
            //    obj = EmployeeDB.GetULBHeadWiseLeaveDeduction(model);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Salary Bill Report
        public ActionResult SalaryBillRpt()
        {
            SalaryBill model = new SalaryBill();
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model = EmpDB.GetSalaryBillReport();
            return View(model);
        }

        public JsonResult GetULBHeadWiseSalaryBillDetails3(SalaryBill model)
        {

            var ds = EmpDB.GetULBHeadWiseSalaryBillDetails3(model);
            return Json(JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented), JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region Salary Bill Summary Sub-Department Wise - Custom 
        public ActionResult RptSubDepWiseSummaryCustom(RptSubDepWiseSummaryCustom model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model = objDB.GetSummaryCustom();
            return View(model);
        }
        public JsonResult GetULBHeadWiseSalaryBillDetails(RptSubDepWiseSummaryCustom model)
        {

            var ds = EmpDB.GetULBHeadWiseSalaryBillDetails(model);
            if (ds.Tables.Count == 0)
            {
                return Json(JsonConvert.SerializeObject(0, Newtonsoft.Json.Formatting.Indented), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented), JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region SalarySummery 
        public ActionResult SalarySummery(SalarySummery model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            return View(model);
        }
        public ActionResult Show_SalarySummery(SalarySummery model)
        {
            SalarySummery obj = new SalarySummery();
            model = EmployeeDB.GetRptSalarySummery(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalarySummeryExcel(SalarySummery model)
        {

            model = EmployeeDB.GetRptSalarySummery(model);

            DataTable dt = new DataTable("SalarySummeryReport");
            dt.Columns.AddRange(new DataColumn[7] {
            new DataColumn("Department Name"),
            new DataColumn("No oF Employee"),
            new DataColumn("Basic Pay"),
            new DataColumn("Total Allowance"),
            new DataColumn("Gross Pay"),
            new DataColumn("Total Deduction"),
            new DataColumn("Net Payment"),

            });

            foreach (var item in model.List)
            {
                dt.Rows.Add(item.DepartmentHead, item.EmpId, item.BasicSal, item.TotalAllow, item.GrossPay, item.TotalDed, item.NetPay);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SalarySummeryReport.xlsx");
                }
            }
            return View();
        }
        #endregion

        #region Salary Bill Summary Departmentwise - Custom 
        public ActionResult RptDepWiseSummaryCustom(RptDepWiseSummaryCustom model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model = objDB.GetDepWiseSummaryCustom();
            return View(model);
        }

        public JsonResult GetULBHeadWiseSalaryBillDetails1(RptDepWiseSummaryCustom model)
        {

            var ds = EmpDB.GetULBHeadWiseSalaryBillDetails1(model);
            if (ds.Tables.Count == 0)
            {
                return Json(JsonConvert.SerializeObject(0, Newtonsoft.Json.Formatting.Indented), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented), JsonRequestBehavior.AllowGet);
            }

        }

        #endregion 

        #region Salary Bill Summary Designation Wise - Custom 
        public ActionResult DesigWiseSummery(DesigWiseSummery model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model = objDB.GetDegWiseSummaryCustom();
            return View(model);
        }

        public JsonResult GetULBHeadWiseSalaryBillDetails2(DesigWiseSummery model)
        {

            var ds = EmpDB.GetULBHeadWiseSalaryBillDetails2(model);
            if (ds.Tables.Count == 0)
            {
                return Json(JsonConvert.SerializeObject(0, Newtonsoft.Json.Formatting.Indented), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented), JsonRequestBehavior.AllowGet);
            }

        }

        #endregion

        #region Supplementary Bill Report - Custom 
        public ActionResult SupplementaryReport(SupplementaryReport model)
        {
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            ViewBag.SubDepartment = new List<SelectListItem>();
            ViewBag.Employee = new List<SelectListItem>();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            model = objDB.GetSupplementaryReport();
            return View(model);
        }

        public JsonResult GetULBHeadWiseSupplementaryBillDetails(SupplementaryReport model)
        {
            var ds = EmpDB.GetULBHeadWiseSupplementaryBillDetails(model);
            if (ds.Tables.Count == 0)
            {
                return Json(JsonConvert.SerializeObject(0, Newtonsoft.Json.Formatting.Indented), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented), JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region SalaryBillPermanentReport
        [HttpGet]
        public ActionResult SalaryBillReport()
        {
            SalaryReport model = new SalaryReport();
            MasterDB objDB = new MasterDB();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            model = objDB.GetSalaryBillReport();
            return View(model);
        }
        [HttpPost]
        public ActionResult SalaryBillReport(SalaryReport obj)
        {
            SalaryReport model = new SalaryReport();
            MasterDB objDB = new MasterDB();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            model = objDB.GetSalaryBillReport();
            var offcieId = 0;
            if (obj.Fk_SubDeptIdList != null)
            {

                obj.Fk_SubDeptId = string.Join(",", obj.Fk_SubDeptIdList);
            }
            if (Convert.ToInt32(obj.District) > 0)
            {
                obj.IsDepot = "H";
                offcieId = obj.District;
            }
            if (Convert.ToInt32(obj.ULBType) > 0)
            {
                obj.IsDepot = "R";
                offcieId = obj.District;
            }
            if (Convert.ToInt32(obj.ULBName) > 0)
            {
                obj.IsDepot = "D";
                offcieId = obj.District;
            }
            if (obj.Subtype == "1")
            {
                obj.salarytype = "C";

            }
            if (obj.Subtype == "2")
            {
                obj.salarytype = "S";

            }

            model = EmployeeDB.DisplaySalaryBillReport(obj, Convert.ToInt32(offcieId));
            // model.Fk_SubDeptId=
            if (model.SubDepartmentlst != null)
            {
                model.Fk_SubDeptId = string.Join(",", model.SubDepartmentlst);
            }
            if (model.SalaryReports.Count() > 0)
            {
                model.Month = Convert.ToInt32(model.SalaryReports[0].PayMonth);
                model.Year = Convert.ToInt32(model.SalaryReports[0].PayYear);
                model.MonthName = MOnthName(model.Month);
            }


            model.Year = obj.Year;
            model.Month = obj.Month;
            model.OrderBy = obj.OrderBy;
            model.Fk_DepartmentId = obj.Fk_DepartmentId;
            if (obj.Fk_SubDeptIdList != null)
            {
                model.Fk_SubDeptId = string.Join(",", obj.Fk_SubDeptIdList);
            }
            return View(model);
        }
        #endregion

        #region Employee Leave Delete 
        public ActionResult EmpLeaveSuspendDelete(EmpLeaveSuspendDelete model)
        {
            EmpLeaveSuspendDelete Model = new EmpLeaveSuspendDelete();
            ViewBag.Department = MasterDB.Dropdown(4, 0);
            ViewBag.WorkingType = MasterDB.Dropdown(3, 0);
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.Employee = new List<SelectListItem>();
            return View(Model);
        }

        public JsonResult GetEmployee(EmpLeaveSuspendDelete model)
        {
            List<SelectListItem> modelresult1 = EmpDB.GetEmployee(model);
            return Json(modelresult1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Report_LeaveDelete(string EmpId,string Month,string Year,string LeaveType)
        {

            var res = EmployeeDB.ReportLeaveDelete(EmpId, Month, Year, LeaveType);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

       

        public JsonResult BindDepartmentByMonthAndYear(string Year, string Month,string proc)
        {
            var res = EmpDB.GetDepartmentByMonthAndYear(Year, Month,Convert.ToInt32(proc));
            return Json(res, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LeaveDelete(EmpLeaveSuspendDelete model)
        {

            model = EmpDB.LeaveDelete(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region SalaryBillContractualReport

        [HttpGet]
        public ActionResult RptSamvidaBill()
        {
            SalaryReport model = new SalaryReport();
            MasterDB objDB = new MasterDB();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            model = objDB.GetSalaryBillReport();
            return View(model);
        }

        [HttpPost]
        public ActionResult RptSamvidaBill(SalaryReport obj)
        {
            SalaryReport model = new SalaryReport();
            MasterDB objDB = new MasterDB();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            model = objDB.GetSalaryBillReport();
            if (model.SubDepartmentlst != null)
            {
                model.Fk_SubDeptId = string.Join(",", model.SubDepartmentlst);
            }
            model = EmployeeDB.GetTreasuryBillSummary(obj);
            if (model.SubDepartmentlst != null)
            {
                model.Fk_SubDeptId = string.Join(",", model.SubDepartmentlst);
            }
            if (model.SalaryReports.Count() > 0)
            {
                model.Month = Convert.ToInt32(model.SalaryReports[0].PayMonth);
                model.Year = Convert.ToInt32(model.SalaryReports[0].PayYear);
                model.MonthName = MOnthName(model.Month);
            }
            model.Year = obj.Year;
            model.Month = obj.Month;
            model.OrderBy = obj.OrderBy;
            model.Fk_DepartmentId = obj.Fk_DepartmentId;
            if (obj.Fk_SubDeptIdList != null)
            {
                model.Fk_SubDeptId = string.Join(",", obj.Fk_SubDeptIdList);
            }
            return View(model);
        }
        #endregion
        #region Pensioner'sBillContractualReport
        [HttpGet]
        public ActionResult RptPensionBill()
        {
            SalaryReport model = new SalaryReport();
            MasterDB objDB = new MasterDB();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            model = objDB.GetSalaryBillReport();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult RptPensionBill(SalaryReport obj)
        {
            SalaryReport model = new SalaryReport();
            MasterDB objDB = new MasterDB();
            ViewBag.Month = MasterDB.Dropdown(15, 0);
            ViewBag.ddlDistrict = objDB.BindDistrictDropdown();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            ViewBag.Agency = MasterDB.Dropdown(1, 0);
            ViewBag.EmployeeCategory = MasterDB.Dropdown(3, 0);
            model = objDB.GetSalaryBillReport();
            model = EmployeeDB.GetPensionersBillSummary(obj);
            model.Year = obj.Year;
            model.Month = obj.Month;
            model.OrderBy = obj.OrderBy;
            model.Fk_DepartmentId = obj.Fk_DepartmentId;
            if (obj.Fk_SubDeptIdList != null)
            {
                model.Fk_SubDeptId = string.Join(",", obj.Fk_SubDeptIdList);
            }
            if (model.SubDepartmentlst != null)
            {
                model.Fk_SubDeptId = string.Join(",", model.SubDepartmentlst);
            }
             if (model.PensionerBill != null)
            {
                if (model.PensionerBill.Count() > 0)
                {
                    model.Month = Convert.ToInt32(model.PensionerBill[0].Month);
                    model.Year = Convert.ToInt32(model.PensionerBill[0].Year);
                    model.MonthName = MOnthName(model.Month);
                }
            }
            return View(model);
        }

        #endregion

        public string MOnthName(int month)
        {

            return CultureInfo.CurrentCulture.
             DateTimeFormat.GetMonthName
             (month);
        }
    }
}