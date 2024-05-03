using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class StatusProduto
    {

        public int SPR_Id { get; set; }
        public string SPR_Descricao { get; set; }
        public bool? SPR_FlagAtivo { get; set; }
        public string SPR_DescricaoIngles { get; set; }        
        public Log Log { get; set; }
    }
}

