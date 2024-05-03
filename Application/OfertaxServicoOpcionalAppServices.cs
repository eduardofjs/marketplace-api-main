using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class OfertaxServicoOpcionalAppServices : IOfertaxServicoOpcionalAppServices
    {
        private readonly IOfertaxServicoOpcionalServices _OfertaxServicoOpcionalServices;


        public OfertaxServicoOpcionalAppServices(IOfertaxServicoOpcionalServices OfertaxServicoOpcionalServices)
        {
            _OfertaxServicoOpcionalServices = OfertaxServicoOpcionalServices;

        }

        public OfertaxServicoOpcional InsertOfertaxServicoOpcional(OfertaxServicoOpcional objOfertaxServicoOpcional)
        {


            return _OfertaxServicoOpcionalServices.InsertOfertaxServicoOpcional(objOfertaxServicoOpcional);
        }

        public bool UpdateOfertaxServicoOpcional(OfertaxServicoOpcional objOfertaxServicoOpcional)
        {

            return _OfertaxServicoOpcionalServices.UpdateOfertaxServicoOpcional(objOfertaxServicoOpcional);
        }

        public bool AtivarOfertaxServicoOpcional(int OXS_Id)
        {
            return _OfertaxServicoOpcionalServices.AtivarOfertaxServicoOpcional(OXS_Id);
        }

        public bool DeletarOfertaxServicoOpcional(int OXS_Id)
        {
            return _OfertaxServicoOpcionalServices.DeletarOfertaxServicoOpcional(OXS_Id);
        }

        public OfertaxServicoOpcional GetOfertaxServicoOpcionalById(int OXS_Id, bool join)
        {
            return _OfertaxServicoOpcionalServices.GetOfertaxServicoOpcionalById(OXS_Id, join);
        }

        public IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoOpcionalServices.GetAllOfertaxServicoOpcional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoOpcionalServices.GetAllOfertaxServicoOpcionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxServicoOpcionalServices.GetAllOfertaxServicoOpcionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

