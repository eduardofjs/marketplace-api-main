using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TipoLogisticoPorto
    {

        public int TLP_Id { get; set; }
        public string TLP_Descricao { get; set; }
        public bool? TLP_FlagAtivo { get; set; }
        public string TLP_DescricaoIngles { get; set; }
        public Log Log { get; set; }
    }
}

