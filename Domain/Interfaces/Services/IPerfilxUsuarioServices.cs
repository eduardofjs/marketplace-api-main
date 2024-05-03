
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPerfilxUsuarioServices
    {
        PerfilxUsuario InsertPerfilxUsuario(PerfilxUsuario objPerfilxUsuario);
        bool UpdatePerfilxUsuario(PerfilxUsuario objPerfilxUsuario);
        bool AtivarPerfilxUsuario(int PXU_Id);
        bool DeletarPerfilxUsuario(int PXU_PerfilId, int PXU_UsuarioId);
        PerfilxUsuario GetPerfilxUsuarioById(int PXU_Id, bool join);
        IEnumerable<PerfilxUsuario> GetAllPerfilxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PerfilxUsuario> GetAllPerfilxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PerfilxUsuario> GetAllPerfilxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        bool ListasPerfilxUsuario(List<PerfilxUsuario> lista);
    }
}
