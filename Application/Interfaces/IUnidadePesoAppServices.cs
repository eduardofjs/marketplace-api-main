
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IUnidadePesoAppServices
    {
        UnidadePeso InsertUnidadePeso(UnidadePeso objUnidadePeso);
        bool UpdateUnidadePeso(UnidadePeso objUnidadePeso);
        bool AtivarUnidadePeso(int UNP_Id);
        bool DeletarUnidadePeso(int UNP_Id);
        UnidadePeso GetUnidadePesoById(int UNP_Id, bool join);
        IEnumerable<UnidadePeso> GetAllUnidadePeso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<UnidadePeso> GetAllUnidadePesoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<UnidadePeso> GetAllUnidadePesoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
