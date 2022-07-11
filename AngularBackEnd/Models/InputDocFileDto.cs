using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AngularBackEnd.Models
{
    public class InputDocFileDto
    {
        [Required]
        [JsonProperty("docNumber")]
        public string DocNumber { get; set; }

        [JsonProperty("airlineCode")]
        public string AirlineCode { get; set; }
    }
}
