using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ILogisticaAppServices
    {
        Logistica InsertLogistica(Logistica objLogistica);
        bool UpdateLogistica(Logistica objLogistica);
        bool AtivarLogistica(int LGT_Id);
        bool DeletarLogistica(int LGT_Id);
        Logistica GetLogisticaById(int LGT_Id, bool join);
        IEnumerable<Logistica> GetAllLogistica(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Logistica> GetAllLogisticaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Logistica> GetAllLogisticaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
