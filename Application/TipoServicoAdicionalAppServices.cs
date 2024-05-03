
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TipoServicoAdicionalAppServices : ITipoServicoAdicionalAppServices
    {
        private readonly ITipoServicoAdicionalServices _TipoServicoAdicionalServices;


        public TipoServicoAdicionalAppServices(ITipoServicoAdicionalServices TipoServicoAdicionalServices)
        {
            _TipoServicoAdicionalServices = TipoServicoAdicionalServices;

        }

        public TipoServicoAdicional InsertTipoServicoAdicional(TipoServicoAdicional objTipoServicoAdicional)
        {


            return _TipoServicoAdicionalServices.InsertTipoServicoAdicional(objTipoServicoAdicional);
        }

        public bool UpdateTipoServicoAdicional(TipoServicoAdicional objTipoServicoAdicional)
        {

            return _TipoServicoAdicionalServices.UpdateTipoServicoAdicional(objTipoServicoAdicional);
        }

        public bool AtivarTipoServicoAdicional(int TSA_Id)
        {
            return _TipoServicoAdicionalServices.AtivarTipoServicoAdicional(TSA_Id);
        }

        public bool DeletarTipoServicoAdicional(int TSA_Id)
        {
            return _TipoServicoAdicionalServices.DeletarTipoServicoAdicional(TSA_Id);
        }

        public TipoServicoAdicional GetTipoServicoAdicionalById(int TSA_Id, bool join)
        {
            return _TipoServicoAdicionalServices.GetTipoServicoAdicionalById(TSA_Id, join);
        }

        public IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoServicoAdicionalServices.GetAllTipoServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoServicoAdicionalServices.GetAllTipoServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoServicoAdicionalServices.GetAllTipoServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

