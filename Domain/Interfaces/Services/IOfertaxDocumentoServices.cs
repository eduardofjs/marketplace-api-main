using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IOfertaxDocumentoServices
    {
        OfertaxDocumento InsertOfertaxDocumento(OfertaxDocumento objOfertaxDocumento);
        bool UpdateOfertaxDocumento(OfertaxDocumento objOfertaxDocumento);
        bool AtivarOfertaxDocumento(int OXD_Id);
        bool DeletarOfertaxDocumento(int OXD_Id);
        bool DeletarOfertaxDocumentoByOferta(int OXD_OfertaId);
        OfertaxDocumento GetOfertaxDocumentoById(int OXD_Id, bool join);
        IEnumerable<OfertaxDocumento> GetAllOfertaxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxDocumento> GetAllOfertaxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxDocumento> GetAllOfertaxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
