
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class MeioTransporteServices : IMeioTransporteServices
    {
        private readonly IMeioTransporteRepository _MeioTransporteRepo;

        public MeioTransporteServices(IMeioTransporteRepository MeioTransporteRepo)
        {
            _MeioTransporteRepo = MeioTransporteRepo;
        }

        public MeioTransporte InsertMeioTransporte(MeioTransporte objMeioTransporte)
        {
            return _MeioTransporteRepo.InsertMeioTransporte(objMeioTransporte);
        }

        public bool UpdateMeioTransporte(MeioTransporte objMeioTransporte)
        {
            return _MeioTransporteRepo.UpdateMeioTransporte(objMeioTransporte);
        }

        public bool AtivarMeioTransporte(int MTR_Id)
        {
            return _MeioTransporteRepo.AtivarMeioTransporte(MTR_Id);
        }

        public bool DeletarMeioTransporte(int MTR_Id)
        {
            return _MeioTransporteRepo.DeletarMeioTransporte(MTR_Id);
        }

        public MeioTransporte GetMeioTransporteById(int MTR_Id, bool join)
        {
            return _MeioTransporteRepo.GetMeioTransporteById(MTR_Id, join);
        }

        public IEnumerable<MeioTransporte> GetAllMeioTransporte(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MeioTransporteRepo.GetAllMeioTransporte(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<MeioTransporte> GetAllMeioTransporteByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MeioTransporteRepo.GetAllMeioTransporteByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<MeioTransporte> GetAllMeioTransporteByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _MeioTransporteRepo.GetAllMeioTransporteByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

