using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EtapaNegociacaoHistorico
    {
        public int ENH_Id { get; set; }
        public int ENH_OfertaNegociacaoId { get; set; }
        public int ENH_EtapaNegociacaoDirectto { get; set; }
        public int ENH_EtapaNegociacaoOfertador { get; set; }
        public int ENH_EtapaNegociacaoCliente { get; set; }
        public DateTime ENH_DataCadastro { get; set; }
        public bool ENH_FlagAtivo { get; set; }
    }
}
