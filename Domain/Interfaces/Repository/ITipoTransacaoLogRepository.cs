
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface ITipoTransacaoLogRepository
    {
        TipoTransacaoLog InsertTipoTransacaoLog(TipoTransacaoLog objTipoTransacaoLog);
        bool UpdateTipoTransacaoLog(TipoTransacaoLog objTipoTransacaoLog);
        bool AtivarTipoTransacaoLog(int TTL_Id);
        bool DeletarTipoTransacaoLog(int TTL_Id);
        TipoTransacaoLog GetTipoTransacaoLogById(int TTL_Id, bool join);
        IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLog(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLogByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLogByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
