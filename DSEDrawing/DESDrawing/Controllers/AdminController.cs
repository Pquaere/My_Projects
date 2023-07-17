using DESDrawing.Filter;
using DESDrawing.Models;
using DESDrawing.Models.DBRepository;
using DESDrawing.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESDrawing.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        // GET: Admin
        AdminDB objDB = new AdminDB();
        public ActionResult Index()
        {
            return View();
        }

        #region ADMIN DASHBOARD
        public ActionResult Dashboard()
        {
            MasterDB objdb = new MasterDB();
            Dashboard model = new Dashboard();
            IEnumerable<SelectListItem> DiscomOffice = objdb.Discomofficesdrop();
            ViewBag.DiscomOffice = DiscomOffice;
            model = DirectorDB.AdminDashboard();
            return View(model);
        }
        #endregion

        #region USER MASTER FOR ADMIN
        public ActionResult UsersList()
        {
            Users objmodel = new Users();
            AdminDB obj = new AdminDB();
            objmodel.Userslist = obj.ListUsers();
            return View(objmodel);
        }
        [HttpGet]
        public ActionResult ChangeUserStatus(bool Isactive, int ID)
        {
            AdminDB obj = new AdminDB();
            Users model = new Users();
            model.Isactive = Isactive;
            model.UserID = ID;
            Users objresult = obj.changeuserstatus(model);
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
            return RedirectToAction("UsersList", "Admin");
        }

        [HttpGet]
        public ActionResult AddUser(int? ID)
        {
            MasterDB objdb = new MasterDB();
            AdminDB objdbAdmin = new AdminDB();
            UserPermissionDB obj = new UserPermissionDB();
            IEnumerable<SelectListItem> discomoffice = objdb.Discomofficesdrop();
            ViewBag.discomoffice = discomoffice;
            IEnumerable<SelectListItem> Role = obj.BindddlRoles();
            ViewBag.Role = Role;
            if (ID > 0)
            {
                Users objresult = objdbAdmin.GetUserDetails(ID);
                return View(objresult);
            }
            return View(new Users());
        }
        [HttpPost]
        public ActionResult AddUser(Users model)
        {
            AdminDB objDB = new AdminDB();
            Users objresult = new Users();
            if (model.UserID > 0)
            {
                objresult = objDB.UpdateUser(model);
            }
            else
            {
                objresult = objDB.SaveUser(model);
            }

            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
            }
            else
            {
                MasterDB objdbMaster = new MasterDB();
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
                IEnumerable<SelectListItem> discomoffice = objdbMaster.Discomofficesdrop();
                ViewBag.discomoffice = discomoffice;
                return View(model);
            }

            return RedirectToAction("UsersList", "Admin");
        }
        public JsonResult GetsubRegions(int DiscomId)
        {
            AdminDB ADB = new AdminDB();
            List<SelectListItem> modelresult = ADB.GetRegions(DiscomId);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetsubZones(int RegionId)
        {
            AdminDB ADB = new AdminDB();
            List<SelectListItem> modelresult = ADB.GetZones(RegionId);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetsubDistrict(int ZoneId)
        {
            AdminDB ADB = new AdminDB();
            List<SelectListItem> modelresult = ADB.GetDistricts(ZoneId);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}