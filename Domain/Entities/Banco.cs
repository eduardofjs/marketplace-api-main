
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Banco
    {	
		
		public int BAN_Id { get; set; }  
		public string BAN_Nome { get; set; }  
		public string BAN_CNPJ { get; set; }  
		public string BAN_Sigla { get; set; }  
		public bool? BAN_Ativo { get; set; }  
		public string BAN_NumeroBanco { get; set; }  		
        public Log Log { get; set; }
    }
}

