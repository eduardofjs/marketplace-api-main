
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ConfiguracaoGlobalAppServices : IConfiguracaoGlobalAppServices
    {
        private readonly IConfiguracaoGlobalServices _ConfiguracaoGlobalServices;
                               

        public ConfiguracaoGlobalAppServices(IConfiguracaoGlobalServices ConfiguracaoGlobalServices                        )
        {
            _ConfiguracaoGlobalServices = ConfiguracaoGlobalServices;
                                 
        }

        public ConfiguracaoGlobal InsertConfiguracaoGlobal(ConfiguracaoGlobal objConfiguracaoGlobal)
        {
                                   
            
            return _ConfiguracaoGlobalServices.InsertConfiguracaoGlobal(objConfiguracaoGlobal);
        }

        public bool UpdateConfiguracaoGlobal(ConfiguracaoGlobal objConfiguracaoGlobal)
        {            
                                  
            return _ConfiguracaoGlobalServices.UpdateConfiguracaoGlobal(objConfiguracaoGlobal);
        }

        public bool AtivarConfiguracaoGlobal(int CGL_Id)
        {
            return _ConfiguracaoGlobalServices.AtivarConfiguracaoGlobal(CGL_Id);
        }

        public bool DeletarConfiguracaoGlobal(int CGL_Id)
        {
            return _ConfiguracaoGlobalServices.DeletarConfiguracaoGlobal(CGL_Id);
        }

        public ConfiguracaoGlobal GetConfiguracaoGlobalById(int CGL_Id, bool join)
        {
            return _ConfiguracaoGlobalServices.GetConfiguracaoGlobalById(CGL_Id, join);
        }

        public IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobal(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ConfiguracaoGlobalServices.GetAllConfiguracaoGlobal(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ConfiguracaoGlobalServices.GetAllConfiguracaoGlobalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ConfiguracaoGlobalServices.GetAllConfiguracaoGlobalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

