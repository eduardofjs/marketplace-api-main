
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ILogErroAppServices
    {
        LogErro InsertLogErro(LogErro objLogErro);
        bool UpdateLogErro(LogErro objLogErro);
        bool AtivarLogErro(int LGE_Id);
        bool DeletarLogErro(int LGE_Id);
        LogErro GetLogErroById(int LGE_Id, bool join);
        IEnumerable<LogErro> GetAllLogErro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<LogErro> GetAllLogErroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<LogErro> GetAllLogErroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
