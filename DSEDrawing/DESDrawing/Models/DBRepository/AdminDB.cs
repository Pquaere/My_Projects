using Dapper;
using DESDrawing.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESDrawing.Models.DBRepository
{
    public class AdminDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();

        #region Admin USER MASTER

        //public Dashboard Dashboard()
        //{
        //    try
        //    {
        //        var Parametor = new DynamicParameters();
        //        Dashboard details = _dapper.Execute<Dashboard>("Fetch_Admin_Dashboard", Parametor);
        //        return details;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}

        public List<Users> ListUsers()
        {
            try
            {
                var query = new DynamicParameters();
                List<Users> objlist = _dapper.GetAll<Users>("Fetch_Users", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Users changeuserstatus(Users model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.UserID);
                Parametor.Add("@IsActive", model.Isactive);
                Users DelCity = _dapper.Execute<Users>("SetStatus_User", Parametor);
                return DelCity;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<SelectListItem> BindCityList()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            try
            {
                var param = new DynamicParameters();

                obj = _dapper.GetAll<SelectListItem>("proc_bindcity", param);
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> BindDisctrictList()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            try
            {
                var param = new DynamicParameters();

                obj = _dapper.GetAll<SelectListItem>("proc_binddistrict", param);
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Users GetUserDetails(int? ID)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_Id", ID);
                Users details = _dapper.Execute<Users>("Fetch_Users", Parametor);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Users SaveUser(Users model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@UserName", model.UserName);
                Parametor.Add("@Password", model.Password);
                Parametor.Add("@Role", model.RoleID);
                Parametor.Add("@FullName", model.Fullname);
                Parametor.Add("@Mobile", model.Mobile);
                Parametor.Add("@Email", model.Email);
                Parametor.Add("@Address", model.Address);
                Parametor.Add("@FK_Discom_Id", model.DiscomId);
                Parametor.Add("@FK_Region_Id", model.RegionId);
                Parametor.Add("@FK_Zone_Id", model.ZoneId);
                Parametor.Add("@FK_District_Id", model.DistrictId);
                Parametor.Add("@Pincode", model.Pincode);
                Parametor.Add("@Created_By", SessionManager.UserId);
                Users save = _dapper.Execute<Users>("Register_User", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Users UpdateUser(Users model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@UserName", model.UserName);
                Parametor.Add("@Password", model.Password);
                Parametor.Add("@Role", model.RoleID);
                Parametor.Add("@FullName", model.Fullname);
                Parametor.Add("@Mobile", model.Mobile);
                Parametor.Add("@Email", model.Email);
                Parametor.Add("@Address", model.Address);
                Parametor.Add("@FK_Discom_Id", model.DiscomId);
                Parametor.Add("@FK_Region_Id", model.RegionId);
                Parametor.Add("@FK_Zone_Id", model.ZoneId);
                Parametor.Add("@FK_District_Id", model.DistrictId);
                Parametor.Add("@Pincode", model.Pincode);
                Parametor.Add("@Pk_ID", model.UserID);
                Parametor.Add("@Updated_By", SessionManager.UserId);
                Users CityList = _dapper.Execute<Users>("Update_Register_User", Parametor);
                return CityList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<SelectListItem> GetRegions(int DiscomId)
        {
            try
            {
                var Parametor = new DynamicParameters();

                Parametor.Add("@DiscomId", DiscomId);
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("proc_bindRegion_byid", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<SelectListItem> GetCities(int FK_State_id)
        {
            try
            {
                var Parametor = new DynamicParameters();

                Parametor.Add("@FK_State_id", FK_State_id);
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("proc_bindcity_byid", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<SelectListItem> GetDiscomeOffice()
        {
            try
            {
                var Parametor = new DynamicParameters();
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("proc_bindDiscom", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> GetZones(int RegionId)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@RegionId", RegionId);
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("proc_bindZones_byid", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> GetDistricts(int ZoneId)
        {
            try
            {
                var Parametor = new DynamicParameters();

                Parametor.Add("@ZoneId", ZoneId);
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("proc_bindDistrict_byid", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }
        #endregion
    }
}