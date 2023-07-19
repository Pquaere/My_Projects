using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRPayroll.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public int FK_EmployeeType { get; set; }
        public int Designation { get; set; }
        public int Year { get; set; }
        public int Department { get; set; }
        public int OfficeId { get; set; }
        public int LeaveCategory { get; set; }
        public int EmpType { get; set; }
        public int monthId { get; set; }
        public string FatherName { get; set; }
        public string MobileNo { get; set; }
        public string PFMSCode { get; set; }
        public string DepEMPCode { get; set; }
        public string EmployeeName { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public int EMPid { get; set; }
        public int flag { get; set; }
    
        public List<Employee> EmployeeList { get; set; }
        public IEnumerable<Employee> EmpIDList { get; set; }
    }
    public class FrmFinalizeData
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
        public string OrderBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<FrmFinalizeData1> List { get; set; }
    }


    public class FrmFinalizeData1
    {
        public string pfmscode { get; set; }
        public string departmenthead { get; set; }
        public string empname { get; set; }
        public string fathername { get; set; }
        public string DptEmpCode { get; set; }
        public string BasicSalary { get; set; }
        public string LevelID { get; set; }
        public string gradepay { get; set; }
        public string designationname { get; set; }
        public int SubDeptId { get; set; }
        public string OrderBy { get; set; }
        public List<FrmFinalizeData1> EmpStatusList { get; set; }
    }
    public class EmployeePF
    {
        public int ID { get; set; }
        public int Fk_DepartmentId { get; set; }
        public string Year { get; set; }
        public int monthId { get; set; }
        public int YearId { get; set; }
        public int Fk_CategoryId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int Fk_EmpId { get; set; }
        public string EmpName { get; set; }
        public string select { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string AccountNo { get; set; }
        public string PAccountNo { get; set; }
        public string NoofDaysHours { get; set; }
        public string CAccountNo { get; set; }
        public string SuspendPer { get; set; }
        public string IFSC { get; set; }
        public string PFMSCODE { get; set; }
        public string SalaryStatus { get; set; }
        public string BasicSalary { get; set; }
        public string Remark { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string DOR { get; set; }
        public int FK_BankId { get; set; }
        public int NoOfDays { get; set; }
        public string DateOfDeath { get; set; }
        public string DateOfRetire { get; set; }
        public string msg { get; set; }
        public int Hours { get; set; }
        public int CommssionId { get; set; }
        public int GradePayId { get; set; }
        public int LevelID { get; set; }
        public int PayScaleID { get; set; }
        public int IncrementId { get; set; }
        public int TypeId { get; set; }
        public string STypeId { get; set; }
        public int WTypeId { get; set; }
        public string IpAddress { get; set; }
        public string DptEmpCode { get; set; }
        public bool IsActive { get; set; }
        public decimal IsPenCon { get; set; }
        public decimal IsPpf { get; set; }
        public bool IsNPSCon { get; set; }
        public bool HRA { get; set; }
        public bool CCA { get; set; }
        public bool WA { get; set; }
        public bool MA { get; set; }
        public string message { get; set; }
        public int flag { get; set; }
        public Response response { get; set; }
        public List<EmployeePF> List { get; set; }
    }

    public class ReportBonus
    {
        public int ID { get; set; }
        public int EmpId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public string Year { get; set; }
        public string OrderBy { get; set; }
        public string NetAmount { get; set; }
        public string GrossAmt { get; set; }
        public string OtherDedAmt { get; set; }
        public string OtherAllAmt { get; set; }
        public string PFAmt { get; set; }
        public string CashAmt { get; set; }
        public string DesignationName { get; set; }
        public string DptEmpCode { get; set; }
        public string AccNo { get; set; }
        public string SubDeptName { get; set; }
        public string DepartmentHead { get; set; }
        public string FName { get; set; }
        public string pfmscode { get; set; }
        public string empname { get; set; }
        public List<ReportBonus> List { get; set; }
    }

    public class EmployeeLIC
    {
        public int ID { get; set; }
        public int WTypeId { get; set; }
        public int EmployementId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int EmpType { get; set; }
        public int GISId { get; set; }
        //public string Remarks { get; set; }
        public string RenewDate { get; set; }
        public string Address { get; set; }
        public int EmpCategory { get; set; }
        public string Year { get; set; }
        public int StartMonth { get; set; }
        public string Type { get; set; }
        public decimal GISAmount { get; set; }
        public string GISNo { get; set; }
        public int Fk_SubDeptId { get; set; }
        public string PFMSCode { get; set; }
        public string DeptEmpCode { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpNameSearch { get; set; }
        public int DesignationId { get; set; }
        public int DesignationName { get; set; }
        public string FatherName { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string PermAddress { get; set; }
        public string AdharNo { get; set; }
        public string PANNo { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string DOR { get; set; }
        public string AccountNo { get; set; }
        public string Code { get; set; }
        public string LicNo { get; set; }
        public string LicAmount { get; set; }
        public string remarks { get; set; }
        public string Status { get; set; }
        public string EndDate { get; set; }
        public int Fk_AccountType { get; set; }
        public int Fk_CategoryId { get; set; }
        public bool IsActive { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public string empimg { get; set; }
        public string Photo { get; set; }
        public List<EmployeeLIC> LIClist { get; set; }

    }
    public class EmpSearch
    {
        public int ID { get; set; }
        public int EmpId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int OfficeId { get; set; }
        public int Agencytypeid { get; set; }
        public int Fk_distictId { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string DepartmentName { get; set; }
        public string SubDepartmentName { get; set; }
        public string OfficeName { get; set; }
        public string PFMSCode { get; set; }
        public string dptempcode { get; set; }
        public int WTypeId { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string SalaryStatus { get; set; }
        public List<EmpSearch> list { get; set; }
    }
    public class EmpEarningAndDeductionDetails
    {
        public int ID { get; set; }
        public int WTypeId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int GradePayId { get; set; }
        public int LevelID { get; set; }
        public int IncrementId { get; set; }
        public string DedEmpId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public string PFMSCode { get; set; }
        public string PFMSCode1 { get; set; }
        public string DeptEmpCode { get; set; }
        public string SaveUpdate { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int DesignationId { get; set; }
        public int DesignationName { get; set; }
        public string FatherName { get; set; }
        public string BasicSalary { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string PermAddress { get; set; }
        public string AdharNo { get; set; }
        public string OrderName { get; set; }
        public string AscDesc { get; set; }
        public string PANNo { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string DOR { get; set; }
        public string AccountNo { get; set; }
        public string Code { get; set; }
        public string LicNo { get; set; }
        public string LicAmount { get; set; }
        public string remarks { get; set; }
        public string Status { get; set; }
        public string EndDate { get; set; }
        public int Fk_AccountType { get; set; }
        public int Fk_CategoryId { get; set; }
        public bool IsActive { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public string DaStatus { get; set; }
        public string IsNPSCon { get; set; }

        public string HRA { get; set; }
        public decimal NPS1 { get; set; }
        public decimal PensionContribution1 { get; set; }
        public decimal PensionContribution { get; set; }
        public decimal VehicleAllow { get; set; }
        public decimal CleaningAllow { get; set; }
        public decimal DAPer { get; set; }
        public string DA { get; set; }
        public decimal NPS { get; set; }
        public string WA { get; set; }
        public decimal BroomAllow { get; set; }
        public decimal SpecPay { get; set; }
        public string MA { get; set; }
        public decimal SalaryBeforeDemotion { get; set; }
        public decimal DepAllow { get; set; }
        public decimal ChatvaAllow { get; set; }
        public decimal PPFCon { get; set; }
        public decimal PerPay { get; set; }
        public decimal OtherAllow { get; set; }
        public decimal IR { get; set; }
        public decimal DisAllow { get; set; }
        public decimal BilangAllow { get; set; }
        public decimal NPS10 { get; set; }
        public decimal MiscAmt1 { get; set; }
        public decimal MiscAmt2 { get; set; }
        public decimal MiscAmt3 { get; set; }
        public decimal MiscAmt4 { get; set; }
        public string MiscDesc1 { get; set; }
        public string MiscDesc2 { get; set; }
        public string MiscDesc3 { get; set; }
        public string MiscDesc4 { get; set; }
        public decimal MisAmt1 { get; set; }
        public decimal MisAmt2 { get; set; }
        public decimal MisAmt3 { get; set; }
        public decimal MisAmt4 { get; set; }
        public string MisDesc1 { get; set; }
        public string MisDesc2 { get; set; }
        public string MisDesc3 { get; set; }
        public string MisDesc4 { get; set; }
        public decimal NightPayment { get; set; }



        public decimal GPFPer1 { get; set; }
        public decimal GPF { get; set; }
        public decimal PPFPer1 { get; set; }
        public decimal PPF { get; set; }
        public decimal GIS { get; set; }

        public decimal VehicleCharges { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal QtrRent { get; set; }
        public decimal CourtReco { get; set; }
        public decimal RD { get; set; }
        public decimal Society { get; set; }
        public decimal CommssionId { get; set; }

        public decimal PayReco { get; set; }
        public decimal MiscReco { get; set; }
        public decimal OtherReco { get; set; }
        public decimal StaffAdv { get; set; }
        public decimal CoOperative { get; set; }
        public decimal Penalty { get; set; }
        public string txtTotalEarning { get; set; }
        public string TotalDeduction { get; set; }
        public string GrossPay { get; set; }
        public string NetPay { get; set; }
        public string PersonalPay { get; set; }

        public List<EmployeeLIC> LIClist { get; set; }
        public List<EmployeeEarning> EmployeeEarninglist { get; set; }
        public List<EmployeeDeduction> EmployeeDeductionlist { get; set; }
        public List<EmployeeGred> EmployeeGredlist { get; set; }
        public List<EmployeeDA> EmployeeDAlist { get; set; }
        public List<EmployeeFixAllow> EmployeeFixAllowlist { get; set; }

        public double hdn1 { get; set; }
        public double hdn2 { get; set; }
        public double hdn3 { get; set; }

    }
    public class EmployeeEarning
    {
        public string DaStatus { get; set; }

        public string HRA { get; set; }
        public string PensionContribution { get; set; }
        public string VehicleAllow { get; set; }
        public string CleaningAllow { get; set; }
        public string DAPer { get; set; }
        public string DA { get; set; }
        public string NPS { get; set; }
        public string WA { get; set; }
        public string BroomAllow { get; set; }
        public string SpecPay { get; set; }
        public string MA { get; set; }
        public string SalaryBeforeDemotion { get; set; }
        public string DepAllow { get; set; }
        public string ChatvaAllow { get; set; }
        public string PPFCon { get; set; }
        public string PerPay { get; set; }
        public string OtherAllow { get; set; }
        public string IR { get; set; }
        public string DisAllow { get; set; }
        public string BilangAllow { get; set; }
        public string NPS10 { get; set; }
        public string MiscAmt1 { get; set; }
        public string MiscAmt2 { get; set; }
        public string MiscAmt3 { get; set; }
        public string MiscAmt4 { get; set; }
        public string MiscDesc1 { get; set; }
        public string MiscDesc2 { get; set; }
        public string MiscDesc3 { get; set; }
        public string MiscDesc4 { get; set; }
        public string NightPayment { get; set; }
    }
    public class EmployeeDeduction
    {
        public string PensionContribution { get; set; }
        public string NPS10 { get; set; }
        public string GPFPer1 { get; set; }
        public string GPF { get; set; }
        public string PPFPer1 { get; set; }
        public string PPF { get; set; }
        public string GIS { get; set; }
        public string LicAmount { get; set; }
        public string VehicleCharges { get; set; }
        public string IncomeTax { get; set; }
        public string QtrRent { get; set; }
        public string CourtReco { get; set; }
        public string RD { get; set; }
        public string Society { get; set; }
        public string NPS { get; set; }
        public string PayReco { get; set; }
        public string MiscReco { get; set; }
        public string OtherReco { get; set; }
        public string StaffAdv { get; set; }
        public string CoOperative { get; set; }
        public string Penalty { get; set; }
        public string txtTotalEarning { get; set; }
        public string TotalDeduction { get; set; }
        public string GrossPay { get; set; }
        public string NetPay { get; set; }
        public string PersonalPay { get; set; }

        public string MiscAmt1 { get; set; }
        public string MiscAmt2 { get; set; }
        public string MiscAmt3 { get; set; }
        public string MiscAmt4 { get; set; }
        public string MiscDesc1 { get; set; }
        public string MiscDesc2 { get; set; }
        public string MiscDesc3 { get; set; }
        public string MiscDesc4 { get; set; }
    }
    public class EmployeeGred
    {
        public string GradePay { get; set; }
        public string PNPSEmployer { get; set; }
        public string PPenCont { get; set; }

    }
    public class EmployeeDA
    {
        public int FK_PayComId { get; set; }
    }
    public class EmployeeFixAllow
    {
        public string HRA { get; set; }
        public string WA { get; set; }
        public string MA { get; set; }
    }
    public class AttendanceReg
    {
        public int ID { get; set; }
        public int Fk_EmpId { get; set; }
        public int ForwardedTo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Reason { get; set; }
        public string Remark { get; set; }
        public string Other { get; set; }
        public string Status { get; set; }
        public Response response { get; set; }
        public bool IsActive { get; set; }
        public List<AttendanceReg> List { get; set; }

    }
    public class EDContractual
    {
        public int ID { get; set; }
        public int EmpId { get; set; }
        public int EmpTId { get; set; }
        public int UserId { get; set; }
        public int DepartmentID { get; set; }
        public int SubDeptID { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public string OrderName { get; set; }
        public string AscDesc { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string BasicSalary { get; set; }
        public string DaStatus { get; set; }
        public string DAPer { get; set; }
        public string DA { get; set; }
        public string Festival { get; set; }
        public string EOther { get; set; }
        public string EMisc { get; set; }
        public string EMisc2 { get; set; }
        public string EMisc3 { get; set; }
        public string LicAmount { get; set; }
        public string DMisc2 { get; set; }
        public string Penality { get; set; }
        public string DOther { get; set; }
        public int EPFDed { get; set; }
        public int DMisc { get; set; }
        public int PPPfCont { get; set; }
        public string CourtDed { get; set; }
        public string SESICEmployee { get; set; }
        public string SESICEmployer { get; set; }
        public string SEPFEmployee { get; set; }
        public string SEPFEmployer { get; set; }
        public int TotalEarning { get; set; }
        public int TotalDeduction { get; set; }
        public int GrossPay { get; set; }
        public int NetPay { get; set; }
        public string IsFixPay { get; set; }
        public string SaveUpdate { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public EDAddEarnings list { get; set; }
        public serviceType list1 { get; set; }
        public EDDeductions list2 { get; set; }

    }
    public class EDAddEarnings
    {
        public int EmpId { get; set; }
        public string IsEPF { get; set; }
        public string IsESIC { get; set; }
        public string LicAmount { get; set; }
        public int DedEmpId { get; set; }
        public string EmpName { get; set; }
        public string PFMSCODE { get; set; }
        public string FatherName { get; set; }
        public string BasicSalary { get; set; }
        public string DAPer { get; set; }
        public string CourtDed { get; set; }
        public int CommssionId { get; set; }
        public int WTypeId { get; set; }
        public string EOther { get; set; }
        public string EMisc { get; set; }
        public string Festival { get; set; }
        public string EMisc2 { get; set; }
        public string DOther { get; set; }
        public string DMisc { get; set; }
        public string Penality { get; set; }
        public string DPPF { get; set; }
        public string DMisc2 { get; set; }
        public string Status { get; set; }
        public string IsFixPay { get; set; }
    }
    public class serviceType
    {
        public string DAPer { get; set; }
    }
    public class EDDeductions
    {
        public string GradePay { get; set; }
        public string PPenCont { get; set; }
        public string PPPfCont { get; set; }
        public string PNPSEmployer { get; set; }
        public string PNPSEmployee { get; set; }
        public string SEPFEmployer { get; set; }
        public string SESICEmployer { get; set; }
        public int SEPFEmployee { get; set; }
        public int SESICEmployee { get; set; }
    }
    public class GenerateSalary
    {
        public int ID { get; set; }
        public int WTypeId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public string salaryFor { get; set; }
        public List<GenerateSalary> Salarylist { get; set; }

    }
    public class EmployeeLoan
    {
        public int ID { get; set; }
        public int WTypeId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public string PFMSCode { get; set; }
        public string DeptEmpCode { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int DesignationId { get; set; }
        public int DesignationName { get; set; }
        public string FatherName { get; set; }
        public string Year { get; set; }
        public string MonthlyDeduction { get; set; }
        public string AdvanceAmount { get; set; }
        public string TotalDeductionPre { get; set; }
        public string TotalNoOfInstalment { get; set; }
        public string CurrentNoOfInstalment { get; set; }  

        public string Month { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string PermAddress { get; set; }
        public string AdharNo { get; set; }
        public string PANNo { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string DOR { get; set; }
        public string AccountNo { get; set; }
        public string Code { get; set; }
        public string LicNo { get; set; }
        public string LicAmount { get; set; }
        public string LoneType { get; set; }
        public string OrderNo { get; set; }
        public string remarks { get; set; }
        public string Status { get; set; }
        public string EndDate { get; set; }
        public int Fk_AccountType { get; set; }
        public int Fk_CategoryId { get; set; }
        public bool IsActive { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<EmployeeLIC> LIClist { get; set; }

    }
    #region Empolyee Transfer
    public class InternalTransfer
    {
        public int ID { get; set; }
        public int TWTypeId { get; set; }
        public int preWTypeId { get; set; }
        public int preEmployementId { get; set; }
        public int TEmployementId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int SubDeptID { get; set; }
        public int DepartmentID { get; set; }
        public int preFk_DepartmentId { get; set; }
        public int TFk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int preFk_SubDeptId { get; set; }
        public int TFk_SubDeptId { get; set; }
        public string PFMSCode { get; set; }
        public string DeptEmpCode { get; set; }
        public string SearchEmpName { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int TDesignationId { get; set; }
        public int preDesignationId { get; set; }
        public int EmployementId { get; set; }
        public int DesignationName { get; set; }
        public string FatherName { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string PermAddress { get; set; }
        public string Address { get; set; }
        public string AdharNo { get; set; }
        public string PANNo { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string TDOJ { get; set; }
        public string DOR { get; set; }
        public string AccountNo { get; set; }
        public string remarks { get; set; }
        public string Status { get; set; }
        public string Year { get; set; }
        public string EndDate { get; set; }
        public int Fk_AccountType { get; set; }
        public int Ltype1 { get; set; }
        public int Ltype2 { get; set; }
        public string days1 { get; set; }
        public string days2 { get; set; }
        public int Fk_DistrictId { get; set; }
        public int Fk_CategoryId { get; set; }
        public int EmpCategory { get; set; }
        public int DesignationId { get; set; }
        public int WTypeId { get; set; }
        public int EmpType { get; set; }
        public bool IsActive { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public int ValueField { get; set; }
        public string TextField { get; set; }
        public Response response { get; set; }
        public string OrderNO { get; set; }
        public string Orderdate { get; set; }
        public List<InternalTransfer> list { get; set; }

    }
    public class EmployeeTransfer : InternalTransfer
    {
        public int DistrictId { get; set; }
        public int officeTypeId { get; set; }
        public int OfficeName { get; set; }
        public int OfficeId { get; set; }
        public string Transferto { get; set; }
    }
    public class Accept_RollbackEmployee : InternalTransfer
    {
        public int A_Fk_DepartmentId { get; set; }
        public int A_Fk_SubDeptId { get; set; }
        public int A_DesignationId { get; set; }
        public string A_startdate { get; set; }
        public string Type { get; set; }
    }
    #endregion
    public class EmpGIS
    {
        public int ID { get; set; }
        public int WTypeId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int SubDeptID { get; set; }
        public int DepartmentID { get; set; }
        public int Fk_SubDeptId { get; set; }
        public string PFMSCode { get; set; }
        public string DeptEmpCode { get; set; }
        public string SearchEmpName { get; set; }
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string EmpName { get; set; }
        public int DesignationId { get; set; }
        public int preDesignationId { get; set; }
        public int DesignationName { get; set; }
        public string FatherName { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string PermAddress { get; set; }
        public string Address { get; set; }
        public string AdharNo { get; set; }
        public string PANNo { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string DOR { get; set; }
        public string AccountNo { get; set; }
        public string Code { get; set; }
        public string LicNo { get; set; }
        public string LicAmount { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Year { get; set; }
        public int GISId { get; set; }
        public string EndDate { get; set; }
        public int Fk_AccountType { get; set; }
        public string RenewDate { get; set; }
        public string StartYear { get; set; }
        public int StartMonth { get; set; }
        public string Type { get; set; }
        public decimal GISAmount { get; set; }
        public string GISNo { get; set; }
        public int Fk_DistrictId { get; set; }
        public int Fk_CategoryId { get; set; }
        public int EmpCategory { get; set; }
        public int EmpType { get; set; }
        public bool IsActive { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public int ValueField { get; set; }
        public string TextField { get; set; }
        public Response response { get; set; }
        public List<EmpGIS> list { get; set; }

    }

    public class ClearData
    {
        public int ID { get; set; }
        public int Fk_DepartmentId { get; set; }
        public int Fk_SubDeptId { get; set; }
        public string Earnhead { get; set; }
        public string Dedhead { get; set; }
        public Response response { get; set; }
        public List<ClearData> List { get; set; }

    }

    public class PaySlip
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string AccountNo { get; set; }
        public string DptEmpCode { get; set; }
        public string SubDeptName { get; set; }
        public string DepartmentHead { get; set; }
        public string DOJ { get; set; }
        public string DOB { get; set; }
        public string FatherName { get; set; }
        public string DOR { get; set; }
        public string AdharNo { get; set; }
        public string LevelId { get; set; }
        public string UANNo { get; set; }
        public string NPSEmployer { get; set; }
        public string CleaningAllow { get; set; }
        public string ChatvaAllow { get; set; }
        public decimal MiscAllowAmt1 { get; set; }
        public decimal MiscAllowAmt2 { get; set; }
        public decimal MiscAllowAmt3 { get; set; }
        public decimal MiscAllowAmt4 { get; set; }
        public string VehicleAllow { get; set; }
        public string BroomAllow { get; set; }
        public string PenContribution { get; set; }
        public string Penalty { get; set; }
        public string CoOperative { get; set; }
        public string PPF { get; set; }
        public string Penality { get; set; }
        public string Festival { get; set; }
        public string PPFCont { get; set; }
        public string Misc { get; set; }
        public string EOther { get; set; }
        public string ESICEmployer { get; set; }
        public string EPFEmployer { get; set; }
        public string DAAmount { get; set; }
        public string VehicleCharges { get; set; }
        public string BasicSalary { get; set; }
        public string DutyDays { get; set; }
        public string DPPF { get; set; }
        public string EPFEmployee { get; set; }
        public string ESICEmployee { get; set; }
        public string DMisc { get; set; }
        public string EPFCode { get; set; }
        public string GPFCode { get; set; }
        public string GISCode { get; set; }
        public string mobileno { get; set; }


        public string DivisionName { get; set; }
        public string RegionName { get; set; }
        public string Depot { get; set; }
        public string PANNo { get; set; }
        public string PayMonth { get; set; }
        public string PayYear { get; set; }
        public string Designation { get; set; }
        public string BankName { get; set; }
        public string Employement { get; set; }
        public string GPFType { get; set; }
        public string RTGSCode { get; set; }
        public string WorkDays { get; set; }
        public string BasicSal { get; set; }
        public string GradePay { get; set; }
        public string DAPer { get; set; }
        public string DA { get; set; }
        public string HRA { get; set; }
        public string CCA { get; set; }
        public string IR { get; set; }
        public string WA { get; set; }
        public string MA { get; set; }
        public string DepAllow { get; set; }
        public string DisAllow { get; set; }
        public string SpecPay { get; set; }
        public string Traffic { get; set; }
        public string PraPay { get; set; }
        public string PerPay2 { get; set; }
        public string PerPay { get; set; }
        public string QtrRent { get; set; }
        public string CourtReco { get; set; }
        public string IncomeTax { get; set; }
        public string StaffCar { get; set; }
        public string KKF { get; set; }
        public string GIS { get; set; }
        public string LIC { get; set; }
        public string GPF { get; set; }
        public string EPF { get; set; }
        public decimal GrossPay { get; set; }
        public string OtherAllow { get; set; }
        public string CarAllow { get; set; }
        public string BilangAllow { get; set; }
        public string TyreReco { get; set; }
        public string StaffAdv { get; set; }

        public string OtherReco { get; set; }
        public string MiscReco { get; set; }
        public string DieselReco { get; set; }
        public string MobileBill { get; set; }
        public decimal MiscDedAmt1 { get; set; }
        public decimal MiscDedAmt2 { get; set; }
        public decimal MiscDedAmt3 { get; set; }
        public decimal MiscDedAmt4 { get; set; }
        public string PayReco { get; set; }
        public string LapAdv { get; set; }
        public string NPS { get; set; }
        public string HBA { get; set; }
        public string MobileAdv { get; set; }
        public decimal NetPay { get; set; }
        public string GPFAdv { get; set; }
        public string RD { get; set; }
        public string Society { get; set; }
        public string PermReco { get; set; }

        public List<PaySlip> paySlipList { get; set; }
    }
    public class SalarySummary
    {
        public string FromMonth { get; set; }
        public string FromYear { get; set; }
        public string ToMonth { get; set; }
        public string ToYear { get; set; }
        public List<SalarySummary> SalarySummaryList { get; set; }
    }
    public class DAilyWagesEarDed
    {
        public int ID { get; set; }
        public int Fk_SubDeptId { get; set; }
        public int EmpId { get; set; }
        public int DedEmpId { get; set; }
        public int Fk_DepartmentId { get; set; }
        public string SaveUpdate { get; set; }
        public string AscDesc { get; set; }
        public string OrderName { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string BasicSalary { get; set; }
        public string Earning { get; set; }
        public string Deduction { get; set; }
        public string Rate { get; set; }
        public int flag { get; set; }
        public string message { get; set; }

    }
    public class OfficePayment
    {
        public int FinanicalYear { get; set; }
        public string VendorName { get; set; }
        public int GrossPayment { get; set; }
        public int TdsCgst { get; set; }
        public int TdsSgst { get; set; }
        public string PPANo { get; set; }
        public string CheqNo { get; set; }
        public string PaymentDate { get; set; }
        public int PaidAmount { get; set; }
        public string Favouring { get; set; }
        public double TotalDeduction { get; set; }
        public decimal MiscDeductionAmount { get; set; }
        public string MiscDeductionDescription { get; set; }

        public int Flag { get; set; }
        public string message { get; set; }
    }
    public class DAArrear
    {
        public int Id { get; set; }
        public int EMPid { get; set; }
        public int District { get; set; }
        public int ULBType { get; set; }
        public int OfficeType { get; set; }
        public string OfficeName { get; set; }
        public string PFMSCode { get; set; }
        public string EMPName { get; set; }
        public string FatherName { get; set; }
        public string Year { get; set; }
        public string FRYear { get; set; }
        public string TYear { get; set; }
        public string Month { get; set; }
        public int FromMonth { get; set; }
        public int FromYear { get; set; }
        public int ToMonth { get; set; }
        public int ToYear { get; set; }
        public int WorkingType { get; set; }
        public int Department { get; set; }
        public int SubDepartment { get; set; }
        public int EmployeeName { get; set; }
        public int BasicSal { get; set; }
        public int WorkDays { get; set; }
        public int cnt { get; set; }
        public string ULBName { get; set; }
        public string message { get; set; }
        public string ExpenseType { get; set; }
        public string ActionType { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionKey { get; set; }
        public string THead { get; set; }
        public string Head { get; set; }
        public string GrossPay { get; set; }
        public string DesigNo { get; set; }
        public string WType { get; set; }
        public string ComponentCode { get; set; }
        public string AccountNo { get; set; }
        public int DueDA { get; set; }
        public int DrawDA { get; set; }
        public int flag { get; set; }
        public bool ReportFor { get; set; }
        public List<DAArrear> List { get; set; }
        public List<DAArrear> EmpIDList { get; set; }
    }
    public class EmpLeaveDelete
    {
        public string AccountNo { get; set; }
        public string SelectType { get; set; }
        public string fe { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string SalaryType { get; set; }
        public string Value { get; set; }
        public string netpay { get; set; }
        public string grosspay { get; set; }
        public string PFMSCode { get; set; }
        public string Testq { get; set; }
        public string EmpName { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<EmpLeaveDelete> List { get; set; }

    }


    public class Leave
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string WorkingType { get; set; }
        public int Employee { get; set; }
        public string PFMSCode { get; set; }
        public string DeptUniqueCode { get; set; }
        public string Name { get; set; }

        // empdetail
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string ActionType { get; set; }
        public string NoOfDays { get; set; }
        public string Retierdate { get; set; }
        public string Remark { get; set; }
        public string SalaryWeightage { get; set; }
        public string salaryHours { get; set; }
        public string LeaveType { get; set; }
        public string DeathDate { get; set; }
        public int flag { get; set; }
    }
    public class EmpStatus
    {
        public string PFMSCode { get; set; }
        public string MobileNo { get; set; }
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public string EmpName { get; set; }
        public string fathername { get; set; }

        public string OfficeHeadName { get; set; }
        public string OfficeName { get; set; }
        public string SalaryStatus { get; set; }
        public string EmployeeStatus { get; set; }
        public string EOName { get; set; }
        public string EOMobileNo { get; set; }
        public string PayclerkName { get; set; }
        public string PayclerkMobileNo { get; set; }
        public string OptName { get; set; }
        public string OptNo { get; set; }
        public string working { get; set; }
        public List<EmpStatus> EmpStatusList { get; set; }
    }

    public class FrmUnsettleData
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
        public string OrderBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<FrmUnsettleData1> List { get; set; }
    }


    public class FrmUnsettleData1
    {
        public string pfmscode { get; set; }
        public string departmenthead { get; set; }
        public string empname { get; set; }
        public string fathername { get; set; }
        public string DptEmpCode { get; set; }
        public string BasicSalary { get; set; }
        public string LevelID { get; set; }
        public string gradepay { get; set; }
        public string designationname { get; set; }
        public int SubDeptId { get; set; }
        public string OrderBy { get; set; }
        public List<FrmFinalizeData1> EmpStatusList { get; set; }
    }

    public class ExcelForBonus
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
        public string OrderBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<ExcelForBonusList> List { get; set; }
    }
    public class ExcelForBonusList
    {
        public int EmpId { get; set; }
        public string FatherName { get; set; }
        public string EmpName { get; set; }
        public string pfmscode { get; set; }
        public string DPTEmpCode { get; set; }
        public string SubDepartment { get; set; }
        public string Department { get; set; }
        public int FinYear { get; set; }
        public string Remarks { get; set; }
        public string OtherDedAmt { get; set; }
        public string OtherAllAmt { get; set; }
        public string PFStatus { get; set; }
        public string Status { get; set; }
        public string PFAccount { get; set; }
        public string DOJ { get; set; }
        public string DOR { get; set; }
        public string DOB { get; set; } 
    }
}