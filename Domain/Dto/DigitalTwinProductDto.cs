using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DigitalTwinProductDto
    {
        [JsonPropertyName("externalId")]
        public int ExternalId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public DigitalTwinProductDto() {}
        public DigitalTwinProductDto(Produto produto)
        {
            ExternalId = produto.PDT_Id;
            Name = produto.PDT_Nome;
            Description = produto.PDT_Descricao;
        }
    }
}
