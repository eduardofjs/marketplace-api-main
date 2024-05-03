
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class StatusPagamento
    {	
		
		public int SPG_Id { get; set; }  
		public string SPG_Nome { get; set; }
		public string SPG_NomeIngles { get; set; }
		public bool? SPG_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

