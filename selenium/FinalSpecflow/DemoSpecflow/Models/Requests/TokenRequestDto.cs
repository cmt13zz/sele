using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoSpecflow.Models.Requests
{
    public class TokenRequestDto
    {
        [JsonProperty("username")]
        public string Username {get; set;}

        [JsonProperty("password")]
        public string Password {get; set;}
    }
}