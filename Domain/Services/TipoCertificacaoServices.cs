
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TipoCertificacaoServices : ITipoCertificacaoServices
    {
        private readonly ITipoCertificacaoRepository _TipoCertificacaoRepo;

        public TipoCertificacaoServices(ITipoCertificacaoRepository TipoCertificacaoRepo)
        {
            _TipoCertificacaoRepo = TipoCertificacaoRepo;
        }

        public TipoCertificacao InsertTipoCertificacao(TipoCertificacao objTipoCertificacao)
        {
            return _TipoCertificacaoRepo.InsertTipoCertificacao(objTipoCertificacao);
        }

        public bool UpdateTipoCertificacao(TipoCertificacao objTipoCertificacao)
        {
            return _TipoCertificacaoRepo.UpdateTipoCertificacao(objTipoCertificacao);
        }

        public bool AtivarTipoCertificacao(int TPC_Id)
        {
            return _TipoCertificacaoRepo.AtivarTipoCertificacao(TPC_Id);
        }

        public bool DeletarTipoCertificacao(int TPC_Id)
        {
            return _TipoCertificacaoRepo.DeletarTipoCertificacao(TPC_Id);
        }

        public TipoCertificacao GetTipoCertificacaoById(int TPC_Id, bool join)
        {
            return _TipoCertificacaoRepo.GetTipoCertificacaoById(TPC_Id, join);
        }

        public IEnumerable<TipoCertificacao> GetAllTipoCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoCertificacaoRepo.GetAllTipoCertificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoCertificacao> GetAllTipoCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoCertificacaoRepo.GetAllTipoCertificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoCertificacao> GetAllTipoCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoCertificacaoRepo.GetAllTipoCertificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

