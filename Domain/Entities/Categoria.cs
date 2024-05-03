using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Categoria
    {
        public int CAT_Id { get; set; }
        public string CAT_Descricao { get; set; }
        public bool? CAT_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}
