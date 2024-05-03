
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TipoDocumento
    {			
		public int TDC_Id { get; set; }  
		public string TDC_Descricao { get; set; }  
		public bool? TDC_Ativo { get; set; }
        public bool? TDC_flagCirurgia { get; set; }
        public bool? TDC_flagExame { get; set; }
        public bool? TDC_flagContaMedica { get; set; }
        public bool? TDC_flagObrigatorio { get; set; }
        public string TDC_Label { get; set; }
        public Log Log { get; set; }
    }
}

