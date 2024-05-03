
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class PerfilxSubMenu
    {	
		
		public int PXS_Id { get; set; }  
		public int? PXS_SubMenuId { get; set; } 
		public SubMenu SubMenu { get; set; }
		public int? PXS_PerfilId { get; set; } 
		public Perfil Perfil { get; set; }
		public bool? PXS_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

