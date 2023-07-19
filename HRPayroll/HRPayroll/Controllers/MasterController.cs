using HRPayroll.Models;
using HRPayroll.Models.DBRepository;
using HRPayroll.Filters;
using HRPayroll.Models.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayroll.Controllers
{
    [AuthorizeAdmin]
    public class MasterController : Controller
    {       
        MasterDB objDB = new MasterDB();
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        #region Role Master

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

            return RedirectToAction("RoleList", "Master");
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
            return RedirectToAction("RoleList", "Master");
        }

        #endregion

        #region Form Master
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
                return RedirectToAction("AddForm", "Master");
            }
            return RedirectToAction("FormList", "Master");
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
            return RedirectToAction("FormList", "Master");
        }
        #endregion

        #region FormType Master

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

            return RedirectToAction("FormTypeList", "Master");
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
            return RedirectToAction("FormTypeList", "Master");
        }

        #endregion

        #region State Master 

        [HttpGet]
        public ActionResult AddState(int? ID)
        {
            if (ID > 0)
            {
                State objresult = objDB.GetStateDetails(ID);
                return View(objresult);
            }
            return View(new State());
        }
        [HttpPost]
        public ActionResult AddState(State model)
        {
            State objresult = new State();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateState(model);
            }
            else
            {
                objresult = objDB.SaveState(model);
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

            return RedirectToAction("StateList", "Master");
        }
        public ActionResult StateList()
        {
            State obj = new State();
            obj.statelist = objDB.StateList();
            return View(obj);
        }
        public ActionResult ChangeStateStatus(bool IsActive, int ID)
        {
            State model = new State();
            model.IsActive = IsActive;
            model.ID = ID;
            State objresult = objDB.ChangeStatestatus(model);
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
            return RedirectToAction("StateList", "Master");
        }

        #endregion

        #region District Master
        [HttpGet]
        public ActionResult AddDistrict(int? ID)
        {
            District model = new District();
            ViewBag.State = objDB.BindStateDropdown();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetDistrictByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddDistrict(District model)
        {
            District result = new District();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateDistrict(model);
            }
            else
            {
                result = MasterDB.AddDistrict(model);
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
                return RedirectToAction("AddDistrict", "Master");
            }
            return RedirectToAction("DistrictList", "Master");
        }
        [HttpGet]
        public ActionResult DistrictList()
        {
            District model = new District();
            model = MasterDB.DistrictList(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult ChangeDistrictStatus(bool Isactive, int ID)
        {
            District model = new District();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.ChangeDistrictstatus(model);
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
            return RedirectToAction("DistrictList", "Master");
        }
        #endregion

        #region Office Master 
        [HttpGet]
        public ActionResult AddOffice(int? ID)
        {
            Office model = new Office();
            ViewBag.District = objDB.BindDistrictDropdown();
            ViewBag.AgencyType = MasterDB.Dropdown(1, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetOfficeByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddOffice(Office model)
        {
            ViewBag.District = objDB.BindDistrictDropdown();
            ViewBag.AgencyType = MasterDB.Dropdown(1, 0);
            Office result = new Office();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateOffice(model);
            }
            else
            {
                result = MasterDB.AddOffice(model);
            }

            if (result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.message;
                return RedirectToAction("OfficeList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult OfficeList()
        {
            Office model = new Office();
            model = MasterDB.OfficeList(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult ChangeOfficeStatus(bool Isactive, int ID)
        {
            Office model = new Office();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.ChangeOfficestatus(model);
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
            return RedirectToAction("OfficeList", "Master");
        }
        #endregion

        #region Circle Master 

        [HttpGet]
        public ActionResult AddCircle(int? ID)
        {
            if (ID > 0)
            {
                Circle objresult = objDB.GetCircleDetails(ID);
                return View(objresult);
            }
            return View(new Circle());
        }
        [HttpPost]
        public ActionResult AddCircle(Circle model)
        {
            Circle objresult = new Circle();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateCircle(model);
            }
            else
            {
                objresult = objDB.SaveCircle(model);
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

            return RedirectToAction("CircleList", "Master");
        }
        public ActionResult CircleList()
        {
            Circle obj = new Circle();
            obj.circlelist = objDB.CircleList();
            return View(obj);
        }
        public ActionResult ChangeCircleStatus(bool IsActive, int ID)
        {
            Circle model = new Circle();
            model.IsActive = IsActive;
            model.ID = ID;
            Circle objresult = objDB.ChangeCirclestatus(model);
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
            return RedirectToAction("CircleList", "Master");
        }

        #endregion

        #region Bonus
        [HttpGet]
        public ActionResult AddBonus(int? ID)
        {
            IEnumerable<SelectListItem> Level = objDB.LevelList();
            ViewBag.Level = Level;
            Bonus model = new Bonus();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetBonusByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddBonus(Bonus model)
        {
            Bonus result = new Bonus();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateBonus(model);
            }
            else
            {
                result = MasterDB.AddBonus(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("BonusList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }

        public ActionResult BonusList()
        {
            Bonus model = new Bonus();
            model = MasterDB.ListBonus(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeBonustatus(bool Isactive, int ID)
        {
            Bonus model = new Bonus();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.changeBonustatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("BonusList", "Master");
        }
        #endregion

        #region Bank
        [HttpGet]
        public ActionResult AddBank(int? ID)
        {
            Bank model = new Bank();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetBankByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddBank(Bank model)
        {
            Bank result = new Bank();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateBank(model);
            }
            else
            {
                result = MasterDB.AddBank(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("BankList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }
        public ActionResult BankList()
        {
            Bank model = new Bank();
            model = MasterDB.ListBank(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeBanktatus(bool Isactive, int ID)
        {
            Bank model = new Bank();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.changeBanktatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("BankList", "Master");
        }
        #endregion

        #region BankBranch
        [HttpGet]
        public ActionResult AddBranch(int? ID)
        {
            IEnumerable<SelectListItem> Bank = objDB.BindBankDropdown();
            ViewBag.Bank = Bank;
            IEnumerable<SelectListItem> States = objDB.BindStateDropdown();
            ViewBag.States = States;
            ViewBag.District = new List<SelectListItem>();
            Branch model = new Branch();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetBranchByID(model);
                IEnumerable<SelectListItem> District = objDB.GetDistricts(model.Fk_StateId);
                ViewBag.District = District;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddBranch(Branch model)
        {
            Branch result = new Branch();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateBranch(model);
            }
            else
            {
                result = MasterDB.AddBranch(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("BranchList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }
        public ActionResult BranchList()
        {
            Branch model = new Branch();
            model = MasterDB.ListBranch(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeBranchtatus(bool Isactive, int ID)
        {
            Branch model = new Branch();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.changeBranchtatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("BranchList", "Master");
        }
        public JsonResult GetDistricts(int StateId)
        {
            List<SelectListItem> modelresult = objDB.GetDistricts(StateId);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HolidayType
        [HttpGet]
        public ActionResult AddHolidayType(int? ID)
        {
            HolidayTypes model = new HolidayTypes();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetHolidayTypeByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddHolidayType(HolidayTypes model)
        {
            HolidayTypes result = new HolidayTypes();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateHolidayType(model);
            }
            else
            {
                result = MasterDB.AddHolidayType(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("HolidayTypeList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }
        public ActionResult HolidayTypeList()
        {
            HolidayTypes model = new HolidayTypes();
            model = MasterDB.ListHolidayType(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult ChangeHolidayTypeStatus(bool Isactive, int ID)
        {
            HolidayTypes model = new HolidayTypes();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.ChangeHolidayTypestatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("HolidayTypeList", "Master");
        }

        #endregion

        #region Leavetype 

        [HttpGet]
        public ActionResult AddLeaveType(int? ID)
        {
            LeaveTypes model = new LeaveTypes();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetLeaveTypeByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddLeaveType(LeaveTypes model)
        {
            LeaveTypes result = new LeaveTypes();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateLeaveType(model);
            }
            else
            {
                result = MasterDB.AddLeaveType(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("LeaveTypeList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }

        public ActionResult LeaveTypeList()
        {
            LeaveTypes model = new LeaveTypes();
            model = MasterDB.ListLeaveType(model);
            return View(model);
        }

        [HttpGet]
        public ActionResult ChangeLeaveTypeStatus(bool Isactive, int ID)
        {
            LeaveTypes model = new LeaveTypes();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.ChangeLeaveTypestatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("LeaveTypeList", "Master");
        }

        #endregion

        #region Department

        [HttpGet]
        public ActionResult AddDepartment(int? ID)
        {
            Department model = new Department();
            ViewBag.UserType = MasterDB.Dropdown(2, 0);
            ViewBag.WorkingType = MasterDB.Dropdown(3, 0);
            ViewBag.OfficeName = MasterDB.Dropdown(27, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetDepartmentByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddDepartment(Department model)
        {
            Department result = new Department();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateDepartment(model);
            }
            else
            {
                result = MasterDB.AddDepartment(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("DepartmentList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("DepartmentList", "Master");
            }
           // return View(model);
        }

        public ActionResult DepartmentList()
        {
            Department model = new Department();
            model = MasterDB.ListDepartment(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeDepartmentStatus(bool Isactive, int ID)
        {
            Department model = new Department();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.changeDepartmenttatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("DepartmentList", "Master");
        }

        #endregion

        #region SubDepartment

        [HttpGet]
        public ActionResult AddSubDepartment(int? ID)
        {
            SubDepartment model = new SubDepartment();
            ViewBag.Department = MasterDB.Dropdown(35, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetSubDepartmentByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSubDepartment(SubDepartment model)
        {
            SubDepartment result = new SubDepartment();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateSubDepartment(model);
            }
            else
            {
                result = MasterDB.AddSubDepartment(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("SubDepartmentList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("SubDepartmentList", "Master");
            }
          //  return View(model);
        }

        public ActionResult SubDepartmentList()
        {
            SubDepartment model = new SubDepartment();
            model = MasterDB.ListSubDepartment(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeSubDepartmenttatus(bool Isactive, int ID)
        {
            SubDepartment model = new SubDepartment();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.changeSubDepartmenttatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("SubDepartmentList", "Master");
        }

        #endregion

        #region Activities

        [HttpGet]
        public ActionResult AddActivities(int? ID)
        {
            Activitie model = new Activitie();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetActivitiesByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddActivities(Activitie model)
        {
            Activitie result = new Activitie();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateActivities(model);
            }
            else
            {
                result = MasterDB.AddActivities(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("ActivitiesList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }

        public ActionResult ActivitiesList()
        {
            Activitie model = new Activitie();
            DateTime.Now.ToString("MM/dd/yyyy");
            model = MasterDB.ListActivities(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeActivitieStatus(bool Isactive, int ID)
        {
            Activitie model = new Activitie();
            model.IsActivity = Isactive;
            model.ID = ID;
            model = MasterDB.changeActivieStatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("ActivitiesList", "Master");
        }

        #endregion

        #region Desigation 
        [HttpGet]
        public ActionResult Desigation(string Id)
        {
            Desigation model = new Desigation();
            if (!string.IsNullOrEmpty(Id))
            {
                model = objDB.GetDesignationById(Convert.ToInt32(Id));
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveDesigation(Desigation model)
        {
            Desigation objresult = new Desigation();
            model.UserId = SessionManager.UserId;
            if (model.DesignationId > 0)
            {
                objresult = objDB.UpdateDesigation(model);
            }
            else
            {
                objresult = objDB.InsertDesigation(model);
            }

            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
                return RedirectToAction("DesignationList");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
                return RedirectToAction("Desigation", "Master");
            }
            return View();
        }
        public ActionResult DesignationList()
        {
            Desigation obj = new Desigation();
            obj.Desigationlist = objDB.DesignationList();
            return View(obj);
        }
        public ActionResult ChangeDesigationStatus(int IsActive, int ID)
        {
            Desigation model = new Desigation();
            model.IsActive = IsActive;
            model.DesignationId = ID;
            model.UserId = SessionManager.UserId;
            Desigation objresult = objDB.ChangeDesignationstatus(model);
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
            return RedirectToAction("DesignationList");
        }
        #endregion

        #region Brand
        [HttpGet]
        public ActionResult AddBrand(int? ID)
        {
            Brands model = new Brands();
            ViewBag.Category = MasterDB.Dropdown(19, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetBrandByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddBrand(Brands model)
        {
            Brands result = new Brands();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateBrand(model);
            }
            else
            {
                result = MasterDB.AddBrand(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("BrandList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }
        public ActionResult BrandList()
        {
            Brands model = new Brands();
            model = MasterDB.ListBrand(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeBrandStatus(bool Isactive, int ID)
        {
            Brands model = new Brands();
            model.IsDeleted = Isactive;
            model.ID = ID;
            model = MasterDB.changeBrandtatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("BrandList", "Master");
        }
        #endregion

        #region EmployeeType


        [HttpGet]
        public ActionResult AddEmployeeType(int? ID)
        {
            Employements model = new Employements();
            ViewBag.Department = MasterDB.Dropdown(3, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetEmployeeTypeByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployeeType(Employements model)
        {
            Employements result = new Employements();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateEmployeeType(model);
            }
            else
            {
                result = MasterDB.AddEmployeeType(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("EmployeeTypeList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }

        public ActionResult EmployeeTypeList()
        {
            Employements model = new Employements();
            model = MasterDB.ListEmployeeType(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeEmployeeTypeStatus(bool Isactive, int ID)
        {
            Employements model = new Employements();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.changeEmployeeTypeStatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("EmployeeTypeList", "Master");
        }

        #endregion

        #region Category
        [HttpGet]
        public ActionResult AddCategory(int? ID)
        {
            CategoryModel model = new CategoryModel();
            ViewBag.Category = MasterDB.Dropdown(19, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetCategoryByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryModel model)
        {
            CategoryModel result = new CategoryModel();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateCategory(model);
            }
            else
            {
                result = MasterDB.AddCategory(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("CategoryList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }

        public JsonResult UploadImageFile(HttpPostedFileBase File, string type)
        {
            string Dirpath = "";
            if (type == "Images")
            {
                Dirpath = "/Documents/Category/";
            }
            if (type == "ProductImage")
            {
                Dirpath = "/Documents/ProductImage/";
            }
            string path = "";
            string filename = File.FileName;
            bool res = false;
            string msg = "";
            if (!Directory.Exists(Server.MapPath(Dirpath)))
            {
                Directory.CreateDirectory(Server.MapPath(Dirpath));
            }
            string ext = Path.GetExtension(File.FileName);
            filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + filename;
            string completepath = Path.Combine(Server.MapPath(Dirpath), filename);
            if (System.IO.File.Exists(completepath))
            {
                System.IO.File.Delete(completepath);
            }
            File.SaveAs(completepath);
            path = Dirpath + filename;
            res = true;
            return Json(new { result = res, fpath = path, mesg = msg });
        }


        public ActionResult CategoryList()
        {
            CategoryModel model = new CategoryModel();
            model = MasterDB.ListCategory(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeCategoryStatus(bool Isactive, int ID)
        {
            CategoryModel model = new CategoryModel();
            model.IsDeleted = Isactive;
            model.ID = ID;
            model = MasterDB.changeCategoryStatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("CategoryList", "Master");
        }
        #endregion

        #region AgencyType
        [HttpGet]
        public ActionResult AddAgencyType(int? ID)
        {
            Agency model = new Agency();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetAgencyTypeByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddAgencyType(Agency model)
        {
            Agency result = new Agency();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateAgencyType(model);
            }
            else
            {
                result = MasterDB.AddAgencyType(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("AgencyTypeList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }
        public ActionResult AgencyTypeList()
        {
            Agency model = new Agency();
            model = MasterDB.ListAgencyType(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult changeAgencyTypeStatus(bool Isactive, int ID)
        {
            Agency model = new Agency();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.changeAgencyTypeStatus(model);
            if (model.response.flag != 0 || model.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = model.response.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = model.response.message;
            }
            return RedirectToAction("AgencyTypeList", "Master");
        }
        #endregion

        #region DA_Percent & fixallowance 

        [HttpGet]
        public ActionResult DA_PercentList()
        {
            DAPercent model = new DAPercent();
            model = MasterDB.DAPercentList(model);
            return View(model);
        }

        [HttpGet]
        public ActionResult DA_Percent(int? ID)
        {
            ViewBag.Paycommission = MasterDB.Dropdown(11, 0);
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            DAPercent model = new DAPercent();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetDA_PercentByID(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Add_DA_Percent(DAPercent model)
        {
            DAPercent result = new DAPercent();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateDAPercent(model);
            }
            else
            {
                result = MasterDB.AddDAPercent(model);
            }

            if (result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.message;
                return RedirectToAction("DA_PercentList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ChangeDAPercentStatus(bool Isactive, int ID)
        {
            DAPercent model = new DAPercent();
            model.IsActive = Convert.ToInt32(Isactive);
            model.ID = ID;
            model = MasterDB.ChangeDAPercentstatus(model);
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
            return RedirectToAction("DA_PercentList", "Master");
        }

        [HttpGet]
        public ActionResult fixallowanceList()
        {
            fixallowance model = new fixallowance();
            model = MasterDB.fixallowanceList(model);
            return View(model);
        }

        [HttpGet]
        public ActionResult fixallowance(int? ID)
        {
            ViewBag.Paycommission = MasterDB.Dropdown(11, 0);
            ViewBag.GradePay = MasterDB.Dropdown(6, 0);
            ViewBag.Circle = MasterDB.Dropdown(8, 0);
            fixallowance model = new fixallowance();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetfixallowanceByID(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Add_fixallowance(fixallowance model)
        {
            fixallowance result = new fixallowance();
            if (model.ID > 0)
            {
                result = MasterDB.Updatefixallowance(model);
            }
            else
            {
                result = MasterDB.Addfixallowance(model);
            }

            if (result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.message;
                return RedirectToAction("fixallowanceList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
            }

            return RedirectToAction("fixallowanceList", "Master");
        }

        [HttpGet]
        public ActionResult ChangefixallowanceStatus(bool Isactive, int ID)
        {
            fixallowance model = new fixallowance();
            model.IsActive = Convert.ToInt32(Isactive);
            model.ID = ID;
            model = MasterDB.Changefixallowancestatus(model);
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
            return RedirectToAction("fixallowanceList", "Master");
        }
        #endregion

        #region ServiceType
       public ActionResult ServiceType(string Id)
       {
           ServiceType model = new ServiceType();
           ViewBag.DistrictList = objDB.GetDistricts(0);
           ViewBag.AgncyType = objDB.GetAgencyType();
           ViewBag.OfficeName = objDB.GetOfficeName(0, 0);
            ViewBag.payCommision = objDB.GetPayCommisionDropDown();
            if (!string.IsNullOrEmpty(Id))
            {
                model = objDB.GetServiceTypeById(Convert.ToInt32(Id));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ServiceType(ServiceType model)
        {
            ViewBag.DistrictList = objDB.GetDistricts(0);
            ViewBag.AgncyType = objDB.GetAgencyType();
            ServiceType objresult = new ServiceType();
            if (model.Id > 0)
            {
                objresult = objDB.UpdateServiceType(model);
            }
            else
            {
                objresult = objDB.InsertServiceType(model);
            }

            if (objresult.flag != 0 || objresult.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresult.message;
                return RedirectToAction("ServiceTypeList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = objresult.message;
                return RedirectToAction("ServiceTypeList", "Master");
            }
            return View();
        }

        public JsonResult GetOfficeName(int districtId, int AgencyTypeId)
        {
            var res = objDB.GetOfficeName(districtId, AgencyTypeId);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOfficeType(int districtId)
        {
            var res = MasterDB.Dropdown(32, districtId);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ServiceTypeList()
        {
            ServiceType objresult = new ServiceType();
            objresult.ServiceTypeList = objDB.ServiceTypeList();
            return View(objresult);
        }

        public ActionResult ChangeServiceTypeStatus(int IsActive, int ID)
        {
            ServiceType model = new ServiceType();
            model.IsActive = IsActive;
            model.Id = ID;
            ServiceType objresult = objDB.ChangeServiceTypetatus(model);
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
            return RedirectToAction("ServiceTypeList");
        }
        #endregion

        #region Holiday

        [HttpGet]
        public ActionResult HolidayList()
        {
            Holiday model = new Holiday();
            model = MasterDB.HolidayList(model);
            return View(model);
        }

        [HttpGet]
        public ActionResult Holiday(int? ID)
        {
            Holiday model = new Holiday();
            MasterDB mb = new MasterDB();
            model.OfficeList = mb.Office();
            ViewBag.Holiday = MasterDB.Dropdown(12, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetHolidayByID(Convert.ToInt32(ID));
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Add_Holiday(Holiday model)
        {
            Holiday result = new Holiday();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateHoliday(model);
            }
            else
            {
                result = MasterDB.AddHoliday(model);
            }
            if (result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.message;
                return RedirectToAction("HolidayList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
            }
            return View(model);
        }
        public JsonResult AddImageFile(HttpPostedFileBase File, string type)
        {
            string Dirpath = "";
            if (type == "HolidayImage")
            {
                Dirpath = "/Documents/HolidayImage/";
            }
            string path = "";
            string filename = File.FileName;
            bool res = false;
            string msg = "";
            if (!Directory.Exists(Server.MapPath(Dirpath)))
            {
                Directory.CreateDirectory(Server.MapPath(Dirpath));
            }
            string ext = Path.GetExtension(File.FileName);
            filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + filename;
            string completepath = Path.Combine(Server.MapPath(Dirpath), filename);
            if (System.IO.File.Exists(completepath))
            {
                System.IO.File.Delete(completepath);
            }
            File.SaveAs(completepath);
            path = Dirpath + filename;
            res = true;
            return Json(new { result = res, fpath = path, mesg = msg });
        }

        [HttpGet]
        public ActionResult ChangeHolidayStatus(bool Isactive, int ID)
        {
            Holiday model = new Holiday();
            model.IsActive = Convert.ToInt32(Isactive);
            model.ID = ID;
            model = MasterDB.ChangeHolidayStatus(model);
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
            return RedirectToAction("HolidayList", "Master");
        }
        #endregion

        #region  Leave Request 
        [HttpGet]
        public ActionResult Add_LeaveRequest(int? ID)
        {
            LeaveRequest model = new LeaveRequest();
            MasterDB mb = new MasterDB();
            AccountMasterDb ADb = new AccountMasterDb();
            IEnumerable<SelectListItem> EmployeeType = MasterDB.Dropdown(3, 0);
            ViewBag.EmployeeType = EmployeeType;
            IEnumerable<SelectListItem> Designation = MasterDB.Dropdown(9, 0);
            ViewBag.ddlDesignation = Designation;
            IEnumerable<SelectListItem> Year = ADb.GetAllFinancialYear();
            ViewBag.ddlYear = Year;
            IEnumerable<SelectListItem> LeaveCategory = MasterDB.Dropdown(14, 0);
            ViewBag.ddlLeaveCategory = LeaveCategory;
            model = MasterDB.LeaveType();
            if (ID != null)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetAssignLeaveByID(Convert.ToInt32(ID));
            }
            return View(model);
        }

        public JsonResult AddLeave(LeaveRequest model)
        {
            LeaveRequest obj = new LeaveRequest();
            if (model.ArrayLeave != null)
            {
                if (model.ArrayLeave.Count() > 0)
                {
                    string leavedata = "<leavedata>";
                    foreach (var item in model.ArrayLeave)
                    {
                        if (item.carryforward == false)
                        {
                            item.carry = 0;
                        }
                        else
                        {
                            item.carry = 1;
                        }
                        leavedata += "<leavedatadetails><Pk_LeaveTypeId>" + item.ID + "</Pk_LeaveTypeId><Noofdays>" + item.noofdays + "</Noofdays><carry>" + item.carry + "</carry></leavedatadetails>";
                    }
                    leavedata += "</leavedata>";
                    model.xmlData = leavedata.ToString();
                    obj = MasterDB.AddLeaveRequest(model);
                    if (obj.flag > 0)
                    {
                        TempData["code"] = "1";
                        TempData["Msg"] = obj.message;
                    }
                    else
                    {
                        TempData["code"] = "0";
                        TempData["Msg"] = obj.message;
                    }
                }
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LeaveList()
        {
            LeaveRequest obj = new LeaveRequest();
            obj.LeaveList = objDB.AssignLeaveList();
            return View(obj);
        }
        public ActionResult deleteAssignleave(int ID)
        {
            LeaveRequest obj = new LeaveRequest();
            obj = objDB.DeleteAssignedLeave(ID);
            if (obj.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = obj.message;
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = obj.message;
            }
            return RedirectToAction("LeaveList", "Master");
        }
        #endregion

        #region   SalaryStopAndSuspend
        [HttpGet]
        public ActionResult SalaryStopAndSuspend()
        {
            Employee model = new Employee();
            IEnumerable<SelectListItem> EmployeeType = MasterDB.Dropdown(3, 0);
            ViewBag.EmployeeType = EmployeeType;
            IEnumerable<SelectListItem> Designation = MasterDB.Dropdown(9, 0);
            ViewBag.Designation = Designation;
            IEnumerable<SelectListItem> monthId = MasterDB.Dropdown(15, 0);
            ViewBag.monthId = monthId;
            IEnumerable<SelectListItem> Department = MasterDB.Dropdown(4, 0);
            ViewBag.Department = Department;
            ViewBag.EmpCategory1 = MasterDB.Dropdown(3, 0);
            return View(model);
        }
        public ActionResult Employeelistforsalary(Employee model)
        {
            Employee obj = new Employee();
            obj = MasterDB.EmployeeListForSalarySuspendStop(model);
            return PartialView("_EmployeeForSalary", obj);
        }
        public JsonResult StopAndSuspendSalary(Employee model)
        {
            Employee obj = new Employee();
            if (model.EmpIDList != null)
            {
                if (model.EmpIDList.Count() > 0)
                {
                    foreach (var item in model.EmpIDList)
                    {
                        var id = item.EMPid;
                        var status = model.status;
                        obj = MasterDB.StopAndSuspendSalary(id, status);
                    }
                }
                if (obj.flag > 0)
                {
                    TempData["code"] = "1";
                    TempData["Msg"] = obj.message;
                }
                else
                {
                    TempData["code"] = "0";
                    TempData["Msg"] = obj.message;
                }
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SubCategory Master 
        [HttpGet]
        public ActionResult AddSubCategory(int? ID)
        {

            SubCategory model = new SubCategory();
            ViewBag.Category = MasterDB.Dropdown(19, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetSubcategoryByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSubCategory(SubCategory model)
        {
            SubCategory result = new SubCategory();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateSubcategory(model);
            }
            else
            {
                result = MasterDB.AddSubcategory(model);
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
                return RedirectToAction("AddSubCategory", "Master");
            }
            return RedirectToAction("SubCategoryList", "Master");
        }
        public ActionResult SubCategoryList()
        {
            SubCategory model = new SubCategory();
            model = MasterDB.SubCategorylist(model);
            return View(model);
        }
        public ActionResult ChangeSubCategoryStatus(bool Isdeleted, int ID)
        {
            SubCategory model = new SubCategory();
            model.IsDeleted = Isdeleted;
            model.ID = ID;
            model = MasterDB.ChangeSubCategorystatus(model);
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
            return RedirectToAction("SubCategoryList", "Master");
        }
        #endregion

        #region Unit Master
        [HttpGet]
        public ActionResult AddUnit(int? ID)
        {
            if (ID > 0)
            {
                Unit objresult = objDB.GetUnitDetail(ID);
                return View(objresult);
            }
            return View(new Unit());
        }
        [HttpPost]
        public ActionResult AddUnit(Unit model)
        {
            Unit objresult = new Unit();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateUnit(model);
            }
            else
            {
                objresult = objDB.SaveUnit(model);
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

            return RedirectToAction("UnitList", "Master");
        }
        public ActionResult UnitList()
        {
            Unit obj = new Unit();
            obj.unitlist = objDB.Unitlist();
            return View(obj);
        }
        public ActionResult ChangeUnitStatus(bool Isdeleted, int ID)
        {
            Unit model = new Unit();
            model.IsDeleted = Isdeleted;
            model.ID = ID;
            Unit objresult = objDB.ChangeUnitstatus(model);
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
            return RedirectToAction("UnitList", "Master");
        }
        #endregion

        #region Product Master
        [HttpGet]
        public ActionResult ProductMaster(int? ID)
        {
            IEnumerable<SelectListItem> ddlUnit = MasterDB.Dropdown(20, 0);
            ViewBag.bindUnit = ddlUnit;
            IEnumerable<SelectListItem> ddlBrand = MasterDB.Dropdown(21, 0);
            ViewBag.bindBrand = ddlBrand;
            IEnumerable<SelectListItem> ddlCategory = MasterDB.Dropdown(19, 0);
            ViewBag.bindCategory = ddlCategory;
            if (ID > 0)
            {
                Product objresult = objDB.GetProductDetails(ID);
                return View(objresult);
            }
            return View(new Product());
        }
        [HttpPost]
        public ActionResult ProductMaster(Product model)
        {
            IEnumerable<SelectListItem> ddlUnit = MasterDB.Dropdown(20, 0);
            ViewBag.bindUnit = ddlUnit;
            IEnumerable<SelectListItem> ddlBrand = MasterDB.Dropdown(21, 0);
            ViewBag.bindBrand = ddlBrand;
            IEnumerable<SelectListItem> ddlCategory = MasterDB.Dropdown(19, 0);
            ViewBag.bindCategory = ddlCategory;
            Product objresult = new Product();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateProduct(model);
            }
            else
            {
                objresult = objDB.SaveProduct(model);
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

            return RedirectToAction("ProductList", "Master");
        }
        public ActionResult ProductList()
        {
            Product obj = new Product();
            obj.ProductList = objDB.ProductList();
            return View(obj);
        }
        public ActionResult ChangeProductStatus(bool IsActive, int ID)
        {
            Product model = new Product();
            model.IsActive = IsActive;
            model.ID = ID;
            Product objresult = objDB.ChangeProductstatus(model);
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
            return RedirectToAction("ProductList", "Master");
        }
        #endregion

        #region Size Master
        [HttpGet]
        public ActionResult AddSize(int? ID)
        {
            IEnumerable<SelectListItem> ddlUnit = MasterDB.Dropdown(20, 0);
            ViewBag.bindUnit = ddlUnit;
            if (ID > 0)
            {
                Size objresult = objDB.GetSizeDetails(ID);
                return View(objresult);
            }
            return View(new Size());
        }
        [HttpPost]
        public ActionResult AddSize(Size model)
        {
            IEnumerable<SelectListItem> ddlUnit = MasterDB.Dropdown(20, 0);
            ViewBag.bindUnit = ddlUnit;
            Size objresult = new Size();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateSize(model);
            }
            else
            {
                objresult = objDB.SaveSize(model);
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

            return RedirectToAction("SizeList", "Master");
        }
        public ActionResult SizeList()
        {
            Size obj = new Size();
            obj.SizeList = objDB.SizeList();
            return View(obj);
        }
        public ActionResult ChangeSizeStatus(bool IsActive, int ID)
        {
            Size model = new Size();
            model.IsActive = IsActive;
            model.ID = ID;
            Size objresult = objDB.ChangeSizestatus(model);
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
            return RedirectToAction("SizeList", "Master");
        }
        #endregion

        #region Company Master
        public ActionResult Company(int? ID)
        {
            Company model = new Company();

            ViewBag.District = new List<SelectListItem>();
            ViewBag.State = objDB.BindStateDropdown();

            if (ID > 0)
            {
                model.CompanyId = Convert.ToInt32(ID);
                model = objDB.GetCompanyDetails(Convert.ToInt32(ID));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Add_Company(Company model)
        {
            ViewBag.District = new List<SelectListItem>();
            ViewBag.State = objDB.BindStateDropdown();
            Company objresult = new Company();
            if (model.CompanyId > 0)
            {
                objresult = objDB.UpdateCompany(model);
            }
            else
            {
                objresult = objDB.SaveCompany(model);
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

            return RedirectToAction("CompanyList", "Master");
        }

        [HttpGet]
        public ActionResult CompanyList()
        {
            Company model = new Company();
            model = MasterDB.CompanyList(model);
            return View(model);
        }


        public ActionResult ChangeCompanyStatus(bool Isactive, int ID)
        {
            Company model = new Company();
            model.IsActive = Convert.ToInt32(Isactive);
            model.CompanyId = ID;
            model = MasterDB.ChangeCompanyStatus(model);
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
            return RedirectToAction("CompanyList", "Master");
        }


        public JsonResult GetDistric(int StateId)
        {
            MasterDB objDB = new MasterDB();
            List<SelectListItem> modelresult = objDB.GetDistric(StateId);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Office Time Master    
        [HttpGet]
        public ActionResult AddOfficeTime(int? ID)
        {
            OfficeTime model = new OfficeTime();
            ViewBag.Office = MasterDB.Dropdown(27, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetOfficeTimeDetail(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddOfficeTime(OfficeTime model)
        {
            OfficeTime result = new OfficeTime();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateOfficeTime(model);
            }
            else
            {
                result = MasterDB.AddOfficeTime(model);
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
            }
            return RedirectToAction("OfficeTimeList", "Master");
        }
        [HttpGet]
        public ActionResult OfficeTimeList()
        {
            OfficeTime model = new OfficeTime();
            model = MasterDB.Officetimelist(model);
            return View(model);
        }

        #endregion

        #region Grade-Pay Master 

        [HttpGet]
        public ActionResult AddGradePay(int? ID)
        {
            if (ID > 0)
            {
                Gradepay objresult = objDB.GetGradePayDetails(ID);
                return View(objresult);
            }
            return View(new Gradepay());
        }
        [HttpPost]
        public ActionResult AddGradePay(Gradepay model)
        {
            Gradepay objresult = new Gradepay();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateGradePay(model);
            }
            else
            {
                objresult = objDB.SaveGradePay(model);
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

            return RedirectToAction("GradePayList", "Master");
        }
        public ActionResult GradePayList()
        {
            Gradepay obj = new Gradepay();
            obj.paylist = objDB.GradePayList();
            return View(obj);
        }
        public ActionResult ChangeGradePayStatus(bool IsActive, int ID)
        {
            Gradepay model = new Gradepay();
            model.IsActive = IsActive;
            model.ID = ID;
            Gradepay objresult = objDB.ChangeGradePaystatus(model);
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
            return RedirectToAction("GradePayList", "Master");
        }

        #endregion

        #region Head-Code Master 

        [HttpGet]
        public ActionResult AddHeadCode(int? ID)
        {
            Headcode model = new Headcode();
            ViewBag.Office = objDB.BindOfficeDropdown();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetHeadCodeDetails(ID);
                //Headcode objresult = objDB.GetHeadCodeDetails(ID);
                //return View(objresult);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddHeadCode(Headcode model)
        {
            Headcode objresult = new Headcode();
            ViewBag.Office = objDB.BindOfficeDropdown();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateHeadCode(model);
            }
            else
            {
                objresult = objDB.SaveHeadCode(model);
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

            return RedirectToAction("HeadCodeList", "Master");
        }
        public ActionResult HeadCodeList()
        {
            Headcode obj = new Headcode();
            obj.list = objDB.HeadCodeList();
            return View(obj);
        }
        public ActionResult ChangeHeadCodeStatus(bool IsActive, int ID)
        {
            Headcode model = new Headcode();
            model.IsActive = IsActive;
            model.ID = ID;
            Headcode objresult = objDB.ChangeHeadCodestatus(model);
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
            return RedirectToAction("HeadCodeList", "Master");
        }

        #endregion

        #region EmpCategory Master 

        [HttpGet]
        public ActionResult AddEmpCategory(int? ID)
        {
            if (ID > 0)
            {
                EmpCategory objresult = objDB.GetEmpCategoryDetails(ID);
                return View(objresult);
            }
            return View(new EmpCategory());
        }
        [HttpPost]
        public ActionResult AddEmpCategory(EmpCategory model)
        {
            EmpCategory objresult = new EmpCategory();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateEmpCategory(model);
            }
            else
            {
                objresult = objDB.SaveEmpCategory(model);
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

            return RedirectToAction("EmpCategoryList", "Master");
        }
        public ActionResult EmpCategoryList()
        {
            EmpCategory obj = new EmpCategory();
            obj.list = objDB.EmpCategoryList();
            return View(obj);
        }
        public ActionResult ChangeEmpCategoryStatus(bool IsActive, int ID)
        {
            EmpCategory model = new EmpCategory();
            model.IsActive = IsActive;
            model.ID = ID;
            EmpCategory objresult = objDB.ChangeEmpCategorystatus(model);
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
            return RedirectToAction("EmpCategoryList", "Master");
        }

        #endregion

        #region ServiceQuota Master 

        [HttpGet]
        public ActionResult AddServiceQuota(int? ID)
        {
            if (ID > 0)
            {
                ServiceQuota objresult = objDB.GetServiceQuotaDetails(ID);
                return View(objresult);
            }
            return View(new ServiceQuota());
        }
        [HttpPost]
        public ActionResult AddServiceQuota(ServiceQuota model)
        {
            ServiceQuota objresult = new ServiceQuota();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateServiceQuota(model);
            }
            else
            {
                objresult = objDB.SaveServiceQuota(model);
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

            return RedirectToAction("ServiceQuotaList", "Master");
        }
        public ActionResult ServiceQuotaList()
        {
            ServiceQuota obj = new ServiceQuota();
            obj.list = objDB.ServiceQuotaList();
            return View(obj);
        }
        public ActionResult ChangeServiceQuotaStatus(bool IsActive, int ID)
        {
            ServiceQuota model = new ServiceQuota();
            model.IsActive = IsActive;
            model.ID = ID;
            ServiceQuota objresult = objDB.ChangeServiceQuotastatus(model);
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
            return RedirectToAction("ServiceQuotaList", "Master");
        }

        #endregion

        #region Mandal Master 

        [HttpGet]
        public ActionResult AddMandal(int? ID)
        {
            if (ID > 0)
            {
                Mandal objresult = objDB.GetMandalDetails(ID);
                return View(objresult);
            }
            return View(new Mandal());
        }
        [HttpPost]
        public ActionResult AddMandal(Mandal model)
        {
            Mandal objresult = new Mandal();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateMandal(model);
            }
            else
            {
                objresult = objDB.SaveMandal(model);
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

            return RedirectToAction("MandalList", "Master");
        }
        public ActionResult MandalList()
        {
            Mandal obj = new Mandal();
            obj.Mlist = objDB.MandalList();
            return View(obj);
        }
        public ActionResult ChangeMandalStatus(bool IsActive, int ID)
        {
            Mandal model = new Mandal();
            model.IsActive = IsActive;
            model.ID = ID;
            Mandal objresult = objDB.ChangeMandalstatus(model);
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
            return RedirectToAction("MandalList", "Master");
        }

        #endregion

        #region Division Master 
        [HttpGet]
        public ActionResult AddDivision(int? ID)
        {
            Division model = new Division();
            ViewBag.Mandal = MasterDB.Dropdown(31, 0);
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = objDB.GetDivisionByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddDivision(Division model)
        {
            Division result = new Division();
            ViewBag.Mandal = MasterDB.Dropdown(31, 0);
            if (model.ID > 0)
            {
                result = MasterDB.UpdateDivision(model);
            }
            else
            {
                result = MasterDB.AddDivision(model);
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
                return View(model);
            }
            return RedirectToAction("DivisionList", "Master");
        }
        [HttpGet]
        public ActionResult DivisionList()
        {
            Division model = new Division();
            model = MasterDB.DivisionList(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult ChangeDivisionStatus(bool Isactive, int ID)
        {
            Division model = new Division();
            model.IsActive = Isactive;
            model.ID = ID;
            model = MasterDB.ChangeDivisionstatus(model);
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
            return RedirectToAction("DivisionList", "Master");
        }
        #endregion

        #region Comission Master 

        [HttpGet]
        public ActionResult AddComission(int? ID)
        {
            if (ID > 0)
            {
                Comission objresult = objDB.GetComissionDetails(ID);
                return View(objresult);
            }
            return View(new Comission());
        }
        [HttpPost]
        public ActionResult AddComission(Comission model)
        {
            Comission objresult = new Comission();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateComission(model);
            }
            else
            {
                objresult = objDB.SaveComission(model);
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

            return RedirectToAction("ComissionList", "Master");
        }
        public ActionResult ComissionList()
        {
            Comission obj = new Comission();
            obj.list = objDB.ComissionList();
            return View(obj);
        }
        public ActionResult ChangeComissionStatus(bool IsActive, int ID)
        {
            Comission model = new Comission();
            model.IsActive = IsActive;
            model.ID = ID;
            Comission objresult = objDB.ChangeComissionstatus(model);
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
            return RedirectToAction("ComissionList", "Master");
        }

        #endregion

        #region Pay-Comission Master 

        [HttpGet]
        public ActionResult AddPayComission(int? ID)
        {
            ViewBag.Level = MasterDB.Dropdown(17, 0);
            if (ID > 0)
            {
                PayComission objresult = objDB.GetPayComissionDetails(ID);
                return View(objresult);
            }
            return View(new PayComission());
        }
        [HttpPost]
        public ActionResult AddPayComission(PayComission model)
        {
            PayComission objresult = new PayComission();
            ViewBag.Level = MasterDB.Dropdown(17, 0);
            if (model.ID > 0)
            {
                objresult = objDB.UpdatePayComission(model);
            }
            else
            {
                objresult = objDB.SavePayComission(model);
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

            return RedirectToAction("PayComissionList", "Master");
        }
        public ActionResult PayComissionList()
        {
            PayComission obj = new PayComission();
            obj.list = objDB.PayComissionList();
            return View(obj);
        }

        #endregion
    }
}