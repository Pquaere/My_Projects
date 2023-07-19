using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HRPayroll.Models.Manager
{
    public class SessionManager : IDisposable
    {
        public static int Fk_UserTypeId
        {
            get
            {
                if (HttpContext.Current.Session["Fk_UserTypeId"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Session["Fk_UserTypeId"]);
                }
            }
            set
            {
                HttpContext.Current.Session["Fk_UserTypeId"] = value;
            }
        }
        public static string Usertype
        {
            get
            {
                if (HttpContext.Current.Session["Usertype"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["Usertype"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["Usertype"] = value;
            }
        }
        public static string UserTypeId
        {
            get
            {
                if (HttpContext.Current.Session["UserTypeId"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["UserTypeId"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["UserTypeId"] = value;
            }
        }
        public static string Name
        {
            get
            {
                if (HttpContext.Current.Session["Name"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["Name"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["Name"] = value;
            }
        }

        public static string OfficeName
        {
            get
            {
                if (HttpContext.Current.Session["OfficeName"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["OfficeName"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["OfficeName"] = value;
            }
        }

        public static string WorkingType
        {
            get
            {
                if (HttpContext.Current.Session["WorkingType"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["WorkingType"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["WorkingType"] = value;
            }
        }

        public static string PayclerkName
        {
            get
            {
                if (HttpContext.Current.Session["PayclerkName"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["PayclerkName"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["PayclerkName"] = value;
            }
        }

        public static string EOName
        {
            get
            {
                if (HttpContext.Current.Session["EOName"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["EOName"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["EOName"] = value;
            }
        }

        public static string OptName
        {
            get
            {
                if (HttpContext.Current.Session["OptName"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["OptName"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["OptName"] = value;
            }
        }

        public static string OptNo
        {
            get
            {
                if (HttpContext.Current.Session["OptNo"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["OptNo"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["OptNo"] = value;
            }
        }



        public static string ProfilePic
        {
            get
            {
                if (HttpContext.Current.Session["ProfilePic"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["ProfilePic"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["ProfilePic"] = value;
            }
        }
        public static string Mobile
        {
            get
            {
                if (HttpContext.Current.Session["Mobile"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["Mobile"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["Mobile"] = value;
            }
        }

        public static string PayclerkMobileNo
        {
            get
            {
                if (HttpContext.Current.Session["PayclerkMobileNo"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["PayclerkMobileNo"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["PayclerkMobileNo"] = value;
            }
        }


        public static long Fk_MemId
        {
            get
            {
                if (HttpContext.Current.Session["Fk_MemId"] == null)
                {
                    return 0;
                }
                else
                {
                    return long.Parse(HttpContext.Current.Session["Fk_MemId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["Fk_MemId"] = value;
            }
        }
        public static long Fk_RollId
        {
            get
            {
                if (HttpContext.Current.Session["Fk_RollId"] == null)
                {
                    return 0;
                }
                else
                {
                    return long.Parse(HttpContext.Current.Session["Fk_RollId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["Fk_RollId"] = value;
            }
        }
        public static string LoginId
        {
            get
            {
                if (HttpContext.Current.Session["LoginId"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["LoginId"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["LoginId"] = value;
            }
        }
        public static string Email
        {
            get
            {
                if (HttpContext.Current.Session["Email"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["Email"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }
        public static int DoctorId
        {
            get
            {
                if (HttpContext.Current.Session["DoctorId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["DoctorId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["DoctorId"] = value;
            }
        }
        public static DataTable UserPermissionDt
        {
            get
            {
                if (HttpContext.Current.Session["Permissions"] == null)
                {
                    return null;
                }
                else
                {
                    return (DataTable)HttpContext.Current.Session["Permissions"];
                }
            }
            set
            {
                HttpContext.Current.Session["Permissions"] = value;
            }
        }

        public static int Id
        {
            get
            {
                if (HttpContext.Current.Session["Id"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["Id"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["Id"] = value;
            }
        }
        public static int OfficeID
        {
            get
            {
                if (HttpContext.Current.Session["OfficeID"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["OfficeID"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["OfficeID"] = value;
            }
        }

        public static int PK_HospitalID
        {
            get
            {
                if (HttpContext.Current.Session["PK_HospitalID"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["PK_HospitalID"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["PK_HospitalID"] = value;
            }
        }
        public static int PK_LabID
        {
            get
            {
                if (HttpContext.Current.Session["PK_LabID"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["PK_LabID"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["PK_LabID"] = value;
            }
        }

        public static int UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["UserId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static int EmpId
        {
            get
            {
                if (HttpContext.Current.Session["EmpId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["EmpId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["EmpId"] = value;
            }
        }


        public static int CircleId
        {
            get
            {
                if (HttpContext.Current.Session["CircleId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["CircleId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["CircleId"] = value;
            }
        }

        public static int DepId
        {
            get
            {
                if (HttpContext.Current.Session["DepId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["DepId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["DepId"] = value;
            }
        }

        public static int WTypeId
        {
            get
            {
                if (HttpContext.Current.Session["WTypeId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["WTypeId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["WTypeId"] = value;
            }
        }

        public static int UTypeId
        {
            get
            {
                if (HttpContext.Current.Session["UTypeId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["UTypeId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["UTypeId"] = value;
            }
        }

        public static int AgencyTypeId
        {
            get
            {
                if (HttpContext.Current.Session["AgencyTypeId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["AgencyTypeId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["AgencyTypeId"] = value;
            }
        }

        public static string EmployeeCode
        {
            get
            {
                if (HttpContext.Current.Session["EmployeeCode"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["EmployeeCode"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["EmployeeCode"] = value;
            }
        }

        public static int CompanyId
        {
            get
            {
                if (HttpContext.Current.Session["CompanyId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["CompanyId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["CompanyId"] = value;
            }
        }
        public  static string UserExceptionSession
        {
            get
            {
                if (HttpContext.Current.Session["UserExceptionSession"] != null)
                {
                    return HttpContext.Current.Session["UserExceptionSession"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["UserExceptionSession"] = value;

            }
        }
        public  static string EmpCode
        {
            get
            {
                if (HttpContext.Current.Session["EmpCode"] != null)
                {
                    return HttpContext.Current.Session["EmpCode"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["EmpCode"] = value;

            }
        }

        public void Dispose()
        {

        }
        public static int Size => 200;
    }
}