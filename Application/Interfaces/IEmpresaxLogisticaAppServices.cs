using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IEmpresaxLogisticaAppServices
    {
        EmpresaxLogistica InsertEmpresaxLogistica(EmpresaxLogistica objEmpresaxLogistica);
        bool UpdateEmpresaxLogistica(EmpresaxLogistica objEmpresaxLogistica);
        bool AtivarEmpresaxLogistica(int EXL_Id);
        bool DeletarEmpresaxLogistica(int EXL_Id);
        bool DeletarEmpresaxLogisticaByEmpresa(int EXL_EmpresaId);
        EmpresaxLogistica GetEmpresaxLogisticaById(int EXL_Id, bool join);
        IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogistica(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogisticaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogisticaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
