using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IOfertaxCertificacaoAppServices
    {
        OfertaxCertificacao InsertOfertaxCertificacao(OfertaxCertificacao objOfertaxCertificacao);
        bool UpdateOfertaxCertificacao(OfertaxCertificacao objOfertaxCertificacao);
        bool AtivarOfertaxCertificacao(int OXC_Id);
        bool DeletarOfertaxCertificacao(int OXC_Id);
        OfertaxCertificacao GetOfertaxCertificacaoById(int OXC_Id, bool join);
        IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
