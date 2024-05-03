using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IEmpresaxProdutoRepository
    {
        EmpresaxProduto InsertEmpresaxProduto(EmpresaxProduto objEmpresaxProduto);
        bool UpdateEmpresaxProduto(EmpresaxProduto objEmpresaxProduto);
        bool AtivarEmpresaxProduto(int EXP_Id);
        bool DeletarEmpresaxProduto(int EXP_Id);
        bool DeletarEmpresaxProdutoByEmpresa(int EXP_EmpresaId);
        EmpresaxProduto GetEmpresaxProdutoById(int EXP_Id, bool join);
        IEnumerable<EmpresaxProduto> GetAllEmpresaxProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxProduto> GetAllEmpresaxProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxProduto> GetAllEmpresaxProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
