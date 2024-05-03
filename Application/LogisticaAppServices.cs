using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class LogisticaAppServices : ILogisticaAppServices
    {
        private readonly ILogisticaServices _LogisticaServices;


        public LogisticaAppServices(ILogisticaServices LogisticaServices)
        {
            _LogisticaServices = LogisticaServices;

        }

        public Logistica InsertLogistica(Logistica objLogistica)
        {


            return _LogisticaServices.InsertLogistica(objLogistica);
        }

        public bool UpdateLogistica(Logistica objLogistica)
        {

            return _LogisticaServices.UpdateLogistica(objLogistica);
        }

        public bool AtivarLogistica(int LGT_Id)
        {
            return _LogisticaServices.AtivarLogistica(LGT_Id);
        }

        public bool DeletarLogistica(int LGT_Id)
        {
            return _LogisticaServices.DeletarLogistica(LGT_Id);
        }

        public Logistica GetLogisticaById(int LGT_Id, bool join)
        {
            return _LogisticaServices.GetLogisticaById(LGT_Id, join);
        }

        public IEnumerable<Logistica> GetAllLogistica(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogisticaServices.GetAllLogistica(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Logistica> GetAllLogisticaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogisticaServices.GetAllLogisticaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Logistica> GetAllLogisticaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogisticaServices.GetAllLogisticaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

