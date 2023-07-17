using DESDrawing.Models;
using DESDrawing.Models.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESDrawing.Controllers
{
    public class HomeController : Controller
    {
        ApplicantDB obj = new ApplicantDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Application Document (Shalini)
        [HttpGet]
        public ActionResult ApplicationDocument(string PK_ID)
        {
            Applicant model = new Applicant();
            model.PK_Applicant_id = Convert.ToInt32(PK_ID);
            model = obj.ApplicationDoc(model);
            return View(model);
        }
        #endregion

        [HttpGet]
        public ActionResult DrawingApproval(string ApplicantID)
        {
            ApplicantDispatch model = new ApplicantDispatch();
            model.FK_Applicant_id = Convert.ToInt32(ApplicantID);
            model = obj.ApplicantDispatch(model);
            return View(model);
        }

        public ActionResult SummaryReport(SummaryReport model)
        {
            MasterDB objdb = new MasterDB();
            IEnumerable<SelectListItem> DiscomOffice = objdb.Discomofficesdrop();
            ViewBag.DiscomOffice = DiscomOffice;
            model = obj.SummaryReport(model);
            return View(model);
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

    }
}