
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class PerfilAppServices : IPerfilAppServices
    {
        private readonly IPerfilServices _PerfilServices;
               

        public PerfilAppServices(IPerfilServices PerfilServices        )
        {
            _PerfilServices = PerfilServices;
                 
        }

        public Perfil InsertPerfil(Perfil objPerfil)
        {
                   
            
            return _PerfilServices.InsertPerfil(objPerfil);
        }

        public bool UpdatePerfil(Perfil objPerfil)
        {            
                  
            return _PerfilServices.UpdatePerfil(objPerfil);
        }

        public bool AtivarPerfil(int PRF_Id)
        {
            return _PerfilServices.AtivarPerfil(PRF_Id);
        }

        public bool DeletarPerfil(int PRF_Id)
        {
            return _PerfilServices.DeletarPerfil(PRF_Id);
        }

        public Perfil GetPerfilById(int PRF_Id, bool join)
        {
            return _PerfilServices.GetPerfilById(PRF_Id, join);
        }

        public IEnumerable<Perfil> GetAllPerfil(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilServices.GetAllPerfil(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Perfil> GetAllPerfilByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilServices.GetAllPerfilByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Perfil> GetAllPerfilByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PerfilServices.GetAllPerfilByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

