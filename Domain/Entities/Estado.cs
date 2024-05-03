
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Estado
    {	
		
		public int ESD_Id { get; set; }  
		public string ESD_Nome { get; set; }  
		public string ESD_Sigla { get; set; }  
		public bool? ESD_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

