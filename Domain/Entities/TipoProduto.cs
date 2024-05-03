using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TipoProduto
    {

        public int TPR_Id { get; set; }
        public string TPR_Descricao { get; set; }
        public bool? TPR_FlagAtivo { get; set; }
        public string TPR_DescricaoIngles { get; set; }
        public string TPR_PathUrl { get; set; }
        public string TPR_PathUrlOferta { get; set; }
        public Log Log { get; set; }
    }
}

