
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class SubMenu
    {	
		
		public int SBM_Id { get; set; }  
		public int? SBM_MenuId { get; set; } 
		public Menu Menu { get; set; }
		public string SBM_Nome { get; set; }  
		public string SBM_Descricao { get; set; }  
		public string SBM_Codigo { get; set; }  
		public string SBM_Controller { get; set; }  
		public int? SBM_Ordem { get; set; }  
		public bool? SBM_Ativo { get; set; }  
		public bool? SBM_FLAGMOBILE { get; set; }  
		public string SBM_Icone { get; set; }  		
        public Log Log { get; set; }
    }
}

