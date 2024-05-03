
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IEmpresaServices
    {
        Empresa InsertEmpresa(Empresa objEmpresa);
        bool UpdateEmpresa(Empresa objEmpresa);
        bool AtivarEmpresa(int EMP_Id);
        bool DeletarEmpresa(int EMP_Id);
        Empresa GetEmpresaById(int EMP_Id, bool join);
        IEnumerable<Empresa> GetAllEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Empresa> GetAllEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Empresa> GetAllEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        bool AprovarEmpresa(int EMP_Id);
        bool ReprovarEmpresa(int EMP_Id);
    }
}
