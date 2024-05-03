using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DigitalTwinLoginResponseDto
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expiresAt")]
        public string ExpiresAt { get; set; }

    }
}
