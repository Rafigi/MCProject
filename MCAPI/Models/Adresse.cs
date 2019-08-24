using System.ComponentModel.DataAnnotations;
namespace MCAPI.Models
{
    public class Adresse
    {
        [Key]
        public int AdresseID { get; set; }
        public string StreetName { get; set; }
        public double StreetNumber { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
