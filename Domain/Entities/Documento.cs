
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Documento
    {	
		
		public int DOC_Id { get; set; }  
		public int DOC_TipoDocumentoId { get; set; } 
		public TipoDocumento TipoDocumento { get; set; }
		public int DOC_UsuarioId { get; set; }
		public Usuario Usuario { get; set; }
		public string DOC_Nome { get; set; }
		public string DOC_PathUrl { get; set; }
        public DateTime DOC_DataCriacao { get; set; }
        public bool? DOC_Ativo { get; set; }  
        public Log Log { get; set; }
    }
}

