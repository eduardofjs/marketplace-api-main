
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class MeioTransporteAppServices : IMeioTransporteAppServices
    {
        private readonly IMeioTransporteServices _MeioTransporteServices;


        public MeioTransporteAppServices(IMeioTransporteServices MeioTransporteServices)
        {
            _MeioTransporteServices = MeioTransporteServices;

        }

        public MeioTransporte InsertMeioTransporte(MeioTransporte objMeioTransporte)
        {


            return _MeioTransporteServices.InsertMeioTransporte(objMeioTransporte);
        }

        public bool UpdateMeioTransporte(MeioTransporte objMeioTransporte)
        {

            return _MeioTransporteServices.UpdateMeioTransporte(objMeioTransporte);
        }

        public bool AtivarMeioTransporte(int MTR_Id)
        {
            return _MeioTransporteServices.AtivarMeioTransporte(MTR_Id);
        }

        public bool DeletarMeioTransporte(int MTR_Id)
        {
            return _MeioTransporteServices.DeletarMeioTransporte(MTR_Id);
        }

        public MeioTransporte GetMeioTransporteById(int MTR_Id, bool join)
        {
            return _MeioTransporteServices.GetMeioTransporteById(MTR_Id, join);
        }

        public IEnumerable<MeioTransporte> GetAllMeioTransporte(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MeioTransporteServices.GetAllMeioTransporte(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<MeioTransporte> GetAllMeioTransporteByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MeioTransporteServices.GetAllMeioTransporteByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<MeioTransporte> GetAllMeioTransporteByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MeioTransporteServices.GetAllMeioTransporteByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

