using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class LogisticaServices : ILogisticaServices
    {
        private readonly ILogisticaRepository _LogisticaRepo;

        public LogisticaServices(ILogisticaRepository LogisticaRepo)
        {
            _LogisticaRepo = LogisticaRepo;
        }

        public Logistica InsertLogistica(Logistica objLogistica)
        {
            return _LogisticaRepo.InsertLogistica(objLogistica);
        }

        public bool UpdateLogistica(Logistica objLogistica)
        {
            return _LogisticaRepo.UpdateLogistica(objLogistica);
        }

        public bool AtivarLogistica(int LGT_Id)
        {
            return _LogisticaRepo.AtivarLogistica(LGT_Id);
        }

        public bool DeletarLogistica(int LGT_Id)
        {
            return _LogisticaRepo.DeletarLogistica(LGT_Id);
        }

        public Logistica GetLogisticaById(int LGT_Id, bool join)
        {
            return _LogisticaRepo.GetLogisticaById(LGT_Id, join);
        }

        public IEnumerable<Logistica> GetAllLogistica(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogisticaRepo.GetAllLogistica(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Logistica> GetAllLogisticaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogisticaRepo.GetAllLogisticaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Logistica> GetAllLogisticaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogisticaRepo.GetAllLogisticaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}


