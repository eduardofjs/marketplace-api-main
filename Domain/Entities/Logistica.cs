using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Logistica
    {
        public int LGT_Id { get; set; }
        public string LGT_Nome { get; set; }
        public bool? LGT_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}
