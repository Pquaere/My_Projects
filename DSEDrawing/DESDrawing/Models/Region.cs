using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class Region
    {

        public int Id { get; set; }

        public string RegionName { get; set; }

      
        public string DiscomofficeName { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public string StateID { get; set; }
        public bool Isactive { get; set; }

        public List<Region> Regionlst { get; set; }

    }
}