
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TipoServicoAdicionalServices : ITipoServicoAdicionalServices
    {
        private readonly ITipoServicoAdicionalRepository _TipoServicoAdicionalRepo;

        public TipoServicoAdicionalServices(ITipoServicoAdicionalRepository TipoServicoAdicionalRepo)
        {
            _TipoServicoAdicionalRepo = TipoServicoAdicionalRepo;
        }

        public TipoServicoAdicional InsertTipoServicoAdicional(TipoServicoAdicional objTipoServicoAdicional)
        {
            return _TipoServicoAdicionalRepo.InsertTipoServicoAdicional(objTipoServicoAdicional);
        }

        public bool UpdateTipoServicoAdicional(TipoServicoAdicional objTipoServicoAdicional)
        {
            return _TipoServicoAdicionalRepo.UpdateTipoServicoAdicional(objTipoServicoAdicional);
        }

        public bool AtivarTipoServicoAdicional(int TSA_Id)
        {
            return _TipoServicoAdicionalRepo.AtivarTipoServicoAdicional(TSA_Id);
        }

        public bool DeletarTipoServicoAdicional(int TSA_Id)
        {
            return _TipoServicoAdicionalRepo.DeletarTipoServicoAdicional(TSA_Id);
        }

        public TipoServicoAdicional GetTipoServicoAdicionalById(int TSA_Id, bool join)
        {
            return _TipoServicoAdicionalRepo.GetTipoServicoAdicionalById(TSA_Id, join);
        }

        public IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoServicoAdicionalRepo.GetAllTipoServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoServicoAdicionalRepo.GetAllTipoServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoServicoAdicionalRepo.GetAllTipoServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

