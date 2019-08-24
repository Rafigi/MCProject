using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCAPI.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public int RegistrationCount { get; set; }
        public string Created { get; set; }
        public Route Route { get; set; }
        public User User { get; set; }

    }
}
