
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface ITipoCertificacaoRepository
    {
        TipoCertificacao InsertTipoCertificacao(TipoCertificacao objTipoCertificacao);
        bool UpdateTipoCertificacao(TipoCertificacao objTipoCertificacao);
        bool AtivarTipoCertificacao(int TPC_Id);
        bool DeletarTipoCertificacao(int TPC_Id);
        TipoCertificacao GetTipoCertificacaoById(int TPC_Id, bool join);
        IEnumerable<TipoCertificacao> GetAllTipoCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoCertificacao> GetAllTipoCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoCertificacao> GetAllTipoCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
