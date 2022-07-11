using AngularBackEnd.Filters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AngularBackEnd.Models
{
    public class InputTicketDto
    {
        [Required]
        [JsonProperty("ticketNumber")]
        [PatternFilter]
        public string TicketNumber { get; set; }

        [Required]
        [JsonProperty("isChecked")]
        public bool IsChecked { get; set; }
    }
}
