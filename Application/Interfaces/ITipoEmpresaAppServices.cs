
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ITipoEmpresaAppServices
    {
        TipoEmpresa InsertTipoEmpresa(TipoEmpresa objTipoEmpresa);
        bool UpdateTipoEmpresa(TipoEmpresa objTipoEmpresa);
        bool AtivarTipoEmpresa(int TEM_Id);
        bool DeletarTipoEmpresa(int TEM_Id);
        TipoEmpresa GetTipoEmpresaById(int TEM_Id, bool join);
        IEnumerable<TipoEmpresa> GetAllTipoEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoEmpresa> GetAllTipoEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoEmpresa> GetAllTipoEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
