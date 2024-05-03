
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPerfilxSubMenuServices
    {
        PerfilxSubMenu InsertPerfilxSubMenu(PerfilxSubMenu objPerfilxSubMenu);
        bool UpdatePerfilxSubMenu(PerfilxSubMenu objPerfilxSubMenu);
        bool AtivarPerfilxSubMenu(int PXS_Id);
        bool DeletarPerfilxSubMenu(int PXS_SubMenuId, int PXS_PerfilId);
        PerfilxSubMenu GetPerfilxSubMenuById(int PXS_Id, bool join);
        IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
