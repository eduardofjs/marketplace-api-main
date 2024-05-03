using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DigitalTwinCompanyDto
    {
        [JsonPropertyName("externalId")]
        public int ExternalId { get; set; }

        [JsonPropertyName("actualName")]
        public string ActualName { get; set; }

        [JsonPropertyName("fantasyName")]
        public string FantasyName { get; set; }

        [JsonPropertyName("document")]
        public string Document { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        public DigitalTwinCompanyDto() { }

        public DigitalTwinCompanyDto(Empresa Empresa)
        {
            ExternalId = Empresa.EMP_Id;
            ActualName = Empresa.EMP_RazaoSocial;
            FantasyName = Empresa.EMP_NomeFantasia;
            Document = Empresa.EMP_CNPJ;
            Email = Empresa.EMP_Contato;
            Phone = Empresa.EMP_Telefone != null ? Empresa.EMP_Telefone.Replace(" ", "") : Empresa.EMP_Telefone;
            Address = Empresa.Endereco != null ? 
                   Empresa.Endereco.END_Logradouro + ", " +
                   Empresa.Endereco.END_Numero + ", " + 
                   Empresa.Endereco.END_Bairro + ", " +
                   Empresa.Endereco.END_Complemento + ", " +
                   Empresa.Endereco.END_CEP
                   : "";
        }

    }
}
