
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Pessoa
    {	
		
		public int PES_Id { get; set; }  
		public string PES_Nome { get; set; }  
		public int? PES_SexoId { get; set; } 
		public Sexo Sexo { get; set; }
		public string PES_CPF { get; set; }  
		public DateTime? PES_DataNascimento { get; set; }  
		public bool? PES_Ativo { get; set; }  
		public string PES_RG { get; set; }  
		public int? PES_EnderecoId { get; set; } 
		public Endereco Endereco { get; set; }
		public string PES_EnderecoFoto { get; set; }  
		public string PES_TelefoneResidencial { get; set; }  
		public string PES_Celular { get; set; }  
		public string PES_Email { get; set; }
		public string PES_SexoBiologico { get; set; }
		public int? PES_PronomeTratamentoId { get; set; } 
		public PronomeTratamento PronomeTratamento { get; set; }
        public decimal PES_Renda { get; set; }
		public string PES_NomeResponsavel { get; set; }
		public string PES_CPFResponsavel { get; set; }
		public bool? PES_flagDoador { get; set; }
		public Log Log { get; set; }
    }
}

