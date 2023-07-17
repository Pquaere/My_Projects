using Dapper;
using DESDrawing.Models.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DESDrawing.Models.DBRepository
{
    public class AccountDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();

        #region Login (Vaishnavi)
        public AccountModel CheckUserLogin(AccountModel model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Username", model.Username);
                Parametor.Add("@Password", model.Password);
                AccountModel obj = _dapper.Execute<AccountModel>("Check_Login", Parametor);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion
        #region GET USER PERMISSION
        public DataTable GetFormPermissionDetails(int userId)
        {
            SqlParameter[] para = { new SqlParameter("@FK_UserId", userId) };
            DataSet ds = _dapper.ExecuteQuery("FormPermissionDetailsByUserId", para);
            return ds.Tables[0];
        }
        #endregion

        public static AccountModel ChangePassword(AccountModel obj)
        {
            AccountModel chpass = new AccountModel();
            try
            {
                var Parameter = new DynamicParameters();
                Parameter.Add("@OldPassword", obj.OldPassword);
                Parameter.Add("@NewPassword", obj.NewPassword);
                Parameter.Add("@ConfirmPassword", obj.ConfirmPassword);
                Parameter.Add("@Id", SessionManager.UserId);
                chpass = DBHelperDapper.DAAddAndReturnModel<AccountModel>("Change_Password_Director", Parameter);
                return chpass;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static AccountModel CustomerChangePassword(AccountModel obj)
        {
            AccountModel chpass = new AccountModel();
            try
            {
                var Parameter = new DynamicParameters();
                Parameter.Add("@OldPassword", obj.OldPassword);
                Parameter.Add("@NewPassword", obj.NewPassword);
                Parameter.Add("@ConfirmPassword", obj.ConfirmPassword);
                Parameter.Add("@Id", SessionManager.CustomerID);
                chpass = DBHelperDapper.DAAddAndReturnModel<AccountModel>("Change_Password_Customer", Parameter);
                return chpass;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}