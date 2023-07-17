using System;
using DESDrawing.Models.DBRepository;
using DESDrawing.Models.Manager;
using DESDrawing.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DESDrawing.Filter;

namespace DESDrawing.Controllers
{
    [AuthorizeAdmin]
    public class MasterController : Controller
    {
        SessionManager sm = new SessionManager();
        MasterDB objDB = new MasterDB();
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        #region City Master (Vaishnavi)
        public ActionResult City()
        {
            City obj = new City();
            obj.CityList = objDB.Citylist();
            return View(obj);
        }
        [HttpGet]
        public ActionResult AddCity(int? ID)
        {
            IEnumerable<SelectListItem> states = objDB.stateList();
            ViewBag.state = states;
            if (ID > 0)
            {
                City objresult = objDB.GetCityDetails(ID);
                return View(objresult);
            }
            return View(new City());
        }
        [HttpPost]
        public ActionResult AddCity(City model)
        {
            City objresult = new City();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateCity(model);
            }
            else
            {
                objresult = objDB.SaveCity(model);
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
                IEnumerable<SelectListItem> states = objDB.stateList();
                ViewBag.state = states;
                return View(model);
            }
            return RedirectToAction("City", "Master");
        }
        [HttpGet]
        public ActionResult ChangeCityStatus(bool Isactive, int ID)
        {
            City model = new City();
            model.Isactive = Isactive;
            model.ID = ID;
            City objresult = objDB.changecitystatus(model);
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
            return RedirectToAction("City", "Master");
        }
        #endregion

        #region Zone Master (Vaishnavi)
        public ActionResult Zone()
        {
            Zone obj = new Zone();
            obj.ZoneList = objDB.ZoneList();
            return View(obj);
        }
        [HttpGet]
        public ActionResult AddZone(int? ID)
        {
            IEnumerable<SelectListItem> Regions = objDB.RegionList();
            ViewBag.Regions = Regions;
            if (ID > 0)
            {
                Zone objresult = objDB.GetZoneDetails(ID);
                return View(objresult);
            }
            return View(new Zone());
        }
        [HttpPost]
        public ActionResult AddZone(Zone model)
        {
            Zone objresult = new Zone();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateZone(model);
            }
            else
            {
                objresult = objDB.SaveZone(model);
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
                IEnumerable<SelectListItem> Regions = objDB.RegionList();
                ViewBag.Regions = Regions;
                return View(model);
            }

