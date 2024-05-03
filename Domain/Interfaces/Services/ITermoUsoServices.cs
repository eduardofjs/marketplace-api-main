
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface ITermoUsoServices
    {
        TermoUso InsertTermoUso(TermoUso objTermoUso);
        bool UpdateTermoUso(TermoUso objTermoUso);
        bool AtivarTermoUso(int TRU_Id);
        bool DeletarTermoUso(int TRU_Id);
        TermoUso GetTermoUsoById(int TRU_Id, bool join);
        IEnumerable<TermoUso> GetAllTermoUso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TermoUso> GetAllTermoUsoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TermoUso> GetAllTermoUsoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
