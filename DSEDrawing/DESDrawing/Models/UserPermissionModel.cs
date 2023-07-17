using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class UserPermissionModel
    {

    }


    public class FormTypeModel
    {
        public int UserID { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public string PK_FormTypeId { get; set; }
        [Required]
        public string FormType { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public List<FormTypeModel> FormTypeList { get; set; }
    }
    public class FormMasterModel
    {
        public int ID { get; set; }
        public string PK_FormId { get; set; }
        public string FK_FormTypeId { get; set; }
        public string FormTypeName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FormName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<FormMasterModel> FormMasterList { get; set; }
    }
    public class RoleMasterModel
    {
        public string PK_RoleId { get; set; }
        public string RoleName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<RoleMasterModel> RoleMasterList { get; set; }
    }
    public class RolePermissionModel
    {
        public string PK_RolePermissionId { get; set; }
        public int? FK_UserTypeId { get; set; }
        public int? FK_UserId { get; set; }

        public int? FK_RoleId { get; set; }
        public string RoleName { get; set; }
        public string Roll_name { get; set; }

        public int? FK_FormTypeId { get; set; }
        public string FormType { get; set; }

        public int? FK_FormMasterId { get; set; }
        public string FormName { get; set; }

        public bool FormView { get; set; }
        public bool FormSave { get; set; }
        public bool FormUpdate { get; set; }
        public bool FormDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public List<RolePermissionModel> RolePermissionList { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
    }
    public class FormPermissionModel
    {
        public string PK_PermissionId { get; set; }
        public int? FK_UserTypeId { get; set; }
        public int? FK_UserId { get; set; }
        public int? FK_RoleId { get; set; }
        public string RoleName { get; set; }
        public string EmployeeName { get; set; }
        public int? FK_FormTypeId { get; set; }
        public string FormType { get; set; }
        public int? FK_FormId { get; set; }
        public string FormName { get; set; }
        public bool FormView { get; set; }
        public bool FormSave { get; set; }
        public bool FormUpdate { get; set; }
        public bool FormDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int flag { get; set; }
        public string message { get; set; }

        public List<FormPermissionModel> FormPermissionList { get; set; }
        public List<RolePermissionModel> SelectedRoles { get; set; }
    }
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string Role { get; set; }
    }
    public class MenuModel
    {
        public int PK_FormId { get; set; }
        public string FormName { get; set; }
        public string Url { get; set; }

    }
    public class MainMenuModel
    {
        public int PK_FormTypeId { get; set; }
        public string FormType { get; set; }
        public string Icon { get; set; }
        public List<MenuModel> MenuList { get; set; }
    }
    public class EmployeeModel
    {
        public long EmpId { get; set; }
        public string EmpName { get; set; }
    }
    public class MenuPermissionModel
    {
        public int PK_FormTypeId { get; set; }
        public string FormType { get; set; }
        public int PK_FormId { get; set; }
        public string FormName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
    public static class RolePermissionConstant
    {
        public const string PK_RolePermissionId = "PK_RolePermissionId";
        public const string FK_UserTypeId = "FK_UserTypeId";
        public const string FK_RoleId = "FK_RoleId";
        public const string FK_FormTypeId = "FK_FormTypeId";
        public const string FK_FormMasterId = "FK_FormMasterId";
        public const string FormView = "FormView";
        public const string FormSave = "FormSave";
        public const string FormUpdate = "FormUpdate";
        public const string FormDelete = "FormDelete";
        public const string CreatedBy = "CreatedBy";
        public const string UpdatedBy = "UpdatedBy";
        // Stored Procedure
        public const string PK_RoleId = "PK_RollID";
        public const string RoleName = "Roll_name";
        public const string DeletedBy = "DeletedBy";
        public const string isUpdate = "isUpdate";
        public const string RolePermissionGetAll = "RolePermissionGetAll";
        public const string RolePermissionDelete = "RolePermissionDelete";
        public const string RolePermissionFormGetAll = "RolePermissionFormGetAll";
        public const string RolePermissionSave = "RolePermissionSave";
        /// <summary>
        /// RolePermissionSave
        /// </summary>
        public const string RolePermissionUpdate = "RolePermissionUpdate";
        //RolePermissionUpdate
    }
}