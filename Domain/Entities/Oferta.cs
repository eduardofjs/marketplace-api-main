using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Oferta
    {
        public int OFE_Id { get; set; }
        public bool? OFE_FlagVender { get; set; }
        public bool? OFE_FlagMercadoExterno { get; set; }
        public int OFE_UsuarioInsercaoId { get; set; }
        public Usuario Usuario { get; set; }
        public int OFE_EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int OFE_CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int OFE_TipoProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public int OFE_ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int OFE_ModoCultivoSistemaProdutivoId { get; set; }
        public ModoCultivoSistemaProdutivo ModoCultivoSistemaProdutivo { get; set; }
        public int OFE_ModoCultivoModoProducaoId { get; set; }
        public ModoCultivoModoProducao ModoCultivoModoProducao { get; set; }
        public int OFE_StatusProdutoId { get; set; }
        public StatusProduto StatusProduto { get; set; }
        public int OFE_EnderecoOrigemId { get; set; }
        public Endereco Endereco { get; set; }
        public int OFE_TipoLogisticoSistemaProdutivoId { get; set; }
        public TipoLogisticoSistemaProdutivo TipoLogisticoSistemaProdutivo { get; set; }
        public int OFE_TipoLogisticoPortoId { get; set; }
        public TipoLogisticoPorto TipoLogisticoPorto { get; set; }        
        public int OFE_AnoColheita { get; set; }
        public string OFE_Descricao { get; set; }
        public DateTime OFE_DataCadastro { get; set; }
        public bool? OFE_FlagAtivo { get; set; }
        public bool? OFE_FlagAprovado { get; set; }
        public DateTime? OFE_DataAprovado { get; set; }
        public DateTime? OFE_DataReprovado { get; set; }
        public bool? OFE_FlagIngles { get; set; }
        public List<OfertaNegociacao> listaOfertaNegociacao { get; set; }
        public List<OfertaxServicoAdicional> listaOfertaxServicoAdicional { get; set; }
        public List<OfertaxServicoOpcional> listaOfertaxServicoOpcional { get; set; }
        public List<OfertaxQuantidadeProduto> listaOfertaxQuantidadeProduto { get; set; }
        public List<OfertaxCertificacao> listaOfertaxCertificacao { get; set; }
        public List<OfertaxDocumento> listaOfertaxDocumento { get; set; }
        public int? OFE_UsuarioAlteracaoId { get; set; }
        public DateTime? OFE_DataAlteracao { get; set; }
        public Log Log { get; set; }
    }
}
