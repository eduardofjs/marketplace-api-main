
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TipoLogisticoSistemaProdutivoServices : ITipoLogisticoSistemaProdutivoServices
    {
        private readonly ITipoLogisticoSistemaProdutivoRepository _TipoLogisticoSistemaProdutivoRepo;

        public TipoLogisticoSistemaProdutivoServices(ITipoLogisticoSistemaProdutivoRepository TipoLogisticoSistemaProdutivoRepo)
        {
            _TipoLogisticoSistemaProdutivoRepo = TipoLogisticoSistemaProdutivoRepo;
        }

        public TipoLogisticoSistemaProdutivo InsertTipoLogisticoSistemaProdutivo(TipoLogisticoSistemaProdutivo objTipoLogisticoSistemaProdutivo)
        {
            return _TipoLogisticoSistemaProdutivoRepo.InsertTipoLogisticoSistemaProdutivo(objTipoLogisticoSistemaProdutivo);
        }

        public bool UpdateTipoLogisticoSistemaProdutivo(TipoLogisticoSistemaProdutivo objTipoLogisticoSistemaProdutivo)
        {
            return _TipoLogisticoSistemaProdutivoRepo.UpdateTipoLogisticoSistemaProdutivo(objTipoLogisticoSistemaProdutivo);
        }

        public bool AtivarTipoLogisticoSistemaProdutivo(int TLS_Id)
        {
            return _TipoLogisticoSistemaProdutivoRepo.AtivarTipoLogisticoSistemaProdutivo(TLS_Id);
        }

        public bool DeletarTipoLogisticoSistemaProdutivo(int TLS_Id)
        {
            return _TipoLogisticoSistemaProdutivoRepo.DeletarTipoLogisticoSistemaProdutivo(TLS_Id);
        }

        public TipoLogisticoSistemaProdutivo GetTipoLogisticoSistemaProdutivoById(int TLS_Id, bool join)
        {
            return _TipoLogisticoSistemaProdutivoRepo.GetTipoLogisticoSistemaProdutivoById(TLS_Id, join);
        }

        public IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoSistemaProdutivoRepo.GetAllTipoLogisticoSistemaProdutivo(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoSistemaProdutivoRepo.GetAllTipoLogisticoSistemaProdutivoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoSistemaProdutivoRepo.GetAllTipoLogisticoSistemaProdutivoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

