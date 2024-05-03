
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Notificacao
    {	
		
		public int NOT_Id { get; set; }  
		public int? NOT_UsuarioId { get; set; } 
		public Usuario Usuario { get; set; }
		public int? NOT_TipoNotificacaoId { get; set; } 
		public TipoNotificacao TipoNotificacao { get; set; }
		public string NOT_Descricao { get; set; }  
		public bool? NOT_Ativo { get; set; }  
		public DateTime? NOT_DataEnvioNotificacao { get; set; }  
		public bool? NOT_Lido { get; set; }  
		public int? NOT_TabelaReferenciaId { get; set; }  
		public string NOT_Titulo { get; set; }  
		public bool? NOT_FlagEnviarParaTodos { get; set; }  
		public DateTime? NOT_DataNotificacaoLida { get; set; }  
		public string NOT_LinklExterno { get; set; }  		
        public Log Log { get; set; }
    }
}

