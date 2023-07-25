using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Automation.Services.Models
{
    public class GetDetailedUserResponseDto
    {
        [JsonPropertyName("code")]
        public int Code {get; set;}

        [JsonPropertyName("meta")]
        public MetaResponseDto Meta {get; set;}

        [JsonPropertyName("data")]
        public AccountDto Users {get; set;}
    }
}