using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public string Customer_Name { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public string CPass { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public string Phone_Number { get; set; }
        public string FK_District_id { get; set; }
        public int Create_by { get; set; }
        public int Updated_by { get; set; }
        public bool Isactive { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Customer> clist { get; set; }
    }
}