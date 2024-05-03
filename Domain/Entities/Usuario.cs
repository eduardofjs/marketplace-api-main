
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Usuario
    {	
		
		public int USR_Id { get; set; }  
		public string USR_Email { get; set; }  
		public string USR_Senha { get; set; }  
		public bool? USR_Ativo { get; set; }  
		public int? USR_PessoaId { get; set; } 
		public Pessoa Pessoa { get; set; }
		public int? USR_UnidadeId { get; set; }
        public int USR_OrigemId { get; set; }
        public bool? USR_PrimeiroAcesso { get; set; }  
		public string USR_DeviceID { get; set; }  
		public string USR_TokenRecoveryPassword { get; set; }  
		public DateTime? USR_TokenDateExpire { get; set; }  		
        public Log Log { get; set; }
        
        public bool sucesso { get; set; }
        public string mensagemSucesso { get; set; }

        public PerfilxUsuario perfilxUsuario { get; set; }

        public PerfilxSubMenu perfilxSubMenu { get; set; }

        public bool? USR_AceitouTermoUso { get; set; }

        public bool? USR_AceitouPolitica { get; set; }

        public bool? USR_FlagGestor { get; set; }

        public bool?USR_FlagContratante { get; set; }

        public bool?USR_FlagProfissional { get; set; }

        public DateTime? USR_DataLeituraAvisoCorona { get; set; }
        public decimal? ValorPagamento { get; set; }

        public bool? USR_FlagIngles { get; set; }
        public Empresa Empresa { get; set; }
    }
}

