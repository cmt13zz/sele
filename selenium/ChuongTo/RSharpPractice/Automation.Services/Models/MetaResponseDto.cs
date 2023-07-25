using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Automation.Services.Models
{
    public class MetaResponseDto
    {
        [JsonPropertyName("pagination")]
        public PaginationResponseDto Pagination {get; set;}
    }
}