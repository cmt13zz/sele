using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Automation.Services.Models
{
    public class PaginationResponseDto
    {
         [JsonPropertyName("total")]
        public int Total {get; set;}

        [JsonPropertyName("pages")]
        public int Pages {get; set;}

        [JsonPropertyName("page")]
        public int Page {get; set;} 

        [JsonPropertyName("limit")]
        public int Limit {get; set;}

    }
}