using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Automation.Services.Models.Requests
{
    public class ChangeBookRequestDto
    {
        [JsonPropertyName("isbn")]
        public string Isbn {get; set;}

        [JsonPropertyName("userId")]
        public string UserId {get; set;}
    }
}