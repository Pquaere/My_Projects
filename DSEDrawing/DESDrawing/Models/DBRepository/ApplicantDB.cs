using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using DESDrawing.Models;
using DESDrawing.Models.DBRepository;
using DESDrawing.Models.Manager;
using System.Data;

namespace DESDrawing.Models.DBRepository
{
    public class ApplicantDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();

        #region Applicant Dashboard (Shalini)
        public static ApplicantDashboard ApplicantList()
        {
            try
            {
                ApplicantDashboard obj = new ApplicantDashboard();
                Applicant model = new Applicant();
                //model.CustomerID = SessionManager.CustomerID;
                using (SqlConnection objConnection = new SqlConnection(DBHelperDapper.connection()))
                {
                    try
                    {
                        var query = new DynamicParameters();
                        query.Add("@Custid", SessionManager.CustomerID);
                        var reader = objConnection.QueryMultiple("Get_ApplicationBy_CustID", query, commandType: CommandType.StoredProcedure);
                        var Details = reader.Read<ApplicantDashboard>().FirstOrDefault();
                        var Appicant = reader.Read<Applicant>().ToList();
                        obj = Details;
                        obj.list = Appicant;
                    }
                    catch (Exception ex)
                    {

                    }
                    return obj;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ApplicantDashboard GetApplicantReply(ApplicantDashboard model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("@ID", model.ID);
                ApplicantDashboard _iresult = _dapper.Execute<ApplicantDashboard>("Fetch_RemarkFilePath_ByID", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #endregion

        #region Applicant Registration
        public List<SelectListItem> BindDistrictDropDown()
        {
            try
            {
                var queryParameters = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_binddistrict", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<SelectListItem> BindStateDropDown()
        {
            try
            {
                var queryParameters = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_bindstate", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Applicant ApplicantReg(Applicant model)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@First_name", model.First_name);
                queryParameters.Add("@Last_name", model.Last_name);
                queryParameters.Add("@FK_Customer_id", SessionManager.CustomerID);
                queryParameters.Add("@Gender", model.Gender);
                //queryParameters.Add("@Dt_of_application", model.Dt_of_application);
                queryParameters.Add("@Phone_number", model.Phone_number);
                queryParameters.Add("@Email", model.Email);
                queryParameters.Add("@Address", model.Address);
                queryParameters.Add("@Tehsil_Name", model.Tehsil_name);
                queryParameters.Add("@Area_Name", model.Town_name);
                queryParameters.Add("@FK_District_id", model.FK_District_id);
                queryParameters.Add("@State_Name", "Uttar Pradesh");
                queryParameters.Add("@Pincode", model.Pincode);
                queryParameters.Add("@Country", "INDIA");
                queryParameters.Add("@LIC_Contractor", model.LIC_contractor + "");
                queryParameters.Add("@LIC_LEC", model.LEC +"");
                queryParameters.Add("@LIC_Supervisor", model.LIC_supervisor + "");
                queryParameters.Add("@LIC_wireman", model.Wireman + "");
                queryParameters.Add("@LIC_Address", model.LIC_Address + "");
                queryParameters.Add("@LIC_firmName", model.FirmName + "");
                if (model.validity == null || model.validity.Year<2000)
                {
                    queryParameters.Add("@LIC_validity", new DateTime(1900,01,1));
                }
                else
                {
                    queryParameters.Add("@LIC_validity", model.validity);
                }
                
                queryParameters.Add("@LIC_Number", model.LicensedNo + "");
                
                queryParameters.Add("@HT_Existing", GetStringToInt(model.HT_Existing));
                queryParameters.Add("@HT_capacity", GetStringToInt(model.HT_capacity));
                queryParameters.Add("@HT_proposed", GetStringToInt(model.HT_proposed));
                queryParameters.Add("@DG_capacity", GetStringToInt(model.DG_capacity));
                queryParameters.Add("@DG_Existing", GetStringToInt(model.DG_Existing));
                queryParameters.Add("@DG_proposed", GetStringToInt(model.DG_proposed));
                queryParameters.Add("@MSB_capacity", GetStringToInt(model.MSB_capacity));
                queryParameters.Add("@MSB_Existing", GetStringToInt(model.MSB_Existing));
                queryParameters.Add("@MSB_proposed", GetStringToInt(model.MSB_proposed));
                queryParameters.Add("@TL_capacity", GetStringToInt(model.TL_capacity)); ;
                queryParameters.Add("@TL_Existing", GetStringToInt(model.TL_Existing));
                queryParameters.Add("@TL_proposed", GetStringToInt(model.TL_proposed));
                queryParameters.Add("@DTC_capacity", GetStringToInt(model.DTC_capacity));
                queryParameters.Add("@DTC_Existing", GetStringToInt(model.DTC_Existing));
                queryParameters.Add("@DTC_proposed", GetStringToInt(model.DTC_proposed));
                queryParameters.Add("@IPP_capacity", GetStringToInt(model.IPP_capacity));
                queryParameters.Add("@IPP_Existing", GetStringToInt(model.IPP_Existing));
                queryParameters.Add("@IPP_proposed", GetStringToInt(model.IPP_proposed));
                queryParameters.Add("@Other_capacity", GetStringToInt(model.Other_capacity));
                queryParameters.Add("@Other_Existing", GetStringToInt(model.Other_Existing));
                queryParameters.Add("@Other_proposed", GetStringToInt(model.Other_proposed));
                queryParameters.Add("@InstallationType", model.InstallationType);
                queryParameters.Add("@TypeSignature", "Signature");
                queryParameters.Add("@SignatureFile", model.SignatureFile);
                queryParameters.Add("@TypeSLD", "SLD");
                queryParameters.Add("@SLDFile", model.SLDFile);
                queryParameters.Add("@TypePlantLayout", "Plant Layout");
                queryParameters.Add("@PlantLaoutFile", model.PlantFile);
                queryParameters.Add("@TypeEarthing", "Earthing Arrangement");
                queryParameters.Add("@EarthingFile", model.EarthingFile);
                queryParameters.Add("@TypeOther", "Others");
                queryParameters.Add("@OtherFile", model.OtherFile);
                queryParameters.Add("@IsAccept", model.IsAccept);
                queryParameters.Add("@Create_by", SessionManager.UserId);
                Applicant _iresult = _dapper.Execute<Applicant>("Insert_Applicant", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private int GetStringToInt(string value)
        {
            int val = 0;
            try
            {
                val = Convert.ToInt32(value);
            }
            catch {; }
            return val;
        }
        #endregion

        #region Update Application Form
        public Applicant GetApplicantFormDetails(int PK_Applicant_ID)
        {
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    Applicant obj = new Applicant();
                    var Parametor = new DynamicParameters();
                    Parametor.Add("@PK_Id", PK_Applicant_ID);
                    var reader = con.QueryMultiple("Fetch_Application", Parametor, commandType: CommandType.StoredProcedure);
                    var ApplicantDetails = reader.Read<Applicant>().FirstOrDefault();
                    var DocList = reader.Read<Applicant>().ToList();
                    var List1 = reader.Read<Applicant>().ToList();
                    obj = ApplicantDetails;
                    obj.DocumentList = DocList;
                    obj.RemarkLists = List1;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }


        public Applicant UpdateApplication(Applicant model)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@FK_Customer_id", SessionManager.CustomerID);
                queryParameters.Add("@PK_Applicant_id", model.PK_Applicant_id);
                queryParameters.Add("@HT_Existing", model.HT_Existing != null ? model.HT_Existing : model.HT_Existing != "" ? model.HT_Existing : "0");
                queryParameters.Add("@HT_capacity", model.HT_capacity);
                queryParameters.Add("@HT_proposed", model.HT_proposed);
                queryParameters.Add("@DG_capacity", model.DG_capacity);
                queryParameters.Add("@DG_Existing", model.DG_Existing != null ? model.DG_Existing : model.DG_Existing != "" ? model.DG_Existing : "0");
                queryParameters.Add("@DG_proposed", model.DG_proposed);
                queryParameters.Add("@MSB_capacity", model.MSB_capacity);
                queryParameters.Add("@MSB_Existing", model.MSB_Existing != null ? model.MSB_Existing : model.MSB_Existing != "" ? model.MSB_Existing : "0");
                queryParameters.Add("@MSB_proposed", model.MSB_proposed);
                queryParameters.Add("@TL_capacity", model.TL_capacity);
                queryParameters.Add("@TL_Existing", model.TL_Existing != null ? model.TL_Existing : model.TL_Existing != "" ? model.TL_Existing : "0");
                queryParameters.Add("@TL_proposed", model.TL_proposed);
                queryParameters.Add("@DTC_capacity", model.DTC_capacity);
                queryParameters.Add("@DTC_Existing", model.DTC_Existing != null ? model.DTC_Existing : model.DTC_Existing != "" ? model.DTC_Existing : "0");
                queryParameters.Add("@DTC_proposed", model.DTC_proposed);
                queryParameters.Add("@IPP_capacity", model.IPP_capacity);
                queryParameters.Add("@IPP_Existing", model.IPP_Existing != null ? model.IPP_Existing : model.IPP_Existing != "" ? model.IPP_Existing : "0");
                queryParameters.Add("@IPP_proposed", model.IPP_proposed);
                queryParameters.Add("@Other_capacity", model.Other_capacity);
                queryParameters.Add("@Other_Existing", model.Other_Existing);
                queryParameters.Add("@Other_proposed", model.Other_proposed);
                queryParameters.Add("@InstallationType", model.InstallationType);
                queryParameters.Add("@Remark", model.Remark);
                queryParameters.Add("@Type", "ResubmitFile");
                queryParameters.Add("@OtherFile", model.OtherFile);
                queryParameters.Add("@Status", "Resubmitted");
                queryParameters.Add("@UserType", "Customer");
                queryParameters.Add("@Create_by", SessionManager.CustomerID);
                queryParameters.Add("@Updated_by", SessionManager.CustomerID);
                Applicant _iresult = _dapper.Execute<Applicant>("Update_Application", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Application Document (Shalini)
        public Applicant ApplicationDoc(Applicant model)
        {
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    Applicant obj = new Applicant();
                    var parameter = new DynamicParameters();

                    parameter.Add("PK_Id", model.PK_Applicant_id);
                    var reader = con.QueryMultiple("Fetch_Application", parameter, commandType: CommandType.StoredProcedure);
                    var ApplicantDetails = reader.Read<Applicant>().FirstOrDefault();
                    var DocList = reader.Read<AppDoc>().ToList();
                    var List1 = reader.Read<AppDoc1>().ToList();
                    obj = ApplicantDetails;
                    obj.doclist = DocList;
                    obj.rlist = List1;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        public ApplicantDispatch ApplicantDispatch(ApplicantDispatch model)
        {
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    var parameter = new DynamicParameters();
                    ApplicantDispatch obj = new ApplicantDispatch();
                    parameter.Add("ApplicantID", model.FK_Applicant_id);
                    var reader = con.QueryMultiple("Fetch_Appli_Dispatch_Details", parameter, commandType: CommandType.StoredProcedure);
                    var ApplicantDetails = reader.Read<ApplicantDispatch>().FirstOrDefault();

                    obj = ApplicantDetails;

                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public SummaryReport SummaryReport(SummaryReport model)
        {
            
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    //    string status = "";
                    //    try
                    //    {
                    //        status = model.Status + "";
                    //    }
                    //    catch {; }
                    //    if (status.Trim().Length < 1)
                    //    {
                    //        status = "All";
                    //    }
                    var parameter = new DynamicParameters();
                    SummaryReport obj = new SummaryReport();
                    parameter.Add("@discomid", model.DiscomID);
                    parameter.Add("@regionid", model.RegionID);
                    parameter.Add("@zoneid", model.ZoneID);
                    parameter.Add("@districtid", model.DistrictID);
                    parameter.Add("@status", model.Status);
                    parameter.Add("@datefrom ", model.From);
                    parameter.Add("@dateto", model.To);
                    var reader = con.QueryMultiple("Fetch_Summary_Report", parameter, commandType: CommandType.StoredProcedure);
                    var ApplicantDetails = reader.Read<SummaryReport>().ToList();
                    var filter = reader.Read<SummaryReport>().FirstOrDefault();
                    obj = filter;
                    obj.SummaryList = ApplicantDetails;

                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}