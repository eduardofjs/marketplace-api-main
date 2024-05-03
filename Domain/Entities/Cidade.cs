
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Cidade
    {	
		
		public int CDD_Id { get; set; }  
		public string CDD_Nome { get; set; }  
		public int? CDD_EstadoId { get; set; } 
		public Estado Estado { get; set; }
		public string CDD_CepInicial { get; set; }  
		public string CDD_CepFinal { get; set; }  
		public bool? CDD_FlgNaturalidade { get; set; }  
		public bool? CDD_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

