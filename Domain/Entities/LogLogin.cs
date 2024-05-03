
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class LogLogin
    {	
		
		public int LLG_Id { get; set; }  
		public int? LLG_UsuarioId { get; set; } 
		public Usuario Usuario { get; set; }
		public string LLG_ipEstacao { get; set; }  
		public DateTime? LLG_DataHoraLogin { get; set; }  
		public DateTime? LLG_DataHoraLogout { get; set; }  
		public string  LLG_Observacao { get; set; }  
		public string LLG_Token { get; set; }  
		public bool? LLG_FlagLogin { get; set; }  
		public bool? LLG_FlagLogout { get; set; }  
		public int? LLG_PlataformaId { get; set; }  
		public string LLG_VersaoPlataforma { get; set; }  
		public string LLG_VersaoApi { get; set; }  		
        public Log Log { get; set; }
    }
}

