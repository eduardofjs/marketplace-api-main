
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ITipoNotificacaoAppServices
    {
        TipoNotificacao InsertTipoNotificacao(TipoNotificacao objTipoNotificacao);
        bool UpdateTipoNotificacao(TipoNotificacao objTipoNotificacao);
        bool AtivarTipoNotificacao(int TPN_Id);
        bool DeletarTipoNotificacao(int TPN_Id);
        TipoNotificacao GetTipoNotificacaoById(int TPN_Id, bool join);
        IEnumerable<TipoNotificacao> GetAllTipoNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoNotificacao> GetAllTipoNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoNotificacao> GetAllTipoNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
