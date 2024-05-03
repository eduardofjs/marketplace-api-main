
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class PerfilxUsuario
    {	
		
		public int PXU_Id { get; set; }  
		public int? PXU_UsuarioId { get; set; } 
		public Usuario Usuario { get; set; }
		public int? PXU_PerfilId { get; set; } 
		public Perfil Perfil { get; set; }
		public bool? PXU_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

