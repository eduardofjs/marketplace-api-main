
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class ConfiguracaoGlobalServices : IConfiguracaoGlobalServices
    {
        private readonly IConfiguracaoGlobalRepository _ConfiguracaoGlobalRepo;

        public ConfiguracaoGlobalServices(IConfiguracaoGlobalRepository ConfiguracaoGlobalRepo)
        {
            _ConfiguracaoGlobalRepo = ConfiguracaoGlobalRepo;
        }
		
        public ConfiguracaoGlobal InsertConfiguracaoGlobal(ConfiguracaoGlobal objConfiguracaoGlobal)
        {
            return _ConfiguracaoGlobalRepo.InsertConfiguracaoGlobal(objConfiguracaoGlobal);
        }

        public bool UpdateConfiguracaoGlobal(ConfiguracaoGlobal objConfiguracaoGlobal)
        {
            return _ConfiguracaoGlobalRepo.UpdateConfiguracaoGlobal(objConfiguracaoGlobal);
        }

        public bool AtivarConfiguracaoGlobal(int CGL_Id)
        {
            return _ConfiguracaoGlobalRepo.AtivarConfiguracaoGlobal(CGL_Id);
        }

        public bool DeletarConfiguracaoGlobal(int CGL_Id)
        {
            return _ConfiguracaoGlobalRepo.DeletarConfiguracaoGlobal(CGL_Id);
        }
        
        public ConfiguracaoGlobal GetConfiguracaoGlobalById(int CGL_Id, bool join)
        {
            return _ConfiguracaoGlobalRepo.GetConfiguracaoGlobalById(CGL_Id, join);
        }

        public IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobal(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ConfiguracaoGlobalRepo.GetAllConfiguracaoGlobal(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ConfiguracaoGlobalRepo.GetAllConfiguracaoGlobalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ConfiguracaoGlobalRepo.GetAllConfiguracaoGlobalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

