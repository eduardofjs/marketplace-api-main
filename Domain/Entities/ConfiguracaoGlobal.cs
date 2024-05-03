
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ConfiguracaoGlobal
    {	
		
		public int CGL_Id { get; set; }  
		public string CGL_UnidadeRaiz { get; set; }  
		public string CGL_UrlImagem { get; set; }  
		public string CGL_PathImagem { get; set; }  
		public string CGL_PathImpressao { get; set; }  
		public string CGL_UrlImpressao { get; set; }  
		public string CGL_PathLogoImpressao { get; set; }  
		public string CGL_UrlLogoImpressao { get; set; }  
		public string CGL_PathLogo { get; set; }  
		public string CGL_UrlLogo { get; set; }  
		public string CGL_PathFonte { get; set; }  
		public string CGL_SendMailFrom { get; set; }  
		public string CGL_SendMailCCOS { get; set; }  
		public string CGL_SendMailSmtpCliente { get; set; }  
		public string CGL_SendMailLogin { get; set; }  
		public string CGL_SendMailSenha { get; set; }  
		public string CGL_SendMailPorta { get; set; }  
		public bool? CGL_FlagPagamentoVoucher { get; set; }  
		public bool? CGL_FlagPagamentoOnline { get; set; }  
		public bool? CGL_Ativo { get; set; }  
		public string CGL_UrlWEB { get; set; }  	
		public string CGL_CronScheduleJob01 { get; set; }  		
		public string CGL_CronScheduleJob02 { get; set; }
		public string CGL_CronScheduleJob03 { get; set; }
		public Log Log { get; set; }
    }
}

