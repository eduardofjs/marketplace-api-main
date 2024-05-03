
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IConfiguracaoGlobalRepository
    {
        ConfiguracaoGlobal InsertConfiguracaoGlobal(ConfiguracaoGlobal objConfiguracaoGlobal);
        bool UpdateConfiguracaoGlobal(ConfiguracaoGlobal objConfiguracaoGlobal);
        bool AtivarConfiguracaoGlobal(int CGL_Id);
        bool DeletarConfiguracaoGlobal(int CGL_Id);
        ConfiguracaoGlobal GetConfiguracaoGlobalById(int CGL_Id, bool join);
        IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobal(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}