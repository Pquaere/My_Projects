using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class City
    {
        public int ID { get; set; }
        public int StateID { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public bool Isactive { get; set; }
        public List<City> CityList { get; set; }
    }
}