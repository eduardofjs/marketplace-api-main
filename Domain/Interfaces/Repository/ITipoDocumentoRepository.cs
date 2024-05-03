
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface ITipoDocumentoRepository
    {
        TipoDocumento InsertTipoDocumento(TipoDocumento objTipoDocumento);
        bool UpdateTipoDocumento(TipoDocumento objTipoDocumento);
        bool AtivarTipoDocumento(int TDC_Id);
        bool DeletarTipoDocumento(int TDC_Id);
        TipoDocumento GetTipoDocumentoById(int TDC_Id, bool join);
        IEnumerable<TipoDocumento> GetAllTipoDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoDocumento> GetAllTipoDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoDocumento> GetAllTipoDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
