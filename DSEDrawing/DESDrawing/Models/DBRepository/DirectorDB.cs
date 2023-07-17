using Dapper;
using DESDrawing.Models.Manager;
using DESDrawing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESDrawing.Models.DBRepository
{
    public class DirectorDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();
        public static Dashboard JointDirectorDashboard()
        {
            try
            {
                Dashboard obj = new Dashboard();
                DashboardReq model = new DashboardReq();
                model.Userid = SessionManager.UserId;
                model.role = SessionManager.Role;
                using (SqlConnection objConnection = new SqlConnection(DBHelperDapper.connection()))
                {   
                    try
                    {
                        var reader = objConnection.QueryMultiple("Fetch_Dashboard", new { Userid=model.Userid }, commandType: CommandType.StoredProcedure);
                        //var Director = reader.Read<DirectorList>().ToList();
                        var Details = reader.Read<Dashboard>().FirstOrDefault();
                        var Appicant = reader.Read<Appicant>().ToList();
                        var AppicantDoc = reader.Read<ApplicantDoc>().ToList();

                        obj = Details;
                        obj.AppicantList = Appicant;
                        obj.DocList = AppicantDoc;
                        
                        //obj.List = Director;

                        obj.response = "success";
                        obj.message = "success";
                    }
                    catch (Exception ex)
                    {
                        obj.response = "failure";
                        obj.message = ex.Message;
                    }
                    return obj;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Dashboard AdminDashboard()
        {
            try
            {
                Dashboard obj = new Dashboard();
                DashboardReq model = new DashboardReq();
                model.Userid = SessionManager.UserId;
                using (SqlConnection objConnection = new SqlConnection(DBHelperDapper.connection()))
                {
                    try
                    {
                        var reader = objConnection.QueryMultiple("Fetch_Admin_Dashboard", new { Userid = model.Userid }, commandType: CommandType.StoredProcedure);
                        var Details = reader.Read<Dashboard>().FirstOrDefault();
                        var Appicant = reader.Read<Appicant>().ToList();

                        obj = Details;
                        obj.AppicantList = Appicant;


                        obj.response = "success";
                        obj.message = "success";
                    }
                    catch (Exception ex)
                    {
                        obj.response = "failure";
                        obj.message = ex.Message;
                    }
                    return obj;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static List<DirectorList> DirectorList(DirectorList  model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("ZoneId", model.ZoneId);
                query.Add("Userid", SessionManager.UserId);
                query.Add("Type", model.Role);
                List<DirectorList> _iresult = DBHelperDapper.DAAddAndReturnModelList<DirectorList>("Proc_Fetch_DirectorList", query).ToList();
                return _iresult;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Applicant ApplicantDetails(Applicant obj)
        {
            // Applicant model = new Applicant();
            try
            {
                using (SqlConnection objConnection = new SqlConnection(DBHelperDapper.connection()))
                {
                    try
                    {
                        var query = new DynamicParameters();
                        query.Add("@PK_Id", obj.PK_Applicant_id);
                        var reader = objConnection.QueryMultiple("Fetch_Application", query, commandType: CommandType.StoredProcedure);

                        var ApplicantDetails = reader.Read<Applicant>().FirstOrDefault();
                        var DocList = reader.Read<Applicant>().ToList();
                        var List1 = reader.Read<Applicant>().ToList();

                        obj = ApplicantDetails;
                        obj.DocumentList = DocList;
                        obj.RemarkLists = List1;

                        obj.response = "success";
                        obj.message = "success";
                    }
                    catch (Exception ex)
                    {
                        obj.response = "failure";
                        obj.message = ex.Message;
                    }
                    return obj;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region   Reply AND Forward Priyanshu 
        public Applicant SubmitReply(Applicant model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@ApplicationID", model.PK_Applicant_id);
                Parametor.Add("@UserType", model.User_Type);
                Parametor.Add("@Remark", model.Remark);
                Parametor.Add("@Doc_filepath", model.ReplyFile);
                Parametor.Add("@Status", "Query");
                
                Parametor.Add("@Created_By", model.Create_by);
                Applicant save = _dapper.Execute<Applicant>("Insert_Application_Approval", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<SelectListItem> UserList()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            try
            {
                var param = new DynamicParameters();
                param.Add("@userid" , SessionManager.UserId);
                obj = _dapper.GetAll<SelectListItem>("Proc_bindusers_forward", param);
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Applicant ForwardApplication(Applicant model)
        {
            try
            {
                var Parametor = new DynamicParameters();

                Parametor.Add("@ApplicationID", model.PK_Applicant_id1);
                Parametor.Add("@UserId", model.UserId);
                Parametor.Add("@Remark", model.ForwardRemark);
                Parametor.Add("@Created_By", model.Create_by);
                Parametor.Add("@File", model.ForwardFile);
                Parametor.Add("@User_type", "Officer");
                Parametor.Add("@status", "Forwarded");
                Applicant save = _dapper.Execute<Applicant>("Insert_Application_Forward", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Document Approval
        public List<SelectListItem> GetApplicant(int UserId)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@UserId", UserId);
                List<SelectListItem> ApplicantList = _dapper.GetAll<SelectListItem>("proc_bindApplicant_No_byid", Parametor);
                return ApplicantList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Applicant ApplicantLists(int ApplicantID)
        {
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    Applicant obj = new Applicant();
                    var query = new DynamicParameters();
                    query.Add("@ApplicantNo", ApplicantID);
                    query.Add("@Userid", SessionManager.UserId);
                    var reader = con.QueryMultiple("Fetch_Application_byNo", query, commandType: CommandType.StoredProcedure);
                    var ApplicantDetails = reader.Read<Applicant>().FirstOrDefault();
                    var DocList = reader.Read<Applicant>().ToList();
                    obj = ApplicantDetails;
                    obj.DocumentList = DocList;
                    return obj;

                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }

        }
        public Applicant SetApplicationStatus(Applicant model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Id", model.FK_Applicant_id);
                Parametor.Add("@Status", model.Status);
                Parametor.Add("@remark", model.Remark);
                Parametor.Add("@createBy", SessionManager.UserId);
                Parametor.Add("@docType", model.Document_type);
                Applicant save = _dapper.Execute<Applicant>("Approve_Documents", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Status Wise Application List
        public List<Applicant> ApplicationsDetails(string Status)
        {

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Status", Status);
                parameters.Add("@Userid", SessionManager.UserId);
                List<Applicant> Appicantlist = _dapper.GetAll<Applicant>("Fetch_Application_Details", parameters);
                return Appicantlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        public Applicant DispatchedApplication(Applicant model)
        {
            try
            {

                var Parametor = new DynamicParameters();

                Parametor.Add("@FK_Applicant_id", model.PK_Applicant_id);
                Parametor.Add("@DrawingNo", model.DrawingNo);
                Parametor.Add("@DispatchDate", model.Date);
                Parametor.Add("@RefNo", model.RefNo);
                Parametor.Add("@SignFilePath", model.SignFile);
                Parametor.Add("@DispatchBy", model.Create_by);

                Applicant save = _dapper.Execute<Applicant>("Dispatch_Certificate", Parametor);
                return save;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    