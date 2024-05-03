using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TipoCertificacao
    {

        public int TPC_Id { get; set; }
        public string TPC_Descricao { get; set; }
        public bool? TPC_FlagAtivo { get; set; }
        public string TPC_DescricaoIngles { get; set; }        
        public Log Log { get; set; }
    }
}

