using Newtonsoft.Json;
using System.Collections.Generic;

namespace Automation.Services.Models
{
    public class BookResponseDto
    {
        [JsonProperty("Isbn")]
        public string? Isbn {get; set;}

        [JsonProperty("Title")]
        public string? BookTitle {get; set;}
    }
}