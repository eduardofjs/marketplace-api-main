
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class LogLoginServices : ILogLoginServices
    {
        private readonly ILogLoginRepository _LogLoginRepo;

        public LogLoginServices(ILogLoginRepository LogLoginRepo)
        {
            _LogLoginRepo = LogLoginRepo;
        }
		
        public LogLogin InsertLogLogin(LogLogin objLogLogin)
        {
            return _LogLoginRepo.InsertLogLogin(objLogLogin);
        }

        public bool UpdateLogLogin(LogLogin objLogLogin)
        {
            return _LogLoginRepo.UpdateLogLogin(objLogLogin);
        }

        public bool AtivarLogLogin(int LLG_Id)
        {
            return _LogLoginRepo.AtivarLogLogin(LLG_Id);
        }

        public bool DeletarLogLogin(int LLG_Id)
        {
            return _LogLoginRepo.DeletarLogLogin(LLG_Id);
        }
        
        public LogLogin GetLogLoginById(int LLG_Id, bool join)
        {
            return _LogLoginRepo.GetLogLoginById(LLG_Id, join);
        }

        public IEnumerable<LogLogin> GetAllLogLogin(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogLoginRepo.GetAllLogLogin(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogLogin> GetAllLogLoginByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogLoginRepo.GetAllLogLoginByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogLogin> GetAllLogLoginByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogLoginRepo.GetAllLogLoginByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogLogin> GetAllLogLoginAuditorOnline(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by)
        {
            return _LogLoginRepo.GetAllLogLoginAuditorOnline(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

