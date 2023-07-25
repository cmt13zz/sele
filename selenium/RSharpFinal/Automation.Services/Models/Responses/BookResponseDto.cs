using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Automation.Services.Models
{
    public class BookResponseDto
    {
        [JsonPropertyName("isbn")]
        public string Isbn {get; set;}

        [JsonPropertyName("title")]
        public string Title {get; set;}

        [JsonPropertyName("subTitle")]
        public string Subtitle {get; set;}

        [JsonPropertyName("author")]
        public string Author {get; set;}

        [JsonPropertyName("publish_date")]
        public string PublishDate {get; set;}

        [JsonPropertyName("publisher")]
        public string Publisher {get; set;}

        [JsonPropertyName("pages")]
        public int Pages {get; set;}

        [JsonPropertyName("description")]
        public string Description {get; set;}

        [JsonPropertyName("website")]
        public string Website {get; set;}
    }
}