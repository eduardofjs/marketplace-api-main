
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class MenuServices : IMenuServices
    {
        private readonly IMenuRepository _MenuRepo;

        public MenuServices(IMenuRepository MenuRepo)
        {
            _MenuRepo = MenuRepo;
        }
		
        public Menu InsertMenu(Menu objMenu)
        {
            return _MenuRepo.InsertMenu(objMenu);
        }

        public bool UpdateMenu(Menu objMenu)
        {
            return _MenuRepo.UpdateMenu(objMenu);
        }

        public bool AtivarMenu(int MEN_Id)
        {
            return _MenuRepo.AtivarMenu(MEN_Id);
        }

        public bool DeletarMenu(int MEN_Id)
        {
            return _MenuRepo.DeletarMenu(MEN_Id);
        }
        
        public Menu GetMenuById(int MEN_Id, bool join)
        {
            return _MenuRepo.GetMenuById(MEN_Id, join);
        }

        public IEnumerable<Menu> GetAllMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MenuRepo.GetAllMenu(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Menu> GetAllMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MenuRepo.GetAllMenuByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Menu> GetAllMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MenuRepo.GetAllMenuByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

