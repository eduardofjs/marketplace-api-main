using Application.Interfaces;
using Data.Repositories;
using Domain.Entities;
using DIRECTTO.Controllers;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIRECTTO.Quartz
{
    public class Service01Job : IJob
    {
        private readonly IOfertaxQuantidadeProdutoAppServices _OfertaxQuantidadeProdutoAppServices;

        public Service01Job(IOfertaxQuantidadeProdutoAppServices OfertaxQuantidadeProdutoAppServices)
        {
            _OfertaxQuantidadeProdutoAppServices = OfertaxQuantidadeProdutoAppServices;
        }
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                string data = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " 00:00:00";
                var listaOfertaxQuantidadeProduto = _OfertaxQuantidadeProdutoAppServices.GetAllOfertaxQuantidadeProdutoByValorExato(data, "OXQ_DataExpiracao", true, false);
                if (listaOfertaxQuantidadeProduto.Count() > 0)
                {
                    foreach (var item in listaOfertaxQuantidadeProduto)
                    {
                        _OfertaxQuantidadeProdutoAppServices.DeletarOfertaxQuantidadeProduto(item.OXQ_Id);
                    }
                }
            }
            catch (Exception ex)
            {
                Log Log = new Log();
                RepositoryBase.salvaLogError(Log, "Service01", "Execute", ex.InnerException.ToString(), ex.Message, ex.StackTrace, "");
            }

            //throw new NotImplementedException();
        }

        public static string ReadString(string key)
        {
            try
            {
                String valor;
                System.Configuration.AppSettingsReader rd = new System.Configuration.AppSettingsReader();
                valor = rd.GetValue("ConfigGlobal", typeof(String)).ToString();

                String value;
                var _ConfiguracaoGlobalRepo = new ConfiguracaoGlobalRepository();
                value = _ConfiguracaoGlobalRepo.getCampoConfiguracaoGlobal(key, Convert.ToInt32(valor));

                return value;

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}