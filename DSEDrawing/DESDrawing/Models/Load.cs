using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DESDrawing.Models
{
    public class Load
    {
        public int ID { get; set; }
        public int Pk_Id { get; set; }
        public string LoadFrom { get; set; }
        public string Loadto { get; set; }
        public int FK_RoleId { get; set; }
        public string RollName { get; set; }
        public int Create_by { get; set; }
        public int Updated_by { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<Load> LoadList { get; set; }
    }
}