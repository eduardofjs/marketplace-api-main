
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class PerfilxUsuarioAppServices : IPerfilxUsuarioAppServices
    {
        private readonly IPerfilxUsuarioServices _PerfilxUsuarioServices;
         private readonly IUsuarioServices _UsuarioServices;
        private readonly IPerfilServices _PerfilServices;
           

        public PerfilxUsuarioAppServices(IPerfilxUsuarioServices PerfilxUsuarioServices  , IUsuarioServices UsuarioServices, IPerfilServices PerfilServices   )
        {
            _PerfilxUsuarioServices = PerfilxUsuarioServices;
             _UsuarioServices = UsuarioServices;
            _PerfilServices = PerfilServices;
             
        }

        public PerfilxUsuario InsertPerfilxUsuario(PerfilxUsuario objPerfilxUsuario)
        {
             if (objPerfilxUsuario.Usuario != null)
            {
                objPerfilxUsuario.Usuario = _UsuarioServices.InsertUsuario(objPerfilxUsuario.Usuario);
                objPerfilxUsuario.PXU_UsuarioId = objPerfilxUsuario.Usuario.USR_Id;
            }
            if (objPerfilxUsuario.Perfil != null)
            {
                objPerfilxUsuario.Perfil = _PerfilServices.InsertPerfil(objPerfilxUsuario.Perfil);
                objPerfilxUsuario.PXU_PerfilId = objPerfilxUsuario.Perfil.PRF_Id;
            }
               
            
            return _PerfilxUsuarioServices.InsertPerfilxUsuario(objPerfilxUsuario);
        }

        public bool UpdatePerfilxUsuario(PerfilxUsuario objPerfilxUsuario)
        {            
             if (objPerfilxUsuario.Usuario != null)
            {
                if (objPerfilxUsuario.Usuario.USR_Id == 0)
                {
                    objPerfilxUsuario.Usuario = _UsuarioServices.InsertUsuario(objPerfilxUsuario.Usuario);
                    objPerfilxUsuario.PXU_UsuarioId = objPerfilxUsuario.Usuario.USR_Id;
                }
                else
                {
                    bool flagUsuario = _UsuarioServices.UpdateUsuario(objPerfilxUsuario.Usuario);
                }
            }
            if (objPerfilxUsuario.Perfil != null)
            {
                if (objPerfilxUsuario.Perfil.PRF_Id == 0)
                {
                    objPerfilxUsuario.Perfil = _PerfilServices.InsertPerfil(objPerfilxUsuario.Perfil);
                    objPerfilxUsuario.PXU_PerfilId = objPerfilxUsuario.Perfil.PRF_Id;
                }
                else
                {
                    bool flagPerfil = _PerfilServices.UpdatePerfil(objPerfilxUsuario.Perfil);
                }
            }
              
            return _PerfilxUsuarioServices.UpdatePerfilxUsuario(objPerfilxUsuario);
        }

        public bool AtivarPerfilxUsuario(int PXU_Id)
        {
            return _PerfilxUsuarioServices.AtivarPerfilxUsuario(PXU_Id);
        }

        public bool DeletarPerfilxUsuario(int PXU_PerfilId, int PXU_UsuarioId)
        {
            return _PerfilxUsuarioServices.DeletarPerfilxUsuario(PXU_PerfilId, PXU_UsuarioId);
        }

        public PerfilxUsuario GetPerfilxUsuarioById(int PXU_Id, bool join)
        {
            return _PerfilxUsuarioServices.GetPerfilxUsuarioById(PXU_Id, join);
        }

        public IEnumerable<PerfilxUsuario> GetAllPerfilxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxUsuarioServices.GetAllPerfilxUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PerfilxUsuario> GetAllPerfilxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxUsuarioServices.GetAllPerfilxUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PerfilxUsuario> GetAllPerfilxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilxUsuarioServices.GetAllPerfilxUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool ListasPerfilxUsuario(List<PerfilxUsuario> lista)
        {
            return _PerfilxUsuarioServices.ListasPerfilxUsuario(lista);
        }
    }
}

