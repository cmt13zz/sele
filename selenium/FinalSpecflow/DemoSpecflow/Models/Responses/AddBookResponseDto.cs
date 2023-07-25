using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DemoSpecflow.Models.Responses
{
    public class AddBookResponseDto
    {
        [JsonProperty("books")]
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        [JsonProperty("isbn")]
        public string Isbn { get; set; }
    }
}