using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using DESDrawing.Models.DBRepository;
using DESDrawing.Models;
using System.Web.Mvc;

namespace DESDrawing.Models.DBRepository
{
    public class CustomerDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();
        #region Customer Register (Shalini)
        public Customer CustomerReg(Customer model)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Customer_Name",model.Customer_Name);
                queryParameters.Add("@Email",model.Email);
                queryParameters.Add("@Password",model.Password);
                queryParameters.Add("@Phone_Number",model.Phone_Number);
                queryParameters.Add("@FK_District_id", model.FK_District_id);
                queryParameters.Add("@Create_by",model.Create_by);
                Customer _iresult = _dapper.Execute<Customer>("Insert_Customer", queryParameters);
                return _iresult;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public List<SelectListItem> BindDistrictDropdown()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_binddistrict", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Customer Login (Shalini)
        public Customer CheckCustomerLogin(Customer model)
        {
            try
            {
                var Parameter = new DynamicParameters();
                Parameter.Add("@mobile", model.Phone_Number);
                Parameter.Add("@Password", model.Password);
                Customer obj = _dapper.Execute<Customer>("Check_CustomerLogin", Parameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion
    }
}