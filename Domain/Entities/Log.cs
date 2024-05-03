
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Log
    {	
		
		public int LOG_Id { get; set; }  
		public int? LOG_SubMenuId { get; set; } 
		public SubMenu SubMenu { get; set; }
		public int? LOG_UsuarioId { get; set; } 
		public Usuario Usuario { get; set; }
		public DateTime? LOG_DataHora { get; set; }  
		public string LOG_Token { get; set; }  
		public string LOG_IpEstacao { get; set; }  
		public string LOG_Observacao { get; set; }  
		public int? LOG_TipoTransacaoId { get; set; } 
		public TipoTransacaoLog TipoTransacaoLog { get; set; }
		public bool? LOG_Ativo { get; set; }  
		public int? LOG_PlataformaId { get; set; }  
		public string LOG_VersaoPlataforma { get; set; }  
		public string LOG_VersaoApi { get; set; }  
		public int? LOG_PerfilId { get; set; } 
		public Perfil Perfil { get; set; }
		public string LOG_Metodo { get; set; }  
		public string LOG_ParametroJson { get; set; }  
		public int? LOG_UnidadeId { get; set; }  
		public string LOG_QueryString { get; set; }  
		public bool? LOG_InternoSympor { get; set; }  
		public int? LOG_EmpresaId { get; set; }  		
    }
}

