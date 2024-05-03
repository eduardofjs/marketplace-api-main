
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Menu
    {	
		
		public int MEN_Id { get; set; }  
		public string MEN_Nome { get; set; }  
		public string MEN_Codigo { get; set; }  
		public bool? MEN_Ativo { get; set; }  
		public int? MEN_Ordem { get; set; }  
		public string MEN_Icone { get; set; }  
		public bool? MEN_FLAGMOBILE { get; set; }  		
        public Log Log { get; set; }
    }
}

