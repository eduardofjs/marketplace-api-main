using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class EmpresaxServicoFinanceiro
    {
        public int ESF_Id { get; set; }
        public int ESF_EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int ESF_ServicoFinanceiroId { get; set; }
        public ServicoFinanceiro ServicoFinanceiro { get; set; }
        public bool? ESF_FlagAtivo { get; set; }
        public DateTime ESF_DataCadastro { get; set; }
        public Log Log { get; set; }
    }
}
