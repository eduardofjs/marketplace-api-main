using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DigitalTwinLoginDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }

        public DigitalTwinLoginDto()
        {
        }

        public DigitalTwinLoginDto(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}
