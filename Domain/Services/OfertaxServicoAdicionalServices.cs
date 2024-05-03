using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class OfertaxServicoAdicionalServices : IOfertaxServicoAdicionalServices
    {
        private readonly IOfertaxServicoAdicionalRepository _OfertaxServicoAdicionalRepo;

        public OfertaxServicoAdicionalServices(IOfertaxServicoAdicionalRepository OfertaxServicoAdicionalRepo)
        {
            _OfertaxServicoAdicionalRepo = OfertaxServicoAdicionalRepo;
        }

        public OfertaxServicoAdicional InsertOfertaxServicoAdicional(OfertaxServicoAdicional objOfertaxServicoAdicional)
        {
            return _OfertaxServicoAdicionalRepo.InsertOfertaxServicoAdicional(objOfertaxServicoAdicional);
        }

        public bool UpdateOfertaxServicoAdicional(OfertaxServicoAdicional objOfertaxServicoAdicional)
        {
            return _OfertaxServicoAdicionalRepo.UpdateOfertaxServicoAdicional(objOfertaxServicoAdicional);
        }

        public bool AtivarOfertaxServicoAdicional(int OXA_Id)
        {
            return _OfertaxServicoAdicionalRepo.AtivarOfertaxServicoAdicional(OXA_Id);
        }

        public bool DeletarOfertaxServicoAdicional(int OXA_Id)
        {
            return _OfertaxServicoAdicionalRepo.DeletarOfertaxServicoAdicional(OXA_Id);
        }

        public OfertaxServicoAdicional GetOfertaxServicoAdicionalById(int OXA_Id, bool join)
        {
            return _OfertaxServicoAdicionalRepo.GetOfertaxServicoAdicionalById(OXA_Id, join);
        }

        public IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoAdicionalRepo.GetAllOfertaxServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoAdicionalRepo.GetAllOfertaxServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoAdicionalRepo.GetAllOfertaxServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

