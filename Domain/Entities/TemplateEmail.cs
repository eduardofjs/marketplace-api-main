
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TemplateEmail
    {	
		
		public int TME_Id { get; set; }  
		public string TME_Nome { get; set; }  
		public string TME_NomeArquivo { get; set; }  
		public string TME_PathTemplateEmail { get; set; }  
		public bool? TME_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

