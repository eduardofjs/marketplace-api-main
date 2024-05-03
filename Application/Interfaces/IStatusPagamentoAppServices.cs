
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IStatusPagamentoAppServices
    {
        StatusPagamento InsertStatusPagamento(StatusPagamento objStatusPagamento);
        bool UpdateStatusPagamento(StatusPagamento objStatusPagamento);
        bool AtivarStatusPagamento(int SPG_Id);
        bool DeletarStatusPagamento(int SPG_Id);
        StatusPagamento GetStatusPagamentoById(int SPG_Id, bool join);
        IEnumerable<StatusPagamento> GetAllStatusPagamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<StatusPagamento> GetAllStatusPagamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<StatusPagamento> GetAllStatusPagamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