            return RedirectToAction("Zone", "Master");
        }
        [HttpGet]
        public ActionResult ChangeZoneStatus(bool Isactive, int ID)
        {
            Zone model = new Zone();
            model.Isactive = Isactive;
            model.ID = ID;
            Zone objresult = objDB.changezonestatus(model);
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
            return RedirectToAction("Zone", "Master");
        }
        #endregion

        #region DiscomOffice Master (Shalini)
        public ActionResult DiscomOfficeList()
        {
            DiscomOffice obj = new DiscomOffice();
            obj.DiscomList = objDB.DiscomOfficelist();
            return View(obj);
        }
        [HttpGet]
        public ActionResult AddDiscomOffice(int? ID)
        {
            if (ID > 0)
            {
                DiscomOffice objresult = objDB.GetDiscomOfficeDetails(ID);
                return View(objresult);
            }
            return View(new DiscomOffice());
        }
        [HttpPost]
        public ActionResult AddDiscomOffice(DiscomOffice model)
        {
            DiscomOffice objresult = new DiscomOffice();
            if (model.ID > 0)
            {
                objresult = objDB.UpdateDiscomOffice(model);
            }
            else
            {
                objresult = objDB.SaveDiscomOffice(model);
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

            return RedirectToAction("DiscomOfficeList", "Master");
        }
        [HttpGet]
        public ActionResult ChangeDiscomOfficeStatus(bool Isactive, int ID)
        {
            DiscomOffice model = new DiscomOffice();
            model.Isactive = Isactive;
            model.ID = ID;
            DiscomOffice objresult = objDB.ChangeDiscomOfficestatus(model);
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
            return RedirectToAction("DiscomOfficeList", "Master");
        }
        #endregion

        #region Add regions (Akash Singh)
        [HttpGet]
        public ActionResult Region(int? ID) 
        {
            Region model = new Region();
            IEnumerable<SelectListItem> Discomoffices = objDB.Discomofficesdrop();

            ViewBag.Discomoffices = Discomoffices;
            if (ID > 0)
            {
                Region model1 = new Region();
                model  = objDB.ResionListById(ID);
                model1.DiscomofficeName = model.StateID;
                model1.Id = model.Id;
                model1.RegionName = model.RegionName;
                
                return View(model1);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveRegion(Region model)
        {
            Region res = new Region();
            IEnumerable<SelectListItem> Discomoffices = objDB.Discomofficesdrop();

            if (model.Id > 0)
            {
                res = objDB.EditRegion(model);
            }
            else
            {
                res = objDB.SaveRegion(model);
            }
            if (res.flag  >0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = res.message;
                return RedirectToAction("RegionList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = res.message;
                return RedirectToAction("Region", "Master");
            }
        }

        public ActionResult RegionList()      
        {
            Region res = new Region();
            res.Regionlst = objDB.ResionList();
            return View(res);
        }
        public ActionResult ChangeRegionStatus(bool Isactive, int ID)
        {
            Region model = new Region();
            model.Isactive = Isactive;
            model.Id = ID;
            Region objresult = objDB.changeRegionstatus(model);
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
            return RedirectToAction("RegionList", "Master");
        }

        #endregion

        #region State Master (Prity)
        [HttpGet]
        public ActionResult State(int? ID)
        {
            State model = new State();
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetStateByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult State(State model)
        {
            State result = new State();
            if (model.ID > 0)
            {
                result = MasterDB.UpdateState(model);
            }
            else
            {
                result = MasterDB.AddState(model);
            }

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("StateList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult StateList()
        {
            State model = new State();
            model = MasterDB.ListState(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult ChangeStateStatus(bool Isactive, int ID)
        {
            State model = new State();
            model.Isactive = Isactive;
            model.ID = ID;
             model = MasterDB.changeStatestatus(model);
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
            return RedirectToAction("StateList", "Master");
        }
        #endregion
        #region District Master (Prity)
        [HttpGet]
        public ActionResult AddDistrict(int? ID)
        {
            District model = new District();
            IEnumerable<SelectListItem> zones = objDB.BindZoneList();
            ViewBag.zones = zones;
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetDistrictByID(model);
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

            if (result.response.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.response.message;
                return RedirectToAction("DistrictList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.response.message;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DistrictList()
        {
            District model = new District();
            model = MasterDB.ListDistrict(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult ChangeDistrictStatus(bool Isactive, int ID)
        {
            District model = new District();
            model.Isactive = Isactive;
            model.ID = ID;
            model = MasterDB.changeDistrictstatus(model);
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
            return RedirectToAction("DistrictList", "Master");
        }
        #endregion

        #region Load Master (Shalini)
        [HttpGet]
        public ActionResult AddLoad(int? ID)
        {
            Load model = new Load();
            IEnumerable<SelectListItem> role = objDB.BindRoleList();
            ViewBag.role = role;
            if (ID > 0)
            {
                model.ID = Convert.ToInt32(ID);
                model = MasterDB.GetLoadByID(model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddLoad(Load model)
        {
            Load result = new Load();
            IEnumerable<SelectListItem> role = objDB.BindRoleList();
            ViewBag.role = role;
            if (model.ID > 0)
            {
                result = objDB.UpdateLoad(model);
            }
            else
            {
                result = objDB.SaveLoad(model);
            }
            if (result.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = result.message;
                return RedirectToAction("LoadList", "Master");
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = result.message;
            }
            return View(model);
        }
        public ActionResult LoadList()
        {
            Load obj = new Load();
            obj.LoadList = objDB.Loadlist();
            return View(obj);
        }
        #endregion



    }
}
