
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TipoLogisticoPortoServices : ITipoLogisticoPortoServices
    {
        private readonly ITipoLogisticoPortoRepository _TipoLogisticoPortoRepo;

        public TipoLogisticoPortoServices(ITipoLogisticoPortoRepository TipoLogisticoPortoRepo)
        {
            _TipoLogisticoPortoRepo = TipoLogisticoPortoRepo;
        }

        public TipoLogisticoPorto InsertTipoLogisticoPorto(TipoLogisticoPorto objTipoLogisticoPorto)
        {
            return _TipoLogisticoPortoRepo.InsertTipoLogisticoPorto(objTipoLogisticoPorto);
        }

        public bool UpdateTipoLogisticoPorto(TipoLogisticoPorto objTipoLogisticoPorto)
        {
            return _TipoLogisticoPortoRepo.UpdateTipoLogisticoPorto(objTipoLogisticoPorto);
        }

        public bool AtivarTipoLogisticoPorto(int TLP_Id)
        {
            return _TipoLogisticoPortoRepo.AtivarTipoLogisticoPorto(TLP_Id);
        }

        public bool DeletarTipoLogisticoPorto(int TLP_Id)
        {
            return _TipoLogisticoPortoRepo.DeletarTipoLogisticoPorto(TLP_Id);
        }

        public TipoLogisticoPorto GetTipoLogisticoPortoById(int TLP_Id, bool join)
        {
            return _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(TLP_Id, join);
        }

        public IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPorto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoPortoRepo.GetAllTipoLogisticoPorto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPortoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoPortoRepo.GetAllTipoLogisticoPortoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPortoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoPortoRepo.GetAllTipoLogisticoPortoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

