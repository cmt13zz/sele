using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Automation.Services.Models
{
    public class UserResponseDto
    {
        
        [JsonPropertyName("isbn")]
        public string Isbn {get; set;}

        

        
    }
}