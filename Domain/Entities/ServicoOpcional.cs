using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ServicoOpcional
    {

        public int SEO_Id { get; set; }
        public string SEO_Descricao { get; set; }
        public bool? SEO_FlagAtivo { get; set; }
        public string SEO_DescricaoIngles { get; set; }
        public int SEO_TipoLogisticoPortoId { get; set; }
        public TipoLogisticoPorto TipoLogisticoPorto { get; set; }
        public Log Log { get; set; }
    }
}

