
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class PronomeTratamentoServices : IPronomeTratamentoServices
    {
        private readonly IPronomeTratamentoRepository _PronomeTratamentoRepo;

        public PronomeTratamentoServices(IPronomeTratamentoRepository PronomeTratamentoRepo)
        {
            _PronomeTratamentoRepo = PronomeTratamentoRepo;
        }
		
        public PronomeTratamento InsertPronomeTratamento(PronomeTratamento objPronomeTratamento)
        {
            return _PronomeTratamentoRepo.InsertPronomeTratamento(objPronomeTratamento);
        }

        public bool UpdatePronomeTratamento(PronomeTratamento objPronomeTratamento)
        {
            return _PronomeTratamentoRepo.UpdatePronomeTratamento(objPronomeTratamento);
        }

        public bool AtivarPronomeTratamento(int PRT_Id)
        {
            return _PronomeTratamentoRepo.AtivarPronomeTratamento(PRT_Id);
        }

        public bool DeletarPronomeTratamento(int PRT_Id)
        {
            return _PronomeTratamentoRepo.DeletarPronomeTratamento(PRT_Id);
        }
        
        public PronomeTratamento GetPronomeTratamentoById(int PRT_Id, bool join)
        {
            return _PronomeTratamentoRepo.GetPronomeTratamentoById(PRT_Id, join);
        }

        public IEnumerable<PronomeTratamento> GetAllPronomeTratamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PronomeTratamentoRepo.GetAllPronomeTratamento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PronomeTratamento> GetAllPronomeTratamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PronomeTratamentoRepo.GetAllPronomeTratamentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PronomeTratamento> GetAllPronomeTratamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PronomeTratamentoRepo.GetAllPronomeTratamentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

