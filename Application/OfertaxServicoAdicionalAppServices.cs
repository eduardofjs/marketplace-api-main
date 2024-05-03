using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class OfertaxServicoAdicionalAppServices : IOfertaxServicoAdicionalAppServices
    {
        private readonly IOfertaxServicoAdicionalServices _OfertaxServicoAdicionalServices;


        public OfertaxServicoAdicionalAppServices(IOfertaxServicoAdicionalServices OfertaxServicoAdicionalServices)
        {
            _OfertaxServicoAdicionalServices = OfertaxServicoAdicionalServices;

        }

        public OfertaxServicoAdicional InsertOfertaxServicoAdicional(OfertaxServicoAdicional objOfertaxServicoAdicional)
        {


            return _OfertaxServicoAdicionalServices.InsertOfertaxServicoAdicional(objOfertaxServicoAdicional);
        }

        public bool UpdateOfertaxServicoAdicional(OfertaxServicoAdicional objOfertaxServicoAdicional)
        {

            return _OfertaxServicoAdicionalServices.UpdateOfertaxServicoAdicional(objOfertaxServicoAdicional);
        }

        public bool AtivarOfertaxServicoAdicional(int OXA_Id)
        {
            return _OfertaxServicoAdicionalServices.AtivarOfertaxServicoAdicional(OXA_Id);
        }

        public bool DeletarOfertaxServicoAdicional(int OXA_Id)
        {
            return _OfertaxServicoAdicionalServices.DeletarOfertaxServicoAdicional(OXA_Id);
        }

        public OfertaxServicoAdicional GetOfertaxServicoAdicionalById(int OXA_Id, bool join)
        {
            return _OfertaxServicoAdicionalServices.GetOfertaxServicoAdicionalById(OXA_Id, join);
        }

        public IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoAdicionalServices.GetAllOfertaxServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoAdicionalServices.GetAllOfertaxServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoAdicionalServices.GetAllOfertaxServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

