
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TermoUsoxUsuario
    {	
		
		public int TXU_Id { get; set; }  
		public int TXU_UsuarioId { get; set; } 
		public Usuario Usuario { get; set; }
		public bool? TXU_Aceite { get; set; }  
		public int TXU_TermoUsoId { get; set; } 
		public TermoUso TermoUso { get; set; }
		public DateTime? TXU_DataAceite { get; set; }  
		public bool? TXU_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

