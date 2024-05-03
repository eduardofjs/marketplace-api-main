
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class PoliticaPrivacidadexUsuario
    {	
		
		public int PVU_Id { get; set; }  
		public int PVU_UsuarioId { get; set; } 
		public Usuario Usuario { get; set; }
		public bool? PVU_Aceite { get; set; }  
		public int PVU_PoliticaPrivacidadeId { get; set; } 
		public PoliticaPrivacidade PoliticaPrivacidade { get; set; }
		public DateTime? PVU_DataAceite { get; set; }  
		public bool? PVU_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

