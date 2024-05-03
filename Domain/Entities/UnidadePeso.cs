using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class UnidadePeso
    {

        public int UNP_Id { get; set; }
        public string UNP_Descricao { get; set; }
        public bool? UNP_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}

