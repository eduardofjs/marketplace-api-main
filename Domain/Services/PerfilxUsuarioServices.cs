
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class PerfilxUsuarioServices : IPerfilxUsuarioServices
    {
        private readonly IPerfilxUsuarioRepository _PerfilxUsuarioRepo;

        public PerfilxUsuarioServices(IPerfilxUsuarioRepository PerfilxUsuarioRepo)
        {
            _PerfilxUsuarioRepo = PerfilxUsuarioRepo;
        }
		
        public PerfilxUsuario InsertPerfilxUsuario(PerfilxUsuario objPerfilxUsuario)
        {
            return _PerfilxUsuarioRepo.InsertPerfilxUsuario(objPerfilxUsuario);
        }

        public bool UpdatePerfilxUsuario(PerfilxUsuario objPerfilxUsuario)
        {
            return _PerfilxUsuarioRepo.UpdatePerfilxUsuario(objPerfilxUsuario);
        }

        public bool AtivarPerfilxUsuario(int PXU_Id)
        {
            return _PerfilxUsuarioRepo.AtivarPerfilxUsuario(PXU_Id);
        }

        public bool DeletarPerfilxUsuario(int PXU_PerfilId, int PXU_UsuarioId)
        {
            return _PerfilxUsuarioRepo.DeletarPerfilxUsuario(PXU_PerfilId, PXU_UsuarioId);
        }
        
        public PerfilxUsuario GetPerfilxUsuarioById(int PXU_Id, bool join)
        {
            return _PerfilxUsuarioRepo.GetPerfilxUsuarioById(PXU_Id, join);
        }

        public IEnumerable<PerfilxUsuario> GetAllPerfilxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxUsuarioRepo.GetAllPerfilxUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PerfilxUsuario> GetAllPerfilxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxUsuarioRepo.GetAllPerfilxUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PerfilxUsuario> GetAllPerfilxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxUsuarioRepo.GetAllPerfilxUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool ListasPerfilxUsuario(List<PerfilxUsuario> lista)
        {
            return _PerfilxUsuarioRepo.ListasPerfilxUsuario(lista);
        }
    }
}

