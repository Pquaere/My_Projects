using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static HRPayroll.Models.Common;

namespace HRPayroll.Models
{
    public class ResponseType
    {
        public static string Success { get { return "success"; } }
        public static string Warning { get { return "warning"; } }
        public static string Error { get { return "error"; } }
        public static string Info { get { return "info"; } }
    }
    public class AccountType
    {
        public int AC_Type_Id { get; set; }
        public int Company_Id { get; set; }

        [Required(ErrorMessage ="Account name is required field")]
        public string AC_Name { get; set; }
        public string Comments { get; set; }
        public int flag { get; set; }
        public string msg { get; set; }
        public Pager Pager { get; set; }       
        public int? Page { get; set; }
        public int Size { get; set; }
        public List<AccountTypeList> list { get; set; }
    }

    public class AccountTypeList
    {
        public int AC_Type_Id { get; set; }
        public int Company_Id { get; set; }
        public string AC_Name { get; set; }
        public string Comments { get; set; }
        public int TotalRecord { get; set; }
    }

    public class VoucherTypes
    {
        public int Voucher_Type_Id { get; set; }
        public int Company_Id { get; set; }
        public string Voucher_Title { get; set; }
        public string Start_Number { get; set; }
        public string Prefix { get; set; }
        public int FY_Id { get; set; }
        public string Nature { get; set; }
        public int flag { get; set; }
        public string msg { get; set; }
        public Pager Pager { get; set; }
        public int? Page { get; set; }
        public int Size { get; set; }
        public List<VoucherTypesList> list { get; set; }
    }

    public class VoucherTypesList
    {
        public int Voucher_Type_Id { get; set; }
        public int Company_Id { get; set; }
        public string Voucher_Title { get; set; }
        public string Start_Number { get; set; }
        public string Prefix { get; set; }
        public int FY_Id { get; set; }
        public string Nature { get; set; }
        public string Fy_Full { get; set; }
        public int TotalRecord { get; set; }
    }

    public class FinancialYear
    {
        public int Id { get; set; }
        public int Company_Id { get; set; }
        public string Fy_Full { get; set; }
        public string Fy_Short { get; set; }
        public string Start_From { get; set; }
        public string End_On { get; set; }
        public int flag { get; set; }
        public string msg { get; set; }
        public Pager Pager { get; set; }
        public int? Page { get; set; }
        public int Size { get; set; }
        public List<FinancialYearList> list { get; set; }
    }

    public class FinancialYearList
    {
        public int Id { get; set; }
        public int Company_Id { get; set; }
        public string Fy_Full { get; set; }
        public string Fy_Short { get; set; }
        public string Start_From { get; set; }
        public string End_On { get; set; }
        public int TotalRecord { get; set; }
    }

    public class AccountGroup
    {
        public int Group_Id { get; set; }
        public string Account_Group_Name { get; set; }
        public string Nature { get; set; }
        public string Remarks { get; set; }
        public int Account_Perent_Group_Id { get; set; }
        public int Ac_Type_Id { get; set; }
        public int IsActive { get; set; }
        public int Is_Primary_Group { get; set; }
        public int Is_Reserved { get; set; }
        public int Group_Level { get; set; }
        public int Instansable { get; set; }
        public int Created_By { get; set; }
        public int flag { get; set; }
        public string msg { get; set; }
        public Pager Pager { get; set; }
        public int? Page { get; set; }
        public int Size { get; set; }
        public List<AccountGroupList> list { get; set; }
    }

    public class AccountGroupList
    {
        public int Group_Id { get; set; }
        public string Account_Group_Name { get; set; }
        public string Account_Perent_Group_Name { get; set; }
        public string Nature { get; set; }
        public string Remarks { get; set; }
        public int Account_Perent_Group_Id { get; set; }
        public int Ac_Type_Id { get; set; }
        public int IsActive { get; set; }
        public int Is_Primary_Group { get; set; }
        public int Is_Reserved { get; set; }
        public int Group_Level { get; set; }
        public int Instansable { get; set; }
        public int Created_By { get; set; }
        public string AC_Name { get; set; }
        public int TotalRecord { get; set; }
    }

    public class AccountLedger
    {
        public int Ledger_Id { get; set; }
        public string Ledger_Name { get; set; }
        public int Account_Perent_Group_Id { get; set; }
        public string Account_Group_Name { get; set; }
        public string Current_Balance { get; set; }
        public string CR_DR { get; set; }
        public int Fy_Id { get; set; }
        public string Fy_Full { get; set; }
        public int Is_Reserved { get; set; }
        public string Nature { get; set; }
        public string Account_Type { get; set; }
        public string Depreciation { get; set; }
        public int CU_VN_Id { get; set; }
        public int Is_Addinlist { get; set; }
        public int Emp_Id { get; set; }
        public int Company_Id { get; set; }
        public int Created_By { get; set; }
        public int flag { get; set; }
        public string msg { get; set; }
        public Pager Pager { get; set; }
        public int? Page { get; set; }
        public int Size { get; set; }
        public List<AccountLedgerList> list { get; set; }
    }

    public class AccountLedgerList
    {
        public int Ledger_Id { get; set; }
        public string Ledger_Name { get; set; }
        public int Account_Perent_Group_Id { get; set; }
        public string Account_Group_Name { get; set; }
        public string Current_Balance { get; set; }
        public string CR_DR { get; set; }
        public int Fy_Id { get; set; }
        public string Fy_Full { get; set; }
        public int Is_Reserved { get; set; }
        public string Nature { get; set; }
        public string Account_Type { get; set; }
        public string Depreciation { get; set; }
        public int CU_VN_Id { get; set; }
        public int Is_Addinlist { get; set; }
        public int Emp_Id { get; set; }
        public int Company_Id { get; set; }
        public int TotalRecord { get; set; }
    }

    public class EmpLogin
    {
        public int EmpId { get; set; }
        public int UserId { get; set; }
        public int FK_AgencyTypeId { get; set; }
        public int DivisionId { get; set; }
        public int Officeid { get; set; }
        public int UTypeId { get; set; }
        public int WTypeId { get; set; }
        public int DepId { get; set; }
        public int CircleId { get; set; }
        public string UserType { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        public string UserName { get; set; }
        public string OfficeName { get; set; }
        public string WorkingType { get; set; }
        public string PayclerkName { get; set; }
        public string PayclerkMobileNo { get; set; }
        public string EOName { get; set; }
        public string EOMobileNo { get; set; }
        public string OptName { get; set; }
        public string OptNo { get; set; }
        [Required(ErrorMessage = "Please Enter EmailId")]
        public string EmailId { get; set; }
        public string message { get; set; }
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string EmpCode { get; set; }
        public string Dob { get; set; }
        public int CompanyId { get; set; }
        public int ReportingPerson { get; set; }
        public int flag { get; set; }
    }



}