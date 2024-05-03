
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TipoLogisticoPortoAppServices : ITipoLogisticoPortoAppServices
    {
        private readonly ITipoLogisticoPortoServices _TipoLogisticoPortoServices;


        public TipoLogisticoPortoAppServices(ITipoLogisticoPortoServices TipoLogisticoPortoServices)
        {
            _TipoLogisticoPortoServices = TipoLogisticoPortoServices;

        }

        public TipoLogisticoPorto InsertTipoLogisticoPorto(TipoLogisticoPorto objTipoLogisticoPorto)
        {


            return _TipoLogisticoPortoServices.InsertTipoLogisticoPorto(objTipoLogisticoPorto);
        }

        public bool UpdateTipoLogisticoPorto(TipoLogisticoPorto objTipoLogisticoPorto)
        {

            return _TipoLogisticoPortoServices.UpdateTipoLogisticoPorto(objTipoLogisticoPorto);
        }

        public bool AtivarTipoLogisticoPorto(int TLP_Id)
        {
            return _TipoLogisticoPortoServices.AtivarTipoLogisticoPorto(TLP_Id);
        }

        public bool DeletarTipoLogisticoPorto(int TLP_Id)
        {
            return _TipoLogisticoPortoServices.DeletarTipoLogisticoPorto(TLP_Id);
        }

        public TipoLogisticoPorto GetTipoLogisticoPortoById(int TLP_Id, bool join)
        {
            return _TipoLogisticoPortoServices.GetTipoLogisticoPortoById(TLP_Id, join);
        }

        public IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPorto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoPortoServices.GetAllTipoLogisticoPorto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPortoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoPortoServices.GetAllTipoLogisticoPortoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPortoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoPortoServices.GetAllTipoLogisticoPortoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

