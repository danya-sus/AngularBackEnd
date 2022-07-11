using System.ComponentModel.DataAnnotations;

namespace AngularBackEnd.Models
{
    public class Airline
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEn { get; set; }

        [Required]
        public string IcaoCode { get; set; }

        [Required]
        public string IataCode { get; set; }

        [Required]
        public string RfCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
