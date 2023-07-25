using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Automation.Services.Models
{
    public class UserResponseDto
    {
        [JsonProperty("name")]
        public string? Name {get; set;}

        [JsonProperty("gender")]
        public string? Gender {get; set;}

        [JsonProperty("email")]
        public string? Email {get; set;} 
        
        [JsonProperty("status")]
        public string? Status {get; set;}

        [JsonProperty("_id")]
        public string? Id {get; set;}
    }
}