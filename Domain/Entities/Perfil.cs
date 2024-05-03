
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Perfil
    {	
		
		public int PRF_Id { get; set; }  
		public int? PRF_UnidadeId { get; set; }  
		public string PRF_Descricao { get; set; }  
		public string PRF_Nome { get; set; }  
		public bool? PRF_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

