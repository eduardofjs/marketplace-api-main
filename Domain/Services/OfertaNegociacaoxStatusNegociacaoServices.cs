
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class OfertaNegociacaoxStatusNegociacaoServices : IOfertaNegociacaoxStatusNegociacaoServices
    {
        private readonly IOfertaNegociacaoxStatusNegociacaoRepository _OfertaNegociacaoxStatusNegociacaoRepo;

        public OfertaNegociacaoxStatusNegociacaoServices(IOfertaNegociacaoxStatusNegociacaoRepository OfertaNegociacaoxStatusNegociacaoRepo)
        {
            _OfertaNegociacaoxStatusNegociacaoRepo = OfertaNegociacaoxStatusNegociacaoRepo;
        }

        public OfertaNegociacaoxStatusNegociacao InsertOfertaNegociacaoxStatusNegociacao(OfertaNegociacaoxStatusNegociacao objOfertaNegociacaoxStatusNegociacao)
        {
            return _OfertaNegociacaoxStatusNegociacaoRepo.InsertOfertaNegociacaoxStatusNegociacao(objOfertaNegociacaoxStatusNegociacao);
        }

        public bool UpdateOfertaNegociacaoxStatusNegociacao(OfertaNegociacaoxStatusNegociacao objOfertaNegociacaoxStatusNegociacao)
        {
            return _OfertaNegociacaoxStatusNegociacaoRepo.UpdateOfertaNegociacaoxStatusNegociacao(objOfertaNegociacaoxStatusNegociacao);
        }

        public bool AtivarOfertaNegociacaoxStatusNegociacao(int ONS_Id)
        {
            return _OfertaNegociacaoxStatusNegociacaoRepo.AtivarOfertaNegociacaoxStatusNegociacao(ONS_Id);
        }

        public bool DeletarOfertaNegociacaoxStatusNegociacao(int ONS_Id)
        {
            return _OfertaNegociacaoxStatusNegociacaoRepo.DeletarOfertaNegociacaoxStatusNegociacao(ONS_Id);
        }

        public OfertaNegociacaoxStatusNegociacao GetOfertaNegociacaoxStatusNegociacaoById(int ONS_Id, bool join)
        {
            return _OfertaNegociacaoxStatusNegociacaoRepo.GetOfertaNegociacaoxStatusNegociacaoById(ONS_Id, join);
        }

        public IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxStatusNegociacaoRepo.GetAllOfertaNegociacaoxStatusNegociacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxStatusNegociacaoRepo.GetAllOfertaNegociacaoxStatusNegociacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxStatusNegociacaoRepo.GetAllOfertaNegociacaoxStatusNegociacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

