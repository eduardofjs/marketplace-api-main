
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TermoUso
    {	
		
		public int TRU_Id { get; set; }  
		public string TRU_Nome { get; set; }  
		public string TRU_PathUrl { get; set; }  
		public int TRU_Versao { get; set; }  
		public string TRU_VersaoLabel { get; set; }  
		public bool? TRU_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

