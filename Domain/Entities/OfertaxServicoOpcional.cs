using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class OfertaxServicoOpcional
    {
        public int OXS_Id { get; set; }
        public int OXS_OfertaId { get; set; }
        public Oferta Oferta { get; set; }
        public int OXS_ServicoOpcionalId { get; set; }
        public ServicoOpcional ServicoOpcional { get; set; }
        public bool? OXS_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}
