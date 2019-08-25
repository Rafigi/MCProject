using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Models
{

    public class Registration
    {
        public int UserID { get; set; }
        public int EventID { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
