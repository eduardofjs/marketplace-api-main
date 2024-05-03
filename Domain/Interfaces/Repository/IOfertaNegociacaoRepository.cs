
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IOfertaNegociacaoRepository
    {
        OfertaNegociacao InsertOfertaNegociacao(OfertaNegociacao objOfertaNegociacao);
        bool UpdateOfertaNegociacao(OfertaNegociacao objOfertaNegociacao);
        bool AtivarOfertaNegociacao(int OFN_Id);
        bool DeletarOfertaNegociacao(int OFN_Id);
        OfertaNegociacao GetOfertaNegociacaoById(int OFN_Id, bool join);
        IEnumerable<OfertaNegociacao> GetAllOfertaNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaNegociacao> GetAllOfertaNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaNegociacao> GetAllOfertaNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        bool AprovarOfertaNegociacao(int OFN_Id);
        bool ReprovarOfertaNegociacao(int OFN_Id);
        IEnumerable<OfertaNegociacao> GetOfertaNegociacaoByEmpresaId(int EmpresaId, bool fSomenteAtivos, int maxInstances = 0, string order_by = "");
        bool OfertaNegociacaoLiberaOfertador(int OFN_Id);
        bool OfertaNegociacaoLiberaCliente(int OFN_Id);
        bool UpdateOfertaNegociacaoDirectto(int OFN_Id, int OFN_MeioTransporteId, DateTime OFN_DataEmbarque, DateTime OFN_DataEstimativaEmbarque, string OFN_TermosPagamento, int OFN_StatusPagamentoId);
        bool UpdateEtapaNegociacaoDirectto(int OFN_Id, int OFN_EtapaNegociacaoDirectto);
        bool UpdateEtapaNegociacaoOfertador(int OFN_Id, int OFN_EtapaNegociacaoOfertador);
        bool UpdateEtapaNegociacaoCliente(int OFN_Id, int OFN_EtapaNegociacaoCliente);
        bool UpdateEtapaNegociacaoDatas(int OFN_Id, string CampoData);
        bool ValidaRegraVendedorComprador(OfertaNegociacao objOfertaNegociacao);
        bool ValidaExistenciaNegociacao(int OfertaId);
    }
}
