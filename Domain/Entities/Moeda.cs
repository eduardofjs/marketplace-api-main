using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Moeda
    {
        public int MOE_Id { get; set; }
        public string MOE_Nome { get; set; }
        public bool MOE_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}
