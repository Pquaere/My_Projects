using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace HRPayroll.Models
{
    public class MasterModel
    {
    }
    public class Role
    {
        public int ID { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Role> rolelist { get; set; }
    }

    public class FormType
    {
        public int ID { get; set; }
        public int FormTypeId { get; set; }
        public string FormTypeName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<FormType> list { get; set; }
    }

    public class Form
    {
        public int ID { get; set; }
        public int FormId { get; set; }
        public int FK_FormTypeId { get; set; }
        public string FormName { get; set; }
        public string FormTypeName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Form> formlist { get; set; }
    }

    public class State
    {
        public int ID { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<State> statelist { get; set; }
    }

    public class District
    {
        public int ID { get; set; }
        public int DistrictId { get; set; }
        public int FK_StateId { get; set; }
        public string DistrictName { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<District> List { get; set; }
    }

    public class Office
    {
        public int ID { get; set; }
        public int OfficeId { get; set; }
        public int FK_DistrictId { get; set; }
        public string OfficeName { get; set; }
        public string DistrictName { get; set; }
        public string AgencyCode { get; set; }
        public int FK_AgencyTypeID { get; set; }
        public string AgencyType { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Office> officeList { get; set; }
    }

    public class Circle
    {
        public int ID { get; set; }
        public int CircleId { get; set; }
        public string CircleName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Circle> circlelist { get; set; }
    }

    public class Bank
    {
        public int ID { get; set; }
        public string BankName { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Bank> List { get; set; }
    }

    public class Agency
    {
        public int ID { get; set; }
        public string AgencyType { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Agency> List { get; set; }
    }


    public class Brands
    {
        public int ID { get; set; }
        public int Fk_CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public bool IsDeleted { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Brands> List { get; set; }
    }

    public class CategoryModel
    {
        public int ID { get; set; }
        public int PreferenceOrder { get; set; }
        public string CategoryName { get; set; }
        public string Images { get; set; }
        public bool IsDeleted { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<CategoryModel> List { get; set; }
    }

    public class HolidayTypes
    {
        public int ID { get; set; }
        public string HolidayType { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<HolidayTypes> List { get; set; }
    }

    public class LeaveTypes
    {
        public int ID { get; set; }
        public string LeaveType { get; set; }
        public string LeaveDesc { get; set; }
        public bool Payable { get; set; }
        public bool IsActive { get; set; }
        public bool carryforward { get; set; }
        public string message { get; set; }
        public string noofdays { get; set; }
        public int carry { get; set; }
        public int show { get; set; }
        public int value { get; set; }
        public Response response { get; set; }
        public List<LeaveTypes> List { get; set; }

    }

    public class Bonus
    {
        public int ID { get; set; }
        public int LevelId { get; set; }
        public string EffectiveDate { get; set; }
        public string LevelName { get; set; }
        public string BonusAmt { get; set; }
        public string CashPer { get; set; }
        public string PFPer { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Bonus> List { get; set; }
    }

    public class Branch
    {
        public int ID { get; set; }
        public int Fk_BankId { get; set; }
        public int Fk_DistrictId { get; set; }
        public int Fk_StateId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddr { get; set; }
        public string RTGSCode { get; set; }
        public string Contactno { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string BankName { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Branch> List { get; set; }
    }

    public class Department
    {
        public int ID { get; set; }
        public int UserTypeId { get; set; }
        public int OfficeId { get; set; }
        public int WorkTypeId { get; set; }
        public string DepartmentHead { get; set; }
        public string OfficeName { get; set; }
        public string Code { get; set; }
        public string WorkingType { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Department> List { get; set; }
    }

    public class Activitie
    {
        public int ID { get; set; }
        public string Tittle { get; set; }
        public string Mobile { get; set; }
        public string DueDate { get; set; }
        public string ActivityType { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string AssignTo { get; set; }
        public string ContactPerson { get; set; }
        public bool IsActivity { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Activitie> List { get; set; }
    }

    public class SubDepartment
    {
        public int ID { get; set; }
        public int Fk_DepartmentId { get; set; }
        public string Code { get; set; }
        public string DepartmentHead { get; set; }
        public string SubDeptName { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<SubDepartment> List { get; set; }
    }

    public class Employements
    {
        public int ID { get; set; }
        public int WTypeId { get; set; }
        public string Employement { get; set; }
        public string WorkingType { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Employements> List { get; set; }
    }

    public class Response
    {
        public int flag { get; set; }
        public string message { get; set; }
    }

    public class Desigation
    {

        public int DesignationId { get; set; }
        [Required]
        public string DesignationName { get; set; }
        [Required]
        public string Code { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public int IsActive { get; set; }

        public long UserId { get; set; }

        public List<Desigation> Desigationlist { get; set; }

    }

    public class FixedAllowances
    {
        public int Id { get; set; }
        public string PayComissionId { get; set; }
        public string GradePayId { get; set; }
        public string CircleId { get; set; }
        public string MA { get; set; }
        public string WA { get; set; }
        public string CCA { get; set; }
        public string HRA { get; set; }
        public string Status { get; set; }
        public string EffectiveDate { get; set; }
        public List<FixedAllowances> FixedAllowancesList { get; set; }
    }

    public class DAPercent
    {
        public int PayComId { get; set; }
        public int ID { get; set; }
        public int EmpCategory { get; set; }
        public decimal DA_Percent { get; set; }
        public string Date { get; set; }
        public string Date1 { get; set; }
        public string PayCommision { get; set; }
        public int flag { get; set; }
        public int IsActive { get; set; }
        public string message { get; set; }
        public List<DAPercent> DAPercent_List { get; set; }
    }

    public class fixallowance
    {
        public int ID { get; set; }
        public int CircleId { get; set; }
        public int PayComId { get; set; }
        public int GradepayId { get; set; }
        public int flag { get; set; }
        public int IsActive { get; set; }
        public string message { get; set; }
        public decimal WA { get; set; }
        public decimal HRA { get; set; }
        public string CircleName { get; set; }
        public string PayCommision { get; set; }
        public string GradePay { get; set; }
        public decimal MA { get; set; }
        public string EffectivFromDate { get; set; }
        public string EffectivFromDate1 { get; set; }
        public List<fixallowance> fixallowance_List { get; set; }
    }

    public class Holiday
    {
        public int ID { get; set; }
        public int flag { get; set; }
        public int IsActive { get; set; }
        public string message { get; set; }
        public string Title { get; set; }
        public string HolidayDate { get; set; }
        public string HolidayImage { get; set; }
        public string HolidayType { get; set; }
        public string HolidayDate1 { get; set; }
        public int HolidayTypeId { get; set; }
        public List<Holiday> HolidayList { get; set; }
        public List<officelist1> OfficeList { get; set; }

    }

    public class officelist1
    {
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public bool Checked { get; set; }
    }

    public class ServiceType
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public int officeTypeId { get; set; }
        public int OfficeName { get; set; }
        public string ServiceName { get; set; }
        public int officeId { get; set; }
        // Permanent Employees
        public decimal PPenCont { get; set; }
        public decimal PPPFCont { get; set; }
        public decimal PNPSEmployer { get; set; }
        public decimal PNPSEmployee { get; set; }
        //Contractual Employees
        public decimal SEPFEmployee { get; set; }
        public decimal SEPFEmployer { get; set; }
        public decimal SESICEmployee { get; set; }
        public decimal SESICEmployer { get; set; }
        public decimal SPPFCont { get; set; }
        public decimal SDAPercent { get; set; }
        public decimal SPFPercent { get; set; }
        //End
        public int PayComId { get; set; }
        public string ActiveDate { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public int IsActive { get; set; }
        public int SesofficeName { get; set; }
        public List<ServiceType> ServiceTypeList { get; set; }
    }

    public class LeaveRequest
    {
        public int ID { get; set; }
        public int FK_EmployeeType { get; set; }
        public int Fk_AssignLeaveId { get; set; }
        public int Designation { get; set; }
        public int Year { get; set; }
        public int LeaveCategory { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<LeaveTypes> LeaveTypes { get; set; }
        public List<LeaveRequest> LeaveList { get; set; }
        public IEnumerable<LeaveTypes> ArrayLeave { get; set; }
        public string xmlData { get; set; }
        public string DesignationName { get; set; }
        public string LeaveCategoryName { get; set; }
        public string EmpCategory { get; set; }
        public string TotalLeave { get; set; }
        public string FnYear { get; set; }
        public string Fy_Full { get; set; }
        public string Date { get; set; }
        public string TotalRecords { get; set; }
    }

    public class EmpReg
    {
        public int EId { get; set; }
        public int EmpCategory { get; set; }
        public int EmpType { get; set; }
        public int UserId { get; set; }

        //Personal Details
        public string EmpName { get; set; }
        public string EmpFatherName { get; set; }
        public string EmpGender { get; set; }
        public string EmpQualification { get; set; }
        public int EmpReligion { get; set; }
        public int EmpBloodGroup { get; set; }
        public int EmpHomeState { get; set; }
        public string EmpMartialStatus { get; set; }
        public string EmpDob { get; set; }
        public int EmpHomeDistrict { get; set; }
        public int EmpCaste { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpPeramanentAddress { get; set; }
        public string EmpMob { get; set; }
        public string EmpContactNo { get; set; }
        public string EmpPostalAddress { get; set; }
        public string EmpAadharNumber { get; set; }
        public string EmpDepartmentalEmployeeCode { get; set; }
        public string Profile { get; set; }
        public string hbdnProfile { get; set; }
        public int office { get; set; }
        public int ReportinPerson { get; set; }
        //Departmental Details

        public string DeptPFMsVendor { get; set; }
        public string DeptDateOfJoiningInService { get; set; }
        public string DeptDateOfJoiningInULB { get; set; }
        public int DeptClassCategory { get; set; }
        public int DeptDepartment { get; set; }
        public int DeptSubDepartment { get; set; }
        public int DeptPaymentHead { get; set; }
        public int DeptModeOfRecruitment { get; set; }
        public int DeptSpecialServiceQuota { get; set; }
        public int DeptDesignation { get; set; }
        public int DeptMonthofIncrement { get; set; }

        //Bank Detail

        public string BIFSC { get; set; }
        public int BBank { get; set; }
        public string BAccountNumber { get; set; }
        public string BPanNumber { get; set; }

        //Salary Details
        public string SStatus { get; set; }
        public int SPayCommisson { get; set; }
        public int SGradePay { get; set; }
        public int SPayScale { get; set; }
        public int SLevel { get; set; }
        public int SIncrement { get; set; }
        public int SBasicSalary { get; set; }
        public int SAllowedFixedAllowence { get; set; }
        public string MA { get; set; }
        public string WA { get; set; }
        public string HRA { get; set; }
        public string IsNps { get; set; }
        public decimal BasicDA { get; set; }
        public decimal Basic { get; set; }
        public string EPF { get; set; }
        public string ESIC { get; set; }


        //OtherDetails
        public string ONPSAccount { get; set; }
        public string ONomineeName { get; set; }
        public int ONomineeRelation { get; set; }
        public string OGISAccountNumber { get; set; }
        public string IsFinalizedData { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string AuthorisedSignatory { get; set; }
        public int GpfType { get; set; }
        public string GPFACNo { get; set; }
        public string UANNO { get; set; }
        public string GISACNo { get; set; }
        public string EPFACNo { get; set; }
        public string ESICACNo { get; set; }
        public string EStatus { get; set; }
        public string ContractValidity { get; set; }
        public int CasEmp { get; set; }
        public string FixedDeduction { get; set; }
        public int salaryweightage { get; set; }
        public string DateOfDeath { get; set; }
        public int flag { get; set; }
        public string message { get; set; }

        public string IsLock { get; set; }
        public int QueryEmpType { get; set; }

    }

    public class ListEmpReg
    {
        public int EmpId { get; set; }
        public string EmpType { get; set; }
        public string WorkingType { get; set; }
        public char IsLock { get; set; }
        public string DepartmentHead { get; set; }
        public string SubDeptName { get; set; }
        public string PFMSCODE { get; set; }
        public string EmPName { get; set; }
        public string FatherName { get; set; }
        public string DesignationName { get; set; }
        public string RecruitMode { get; set; }
        public string QuotaName { get; set; }
        public string BankName { get; set; }
        public string RTGSCode { get; set; }
        public string AccountNo { get; set; }
        public string PANNo { get; set; }
        public string BasicSalary { get; set; }

        //fro searching

        public int EmpCategory { get; set; }
        public int EmpployeType { get; set; }
        public int Department { get; set; }
        public int SubDepartment { get; set; }
        public int Designation { get; set; }
        public string EmpCode { get; set; }

        public List<ListEmpReg> lst { get; set; }

    }

    public class SubCategory
    {
        public int ID { get; set; }
        public int SubCategoryId { get; set; }
        public int FK_CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int AddedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<SubCategory> clist { get; set; }
    }

    public class Unit
    {
        public int ID { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Unit> unitlist { get; set; }
    }

    public class Product
    {
        public int ID { get; set;  }
        public int FK_BrandId { get; set;  }
        public int FK_UnitID { get; set;  }
        public int FK_CategoryID { get; set;  }
        public string ProductName { get; set;  }
        public string ProductCode { get; set;  }
        public string ProductImage { get; set;  }
        public string Description { get; set;  }
        public string MetaTitle { get; set;  }
        public string MetaKeyword { get; set;  }
        public string MetaDescription { get; set;  }
        public int MinimumQuantity { get; set;  }
        public string ProductFeature { get; set;  }
        public string HSNCode { get; set;  }
        public decimal MRP { get; set;  }
        public decimal SalePrice { get; set;  }
        public decimal SGST { get; set;  }
        public decimal CGST { get; set;  }
        public decimal IGST { get; set;  }
        public string BV { get; set;  }
        public string PV { get; set;  }
        public List<Product> ProductList { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public bool IsActive { get; set; }
    }
 
    public class Size
    {
        public int ID { get; set; }
        public string SizeName { get; set; }
        public string UnitName { get; set; }
        public int FK_UnitID { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public bool IsActive { get; set; }
        public List<Size> SizeList { get; set; }
    }

    public class EmpLeaveRequest
    {
        public int ID { get; set; }
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public int LeaveTypeId { get; set; }
        public int NoofDays { get; set; }
        public string FromDate { get; set; }
        public string Status { get; set; }
        public string ToDate { get; set; }
        public string AppliedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string ReportingPersonReply { get; set; }
        public string DeclinedBy { get; set; }
        public string RecommendedBy { get; set; }
        public string Description { get; set; }
        public string LeaveToStatus { get; set; }
        public string LeaveFromStatus { get; set; }
        public int flag { get; set; }
        public string msg { get; set; }
        public List<EmpLeaveRequest> EmployeeListForLeave { get; set; }

    }

    public class OfficeTime
    {
        public int ID { get; set; }
        public int OfficeTimeId { get; set; }
        public int Fk_OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string LunchTime { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<OfficeTime> List { get; set; }
    }

    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyAppLogo { get; set; }
        public string Address { get; set; }
        public string OwnerName { get; set; }
        public string OwnerMobileNo { get; set; }
        public string TelephoneNo { get; set; }
        public string EmailId { get; set; }
        public string GSTNo { get; set; }
        public string PanNumber { get; set; }
        public string Password { get; set; }
        public string AlternateMobile { get; set; }
        public string TanNumber { get; set; }
        public string StateId { get; set; }
        public string checkday { get; set; }
        public string DistrictId { get; set; }
        public string PinCode { get; set; }
        public string Themecolor { get; set; }
        public string Leadcode { get; set; }
        public string HrEmailId { get; set; }
        public int flag { get; set; }
        public int IsActive { get; set; }
        public string message { get; set; }
        public List<Company> CompanyList { get; set; }
        public List<string> WeekoffDay { get; set; }
    }

    public class Gradepay
    {
        public int ID { get; set; }
        public int GradePayId { get; set; }
        public string GradePay { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Gradepay> paylist { get; set; }
    }

    public class Headcode
    {
        public int ID { get; set; }
        public int HeadId { get; set; }
        public string HeadCode { get; set; }
        public string HeadName { get; set; }
        public int FK_OfficeId { get; set; }
        public string OfficeName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Headcode> list { get; set; }
    }

    public class EmpCategory
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<EmpCategory> list { get; set; }
    }

    public class ServiceQuota
    {
        public int ID { get; set; }
        public int QuotaId { get; set; }
        public string QuotaName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<ServiceQuota> list { get; set; }
    }

    public class Mandal
    {
        public int ID { get; set; }
        public int MandalId { get; set; }
        public string MandalName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Mandal> Mlist { get; set; }
    }

    public class Division
    {
        public int ID { get; set; }
        public int DivisionId { get; set; }
        public int FK_MandalId { get; set; }
        public string DivisionName { get; set; }
        public string MandalName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Division> List { get; set; }
    }

    public class Comission
    {
        public int ID { get; set; }
        public int ComissionId { get; set; }
        public string ComissionName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Comission> list { get; set; }
    }

    public class PayComission
    {
        public int ID { get; set; }
        public int LevelId { get; set; }
        public int PayComissionId { get; set; }
        public string PayComissionName { get; set; }
        public int GradePay { get; set; }
        public string Level { get; set; }
        public int Increment { get; set; }
        public string Basic { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<PayComission> list { get; set; }
    }
}