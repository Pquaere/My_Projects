using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class State
    {
        public int ID { get; set; }
        public string StateName { get; set; }
        public string Create_by { get; set; }
        public string Updated_by { get; set; }
        public bool Isactive { get; set; }
        public Response response { get; set; }
        public List<State> List { get; set; }
    }

        public class Response
        {
            public int flag { get; set; }
            public string message { get; set; }
        }
    public class District
    {
        public int ID { get; set; }
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
        public string DistrictName { get; set; }
        public string Create_by { get; set; }
        public string Updated_by { get; set; }
        public bool Isactive { get; set; }
        public Response response { get; set; }
        public List<District> List { get; set; }
    }


}