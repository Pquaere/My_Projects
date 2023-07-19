using Dapper;
using HRPayroll.Models.Manager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayroll.Models.DBRepository
{
    public class AdminDB
    {
        #region
        public List<EmpLeaveRequest> EmployeeLeavelist()
        {
            try
            {
                var queryParameters = new DynamicParameters();
                List<EmpLeaveRequest> objlist = DBHelperDapper.DAAddAndReturnModelList<EmpLeaveRequest>("ApproveDeclineLeaveRequestReport", queryParameters);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmpLeaveRequest Approve_Decline_Leave(EmpLeaveRequest model)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@RequestId", model.RequestId);
                queryParameters.Add("@remark", model.Remark);
                queryParameters.Add("@ApprovedBy", SessionManager.UserId);
                queryParameters.Add("@RejectBy", SessionManager.UserId);
                EmpLeaveRequest objlist = DBHelperDapper.DAAddAndReturnModel<EmpLeaveRequest>("ApproveDeclineLeaveRequest", queryParameters);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        public static Attendances UpdateAttendanceDetail(Attendances model)
        {
            try
            {
                var sqlparam = new DynamicParameters();
                sqlparam.Add("@procId", 2);
                sqlparam.Add("@AttenDate", model.AttendanceDate);
                sqlparam.Add("@XmlData", model.XmlData);
                sqlparam.Add("@CompanyId", SessionManager.CompanyId);
                Attendances _iresult = DBHelperDapper.DAAddAndReturnModel<Attendances>("GetEmployeeForAttendance", sqlparam);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Attendances AttendanceList(Attendances model)
        {
            Attendances _iresult = new Attendances();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("Date", model.AttendanceDate);
                List<Attendances> list = DBHelperDapper.DAAddAndReturnModelList<Attendances>("Fetch_AttendancDetail", queryParameters);
                _iresult.AttendanceList = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dynamic MonthlyAttendance(string month, string year)
        {
            MonthlyAtteReq obj = new MonthlyAtteReq();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    var queryParameter = new DynamicParameters();
                    queryParameter.Add("@monthId", month);
                    queryParameter.Add("@yearId", year);
                    queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                    var redar = con.QueryMultiple("AllEmployeeAttDetails", queryParameter, commandType: System.Data.CommandType.StoredProcedure);
                    var AttendanceList = redar.Read<MonthyAttendances>().ToList();
                    var WeakList = redar.Read<Weakened>().ToList();
                    var Holiday = redar.Read<Holidays>().ToList();
                    var Leave = redar.Read<LeaveApprove>().ToList();

                    obj.listAttendance = AttendanceList;
                    obj.WeakenedList = WeakList;
                    obj.HolidayList = Holiday;
                    obj.LeaveList = Leave;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public static OfficePayment OfficePaymentDetails()
        {

            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@AgencyTypeId", (SessionManager.AgencyTypeId));
                OfficePayment Obj = DBHelperDapper.DAAddAndReturnModel<OfficePayment>("GetOfficePaymentDetails", queryParameters);

                return Obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static OfficePayment SaveOfficePaymentDetails(OfficePayment model)
        {
            try
            {
                var sqlparam = new DynamicParameters();
                sqlparam.Add("@finYear", model.FinanicalYear);
                sqlparam.Add("@VendorName", model.VendorName);
                sqlparam.Add("@GrossPay", model.GrossPayment);
                sqlparam.Add("@TDSCGST", model.TdsCgst);
                sqlparam.Add("@TDSSGST", model.TdsSgst);
                sqlparam.Add("@PPANO", model.PPANo);
                sqlparam.Add("@ChequeNo", model.CheqNo);
                sqlparam.Add("@Chequedt", model.PaymentDate);
                sqlparam.Add("@Amount", model.PaidAmount);
                sqlparam.Add("@Favouring", model.Favouring);
                sqlparam.Add("@MiscDed", model.MiscDeductionAmount);
                sqlparam.Add("@MiscDedDesc", model.MiscDeductionDescription);
                sqlparam.Add("@OfficeId", SessionManager.OfficeID);



                OfficePayment _iresult = DBHelperDapper.DAAddAndReturnModel<OfficePayment>("Insert_OfficePayment", sqlparam);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> BindFinancialYear()
        {
            try
            {
                var queryParameters = new DynamicParameters();

                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Bind_Financial_Year", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<SelectListItem> BindDistrictByOfficeId()
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@officeId", SessionManager.OfficeID);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("GetDistrictByOfficeId", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<SelectListItem> BindDepartmentByWorkingType(int WorkingType)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WorkingType", WorkingType);
                queryParameters.Add("@officeId", SessionManager.OfficeID);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_BindDepartmentByOfficeId", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        } 
        public static List<SelectListItem> BindSubDepartmentByOfficeId(int Department)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Department", Department);
                queryParameters.Add("@officeId", SessionManager.OfficeID);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_BindSubDepartmentByOfficeId", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static List<SelectListItem> BindEmployeeByOfficeId(int SubDepartment)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@SubDepartmentId", SubDepartment);
                queryParameters.Add("@officeId", SessionManager.OfficeID);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("GetEmployeeByOfficeId", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<DAArrear> GetEmployeeDARear(DAArrear model)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                var start = model.FromYear + "-" + model.FromMonth.ToString("00") + "-01";
                var end = model.ToYear + "-" + model.ToMonth.ToString("00") + "-01";
                queryParameters.Add("@DateStart", start);
                queryParameters.Add("@DateEnd", end);
                queryParameters.Add("@Empid", model.EmployeeName);
                queryParameters.Add("@DrawDa", model.DueDA);
                List<DAArrear> objlist = DBHelperDapper.DAAddAndReturnModelList<DAArrear>("sp_getDAArrearList", queryParameters);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<SelectListItem> BindEmployeeByWtfId(int WorkingType)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WorkingType", WorkingType);
                queryParameters.Add("@officeId", SessionManager.OfficeID);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("BindEmployeeByWtf", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Leave GetEmpLeaveDetails(Leave model)
        {
            try
            {
                var sqlparam = new DynamicParameters();

                sqlparam.Add("@DeptId", SessionManager.DepId);
                sqlparam.Add("@officeId", SessionManager.OfficeID);
                sqlparam.Add("@empId", model.Employee);
                sqlparam.Add("@PMFSCode", model.PFMSCode);
                sqlparam.Add("@name", model.Name);
                sqlparam.Add("@empCode", model.DeptUniqueCode);


                Leave _iresult = DBHelperDapper.DAAddAndReturnModel<Leave>("GetEmpLeaveDetails", sqlparam);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static Leave SavfeEmpLeaveRecord(Leave model)
        {
            try
            {
                var sqlparam = new DynamicParameters();

                sqlparam.Add("@EmpId", model.Employee);
                sqlparam.Add("@MonthId", model.Month);
                sqlparam.Add("@YearId", model.Year);
                sqlparam.Add("@Type", model.ActionType);
                sqlparam.Add("@NoofDaysHours", model.salaryHours);
                sqlparam.Add("@SuspendPer", model.SalaryWeightage);
                sqlparam.Add("@OrderNo", model.OrderNo);
                sqlparam.Add("@OrderDate", model.OrderDate);
                sqlparam.Add("@officeid", SessionManager.OfficeID);
                sqlparam.Add("@Remarks", model.Remark);
                if (model.ActionType == "R")
                {
                    sqlparam.Add("@Date", model.Retierdate);
                }
                else
                {
                    sqlparam.Add("@Date", model.DeathDate);
                }
                //sqlparam.Add("@SWeight", model.Employee);
                sqlparam.Add("@DOR", model.Retierdate);
                sqlparam.Add("@DOD", model.DeathDate);
                


                Leave _iresult = DBHelperDapper.DAAddAndReturnModel<Leave>("SP_Empleavesuspend", sqlparam);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> BindDepartmentForLoan (int Year, int Month, int EmpType,int Department, int SubDepartment, int EmployeeID, int empCategory)
        {
            try
            {
                List<SelectListItem> _Iresult =new List<SelectListItem>();
                var queryParameters = new DynamicParameters();
                if (empCategory == 1)
                {
                    queryParameters.Add("ProcId",1);
                    queryParameters.Add("Month", Month);
                    queryParameters.Add("Year", Year);
                    queryParameters.Add("OfficeId", SessionManager.OfficeID);
                    queryParameters.Add("UserId", SessionManager.UserId);
                    queryParameters.Add("DepartmentId", SessionManager.DepId);
                    queryParameters.Add("SubDeptId", 0);
                    queryParameters.Add("WTypeId", empCategory);
                    queryParameters.Add("EmployementId", EmpType);
                    _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Proc_GetFillDropDownFrmPayRegister", queryParameters);
                }
                else if(empCategory == 2)
                {
                    queryParameters.Add("ProcId", 5);
                    queryParameters.Add("Month", Month);
                    queryParameters.Add("Year", Year);
                    queryParameters.Add("OfficeId", SessionManager.OfficeID);
                    queryParameters.Add("UserId", SessionManager.UserId);
                    queryParameters.Add("DepartmentId", SessionManager.DepId);
                    _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Proc_GetFillDropDown", queryParameters);

                }
                else if (empCategory == 4)
                {
                    queryParameters.Add("ProcId", 6);
                    queryParameters.Add("Month", Month);
                    queryParameters.Add("Year", Year);
                    queryParameters.Add("OfficeId", SessionManager.OfficeID);
                    queryParameters.Add("UserId", SessionManager.UserId);
                    queryParameters.Add("DepartmentId", SessionManager.DepId);
                     _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Proc_GetFillDropDown", queryParameters);
                }
                else
                {

                }      
                return _Iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> BindSubDepartmentForLoan(int Year, int Month, int EmpType, int Department, int SubDepartment, int EmployeeID, int empCategory)
        {
            try
            {
                List<SelectListItem> _Iresult = new List<SelectListItem>();
                var queryParameters = new DynamicParameters();
                if (empCategory == 1)
                {
                    queryParameters.Add("ProcId", 2);
                }
                if (empCategory == 2)
                {
                    queryParameters.Add("ProcId", 4);

                }
                    queryParameters.Add("Month", Month);
                    queryParameters.Add("Year", Year);
                    queryParameters.Add("OfficeId", SessionManager.OfficeID);
                    queryParameters.Add("UserId", SessionManager.UserId);
                    queryParameters.Add("DepartmentId", Department);
                    queryParameters.Add("SubDeptId", 0);
                    queryParameters.Add("WTypeId", empCategory);
                    queryParameters.Add("EmployementId", EmpType);
                    _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Proc_GetFillDropDownFrmPayRegister", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<SelectListItem> BindEmpForLoan(int Year, int Month, int EmpType, int Department, int SubDepartment, int EmployeeID, int empCategory)
        {
            try
            {
                List<SelectListItem> _Iresult = new List<SelectListItem>();
                var queryParameters = new DynamicParameters();
                if (empCategory == 1)
                {
                    queryParameters.Add("ProcId", 3);
                    queryParameters.Add("Month", Month);
                    queryParameters.Add("Year", Year);
                    queryParameters.Add("OfficeId", SessionManager.OfficeID);
                    queryParameters.Add("UserId", SessionManager.UserId);
                    queryParameters.Add("DepartmentId", Department);
                    queryParameters.Add("SubDeptId", SubDepartment);
                    queryParameters.Add("WTypeId", empCategory);
                    queryParameters.Add("EmployementId", EmpType);
                    _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Proc_GetFillDropDownFrmPayRegister", queryParameters);
                }
               
               
                return _Iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region user_registeration
        public static List<SelectListItem> BindDesignationOfficer()
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@AgencyTypeId", SessionManager.AgencyTypeId);


                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("BindDesignation", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<SelectListItem> BindDesignationStaff()
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@AgencyTypeId", SessionManager.AgencyTypeId);


                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("BindDesignation1", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public User SaveUser(User model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@UserName", model.UserName);
                queryParameter.Add("@Password", model.Password);
                queryParameter.Add("@DesignationId", model.DesignationId);               
                queryParameter.Add("@UTypeId", model.UTypeId);
                queryParameter.Add("@WTypeId", model.WTypeId);
                queryParameter.Add("@OfficeId", model.OfficeId);
                queryParameter.Add("@CircleId", model.CircleId);
                queryParameter.Add("@PayclerkName", model.PayclerkName);
                queryParameter.Add("@PayclerkMobileNo", model.PayclerkMobileNo);
                queryParameter.Add("@EOName", model.EOName);
                queryParameter.Add("@EOMobileNo", model.EOMobileNo);
                queryParameter.Add("@EmailId", model.EmailId);
                queryParameter.Add("@Status", "F");
                queryParameter.Add("@Departments", model.Departments);
                var res = DBHelperDapper.DAAddAndReturnModel<User>("SP_User_Insert", queryParameter);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static List<SelectListItem> GetDepartmentforcheckbox(int officeId)
        {
            try
            {
                var parnm = new DynamicParameters();
                parnm.Add("@ProcId", 1);
                //parnm.Add("@Department", SessionManager.DepId);
                //parnm.Add("@Worktypeid", SessionManager.WTypeId);
                parnm.Add("@Department", "0");
                parnm.Add("@Worktypeid", 0);
                parnm.Add("@OfficeId", officeId);
                //parnm.Add("@Department", 9019);
                //parnm.Add("@Worktypeid", 1);
                //parnm.Add("@OfficeId", 9);
                List<SelectListItem> _result = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("[Proc_GetDepartmentAndOthers]", parnm);
                return _result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<User> UserList(User model)
        {
            try
            {
                var queryParameters = new DynamicParameters();
            
                queryParameters.Add("@circleId", model.CircleId);
                queryParameters.Add("@WtypeId", model.WTypeId);
                queryParameters.Add("@userName", model.UserName);
                List<User> objlist = DBHelperDapper.DAAddAndReturnModelList<User>("GetUsers", queryParameters);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static List<SelectListItem> GetDepartmentforcheckbox(int OfficeId)
        //{
        //    try
        //    {
        //        var parnm = new DynamicParameters();
        //        parnm.Add("@ProcId", 1);
        //        parnm.Add("@Department", '0');
        //        parnm.Add("@Worktypeid", 0);
        //        parnm.Add("@OfficeId", OfficeId);
        //        //parnm.Add("@Department", 9019);
        //        //parnm.Add("@Worktypeid", 1);
        //        //parnm.Add("@OfficeId", 9);
        //        List<SelectListItem> _result = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("[Proc_GetDepartmentAndOthers]", parnm);
        //        return _result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion
    }
}