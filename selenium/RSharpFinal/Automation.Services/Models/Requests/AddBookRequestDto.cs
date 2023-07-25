using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Automation.Services.Models.Requests
{
    public class AddBookRequestDto
    {
        [JsonPropertyName("userId")]
        public string UserId {get; set;}

        [JsonPropertyName("collectionOfIsbns")]
        public IsbnCollectionRequestDto CollectionOfIsbns {get; set;}
    }
}