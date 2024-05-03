
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class EstadoServices : IEstadoServices
    {
        private readonly IEstadoRepository _EstadoRepo;

        public EstadoServices(IEstadoRepository EstadoRepo)
        {
            _EstadoRepo = EstadoRepo;
        }
		
        public Estado InsertEstado(Estado objEstado)
        {
            return _EstadoRepo.InsertEstado(objEstado);
        }

        public bool UpdateEstado(Estado objEstado)
        {
            return _EstadoRepo.UpdateEstado(objEstado);
        }

        public bool AtivarEstado(int ESD_Id)
        {
            return _EstadoRepo.AtivarEstado(ESD_Id);
        }

        public bool DeletarEstado(int ESD_Id)
        {
            return _EstadoRepo.DeletarEstado(ESD_Id);
        }
        
        public Estado GetEstadoById(int ESD_Id, bool join)
        {
            return _EstadoRepo.GetEstadoById(ESD_Id, join);
        }

        public IEnumerable<Estado> GetAllEstado(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EstadoRepo.GetAllEstado(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Estado> GetAllEstadoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EstadoRepo.GetAllEstadoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Estado> GetAllEstadoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EstadoRepo.GetAllEstadoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

