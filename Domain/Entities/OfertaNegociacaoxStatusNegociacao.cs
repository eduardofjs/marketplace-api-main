using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OfertaNegociacaoxStatusNegociacao
    {
        public int ONS_Id { get; set; }
        public int ONS_OfertaNegociacaoId { get; set; }
        public OfertaNegociacao OfertaNegociacao { get; set; }
        public int ONS_StatusNegociacaoId { get; set; }
        public StatusNegociacao StatusNegociacao { get; set; }
        public decimal ONS_ValorProposta { get; set; }
        public bool ONS_FlagAtivo { get; set; }
        public DateTime ONS_DataCadastro { get; set; }
        public DateTime ONS_DataStatusNegociacao { get; set; }
        public bool ONS_FlagDirectto { get; set; }
        public int ONS_ContadorOfertador { get; set; }
        public int ONS_ContadorCliente { get; set; }
        public int ONS_EmpresaId { get; set; }
        public string ONS_Mensagem { get; set; }
        public Log Log { get; set; }
    }
}
