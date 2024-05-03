using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IStatusNegociacaoAppServices
    {
        StatusNegociacao InsertStatusNegociacao(StatusNegociacao objStatusNegociacao);
        bool UpdateStatusNegociacao(StatusNegociacao objStatusNegociacao);
        bool AtivarStatusNegociacao(int STN_Id);
        bool DeletarStatusNegociacao(int STN_Id);
        StatusNegociacao GetStatusNegociacaoById(int STN_Id, bool join);
        IEnumerable<StatusNegociacao> GetAllStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<StatusNegociacao> GetAllStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<StatusNegociacao> GetAllStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
