
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Unidade
    {	
		
		public int UNI_Id { get; set; }  
		public string UNI_RazaoSocial { get; set; }  
		public string UNI_NomeFantasia { get; set; }  
		public string UNI_CNPJ { get; set; }  
		public int UNI_EnderecoId { get; set; } 
		public Endereco Endereco { get; set; }
		public string UNI_Telefone { get; set; }  
		public string UNI_Contato { get; set; }  
		public string UNI_ImagePath { get; set; }  
		public string UNI_Site { get; set; }  
		public bool? UNI_FlagAtivo { get; set; }  		
        public Log Log { get; set; }
    }
}

