using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class OfertaxServicoOpcionalServices : IOfertaxServicoOpcionalServices
    {
        private readonly IOfertaxServicoOpcionalRepository _OfertaxServicoOpcionalRepo;

        public OfertaxServicoOpcionalServices(IOfertaxServicoOpcionalRepository OfertaxServicoOpcionalRepo)
        {
            _OfertaxServicoOpcionalRepo = OfertaxServicoOpcionalRepo;
        }

        public OfertaxServicoOpcional InsertOfertaxServicoOpcional(OfertaxServicoOpcional objOfertaxServicoOpcional)
        {
            return _OfertaxServicoOpcionalRepo.InsertOfertaxServicoOpcional(objOfertaxServicoOpcional);
        }

        public bool UpdateOfertaxServicoOpcional(OfertaxServicoOpcional objOfertaxServicoOpcional)
        {
            return _OfertaxServicoOpcionalRepo.UpdateOfertaxServicoOpcional(objOfertaxServicoOpcional);
        }

        public bool AtivarOfertaxServicoOpcional(int OXS_Id)
        {
            return _OfertaxServicoOpcionalRepo.AtivarOfertaxServicoOpcional(OXS_Id);
        }

        public bool DeletarOfertaxServicoOpcional(int OXS_Id)
        {
            return _OfertaxServicoOpcionalRepo.DeletarOfertaxServicoOpcional(OXS_Id);
        }

        public OfertaxServicoOpcional GetOfertaxServicoOpcionalById(int OXS_Id, bool join)
        {
            return _OfertaxServicoOpcionalRepo.GetOfertaxServicoOpcionalById(OXS_Id, join);
        }

        public IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoOpcionalRepo.GetAllOfertaxServicoOpcional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoOpcionalRepo.GetAllOfertaxServicoOpcionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoOpcionalRepo.GetAllOfertaxServicoOpcionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

