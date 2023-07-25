using System.Runtime.CompilerServices;
using 
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Automation.Services.Models
{
    public class GetAllUserResponseDto
    {
        [JsonProperty("quantidade")]
        public string? Numbers {get; set;}

        [JsonProperty("usuarios")]
        public List<UserResponseDto>? Users {get; set;}
    }
}