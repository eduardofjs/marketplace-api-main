
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class PoliticaPrivacidade
    {	
		
		public int PVD_Id { get; set; }  
		public string PVD_Nome { get; set; }  
		public string PVD_PathUrl { get; set; }  
		public int PVD_Versao { get; set; }  
		public string PVD_VersaoLabel { get; set; }  
		public bool? PVD_Ativo { get; set; }  		
        public Log Log { get; set; }
    }
}

