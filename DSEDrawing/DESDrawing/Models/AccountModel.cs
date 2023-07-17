using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class AccountModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int DiscomID { get; set; }
        public int ZoneID { get; set; }
        public int RegionID { get; set; }
        public int DistrictID { get; set; }
        [Required (ErrorMessage ="Please Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string response { get; set; }
        public string FullName { get; set; }
        public int Role { get; set; }
        public string RoleName { get; set; }
        public string message { get; set; }
        public int Flag { get; set; }
    }

    public enum RoleType
    {
        Admin =1,
        District_Officer=2,
        Joint_Director=3,
        Deputy_Director=4,
        Assistant_Director=5,
        Head_Office=6
    }

}