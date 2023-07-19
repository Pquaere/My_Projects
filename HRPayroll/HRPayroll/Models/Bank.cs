using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRPayroll.Models
{
    public class Bank
    {
        public int ID { get; set; }
        public string BankName { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Bank> List { get; set; }
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
        public int WorkTypeId { get; set; }
        public string DepartmentHead { get; set; }
        public string Code { get; set; }
        public string WorkingType { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public List<Department> List { get; set; }
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



    public class Response
    {
        public int flag { get; set; }
        public string message { get; set; }
    }
}