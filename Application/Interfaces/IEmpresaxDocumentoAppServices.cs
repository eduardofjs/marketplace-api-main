using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IEmpresaxDocumentoAppServices
    {
        EmpresaxDocumento InsertEmpresaxDocumento(EmpresaxDocumento objEmpresaxDocumento);
        bool UpdateEmpresaxDocumento(EmpresaxDocumento objEmpresaxDocumento);
        bool AtivarEmpresaxDocumento(int EXD_Id);
        bool DeletarEmpresaxDocumento(int EXD_Id);
        bool DeletarEmpresaxDocumentoByEmpresa(int EXD_EmpresaId);
        EmpresaxDocumento GetEmpresaxDocumentoById(int EXD_Id, bool join);
        IEnumerable<EmpresaxDocumento> GetAllEmpresaxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxDocumento> GetAllEmpresaxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<EmpresaxDocumento> GetAllEmpresaxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
