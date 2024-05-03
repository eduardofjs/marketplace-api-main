
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class UnidadePesoServices : IUnidadePesoServices
    {
        private readonly IUnidadePesoRepository _UnidadePesoRepo;

        public UnidadePesoServices(IUnidadePesoRepository UnidadePesoRepo)
        {
            _UnidadePesoRepo = UnidadePesoRepo;
        }

        public UnidadePeso InsertUnidadePeso(UnidadePeso objUnidadePeso)
        {
            return _UnidadePesoRepo.InsertUnidadePeso(objUnidadePeso);
        }

        public bool UpdateUnidadePeso(UnidadePeso objUnidadePeso)
        {
            return _UnidadePesoRepo.UpdateUnidadePeso(objUnidadePeso);
        }

        public bool AtivarUnidadePeso(int UNP_Id)
        {
            return _UnidadePesoRepo.AtivarUnidadePeso(UNP_Id);
        }

        public bool DeletarUnidadePeso(int UNP_Id)
        {
            return _UnidadePesoRepo.DeletarUnidadePeso(UNP_Id);
        }

        public UnidadePeso GetUnidadePesoById(int UNP_Id, bool join)
        {
            return _UnidadePesoRepo.GetUnidadePesoById(UNP_Id, join);
        }

        public IEnumerable<UnidadePeso> GetAllUnidadePeso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadePesoRepo.GetAllUnidadePeso(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<UnidadePeso> GetAllUnidadePesoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadePesoRepo.GetAllUnidadePesoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<UnidadePeso> GetAllUnidadePesoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadePesoRepo.GetAllUnidadePesoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

