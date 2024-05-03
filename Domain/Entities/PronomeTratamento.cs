
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class PronomeTratamento
    {	
		
		public int PRT_Id { get; set; }  
		public string PRT_Nome { get; set; }  
		public string PRT_Descricao { get; set; }  
		public bool? PRT_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

