
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface ICidadeRepository
    {
        Cidade InsertCidade(Cidade objCidade);
        bool UpdateCidade(Cidade objCidade);
        bool AtivarCidade(int CDD_Id);
        bool DeletarCidade(int CDD_Id);
        Cidade GetCidadeById(int CDD_Id, bool join);
        IEnumerable<Cidade> GetAllCidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Cidade> GetAllCidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Cidade> GetAllCidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
