
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IOfertaNegociacaoxStatusNegociacaoRepository
    {
        OfertaNegociacaoxStatusNegociacao InsertOfertaNegociacaoxStatusNegociacao(OfertaNegociacaoxStatusNegociacao objOfertaNegociacaoxStatusNegociacao);
        bool UpdateOfertaNegociacaoxStatusNegociacao(OfertaNegociacaoxStatusNegociacao objOfertaNegociacaoxStatusNegociacao);
        bool AtivarOfertaNegociacaoxStatusNegociacao(int ONS_Id);
        bool DeletarOfertaNegociacaoxStatusNegociacao(int ONS_Id);
        OfertaNegociacaoxStatusNegociacao GetOfertaNegociacaoxStatusNegociacaoById(int ONS_Id, bool join);
        IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
