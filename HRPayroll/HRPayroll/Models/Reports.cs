using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRPayroll.Models
{
    public class Reports
    {
    }




    public class LoanReport
    {
        public string Year { get; set; }
        public int Month { get; set; }
        public int Wtype { get; set; }
        public int EmpType { get; set; }
        public string SalaryType { get; set; }
        public int Department { get; set; }
        public int SubDepartment { get; set; }
        public int EmployeeID { get; set; }
        public int LoanType { get; set; }
        public string OrderBy { get; set; }

        public List<LoanReportList> LoanReportLists { get; set; }
    }

    public class LoanReportList
    {
        public string DepartmentHead { get; set; }
        public string SubdeptName { get; set; }
        public string EmpName { get; set; }
        public string DptEMpCode { get; set; }
        public string FatherName { get; set; }
        public string DesignationName { get; set; }
        public string gross { get; set; }
        public string NetPay { get; set; }
        public string AcNO { get; set; }
        public string Amount { get; set; }
        public string EPFCode { get; set; }
        public string NPSNO { get; set; }
    }

    public class ServiceBook
    {
        public int Fk_EmpId { get; set; }
        public string DptEmpCode { get; set; }
        public int Fk_SubDeptId { get; set; }
        public string DesignationName { get; set; }
        public string Fk_DepartmentId { get; set; }
        public string EmployeeName { get; set; }
        public string SubDepartmentName { get; set; }
        public string DepartmentName { get; set; }
        public string WorkingType { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
        public string PFMSCODE { get; set; }
        public string EmpPFMSCODE { get; set; }
        public string EmpName { get; set; }
        public string Status { get; set; }
        public List<ServiceBook> List { get; set; }
    }

    public class Compensative
    {
        public int Fk_SubDeptId { get; set; }
        public string Fk_DepartmentId { get; set; }
        public string EmpIdC { get; set; }
        public int PreEmpP { get; set; }
        public string EmployeeNameP { get; set; }
        public string SubDeptNameP { get; set; }
        public string DepartmentHeadP { get; set; }
        public string PFMSCODEP { get; set; }
        public int PreEmpC { get; set; }
        public string EmployeeNameC { get; set; }
        public string SubDeptNameC { get; set; }
        public string DepartmentHeadC { get; set; }
        public string PFMSCODEC { get; set; }
        public int EmpIdP { get; set; }
        public List<Compensative> List { get; set; }

    }

    public class RptEmpLeaveDetail
    {
        public int Fk_SubDeptId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int EmpId { get; set; }
        public int WTypeId { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string ReportFor { get; set; }
        public string SubDeptName { get; set; }
        public string DeptName { get; set; }
        public string PFMSCode { get; set; }
        public string fathername { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }

        public List<RptEmpLeaveDetail> RptEmpLeaveDetailList { get; set; }
    }

    public class DeductionReport
    {
        public int Fk_SubDeptId { get; set; }
        public int SalaryType { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int EmpId { get; set; }
        public int WTypeId { get; set; }
        public int EmpType { get; set; }
        public int Month { get; set; }
        public string GISNO { get; set; }
        public string AcNo { get; set; }
        public string BankName { get; set; }
        public string AdvAmount { get; set; }
        public string Amount { get; set; }
        public string NetPay { get; set; }
        public string Gross { get; set; }
        public string Code { get; set; }
        public string AccountNo { get; set; }
        public string RTGSCode { get; set; }
        public string BranchName { get; set; }
        public string DesignationName { get; set; }
        public string DptEMpCode { get; set; }
        public string FatherName { get; set; }
        public string EmpName { get; set; }
        public string SubdeptName { get; set; }
        public string DepartmentHead { get; set; }
        public string Amount1 { get; set; }
        public string DA { get; set; }
        public string Basicsal { get; set; }
        public string NPSNO { get; set; }
        public string EPFCode { get; set; }
        public string NPS { get; set; }
        public string DAAmount { get; set; }
        public string BasicSalary { get; set; }
        public string UANNO { get; set; }
        public string DOJ { get; set; }
        public string Nominee { get; set; }
        public string Mobileno { get; set; }
        public string Panno { get; set; }
        public string AdharNo { get; set; }
        public string GISCode { get; set; }
        public string DOB { get; set; }
        public string WorkDays { get; set; }
        public string Pfmscode { get; set; }
        public string ESIC { get; set; }
        public string Year { get; set; }
        public string OrderBy { get; set; }
        public string BillDate { get; set; }
        public string DeductionType { get; set; }
        public List<DeductionReport> List { get; set; }
    }

    public class RptEmpLicdetail
    {
        public int Fk_SubDeptId { get; set; }
        public int SalaryType { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int EmpId { get; set; }
        public int WTypeId { get; set; }
        public int EmpType { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string OrderBy { get; set; }
        public string Amount { get; set; }
        public string LicNo { get; set; }
        public string GISCode { get; set; }
        public string DesignationName { get; set; }
        public string FatherName { get; set; }
        public string EmpName { get; set; }
        public string subdeptname { get; set; }
        public string DepartmentHead { get; set; }

        public List<RptEmpLicdetail> RptEmpLicdetailList { get; set; }
        public List<RptEmpLicdetail1> RptEmpLicdetailList1 { get; set; }
        public List<RptEmpLicdetail2> RptEmpLicdetailList2 { get; set; }
    }

    public class RptEmpLicdetail1
    {
        public string OfficeHN { get; set; }
    }

    public class RptEmpLicdetail2
    {
        public string Amount { get; set; }
    }

    public class AdvanceLoan
    {
        public string EmpName { get; set; }
        public string QryP { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string PFMSCODE { get; set; }
        public string EmpPFMSCODE { get; set; }
        public string DptEmpCode { get; set; }
        public string Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int Fk_EmpId { get; set; }
        public string EndDate { get; set; }
        public string StartDate { get; set; }
        public string RecTotInst { get; set; }
        public string TotalInst { get; set; }
        public string InstAmount { get; set; }
        public string LoanAmount { get; set; }
        public string LoanNo { get; set; }
        public string LoanType { get; set; }
        public string PFMSCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmpId { get; set; }
        public List<AdvanceLoan> List { get; set; }
    }

    public class VariationReport
    {
        public int ID { get; set; }
        public int District { get; set; }
        public int ULBType { get; set; }
        public int ULBName { get; set; }
        public int Month { get; set; }
        public string Year { get; set; }
        public string Premonth { get; set; }
        public string CurMonth { get; set; }
        public string WType { get; set; }
        public string Employement { get; set; }
        public string DepartmentHead { get; set; }
        public string SubDeptName { get; set; }
        public string EmpName { get; set; }
        public int WorkingType { get; set; }
        public int E1WTypeId { get; set; }
        public int WTypeId { get; set; }
        public int P1EmpId { get; set; }
        public int P1SubDeptId { get; set; }
        public int E1EmployementId { get; set; }
        public int EmployementId { get; set; }
        public int P1TotalEmp { get; set; }
        public int P1Retirement { get; set; }
        public int P1DepartmentId { get; set; }
        public int P1Expire { get; set; }
        public int P1GrossPay { get; set; }
        public int P1Deduction { get; set; }
        public int P1NetPay { get; set; }
        public int P2DepartmentId { get; set; }
        public int P2SubDeptId { get; set; }
        public int P2TotalEmp { get; set; }
        public int P2Retirement { get; set; }
        public int P2Expire { get; set; }
        public int P2GrossPay { get; set; }
        public int P2Deduction { get; set; }
        public int P2NetPay { get; set; }
        public List<VariationReport> List { get; set; }
    }

    public class Rptemppayment
    {
        public int WTypeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string SalaryType { get; set; }
        public int BankId { get; set; }
        public int checkSelect { get; set; }
        public decimal Total { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string MobileNo { get; set; }
        public string Designation { get; set; }
        public string FatherName { get; set; }
        public string EmpName { get; set; }

        public List<Rptemppayment> RptemppaymentList { get; set; }
    }

    public class LeaveDedReport
    {
        public int WTypeId { get; set; }
        public int EmpType { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int District { get; set; }
        public int ULBType { get; set; }
        public string ULBName { get; set; }
        public int OfficeName { get; set; }
        public int OfficeId { get; set; }
        public int EmpId { get; set; }
        public string OverTimeAmt { get; set; }
        public string LeaveAmt { get; set; }
        public string SuspAmt { get; set; }
        public string BasicPay { get; set; }
        public string PayYear { get; set; }
        public string PayMonth { get; set; }
        public string LeaveDays { get; set; }
        public string LeaveType { get; set; }
        public string Designation { get; set; }
        public string EmpName { get; set; }
        public string PFMSCODE { get; set; }
        public string SubDepartment { get; set; }
        public string Department { get; set; }
        public string Employement { get; set; }



        public List<LeaveDedReport> LeaveDedReportList { get; set; }
    }

    public class RptSubDepWiseSummaryCustom
    {
        public int WTypeId { get; set; }
        public int EmpType { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int District { get; set; }
        public int ULBType { get; set; }
        public string ULBName { get; set; }
        public string SalaryType { get; set; }
        public string OfficeName { get; set; }
        public int OfficeId { get; set; }
        public int EmpId { get; set; }
        public string HeadName { get; set; }
        public string Employement { get; set; }
        public string DepartmentName { get; set; }
        public string SubDepartmentName { get; set; }
        public string DepartentCode { get; set; }
        public string PFMSCode { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string DesignationName { get; set; }
        public string PayMonth { get; set; }
        public string PayYear { get; set; }
        public string TText { get; set; }
        public string TVal { get; set; }
        public string BasicSalary00 { get; set; }
        public string GradePay { get; set; }
        public List<RptSubDepWiseSummaryCustom> RptSubDepWiseSummaryCustomList { get; set; }
    }

    public class SalaryBill
    {
        public int ID { get; set; }
        public int DistrictId { get; set; }
        public int officeTypeId { get; set; }
        public int OfficeId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public string SalaryType { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int EmpId { get; set; }
        public int WTypeId { get; set; }
        public int EmpType { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int District { get; set; }
        public string ULBType { get; set; }
        public string ULBName { get; set; }
        public string OrderBy { get; set; }
        public string OfficeName { get; set; }
        public string HeadName { get; set; }
        public string Employement { get; set; }
        public string DepartmentName { get; set; }
        public string SubDepartmentName { get; set; }
        public string DepartentCode { get; set; }
        public string PFMSCode { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string DesignationName { get; set; }
        public string PayMonth { get; set; }
        public string PayYear { get; set; }
        public string TText { get; set; }
        public string TVal { get; set; }
        public string BasicSalary00 { get; set; }
        public string GradePay { get; set; }
        public List<SalaryBill> list { get; set; }
    }

    public class Financial
    {
        public int ID { get; set; }
        public int FYearId { get; set; }
        public int WTypeId { get; set; }
        public int EId { get; set; }
        public int OfficeID { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int EmpCategory { get; set; }
        public string SalaryType { get; set; }
        public int EmpType { get; set; }
        public int LoanType { get; set; }
        public string OrderBy { get; set; }
        public string Year { get; set; }
        public string FinYear { get; set; }
        public string DepartmentHead { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string DesignationName { get; set; }
        public string FatherName { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string AdharNo { get; set; }
        public string PANNo { get; set; }
        public string NPSNo { get; set; }
        public string GISCode { get; set; }
        public string EPFCode { get; set; }
        public string GPFCode { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string UANNO { get; set; }
        public string AprDed { get; set; }
        public string MayDed { get; set; }
        public string JunDed { get; set; }
        public string JulDed { get; set; }
        public string AugDed { get; set; }
        public string SepDed { get; set; }
        public string OctDed { get; set; }
        public string NovDed { get; set; }
        public string DecDed { get; set; }
        public string JanDed { get; set; }
        public string FebDed { get; set; }
        public string MarDed { get; set; }
        public List<Financial> list { get; set; }
    }

    public class SalarySummery
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Fk_DepartmentId { get; set; }
        public string NetPay { get; set; }
        public string TotalDed { get; set; }
        public string GrossPay { get; set; }
        public string TotalAllow { get; set; }
        public string BasicSal { get; set; }
        public int EmpId { get; set; }
        public int DepartmentId { get; set; }
        public int OfficeID { get; set; }
        public string DepartmentHead { get; set; }

        public List<SalarySummery> List { get; set; }
    }

    public class SalaryReport
    {
        public int EmpId { get; set; }
        public int GradePayId { get; set; }
        public int LevelId { get; set; }
        public int IncrementId { get; set; }
        public int CommssionId { get; set; }
        public int CircleId { get; set; }
        public int GPFTypeId { get; set; }
        public int RowNumber { get; set; }
        public string BankLoan { get; set; }
        public string Photo { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public string LoanAmt { get; set; }
        public string BankName { get; set; }
        public string SpecPay { get; set; }
        public string PayReco { get; set; }
        public string Penalty { get; set; }
        public string Remarks { get; set; }
        public string salarytype { get; set; }
        public string NetPay { get; set; }
        public string Rd { get; set; }
        public string StaffAdv { get; set; }
        public string CoOperative { get; set; }
        public string OtherReco { get; set; }
        public string MiscReco { get; set; }
        public string EmergLoan { get; set; }
        public string VehicleLoan { get; set; }
        public string HBA { get; set; }
        public string QtrRent { get; set; }
        public string GPFAdv { get; set; }
        public string PPFAdv { get; set; }
        public string LIC { get; set; }
        public string CourtReco { get; set; }
        public string Society { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal GPF { get; set; }
        public decimal VehicleCharges { get; set; }
        public string GIS { get; set; }
        public decimal PPF { get; set; }
        public decimal DisAllow { get; set; }
        public decimal GrossPay { get; set; }
        public string MiscDedDesc3 { get; set; }
        public string MiscDedDesc4 { get; set; }
        public string MiscDedAmt4 { get; set; }
        public decimal MiscDedAmt3 { get; set; }
        public string MiscDedDesc1 { get; set; }
        public string MiscDedDesc2 { get; set; }
        public decimal MiscDedAmt2 { get; set; }
        public decimal MiscAllowDesc4 { get; set; }
        public decimal MiscDedAmt1 { get; set; }
        public decimal MiscAllowAmt4 { get; set; }
        public decimal MiscAllowAmt3 { get; set; }
        public string MiscAllowDesc3 { get; set; }
        public string MiscAllowDesc2 { get; set; }
        public decimal MiscAllowAmt2 { get; set; }
        public string MiscAllowDesc1 { get; set; }
        public string MiscAllowAmt1 { get; set; }
        public string VehicleAllow { get; set; }
        public string OtherAllow { get; set; }
        public string DepAllow { get; set; }
        public string NPSEmployee { get; set; }
        public string NPSEmployer { get; set; }
        public string BilangAllow { get; set; }
        public string PPFContribution { get; set; }
        public string PenContribution { get; set; }
        public string CleaningAllow { get; set; }
        public string BroomAllow { get; set; }
        public string ChatvaAllow { get; set; }
        public string PerPay { get; set; }
        public decimal HRA { get; set; }
        public decimal CCA { get; set; }
        public decimal IR { get; set; }
        public decimal WA { get; set; }
        public decimal MA { get; set; }
        public decimal DA { get; set; }
        public decimal DAPer { get; set; }
        public decimal GradePay { get; set; }
        public decimal BasicSal { get; set; }
        public decimal MonBasic { get; set; }
        public string FatherName { get; set; }
        public string Empcode { get; set; }
        public string DptEmpCode { get; set; }
        public string EmpName { get; set; }
        public string AccountNo { get; set; }
        public string EPFCode { get; set; }
        public string GPFCode { get; set; }
        public string GISCode { get; set; }
        public string NPSNo { get; set; }
        public string DOR { get; set; }
        public string DivisionName { get; set; }
        public string OfficeName { get; set; }
        public string PANNo { get; set; }
        public string Designation { get; set; }
        public string Employement { get; set; }
        public string GPFType { get; set; }
        public string RTGSCode { get; set; }
        public string PayYear { get; set; }
        public string PayMonth { get; set; }
        public int District { get; set; }
        public int ULBType { get; set; }
        public int ULBName { get; set; }
        public int Fk_DepartmentId { get; set; }
        public string Fk_SubDeptId { get; set; }
        public List<string> Fk_SubDeptIdList { get; set; }
        public string OrderBy { get; set; }
        public int chknps { get; set; }
        public int chkpen { get; set; }
        public string IsDepot { get; set; }
        public string Subtype { get; set; }

        public List<SalaryReport1> SalaryReports { get; set; }
        public List<TreasuryBillSummary> TreasuryBillSummary { get; set; }
        public List<TreasuryBillBankWiseSummary> TreasuryBillBankWiseSummary { get; set; }
        public List<HQGPFSummary> HQGPFSummary { get; set; }
        public List<string> SubDepartmentlst { get; set; }

        public List<PensionerBill> PensionerBill { get; set; }
        public List<PensionerSummry> PensionerSummry { get; set; }
    }

 

    public class RptDepWiseSummaryCustom
    {

        public int WTypeId { get; set; }
        public int EmpType { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int District { get; set; }
        public int ULBType { get; set; }
        public string ULBName { get; set; }
        public string SalaryType { get; set; }
        public string OfficeName { get; set; }
        public int OfficeId { get; set; }
        public int EmpId { get; set; }
        public string HeadName { get; set; }
        public string Employement { get; set; }
        public string DepartmentName { get; set; }
        public string SubDepartmentName { get; set; }
        public string DepartentCode { get; set; }
        public string PFMSCode { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string DesignationName { get; set; }
        public string PayMonth { get; set; }
        public string PayYear { get; set; }
        public string TText { get; set; }
        public string TVal { get; set; }
        public string BasicSalary00 { get; set; }
        public string GradePay { get; set; }




        public List<RptDepWiseSummaryCustom> RptDepWiseSummaryCustomList { get; set; }
    }

    public class DesigWiseSummery
    {
        public int WTypeId { get; set; }
        public int EmpType { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int District { get; set; }
        public int ULBType { get; set; }
        public string ULBName { get; set; }
        public string SalaryType { get; set; }
        public string OfficeName { get; set; }
        public int OfficeId { get; set; }
        public int EmpId { get; set; }
        public string HeadName { get; set; }
        public string Employement { get; set; }
        public string DepartmentName { get; set; }
        public string SubDepartmentName { get; set; }
        public string DepartentCode { get; set; }
        public string PFMSCode { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string DesignationName { get; set; }
        public string PayMonth { get; set; }
        public string PayYear { get; set; }
        public string TText { get; set; }
        public string TVal { get; set; }
        public string BasicSalary00 { get; set; }
        public string GradePay { get; set; }




        public List<DesigWiseSummery> DesigWiseSummeryList { get; set; }
    }

    public class SupplementaryReport
    {
        public int WTypeId { get; set; }
        public int EmpType { get; set; }
        public int FromMonth { get; set; }
        public int FromYear { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int District { get; set; }
        public int ULBType { get; set; }
        public string ULBName { get; set; }
        public string SalaryType { get; set; }
        public string OfficeName { get; set; }
        public int OfficeId { get; set; }
        public int EmpId { get; set; }
        public int OrderBy { get; set; }
        public string HeadName { get; set; }
        public string Employement { get; set; }
        public string DepartmentName { get; set; }
        public string SubDepartmentName { get; set; }
        public string DepartentCode { get; set; }
        public string PFMSCode { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string DesignationName { get; set; }
        public string PayMonth { get; set; }
        public string PayYear { get; set; }
        public string TText { get; set; }
        public string TVal { get; set; }
        public string BasicSalary00 { get; set; }
        public string GradePay { get; set; }
        public List<SupplementaryReport> SupplementaryReportList { get; set; }
    }
    public class EmpLeaveSuspendDelete
    {
        public string AccountNo { get; set; }
        public string SelectType { get; set; }
        public string PFMSCod { get; set; }
        public string UniqueCode { get; set; }
        public string Employee { get; set; }

        public string Year { get; set; }
        public string Month { get; set; }
        public string LeaveType { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string PFMSCODE { get; set; }
        public string DPTEmpCode { get; set; }
        public string NoDays { get; set; }

        public int flag { get; set; }
        public int Id { get; set; }
        public int DeleteID { get; set; }

        public int WtypeId { get; set; }
        public int EmpId { get; set; }
        public string message { get; set; }

        public List<EmpLeaveSuspendDelete> List { get; set; }

    }


    public class SalaryReport1
    {
        public int RowNo { get; set; }
        public int EmpId { get; set; }
        public string EmpCode { get; set; }
        public string DptEmpCode { get; set; }
        public string EmpName { get; set; }
        public string AccountNo { get; set; }
        public string EPFCode { get; set; }
        public string GPFCode { get; set; }
        public string GISCode { get; set; }
        public string NPSNo { get; set; }
        public string DOR { get; set; }
        public string DivisionName { get; set; }
        public string OfficeName { get; set; }
        public string PANNo { get; set; }
        public string Designation { get; set; }
        public string Employement { get; set; }
        public string GPFType { get; set; }
        public string RTGSCode { get; set; }
        public string PayYear { get; set; }
        public string PayMonth { get; set; }
        public string WorkDays { get; set; }
        public string GradePayId { get; set; }
        public string CircleId { get; set; }
        public string FatherName { get; set; }
        public string MonBasic { get; set; }
        public string BasicSal { get; set; }
        public string GradePay { get; set; }
        public string DAPer { get; set; }
        public decimal DA { get; set; }
        public decimal MA { get; set; }
        public decimal WA { get; set; }
        public decimal IR { get; set; }
        public decimal CCA { get; set; }
        public decimal HRA { get; set; }
        public decimal PerPay { get; set; }
        public decimal ChatvaAllow { get; set; }
        public string BroomAllow { get; set; }
        public string CleaningAllow { get; set; }
        public string SpecPay { get; set; }
        public decimal PPFContribution { get; set; }
        public string BilangAllow { get; set; }
        public string NPSEmployer { get; set; }
        public string NPSEmployee { get; set; }
        public string DisAllow { get; set; }
        public string DepAllow { get; set; }
        public string VehicleAllow { get; set; }
        public string OtherAllow { get; set; }
        public decimal MiscAllowAmt1 { get; set; }
        public string MiscAllowDesc1 { get; set; }
        public decimal MiscAllowAmt2 { get; set; }
        public string MiscAllowDesc2 { get; set; }
        public decimal MiscAllowAmt3 { get; set; }
        public string MiscAllowDesc3 { get; set; }
        public decimal MiscAllowAmt4 { get; set; }
        public string MiscAllowDesc4 { get; set; }
        public decimal MiscDedAmt1 { get; set; }
        public string MiscDedDesc1 { get; set; }
        public decimal MiscDedAmt2 { get; set; }
        public string MiscDedDesc2 { get; set; }
        public decimal MiscDedAmt3 { get; set; }
        public string MiscDedDesc3 { get; set; }
        public decimal MiscDedAmt4 { get; set; }
        public string MiscDedDesc4 { get; set; }
        public decimal GrossPay { get; set; }
        public string GPFTypeId { get; set; }
        public string GPF { get; set; }
        public decimal PPF { get; set; }
        public string LIC { get; set; }
        public string GIS { get; set; }
        public string VehicleCharges { get; set; }
        public string IncomeTax { get; set; }
        public string CourtReco { get; set; }
        public string QtrRent { get; set; }
        public string Society { get; set; }
        public string PPFAdv { get; set; }
        public decimal HBA { get; set; }
        public string GPFAdv { get; set; }
        public string VehicleLoan { get; set; }
        public string BankLoan { get; set; }
        public string EmergLoan { get; set; }
        public string PayReco { get; set; }
        public string MiscReco { get; set; }
        public string OtherReco { get; set; }
        public string StaffAdv { get; set; }
        public string CoOperative { get; set; }
        public string Penalty { get; set; }
        public string Rd { get; set; }
        public string Remarks { get; set; }
        public string salarytype { get; set; }
        public string CommssionId { get; set; }
        public string LevelId { get; set; }
        public string IncrementId { get; set; }
        public string BankName { get; set; }
        public string Photo { get; set; }
        public string LoanAmt { get; set; }
        public decimal PenContribution { get; set; }
        public decimal NetPay { get; set; }
        public string RD { get; set; }


        public string fathername { get; set; }
        public string DutyDays { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal DAAmount { get; set; }
        public decimal EPFEmployer { get; set; }
        public decimal EOther { get; set; }
        public decimal EMisc { get; set; }
        public decimal EMisc2 { get; set; }
        public decimal PPFCont { get; set; }
        public decimal Festival { get; set; }
        public decimal EPFEmployee { get; set; }
        public decimal ESICEmployer { get; set; }
        public decimal ESICEmployee { get; set; }
        public decimal DPPF { get; set; }
        public decimal Penality { get; set; }
        public decimal courtded { get; set; }
        public decimal DMisc { get; set; }
        public decimal DMisc2 { get; set; }
        public decimal TotDeduction { get; set; }
    }

    public class TreasuryBillSummary
    {
        public decimal BasicPay { get; set; }
        public decimal BasicSal { get; set; }
        public string GradePay { get; set; }
        public decimal DA { get; set; }
        public decimal MA { get; set; }
        public decimal WA { get; set; }
        public decimal IR { get; set; }
        public decimal CCA { get; set; }
        public decimal HRA { get; set; }
        public decimal PerPay { get; set; }
        public string SpecPay { get; set; }
        public string DisAllow { get; set; }
        public string VehicleAllow { get; set; }
        public string OtherAllow { get; set; }
        public decimal GrossPay { get; set; }
        public string ChatvaAllow { get; set; }
        public string CleaningAllow { get; set; }
        public string PenContribution { get; set; }
        public string PPFContribution { get; set; }
        public string NPSEmployer { get; set; }
        public string NPSEmployee { get; set; }
        public string GPF { get; set; }
        public decimal PPF { get; set; }
        public string VehicleCharges { get; set; }
        public string PPFAdv { get; set; }
        public string LIC { get; set; }
        public string GIS { get; set; }
        public string IncomeTax { get; set; }
        public string CourtReco { get; set; }
        public string QtrRent { get; set; }
        public string Society { get; set; }
        public string GPFAdv { get; set; }
        public string VehicleLoan { get; set; }
        public string EmergLoan { get; set; }
        public string BroomAllow { get; set; }
        public string HBA { get; set; }
        public string PayReco { get; set; }
        public string MiscReco { get; set; }
        public string OtherReco { get; set; }
        public string StaffAdv { get; set; }
        public string CoOperative { get; set; }
        public string Penalty { get; set; }
        public string BankLoan { get; set; }
        public decimal MiscAllowAmt1 { get; set; }
        public decimal MiscAllowAmt2 { get; set; }
        public string BilangAllow { get; set; }
        public decimal MiscAllowAmt3 { get; set; }
        public decimal MiscAllowAmt4 { get; set; }
        public decimal MiscDedAmt1 { get; set; }
        public decimal MiscDedAmt2 { get; set; }
        public decimal MiscDedAmt3 { get; set; }
        public decimal MiscDedAmt4 { get; set; }
        public string Rd { get; set; }
        public decimal NetPay { get; set; }
        public string LoanAmt { get; set; }
        public string DepAllow { get; set; }


        //
        public string DutyDays { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal DAAmount { get; set; }
        public decimal EPFEmployer { get; set; }
        public decimal ESICEmployer { get; set; }
        public decimal EOther { get; set; }
        public decimal EMisc { get; set; }
        public decimal EMisc2 { get; set; }
        public decimal PPFCont { get; set; }
        public decimal Festival { get; set; }
        public decimal EPFEmployee { get; set; }
        public decimal ESICEmployee { get; set; }
        public decimal DPPF { get; set; }
        public decimal courtded { get; set; }
        public decimal Penality { get; set; }
        public decimal DMisc { get; set; }
        public decimal DMisc2 { get; set; }
        public decimal TotDeduction { get; set; }
   
    }

    public class TreasuryBillBankWiseSummary
    {
        public int Sno { get; set; }
        public string BankName { get; set; }
        public decimal NetPay { get; set; }
        public string EmpCount { get; set; }
    }

    public class HQGPFSummary
    {
        public int SNo { get; set; }
        public int EmpCnt { get; set; }
        public int GPFTypeId { get; set; }
        public string GPFType { get; set; }
        public decimal Amount { get; set; }
    }


    public class PensionerBill
    {
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string FatherName { get; set; }
        public string DOR { get; set; }
        public string NPSNo { get; set; }
        public decimal BasicSal { get; set; }
        public decimal DA { get; set; }
        public decimal ChatvaAllow { get; set; }
        public decimal PPFContribution { get; set; }
        public decimal OtherAllow { get; set; }
        public decimal BilangAllow { get; set; }
        public decimal GrossPay { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal QtrRent { get; set; }
        public decimal StaffAdv { get; set; }
        public decimal NetPay { get; set; }
        public string Photo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
    public class PensionerSummry
    {
        public decimal BasicSal { get; set; }
        public decimal DA { get; set; }
        public decimal ChatvaAllow { get; set; }
        public decimal PPFContribution { get; set; }
        public decimal OtherAllow { get; set; }
        public decimal BilangAllow { get; set; }
        public decimal GrossPay { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal QtrRent { get; set; }
        public decimal StaffAdv { get; set; }
        public decimal NetPay { get; set; }
    }
}