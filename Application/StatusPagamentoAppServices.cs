
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class StatusPagamentoAppServices : IStatusPagamentoAppServices
    {
        private readonly IStatusPagamentoServices _StatusPagamentoServices;
             

        public StatusPagamentoAppServices(IStatusPagamentoServices StatusPagamentoServices      )
        {
            _StatusPagamentoServices = StatusPagamentoServices;
               
        }

        public StatusPagamento InsertStatusPagamento(StatusPagamento objStatusPagamento)
        {
                 
            
            return _StatusPagamentoServices.InsertStatusPagamento(objStatusPagamento);
        }

        public bool UpdateStatusPagamento(StatusPagamento objStatusPagamento)
        {            
                
            return _StatusPagamentoServices.UpdateStatusPagamento(objStatusPagamento);
        }

        public bool AtivarStatusPagamento(int SPG_Id)
        {
            return _StatusPagamentoServices.AtivarStatusPagamento(SPG_Id);
        }

        public bool DeletarStatusPagamento(int SPG_Id)
        {
            return _StatusPagamentoServices.DeletarStatusPagamento(SPG_Id);
        }

        public StatusPagamento GetStatusPagamentoById(int SPG_Id, bool join)
        {
            return _StatusPagamentoServices.GetStatusPagamentoById(SPG_Id, join);
        }

        public IEnumerable<StatusPagamento> GetAllStatusPagamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusPagamentoServices.GetAllStatusPagamento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusPagamento> GetAllStatusPagamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusPagamentoServices.GetAllStatusPagamentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusPagamento> GetAllStatusPagamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusPagamentoServices.GetAllStatusPagamentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

