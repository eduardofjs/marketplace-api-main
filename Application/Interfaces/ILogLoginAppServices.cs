
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ILogLoginAppServices
    {
        LogLogin InsertLogLogin(LogLogin objLogLogin);
        bool UpdateLogLogin(LogLogin objLogLogin);
        bool AtivarLogLogin(int LLG_Id);
        bool DeletarLogLogin(int LLG_Id);
        LogLogin GetLogLoginById(int LLG_Id, bool join);
        IEnumerable<LogLogin> GetAllLogLogin(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<LogLogin> GetAllLogLoginByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<LogLogin> GetAllLogLoginByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
     
        IEnumerable<LogLogin> GetAllLogLoginAuditorOnline(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by);
	}
}
