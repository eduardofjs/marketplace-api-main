
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class SubMenuAppServices : ISubMenuAppServices
    {
        private readonly ISubMenuServices _SubMenuServices;
         private readonly IMenuServices _MenuServices;
                  

        public SubMenuAppServices(ISubMenuServices SubMenuServices  , IMenuServices MenuServices          )
        {
            _SubMenuServices = SubMenuServices;
             _MenuServices = MenuServices;
                    
        }

        public SubMenu InsertSubMenu(SubMenu objSubMenu)
        {
             if (objSubMenu.Menu != null)
            {
                objSubMenu.Menu = _MenuServices.InsertMenu(objSubMenu.Menu);
                objSubMenu.SBM_MenuId = objSubMenu.Menu.MEN_Id;
            }
                      
            
            return _SubMenuServices.InsertSubMenu(objSubMenu);
        }

        public bool UpdateSubMenu(SubMenu objSubMenu)
        {            
             if (objSubMenu.Menu != null)
            {
                if (objSubMenu.Menu.MEN_Id == 0)
                {
                    objSubMenu.Menu = _MenuServices.InsertMenu(objSubMenu.Menu);
                    objSubMenu.SBM_MenuId = objSubMenu.Menu.MEN_Id;
                }
                else
                {
                    bool flagMenu = _MenuServices.UpdateMenu(objSubMenu.Menu);
                }
            }
                     
            return _SubMenuServices.UpdateSubMenu(objSubMenu);
        }

        public bool AtivarSubMenu(int SBM_Id)
        {
            return _SubMenuServices.AtivarSubMenu(SBM_Id);
        }

        public bool DeletarSubMenu(int SBM_Id)
        {
            return _SubMenuServices.DeletarSubMenu(SBM_Id);
        }

        public SubMenu GetSubMenuById(int SBM_Id, bool join)
        {
            return _SubMenuServices.GetSubMenuById(SBM_Id, join);
        }

        public IEnumerable<SubMenu> GetAllSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SubMenuServices.GetAllSubMenu(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<SubMenu> GetAllSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SubMenuServices.GetAllSubMenuByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<SubMenu> GetAllSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SubMenuServices.GetAllSubMenuByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

