
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface INotificacaoServices
    {
        Notificacao InsertNotificacao(Notificacao objNotificacao);
        bool UpdateNotificacao(Notificacao objNotificacao);
        bool AtivarNotificacao(int NOT_Id);
        bool DeletarNotificacao(int NOT_Id);
        Notificacao GetNotificacaoById(int NOT_Id, bool join);
        IEnumerable<Notificacao> GetAllNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Notificacao> GetAllNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Notificacao> GetAllNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
