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
    public class DirectorController : Controller
    {
        AdminDB objDB = new AdminDB();
        
        // GET: JointDirector
        #region Dashboard
        public ActionResult Dashboard()
        {
            Dashboard model = new Dashboard();
            DirectorDB dB = new DirectorDB();
            IEnumerable<SelectListItem> zones = objDB.GetZones(SessionManager.RegionId);
            ViewBag.zones = zones;
            model = DirectorDB.JointDirectorDashboard();
            IEnumerable<SelectListItem> User = dB.UserList();
            ViewBag.User = User;
            return View(model);
        }
        [HttpPost]
        public JsonResult DirectorList(string ZoneID, string Type)
        {
            DirectorList model = new DirectorList();
            if (string.IsNullOrEmpty(ZoneID))
            {
                model.ZoneId = 0;
            }
            else
            {
                model.ZoneId = Convert.ToInt32(ZoneID);
            }
            model.Role = Type;
            model.List = DirectorDB.DirectorList(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region  Approve Application 
        public ActionResult ApplicantDetails(string ApplicantID)
        {

            Applicant model = new Applicant();
            DirectorDB obj = new DirectorDB();
            model.PK_Applicant_id = Convert.ToInt32(ApplicantID);
            model = DirectorDB.ApplicantDetails(model);
            IEnumerable<SelectListItem> User = obj.UserList();
            ViewBag.User = User;
            foreach (var i in model.DocumentList)
            {
                if (i.Document_type == "Signature")
                {
                    model.SignatureFile = (i.Doc_filepath);
                }
                else if (i.Document_type == "SLD")
                {
                    model.SLDFile = (i.Doc_filepath);
                }
                else if (i.Document_type == "Plant Layout")
                {
                    model.PlantFile = (i.Doc_filepath);
                }
                else if (i.Document_type == "Earthing Arrangement")
                {
                    model.EarthingFile = (i.Doc_filepath);
                }
                else
                {
                    model.OtherFile = i.OtherFile;
                }
            }
            return View(model);
        }

        #endregion

        #region Priyanshu
        [HttpPost]
        public ActionResult SubmitReply(Applicant model)
          {
            model.Create_by = Convert.ToInt32(SessionManager.UserId);
            model.User_Type = "Officer";
            DirectorDB objDB = new DirectorDB();
            Applicant objresult = new Applicant();
            objresult = objDB.SubmitReply(model);

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

            return RedirectToAction("Dashboard", "Director");
        }
        [HttpPost]
        public ActionResult ForwardApplication(Applicant model)
        {
            model.Create_by = Convert.ToInt32(SessionManager.UserId);

            DirectorDB objDB = new DirectorDB();
            Applicant objresult = new Applicant();
            objresult = objDB.ForwardApplication(model);

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

            return RedirectToAction("Dashboard", "Director");
        }
        #endregion

        #region  Application Approve Document
        public ActionResult ApplicantDocument(int? ApplicantID)
        {
            Applicant model = new Applicant();
            DirectorDB objDB = new DirectorDB();
            model.PK_Applicant_id = Convert.ToInt32(ApplicantID);
            IEnumerable<SelectListItem> Application = objDB.GetApplicant(Convert.ToInt32(SessionManager.UserId));
            ViewBag.Applicantno = Application;
            return View(model);
        }
        public JsonResult ApplicantList(int ApplicantID)
        {
            Applicant model = new Applicant();
            DirectorDB dB = new DirectorDB();
            model = dB.ApplicantLists(ApplicantID);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ApproveDoc(Applicant model)
        {
            Applicant objresponse = new Applicant();
            DirectorDB objDB = new DirectorDB();
            objresponse = objDB.SetApplicationStatus(model);
            if (objresponse.flag != 0 || objresponse.flag > 0)
            {
                TempData["code"] = "1";
                TempData["Msg"] = objresponse.message;                
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = "Something Went Wrong";                
            }
            return RedirectToAction("ApplicantDocument", "Director", new { ApplicantID = model.FK_Applicant_id });
        }
        #endregion        

        #region Status Wise Application List
        public ActionResult Application(string Status)
        {
            if (Status == "Declined")
            {
                Status = "Rejected";
            };

            Applicant model = new Applicant();
            DirectorDB dB = new DirectorDB();
            ViewBag.status = Status;
            model.AppicantList = dB.ApplicationsDetails(Status);
            IEnumerable<SelectListItem> User = dB.UserList();
            ViewBag.User = User;
            return View(model);
        }
        #endregion


          #region Priyanshu
        public ActionResult DrawingApprovel()
        {
            return View();
        }
        public ActionResult Dispatched(Applicant model)
        {
            model.Create_by = Convert.ToInt32(SessionManager.UserId);

            DirectorDB objDB = new DirectorDB();
            Applicant objresult = new Applicant();
            objresult = objDB.DispatchedApplication(model);

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

            return RedirectToAction("Dashboard", "Director");
        }
        #endregion

        #region Summary Report
        public ActionResult SummaryReport(SummaryReport model)
        {
            ApplicantDB obj = new ApplicantDB();
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
        #endregion
    }
}