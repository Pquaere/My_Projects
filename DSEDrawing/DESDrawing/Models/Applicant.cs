using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int FK_District_id { get; set; }
        public string State_Name { get; set; }
        public string SignFile { get; set; }
        public string RefNo { get; set; }
        public string Date { get; set; }
        public string DrawingNo { get; set; }
        public string Name { get; set; }
        public string District_name { get; set; }
        public int PK_Applicant_id { get; set; }
        public int PK_Applicant_id1 { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Applicant_No { get; set; }
        public string Gender { get; set; }
        public DateTime Dt_of_application { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string User_Type { get; set; }
        public int Create_by { get; set; }
        public int Updated_by { get; set; }
        public bool Isactive { get; set; }
        public int flag { get; set; }
        public string Tehsil_name { get; set; }
        public string Town_name { get; set; }
        public int FK_City_id { get; set; }
        public int FK_State_id { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public string LIC_contractor { get; set; }
        public string LIC_supervisor { get; set; }
        public string LEC { get; set; }
        public string Wireman { get; set; }
        public string LIC_Address { get; set; }
        public string FirmName { get; set; }
        public string LicensedNo { get; set; }
        public string LIC_validity { get; set; }
        public DateTime validity { get; set; }
        public string HT_Existing { get; set; }
        public string HT_proposed { get; set; }
        public string HT_capacity { get; set; }
        public string DG_Existing { get; set; }
        public string DG_proposed { get; set; }
        public string DG_capacity { get; set; }
        public string MSB_Existing { get; set; }
        public string MSB_proposed { get; set; }
        public string MSB_capacity { get; set; }
        public string TL_Existing { get; set; }
        public string TL_proposed { get; set; }
        public string TL_capacity { get; set; }
        public string DTC_Existing { get; set; }
        public string DTC_proposed { get; set; }
        public string DTC_capacity { get; set; }
        public string IPP_Existing { get; set; }
        public string IPP_proposed { get; set; }
        public string IPP_capacity { get; set; }
        public string Other_Existing { get; set; }
        public string Other_proposed { get; set; }
        public string Other_capacity { get; set; }
        public string InstallationType { get; set; }
        public string SLDFile { get; set; }
        public string PlantFile { get; set; }
        public string EarthingFile { get; set; }
        public string OtherFile { get; set; }
        public string SignatureFile { get; set; }
        public string message { get; set; }
        public string response { get; set; }
        public string Total { get; set; }
        public string Document_type { get; set; }
        public string Documenttype { get; set; }
        public string Doc_filepath { get; set; }
        public int FK_Applicant_id { get; set; }
        public bool IsAccept { get; set; }
        public string AppDate { get; set; }
        public string Capicity { get; set; }
        public string Status { get; set; }
        public string Mobile { get; set; }
        public string ReplyFile { get; set; }
        public string ForwardFile { get; set; }
        public string Applicant_Id { get; set; }
        public string ApprovalID { get; set; }

        public string Applicant_Name { get; set; }
        public string Remark { get; set; }
        public string Created_at { get; set; }
        public string RemarkBy { get; set; }
        public int UserId { get; set; }
        public string ForwardRemark { get; set; }
        public List<Applicant> DocumentList { get; set; }
        public List<Applicant> list { get; set; }
        public List<Applicant> RemarkLists { get; set; }
        public List<Applicant> AppicantList { get; set; }
        public List<AppDoc> doclist { get; set; }
        public List<AppDoc1> rlist { get; set; }
    }

    public class ApplicantDashboard
    {
        public int CustomerID { get; set; }
        public int FK_Applicant_id { get; set; }
        public int TotalApplication { get; set; }
        public int PendingApplication { get; set; }
        public int ApprovedApplication { get; set; }
        public int QueryApplication { get; set; }
        public int DeclinedApplication { get; set; }
        public int ResubmittedApplication { get; set; }
        public string response { get; set; }
        public string message { get; set; }
        public List<Applicant> list { get; set; }
        public int ID { get; set; }
        public string Remark { get; set; }
        public string filepath { get; set; }

    }
    public class AppDoc
    {
        public int PK_Applicant_id { get; set; }
        public int PK_Document_id { get; set; }
        public string Document_type { get; set; }
        public string Doc_filepath { get; set; }
        public string Created_at { get; set; }
    }
    public class AppDoc1
    {
        public string Remark { get; set; }
        public string Doc_filepath { get; set; }
    }

}