
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class DocumentoServices : IDocumentoServices
    {
        private readonly IDocumentoRepository _DocumentoRepo;

        public DocumentoServices(IDocumentoRepository DocumentoRepo)
        {
            _DocumentoRepo = DocumentoRepo;
        }
		
        public Documento InsertDocumento(Documento objDocumento)
        {
            return _DocumentoRepo.InsertDocumento(objDocumento);
        }

        public bool UpdateDocumento(Documento objDocumento)
        {
            return _DocumentoRepo.UpdateDocumento(objDocumento);
        }

        public bool AtivarDocumento(int DOC_Id)
        {
            return _DocumentoRepo.AtivarDocumento(DOC_Id);
        }

        public bool DeletarDocumento(int DOC_Id)
        {
            return _DocumentoRepo.DeletarDocumento(DOC_Id);
        }
        
        public Documento GetDocumentoById(int DOC_Id, bool join)
        {
            return _DocumentoRepo.GetDocumentoById(DOC_Id, join);
        }

        public IEnumerable<Documento> GetAllDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _DocumentoRepo.GetAllDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Documento> GetAllDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _DocumentoRepo.GetAllDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Documento> GetAllDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _DocumentoRepo.GetAllDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

    }
}

