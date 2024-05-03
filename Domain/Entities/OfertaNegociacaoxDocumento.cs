using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OfertaNegociacaoxDocumento
    {
        public int OND_Id { get; set; }
        public int OND_OfertaNegociacaoId { get; set; }
        public OfertaNegociacao OfertaNegociacao { get; set; }
        public int OND_EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int? OND_DocumentoId { get; set; }
        public Documento Documento { get; set; }
        public int? OND_StatusDocumentoId { get; set; }
        public StatusDocumento StatusDocumento { get; set; }
        public string OND_Descricao { get; set; }
        public string OND_Justificativa { get; set; }
        public bool OND_FlagAtivo { get; set; }
        public bool? OND_FlagAprovado { get; set; }
        public bool? OND_FlagIngles { get; set; }
        public DateTime OND_DataCadastro { get; set; }
        public DateTime? OND_DataAtualizacao { get; set; }
        public Log Log { get; set; }
    }
}
