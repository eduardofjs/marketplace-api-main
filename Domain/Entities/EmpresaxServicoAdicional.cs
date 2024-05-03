using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpresaxServicoAdicional
    {
        public int ESA_Id { get; set; }
        public int ESA_EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int ESA_ServicoAdicionalId { get; set; }
        public ServicoAdicional ServicoAdicional { get; set; }
        public bool? ESA_FlagAtivo { get; set; }
        public DateTime ESA_DataCadastro { get; set; }
        public Log Log { get; set; }
    }
}
