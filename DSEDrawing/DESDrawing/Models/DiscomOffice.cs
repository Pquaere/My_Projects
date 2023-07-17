using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class DiscomOffice
    {
        public int ID { get; set; }
        public int Pk_Id { get; set; }
        public string OfficeName { get; set; }
        public int Create_by { get; set; }
        public int Updated_by { get; set; }
        public bool Isactive { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<DiscomOffice> DiscomList { get; set; }
    }
}