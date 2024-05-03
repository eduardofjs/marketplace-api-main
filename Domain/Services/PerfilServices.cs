
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class PerfilServices : IPerfilServices
    {
        private readonly IPerfilRepository _PerfilRepo;

        public PerfilServices(IPerfilRepository PerfilRepo)
        {
            _PerfilRepo = PerfilRepo;
        }
		
        public Perfil InsertPerfil(Perfil objPerfil)
        {
            return _PerfilRepo.InsertPerfil(objPerfil);
        }

        public bool UpdatePerfil(Perfil objPerfil)
        {
            return _PerfilRepo.UpdatePerfil(objPerfil);
        }

        public bool AtivarPerfil(int PRF_Id)
        {
            return _PerfilRepo.AtivarPerfil(PRF_Id);
        }

        public bool DeletarPerfil(int PRF_Id)
        {
            return _PerfilRepo.DeletarPerfil(PRF_Id);
        }
        
        public Perfil GetPerfilById(int PRF_Id, bool join)
        {
            return _PerfilRepo.GetPerfilById(PRF_Id, join);
        }

        public IEnumerable<Perfil> GetAllPerfil(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilRepo.GetAllPerfil(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Perfil> GetAllPerfilByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilRepo.GetAllPerfilByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Perfil> GetAllPerfilByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilRepo.GetAllPerfilByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

