using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DESDrawing.Models;
using DESDrawing.Models.Manager;
using DESDrawing.Models.DBRepository;
using DESDrawing.Filter;
//using static microMapV2.Models.DAL.DALCommon;

namespace FamilyN.Areas.Admin.Controllers
{
    [AuthorizeAdmin]
    // [MenuPermissionFilter]
    public class UserPermissionController : Controller
    {
        #region    --------- UserPermission -----------        
        // GET: Admin/UserPermission
        public ActionResult Index()
        {
            return View();
        }

        #region ----------Form Type----------

        [HttpGet]
        public ActionResult FormType(FormTypeModel obj)
        {
            return View(obj);
        }

        public ActionResult FormTypeList()
        {
            UserPermissionDB obj = new UserPermissionDB();
            List<FormTypeModel> listoobj = obj.FormTypeList();
            return View(listoobj);
        }

        public ActionResult FormTypeDelete(bool Isactive, int ID)
        {
            UserPermissionDB obj = new UserPermissionDB();
            FormTypeModel model = new FormTypeModel();
            model.UserID = ID;
            FormTypeModel objresult = obj.changeFormTypestatus(model);
            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
            }
            return RedirectToAction("FormTypeList", "UserPermission");
        }

        [HttpPost]
        public ActionResult FormTypeInsert(FormTypeModel obj)
        {
            UserPermissionDB objrpst = new UserPermissionDB();
            FormTypeModel objresult = new FormTypeModel();
            if (obj.PK_FormTypeId != null)
            {
                objresult = objrpst.UpdateFormType(obj);
            }
            else
            {
                objresult = objrpst.SaveFormType(obj);
            }
            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
                return RedirectToAction("FormType", "UserPermission", obj);
            }
            return RedirectToAction("FormTypeList", "UserPermission");
        }

        public ActionResult FormTypeFill(string id)
        {
            UserPermissionDB objresps = new UserPermissionDB();
            FormTypeModel lstobj = objresps.GetFormTypeDetails(Convert.ToInt32(id));
            return View("FormType", lstobj);
        }
        #endregion

        #region ----------------Form Master--------------

        public ActionResult FormMaster(FormMasterModel model)
        {
            UserPermissionDB obj = new UserPermissionDB();
            ViewBag.ddlFormType = obj.GetFormType();
            return View(model);
        }

        public ActionResult FormMasterList()
        {
            UserPermissionDB obj = new UserPermissionDB();
            List<FormMasterModel> listoobj = obj.FormMasterList();
            return View(listoobj);
        }

        public ActionResult FormMasterDelete(bool Isactive, int ID)
        {
            FormMasterModel obj = new FormMasterModel();
            UserPermissionDB objresps = new UserPermissionDB();
            obj.ID = ID;
            obj = objresps.changeFormMastertatus(obj);
            if (obj.flag != 0 || obj.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = obj.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = obj.message;
            }
            return RedirectToAction("FormMasterList", "UserPermission");
        }

        [HttpPost]
        public ActionResult FormMasterInsert(FormMasterModel obj)
        {
            UserPermissionDB objrpst = new UserPermissionDB();
            FormMasterModel objresult = new FormMasterModel();
            if (obj.PK_FormId !=null)
            {
                objresult = objrpst.UpdateFormMaster(obj);
            }
            else
            {
                objresult = objrpst.SaveFormMaster(obj);
            }
            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
                return RedirectToAction("FormMaster", "UserPermission", obj);
            }
            return RedirectToAction("FormMasterList", "UserPermission");
        }

        public ActionResult FormMasterFill(string id)
        {
            UserPermissionDB objresps = new UserPermissionDB();
            ViewBag.ddlFormType = objresps.GetFormType();
            FormMasterModel obj = new FormMasterModel();
            obj.PK_FormId = id;
            FormMasterModel lstobj = objresps.GetFormMasterDetails(id);
            return View("FormMaster", lstobj);
        }
        #endregion FormMaster

        #region ----------------Role Master--------------

        public ActionResult RoleMaster(RoleMasterModel obj)
        {
            return View(obj);
        }
        public ActionResult RoleMasterList()
        {
            UserPermissionDB obj = new UserPermissionDB();
            List<RoleMasterModel> listoobj = obj.RoleMasterList();
            return View(listoobj);
        }

        [HttpPost]
        public ActionResult RoleMasterInsert(RoleMasterModel obj)
        {
            if (obj.PK_RoleId != null)
            {
                UserPermissionDB objrpst = new UserPermissionDB();
                RoleMasterModel res = new RoleMasterModel();
                res = objrpst.UpdateRoleMaster(obj);
                if (res.flag != 0 || res.flag > 0)
                {
                    TempData["code"] = "1";
                    TempData["Msg"] = res.message;
                }
                else
                {
                    TempData["code"] = "0";
                    TempData["Msg"] = res.message;
                    return RedirectToAction("RoleMaster", "UserPermission", obj);
                }                    
                return RedirectToAction("RoleMasterList", "UserPermission");
            }
            else
            {
                UserPermissionDB objreps = new UserPermissionDB();
                RoleMasterModel res = new RoleMasterModel();
                 res = objreps.SaveRoleMaster(obj);
                if (res.flag != 0 || res.flag > 0)
                {
                    TempData["code"] = "1";
                    TempData["Msg"] = res.message;
                }
                else
                {
                    TempData["code"] = "0";
                    TempData["Msg"] = res.message;
                    return RedirectToAction("RoleMaster", "UserPermission", obj);
                }
                return RedirectToAction("RoleMasterList", "UserPermission");
            }

        }

        public ActionResult RoleMasterDelete(string id)
        {
            RoleMasterModel obj = new RoleMasterModel();
            UserPermissionDB objresps = new UserPermissionDB();
            obj = objresps.DeleteRoleMaster(id);
            if (obj.flag != 0 || obj.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = obj.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = obj.message;
            }
            return RedirectToAction("RoleMasterList", "UserPermission");
        }

        public ActionResult RoleMasterFill(string id)
        {
            RoleMasterModel obj = new RoleMasterModel();
            obj.PK_RoleId = id;
            UserPermissionDB objresps = new UserPermissionDB();
            RoleMasterModel lstobj = objresps.GetRoleMasterdetails(id);
            return View("RoleMaster", lstobj);
        }
        #endregion

        #region ---------------- Role Permission Master --------------

        public ActionResult RolePermission()
        {           
            UserPermissionDB res = new UserPermissionDB();
            ViewBag.ddlRoles = res.BindddlRoles();
            ViewBag.ddlFormType = res.GetFormType();
            ViewBag.RolePermissionFormList = res.BindRolePermissionFormList();
            return View();
        }

        public ActionResult RolePermissionList()
        {
            UserPermissionDB obj = new UserPermissionDB();
            List<RolePermissionModel> listoobj = obj.RolePermissionList().GroupBy(x => x.RoleName).Select(l => l.FirstOrDefault()).ToList();
            return View(listoobj);
        }
        [HttpPost]
        public JsonResult RolePermissionJsonInsert(RolePermissionModel roles)
        {
            if (roles != null)
            {                
                foreach (var obj in roles.RolePermissionList)
                {
                    var rpmObj = new RolePermissionModel();
                    rpmObj.CreatedBy = SessionManager.UserId.ToString();
                    rpmObj.FK_RoleId = obj.FK_RoleId;
                    rpmObj.FK_FormTypeId = obj.FK_FormTypeId;
                    rpmObj.FK_FormMasterId = obj.FK_FormMasterId;
                    rpmObj.FormSave = obj.FormSave;
                    rpmObj.FormUpdate = obj.FormUpdate;
                    rpmObj.FormDelete = obj.FormDelete;
                    rpmObj.FormView = obj.FormView;

                    UserPermissionDB objreps = new UserPermissionDB();
                    RolePermissionModel objres = new RolePermissionModel();
                    objres = objreps.SaveRolePermission(rpmObj);
                    if (objres.flag != 0 || objres.flag > 0)
                    {
                        TempData["code"] = "1";
                        TempData["Msg"] = objres.message;
                    }
                    else
                    {
                        TempData["code"] = "0";
                        TempData["Msg"] = objres.message;
                    }

                }                
            }

            return Json(new { msg = TempData["msg"], code = TempData["code"] }); ;
        }

        public ActionResult RolePermissionFill(string roleId)
        {

            UserPermissionDB rep = new UserPermissionDB();
            ViewBag.ddlRoles = rep.BindddlRoles();
            ViewBag.ddlFormType = rep.GetFormType();
            ViewBag.RolePermissionFormList = rep.BindRolePermissionFormList();
            var obj = new RoleMasterModel();
            obj.PK_RoleId = roleId;
            var objresps = new UserPermissionDB();
            var lstobj = objresps.EditRolePermission(roleId);
            return View("RolePermission", lstobj);
        }
        [HttpPost]
        public JsonResult RolePermissionJsonUpdate(RolePermissionModel roles)
        {
            if (roles != null)
            {
                foreach (var obj in roles.RolePermissionList)
                {
                    var rpmObj = new RolePermissionModel();
                    rpmObj.CreatedBy = SessionManager.UserId.ToString();
                    rpmObj.FK_RoleId = obj.FK_RoleId;
                    rpmObj.FK_FormTypeId = obj.FK_FormTypeId;
                    rpmObj.FK_FormMasterId = obj.FK_FormMasterId;
                    rpmObj.FormSave = obj.FormSave;
                    rpmObj.FormUpdate = obj.FormUpdate;
                    rpmObj.FormDelete = obj.FormDelete;
                    rpmObj.FormView = obj.FormView;
                    var objreps = new UserPermissionDB();
                    RolePermissionModel objres = new RolePermissionModel();
                    if (string.IsNullOrEmpty(obj.PK_RolePermissionId))
                    {
                        objres = objreps.SaveRolePermission(rpmObj, true);
                    }
                    else
                    {
                        rpmObj.PK_RolePermissionId = obj.PK_RolePermissionId;
                        objres = objreps.UpdateRolePermission(rpmObj);
                    }
                    if (objres.flag != 0 || objres.flag > 0)
                    {
                        TempData["code"] = "1";
                        TempData["Msg"] = objres.message;
                    }
                    else
                    {
                        TempData["code"] = "0";
                        TempData["Msg"] = objres.message;
                    }
                }
            }

            return Json(new { msg = TempData["msg"], code = TempData["code"] }); ;
        }
        #endregion
        #region ----------Set Menu Permission------------------
        public ActionResult SetPermission()
        {
            UserPermissionDB obj = new UserPermissionDB();
            ViewBag.ddlRoles = obj.BindddlRoles();
            ViewBag.ddlUsers = obj.BindUsers();
            ViewBag.RolePermissionFormList = obj.BindRolePermissionFormList();
            return View();
        }

        public ActionResult SetPermissionList()
        {
            UserPermissionDB obj = new UserPermissionDB();
            List<FormPermissionModel> listoobj = obj.FormPermissionList().GroupBy(x => x.FK_UserId).Select(l => l.FirstOrDefault()).ToList();
            return View(listoobj);
        }

        public ActionResult SetPermissionDelete(string id)
        {
            FormPermissionModel obj = new FormPermissionModel();
            string DeletedBy = SessionManager.UserId.ToString();
            UserPermissionDB objresps = new UserPermissionDB();
            obj = objresps.DeleteRolePermission(id, DeletedBy);
            if (obj.flag >0 || obj.flag != 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = obj.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = obj.message;
            }
            return RedirectToAction("SetPermissionList", "UserPermission");
        }

        [HttpPost]
        public JsonResult SetPermissionJsonInsert(int userId, int roleId)
        {            
            if (userId != 0 && roleId != 0)
            {
                UserPermissionDB objreps = new UserPermissionDB();
                var rolePermissions = objreps.BindRolePermissionList(roleId);
                foreach (var obj in rolePermissions)
                {
                    FormPermissionModel objres = new FormPermissionModel();
                    var rpmObj = new FormPermissionModel();
                    rpmObj.CreatedBy = SessionManager.UserId.ToString();
                    rpmObj.FK_RoleId = obj.FK_RoleId;
                    rpmObj.FK_FormTypeId = obj.FK_FormTypeId;
                    rpmObj.FK_FormId = obj.FK_FormMasterId;
                    rpmObj.FK_UserId = userId;
                    rpmObj.FormSave = obj.FormSave;
                    rpmObj.FormUpdate = obj.FormUpdate;
                    rpmObj.FormDelete = obj.FormDelete;
                    rpmObj.FormView = obj.FormView;

                    objres = objreps.SaveFormPermission(rpmObj);
                    if (objres.flag > 0 || objres.flag != 0)
                    {
                        TempData["code"] = "1";
                        TempData["Msg"] = objres.message;
                    }
                    else
                    {
                        TempData["code"] = "0";
                        TempData["Msg"] = objres.message;
                    }
                }
            }
            return Json(new { msg = TempData["msg"], code = TempData["code"] });
        }

        [HttpPost]
        public JsonResult SetPermissionJsonUpdate(FormPermissionModel roles)
        {
            if (roles != null && roles.FormPermissionList != null)
            {
                foreach (var obj in roles.FormPermissionList)
                {                    
                    var rpmObj = new FormPermissionModel();
                    rpmObj.CreatedBy = SessionManager.UserId.ToString();
                    rpmObj.FK_RoleId = obj.FK_RoleId;
                    rpmObj.FK_FormTypeId = obj.FK_FormTypeId;
                    rpmObj.FK_FormId = obj.FK_FormId;
                    rpmObj.FormSave = obj.FormSave;
                    rpmObj.FormUpdate = obj.FormUpdate;
                    rpmObj.FormDelete = obj.FormDelete;
                    rpmObj.FormView = obj.FormView;
                    rpmObj.FK_UserId = obj.FK_UserId;
                    UserPermissionDB objreps = new UserPermissionDB();
                    FormPermissionModel objresult = new FormPermissionModel();
                    if (string.IsNullOrEmpty(obj.PK_PermissionId))
                    {
                        objresult = objreps.SaveFormPermission(rpmObj, true);
                    }
                    else
                    {
                        rpmObj.PK_PermissionId = obj.PK_PermissionId;
                        objresult = objreps.UpdatesetRolePermission(rpmObj);
                    }
                    if (objresult.flag > 0 || objresult.flag != 0)
                    {
                        TempData["code"] = "1";
                        TempData["Msg"] = objresult.message;
                    }
                    else
                    {
                        TempData["code"] = "0";
                        TempData["Msg"] = objresult.message;
                    }
                }
            }
            else
            {
                return Json(new { msg = "Record Updated Successfully", code = "1" }); ;
            }
            return Json(new { msg = TempData["msg"], code = TempData["code"] }); ;
        }
        public ActionResult SetPermissionFill(int userId, int roleId)
        {
            UserPermissionDB objreps = new UserPermissionDB();
            ViewBag.ddlRoles = objreps.BindddlRoles();
            ViewBag.ddlUsers = objreps.BindUsers();
            ViewBag.RolePermissionFormList = objreps.BindRolePermissionFormList();
            var obj = new FormPermissionModel();
            obj.FK_UserId = userId;
            var objresps = new UserPermissionDB();
            var lstobj = objresps.EditFormPermission(userId);
            lstobj.FK_UserId = userId;
            lstobj.FK_RoleId = roleId;
            return View("SetPermission", lstobj);
        }

        public PartialViewResult GetPermissionTblList(int userId)
        {
            UserPermissionDB objreps = new UserPermissionDB();
            ViewBag.RolePermissionFormList = objreps.BindRolePermissionFormList();
            var objresps = new UserPermissionDB();
            var lstobj = objresps.EditFormPermission(userId);
            lstobj.FK_UserId = userId;
            return PartialView("_GetFormTblPermission", lstobj);
        }

        public ActionResult SetUserPermission()
        {
            return View();
        }
        //public JsonResult BindAllMenu()
        //{
        //    UserPermissionDB objreps = new UserPermissionDB();
        //    return Json(objreps.BindAllMenu());
        //}
        //public JsonResult BindRole()
        //{
        //    UserPermissionDB objreps = new UserPermissionDB();
        //    return Json(objreps.BindRoleMaster());
        //}
        //public JsonResult BindEmpRoleWise(int RoleId = 0)
        //{
        //    UserPermissionDB objreps = new UserPermissionDB();
        //    return Json(objreps.BindEmpRoleIdWise(RoleId));
        //}
        #endregion

        #endregion
    }
}