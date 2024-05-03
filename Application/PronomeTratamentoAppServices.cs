
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class PronomeTratamentoAppServices : IPronomeTratamentoAppServices
    {
        private readonly IPronomeTratamentoServices _PronomeTratamentoServices;
              

        public PronomeTratamentoAppServices(IPronomeTratamentoServices PronomeTratamentoServices       )
        {
            _PronomeTratamentoServices = PronomeTratamentoServices;
                
        }

        public PronomeTratamento InsertPronomeTratamento(PronomeTratamento objPronomeTratamento)
        {
                  
            
            return _PronomeTratamentoServices.InsertPronomeTratamento(objPronomeTratamento);
        }

        public bool UpdatePronomeTratamento(PronomeTratamento objPronomeTratamento)
        {            
                 
            return _PronomeTratamentoServices.UpdatePronomeTratamento(objPronomeTratamento);
        }

        public bool AtivarPronomeTratamento(int PRT_Id)
        {
            return _PronomeTratamentoServices.AtivarPronomeTratamento(PRT_Id);
        }

        public bool DeletarPronomeTratamento(int PRT_Id)
        {
            return _PronomeTratamentoServices.DeletarPronomeTratamento(PRT_Id);
        }

        public PronomeTratamento GetPronomeTratamentoById(int PRT_Id, bool join)
        {
            return _PronomeTratamentoServices.GetPronomeTratamentoById(PRT_Id, join);
        }

        public IEnumerable<PronomeTratamento> GetAllPronomeTratamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PronomeTratamentoServices.GetAllPronomeTratamento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PronomeTratamento> GetAllPronomeTratamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PronomeTratamentoServices.GetAllPronomeTratamentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PronomeTratamento> GetAllPronomeTratamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PronomeTratamentoServices.GetAllPronomeTratamentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

