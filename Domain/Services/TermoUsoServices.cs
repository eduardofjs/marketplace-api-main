
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TermoUsoServices : ITermoUsoServices
    {
        private readonly ITermoUsoRepository _TermoUsoRepo;

        public TermoUsoServices(ITermoUsoRepository TermoUsoRepo)
        {
            _TermoUsoRepo = TermoUsoRepo;
        }
		
        public TermoUso InsertTermoUso(TermoUso objTermoUso)
        {
            return _TermoUsoRepo.InsertTermoUso(objTermoUso);
        }

        public bool UpdateTermoUso(TermoUso objTermoUso)
        {
            return _TermoUsoRepo.UpdateTermoUso(objTermoUso);
        }

        public bool AtivarTermoUso(int TRU_Id)
        {
            return _TermoUsoRepo.AtivarTermoUso(TRU_Id);
        }

        public bool DeletarTermoUso(int TRU_Id)
        {
            return _TermoUsoRepo.DeletarTermoUso(TRU_Id);
        }
        
        public TermoUso GetTermoUsoById(int TRU_Id, bool join)
        {
            return _TermoUsoRepo.GetTermoUsoById(TRU_Id, join);
        }

        public IEnumerable<TermoUso> GetAllTermoUso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoRepo.GetAllTermoUso(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TermoUso> GetAllTermoUsoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoRepo.GetAllTermoUsoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TermoUso> GetAllTermoUsoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoRepo.GetAllTermoUsoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

