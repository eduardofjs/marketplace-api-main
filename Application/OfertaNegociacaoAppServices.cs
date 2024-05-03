
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class OfertaNegociacaoAppServices : IOfertaNegociacaoAppServices
    {
        private readonly IOfertaNegociacaoServices _OfertaNegociacaoServices;


        public OfertaNegociacaoAppServices(IOfertaNegociacaoServices OfertaNegociacaoServices)
        {
            _OfertaNegociacaoServices = OfertaNegociacaoServices;
        }

        public OfertaNegociacao InsertOfertaNegociacao(OfertaNegociacao objOfertaNegociacao)
        {
            return _OfertaNegociacaoServices.InsertOfertaNegociacao(objOfertaNegociacao);
        }

        public bool UpdateOfertaNegociacao(OfertaNegociacao objOfertaNegociacao)
        {
            return _OfertaNegociacaoServices.UpdateOfertaNegociacao(objOfertaNegociacao);
        }

        public bool AtivarOfertaNegociacao(int OFN_Id)
        {
            return _OfertaNegociacaoServices.AtivarOfertaNegociacao(OFN_Id);
        }

        public bool DeletarOfertaNegociacao(int OFN_Id)
        {
            return _OfertaNegociacaoServices.DeletarOfertaNegociacao(OFN_Id);
        }

        public OfertaNegociacao GetOfertaNegociacaoById(int OFN_Id, bool join)
        {
            return _OfertaNegociacaoServices.GetOfertaNegociacaoById(OFN_Id, join);
        }

        public IEnumerable<OfertaNegociacao> GetAllOfertaNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoServices.GetAllOfertaNegociacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacao> GetAllOfertaNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoServices.GetAllOfertaNegociacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacao> GetAllOfertaNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoServices.GetAllOfertaNegociacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool AprovarOfertaNegociacao(int OFN_Id)
        {
            return _OfertaNegociacaoServices.AprovarOfertaNegociacao(OFN_Id);
        }

        public bool ReprovarOfertaNegociacao(int OFN_Id)
        {
            return _OfertaNegociacaoServices.ReprovarOfertaNegociacao(OFN_Id);
        }

        public IEnumerable<OfertaNegociacao> GetOfertaNegociacaoByEmpresaId(int EmpresaId, bool fSomenteAtivos, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoServices.GetOfertaNegociacaoByEmpresaId(EmpresaId, fSomenteAtivos, maxInstances, order_by);
        }

        public bool UpdateOfertaNegociacaoDirectto(int OFN_Id, int OFN_MeioTransporteId, DateTime OFN_DataEmbarque, DateTime OFN_DataEstimativaEmbarque, string OFN_TermosPagamento, int OFN_StatusPagamentoId)
        {
            return _OfertaNegociacaoServices.UpdateOfertaNegociacaoDirectto(OFN_Id, OFN_MeioTransporteId, OFN_DataEmbarque, OFN_DataEstimativaEmbarque, OFN_TermosPagamento, OFN_StatusPagamentoId);
        }

        public bool OfertaNegociacaoLiberaOfertador(int OFN_Id)
        {
            return _OfertaNegociacaoServices.OfertaNegociacaoLiberaOfertador(OFN_Id);
        }

        public bool OfertaNegociacaoLiberaCliente(int OFN_Id)
        {
            return _OfertaNegociacaoServices.OfertaNegociacaoLiberaCliente(OFN_Id);
        }

        public bool UpdateEtapaNegociacaoDirectto(int OFN_Id, int OFN_EtapaNegociacaoDirectto)
        {
            return _OfertaNegociacaoServices.UpdateEtapaNegociacaoDirectto(OFN_Id, OFN_EtapaNegociacaoDirectto);
        }

        public bool UpdateEtapaNegociacaoOfertador(int OFN_Id, int OFN_EtapaNegociacaoOfertador)
        {
            return _OfertaNegociacaoServices.UpdateEtapaNegociacaoOfertador(OFN_Id, OFN_EtapaNegociacaoOfertador);
        }

        public bool UpdateEtapaNegociacaoCliente(int OFN_Id, int OFN_EtapaNegociacaoCliente)
        {
            return _OfertaNegociacaoServices.UpdateEtapaNegociacaoCliente(OFN_Id, OFN_EtapaNegociacaoCliente);
        }

        public bool UpdateEtapaNegociacaoDatas(int OFN_Id, string CampoData)
        {
            return _OfertaNegociacaoServices.UpdateEtapaNegociacaoDatas(OFN_Id, CampoData);
        }

        public bool ValidaRegraVendedorComprador(OfertaNegociacao objOfertaNegociacao)
        {
            return _OfertaNegociacaoServices.ValidaRegraVendedorComprador(objOfertaNegociacao);
        }

        public bool ValidaExistenciaNegociacao(int OfertaId)
        {
            return _OfertaNegociacaoServices.ValidaExistenciaNegociacao(OfertaId);
        }
    }
}

