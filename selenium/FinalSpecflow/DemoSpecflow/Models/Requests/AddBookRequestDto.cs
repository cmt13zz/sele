using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoSpecflow.Models.Requests
{
    public class AddBookRequestDto
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("collectionOfIsbns")]
        public List<CollectionOfIsbn> CollectionOfIsbns { get; set; }


    }

    public class CollectionOfIsbn
    {
        [JsonProperty("isbn")]
        public string Isbn { get; set; }
    }
}