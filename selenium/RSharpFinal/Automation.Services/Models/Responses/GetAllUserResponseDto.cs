using System.Runtime.CompilerServices;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Automation.Services.Models
{
    public class GetAllUserResponseDto
    {
        [JsonPropertyName("code")]
        public int Code {get; set;}

        [JsonPropertyName("message")]
        public string Message {get; set;}

        [JsonPropertyName("userId")]
        public string UserId {get; set;}

        [JsonPropertyName("username")]
        public string Username {get; set;}

        [JsonPropertyName("books")]
        public IList<BookResponseDto> Books {get; set;}

        [JsonPropertyName("collectionOfIsbns")]
        public IsbnCollectionRequestDto CollectionOfIsbns {get; set;}

        [JsonPropertyName("isbn")]
        public string Isbn {get; set;}
        
    }
}