using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpresaxDocumento
    {
        public int EXD_Id { get; set; }
        public int EXD_EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int EXD_DocumentoId { get; set; }
        public Documento Documento { get; set; }
        public bool? EXD_FlagAtivo { get; set; }
        public DateTime EXD_DataCadastro { get; set; }
        public Log Log { get; set; }
    }
}
