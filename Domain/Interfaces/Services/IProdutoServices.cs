
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IProdutoServices
    {
        Produto InsertProduto(Produto objProduto);
        bool UpdateProduto(Produto objProduto);
        bool AtivarProduto(int PDT_Id);
        bool DeletarProduto(int PDT_Id);
        Produto GetProdutoById(int PDT_Id, bool join);
        IEnumerable<Produto> GetAllProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Produto> GetAllProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Produto> GetAllProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
