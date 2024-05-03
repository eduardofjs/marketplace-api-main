
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class MenuAppServices : IMenuAppServices
    {
        private readonly IMenuServices _MenuServices;
                 

        public MenuAppServices(IMenuServices MenuServices          )
        {
            _MenuServices = MenuServices;
                   
        }

        public Menu InsertMenu(Menu objMenu)
        {
                     
            
            return _MenuServices.InsertMenu(objMenu);
        }

        public bool UpdateMenu(Menu objMenu)
        {            
                    
            return _MenuServices.UpdateMenu(objMenu);
        }

        public bool AtivarMenu(int MEN_Id)
        {
            return _MenuServices.AtivarMenu(MEN_Id);
        }

        public bool DeletarMenu(int MEN_Id)
        {
            return _MenuServices.DeletarMenu(MEN_Id);
        }

        public Menu GetMenuById(int MEN_Id, bool join)
        {
            return _MenuServices.GetMenuById(MEN_Id, join);
        }

        public IEnumerable<Menu> GetAllMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MenuServices.GetAllMenu(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Menu> GetAllMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MenuServices.GetAllMenuByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Menu> GetAllMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MenuServices.GetAllMenuByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

