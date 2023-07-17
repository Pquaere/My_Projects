using Dapper;
using DESDrawing.Models.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESDrawing.Models.DBRepository
{
    public class UserPermissionDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();
        #region --Form Type--
        public List<FormTypeModel> FormTypeList()
        {
            try
            {
                var query = new DynamicParameters();
                List<FormTypeModel> objlist = _dapper.GetAll<FormTypeModel>("FormTypeGetAll", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FormTypeModel changeFormTypestatus(FormTypeModel model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_FormTypeId", model.PK_FormTypeId);
                Parametor.Add("@DeletedBy", SessionManager.UserId);
                FormTypeModel DelCity = _dapper.Execute<FormTypeModel>("FormTypeDelete", Parametor);
                return DelCity;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public FormTypeModel UpdateFormType(FormTypeModel model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_FormTypeId", model.PK_FormTypeId);
                Parametor.Add("@FormType", model.FormType);
                Parametor.Add("@UpdatedBy", SessionManager.UserId);
                FormTypeModel FormTypeModel = _dapper.Execute<FormTypeModel>("FormTypeUpdate", Parametor);
                return FormTypeModel;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public FormTypeModel SaveFormType(FormTypeModel model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@FormType", model.FormType);
                Parametor.Add("@CreatedBy", SessionManager.UserId);
                FormTypeModel save = _dapper.Execute<FormTypeModel>("FormTypeSave", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public FormTypeModel GetFormTypeDetails(int? ID)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_FormTypeId", ID);
                FormTypeModel details = _dapper.Execute<FormTypeModel>("FormTypeGetAll", Parametor);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region --Form Master--
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
        public List<FormMasterModel> FormMasterList()
        {
            try
            {
                var query = new DynamicParameters();
                List<FormMasterModel> objlist = _dapper.GetAll<FormMasterModel>("FormMasterGetAll", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FormMasterModel changeFormMastertatus(FormMasterModel model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_FormId", model.PK_FormId);
                Parametor.Add("@DeletedBy", SessionManager.UserId);
                FormMasterModel DelCity = _dapper.Execute<FormMasterModel>("FormTypeDelete", Parametor);
                return DelCity;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public FormMasterModel UpdateFormMaster(FormMasterModel model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_FormId", model.PK_FormId);
                Parametor.Add("@FK_FormTypeId", model.FK_FormTypeId);
                Parametor.Add("@FormName", model.FormName);
                Parametor.Add("@UpdatedBy", SessionManager.UserId);
                FormMasterModel FormTypeModel = _dapper.Execute<FormMasterModel>("FormMasterUpdate", Parametor);
                return FormTypeModel;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public FormMasterModel SaveFormMaster(FormMasterModel model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@FormName", model.FormName);
                Parametor.Add("@FK_FormTypeId", model.FK_FormTypeId);
                Parametor.Add("@CreatedBy", SessionManager.UserId);
                FormMasterModel save = _dapper.Execute<FormMasterModel>("FormMasterSave", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public FormMasterModel GetFormMasterDetails(string ID)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_FormId", ID);
                FormMasterModel details = _dapper.Execute<FormMasterModel>("FormMasterGetAll", Parametor);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region --Role Master--
        public List<RoleMasterModel> RoleMasterList()
        {
            var query = new DynamicParameters();
            List<RoleMasterModel> objlist = _dapper.GetAll<RoleMasterModel>("RoleMasterGetAll", query);
            return objlist;
        }
        public RoleMasterModel SaveRoleMaster(RoleMasterModel obj)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@RoleName", obj.RoleName);
                Parametor.Add("@CreatedBy", SessionManager.UserId);
                RoleMasterModel save = _dapper.Execute<RoleMasterModel>("RoleMasterSave", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public RoleMasterModel UpdateRoleMaster(RoleMasterModel obj)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@RoleName", obj.RoleName);
                Parametor.Add("@UpdatedBy", SessionManager.UserId);
                Parametor.Add("@PK_RoleId", obj.PK_RoleId);
                RoleMasterModel save = _dapper.Execute<RoleMasterModel>("RoleMasterUpdate", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public RoleMasterModel DeleteRoleMaster(string Id)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_RoleId", Id);
                Parametor.Add("@DeletedBy", SessionManager.UserId);
                RoleMasterModel DelCity = _dapper.Execute<RoleMasterModel>("RoleMasterDelete", Parametor);
                return DelCity;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public RoleMasterModel GetRoleMasterdetails(string id)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_RoleId", id);
                RoleMasterModel details = _dapper.Execute<RoleMasterModel>("RoleMasterGetAll", Parametor);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region --Role Permission --

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
        //public List<SelectListItem> BindRolePermissionFormList()
        //{
        //    try
        //    {
        //        var Parametor = new DynamicParameters();
        //        List<SelectListItem> List = _dapper.GetAll<SelectListItem>("RolePermissionFormGetAll", Parametor);
        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}
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
        //public RolePermissionModel EditRolePermission(string roleId)
        //{
        //    using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
        //    {
        //        try
        //    {
        //        RolePermissionModel obj = new RolePermissionModel();
        //        var Parametor = new DynamicParameters();
        //        Parametor.Add("@FK_RoleId", roleId);
        //            var reader = con.QueryMultiple("RolePermissionGetAll", Parametor, commandType: CommandType.StoredProcedure);
        //            var FK_RoleId = reader.Read<RolePermissionModel>().FirstOrDefault();
        //            var RolePermissionList = reader.Read<RolePermissionModel>().ToList();
        //            obj.FK_RoleId = FK_RoleId;
        //            obj.RolePermissionList = RolePermissionList;
        //            return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}
        public RolePermissionModel EditRolePermission(string roleId)
        {
            var lstobj = new List<RolePermissionModel>();
            SqlParameter[] Para =
                {
                new SqlParameter("@FK_RoleId",roleId)
            };
            RolePermissionModel obj = new RolePermissionModel();
            DataSet ds = _dapper.ExecuteQuery("RolePermissionGetAll", Para);

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
        //public List<RoleModel> BindRoleMaster()
        //{
        //    try
        //    {
        //        var queryParameters = new DynamicParameters();
        //        List<RoleModel> _iresult = _dapper.GetAll<RoleModel>("ProBindRoleMasterForMenuPermission", queryParameters);
        //        return _iresult;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<MainMenuModel> BindAllMenu()
        //{
        //    try
        //    {
        //        List<MainMenuModel> _ObjList = new List<MainMenuModel>();
        //        var queryParameters = new DynamicParameters();
        //        List<MenuPermissionModel> _iresult = _dapper.GetAll<MenuPermissionModel>("ProBindAllMenu", queryParameters);
        //        _ObjList = _iresult.GroupBy(x => x.PK_FormTypeId).Select(x => new MainMenuModel
        //        {
        //            PK_FormTypeId = x.FirstOrDefault().PK_FormTypeId,
        //            FormType = x.FirstOrDefault().FormType,
        //            Icon = x.FirstOrDefault().Icon,
        //            MenuList = x.Select(p => new MenuModel { FormName = p.FormName, PK_FormId = p.PK_FormId, Url = p.Url }).ToList()
        //        }).ToList();

        //        return _ObjList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<EmployeeModel> BindEmpRoleIdWise(int RoleId = 0)
        //{
        //    try
        //    {
        //        var queryParameters = new DynamicParameters();
        //        queryParameters.Add("@RoleId", RoleId);
        //        List<EmployeeModel> _iresult = _dapper.GetAll<EmployeeModel>("ProBindEmpRoleIdWise", queryParameters);
        //        return _iresult;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion
    }
}