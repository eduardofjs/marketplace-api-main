
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IStatusProdutoServices
    {
        StatusProduto InsertStatusProduto(StatusProduto objStatusProduto);
        bool UpdateStatusProduto(StatusProduto objStatusProduto);
        bool AtivarStatusProduto(int SPR_Id);
        bool DeletarStatusProduto(int SPR_Id);
        StatusProduto GetStatusProdutoById(int SPR_Id, bool join);
        IEnumerable<StatusProduto> GetAllStatusProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<StatusProduto> GetAllStatusProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<StatusProduto> GetAllStatusProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
