
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class OfertaNegociacaoxStatusNegociacaoAppServices : IOfertaNegociacaoxStatusNegociacaoAppServices
    {
        private readonly IOfertaNegociacaoxStatusNegociacaoServices _OfertaNegociacaoxStatusNegociacaoServices;


        public OfertaNegociacaoxStatusNegociacaoAppServices(IOfertaNegociacaoxStatusNegociacaoServices OfertaNegociacaoxStatusNegociacaoServices)
        {
            _OfertaNegociacaoxStatusNegociacaoServices = OfertaNegociacaoxStatusNegociacaoServices;
        }

        public OfertaNegociacaoxStatusNegociacao InsertOfertaNegociacaoxStatusNegociacao(OfertaNegociacaoxStatusNegociacao objOfertaNegociacaoxStatusNegociacao)
        {
            return _OfertaNegociacaoxStatusNegociacaoServices.InsertOfertaNegociacaoxStatusNegociacao(objOfertaNegociacaoxStatusNegociacao);
        }

        public bool UpdateOfertaNegociacaoxStatusNegociacao(OfertaNegociacaoxStatusNegociacao objOfertaNegociacaoxStatusNegociacao)
        {
            return _OfertaNegociacaoxStatusNegociacaoServices.UpdateOfertaNegociacaoxStatusNegociacao(objOfertaNegociacaoxStatusNegociacao);
        }

        public bool AtivarOfertaNegociacaoxStatusNegociacao(int ONS_Id)
        {
            return _OfertaNegociacaoxStatusNegociacaoServices.AtivarOfertaNegociacaoxStatusNegociacao(ONS_Id);
        }

        public bool DeletarOfertaNegociacaoxStatusNegociacao(int ONS_Id)
        {
            return _OfertaNegociacaoxStatusNegociacaoServices.DeletarOfertaNegociacaoxStatusNegociacao(ONS_Id);
        }

        public OfertaNegociacaoxStatusNegociacao GetOfertaNegociacaoxStatusNegociacaoById(int ONS_Id, bool join)
        {
            return _OfertaNegociacaoxStatusNegociacaoServices.GetOfertaNegociacaoxStatusNegociacaoById(ONS_Id, join);
        }

        public IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxStatusNegociacaoServices.GetAllOfertaNegociacaoxStatusNegociacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxStatusNegociacaoServices.GetAllOfertaNegociacaoxStatusNegociacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxStatusNegociacaoServices.GetAllOfertaNegociacaoxStatusNegociacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

