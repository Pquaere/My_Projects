using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayroll.Models
{
    public class AdminModel
    {
    }
    public class Attendances
    {
        public int ID { get; set; }
        public int EmpId { get; set; }
        public string WorkingType { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string AttendanceDate { get; set; }
        public IEnumerable<Attendances> EmpList { get; set; }
        public string XmlData { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public string response { get; set; }
        public List<Attendances> AttendanceList { get; set; }
    }

    public class MonthlyAtteReq
    {
        public int ID { get; set; }
        public int monthId { get; set; }
        public int Year { get; set; }
        public List<MonthyAttendances> listAttendance { get; set; }
        public List<Weakened> WeakenedList { get; set; }
        public List<Holidays> HolidayList { get; set; }
        public List<LeaveApprove> LeaveList { get; set; }
    }

    public class MonthyAttendances
    {
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
    }

    public class Holidays
    {
        public string HolidayName { get; set; }
        public string HolidayDate { get; set; }
        
    }

    public class Weakened
    {
        public string weakeneddate { get; set; }
        public string weakenednumber { get; set; }
    }

    public class LeaveApprove
    {
        public string EmpCode { get; set; }
        public string date { get; set; }
    }

    #region user_registration 
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int DesignationId { get; set; }
        public int UTypeId { get; set; }
        public int WTypeId { get; set; }
        public int OfficeId { get; set; }
        public int CircleId { get; set; }
        public int DistrictId { get; set; }
        public int officeTypeId { get; set; }
        public string EOName { get; set; }
        public string EOMobileNo { get; set; }
        public string PayclerkName { get; set; }
        public string PayclerkMobileNo { get; set; }
        public string EmailId { get; set; }
        public string Departments { get; set; }
        public string OfficeName { get; set; }
        public string WorkingType { get; set; }
        public List<string> DepartmentsLst { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<SelectListItem> mapdept { get; set; }
        public List<User> UList { get; set; }
    }
    #endregion

}