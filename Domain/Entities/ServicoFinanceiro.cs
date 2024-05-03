using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ServicoFinanceiro
    {
        public int SEF_Id { get; set; }
        public string SEF_Nome { get; set; }
        public bool? SEF_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}
