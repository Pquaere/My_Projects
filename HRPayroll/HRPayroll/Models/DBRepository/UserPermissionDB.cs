using Dapper;
using HRPayroll.Models.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayroll.Models.DBRepository
{
    public class UserPermissionDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();
        #region --Role Permission --
        public List<SelectListItem> GetFormType()
        {
            try
            {
                var Parametor = new DynamicParameters();
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("proc_bindFormType", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }
        public List<SelectListItem> BindddlRoles()
        {
            try
            {
                var Parametor = new DynamicParameters();
                List<SelectListItem> List = _dapper.GetAll<SelectListItem>("proc_bindrole", Parametor);
                return List;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }       
        public List<RolePermissionModel> BindRolePermissionFormList()
        {
            try
            {
                var Parametor = new DynamicParameters();
                List<RolePermissionModel> objlist = _dapper.GetAll<RolePermissionModel>("RolePermissionFormGetAll", Parametor);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<RolePermissionModel> RolePermissionList()
        {
            UserPermissionDB obj = new UserPermissionDB();
            List<RolePermissionModel> objlist = obj.BindRolePermissionList(null);
            return objlist;
        }
        public List<RolePermissionModel> BindRolePermissionList(int? roleId)
        {
            try
            {
                var Parametor = new DynamicParameters();
                var query = new DynamicParameters();
                Parametor.Add("@FK_RoleId", roleId);
                List<RolePermissionModel> objlist = _dapper.GetAll<RolePermissionModel>("RolePermissionGetAll", Parametor);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public RolePermissionModel SaveRolePermission(RolePermissionModel obj, bool isUpdate = false)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@FK_RoleId", obj.FK_RoleId);
                Parametor.Add("@FK_FormTypeId", obj.FK_FormTypeId);
                Parametor.Add("@FK_FormMasterId", obj.FK_FormMasterId);
                Parametor.Add("@FormView", obj.FormSave);
                Parametor.Add("@FormSave", obj.FormView);
                Parametor.Add("@FormUpdate", obj.FormUpdate);
                Parametor.Add("@FormDelete", obj.FormDelete);
                Parametor.Add("@CreatedBy", SessionManager.UserId);
                Parametor.Add("@FK_UserTypeId", 0);
                Parametor.Add("@isUpdate", isUpdate);
                RolePermissionModel save = _dapper.Execute<RolePermissionModel>("RolePermissionSave", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public RolePermissionModel UpdateRolePermission(RolePermissionModel obj)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_RolePermissionId", obj.PK_RolePermissionId);
                Parametor.Add("@FK_RoleId", obj.FK_RoleId);
                Parametor.Add("@FK_FormTypeId", obj.FK_FormTypeId);
                Parametor.Add("@FK_FormMasterId", obj.FK_FormMasterId);
                Parametor.Add("@FormView", obj.FormSave);
                Parametor.Add("@FormSave", obj.FormView);
                Parametor.Add("@FormUpdate", obj.FormUpdate);
                Parametor.Add("@FormDelete", obj.FormDelete);
                Parametor.Add("@UpdatedBy", SessionManager.UserId);
                RolePermissionModel save = _dapper.Execute<RolePermissionModel>("RolePermissionUpdate", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        
        public RolePermissionModel EditRolePermission(string roleId)
        {
            var lstobj = new List<RolePermissionModel>();
            SqlParameter[] Para =
                {
                new SqlParameter("@FK_RoleId",roleId)
            };
            RolePermissionModel obj = new RolePermissionModel();
            DataSet ds = DBHelperDapper.ExecuteQuery("RolePermissionGetAll", Para);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lstobj.Add(new RolePermissionModel()
                    {
                        RoleName = ds.Tables[0].Rows[i][RolePermissionConstant.RoleName].ToString(),
                        FK_FormTypeId = int.Parse(ds.Tables[0].Rows[i][RolePermissionConstant.FK_FormTypeId].ToString()),
                        PK_RolePermissionId = ds.Tables[0].Rows[i][RolePermissionConstant.PK_RolePermissionId].ToString(),
                        FK_FormMasterId = int.Parse(ds.Tables[0].Rows[i][RolePermissionConstant.FK_FormMasterId].ToString()),
                        FormView = bool.Parse(ds.Tables[0].Rows[i][RolePermissionConstant.FormView].ToString()),
                        FormSave = bool.Parse(ds.Tables[0].Rows[i][RolePermissionConstant.FormSave].ToString()),
                        FormUpdate = bool.Parse(ds.Tables[0].Rows[i][RolePermissionConstant.FormUpdate].ToString()),
                        FormDelete = bool.Parse(ds.Tables[0].Rows[i][RolePermissionConstant.FormDelete].ToString()),
                    });
                }
                obj.FK_RoleId = int.Parse(ds.Tables[0].Rows[0][RolePermissionConstant.FK_RoleId].ToString());
                obj.RolePermissionList = lstobj;
            }

            return obj;
        }
        #endregion

        #region
        public List<SelectListItem> BindUsers()
        {
            try
            {
                var Parametor = new DynamicParameters();
                List<SelectListItem> List = _dapper.GetAll<SelectListItem>("proc_bindusers", Parametor);
                return List;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public List<FormPermissionModel> FormPermissionList()
        {
            try
            {
                var query = new DynamicParameters();
                List<FormPermissionModel> objlist = _dapper.GetAll<FormPermissionModel>("FormPermissionGetAll", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FormPermissionModel DeleteRolePermission(string Id, string DeletedBy)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@FK_UserId", Id);
                param.Add("@DeletedBy", SessionManager.UserId);
                FormPermissionModel objres = _dapper.Execute<FormPermissionModel>("FormPermissionDelete", param);
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FormPermissionModel SaveFormPermission(FormPermissionModel obj, bool isUpdate = false)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@FK_RoleId", obj.FK_RoleId);
                param.Add("@FK_FormTypeId", obj.FK_FormTypeId);
                param.Add("@FK_FormId", obj.FK_FormId);
                param.Add("@FK_UserId", obj.FK_UserId);
                param.Add("@FormView", obj.FormView);
                param.Add("@FormSave", obj.FormSave);
                param.Add("@FormUpdate", obj.FormUpdate);
                param.Add("@FormDelete", obj.FormDelete);
                param.Add("@CreatedBy", obj.CreatedBy);
                param.Add("@isUpdate", isUpdate);
                FormPermissionModel objres = _dapper.Execute<FormPermissionModel>("FormPermissionSave", param);
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FormPermissionModel UpdatesetRolePermission(FormPermissionModel obj)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@FK_RoleId", obj.FK_RoleId);
                param.Add("@PK_PermissionId", obj.PK_PermissionId);
                param.Add("@FK_FormTypeId", obj.FK_FormTypeId);
                param.Add("@FK_FormId", obj.FK_FormId);
                param.Add("@FK_UserId", obj.FK_UserId);
                param.Add("@FormView", obj.FormView);
                param.Add("@FormSave", obj.FormSave);
                param.Add("@FormUpdate", obj.FormUpdate);
                param.Add("@FormDelete", obj.FormDelete);
                param.Add("@CreatedBy", obj.CreatedBy);
                FormPermissionModel objres = _dapper.Execute<FormPermissionModel>("FormPermissionUpdate", param);
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FormPermissionModel EditFormPermission(int userId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@FK_UserId", userId);
                FormPermissionModel objres = _dapper.Execute<FormPermissionModel>("FormPermissionGetByUserId", param);
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }       
        #endregion
    }
}