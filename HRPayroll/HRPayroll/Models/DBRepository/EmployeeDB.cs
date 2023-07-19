using Dapper;
using HRPayroll.Models.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayroll.Models.DBRepository
{
    public class EmployeeDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();

        public static EmployeePF AddPFGPFAcc(EmployeePF model)
        {
            EmployeePF _iresult = new EmployeePF();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Fk_EmpId", model.Fk_EmpId);
                queryParameters.Add("@TypeId", model.TypeId);
                queryParameters.Add("@IFSC", model.IFSC);
                queryParameters.Add("@FK_BankId", model.FK_BankId);
                queryParameters.Add("@PAccountNo", model.PAccountNo);
                queryParameters.Add("@CAccountNo", model.CAccountNo);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_PFGPFAccount", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EmployeePF AddEmpLeave(EmployeePF model)
        {
            EmployeePF _iresult = new EmployeePF();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpId", model.Fk_EmpId);
                queryParameters.Add("@MonthId", model.monthId);
                queryParameters.Add("@YearId", model.Year);
                //queryParameters.Add("@Type", model.STypeId);
                queryParameters.Add("@YearId", model.Year);
                queryParameters.Add("@Type", model.STypeId);

                //if (model.STypeId == "S")
                //{
                //    queryParameters.Add("@SWeight", model.WTypeId);
                //}
                if (model.STypeId == "H")
                {
                    queryParameters.Add("@NoofDaysHours", model.Hours);
                }
                if (model.STypeId == "R")
                {
                    queryParameters.Add("@DOR", model.DateOfRetire);
                }
                if (model.STypeId == "D")
                {
                    queryParameters.Add("@DOD", model.DateOfDeath);
                }
                if (model.STypeId == "L" || model.STypeId == "P" || model.STypeId == "A" || model.STypeId == "U")
                {
                    queryParameters.Add("@NoofDaysHours", model.NoOfDays);
                }
                else
                {
                    queryParameters.Add("@NoofDaysHours", model.NoOfDays);
                }
                queryParameters.Add("@SuspendPer", model.SuspendPer);
                queryParameters.Add("@OrderNo", model.OrderNo);
                queryParameters.Add("@OrderDate", model.OrderDate);
                queryParameters.Add("@Remarks", model.Remark);
                queryParameters.Add("@officeid", SessionManager.OfficeID);
                //queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                //queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SP_Empleavesuspend", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EmployeePF UpdatePFGPFAcc(EmployeePF model)
        {
            EmployeePF _iresult = new EmployeePF();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Fk_EmpId", model.Fk_EmpId);
                queryParameters.Add("@TypeId", model.TypeId);
                queryParameters.Add("@IFSC", model.IFSC);
                queryParameters.Add("@FK_BankId", model.FK_BankId);
                queryParameters.Add("@PAccountNo", model.PAccountNo);
                queryParameters.Add("@CAccountNo", model.CAccountNo);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", model.ID);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Update_PFGPFAccount", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EmployeePF UpdateEmpSalary(EmployeePF model)
        {
            EmployeePF _iresult = new EmployeePF();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PayCommision", model.CommssionId);
                queryParameters.Add("@PayScale", model.PayScaleID);
                queryParameters.Add("@SalStatus", model.SalaryStatus);
                queryParameters.Add("@GradePay", model.GradePayId);
                queryParameters.Add("@BasicSal", model.BasicSalary);
                queryParameters.Add("@InrementLevel", model.IncrementId);
                queryParameters.Add("@GradeLevel", model.LevelID);
                if (model.MA == true)
                {
                    queryParameters.Add("@MA", 'Y');
                }
                else
                {
                    queryParameters.Add("@MA", 'N');
                }
                if (model.WA == true)
                {
                    queryParameters.Add("@WA", 'Y');
                }
                else
                {
                    queryParameters.Add("@WA", 'N');
                }
                if (model.HRA == true)
                {
                    queryParameters.Add("@HRA", 'Y');
                }
                else
                {
                    queryParameters.Add("@HRA", 'N');
                }
                if (model.IsNPSCon == true)
                {
                    queryParameters.Add("@IsNPSCon", 'Y');
                }
                else
                {
                    queryParameters.Add("@IsNPSCon", 'N');
                }
                if (model.CCA == true)
                {
                    queryParameters.Add("@CCA", 'Y');
                }
                else
                {
                    queryParameters.Add("@CCA", 'N');
                }
                queryParameters.Add("@IsPenCon", model.IsPenCon);
                queryParameters.Add("@IsPpf", model.IsPpf);
                queryParameters.Add("@DOR", model.DOR);
                queryParameters.Add("@EmpId", model.ID);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("EmpSalary_Update", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region EmployeeLICDetail
        public static EmployeeLIC BindEmployeeDetailDropdown(EmployeeLIC model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmpId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<EmployeeLIC>("GetEmployeeDetailById", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmployeeLIC BindEmployeeByName(EmployeeLIC model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@TypeId", model.WTypeId);
                queryParameter.Add("@SubTypeId", model.Fk_SubDeptId);
                queryParameter.Add("@PFMSCode", model.PFMSCode);
                queryParameter.Add("@DeptEmpCode", model.DeptEmpCode);
                queryParameter.Add("@EmpName", model.EmpName);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<EmployeeLIC>("SearchEmployee", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmployeeLIC SaveEmpLIC(EmployeeLIC model)
        {
            EmployeeLIC _iresult = new EmployeeLIC();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpId", model.EmpId);
                queryParameters.Add("@LicNo", model.LicNo);
                queryParameters.Add("@LicAmount", model.LicAmount);
                queryParameters.Add("@remarks", model.remarks);
                queryParameters.Add("@Status", model.Status);
                queryParameters.Add("@EndDate", model.EndDate);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", model.ID);
                var list = DBHelperDapper.DAAddAndReturnModel<EmployeeLIC>("SP_EmpLicDetail_Insert", queryParameters);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmployeeLIC UpdateEmpLIC(EmployeeLIC model)
        {
            EmployeeLIC _iresult = new EmployeeLIC();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpId", model.EmpId);
                queryParameters.Add("@LicNo", model.LicNo);
                queryParameters.Add("@LicAmount", model.LicAmount);
                queryParameters.Add("@remarks", model.remarks);
                queryParameters.Add("@Status", model.Status);
                queryParameters.Add("@EndDate", model.EndDate);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<EmployeeLIC>("SP_EmpLicDetail_Update", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region EmpRegistration 
        public EmpReg SaveEmployeeRegistration(EmpReg model)
        {
            EmpReg _iresult = new EmpReg();
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@UserId", model.UserId);
                parameter.Add("@EmployementId", model.EmpType);
                parameter.Add("@OfficeId", SessionManager.OfficeID);
                parameter.Add("@WTypeId", model.EmpCategory);
                parameter.Add("@EmpName", model.EmpName);
                parameter.Add("@Sex", model.EmpGender);
                parameter.Add("@Married", model.EmpMartialStatus);
                parameter.Add("@FatherName", model.EmpFatherName);
                parameter.Add("@DistrictId", model.EmpHomeDistrict);
                parameter.Add("@PermAddress", model.EmpPeramanentAddress);
                parameter.Add("@PostAddress", model.EmpPostalAddress);
                parameter.Add("@EmpQualification", model.EmpQualification);
                parameter.Add("@DepartmentId", model.DeptDepartment);
                parameter.Add("@BankId", model.BBank);
                parameter.Add("@BranchId", 0);
                parameter.Add("@UANNO", model.UANNO);
                parameter.Add("@AccountNo", model.BAccountNumber);
                parameter.Add("@PANNo", model.BPanNumber);
                parameter.Add("@CategoryId", model.DeptClassCategory);
                parameter.Add("@SubDeptId", model.DeptSubDepartment);
                parameter.Add("@DesignationId", model.DeptDesignation);
                parameter.Add("@NPSNo", model.ONPSAccount);
                parameter.Add("@Nominee", model.ONomineeName);
                parameter.Add("@RelationId", model.ONomineeRelation);
                parameter.Add("@MobileNo", model.EmpMob);
                parameter.Add("@EmailId", model.EmpEmailId);
                parameter.Add("@DOB", model.EmpDob);
                parameter.Add("@DOJ", model.DeptDateOfJoiningInService);
                if (string.IsNullOrEmpty(model.DateOfDeath))
                {
                    parameter.Add("@DOD", "1900-01-01");
                }
                else
                {
                    parameter.Add("@DOD", model.DateOfDeath);
                }
                parameter.Add("@AdharNo", model.EmpAadharNumber);

                parameter.Add("@Remarks", 0);
                parameter.Add("@Photo", model.hbdnProfile);
                parameter.Add("@GPFTypeId", model.GpfType);

                parameter.Add("@GPFCode", model.GPFACNo);
                parameter.Add("@GISCode", model.OGISAccountNumber);
                parameter.Add("@EPFCode", model.EPFACNo);
                parameter.Add("@ESICCODE", model.ESICACNo);
                parameter.Add("@GradePayId", model.SGradePay);
                parameter.Add("@BasicSalary", model.SBasicSalary);
                parameter.Add("@MA", Convert.ToInt32(model.MA) == 1 ? 'Y' : 'N');
                parameter.Add("@WA", Convert.ToInt32(model.WA) == 1 ? 'Y' : 'N');
                parameter.Add("@CCA", "N");
                parameter.Add("@HRA", Convert.ToInt32(model.HRA) == 1 ? 'Y' : 'N');
                parameter.Add("@SalaryStatus", model.SStatus);
                parameter.Add("@EmployeeStatus", model.EStatus);
                parameter.Add("@BloodGroupId", model.EmpBloodGroup);
                parameter.Add("@EmergencyNo", model.EmpContactNo);
                parameter.Add("@DptEmpCode", model.EmpDepartmentalEmployeeCode);
                parameter.Add("@AuthSignatory", model.AuthorisedSignatory);
                parameter.Add("@casteid", model.EmpCaste);
                parameter.Add("@LevelID", model.SLevel);
                parameter.Add("@IncrementId", model.SIncrement);
                parameter.Add("@IPAddress", "");
                parameter.Add("@IFSCCode", model.BIFSC);
                if (String.IsNullOrEmpty(model.ContractValidity))
                {
                    parameter.Add("@ContractValidity", "1900-01-01");
                }
                else
                {
                    parameter.Add("@ContractValidity", model.ContractValidity);
                }

                parameter.Add("@RecruitmentMode", model.DeptModeOfRecruitment);
                parameter.Add("@ServiceQuota", model.DeptSpecialServiceQuota);
                parameter.Add("@ReligionId", model.EmpReligion);
                parameter.Add("@PreEmpId", model.CasEmp);
                parameter.Add("@OfficeDOJ", model.DeptDateOfJoiningInULB);
                parameter.Add("@IncDt", model.DeptMonthofIncrement);
                parameter.Add("@IsEPF", Convert.ToInt32(model.EPF) == 1 ? "Y" : "N");
                parameter.Add("@IsESIC", Convert.ToInt32(model.ESIC) == 1 ? "Y" : "N");
                parameter.Add("@IsPPF", model.Basic);
                parameter.Add("@PFMSCode", model.DeptPFMsVendor);
                parameter.Add("@IsPenCon", model.BasicDA);
                parameter.Add("@IsNPSCon", Convert.ToInt32
                    (model.IsNps) == 1 ? "Y" : "N");
                parameter.Add("@HeadId", model.DeptPaymentHead);
                parameter.Add("@PayCommissionId", model.SPayCommisson);
                parameter.Add("@PayScaleId", model.SPayScale);
                parameter.Add("@SourceId", model.salaryweightage);
                parameter.Add("@EmpCode", "");
                parameter.Add("@companyId", SessionManager.CompanyId);
                parameter.Add("@ReportingPerson", model.ReportinPerson);
                parameter.Add("@IsLock", Convert.ToInt32(model.IsFinalizedData) == 1 ? "F" : "N");

                _iresult = DBHelperDapper.DAAddAndReturnModel<EmpReg>("SP_EmpDetail_Insert", parameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<SelectListItem> BindSubCategory(int DepartmentId)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@DepartmentId", DepartmentId);
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("GetSubCategory_DropDwon", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> BindIncrement(int LevelId)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@levelId", LevelId);
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("bindIncrement", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> BindDistrict(int stateId)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@StaetId", stateId);
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Bind_District", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> BindOffice(int district)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@DistrictId", district);
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("BindOfficeByDistrictId", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> BindReportingPerson(int Office, int empId)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", Office);
                queryParameter.Add("@empId", empId);
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("BindRportingPeronByOfficeId", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ListEmpReg> EmpRegList(ListEmpReg model)
        {
            try
            {
                var query = new DynamicParameters();
                if (String.IsNullOrEmpty(model.EmpType))
                {
                    model.EmpType = "0";
                }
                query.Add("@EmpType", Convert.ToInt32(model.EmpType));
                query.Add("@EmpCategory", model.EmpCategory);
                query.Add("@empName", model.EmPName);
                query.Add("@empcode", model.EmpCode);
                query.Add("@PFMSCODE", model.PFMSCODE);
                query.Add("@Deaprtment", model.Department);
                query.Add("@Subdepartment", model.SubDepartment);
                query.Add("@Designation", model.Designation);
                query.Add("@officeid", SessionManager.OfficeID);
                List<ListEmpReg> objlist = DBHelperDapper.DAAddAndReturnModelList<ListEmpReg>("Get_EmployeeList", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmpReg EmpRegById(int EmpId)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("@EmpId", EmpId);
                EmpReg objlist = DBHelperDapper.DAAddAndReturnModel<EmpReg>("Get_EmployeeList", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmpReg EditEmployeeRegistration(EmpReg model)
        {
            EmpReg _iresult = new EmpReg();
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@EmpId", model.EId);
                parameter.Add("@UserId", model.UserId);
                parameter.Add("@EmployementId", model.EmpType);
                parameter.Add("@OfficeId", SessionManager.OfficeID);
                parameter.Add("@WTypeId", model.EmpCategory);
                parameter.Add("@EmpName", model.EmpName);
                parameter.Add("@Sex", model.EmpGender);
                parameter.Add("@Married", model.EmpMartialStatus);
                parameter.Add("@FatherName", model.EmpFatherName);
                parameter.Add("@DistrictId", model.EmpHomeDistrict);
                parameter.Add("@PermAddress", model.EmpPeramanentAddress);
                parameter.Add("@PostAddress", model.EmpPostalAddress);
                parameter.Add("@EmpQualification", model.EmpQualification);
                parameter.Add("@DepartmentId", model.DeptDepartment);
                parameter.Add("@BankId", model.BBank);
                parameter.Add("@BranchId", 0);
                parameter.Add("@UANNO", model.UANNO);
                parameter.Add("@AccountNo", model.BAccountNumber);
                parameter.Add("@PANNo", model.BPanNumber);
                parameter.Add("@CategoryId", model.DeptClassCategory);
                parameter.Add("@DesignationId", model.DeptDesignation);


                parameter.Add("@NPSNo", model.ONPSAccount);
                parameter.Add("@Nominee", model.ONomineeName);
                parameter.Add("@RelationId", model.ONomineeRelation);
                parameter.Add("@MobileNo", model.EmpMob);
                parameter.Add("@EmailId", model.EmpEmailId);
                parameter.Add("@DOB", model.EmpDob);
                parameter.Add("@DOJ", model.DeptDateOfJoiningInService);
                parameter.Add("@Dor", model.OrderDate);
                if (string.IsNullOrEmpty(model.DateOfDeath))
                {
                    parameter.Add("@DOD", "1900-01-01");
                }
                else
                {
                    parameter.Add("@DOD", model.DateOfDeath);
                }
                parameter.Add("@AdharNo", model.EmpAadharNumber);

                parameter.Add("@Remarks", 0);
                //parameter.Add("@Photo", model.hbdnProfile);
                parameter.Add("@GPFTypeId", model.GpfType);

                parameter.Add("@GPFCode", model.GPFACNo);
                parameter.Add("@GISCode", model.OGISAccountNumber);
                parameter.Add("@EPFCode", model.EPFACNo);

                parameter.Add("@GradePayId", model.SGradePay);
                parameter.Add("@LevelID", model.SLevel);
                parameter.Add("@IncrementId", model.SIncrement);
                parameter.Add("@BasicSalary", model.SBasicSalary);
                parameter.Add("@MA", Convert.ToInt32(model.MA) == 1 ? 'Y' : 'N');
                parameter.Add("@WA", Convert.ToInt32(model.WA) == 1 ? 'Y' : 'N');
                parameter.Add("@CCA", "N");
                parameter.Add("@HRA", Convert.ToInt32(model.HRA) == 1 ? 'Y' : 'N');
                parameter.Add("@SalaryStatus", model.SStatus);
                parameter.Add("@EmployeeStatus", model.EStatus);
                parameter.Add("@BloodGroupId", model.EmpBloodGroup);
                parameter.Add("@EmergencyNo", model.EmpContactNo);
                parameter.Add("@AuthSignatory", model.AuthorisedSignatory);
                parameter.Add("@casteid", model.EmpCaste);
                parameter.Add("@IPAddress", "");
                if (String.IsNullOrEmpty(model.ContractValidity))
                {
                    parameter.Add("@ContractValidity", "1900-01-01");
                }
                else
                {
                    parameter.Add("@ContractValidity", model.ContractValidity);
                }
                parameter.Add("@ReligionId", model.EmpReligion);
                if (string.IsNullOrEmpty(model.DeptDateOfJoiningInULB))
                {

                    parameter.Add("@OfficeDOJ", "1900-01-01");
                }
                else
                {
                    parameter.Add("@OfficeDOJ", model.DeptDateOfJoiningInULB);
                }
                parameter.Add("@IncDt", model.DeptMonthofIncrement);

                parameter.Add("@IsEPF", Convert.ToInt32(model.EPF) == 1 ? "Y" : "N");

                parameter.Add("@IsESIC", Convert.ToInt32(model.ESIC) == 1 ? "Y" : "N");
                parameter.Add("@ServiceQuota", model.DeptSpecialServiceQuota);
                parameter.Add("@RecruitmentMode", model.DeptModeOfRecruitment);
                parameter.Add("@PFMSCode", model.DeptPFMsVendor);
                parameter.Add("@IsPenCon", model.BasicDA);
                parameter.Add("@IsNPSCon", Convert.ToInt32(model.IsNps) == 1 ? "Y" : "N");
                parameter.Add("@IsLock", Convert.ToInt32(model.IsFinalizedData) == 1 ? "F" : "N");
                parameter.Add("@IsPPF", model.Basic);

                parameter.Add("@ESICCODE", model.ESICACNo);
                parameter.Add("@SubDeptId", model.DeptSubDepartment);
                parameter.Add("@DptEmpCode", model.EmpDepartmentalEmployeeCode);
                parameter.Add("@PreEmpId", model.CasEmp);
                parameter.Add("@IFSCCode", model.BIFSC);
                parameter.Add("@HeadId", model.DeptPaymentHead);
                parameter.Add("@PayCommissionId", model.SPayCommisson);
                parameter.Add("@PayScaleId", model.SPayScale);
                parameter.Add("@SourceId", model.salaryweightage);

                parameter.Add("@companyId", SessionManager.CompanyId);
                parameter.Add("@Photo", model.hbdnProfile);
                parameter.Add("@ReportingPerson", model.ReportinPerson);


                //parameter.Add("@EmpCode", "");

                _iresult = DBHelperDapper.DAAddAndReturnModel<EmpReg>("SP_EmpDetail_Update", parameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Employee Search
        public List<EmpSearch> EmpList(EmpSearch model)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@TypeId", model.WTypeId);
                queryParameters.Add("@officeid", SessionManager.OfficeID);
                queryParameters.Add("@Agencytypeid", model.Agencytypeid);
                queryParameters.Add("@Fk_distictId", model.Fk_distictId);
                queryParameters.Add("@DepartmentId", model.Fk_DepartmentId);
                queryParameters.Add("@SubDeptId", model.Fk_SubDeptId);
                queryParameters.Add("@EmpName", model.EmpName == "" ? null : model.EmpName);
                queryParameters.Add("@empcode", model.PFMSCode == "" ? null : model.PFMSCode);
                queryParameters.Add("@deptempcode", model.dptempcode == "" ? null : model.dptempcode);
                queryParameters.Add("@salarystatus", model.SalaryStatus == "" ? null : model.SalaryStatus);
                List<EmpSearch> objlist = DBHelperDapper.DAAddAndReturnModelList<EmpSearch>("EmployeeReport", queryParameters);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Request Leave
        public EmpLeaveRequest SaveEmpLeaveRequest(EmpLeaveRequest model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@Description", model.Description);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@Title", model.LeaveTypeId);
                queryParameter.Add("@FromDate", model.FromDate);
                queryParameter.Add("@ToDate", model.ToDate);
                queryParameter.Add("@LeaveType", model.LeaveTypeId);
                queryParameter.Add("@LeaveFromStatus", model.LeaveFromStatus);
                queryParameter.Add("@LeaveToStatus", model.LeaveToStatus);
                queryParameter.Add("@Employeecode", SessionManager.EmpCode);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                model = DBHelperDapper.DAAddAndReturnModel<EmpLeaveRequest>("SaveLeaveRequestAPI", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Priyanshu




        public dynamic BindEmployeeDetailDropdown1(EmpEarningAndDeductionDetails model)
        {
            EmpEarningAndDeductionDetails obj = new EmpEarningAndDeductionDetails();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {

                try
                {
                    var queryParameter = new DynamicParameters();
                    queryParameter.Add("@EmpId", model.EmpId);
                    queryParameter.Add("@officeid", SessionManager.OfficeID);

                    var redar = con.QueryMultiple("GetEmployeeDetailById1", queryParameter, commandType: System.Data.CommandType.StoredProcedure);
                    var Vm = redar.Read<EmpEarningAndDeductionDetails>().FirstOrDefault();
                    var Vl = redar.Read<EmployeeEarning>().ToList();
                    var Vll = redar.Read<EmployeeDeduction>().ToList();
                    var Ofc = redar.Read<EmployeeGred>().ToList();
                    var DA = redar.Read<EmployeeDA>().ToList();
                    var Fx = redar.Read<EmployeeFixAllow>().ToList();
                    obj = Vm;
                    obj.EmployeeEarninglist = Vl;
                    obj.EmployeeDeductionlist = Vll;
                    obj.EmployeeGredlist = Ofc;
                    obj.EmployeeDAlist = DA;
                    obj.EmployeeFixAllowlist = Fx;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public EmpEarningAndDeductionDetails SaveEmpEarningAndDeductionDetail(EmpEarningAndDeductionDetails model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmpId);
                queryParameter.Add("@CircleId", SessionManager.CircleId);
                queryParameter.Add("@DAPer", model.DAPer);
                queryParameter.Add("@IR", model.IR);
                queryParameter.Add("@PerPay", model.PerPay);
                queryParameter.Add("@ChatvaAllow", model.ChatvaAllow);
                queryParameter.Add("@CleaningAllow", model.CleaningAllow);
                queryParameter.Add("@SpecPay", model.SpecPay);
                queryParameter.Add("@DisAllow", model.DisAllow);
                queryParameter.Add("@DepAllow", model.DepAllow);
                queryParameter.Add("@VehicleAllow", model.VehicleAllow);
                queryParameter.Add("@OtherAllow", model.OtherAllow);
                queryParameter.Add("@MiscAmt1", model.MiscAmt1);
                queryParameter.Add("@MiscDesc1", model.MiscDesc1);
                queryParameter.Add("@MiscAmt2", model.MiscAmt2);
                queryParameter.Add("@MiscDesc2", model.MiscDesc2);
                queryParameter.Add("@MiscAmt3", model.MiscAmt3);
                queryParameter.Add("@MiscDesc3", model.MiscDesc3);
                queryParameter.Add("@MiscAmt4", model.MiscAmt4);
                queryParameter.Add("@MiscDesc4", model.MiscDesc4);
                queryParameter.Add("@BilangAllow", model.BilangAllow);
                queryParameter.Add("@BroomAllow", model.BroomAllow);
                //queryParameter.Add("@DAStatus", model.DaStatus);
                var res = DBHelperDapper.DAAddAndReturnModel<EmpEarningAndDeductionDetails>("SP_EmpAllowance_Insert", queryParameter);
                var queryParameter1 = new DynamicParameters();
                queryParameter1.Add("@EmpId", model.EmpId);
                queryParameter1.Add("@GPF", model.GPF);
                queryParameter1.Add("@LIC", model.LicAmount);
                queryParameter1.Add("@GIS", model.GIS);
                queryParameter1.Add("@VehicleCharges", model.VehicleCharges);
                queryParameter1.Add("@IncomeTax", model.IncomeTax);
                queryParameter1.Add("@CourtReco", model.CourtReco);
                queryParameter1.Add("@QtrRent", model.QtrRent);
                queryParameter1.Add("@PermReco", model.PayReco);
                queryParameter1.Add("@Society", model.Society);
                queryParameter1.Add("@PayReco", model.PayReco);
                queryParameter1.Add("@MiscReco", model.MiscReco);
                queryParameter1.Add("@OtherReco", model.OtherReco);
                queryParameter1.Add("@CoOperative", model.CoOperative);
                queryParameter1.Add("@Penalty", model.Penalty);
                queryParameter1.Add("@MiscAmt1", model.MisAmt1);
                queryParameter1.Add("@MiscAmt2", model.MisAmt2);
                queryParameter1.Add("@MiscDesc1", model.MisDesc1);
                queryParameter1.Add("@MiscDesc2", model.MisDesc2);
                queryParameter1.Add("@MiscAmt3", model.MisAmt3);
                queryParameter1.Add("@MiscDesc3", model.MisDesc3);
                queryParameter1.Add("@MiscAmt4", model.MisAmt4);
                queryParameter1.Add("@MiscDesc4", model.MisDesc4);
                queryParameter1.Add("@TotLoanAmt", 0);
                queryParameter1.Add("@RD", model.RD);
                queryParameter1.Add("@PPF", model.PPF);
                queryParameter1.Add("@StaffAdv", model.StaffAdv);
                queryParameter1.Add("@GPFPer", model.GPFPer1);
                queryParameter1.Add("@PPFPer", model.PPFPer1);
                var res1 = DBHelperDapper.DAAddAndReturnModel<EmpEarningAndDeductionDetails>("SP_EmpDeduction_Insert", queryParameter1);
                if (res.flag > 0 && res1.flag > 0)
                {
                    if (res.flag == res1.flag)
                    {
                        res.message = "Record saved successfully";
                    }
                    else
                    {
                        res.message = "Something went wrong";
                    }
                }
                else
                {
                    res.message = "Something went wrong";

                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public EmpEarningAndDeductionDetails UpdateEmpEarningAndDeductionDetail(EmpEarningAndDeductionDetails model)
        {
            try
            {

                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmpId);
                queryParameter.Add("@CircleId", SessionManager.CircleId);
                queryParameter.Add("@DAPer", model.DAPer);
                queryParameter.Add("@IR", model.IR);
                queryParameter.Add("@PerPay", model.PerPay);
                queryParameter.Add("@ChatvaAllow", model.ChatvaAllow);
                queryParameter.Add("@CleaningAllow", model.CleaningAllow);
                queryParameter.Add("@SpecPay", model.SpecPay);
                queryParameter.Add("@DisAllow", model.DisAllow);
                queryParameter.Add("@DepAllow", model.DepAllow);
                queryParameter.Add("@VehicleAllow", model.VehicleAllow);
                queryParameter.Add("@OtherAllow", model.OtherAllow);
                queryParameter.Add("@MiscAmt1", model.MiscAmt1);
                queryParameter.Add("@MiscDesc1", model.MiscDesc1);
                queryParameter.Add("@MiscAmt2", model.MiscAmt2);
                queryParameter.Add("@MiscDesc2", model.MiscDesc2);
                queryParameter.Add("@MiscAmt3", model.MiscAmt3);
                queryParameter.Add("@MiscDesc3", model.MiscDesc3);
                queryParameter.Add("@MiscAmt4", model.MiscAmt4);
                queryParameter.Add("@MiscDesc4", model.MiscDesc4);
                queryParameter.Add("@BilangAllow", model.BilangAllow);
                queryParameter.Add("@BroomAllow", model.BroomAllow);
                //queryParameter.Add("@DAStatus", model.DaStatus);
                var res = DBHelperDapper.DAAddAndReturnModel<EmpEarningAndDeductionDetails>("SP_EmpAllowance_Update", queryParameter);
                var queryParameter1 = new DynamicParameters();
                queryParameter1.Add("@EmpId", model.EmpId);
                queryParameter1.Add("@GPF", model.GPF);
                queryParameter1.Add("@LIC", model.LicAmount);
                queryParameter1.Add("@GIS", model.GIS);
                queryParameter1.Add("@VehicleCharges", model.VehicleCharges);
                queryParameter1.Add("@IncomeTax", model.IncomeTax);
                queryParameter1.Add("@CourtReco", model.CourtReco);
                queryParameter1.Add("@QtrRent", model.QtrRent);
                queryParameter1.Add("@PermReco", model.PayReco);
                queryParameter1.Add("@Society", model.Society);
                queryParameter1.Add("@PayReco", model.PayReco);
                queryParameter1.Add("@MiscReco", model.MiscReco);
                queryParameter1.Add("@OtherReco", model.OtherReco);
                queryParameter1.Add("@CoOperative", model.CoOperative);
                queryParameter1.Add("@Penalty", model.Penalty);
                queryParameter1.Add("@MiscAmt1", model.MisAmt1);
                queryParameter1.Add("@MiscAmt2", model.MisAmt2);
                queryParameter1.Add("@MiscDesc1", model.MisDesc1);
                queryParameter1.Add("@MiscDesc2", model.MisDesc2);
                queryParameter1.Add("@MiscAmt3", model.MisAmt3);
                queryParameter1.Add("@MiscDesc3", model.MisDesc3);
                queryParameter1.Add("@MiscAmt4", model.MisAmt4);
                queryParameter1.Add("@MiscDesc4", model.MisDesc4);
                queryParameter1.Add("@TotLoanAmt", 0);
                queryParameter1.Add("@RD", model.RD);
                queryParameter1.Add("@PPF", model.PPF);
                queryParameter1.Add("@StaffAdv", model.StaffAdv);
                queryParameter1.Add("@GPFPer", model.GPFPer1);
                queryParameter1.Add("@PPFPer", model.PPFPer1);
                var res1 = DBHelperDapper.DAAddAndReturnModel<EmpEarningAndDeductionDetails>("SP_EmpDeduction_Update", queryParameter1);
                if (res.flag > 0 && res1.flag > 0)
                {
                    if (res.flag == res1.flag)
                    {
                        res.message = "Record Updated successfully";
                    }
                    else
                    {
                        res.message = "Something went wrong";
                    }
                }
                else
                {
                    res.message = "Something went wrong";

                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Earning & Deduction (Contractual)

        public static EDContractual BindEmployeeDetailDropdown2(EDContractual model)
        {
            EDContractual obj = new EDContractual();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    var queryParameter = new DynamicParameters();
                    queryParameter.Add("@EmpId", model.EmpId);
                    var redar = con.QueryMultiple("GetEmployeeDetailById2", queryParameter, commandType: System.Data.CommandType.StoredProcedure);
                    var EDAddEarnings = redar.Read<EDAddEarnings>().FirstOrDefault();
                    var serviceType = redar.Read<serviceType>().FirstOrDefault();
                    var EDDeductions = redar.Read<EDDeductions>().FirstOrDefault();
                    obj.list = EDAddEarnings;
                    obj.list1 = serviceType;
                    obj.list2 = EDDeductions;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public EDContractual SaveEDContractual(EDContractual model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmpId);
                queryParameter.Add("@UserId", SessionManager.UserId);
                queryParameter.Add("@EOther", model.EOther);
                queryParameter.Add("@EMisc", model.EMisc);
                queryParameter.Add("@EMisc2", model.EMisc2);
                queryParameter.Add("@Festival", model.Festival);
                queryParameter.Add("@DOther", model.DOther);
                queryParameter.Add("@DMisc", model.DMisc);
                queryParameter.Add("@Penality", model.Penality);
                queryParameter.Add("@DPPF", model.PPPfCont);
                queryParameter.Add("@DMisc2", model.DMisc2);
                queryParameter.Add("@Action", "save");
                queryParameter.Add("@IsFixPay", model.IsFixPay);
                queryParameter.Add("@DAPer", model.DAPer);
                model = DBHelperDapper.DAAddAndReturnModel<EDContractual>("sp_ContractEarnDed", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public EDContractual UpdateEDContractual(EDContractual model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmpId);
                queryParameter.Add("@UserId", SessionManager.UserId);
                queryParameter.Add("@EOther", model.EOther);
                queryParameter.Add("@EMisc", model.EMisc);
                queryParameter.Add("@EMisc2", model.EMisc2);
                queryParameter.Add("@Festival", model.Festival);
                queryParameter.Add("@DOther", model.DOther);
                queryParameter.Add("@DMisc", model.DMisc);
                queryParameter.Add("@Penality", model.Penality);
                queryParameter.Add("@DPPF", model.PPPfCont);
                queryParameter.Add("@DMisc2", model.DMisc2);
                queryParameter.Add("@Action", "update");
                queryParameter.Add("@IsFixPay", model.IsFixPay);
                queryParameter.Add("@DAPer", model.DAPer);
                model = DBHelperDapper.DAAddAndReturnModel<EDContractual>("sp_ContractEarnDed", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region AttendanceReg
        public static AttendanceReg AttenReg(AttendanceReg model)
        {
            AttendanceReg _iresult = new AttendanceReg();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@FromDate", model.FromDate);
                queryParameters.Add("@ToDate", model.ToDate);
                if (model.Reason == "Other")
                {
                    queryParameters.Add("@Reason", model.Other);
                }
                else
                {
                    queryParameters.Add("@Reason", model.Reason);
                }
                queryParameters.Add("@Remark", model.Remark);
                queryParameters.Add("@Fk_EmpId", SessionManager.EmpId);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_AtteReg", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static AttendanceReg ListAttenReg(AttendanceReg model)
        {
            AttendanceReg _iresult = new AttendanceReg();

            try
            {
                var queryParameters = new DynamicParameters();
                List<AttendanceReg> list = DBHelperDapper.DAAddAndReturnModelList<AttendanceReg>("Fetch_AttenReg", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Bonus
        public static EmployeePF GenerateBonus(EmployeePF model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@UserId", SessionManager.UserId);
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                queryParameter.Add("@WtypeId", model.WTypeId);
                queryParameter.Add("@IPaddress", model.IpAddress);
                queryParameter.Add("@DepartmentID", model.Fk_DepartmentId);
                queryParameter.Add("@ESubDeptid", model.Fk_SubDeptId);
                queryParameter.Add("@FinYr", model.Year);
                queryParameter.Add("@SEmpid", model.Fk_EmpId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<EmployeePF>("SP_Generate_Bonus", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ReportBonus BonusReport(ReportBonus model)
        {
            ReportBonus _iresult = new ReportBonus();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DeptId", model.Fk_DepartmentId);
                queryParameters.Add("@SubDeptId", model.Fk_SubDeptId);
                queryParameters.Add("@FinYear", model.Year);
                queryParameters.Add("@Procid", 1);
                queryParameters.Add("@OrderBy", model.OrderBy);
                List<ReportBonus> List = DBHelperDapper.DAAddAndReturnModelList<ReportBonus>("Sp_BonusBill", queryParameters);
                _iresult.List = List;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public List<SelectListItem> BindEmployeeByWorkingType(int WTypeId, int DepartmentId, int Fk_SubDeptId)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@empcategory", WTypeId);
                queryParameter.Add("@departmentId", DepartmentId);
                queryParameter.Add("@subdepartmentId", Fk_SubDeptId);
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("GetEmployeeBySubDepartmentId", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GenerateSalary GenerateSalary(GenerateSalary model)
        {
            GenerateSalary _iresult = new GenerateSalary();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@UserId", SessionManager.UserId);
                queryParameters.Add("@IPAddress", "");
                queryParameters.Add("@WtypeId", model.WTypeId);
                queryParameters.Add("@DepartmentId", model.Fk_DepartmentId);
                queryParameters.Add("@ESubDeptId", model.Fk_SubDeptId);
                if (Convert.ToInt32(model.WTypeId) == 1)
                {
                    queryParameters.Add("@TotalDays", System.Globalization.CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(Convert.ToInt32(model.Year), Convert.ToInt32(model.Month)));
                    queryParameters.Add("AllEmp", Convert.ToInt32(model.salaryFor) == 2 ? "A" : "O");
                    queryParameters.Add("@EmpId", model.EmpId);
                }
                else
                {

                    //queryParameters.Add("@EmpId", 0);
                    queryParameters.Add("@SEmpid", model.EmpId);
                    queryParameters.Add("@Remarks", "Test");
                }
                queryParameters.Add("@PayYear", model.Year);
                queryParameters.Add("@PayMonth", model.Month);

                queryParameters.Add("@outmsg", "");
                if (model.WTypeId == 1)
                {
                    _iresult = DBHelperDapper.DAAddAndReturnModel<GenerateSalary>("SP_GenerateSalary", queryParameters);
                }
                else if (model.WTypeId == 2)
                {
                    _iresult = DBHelperDapper.DAAddAndReturnModel<GenerateSalary>("SP_GenerateSalary_Samvida", queryParameters);
                }
                else if (model.WTypeId == 3)
                {
                    _iresult = DBHelperDapper.DAAddAndReturnModel<GenerateSalary>("SP_GenerateSalary_DailyWages", queryParameters);

                }
                else
                {
                    ;
                }



                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Emplone


        public EmployeeLoan SaveLoanDetail(EmployeeLoan model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmpId);
                queryParameter.Add("@LoanTypeId", model.LoneType);
                queryParameter.Add("@LoanNo", model.OrderNo);
                queryParameter.Add("@LoanAmount", model.AdvanceAmount);
                queryParameter.Add("@TotalInst", model.TotalNoOfInstalment);
                queryParameter.Add("@InstAmount", model.MonthlyDeduction);
                queryParameter.Add("@StartMonth", model.Month);
                queryParameter.Add("@StartYear", model.Year);
                queryParameter.Add("@TotPre", model.TotalDeductionPre);
                queryParameter.Add("@CurrInst", model.CurrentNoOfInstalment);
                queryParameter.Add("@RecTotInst", 0);
                queryParameter.Add("@Status", model.Status);

                model = DBHelperDapper.DAAddAndReturnModel<EmployeeLoan>("SP_EmpLoanDetail_Insert", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Payslip 
        public static PaySlip PaySlip(PaySlip model)
        {
            PaySlip _iresult = new PaySlip();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@UserId", SessionManager.UserId);
                // queryParameters.Add("@RegTypeId", SessionManager.DepId);
                queryParameters.Add("@RegTypeId", 1);
                queryParameters.Add("@EmpId", SessionManager.EmpId);
                queryParameters.Add("@AllEmp", 'E');
                // queryParameters.Add("@Month", model.Month);
                queryParameters.Add("@Month", 2);
                //queryParameters.Add("@Year", model.Year);
                queryParameters.Add("@Year", 2021);
                queryParameters.Add("@PageIndex", 1);
                queryParameters.Add("@PageSize", 10);
                // queryParameters.Add("@RecordCount", "Out");

                List<PaySlip> list = DBHelperDapper.DAAddAndReturnModelList<PaySlip>("GetHQPaySlipPageWise", queryParameters);
                _iresult.paySlipList = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SalarySummary SummarySlips(SalarySummary model)
        {
            SalarySummary _iresult = new SalarySummary();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("RegTypeId", SessionManager.DepId);

                queryParameters.Add("@DepotId", SessionManager.OfficeID);
                queryParameters.Add("@EmpId", SessionManager.EmpId);
                queryParameters.Add("@FromMonth", model.FromMonth);
                queryParameters.Add("@FromYear", model.FromYear);
                queryParameters.Add("@ToMonth", model.ToMonth);
                queryParameters.Add("@ToYear", model.ToYear);



                List<SalarySummary> list = DBHelperDapper.DAAddAndReturnModelList<SalarySummary>("GetDPSalarySummary", queryParameters);
                _iresult.SalarySummaryList = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Daily Wages Earnings & Deductions Master 

        public DAilyWagesEarDed SaveDAilyWagesEarDed(DAilyWagesEarDed model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmpId);
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                queryParameter.Add("@PerRate", model.BasicSalary);
                queryParameter.Add("@Earning", model.Earning);
                queryParameter.Add("@Action", "Save");
                queryParameter.Add("@Deduction", model.Deduction);
                model = DBHelperDapper.DAAddAndReturnModel<DAilyWagesEarDed>("Proc_DailyWagesEarDed", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public DAilyWagesEarDed UpdateDAilyWagesEarDed(DAilyWagesEarDed model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmpId);
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                queryParameter.Add("@PerRate", model.BasicSalary);
                queryParameter.Add("@Earning", model.Earning);
                queryParameter.Add("@Action", "Update");
                queryParameter.Add("@Deduction", model.Deduction);
                model = DBHelperDapper.DAAddAndReturnModel<DAilyWagesEarDed>("Proc_DailyWagesEarDed", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        public static InternalTransfer AddEmpLeaveEncashment(InternalTransfer model)
        {
            InternalTransfer _iresult = new InternalTransfer();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpId", model.EmpId);
                queryParameters.Add("@YearId", model.Year);
                queryParameters.Add("@Ltype1", model.Ltype1);
                queryParameters.Add("@Ltype2", model.Ltype2);
                queryParameters.Add("@days1", model.days1);
                queryParameters.Add("@days2", model.days2);
                queryParameters.Add("@Remarks", model.remarks);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SP_EmpLeaveEncashMent", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EmpStatus GetEmpStatus(EmpStatus model)
        {
            EmpStatus _iresult = new EmpStatus();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpName", model.Name);
                queryParameters.Add("@PFMSCODE", model.PFMSCode);
                queryParameters.Add("@AccountNo", model.AccountNo);
                queryParameters.Add("@MobileNo", model.MobileNo);


                List<EmpStatus> list = DBHelperDapper.DAAddAndReturnModelList<EmpStatus>("Bind_Emp_status", queryParameters);
                _iresult.EmpStatusList = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region EmpGIS
        public static EmpGIS AddEmpGIS(EmpGIS model)
        {
            EmpGIS _iresult = new EmpGIS();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpId", model.EmpId);
                queryParameters.Add("@GISId", 0);
                queryParameters.Add("@StartYear", model.Year);
                queryParameters.Add("@Type", model.Type);
                queryParameters.Add("@GISNo", model.GISNo);
                queryParameters.Add("@RenewDate", model.RenewDate);
                queryParameters.Add("@Status", model.Status);
                queryParameters.Add("@GISAmount", model.GISAmount);
                queryParameters.Add("@StartMonth", model.StartMonth);
                queryParameters.Add("@Remarks", model.Remarks);
                queryParameters.Add("@ProcId", 1);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Proc_GISDetail", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static EmpGIS UpdateEmpGIS(EmpGIS model)
        {
            EmpGIS _iresult = new EmpGIS();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpId", model.EmpId);
                queryParameters.Add("@GISId", model.GISId);
                queryParameters.Add("@StartYear", model.Year);
                queryParameters.Add("@Type", model.Type);
                queryParameters.Add("@GISNo", model.GISNo);
                queryParameters.Add("@RenewDate", model.RenewDate);
                queryParameters.Add("@Status", model.Status);
                queryParameters.Add("@GISAmount", model.GISAmount);
                queryParameters.Add("@StartMonth", model.StartMonth);
                queryParameters.Add("@Remarks", model.Remarks);
                queryParameters.Add("@ProcId", 2);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Proc_GISDetail", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ClearData
        public static ClearData ClearDedData(ClearData model)
        {
            ClearData _iresult = new ClearData();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@departmentId", model.Fk_DepartmentId);
                queryParameters.Add("@subdeptid", model.Fk_SubDeptId);
                queryParameters.Add("@head", model.Dedhead);
                queryParameters.Add("@ProcId", 2);
                queryParameters.Add("@userid", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Proc_ClearPreviousEarningandDeduction", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ClearData ClearEarnData(ClearData model)
        {
            ClearData _iresult = new ClearData();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@departmentId", model.Fk_DepartmentId);
                queryParameters.Add("@subdeptid", model.Fk_SubDeptId);
                queryParameters.Add("@head", model.Earnhead);
                queryParameters.Add("@ProcId", 1);
                queryParameters.Add("@userid", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Proc_ClearPreviousEarningandDeduction", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Empolyee Transfer
        #region SearchEmpolyee
        public List<InternalTransfer> SerachEmpolyee(InternalTransfer model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@SubTypeId", model.Fk_SubDeptId);
                queryParameter.Add("@PFMSCode", model.PFMSCode);
                queryParameter.Add("@DeptEmpCode", model.DeptEmpCode);
                queryParameter.Add("@EmpName", model.SearchEmpName);
                var _iresult = DBHelperDapper.DAAddAndReturnModelList<InternalTransfer>("SearchEmployee", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Internal Transfer Save
        public InternalTransfer SaveInternalTransfer(InternalTransfer obj)
        {
            try
            {
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@EmpId", obj.EmpId);
                queryparameter.Add("@PrevUserId", SessionManager.UserId);
                queryparameter.Add("@PrevOfficeId", SessionManager.OfficeID);
                queryparameter.Add("@TranOfficeId", 0);
                queryparameter.Add("@PreDeptId", obj.preFk_DepartmentId);
                queryparameter.Add("@PreSubDeptId", obj.preFk_SubDeptId);
                queryparameter.Add("@TranDeptId", obj.TFk_DepartmentId);
                queryparameter.Add("@TranSubDeptId", obj.TFk_SubDeptId);
                queryparameter.Add("@OrderNo", obj.OrderNO);
                queryparameter.Add("@OrderDate", obj.Orderdate);
                queryparameter.Add("@Remarks", obj.remarks);
                queryparameter.Add("@EntryDate", DateTime.Now.ToString("yyyy-MM-dd"));
                queryparameter.Add("@TDesignation", obj.TDesignationId);
                queryparameter.Add("@JoiningDate", obj.TDOJ);
                queryparameter.Add("@PreWTypeId", obj.preWTypeId);
                queryparameter.Add("@PreEmployementId", obj.preEmployementId);
                queryparameter.Add("@TWTypeId", obj.TWTypeId);
                queryparameter.Add("@TEmployementId", obj.TEmployementId);
                var _result = DBHelperDapper.DAAddAndReturnModel<InternalTransfer>("SP_EmpInternalTransfer_Insert", queryparameter);
                return _result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Empolyee Transfer Save
        public EmployeeTransfer SaveEmployeeTransfer(EmployeeTransfer obj)
        {
            try
            {
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@EmpId", obj.EmpId);
                queryparameter.Add("@PrevUserId", SessionManager.UserId);
                queryparameter.Add("@PrevOfficeId", SessionManager.OfficeID);
                queryparameter.Add("@TranOfficeId", obj.OfficeId);
                queryparameter.Add("@OrderNo", obj.OrderNO);
                queryparameter.Add("@OrderDate", obj.Orderdate);
                queryparameter.Add("@Remarks", obj.remarks);
                queryparameter.Add("@EntryDate", DateTime.Now.ToString("yyyy-MM-dd"));
                var _result = DBHelperDapper.DAAddAndReturnModel<EmployeeTransfer>("SP_EmpTransfer_Insert", queryparameter);
                return _result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Accept_Rollback Empolyee
        public Accept_RollbackEmployee Accept_RollbackEmployee(Accept_RollbackEmployee obj)
        {
            try
            {
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@EmpId", obj.EmpId);
                queryparameter.Add("@OfficeId", SessionManager.OfficeID);
                queryparameter.Add("@UserId", SessionManager.UserId);
                queryparameter.Add("@DepartmentId", obj.A_Fk_DepartmentId);
                queryparameter.Add("@SubDepartmentId", obj.A_Fk_SubDeptId);
                queryparameter.Add("@DesignationId", obj.A_DesignationId);
                queryparameter.Add("@Date", obj.A_startdate);
                queryparameter.Add("@type", obj.Type);
                var _result = DBHelperDapper.DAAddAndReturnModel<Accept_RollbackEmployee>("Proc_Accept_Roolback_EMployee", queryparameter);
                return _result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        public List<SelectListItem> BindEmpByDepartmentAndsubDepartment(int DepartmentId, int SubDepartment)
        {
            try
            {
                var queryParameter = new DynamicParameters();

                queryParameter.Add("@departmentId", DepartmentId);
                queryParameter.Add("@subdepartment", SubDepartment);
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("BindEmpByDepartmentAndsubDepartment", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Loan Report
        public List<LoanReportList> LoanReport(LoanReport model)
        {
            List<LoanReportList> objlist = new List<LoanReportList>();
            try
            {
                var query = new DynamicParameters();

                query.Add("@DedType", Convert.ToInt32(model.LoanType));
                query.Add("@orderby", model.OrderBy);
                query.Add("@WType", model.Wtype);
                query.Add("@PMonth", model.Month);
                query.Add("@PYear", model.Year);
                query.Add("@salarytype", model.SalaryType);
                query.Add("@Employementid", model.EmpType);
                query.Add("@subdepid", model.SubDepartment);
                query.Add("@depid", model.Department);
                query.Add("@OfficeId", SessionManager.OfficeID);
                objlist = DBHelperDapper.DAAddAndReturnModelList<LoanReportList>("rpt_LoanReport", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<SelectListItem> BindLoanType()
        {
            try
            {
                var queryParameters = new DynamicParameters();

                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("BindLoanType", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Compensative

        public static Compensative CompensativeReport(Compensative model)
        {
            Compensative _iresult = new Compensative();
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@DepartmentId", model.Fk_DepartmentId);
                queryParameter.Add("@SubDeptId", model.Fk_SubDeptId);
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                List<Compensative> List = DBHelperDapper.DAAddAndReturnModelList<Compensative>("GetCompensative", queryParameter);
                _iresult.List = List;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Leave Report 
        public static RptEmpLeaveDetail GetRptEmpLeaveDetail(RptEmpLeaveDetail model)
        {
            RptEmpLeaveDetail _iresult = new RptEmpLeaveDetail();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WType", model.WTypeId);
                queryParameters.Add("@@Officeid", SessionManager.OfficeID);
                queryParameters.Add("@month", model.Month);
                queryParameters.Add("@year", model.Year);
                queryParameters.Add("@ReportFor", model.ReportFor);
                queryParameters.Add("@EmpId", model.EmpId);
                List<RptEmpLeaveDetail> list = DBHelperDapper.DAAddAndReturnModelList<RptEmpLeaveDetail>("Employee_LeaveReport", queryParameters);
                _iresult.RptEmpLeaveDetailList = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Lic Report 
        public List<SelectListItem> Getfilldepartment(RptEmpLicdetail model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Month", model.Month);
                Parametor.Add("@Year", model.Year);
                Parametor.Add("@WTypeId", model.WTypeId);
                Parametor.Add("@EmployementId", model.EmpType);
                Parametor.Add("@ProcId", 1);
                Parametor.Add("@OfficeId", SessionManager.OfficeID);
                Parametor.Add("@UserId", SessionManager.UserId);
                Parametor.Add("@DepartmentId", SessionManager.DepId);
                Parametor.Add("@SubDeptId", 0);
                List<SelectListItem> List = _dapper.GetAll<SelectListItem>("Proc_GetFillDropDownFrmPayRegister", Parametor);
                return List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SelectListItem> Getfilldepartment1(RptEmpLicdetail model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Month", model.Month);
                Parametor.Add("@Year", model.Year);
                if (model.WTypeId == 2)
                {
                    Parametor.Add("@ProcId", 5);
                }
                else if (model.WTypeId == 4)
                {
                    Parametor.Add("@ProcId", 6);
                }

                Parametor.Add("@OfficeId", SessionManager.OfficeID);
                Parametor.Add("@UserId", SessionManager.UserId);
                Parametor.Add("@DepartmentId", SessionManager.DepId);

                List<SelectListItem> List = _dapper.GetAll<SelectListItem>("Proc_GetFillDropDown", Parametor);
                return List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dynamic GetRptEmpLicDetail(RptEmpLicdetail model)
        {
            RptEmpLicdetail obj = new RptEmpLicdetail();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {

                try
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@WType", model.WTypeId);
                    queryParameters.Add("@month", model.Month);
                    queryParameters.Add("@year", model.Year);
                    queryParameters.Add("@EmpId", model.EmpId);
                    queryParameters.Add("@EmployementId", model.EmpType);
                    queryParameters.Add("@SalaryType", model.SalaryType);
                    queryParameters.Add("@SubDeptId", model.Fk_SubDeptId);
                    queryParameters.Add("@DepartmentId", model.Fk_DepartmentId);
                    queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                    if (model.WTypeId == 2)
                    {
                        queryParameters.Add("@Table", "SamvidaPayRegister");
                    }
                    else
                    {
                        queryParameters.Add("@Table", "PayRegister");
                    }
                    if (model.Month.Length == 1)
                    {
                        queryParameters.Add("@YrMon", model.Year + 0 + model.Month);
                    }
                    else
                    {
                        queryParameters.Add("@YrMon", model.Year + "" + model.Month);
                    }

                    var redar = con.QueryMultiple("Employee_LicReport", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var Vm = redar.Read<RptEmpLicdetail>().ToList();
                    var Vl = redar.Read<RptEmpLicdetail1>().ToList();
                    var Vll = redar.Read<RptEmpLicdetail2>().ToList();

                    obj.RptEmpLicdetailList = Vm;
                    obj.RptEmpLicdetailList1 = Vl;
                    obj.RptEmpLicdetailList2 = Vll;

                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        public static AdvanceLoan GetAdvLoanDetail(AdvanceLoan model)
        {
            AdvanceLoan _iresult = new AdvanceLoan();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpId", model.Fk_EmpId);
                queryParameters.Add("@type", model.Type);
                queryParameters.Add("@Status", model.QryP);
                queryParameters.Add("@UserId", SessionManager.OfficeID);
                List<AdvanceLoan> List = DBHelperDapper.DAAddAndReturnModelList<AdvanceLoan>("AdvLoanReport", queryParameters);
                _iresult.List = List;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Rptemppayment GetRptemppaymentDetail(Rptemppayment model)
        {
            Rptemppayment _iresult = new Rptemppayment();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Wtypeid", model.WTypeId);
                queryParameters.Add("@UserId", SessionManager.UserId);
                queryParameters.Add("@month", model.Month);
                queryParameters.Add("@year", model.Year);
                queryParameters.Add("@BankId", model.BankId);
                queryParameters.Add("@PageIndex", 1);
                queryParameters.Add("@PageSize", 10);
                queryParameters.Add("@RegTypeList", model.checkSelect);
                queryParameters.Add("@Salarytype", model.SalaryType);
                queryParameters.Add("@Total", model.Total, System.Data.DbType.String, System.Data.ParameterDirection.Output);
                List<Rptemppayment> list = DBHelperDapper.DAAddAndReturnModelList<Rptemppayment>("GetEmpPaymentPageWise", queryParameters);
                _iresult.RptemppaymentList = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DeductionReport DeductionReport(DeductionReport model)
        {
            DeductionReport _result = new DeductionReport();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DedType", model.DeductionType);
                queryParameters.Add("@SalaryType", model.SalaryType);
                queryParameters.Add("@BillDate", model.BillDate);
                queryParameters.Add("@Month", model.Month);
                queryParameters.Add("@Year", model.Year);
                queryParameters.Add("@EmployementId", model.EmpType);
                queryParameters.Add("@WtypeId", model.WTypeId);
                queryParameters.Add("@DepartmentId", model.Fk_DepartmentId);
                queryParameters.Add("@SubDeparId", model.Fk_SubDeptId);
                queryParameters.Add("@EmpId", model.EmpId);
                queryParameters.Add("@OrderBy", model.OrderBy);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                List<DeductionReport> List = DBHelperDapper.DAAddAndReturnModelList<DeductionReport>("Get_Deductiondetail", queryParameters);
                _result.List = List;
                return _result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Salary Bill Summary Sub-Department Wise - Custom 
        //public static RptSubDepWiseSummaryCustom GetULBHeadWiseSalaryBillDetails(RptSubDepWiseSummaryCustom model)
        //{
        //    RptSubDepWiseSummaryCustom _iresult = new RptSubDepWiseSummaryCustom();
        //    try
        //    {
        //        var queryParameters = new DynamicParameters();
        //        //queryParameters.Add("@OfficeId", model.ULBName);
        //        //queryParameters.Add("@PayMonth", model.Month);
        //        //queryParameters.Add("@PayYear", model.Year);
        //        //queryParameters.Add("@subdeptid", model.Fk_SubDeptId);
        //        //if(model.WTypeId==2)
        //        //{
        //        //    queryParameters.Add("@ProcId", 7);
        //        //}
        //        //else
        //        //{
        //        //    queryParameters.Add("@ProcId", 6);
        //        //}

        //        //queryParameters.Add("@EmpId", model.EmpId);
        //        //queryParameters.Add("@DepartmentId", model.Fk_DepartmentId);
        //        //queryParameters.Add("@WTypeId", model.WTypeId);
        //        //queryParameters.Add("@EmployementId", model.EmpType);
        //        //queryParameters.Add("@OrderBy", 1);
        //        //queryParameters.Add("@SalaryType", model.SalaryType);

        //        queryParameters.Add("@OfficeId", 537);
        //        queryParameters.Add("@PayMonth", 11);
        //        queryParameters.Add("@PayYear", 2020);
        //        queryParameters.Add("@subdeptid", 6821);
        //        queryParameters.Add("@ProcId", 1);
        //        queryParameters.Add("@EmpId", 9);
        //        queryParameters.Add("@DepartmentId", 6764);
        //        queryParameters.Add("@WTypeId", 1);
        //        queryParameters.Add("@EmployementId", 0);
        //        queryParameters.Add("@OrderBy", 1);
        //        queryParameters.Add("@SalaryType", 'C');
        //        List<RptSubDepWiseSummaryCustom> list = DBHelperDapper.DAAddAndReturnModelList<RptSubDepWiseSummaryCustom>("Proc_ULBHeadWiseSalaryBill", queryParameters);
        //        _iresult.RptSubDepWiseSummaryCustomList = list;
        //        return _iresult;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        public List<SelectListItem> GetSections(Rptemppayment model)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Worktypeid", model.WTypeId);
                queryParameters.Add("@ProcId", 1);
                queryParameters.Add("@Department", SessionManager.DepId);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Proc_GetDepartmentAndOthers", queryParameters);
                return _iresult;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region SalarySummery 
        public static SalarySummery GetRptSalarySummery(SalarySummery model)
        {
            SalarySummery _iresult = new SalarySummery();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DeptId", model.Fk_DepartmentId);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                queryParameters.Add("@Month", model.Month);
                queryParameters.Add("@Year", model.Year);
                List<SalarySummery> list = DBHelperDapper.DAAddAndReturnModelList<SalarySummery>("Proc_SalarySummery", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Salary Bill Summary Sub-Department Wise - Custom 


        public DataSet GetULBHeadWiseSalaryBillDetails(RptSubDepWiseSummaryCustom obj)
        {
            var ProcId = 0;
            if (obj.WTypeId == 2)
            {
                ProcId = 7;
            }
            else
            {
                ProcId = 6;
            }
            SqlParameter[] Para =
             {
                new SqlParameter("@OfficeId", SessionManager.OfficeID),
                new SqlParameter("@PayMonth", obj.Month),
                new SqlParameter("@PayYear", obj.Year),
                new SqlParameter("@subdeptid", obj.Fk_SubDeptId),

                new SqlParameter("@ProcId",ProcId),

                new SqlParameter("@EmpId", obj.EmpId),
                new SqlParameter("@DepartmentId", obj.Fk_DepartmentId),
                new SqlParameter("@WTypeId", obj.WTypeId),
                new SqlParameter("@EmployementId", obj.EmpType),
                new SqlParameter("@OrderBy", 1),
                new SqlParameter("@SalaryType", obj.SalaryType),
              };
            DataSet ds = DBHelperDapper.ExecuteQuery("Proc_ULBHeadWiseSalaryBill", Para);
            return ds;
        }
        #endregion

        #region Salary Bill Summary Department Wise - Custom 


        public DataSet GetULBHeadWiseSalaryBillDetails1(RptDepWiseSummaryCustom obj)
        {

            SqlParameter[] Para =
             {
                new SqlParameter("@OfficeId", SessionManager.OfficeID),
                new SqlParameter("@PayMonth", obj.Month),
                new SqlParameter("@PayYear", obj.Year),
                new SqlParameter("@subdeptid", obj.Fk_SubDeptId),

                new SqlParameter("@ProcId",5),

                new SqlParameter("@EmpId", obj.EmpId),
                new SqlParameter("@DepartmentId", obj.Fk_DepartmentId),
                new SqlParameter("@WTypeId", obj.WTypeId),
                new SqlParameter("@EmployementId", obj.EmpType),
                new SqlParameter("@OrderBy", 1),
                new SqlParameter("@SalaryType", obj.SalaryType),
              };
            DataSet ds = DBHelperDapper.ExecuteQuery("Proc_ULBHeadWiseSalaryBill", Para);
            return ds;
        }
        #endregion

        #region Salary Bill Summary Designation Wise - Custom 


        public DataSet GetULBHeadWiseSalaryBillDetails2(DesigWiseSummery obj)
        {
            var ProcId = 0;
            if (obj.WTypeId == 2)
            {
                ProcId = 9;
            }
            else
            {
                ProcId = 8;
            }
            SqlParameter[] Para =
             {
                new SqlParameter("@OfficeId", SessionManager.OfficeID),
                new SqlParameter("@PayMonth", obj.Month),
                new SqlParameter("@PayYear", obj.Year),
                new SqlParameter("@subdeptid", obj.Fk_SubDeptId),
                new SqlParameter("@ProcId",ProcId),
                new SqlParameter("@EmpId", obj.EmpId),
                new SqlParameter("@DepartmentId", obj.Fk_DepartmentId),
                new SqlParameter("@WTypeId", obj.WTypeId),
                new SqlParameter("@EmployementId", obj.EmpType),
                new SqlParameter("@OrderBy", 1),
                new SqlParameter("@SalaryType", obj.SalaryType),
              };
            DataSet ds = DBHelperDapper.ExecuteQuery("Proc_ULBHeadWiseSalaryBill", Para);
            return ds;
        }
        #endregion

        #region Supplementary Bill Report - Custom 


        public DataSet GetULBHeadWiseSupplementaryBillDetails(SupplementaryReport obj)
        {
            var ProcId = 0;
            if (obj.WTypeId == 1)
            {
                ProcId = 1;
            }
            else if (obj.WTypeId == 2)
            {
                ProcId = 2;
            }
            else if (obj.WTypeId == 4)
            {
                ProcId = 4;
            }
            else if (obj.WTypeId == 5)
            {
                ProcId = 3;
            }
            else
            {
                ProcId = 0;
            }
            SqlParameter[] Para =
             {
                new SqlParameter("@OfficeId", SessionManager.OfficeID),
                new SqlParameter("@PayMonth", obj.FromMonth),
                new SqlParameter("@PayYear", obj.FromYear),
                new SqlParameter("@Tomonth", obj.Month),
                new SqlParameter("@ToYear", obj.Year),
                new SqlParameter("@subdeptid", obj.Fk_SubDeptId),
                new SqlParameter("@ProcId",ProcId),
                new SqlParameter("@EmpId", obj.EmpId),
                new SqlParameter("@DepartmentId", obj.Fk_DepartmentId),
                new SqlParameter("@WTypeId", obj.WTypeId),
                new SqlParameter("@EmployementId", obj.EmpType),
                new SqlParameter("@OrderBy", obj.OrderBy),
                new SqlParameter("@SalaryType", "S"),

              };
            DataSet ds = DBHelperDapper.ExecuteQuery("Proc_ULBHeadWiseSupplementaryBill", Para);
            return ds;
        }
        #endregion

        #region Salary Bill Report
        public DataSet GetULBHeadWiseSalaryBillDetails3(SalaryBill obj)
        {
            var procId = 0;
            if (obj.WTypeId == 1)
            {
                procId = 1;
            }
            else if (obj.WTypeId == 2)
            {
                procId = 2;
            }
            else if (obj.WTypeId == 4)
            {
                procId = 4;
            }
            else
            {
                procId = 3;
            }
            SqlParameter[] Para =
             {
                new SqlParameter("@OfficeId", SessionManager.OfficeID),
                new SqlParameter("@PayMonth", obj.Month),
                new SqlParameter("@PayYear", obj.Year),
                new SqlParameter("@subdeptid", obj.Fk_SubDeptId),

                new SqlParameter("@ProcId",procId),

                new SqlParameter("@EmpId", obj.EmpId),
                new SqlParameter("@DepartmentId", obj.Fk_DepartmentId),
                new SqlParameter("@WTypeId", obj.WTypeId),
                new SqlParameter("@EmployementId", obj.EmpType),
                new SqlParameter("@OrderBy", obj.OrderBy),
                new SqlParameter("@SalaryType", obj.SalaryType),
              };
            DataSet ds = DBHelperDapper.ExecuteQuery("Proc_ULBHeadWiseSalaryBill", Para);
            return ds;
        }

        public SalaryBill GetSalaryBillReport()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                // queryParameter.Add("@OfficeId", 2);
                SalaryBill obj = DBHelperDapper.DAAddAndReturnModel<SalaryBill>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion
        #region Employee Leave Delete 
        public List<SelectListItem> GetEmployee(EmpLeaveSuspendDelete model)
        {
            try
            {
                var query = new DynamicParameters();

                query.Add("@OfficeId", SessionManager.OfficeID);
                query.Add("@WtypeId", model.WtypeId);

                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Proc_Bind_Emp", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static EmpLeaveSuspendDelete ReportLeaveDelete(string EmpId, string Month, string Year, string LeaveType)
        {
            EmpLeaveSuspendDelete _iresult = new EmpLeaveSuspendDelete();
            try
            {
                if (string.IsNullOrEmpty(EmpId))
                {
                    EmpId = "0";
                }
                if (string.IsNullOrEmpty(Month))
                {
                    Month = "0";
                }
                if (string.IsNullOrEmpty(Month))
                {
                    Month = "0";
                }
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpId", Convert.ToInt32(EmpId));
                queryParameters.Add("@LeaveType", LeaveType);
                queryParameters.Add("@Month", Convert.ToInt32(Month));
                queryParameters.Add("@Year", Convert.ToInt32(Year));
                List<EmpLeaveSuspendDelete> list = DBHelperDapper.DAAddAndReturnModelList<EmpLeaveSuspendDelete>("Report_LeaveDelete", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public EmpLeaveSuspendDelete LeaveDelete(EmpLeaveSuspendDelete model)
        {

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpId", model.EmpId);
                queryParameters.Add("@Id", model.DeleteID);
                queryParameters.Add("@Month", model.Month);
                queryParameters.Add("@Year", model.Year);
                EmpLeaveSuspendDelete model1 = DBHelperDapper.DAAddAndReturnModel<EmpLeaveSuspendDelete>("Proc_LeaveDelete", queryParameters);

                return model1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion



        public List<SelectListItem> GetDepartmentByMonthAndYear(string Year, string Month, int proc)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Year", Convert.ToInt32(Year));
                queryParameters.Add("@Month", Convert.ToInt32(Month));
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                queryParameters.Add("@proc", proc);
                queryParameters.Add("@deptId", SessionManager.DepId);

                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("GetDepartmentByMonth", queryParameters);
                return _iresult;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static dynamic DisplaySalaryBillReport(SalaryReport model, int offcieId)
        {
            SalaryReport obj = new SalaryReport();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {

                try
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@DivisionId", model.District);
                    queryParameters.Add("@DepTypeList", model.Fk_SubDeptId);
                    queryParameters.Add("@OfficeHeadId", model.ULBType);
                    queryParameters.Add("@OfficeId", model.ULBName);

                    queryParameters.Add("@Month", model.Month);
                    queryParameters.Add("@Year", model.Year);
                    queryParameters.Add("@PageIndex", 10);
                    queryParameters.Add("@salarytype", model.salarytype);
                    // queryParameters.Add("@RecordCount", model.Total, System.Data.DbType.String, System.Data.ParameterDirection.Output);
                    if (model.chknps != 0 && model.chkpen != 0 && model.chknps == model.chkpen)
                    {
                        queryParameters.Add("@IsNPS", 3);
                    }
                    else if (model.chkpen == 1)
                    {
                        queryParameters.Add("@IsNPS", 2);
                    }
                    else if (model.chknps == 1)
                    {
                        queryParameters.Add("@IsNPS", 1);
                    }
                    else
                    {
                        queryParameters.Add("@IsNPS", 0);
                    }

                    queryParameters.Add("@OrderBy", Convert.ToInt32(model.OrderBy));
                    queryParameters.Add("RecordCount", SqlDbType.Int, (DbType?)4);
                    queryParameters.Add("@ID", offcieId);
                    queryParameters.Add("@IsOffice", model.IsDepot);

                    var redar = con.QueryMultiple("GetTreasuryBillPageWise_Ulb", queryParameters, commandType: System.Data.CommandType.StoredProcedure);

                    var list1 = redar.Read<SalaryReport1>().ToList();
                    var list2 = redar.Read<TreasuryBillSummary>().ToList();
                    var list3 = redar.Read<TreasuryBillBankWiseSummary>().ToList();
                    var list4 = redar.Read<HQGPFSummary>().ToList();
                    var Subdepartment = redar.Read<string>().ToList();
                    obj.SalaryReports = list1;
                    obj.TreasuryBillSummary = list2;
                    obj.TreasuryBillBankWiseSummary = list3;
                    obj.SubDepartmentlst = Subdepartment;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }




        public static dynamic GetTreasuryBillSummary(SalaryReport model)
        {
            SalaryReport obj = new SalaryReport();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@DivisionId", model.District);
                    queryParameters.Add("@DepTypeList", model.Fk_SubDeptId);
                    queryParameters.Add("@OfficeHeadId", model.ULBType);
                    queryParameters.Add("@OfficeId", model.ULBName);
                    queryParameters.Add("@Month", model.Month);
                    queryParameters.Add("@Year", model.Year);
                    queryParameters.Add("@Status", model.salarytype);
                    queryParameters.Add("RecordCount", SqlDbType.Int, (DbType?)4);
                    var redar = con.QueryMultiple("GetSamvidaBillPageWise", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var list1 = redar.Read<SalaryReport1>().ToList();
                    var list2 = redar.Read<TreasuryBillSummary>().ToList();
                    var list3 = redar.Read<TreasuryBillBankWiseSummary>().ToList();
                    var Subdepartment = redar.Read<string>().ToList();
                    obj.SalaryReports = list1;
                    obj.TreasuryBillSummary = list2;
                    obj.TreasuryBillBankWiseSummary = list3;
                    obj.SubDepartmentlst = Subdepartment;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }


        public static dynamic GetPensionersBillSummary(SalaryReport model)
        {
            SalaryReport obj = new SalaryReport();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@DivisionId", model.District);
                    queryParameters.Add("@DepTypeList", model.Fk_SubDeptId);
                    queryParameters.Add("@OfficeHeadId", model.ULBType);
                    queryParameters.Add("@OfficeId", model.ULBName);
                    queryParameters.Add("@Month", model.Month);
                    queryParameters.Add("@Year", model.Year);
                    queryParameters.Add("@salarytype", "C");
                    queryParameters.Add("RecordCount", SqlDbType.Int, (DbType?)4);
                    var redar = con.QueryMultiple("GetPensionerBill", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var list1 = redar.Read<PensionerBill>().ToList();
                    var list2 = redar.Read<PensionerSummry>().ToList();
                    var list3 = redar.Read<TreasuryBillBankWiseSummary>().ToList();
                    var Subdepartment = redar.Read<string>().ToList();
                    obj.PensionerBill = list1;
                    obj.PensionerSummry = list2;
                    obj.TreasuryBillBankWiseSummary = list3;
                    obj.SubDepartmentlst = Subdepartment;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public PaySlip RptHQEmpPaySlip(PaySlip model)
        {

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@UserId", SessionManager.UserId);
                queryParameters.Add("@RegTypeId", SessionManager.DepId);
                queryParameters.Add("@EmpId", SessionManager.EmpId);
                queryParameters.Add("@AllEmp", "E");
                queryParameters.Add("@Month", model.Month);
                queryParameters.Add("@Year", model.Year);
                queryParameters.Add("@PageIndex", 1);
                queryParameters.Add("@PageSize", 10);
                queryParameters.Add("@RecordCount", 1);
                PaySlip model1 = DBHelperDapper.DAAddAndReturnModel<PaySlip>("GetHQPaySlipPageWise", queryParameters);

                return model1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PaySlip ContPaySlip(PaySlip model)
        {

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@UserId", SessionManager.UserId);
                queryParameters.Add("@DepartmentID", SessionManager.DepId);
                queryParameters.Add("@EmpId", SessionManager.EmpId);
                queryParameters.Add("@AllEmp", "I");
                queryParameters.Add("@Month", model.Month);
                queryParameters.Add("@Year", model.Year);
                queryParameters.Add("@PageIndex", 1);
                queryParameters.Add("@PageSize", 10);
                queryParameters.Add("@RecordCount", 1);
                PaySlip model1 = DBHelperDapper.DAAddAndReturnModel<PaySlip>("GetContractualPaySlip", queryParameters);

                return model1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PaySlip RptDPPaySlip(PaySlip model)
        {

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@UserId", SessionManager.UserId);
                queryParameters.Add("@DepartmentID", SessionManager.DepId);
                queryParameters.Add("@EmpId", SessionManager.EmpId);
                queryParameters.Add("@AllEmp", "I");
                queryParameters.Add("@Month", model.Month);
                queryParameters.Add("@Year", model.Year);
                queryParameters.Add("@PageIndex", 1);
                queryParameters.Add("@PageSize", 10);
                queryParameters.Add("@RecordCount", 1);
                PaySlip model1 = DBHelperDapper.DAAddAndReturnModel<PaySlip>("GetPaySlipPageWise", queryParameters);

                return model1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region  



        public static EmpLeaveDelete GetEmployeeSalary(EmpLeaveDelete model)
        {
            EmpLeaveDelete _iresult = new EmpLeaveDelete();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WType", model.SelectType);
                queryParameters.Add("@SalaryType", model.SalaryType);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                queryParameters.Add("@AccountNo", model.AccountNo);
                queryParameters.Add("@Paymonth", model.Month);
                queryParameters.Add("@Payyear", model.Year);
                queryParameters.Add("@AccountNo", model.AccountNo);
                List<EmpLeaveDelete> list = DBHelperDapper.DAAddAndReturnModelList<EmpLeaveDelete>("SP_Employee_SalaryDeleteReport", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmpLeaveDelete SalaryDelete(EmpLeaveDelete model)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WType", model.SelectType);
                queryParameters.Add("@SalaryType", model.SalaryType);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                queryParameters.Add("@pfmscode", model.PFMSCode);
                queryParameters.Add("@Paymonth", model.Month);
                queryParameters.Add("@Payyear", model.Year);
                model = DBHelperDapper.DAAddAndReturnModel<EmpLeaveDelete>("Employee_Salarydelete", queryParameters);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region 
        public FrmFinalizeData GetFrmFinalizeData()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                // queryParameter.Add("@OfficeId", 2);
                FrmFinalizeData obj = DBHelperDapper.DAAddAndReturnModel<FrmFinalizeData>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Finalize Data
        public static FrmFinalizeData GetFinalizeData(FrmFinalizeData model)
        {
            FrmFinalizeData _iresult = new FrmFinalizeData();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WtypeId", model.WTypeId);
                queryParameters.Add("@salarytype", model.SalaryType); 
                queryParameters.Add("@departmentId", model.Fk_DepartmentId);
                queryParameters.Add("@subdepartmentId", model.Fk_SubDeptId);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                queryParameters.Add("@Month", model.Month);
                queryParameters.Add("@Year", model.Year);
                List<FrmFinalizeData1> list = DBHelperDapper.DAAddAndReturnModelList<FrmFinalizeData1>("Fetch_FinalizeData", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public FrmFinalizeData FinalizeData(FrmFinalizeData model)
        {

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WTypeId", model.WTypeId); 
                queryParameters.Add("@DepartmentID", model.Fk_DepartmentId);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                queryParameters.Add("@FinalMonth", model.Month);
                queryParameters.Add("@FinalYear", model.Year);
                FrmFinalizeData model1 = DBHelperDapper.DAAddAndReturnModel<FrmFinalizeData>("Proc_FinalizeData1", queryParameters);

                return model1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        

        #region FrmUnsettleData

        public static FrmUnsettleData GetUnsettleData(FrmUnsettleData model)
        {
            FrmUnsettleData _iresult = new FrmUnsettleData();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WtypeId", model.WTypeId);
                queryParameters.Add("@salarytype", model.SalaryType); 
                queryParameters.Add("@departmentId", model.Fk_DepartmentId);
                queryParameters.Add("@subdepartmentId", model.Fk_SubDeptId);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                queryParameters.Add("@Month", model.Month);
                queryParameters.Add("@Year", model.Year);
                List<FrmUnsettleData1> list = DBHelperDapper.DAAddAndReturnModelList<FrmUnsettleData1>("Fetch_UnsettleData", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FrmUnsettleData UnsettleData(FrmUnsettleData model)
        {

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WTypeId", model.WTypeId); 
                queryParameters.Add("@DepartmentID", model.Fk_DepartmentId);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                queryParameters.Add("@FinalMonth", model.Month);
                queryParameters.Add("@FinalYear", model.Year); 
                FrmUnsettleData model1 = DBHelperDapper.DAAddAndReturnModel<FrmUnsettleData>("Proc_UnsettleData", queryParameters);

                return model1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region GenExcelForBonus  
        public List<ExcelForBonusList> GenerateExcelforBonus(ExcelForBonus model)
        {

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WTypeId", model.WTypeId); 
                queryParameters.Add("@DepartmentID", model.Fk_DepartmentId);
                queryParameters.Add("@SubDepartmentID", model.Fk_SubDeptId);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                //queryParameters.Add("@orderby", model.OrderBy);
                queryParameters.Add("@Year", model.Year);
                List<ExcelForBonusList> List = DBHelperDapper.DAAddAndReturnModelList<ExcelForBonusList>("GenerateExcelforBonus", queryParameters);

                return List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        public dynamic BindEmployeeDetailDropdownDW(DAilyWagesEarDed model)
        {
            DAilyWagesEarDed obj = new DAilyWagesEarDed();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {

                try
                {
                    var queryParameter = new DynamicParameters();
                    queryParameter.Add("@EmpId", model.EmpId);
                    var redar = con.QueryMultiple("GetEmpdetailforDailyWagesEarnings", queryParameter, commandType: System.Data.CommandType.StoredProcedure);
                    var Vm = redar.Read<DAilyWagesEarDed>().FirstOrDefault();
                    obj = Vm;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}

