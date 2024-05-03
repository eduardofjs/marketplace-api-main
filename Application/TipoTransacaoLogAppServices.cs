
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TipoTransacaoLogAppServices : ITipoTransacaoLogAppServices
    {
        private readonly ITipoTransacaoLogServices _TipoTransacaoLogServices;
              

        public TipoTransacaoLogAppServices(ITipoTransacaoLogServices TipoTransacaoLogServices       )
        {
            _TipoTransacaoLogServices = TipoTransacaoLogServices;
                
        }

        public TipoTransacaoLog InsertTipoTransacaoLog(TipoTransacaoLog objTipoTransacaoLog)
        {
                  
            
            return _TipoTransacaoLogServices.InsertTipoTransacaoLog(objTipoTransacaoLog);
        }

        public bool UpdateTipoTransacaoLog(TipoTransacaoLog objTipoTransacaoLog)
        {            
                 
            return _TipoTransacaoLogServices.UpdateTipoTransacaoLog(objTipoTransacaoLog);
        }

        public bool AtivarTipoTransacaoLog(int TTL_Id)
        {
            return _TipoTransacaoLogServices.AtivarTipoTransacaoLog(TTL_Id);
        }

        public bool DeletarTipoTransacaoLog(int TTL_Id)
        {
            return _TipoTransacaoLogServices.DeletarTipoTransacaoLog(TTL_Id);
        }

        public TipoTransacaoLog GetTipoTransacaoLogById(int TTL_Id, bool join)
        {
            return _TipoTransacaoLogServices.GetTipoTransacaoLogById(TTL_Id, join);
        }

        public IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLog(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoTransacaoLogServices.GetAllTipoTransacaoLog(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLogByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoTransacaoLogServices.GetAllTipoTransacaoLogByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLogByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoTransacaoLogServices.GetAllTipoTransacaoLogByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

