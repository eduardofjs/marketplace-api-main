
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Endereco
    {	
		
		public int END_Id { get; set; }  
		public string END_Logradouro { get; set; }  
		public int? END_Numero { get; set; }  
		public string END_Bairro { get; set; }  
		public string END_Cidade { get; set; }  
		public string END_Estado { get; set; }  
		public string END_Complemento { get; set; }  
		public string END_CEP { get; set; }  
		public int? END_CidadeId { get; set; } 
		public Cidade Cidade { get; set; }
		public int? END_EstadoId { get; set; } 
		public Estado Estado { get; set; }
		public float? END_Latitude { get; set; }  
		public float? END_Longitude { get; set; }  
		public bool? END_Ativo { get; set; }  
		public string END_Regiao { get; set; }  
		public string END_CodIBGE { get; set; }
		public string END_Pais { get; set; }		
		public Log Log { get; set; }
    }
}

