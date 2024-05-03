using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IModoCultivoModoProducaoServices
    {
        ModoCultivoModoProducao InsertModoCultivoModoProducao(ModoCultivoModoProducao objModoCultivoModoProducao);
        bool UpdateModoCultivoModoProducao(ModoCultivoModoProducao objModoCultivoModoProducao);
        bool AtivarModoCultivoModoProducao(int MCM_Id);
        bool DeletarModoCultivoModoProducao(int MCM_Id);
        ModoCultivoModoProducao GetModoCultivoModoProducaoById(int MCM_Id, bool join);
        IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
