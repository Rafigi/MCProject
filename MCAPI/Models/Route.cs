using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Models
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }
        public Adresse Adresse{ get; set; }
        public double Distance { get; set; }
        public bool Motorway { get; set; }
        public bool Ferry { get; set; }
        public bool Toll { get; set; }
        public string Created { get; set; }
        public User User{ get; set; }
    }
}
