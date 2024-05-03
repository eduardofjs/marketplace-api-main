
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IDocumentoAppServices
    {
        Documento InsertDocumento(Documento objDocumento);
        bool UpdateDocumento(Documento objDocumento);
        bool AtivarDocumento(int DOC_Id);
        bool DeletarDocumento(int DOC_Id);
        Documento GetDocumentoById(int DOC_Id, bool join);
        IEnumerable<Documento> GetAllDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Documento> GetAllDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Documento> GetAllDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
