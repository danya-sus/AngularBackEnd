using AngularBackEnd.Filters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AngularBackEnd.Models
{
    public class InputTicketFileDto
    {
        [Required]
        [JsonProperty("ticketNumber")]
        [PatternFilter]
        public string TicketNumber { get; set; }

        [Required]
        [JsonProperty("isChecked")]
        public bool IsChecked { get; set; }

        [JsonProperty("airlineCode")]
        public string AirlineCode { get; set; }
    }
}
