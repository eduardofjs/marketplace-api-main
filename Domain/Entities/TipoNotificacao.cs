
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TipoNotificacao
    {	
		
		public int TPN_Id { get; set; }  
		public string TPN_Nome { get; set; }  
		public bool? TPN_Ativo { get; set; }  
		public string TPN_Controller { get; set; }  
		public string TPN_Cor { get; set; }  
		public string TPN_IconPath { get; set; }  		
        public Log Log { get; set; }
    }
}

