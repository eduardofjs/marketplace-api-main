using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StatusDocumento
    {
        public int SDO_Id { get; set; }
        public string SDO_Descricao { get; set; }
        public string SDO_DescricaoIngles { get; set; }
        public bool SDO_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}
