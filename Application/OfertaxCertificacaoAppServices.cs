using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class OfertaxCertificacaoAppServices : IOfertaxCertificacaoAppServices
    {
        private readonly IOfertaxCertificacaoServices _OfertaxCertificacaoServices;


        public OfertaxCertificacaoAppServices(IOfertaxCertificacaoServices OfertaxCertificacaoServices)
        {
            _OfertaxCertificacaoServices = OfertaxCertificacaoServices;
        }

        public OfertaxCertificacao InsertOfertaxCertificacao(OfertaxCertificacao objOfertaxCertificacao)
        {


            return _OfertaxCertificacaoServices.InsertOfertaxCertificacao(objOfertaxCertificacao);
        }

        public bool UpdateOfertaxCertificacao(OfertaxCertificacao objOfertaxCertificacao)
        {

            return _OfertaxCertificacaoServices.UpdateOfertaxCertificacao(objOfertaxCertificacao);
        }

        public bool AtivarOfertaxCertificacao(int OXC_Id)
        {
            return _OfertaxCertificacaoServices.AtivarOfertaxCertificacao(OXC_Id);
        }

        public bool DeletarOfertaxCertificacao(int OXC_Id)
        {
            return _OfertaxCertificacaoServices.DeletarOfertaxCertificacao(OXC_Id);
        }

        public OfertaxCertificacao GetOfertaxCertificacaoById(int OXC_Id, bool join)
        {
            return _OfertaxCertificacaoServices.GetOfertaxCertificacaoById(OXC_Id, join);
        }

        public IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxCertificacaoServices.GetAllOfertaxCertificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxCertificacaoServices.GetAllOfertaxCertificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxCertificacaoServices.GetAllOfertaxCertificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

