using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class Dashboard
    {
        public int ZoneID { get; set; }
        public int DiscomID { get; set; }
        public int RegionID { get; set; }
        public int DistrictID { get; set; }
        public int ID { get; set; }
        public int Total { get; set; }
        public int Pending { get; set; }
        public int Query { get; set; }
        public int Approved { get; set; }
        public int Decline { get; set; }
        public int Resubmit { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string response { get; set; }
        public string message { get; set; }
        public string Status { get; set; }
        public int ApprovalID { get; set; }
        public string ReplyFile { get; set; }
        public string Remark { get; set; }
        public int UserId { get; set; }
        public string ForwardRemark { get; set; }
        public string ForwardFile { get; set; }
        public int Pk_Applicant_id { get; set; }
        public int Pk_Applicant_id1 { get; set; }
        public List<Appicant> AppicantList { get; set; }
        public List<DirectorList> List { get; set; }
        public List<ApplicantDoc> DocList { get; set; }
    }
    public class DashboardReq
    {
        public long Userid { get; set; }
        public int role { get; set; }
    }


    public class Appicant
    {
        public int Pk_Applicant_id { get; set; }
        public string Applicant_No { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ConsumerType { get; set; }
        public string ApplicationDate { get; set; }
        public string Capacity { get; set; }
        public string ForwordTo { get; set; }
        public string Status { get; set; }
        public List<Appicant> AppicantList { get; set; }
    }

    public class ApplicantDoc
    {
        public int FK_Applicant_id { get; set; }
        public string Document_type { get; set; }
        public string Doc_filepath { get; set; }
    }

    public class DirectorList
    {
        public int ZoneId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string RegionName { get; set; }
        public string DiscomOfficeName { get; set; }
        public string DistrictName { get; set; }
        public string Role { get; set; }
        public List<DirectorList> List { get; set; }


    }

    public class ApplicantDispatch
    {
        public int FK_Applicant_id { get; set; }
        public string Name { get; set; }
        public string DispatchDate { get; set; }
        public string Capacity { get; set; }
        public string CreatedAt { get; set; }
        public string Address { get; set; }
        public string DrawingNo { get; set; }
        public string RefNo { get; set; }
        public string Tahsil { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public List<ApplicantDispatch> List { get; set; }

    }


    public class SummaryReport
    {
        public string dateto { get; set; }
        public string datefrom { get; set; }
        
        public int PK_District_id{ get; set; }
        public int PK_Zone_id { get; set; }
        public int PK_Region_id { get; set; }
        public int PK_Discom_id { get; set; }
        public int ZoneID { get; set; }
        public int DiscomID { get; set; }
        public int RegionID { get; set; }
        public int DistrictID { get; set; }
        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Pk_Applicant_id { get; set; }
        public string Applicant_No { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ConsumerType { get; set; }
        public string ApplicationDate { get; set; }
        public string Capacity { get; set; }
        public string ForwordTo { get; set; }
        public string Status { get; set; }
        public string Discomoffice_name { get; set; }
        public string Zone_name { get; set; }
        public string Region_name { get; set; }
        public string District_name { get; set; }
        public List<SummaryReport> SummaryList { get; set; }
    }




}