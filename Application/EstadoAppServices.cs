
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class EstadoAppServices : IEstadoAppServices
    {
        private readonly IEstadoServices _EstadoServices;
              

        public EstadoAppServices(IEstadoServices EstadoServices       )
        {
            _EstadoServices = EstadoServices;
                
        }

        public Estado InsertEstado(Estado objEstado)
        {
                  
            
            return _EstadoServices.InsertEstado(objEstado);
        }

        public bool UpdateEstado(Estado objEstado)
        {            
                 
            return _EstadoServices.UpdateEstado(objEstado);
        }

        public bool AtivarEstado(int ESD_Id)
        {
            return _EstadoServices.AtivarEstado(ESD_Id);
        }

        public bool DeletarEstado(int ESD_Id)
        {
            return _EstadoServices.DeletarEstado(ESD_Id);
        }

        public Estado GetEstadoById(int ESD_Id, bool join)
        {
            return _EstadoServices.GetEstadoById(ESD_Id, join);
        }

        public IEnumerable<Estado> GetAllEstado(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EstadoServices.GetAllEstado(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Estado> GetAllEstadoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EstadoServices.GetAllEstadoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Estado> GetAllEstadoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EstadoServices.GetAllEstadoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

