using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OfertaNegociacao
    {
        public int OFN_Id { get; set; }
        public int OFN_OfertaxQuantidadeProdutoId { get; set; }
        public OfertaxQuantidadeProduto OfertaxQuantidadeProduto { get; set; }
        public int OFN_EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int OFN_StatusPagamentoId { get; set; }
        public StatusPagamento StatusPagamento { get; set; }

        public int? OFN_MeioTransporteId { get; set; }
        public MeioTransporte MeioTransporte { get; set; }
        public string OFN_NumeroPedido { get; set; }
        public decimal OFN_Peso { get; set; }
        public decimal OFN_ValorProposta { get; set; }
        public string OFN_Mensagem { get; set; }
        public bool OFN_FlagContato { get; set; }
        public bool OFN_FlagAceite { get; set; }
        public bool OFN_FlagAtivo { get; set; }
        public DateTime OFN_DataCadastro { get; set; }
        public DateTime OFN_DataAtualizacao { get; set; }
        public DateTime? OFN_DataEmbarque { get; set; }
        public DateTime? OFN_DataEstimativaEmbarque { get; set; }
        public bool? OFN_FlagIngles { get; set; }
        public bool? OFN_FlagVendedor { get; set; }
        public bool OFN_FlagDirectto { get; set; }
        public bool? OFN_FlagLiberaOfertador { get; set; }
        public bool? OFN_FlagLiberaCliente { get; set; }
        public int? OFN_ContadorOfertador { get; set; }
        public int? OFN_ContadorCliente { get; set; }
        public int OFN_EmpresaOriginalId { get; set; }
        public Empresa EmpresaOriginal { get; set; }
        public string mensagemSucesso { get; set; }
        public int OFN_EtapaNegociacaoDirectto { get; set; }
        public int OFN_EtapaNegociacaoOfertador { get; set; }
        public List<EtapaNegociacaoHistorico> listaEtapaNegociacaoHistorico { get; set; }
        public int OFN_EtapaNegociacaoCliente { get; set; }
        public DateTime? OFN_DataDirEtapa1 { get; set; }
        public DateTime? OFN_DataDirEtapa2 { get; set; }
        public DateTime? OFN_DataDirEtapa3 { get; set; }
        public DateTime? OFN_DataDirEtapa4 { get; set; }
        public DateTime? OFN_DataOferEtapa1 { get; set; }
        public DateTime? OFN_DataOferEtapa2 { get; set; }
        public DateTime? OFN_DataCliEtapa1 { get; set; }
        public DateTime? OFN_DataCliEtapa2 { get; set; }
        public string OFN_TermosPagamento { get; set; }
        public Log Log { get; set; }

    }
}
