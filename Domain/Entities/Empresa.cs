
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class Empresa
	{

		public int EMP_Id { get; set; }
		public string EMP_RazaoSocial { get; set; }
		public string EMP_NomeFantasia { get; set; }
		public string EMP_CNPJ { get; set; }
		public bool? EMP_Ativo { get; set; }
		public int? EMP_EnderecoId { get; set; }
		public Endereco Endereco { get; set; }
		public int? EMP_TipoEmpresaId { get; set; }
		public TipoEmpresa TipoEmpresa { get; set; }
		public string EMP_Telefone { get; set; }
		public string EMP_Contato { get; set; }
		public string EMP_Site { get; set; }
		public string EMP_ImagemPath { get; set; }

		public bool EMP_FlagMercadoInterno { get; set; }
		public bool EMP_FlagMercadoExterno { get; set; }
		public decimal EMP_Valor{ get; set; }
		public int EMP_UsuarioId { get; set; }
		public Usuario Usuario { get; set; }
		public string EMP_CodigoSeguranca { get; set; }
		public decimal EMP_Faturamento { get; set; }
		public DateTime EMP_DataCadastro { get; set; }
		public DateTime EMP_DataAbertura { get; set; }
		public bool EMP_FlagTermoTransporte { get; set; }
		public bool EMP_FlagTermoPagamento { get; set; }
		public bool EMP_FlagTermoPlataforma { get; set; }
		public bool EMP_FlagTermoUsoConta { get; set; }
		public bool EMP_FlagTermoPlataformaCobranca { get; set; }
		public bool? EMP_FlagAprovado { get; set; }
		public DateTime? EMP_DataAprovado { get; set; }
		public DateTime? EMP_DataReprovado { get; set; }
		public bool? EMP_FlagIngles { get; set; }

		[NotMapped]
		public bool? EMP_FlagEmail { get; set; }

		public List<EmpresaxDocumento> listaEmpresaxDocumento { get; set; }
		public List<EmpresaxLogistica> listaEmpresaxLogistica { get; set; }
		public List<EmpresaxServicoAdicional> listaEmpresaxServicoAdicional { get; set; }
		public List<EmpresaxServicoFinanceiro> listaEmpresaxServicoFinanceiro { get; set; }
		public List<EmpresaxProduto> listaEmpresaxProduto { get; set; }
		//public Log Log { get; set; }
	}
}

