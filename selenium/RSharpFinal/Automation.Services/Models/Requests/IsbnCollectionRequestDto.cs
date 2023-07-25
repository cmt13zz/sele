using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Automation.Services.Models
{
    public class IsbnCollectionRequestDto
    {
        [JsonPropertyName("isbn")]
        public string Isbn {get; set;}

        
    }
}