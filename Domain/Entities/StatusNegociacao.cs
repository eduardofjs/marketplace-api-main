using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StatusNegociacao
    {
        public int STN_Id { get; set; }
        public string STN_Nome { get; set; }
        public string STN_Descricao { get; set; }
        public int STN_Peso { get; set; }
        public bool? STN_Ativo { get; set; }
        public Log Log { get; set; }
    }
}
