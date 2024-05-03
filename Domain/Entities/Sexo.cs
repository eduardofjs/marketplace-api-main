
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Sexo
    {	
		
		public int SEX_Id { get; set; }  
		public string SEX_Nome { get; set; }  
		public string SEX_Sigla { get; set; }  
		public bool? SEX_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

