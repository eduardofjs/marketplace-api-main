using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IServicoFinanceiroServices
    {
        ServicoFinanceiro InsertServicoFinanceiro(ServicoFinanceiro objServicoFinanceiro);
        bool UpdateServicoFinanceiro(ServicoFinanceiro objServicoFinanceiro);
        bool AtivarServicoFinanceiro(int SEF_Id);
        bool DeletarServicoFinanceiro(int SEF_Id);
        ServicoFinanceiro GetServicoFinanceiroById(int SEF_Id, bool join);
        IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
