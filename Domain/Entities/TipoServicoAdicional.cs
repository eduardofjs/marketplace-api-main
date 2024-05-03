
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
	public class TipoServicoAdicional
	{

		public int TSA_Id { get; set; }
		public string TSA_Descricao { get; set; }
		public bool? TSA_FlagAtivo { get; set; }
		public string TSA_DescricaoIngles { get; set; }
		public Log Log { get; set; }
	}
}

