using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class Zone
    {
        public int ID { get; set; }
        public int RegionId { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string RegionName { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public bool Isactive { get; set; }
        public List<Zone> ZoneList { get; set; }
    }
}