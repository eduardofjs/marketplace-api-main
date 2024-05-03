using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IEmpresaxServicoFinanceiroServices
    {
        EmpresaxServicoFinanceiro InsertEmpresaxServicoFinanceiro(EmpresaxServicoFinanceiro objEmpresaxServicoFinanceiro);
        bool UpdateEmpresaxServicoFinanceiro(EmpresaxServicoFinanceiro objEmpresaxServicoFinanceiro);
        bool AtivarEmpresaxServicoFinanceiro(int ESF_Id);
        bool DeletarEmpresaxServicoFinanceiro(int ESF_Id);
        bool DeletarEmpresaxServicoFinanceiroByEmpresa(int ESF_EmpresaId);
        EmpresaxServicoFinanceiro GetEmpresaxServicoFinanceiroById(int ESF_Id, bool join);
        IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
