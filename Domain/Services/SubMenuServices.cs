
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class SubMenuServices : ISubMenuServices
    {
        private readonly ISubMenuRepository _SubMenuRepo;

        public SubMenuServices(ISubMenuRepository SubMenuRepo)
        {
            _SubMenuRepo = SubMenuRepo;
        }
		
        public SubMenu InsertSubMenu(SubMenu objSubMenu)
        {
            return _SubMenuRepo.InsertSubMenu(objSubMenu);
        }

        public bool UpdateSubMenu(SubMenu objSubMenu)
        {
            return _SubMenuRepo.UpdateSubMenu(objSubMenu);
        }

        public bool AtivarSubMenu(int SBM_Id)
        {
            return _SubMenuRepo.AtivarSubMenu(SBM_Id);
        }

        public bool DeletarSubMenu(int SBM_Id)
        {
            return _SubMenuRepo.DeletarSubMenu(SBM_Id);
        }
        
        public SubMenu GetSubMenuById(int SBM_Id, bool join)
        {
            return _SubMenuRepo.GetSubMenuById(SBM_Id, join);
        }

        public IEnumerable<SubMenu> GetAllSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SubMenuRepo.GetAllSubMenu(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<SubMenu> GetAllSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SubMenuRepo.GetAllSubMenuByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<SubMenu> GetAllSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SubMenuRepo.GetAllSubMenuByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

