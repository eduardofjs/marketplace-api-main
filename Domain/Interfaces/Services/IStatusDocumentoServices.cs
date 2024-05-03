using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IStatusDocumentoServices
    {
        StatusDocumento InsertStatusDocumento(StatusDocumento objStatusDocumento);
        bool UpdateStatusDocumento(StatusDocumento objStatusDocumento);
        bool AtivarStatusDocumento(int SDO_Id);
        bool DeletarStatusDocumento(int SDO_Id);
        StatusDocumento GetStatusDocumentoById(int SDO_Id, bool join);
        IEnumerable<StatusDocumento> GetAllStatusDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<StatusDocumento> GetAllStatusDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<StatusDocumento> GetAllStatusDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
