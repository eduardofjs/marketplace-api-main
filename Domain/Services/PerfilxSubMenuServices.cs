
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class PerfilxSubMenuServices : IPerfilxSubMenuServices
    {
        private readonly IPerfilxSubMenuRepository _PerfilxSubMenuRepo;

        public PerfilxSubMenuServices(IPerfilxSubMenuRepository PerfilxSubMenuRepo)
        {
            _PerfilxSubMenuRepo = PerfilxSubMenuRepo;
        }
		
        public PerfilxSubMenu InsertPerfilxSubMenu(PerfilxSubMenu objPerfilxSubMenu)
        {
            return _PerfilxSubMenuRepo.InsertPerfilxSubMenu(objPerfilxSubMenu);
        }

        public bool UpdatePerfilxSubMenu(PerfilxSubMenu objPerfilxSubMenu)
        {
            return _PerfilxSubMenuRepo.UpdatePerfilxSubMenu(objPerfilxSubMenu);
        }

        public bool AtivarPerfilxSubMenu(int PXS_Id)
        {
            return _PerfilxSubMenuRepo.AtivarPerfilxSubMenu(PXS_Id);
        }

        public bool DeletarPerfilxSubMenu(int PXS_SubMenuId, int PXS_PerfilId)
        {
            return _PerfilxSubMenuRepo.DeletarPerfilxSubMenu(PXS_SubMenuId, PXS_PerfilId);
        }
        
        public PerfilxSubMenu GetPerfilxSubMenuById(int PXS_Id, bool join)
        {
            return _PerfilxSubMenuRepo.GetPerfilxSubMenuById(PXS_Id, join);
        }

        public IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxSubMenuRepo.GetAllPerfilxSubMenu(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxSubMenuRepo.GetAllPerfilxSubMenuByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxSubMenuRepo.GetAllPerfilxSubMenuByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

