using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Automation.Services.Models
{
    public class TokenRequestDto
    {
        [JsonPropertyName("username")]
        public string Username {get; set;}

        [JsonPropertyName("password")]
        public string Password {get; set;}
    }
}