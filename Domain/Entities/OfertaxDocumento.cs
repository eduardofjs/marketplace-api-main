using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OfertaxDocumento
    {
        public int OXD_Id { get; set; }
        public int OXD_OfertaId { get; set; }
        public Oferta Oferta { get; set; }
        public int OXD_DocumentoId { get; set; }
        public Documento Documento { get; set; }
        public bool? OXD_FlagAtivo { get; set; }
        public DateTime OXD_DataCadastro { get; set; }
        public Log Log { get; set; }
    }
}
