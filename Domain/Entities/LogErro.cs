
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class LogErro
    {	
		
		public int LGE_Id { get; set; }  
		public DateTime? LGE_DataHora { get; set; }  
		public int? LGE_UsuarioId { get; set; } 
		public Usuario Usuario { get; set; }
		public string LGE_token { get; set; }  
		public int? LGE_SubMenuId { get; set; }  
		public string LGE_className { get; set; }  
		public string LGE_functionName { get; set; }  
		public string LGE_erroFullName { get; set; }  
		public string LGE_erroMessage { get; set; }  
		public string LGE_erroStackTrace { get; set; }  
		public string LGE_erroData { get; set; }  
		public int? LGE_PlataformaId { get; set; }  
		public string LGE_VersaoPlataforma { get; set; }  
		public string LGE_VersaoApi { get; set; }  
		public string LGE_QueryString { get; set; }  		
        public Log Log { get; set; }
    }
}

