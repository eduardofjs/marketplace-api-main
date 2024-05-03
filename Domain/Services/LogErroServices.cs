
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class LogErroServices : ILogErroServices
    {
        private readonly ILogErroRepository _LogErroRepo;

        public LogErroServices(ILogErroRepository LogErroRepo)
        {
            _LogErroRepo = LogErroRepo;
        }
		
        public LogErro InsertLogErro(LogErro objLogErro)
        {
            return _LogErroRepo.InsertLogErro(objLogErro);
        }

        public bool UpdateLogErro(LogErro objLogErro)
        {
            return _LogErroRepo.UpdateLogErro(objLogErro);
        }

        public bool AtivarLogErro(int LGE_Id)
        {
            return _LogErroRepo.AtivarLogErro(LGE_Id);
        }

        public bool DeletarLogErro(int LGE_Id)
        {
            return _LogErroRepo.DeletarLogErro(LGE_Id);
        }
        
        public LogErro GetLogErroById(int LGE_Id, bool join)
        {
            return _LogErroRepo.GetLogErroById(LGE_Id, join);
        }

        public IEnumerable<LogErro> GetAllLogErro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogErroRepo.GetAllLogErro(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogErro> GetAllLogErroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogErroRepo.GetAllLogErroByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogErro> GetAllLogErroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogErroRepo.GetAllLogErroByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

