using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ServicoAdicional
    {

        public int SEA_Id { get; set; }
        public int SEA_TipoServicoAdicionalId { get; set; }
        public TipoServicoAdicional TipoServicoAdicional { get; set; }
        public string SEA_Descricao { get; set; }
        public bool? SEA_FlagAtivo { get; set; }
        public string SEA_DescricaoIngles { get; set; }
        public Log Log { get; set; }
    }
}

