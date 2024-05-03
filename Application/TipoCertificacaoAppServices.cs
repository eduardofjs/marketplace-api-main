
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TipoCertificacaoAppServices : ITipoCertificacaoAppServices
    {
        private readonly ITipoCertificacaoServices _TipoCertificacaoServices;


        public TipoCertificacaoAppServices(ITipoCertificacaoServices TipoCertificacaoServices)
        {
            _TipoCertificacaoServices = TipoCertificacaoServices;

        }

        public TipoCertificacao InsertTipoCertificacao(TipoCertificacao objTipoCertificacao)
        {


            return _TipoCertificacaoServices.InsertTipoCertificacao(objTipoCertificacao);
        }

        public bool UpdateTipoCertificacao(TipoCertificacao objTipoCertificacao)
        {

            return _TipoCertificacaoServices.UpdateTipoCertificacao(objTipoCertificacao);
        }

        public bool AtivarTipoCertificacao(int TPC_Id)
        {
            return _TipoCertificacaoServices.AtivarTipoCertificacao(TPC_Id);
        }

        public bool DeletarTipoCertificacao(int TPC_Id)
        {
            return _TipoCertificacaoServices.DeletarTipoCertificacao(TPC_Id);
        }

        public TipoCertificacao GetTipoCertificacaoById(int TPC_Id, bool join)
        {
            return _TipoCertificacaoServices.GetTipoCertificacaoById(TPC_Id, join);
        }

        public IEnumerable<TipoCertificacao> GetAllTipoCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoCertificacaoServices.GetAllTipoCertificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoCertificacao> GetAllTipoCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoCertificacaoServices.GetAllTipoCertificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoCertificacao> GetAllTipoCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoCertificacaoServices.GetAllTipoCertificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

