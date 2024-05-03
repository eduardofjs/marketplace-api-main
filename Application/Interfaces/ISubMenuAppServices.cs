
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ISubMenuAppServices
    {
        SubMenu InsertSubMenu(SubMenu objSubMenu);
        bool UpdateSubMenu(SubMenu objSubMenu);
        bool AtivarSubMenu(int SBM_Id);
        bool DeletarSubMenu(int SBM_Id);
        SubMenu GetSubMenuById(int SBM_Id, bool join);
        IEnumerable<SubMenu> GetAllSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<SubMenu> GetAllSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<SubMenu> GetAllSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
