
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class LogServices : ILogServices
    {
        private readonly ILogRepository _LogRepo;

        public LogServices(ILogRepository LogRepo)
        {
            _LogRepo = LogRepo;
        }
		
        public Log InsertLog(Log objLog)
        {
            return _LogRepo.InsertLog(objLog);
        }

        public bool UpdateLog(Log objLog)
        {
            return _LogRepo.UpdateLog(objLog);
        }

        public bool AtivarLog(int LOG_Id)
        {
            return _LogRepo.AtivarLog(LOG_Id);
        }

        public bool DeletarLog(int LOG_Id)
        {
            return _LogRepo.DeletarLog(LOG_Id);
        }
        
        public Log GetLogById(int LOG_Id, bool join)
        {
            return _LogRepo.GetLogById(LOG_Id, join);
        }

        public IEnumerable<Log> GetAllLog(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogRepo.GetAllLog(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Log> GetAllLogByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogRepo.GetAllLogByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Log> GetAllLogByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogRepo.GetAllLogByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

