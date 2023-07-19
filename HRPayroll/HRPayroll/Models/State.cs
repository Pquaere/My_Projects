using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRPayroll.Models
{
    public class State
    {
        public int ID { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int flag { get; set; }
        public string message { get; set; }
        public List<State> statelist { get; set; }
    }
    
}