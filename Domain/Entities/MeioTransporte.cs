using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MeioTransporte
    {
        public int MTR_Id { get; set; }
        public string MTR_Descricao { get; set; }
        public string MTR_DescricaoIngles { get; set; }
        public DateTime MTR_DataCadastro { get; set; }
        public bool MTR_FlagAtivo { get; set; }
        public Log Log { get; set; }

    }
}
