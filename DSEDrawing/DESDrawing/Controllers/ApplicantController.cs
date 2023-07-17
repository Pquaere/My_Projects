using DESDrawing.Models;
using DESDrawing.Models.DBRepository;
using DESDrawing.Models.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DESDrawing.Models;
using DESDrawing.Models.Manager;
using DESDrawing.Models.DBRepository;
using System.IO;
using DESDrawing.Filter;

namespace DESDrawing.Controllers
{
    [AuthorizeAdmin]
    public class ApplicantController : Controller
    {
        // GET: Applicant
        ApplicantDB obj = new ApplicantDB();
        public ActionResult Index()
        {
            return View();
        }

        #region Applicant Dashboard (Shalini)
        [Route("Dashboard")]
        public ActionResult Dashboard()
        {
            long uid = 0;
            try { uid = SessionManager.UserId; }
            catch {; }
            if (uid < 1) { RedirectToAction("Login"); }
            ApplicantDashboard model = new ApplicantDashboard();
            model = ApplicantDB.ApplicantList();
            return View(model);
        }
        public JsonResult GetApplicantReply(string Id)
        {
            ApplicantDashboard model = new ApplicantDashboard();
            model.ID = Convert.ToInt32(Id);
            model = obj.GetApplicantReply(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Application Form
        [Route("ApplicantionForm")]
        [HttpGet]
        public ActionResult ApplicantionForm()
        {
            Applicant model = new Applicant();
            ViewBag.District = obj.BindDistrictDropDown();
            if (SessionManager.CustomerID != 0)
            {
                model.First_name = SessionManager.Name;
                model.Email = SessionManager.Email;
                model.Phone_number = SessionManager.Mobile;
                model.FK_District_id = Convert.ToInt32(SessionManager.FK_District_id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult ApplicantionForm(Applicant model)
        {
            Applicant objresponse = new Applicant();

            ViewBag.District = obj.BindDistrictDropDown();
            //SessionManager.CustomerID = 9999;//testing.....
            if (SessionManager.CustomerID != 0)
            {
                objresponse = obj.ApplicantReg(model);
                if (objresponse.flag != 0 || objresponse.flag > 0)
                {
                    TempData["code"] = "1";
                    TempData["Msg"] = objresponse.message;
                    return RedirectToAction("Dashboard", "Applicant");
                }
                else
                {
                    TempData["code"] = "0";
                    TempData["Msg"] = "Something Went Wrong";
                    return View(model);
                }
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = "Customer ID not Send Please Retry or Contact Administrator.";
                return View(model);
            }
        }
        public JsonResult Getsubcities(int FK_State_id)
        {
            AdminDB ADB = new AdminDB();
            List<SelectListItem> modelresult = ADB.GetCities(FK_State_id);
            return Json(modelresult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddImageFile(HttpPostedFileBase File, string type)
        {
            string Dirpath = "";
            if (type == "ReplyFile")
            {
                Dirpath = "/ApplicantDoc/ReplyDoc/";
            }
            else if (type == "ForwardFile")
            {
                Dirpath = "/ApplicantDoc/ForwardFile/";
            }
            else if (type == "SignFile")
            {
                Dirpath = "/ApplicantDoc/SignFile/";
            }
            else
            {
                Dirpath = "/ApplicantDoc/";
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
        #endregion

        #region VIEW Application
        public ActionResult ViewApplicantDetails(string ApplicantID)
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


        #region Resubmit Application Form
        [Route("UpdateApplicationForm")]
        [HttpGet]
        public ActionResult UpdateApplicationForm(int PK_Applicant_ID)
        {
            Applicant model = new Applicant();
            model = obj.GetApplicantFormDetails(PK_Applicant_ID);
            if (model.DocumentList.Count > 0)
            {
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
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateApplicationForm(Applicant model)
        {
            Applicant objresponse = new Applicant();
            if (SessionManager.CustomerID != 0)
            {
                objresponse = obj.UpdateApplication(model);
                if (objresponse.flag != 0 || objresponse.flag > 0)
                {
                    TempData["code"] = "1";
                    TempData["Msg"] = objresponse.message;
                    return RedirectToAction("Dashboard", "Applicant");
                }
                else
                {
                    TempData["code"] = "0";
                    TempData["Msg"] = "Something Went Wrong";
                    return View(model);
                }
            }
            else
            {
                TempData["code"] = "0";
                TempData["Msg"] = "Customer ID not Send Please Retry or Contact Administrator.";
                return View(model);
            }
        }
        #endregion


    }
}