using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class StatusNegociacaoServices : IStatusNegociacaoServices
    {
        private readonly IStatusNegociacaoRepository _StatusNegociacaoRepo;

        public StatusNegociacaoServices(IStatusNegociacaoRepository StatusNegociacaoRepo)
        {
            _StatusNegociacaoRepo = StatusNegociacaoRepo;
        }

        public StatusNegociacao InsertStatusNegociacao(StatusNegociacao objStatusNegociacao)
        {
            return _StatusNegociacaoRepo.InsertStatusNegociacao(objStatusNegociacao);
        }

        public bool UpdateStatusNegociacao(StatusNegociacao objStatusNegociacao)
        {
            return _StatusNegociacaoRepo.UpdateStatusNegociacao(objStatusNegociacao);
        }

        public bool AtivarStatusNegociacao(int STN_Id)
        {
            return _StatusNegociacaoRepo.AtivarStatusNegociacao(STN_Id);
        }

        public bool DeletarStatusNegociacao(int STN_Id)
        {
            return _StatusNegociacaoRepo.DeletarStatusNegociacao(STN_Id);
        }

        public StatusNegociacao GetStatusNegociacaoById(int STN_Id, bool join)
        {
            return _StatusNegociacaoRepo.GetStatusNegociacaoById(STN_Id, join);
        }

        public IEnumerable<StatusNegociacao> GetAllStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusNegociacaoRepo.GetAllStatusNegociacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusNegociacao> GetAllStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusNegociacaoRepo.GetAllStatusNegociacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusNegociacao> GetAllStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusNegociacaoRepo.GetAllStatusNegociacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

