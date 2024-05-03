using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Produto
    {

        public int PDT_Id { get; set; }
        public int PDT_UsuarioInsercaoId { get; set; }
        public Usuario UsuarioInsercao { get; set; }
        public string PDT_Descricao { get; set; }
        public string PDT_Nome { get; set; }
        public string PDT_DescricaoIngles { get; set; }
        public string PDT_NomeIngles { get; set; }
        public DateTime PDT_DataCadastro { get; set; }
        public bool? PDT_FlagAtivo { get; set; }
        public Log Log { get; set; }
    }
}

