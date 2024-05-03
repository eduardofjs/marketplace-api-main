using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpresaxProduto
    {
        public int EXP_Id { get; set; }
        public int EXP_EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int EXP_ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public bool? EXP_FlagAtivo { get; set; }
        public DateTime EXP_DataCadastro { get; set; }
        public Log Log { get; set; }
    }
}
