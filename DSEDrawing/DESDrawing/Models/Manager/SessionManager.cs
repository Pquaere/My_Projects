using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DESDrawing.Models.Manager
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



        public static int CustomerID
        {
            get
            {
                if (HttpContext.Current.Session["CustomerID"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["CustomerID"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["CustomerID"] = value;
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

        public void Dispose()
        {

        }
        public static int Size => 200;


        #region New 
        public static long UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] == null)
                {
                    return 0;
                }
                else
                {
                    return long.Parse(HttpContext.Current.Session["UserId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
        public static string RoleName
        {
            get
            {
                if (HttpContext.Current.Session["RoleName"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["RoleName"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["RoleName"] = value;
            }
        }
        public static int Role
        {
            get
            {
                if (HttpContext.Current.Session["Role"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(HttpContext.Current.Session["Role"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["Role"] = value;
            }
        }
        public static string FK_City_id
        {
            get
            {
                if (HttpContext.Current.Session["FK_City_id"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["FK_City_id"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["FK_City_id"] = value;
            }
        }
        public static int DiscomId
        {
            get
            {
                if (HttpContext.Current.Session["DiscomId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse( HttpContext.Current.Session["DiscomId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["DiscomId"] = value;
            }
        }
        public static int ZoneId
        {
            get
            {
                if (HttpContext.Current.Session["ZoneId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse( HttpContext.Current.Session["ZoneId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["ZoneId"] = value;
            }
        }
        public static int RegionId
        {
            get
            {
                if (HttpContext.Current.Session["RegionId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse( HttpContext.Current.Session["RegionId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["RegionId"] = value;
            }
        }
        public static int DistrictId
        {
            get
            {
                if (HttpContext.Current.Session["DistrictId"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse( HttpContext.Current.Session["DistrictId"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["DistrictId"] = value;
            }
        }

        public static string FK_District_id
        {
            get
            {
                if (HttpContext.Current.Session["FK_District_id"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["FK_District_id"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["FK_District_id"] = value;
            }
        }
        public string UserExceptionSession
        {
            get
            {
                if (HttpContext.Current.Session["UserExceptionSession"] != null)
                {
                    return Convert.ToString((HttpContext.Current.Session["UserExceptionSession"]));
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
        #endregion
    }
}