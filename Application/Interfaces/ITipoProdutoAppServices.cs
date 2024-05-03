
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ITipoProdutoAppServices
    {
        TipoProduto InsertTipoProduto(TipoProduto objTipoProduto);
        bool UpdateTipoProduto(TipoProduto objTipoProduto);
        bool AtivarTipoProduto(int TPR_Id);
        bool DeletarTipoProduto(int TPR_Id);
        TipoProduto GetTipoProdutoById(int TPR_Id, bool join);
        IEnumerable<TipoProduto> GetAllTipoProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoProduto> GetAllTipoProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoProduto> GetAllTipoProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
