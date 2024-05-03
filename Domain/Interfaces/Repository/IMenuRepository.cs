
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IMenuRepository
    {
        Menu InsertMenu(Menu objMenu);
        bool UpdateMenu(Menu objMenu);
        bool AtivarMenu(int MEN_Id);
        bool DeletarMenu(int MEN_Id);
        Menu GetMenuById(int MEN_Id, bool join);
        IEnumerable<Menu> GetAllMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Menu> GetAllMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Menu> GetAllMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
