
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TipoTransacaoLogServices : ITipoTransacaoLogServices
    {
        private readonly ITipoTransacaoLogRepository _TipoTransacaoLogRepo;

        public TipoTransacaoLogServices(ITipoTransacaoLogRepository TipoTransacaoLogRepo)
        {
            _TipoTransacaoLogRepo = TipoTransacaoLogRepo;
        }
		
        public TipoTransacaoLog InsertTipoTransacaoLog(TipoTransacaoLog objTipoTransacaoLog)
        {
            return _TipoTransacaoLogRepo.InsertTipoTransacaoLog(objTipoTransacaoLog);
        }

        public bool UpdateTipoTransacaoLog(TipoTransacaoLog objTipoTransacaoLog)
        {
            return _TipoTransacaoLogRepo.UpdateTipoTransacaoLog(objTipoTransacaoLog);
        }

        public bool AtivarTipoTransacaoLog(int TTL_Id)
        {
            return _TipoTransacaoLogRepo.AtivarTipoTransacaoLog(TTL_Id);
        }

        public bool DeletarTipoTransacaoLog(int TTL_Id)
        {
            return _TipoTransacaoLogRepo.DeletarTipoTransacaoLog(TTL_Id);
        }
        
        public TipoTransacaoLog GetTipoTransacaoLogById(int TTL_Id, bool join)
        {
            return _TipoTransacaoLogRepo.GetTipoTransacaoLogById(TTL_Id, join);
        }

        public IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLog(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoTransacaoLogRepo.GetAllTipoTransacaoLog(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLogByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoTransacaoLogRepo.GetAllTipoTransacaoLogByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLogByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoTransacaoLogRepo.GetAllTipoTransacaoLogByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

