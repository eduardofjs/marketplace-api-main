
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class UnidadePesoAppServices : IUnidadePesoAppServices
    {
        private readonly IUnidadePesoServices _UnidadePesoServices;


        public UnidadePesoAppServices(IUnidadePesoServices UnidadePesoServices)
        {
            _UnidadePesoServices = UnidadePesoServices;

        }

        public UnidadePeso InsertUnidadePeso(UnidadePeso objUnidadePeso)
        {


            return _UnidadePesoServices.InsertUnidadePeso(objUnidadePeso);
        }

        public bool UpdateUnidadePeso(UnidadePeso objUnidadePeso)
        {

            return _UnidadePesoServices.UpdateUnidadePeso(objUnidadePeso);
        }

        public bool AtivarUnidadePeso(int UNP_Id)
        {
            return _UnidadePesoServices.AtivarUnidadePeso(UNP_Id);
        }

        public bool DeletarUnidadePeso(int UNP_Id)
        {
            return _UnidadePesoServices.DeletarUnidadePeso(UNP_Id);
        }

        public UnidadePeso GetUnidadePesoById(int UNP_Id, bool join)
        {
            return _UnidadePesoServices.GetUnidadePesoById(UNP_Id, join);
        }

        public IEnumerable<UnidadePeso> GetAllUnidadePeso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadePesoServices.GetAllUnidadePeso(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<UnidadePeso> GetAllUnidadePesoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadePesoServices.GetAllUnidadePesoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<UnidadePeso> GetAllUnidadePesoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadePesoServices.GetAllUnidadePesoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

