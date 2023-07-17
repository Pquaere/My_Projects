using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class Admin
    {
    }

    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int ZoneId { get; set; }
        public int RegionId { get; set; }
        public int DiscomId { get; set; }
        public int RoleID { get; set; }
        public string DistrictName { get; set; }
        public string DiscomName { get; set; }
        public string RegionName { get; set; }
        public string ZoneName { get; set; }
        public string Pincode { get; set; }
        public string Role { get; set; }
        public string Created_at { get; set; }
        public string Lastlogin { get; set; }
        public bool Isactive { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Users> Userslist { get; set; }
    }
}