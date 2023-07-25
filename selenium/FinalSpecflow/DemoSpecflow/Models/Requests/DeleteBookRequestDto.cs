using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoSpecflow.Models.Requests
{
    public class DeleteBookRequestDto
    {
        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}