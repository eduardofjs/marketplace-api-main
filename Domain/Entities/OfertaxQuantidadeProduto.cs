using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OfertaxQuantidadeProduto
    {
        public int OXQ_Id { get; set; }
        public int OXQ_OfertaId { get; set; }
        public Oferta Oferta { get; set; }
        public int OXQ_UnidadePesoId { get; set; }
        public UnidadePeso UnidadePeso { get; set; }
        public decimal OXQ_Peso { get; set; }
        public int OXQ_MoedaId { get; set; }
        public Moeda Moeda { get; set; }
        public decimal OXQ_MenorPreco { get; set; }
        public decimal OXQ_MaiorPreco { get; set; }
        public decimal OXQ_PercentualAdiantamento { get; set; }
        public DateTime OXQ_DataEntregaInicio { get; set; }
        public DateTime OXQ_DataEntregaFim { get; set; }
        public DateTime OXQ_DataExpiracao { get; set; }
        public bool? OXQ_FlagAtivo { get; set; }
        public List<OfertaxQuantidadeProduto> listaOXQNegociacao { get; set; }
        public Log Log { get; set; }
    }
}
