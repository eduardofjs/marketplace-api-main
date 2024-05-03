using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class OfertaxCertificacao
    {
        public int OXC_Id { get; set; }
        public int OXC_TipoCertificacaoId { get; set; }
        public TipoCertificacao TipoCertificacao { get; set; }
        public int OXC_OfertaId { get; set; }
        public Oferta Oferta { get; set; }
        public string OXC_DocumentoId { get; set; }
        public Documento Documento { get; set; }
        public string OXC_Comentarios { get; set; }
        public bool? OXC_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}
