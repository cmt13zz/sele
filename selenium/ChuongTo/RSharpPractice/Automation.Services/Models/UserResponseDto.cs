using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Automation.Services.Models
{
    public class UserResponseDto
    {
        
        [JsonPropertyName("_id")]
        public int Id {get; set;}

        [JsonPropertyName("name")]
        public string Name {get; set;}

        [JsonPropertyName("email")]
        public string Email {get; set;} 

        [JsonPropertyName("gender")]
        public string Gender {get; set;}

        [JsonPropertyName("status")]
        public string Status {get; set;}

        
    }
}