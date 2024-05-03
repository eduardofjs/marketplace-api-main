
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TipoLogisticoSistemaProdutivoAppServices : ITipoLogisticoSistemaProdutivoAppServices
    {
        private readonly ITipoLogisticoSistemaProdutivoServices _TipoLogisticoSistemaProdutivoServices;


        public TipoLogisticoSistemaProdutivoAppServices(ITipoLogisticoSistemaProdutivoServices TipoLogisticoSistemaProdutivoServices)
        {
            _TipoLogisticoSistemaProdutivoServices = TipoLogisticoSistemaProdutivoServices;

        }

        public TipoLogisticoSistemaProdutivo InsertTipoLogisticoSistemaProdutivo(TipoLogisticoSistemaProdutivo objTipoLogisticoSistemaProdutivo)
        {


            return _TipoLogisticoSistemaProdutivoServices.InsertTipoLogisticoSistemaProdutivo(objTipoLogisticoSistemaProdutivo);
        }

        public bool UpdateTipoLogisticoSistemaProdutivo(TipoLogisticoSistemaProdutivo objTipoLogisticoSistemaProdutivo)
        {

            return _TipoLogisticoSistemaProdutivoServices.UpdateTipoLogisticoSistemaProdutivo(objTipoLogisticoSistemaProdutivo);
        }

        public bool AtivarTipoLogisticoSistemaProdutivo(int TLS_Id)
        {
            return _TipoLogisticoSistemaProdutivoServices.AtivarTipoLogisticoSistemaProdutivo(TLS_Id);
        }

        public bool DeletarTipoLogisticoSistemaProdutivo(int TLS_Id)
        {
            return _TipoLogisticoSistemaProdutivoServices.DeletarTipoLogisticoSistemaProdutivo(TLS_Id);
        }

        public TipoLogisticoSistemaProdutivo GetTipoLogisticoSistemaProdutivoById(int TLS_Id, bool join)
        {
            return _TipoLogisticoSistemaProdutivoServices.GetTipoLogisticoSistemaProdutivoById(TLS_Id, join);
        }

        public IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoSistemaProdutivoServices.GetAllTipoLogisticoSistemaProdutivo(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoSistemaProdutivoServices.GetAllTipoLogisticoSistemaProdutivoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoLogisticoSistemaProdutivoServices.GetAllTipoLogisticoSistemaProdutivoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

