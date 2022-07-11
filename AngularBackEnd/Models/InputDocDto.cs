using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AngularBackEnd.Models
{
    public class InputDocDto
    {
        [Required]
        [JsonProperty("docNumber")]
        public string DocNumber { get; set; }
    }
}
