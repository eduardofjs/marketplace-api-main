
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface ILogServices
    {
        Log InsertLog(Log objLog);
        bool UpdateLog(Log objLog);
        bool AtivarLog(int LOG_Id);
        bool DeletarLog(int LOG_Id);
        Log GetLogById(int LOG_Id, bool join);
        IEnumerable<Log> GetAllLog(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Log> GetAllLogByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Log> GetAllLogByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
