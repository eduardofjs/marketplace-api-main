
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TipoEmpresa
    {	
		
		public int TEM_Id { get; set; }  
		public string TEM_Nome { get; set; }  
		public bool? TEM_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

