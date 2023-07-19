using HRPayroll.Filters;
using HRPayroll.Models;
using HRPayroll.Models.DBRepository;
using HRPayroll.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayroll.Controllers
{
    [AuthorizeAdmin]
    public class UserPermissionController : Controller
    {
        MasterDB objDB = new MasterDB();
        #region    --------- UserPermission -----------        


        #region Form Master (Shalini)
        [HttpGet]
        public ActionResult AddForm(int? ID)
        {
            Form model = new Form();
            ViewBag.State = objDB.BindFormTypeDropdown();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetFormByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddForm(Form model)
        {
            Form result = new Form();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateForm(model);
            }
            else
            {
                result = MasterDB.AddForm(model);
            }

            if (result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
                return RedirectToAction("AddForm", "UserPermission");
            }
            return RedirectToAction("FormList", "UserPermission");
        }
        [HttpGet]
        public ActionResult FormList()
        {
            Form model = new Form();
            model = MasterDB.FormList(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult ChangeFormStatus(bool Isactive, int ID)
        {
            Form model = new Form();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.ChangeFormstatus(model);
            if (model.flag != 0 || model.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.message;
            }
            return RedirectToAction("FormList", "UserPermission");
        }
        #endregion

        #region FormType Master (Shalini)

        [HttpGet]
        public ActionResult AddFormType(int? ID)
        {
            if (ID > 0)
            {
                FormType objresult = objDB.GetFormTypeDetails(ID);
                return View(objresult);
            }
            return View(new FormType());
        }
        [HttpPost]
        public ActionResult AddFormType(FormType model)
        {
            FormType objresult = new FormType();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateFormType(model);
            }
            else
            {
                objresult = objDB.SaveFormType(model);
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
                return View(model);
            }

            return RedirectToAction("FormTypeList", "UserPermission");
        }
        public ActionResult FormTypeList()
        {
            FormType obj = new FormType();
            obj.list = objDB.FormTypeList();
            return View(obj);
        }
        public ActionResult ChangeFormTypeStatus(bool IsActive, int ID)
        {
            FormType model = new FormType();
            model.IsActive = IsActive;
            model.ID = ID;
            FormType objresult = objDB.ChangeFormTypestatus(model);
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

        #endregion

        #region Role Master (Shalini)

        [HttpGet]
        public ActionResult AddRole(int? ID)
        {
            if (ID > 0)
            {
                Role objresult = objDB.GetRoleDetails(ID);
                return View(objresult);
            }
            return View(new Role());
        }
        [HttpPost]
        public ActionResult AddRole(Role model)
        {
            Role objresult = new Role();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateRole(model);
            }
            else
            {
                objresult = objDB.SaveRole(model);
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
                return View(model);
            }

            return RedirectToAction("RoleList", "UserPermission");
        }
        public ActionResult RoleList()
        {
            Role obj = new Role();
            obj.rolelist = objDB.RoleList();
            return View(obj);
        }
        public ActionResult ChangeRoleStatus(bool IsActive, int ID)
        {
            Role model = new Role();
            model.IsActive = IsActive;
            model.ID = ID;
            Role objresult = objDB.ChangeRolestatus(model);
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
            return RedirectToAction("RoleList", "UserPermission");
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
            if (obj.flag > 0 || obj.flag != 0)
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
        
        #endregion

        #endregion
    }
}