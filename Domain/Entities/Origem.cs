using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Origem
    {
        public int ORI_Id { get; set; }
        public string ORI_Descricao { get; set; }
        public bool ORI_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}
