
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IOfertaNegociacaoxDocumentoAppServices
    {
        OfertaNegociacaoxDocumento InsertOfertaNegociacaoxDocumento(OfertaNegociacaoxDocumento objOfertaNegociacaoxDocumento);
        bool UpdateOfertaNegociacaoxDocumento(OfertaNegociacaoxDocumento objOfertaNegociacaoxDocumento);
        bool AtivarOfertaNegociacaoxDocumento(int OND_Id);
        bool DeletarOfertaNegociacaoxDocumento(int OND_Id);
        OfertaNegociacaoxDocumento GetOfertaNegociacaoxDocumentoById(int OND_Id, bool join);
        IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
