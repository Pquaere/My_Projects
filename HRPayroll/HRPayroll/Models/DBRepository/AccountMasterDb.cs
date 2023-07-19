using Dapper;
using HRPayroll.Models.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayroll.Models.DBRepository
{
    public class AccountMasterDb
    {
        DBHelperDapper _dapper = new DBHelperDapper();
        public EmpLogin UserLogin(EmpLogin model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@UserName", model.UserName);
                Parametor.Add("@Password", model.Password);
                EmpLogin obj = _dapper.Execute<EmpLogin>("Login_Details", Parametor);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static EmpLogin ChangePassword(EmpLogin obj)
        {
            EmpLogin chpass = new EmpLogin();
            try
            {
                var Parameter = new DynamicParameters();
                Parameter.Add("@OldPassword", obj.OldPassword);
                Parameter.Add("@NewPassword", obj.NewPassword);
                Parameter.Add("@ConfirmPassword", obj.ConfirmPassword);
                Parameter.Add("@Id", SessionManager.UserId);
                chpass = DBHelperDapper.DAAddAndReturnModel<EmpLogin>("Change_Password", Parameter);
                return chpass;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static EmpLogin ForgotPassword(EmpLogin obj)
        {
            EmpLogin chpass = new EmpLogin();
            try
            {
                var Parameter = new DynamicParameters();
                Parameter.Add("@EmailId", obj.EmailId);
                chpass = DBHelperDapper.DAAddAndReturnModel<EmpLogin>("Forgot_Pasword", Parameter);
                return chpass;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region employee login
        public EmpLogin EmployeeLogin(EmpLogin model)
        {
            try
            {
                string dob = Convert.ToDateTime(model.Dob).ToString("yyyyMMdd");
                var Parametor = new DynamicParameters();
                Parametor.Add("@UserName", model.UserName);
                Parametor.Add("@DOB", dob);
                EmpLogin obj = _dapper.Execute<EmpLogin>("EmployeeLogin", Parametor);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static EmpLogin EmpForgotPassword(EmpLogin obj)
        {
            EmpLogin chpass = new EmpLogin();
            try
            {
                var Parameter = new DynamicParameters();
                Parameter.Add("@EmailId", obj.EmailId);
                chpass = DBHelperDapper.DAAddAndReturnModel<EmpLogin>("EmpForgot_Pasword", Parameter);
                return chpass;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Admin login
        public EmpLogin AdminLogin(EmpLogin model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@UserName", model.UserName);
                Parametor.Add("@Password", model.Password);
                EmpLogin obj = _dapper.Execute<EmpLogin>("AdminLogin", Parametor);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        //public static EmpLogin Employee_ChangePassword(EmpLogin obj)
        //{
        //    EmpLogin chpass = new EmpLogin();
        //    try
        //    {
        //        var Parameter = new DynamicParameters();
        //        Parameter.Add("@OldPassword", obj.OldPassword);
        //        Parameter.Add("@NewPassword", obj.NewPassword);
        //        Parameter.Add("@ConfirmPassword", obj.ConfirmPassword);
        //        Parameter.Add("@Id", SessionManager.UserId);
        //        chpass = DBHelperDapper.DAAddAndReturnModel<EmpLogin>("EmpChange_Password", Parameter);
        //        return chpass;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        #endregion
        public T InsertUpdateAccountType<T>(AccountType obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Company_Id", obj.Company_Id, DbType.Int64);
                dynamicParameters.Add("AC_Name", obj.AC_Name, DbType.String);
                dynamicParameters.Add("Comments", obj.Comments, DbType.String);
                dynamicParameters.Add("AC_Type_Id", obj.AC_Type_Id, DbType.String);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_InsertUpdateAccountType", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAllAccountType<T>(AccountType obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("AC_Type_Id", obj.AC_Type_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModelList<T>("Proc_GetAllAccountType", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetAccountTypeById<T>(AccountType obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("AC_Type_Id", obj.AC_Type_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_GetAllAccountType", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T DeleteAccountTypeById<T>(AccountType obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("AC_Type_Id", obj.AC_Type_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_DeleteAccountTypeById", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T InsertUpdateFinancialYear<T>(FinancialYear obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Company_Id", obj.Company_Id, DbType.Int64);
                dynamicParameters.Add("Fy_Full", obj.Fy_Full, DbType.String);
                dynamicParameters.Add("Fy_Short", obj.Fy_Short, DbType.String);
                dynamicParameters.Add("Start_From", obj.Start_From, DbType.String);
                dynamicParameters.Add("End_On", obj.End_On, DbType.String);
                dynamicParameters.Add("Id", obj.Id, DbType.Int64);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_InsertUpdateFinancialYear", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAllFinancialYear<T>(FinancialYear obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("Id", obj.Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModelList<T>("Proc_GetFinancialYear", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetFinancialYearById<T>(FinancialYear obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("Id", obj.Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_GetFinancialYear", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T DeleteFinancialYearById<T>(FinancialYear obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Id", obj.Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_DeleteFinancialYearById", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T InsertUpdateVoucherTypes<T>(VoucherTypes obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Company_Id", obj.Company_Id, DbType.Int64);
                dynamicParameters.Add("Voucher_Type_Id", obj.Voucher_Type_Id, DbType.Int64);
                dynamicParameters.Add("Voucher_Title", obj.Voucher_Title, DbType.String);
                dynamicParameters.Add("Start_Number", obj.Start_Number, DbType.Int64);
                dynamicParameters.Add("Prefix", obj.Prefix, DbType.String);
                dynamicParameters.Add("FY_Id", obj.FY_Id, DbType.Int64);
                dynamicParameters.Add("Nature", obj.Nature, DbType.String);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_InsertUpdateVoucherTypes", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAllVoucherTypes<T>(VoucherTypes obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("Voucher_Type_Id", obj.Voucher_Type_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModelList<T>("Proc_GetAllVoucherTypes", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetVoucherTypesById<T>(VoucherTypes obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("Voucher_Type_Id", obj.Voucher_Type_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_GetAllVoucherTypes", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T DeleteVoucherTypesById<T>(VoucherTypes obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Voucher_Type_Id", obj.Voucher_Type_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_DeleteVoucherTypesById", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetAllFinancialYear()
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                return DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Proc_GetAllFinancialYear", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetAllAccountType()
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                return DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Proc_BindAccountType", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetAccountGroups()
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                return DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Proc_BindAccountGroup", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T InsertUpdateAccountGroup<T>(AccountGroup obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Group_Id", obj.Group_Id, DbType.Int64);
                dynamicParameters.Add("Account_Group_Name", obj.Account_Group_Name, DbType.String);
                dynamicParameters.Add("Account_Perent_Group_Id", obj.Account_Perent_Group_Id, DbType.Int32);
                dynamicParameters.Add("Ac_Type_Id", obj.Ac_Type_Id, DbType.Int32);
                dynamicParameters.Add("Nature", obj.Nature, DbType.String);
                dynamicParameters.Add("Remarks", obj.Remarks, DbType.String);
                dynamicParameters.Add("IsActive", obj.IsActive, DbType.String);
                dynamicParameters.Add("Is_Primary_Group", obj.Is_Primary_Group, DbType.String);
                dynamicParameters.Add("Group_Level", obj.Group_Level, DbType.String);
                dynamicParameters.Add("Instansable", obj.Instansable, DbType.String);
                dynamicParameters.Add("Created_By", obj.Created_By, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_InsertUpdateAccountGroup", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAllAccountGroup<T>(AccountGroup obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("Group_Id", obj.Group_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModelList<T>("Proc_GetAllAccountGroup", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T DeleteAccountGroupById<T>(AccountGroup obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Group_Id", obj.Group_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_DeleteAccountGroupById", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetAccountGroupById<T>(AccountGroup obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("Group_Id", obj.Group_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_GetAllAccountGroup", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAllAccountLedger<T>(AccountLedger obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("Ledger_Id", obj.Ledger_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModelList<T>("Proc_GetAllAccountLedger", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetAccountLedgerById<T>(AccountLedger obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Page", obj.Page, DbType.Int32);
                dynamicParameters.Add("Size", obj.Size, DbType.Int32);
                dynamicParameters.Add("Ledger_Id", obj.Ledger_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_GetAllAccountLedger", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T InsertUpdateAccountLedger<T>(AccountLedger obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Ledger_Id", obj.Ledger_Id, DbType.Int64);
                dynamicParameters.Add("Ledger_Name", obj.Ledger_Name, DbType.String);
                dynamicParameters.Add("Account_Perent_Group_Id", obj.Account_Perent_Group_Id, DbType.Int32);
                dynamicParameters.Add("Current_Balance", obj.Current_Balance, DbType.String);
                dynamicParameters.Add("CR_DR", obj.CR_DR, DbType.String);
                dynamicParameters.Add("Fy_Id", obj.Fy_Id, DbType.Int32);
                dynamicParameters.Add("Is_Reserved", obj.Is_Reserved, DbType.Int32);
                dynamicParameters.Add("Nature", obj.Nature, DbType.String);
                dynamicParameters.Add("Account_Type", obj.Account_Type, DbType.String);
                dynamicParameters.Add("Depreciation", obj.Depreciation, DbType.String);
                dynamicParameters.Add("CU_VN_Id", obj.CU_VN_Id, DbType.Int32);
                dynamicParameters.Add("Is_Addinlist", obj.Is_Addinlist, DbType.Int32);
                dynamicParameters.Add("Emp_Id", obj.Emp_Id, DbType.Int32);
                dynamicParameters.Add("Company_Id", obj.Company_Id, DbType.Int32);
                dynamicParameters.Add("Created_By", obj.Created_By, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_InsertUpdateAccountLedger", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T DeleteAccountLedgerById<T>(AccountLedger obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Ledger_Id", obj.Ledger_Id, DbType.Int32);
                return DBHelperDapper.DAAddAndReturnModel<T>("Proc_DeleteAccountLedgerById", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}