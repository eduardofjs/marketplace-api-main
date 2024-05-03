using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ModoCultivoModoProducao
    {
        public int MCM_Id { get; set; }
        public string MCM_Descricao { get; set; }
        public bool? MCM_FlagAtivo { get; set; }
        public string MCM_DescricaoIngles { get; set; }        
        public Log Log { get; set; }
    }
}
