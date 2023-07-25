using System.Runtime.CompilerServices;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Automation.Services.Models
{
    public class GetAllUserResponseDto
    {
        [JsonPropertyName("code")]
        public int Code {get; set;}

        [JsonPropertyName("meta")]
        public MetaResponseDto Meta {get; set;}

        [JsonPropertyName("data")]
        public IList<UserResponseDto> Users {get; set;}

        
    }
}