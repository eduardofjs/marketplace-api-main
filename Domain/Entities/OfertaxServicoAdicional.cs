using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class OfertaxServicoAdicional
    {
        public int OXA_Id { get; set; }
        public int OXA_OfertaId { get; set; }
        public Oferta Oferta { get; set; }
        public int OXA_ServicoAdicionalId { get; set; }
        public ServicoAdicional ServicoAdicional { get; set; }
        public bool? OXA_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}
