using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpresaxLogistica
    {
        public int EXL_Id { get; set; }
        public int EXL_EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int EXL_LogisticaId { get; set; }
        public Logistica Logistica { get; set; }
        public bool? EXL_FlagAtivo { get; set; }
        public DateTime EXL_DataCadastro { get; set; }
        public Log Log { get; set; }
    }
}
