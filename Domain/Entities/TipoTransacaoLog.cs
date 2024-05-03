
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TipoTransacaoLog
    {	
		
		public int TTL_Id { get; set; }  
		public string TTL_Nome { get; set; }  
		public string TTL_Descricao { get; set; }  
		public bool? TTL_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

