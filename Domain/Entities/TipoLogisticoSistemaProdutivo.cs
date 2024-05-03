using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TipoLogisticoSistemaProdutivo
    {

        public int TLS_Id { get; set; }
        public string TLS_Descricao { get; set; }
        public bool? TLS_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}

