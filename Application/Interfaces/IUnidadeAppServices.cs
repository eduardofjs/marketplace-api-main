
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IUnidadeAppServices
    {
        Unidade InsertUnidade(Unidade objUnidade);
        bool UpdateUnidade(Unidade objUnidade);
        bool AtivarUnidade(int UNI_Id);
        bool DeletarUnidade(int UNI_Id);
        Unidade GetUnidadeById(int UNI_Id, bool join);
        IEnumerable<Unidade> GetAllUnidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Unidade> GetAllUnidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Unidade> GetAllUnidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
