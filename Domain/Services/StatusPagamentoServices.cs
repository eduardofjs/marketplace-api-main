
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class StatusPagamentoServices : IStatusPagamentoServices
    {
        private readonly IStatusPagamentoRepository _StatusPagamentoRepo;

        public StatusPagamentoServices(IStatusPagamentoRepository StatusPagamentoRepo)
        {
            _StatusPagamentoRepo = StatusPagamentoRepo;
        }
		
        public StatusPagamento InsertStatusPagamento(StatusPagamento objStatusPagamento)
        {
            return _StatusPagamentoRepo.InsertStatusPagamento(objStatusPagamento);
        }

        public bool UpdateStatusPagamento(StatusPagamento objStatusPagamento)
        {
            return _StatusPagamentoRepo.UpdateStatusPagamento(objStatusPagamento);
        }

        public bool AtivarStatusPagamento(int SPG_Id)
        {
            return _StatusPagamentoRepo.AtivarStatusPagamento(SPG_Id);
        }

        public bool DeletarStatusPagamento(int SPG_Id)
        {
            return _StatusPagamentoRepo.DeletarStatusPagamento(SPG_Id);
        }
        
        public StatusPagamento GetStatusPagamentoById(int SPG_Id, bool join)
        {
            return _StatusPagamentoRepo.GetStatusPagamentoById(SPG_Id, join);
        }

        public IEnumerable<StatusPagamento> GetAllStatusPagamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusPagamentoRepo.GetAllStatusPagamento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusPagamento> GetAllStatusPagamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusPagamentoRepo.GetAllStatusPagamentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusPagamento> GetAllStatusPagamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusPagamentoRepo.GetAllStatusPagamentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

