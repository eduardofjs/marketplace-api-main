using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class StatusNegociacaoAppServices : IStatusNegociacaoAppServices
    {
        private readonly IStatusNegociacaoServices _StatusNegociacaoServices;


        public StatusNegociacaoAppServices(IStatusNegociacaoServices StatusNegociacaoServices)
        {
            _StatusNegociacaoServices = StatusNegociacaoServices;

        }

        public StatusNegociacao InsertStatusNegociacao(StatusNegociacao objStatusNegociacao)
        {


            return _StatusNegociacaoServices.InsertStatusNegociacao(objStatusNegociacao);
        }

        public bool UpdateStatusNegociacao(StatusNegociacao objStatusNegociacao)
        {

            return _StatusNegociacaoServices.UpdateStatusNegociacao(objStatusNegociacao);
        }

        public bool AtivarStatusNegociacao(int STN_Id)
        {
            return _StatusNegociacaoServices.AtivarStatusNegociacao(STN_Id);
        }

        public bool DeletarStatusNegociacao(int STN_Id)
        {
            return _StatusNegociacaoServices.DeletarStatusNegociacao(STN_Id);
        }

        public StatusNegociacao GetStatusNegociacaoById(int STN_Id, bool join)
        {
            return _StatusNegociacaoServices.GetStatusNegociacaoById(STN_Id, join);
        }

        public IEnumerable<StatusNegociacao> GetAllStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusNegociacaoServices.GetAllStatusNegociacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusNegociacao> GetAllStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusNegociacaoServices.GetAllStatusNegociacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusNegociacao> GetAllStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusNegociacaoServices.GetAllStatusNegociacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

