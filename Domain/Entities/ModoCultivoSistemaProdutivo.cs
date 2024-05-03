using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ModoCultivoSistemaProdutivo
    {
        public int MCS_Id { get; set; }
        public string MCS_Descricao { get; set; }
        public bool? MCS_FlagAtivo { get; set; }
        public string MCS_DescricaoIngles { get; set; }
        public Log Log { get; set; }
    }
}
