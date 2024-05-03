
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class PerfilxSubMenuAppServices : IPerfilxSubMenuAppServices
    {
        private readonly IPerfilxSubMenuServices _PerfilxSubMenuServices;
         private readonly ISubMenuServices _SubMenuServices;
        private readonly IPerfilServices _PerfilServices;
           

        public PerfilxSubMenuAppServices(IPerfilxSubMenuServices PerfilxSubMenuServices  , ISubMenuServices SubMenuServices, IPerfilServices PerfilServices   )
        {
            _PerfilxSubMenuServices = PerfilxSubMenuServices;
             _SubMenuServices = SubMenuServices;
            _PerfilServices = PerfilServices;
             
        }

        public PerfilxSubMenu InsertPerfilxSubMenu(PerfilxSubMenu objPerfilxSubMenu)
        {
             if (objPerfilxSubMenu.SubMenu != null)
            {
                objPerfilxSubMenu.SubMenu = _SubMenuServices.InsertSubMenu(objPerfilxSubMenu.SubMenu);
                objPerfilxSubMenu.PXS_SubMenuId = objPerfilxSubMenu.SubMenu.SBM_Id;
            }
            if (objPerfilxSubMenu.Perfil != null)
            {
                objPerfilxSubMenu.Perfil = _PerfilServices.InsertPerfil(objPerfilxSubMenu.Perfil);
                objPerfilxSubMenu.PXS_PerfilId = objPerfilxSubMenu.Perfil.PRF_Id;
            }
               
            
            return _PerfilxSubMenuServices.InsertPerfilxSubMenu(objPerfilxSubMenu);
        }

        public bool UpdatePerfilxSubMenu(PerfilxSubMenu objPerfilxSubMenu)
        {            
             if (objPerfilxSubMenu.SubMenu != null)
            {
                if (objPerfilxSubMenu.SubMenu.SBM_Id == 0)
                {
                    objPerfilxSubMenu.SubMenu = _SubMenuServices.InsertSubMenu(objPerfilxSubMenu.SubMenu);
                    objPerfilxSubMenu.PXS_SubMenuId = objPerfilxSubMenu.SubMenu.SBM_Id;
                }
                else
                {
                    bool flagSubMenu = _SubMenuServices.UpdateSubMenu(objPerfilxSubMenu.SubMenu);
                }
            }
            if (objPerfilxSubMenu.Perfil != null)
            {
                if (objPerfilxSubMenu.Perfil.PRF_Id == 0)
                {
                    objPerfilxSubMenu.Perfil = _PerfilServices.InsertPerfil(objPerfilxSubMenu.Perfil);
                    objPerfilxSubMenu.PXS_PerfilId = objPerfilxSubMenu.Perfil.PRF_Id;
                }
                else
                {
                    bool flagPerfil = _PerfilServices.UpdatePerfil(objPerfilxSubMenu.Perfil);
                }
            }
              
            return _PerfilxSubMenuServices.UpdatePerfilxSubMenu(objPerfilxSubMenu);
        }

        public bool AtivarPerfilxSubMenu(int PXS_Id)
        {
            return _PerfilxSubMenuServices.AtivarPerfilxSubMenu(PXS_Id);
        }

        public bool DeletarPerfilxSubMenu(int PXS_SubMenuId, int PXS_PerfilId)
        {
            return _PerfilxSubMenuServices.DeletarPerfilxSubMenu(PXS_SubMenuId, PXS_PerfilId);
        }

        public PerfilxSubMenu GetPerfilxSubMenuById(int PXS_Id, bool join)
        {
            return _PerfilxSubMenuServices.GetPerfilxSubMenuById(PXS_Id, join);
        }

        public IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxSubMenuServices.GetAllPerfilxSubMenu(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxSubMenuServices.GetAllPerfilxSubMenuByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxSubMenuServices.GetAllPerfilxSubMenuByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

