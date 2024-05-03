using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IEmpresaxServicoAdicionalRepository
    {
        EmpresaxServicoAdicional InsertEmpresaxServicoAdicional(EmpresaxServicoAdicional objEmpresaxServicoAdicional);
        bool UpdateEmpresaxServicoAdicional(EmpresaxServicoAdicional objEmpresaxServicoAdicional);
        bool AtivarEmpresaxServicoAdicional(int ESA_Id);
        bool DeletarEmpresaxServicoAdicional(int ESA_Id);
        bool DeletarEmpresaxServicoAdicionalByEmpresa(int ESA_EmpresaId);
        EmpresaxServicoAdicional GetEmpresaxServicoAdicionalById(int ESA_Id, bool join);
        IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
