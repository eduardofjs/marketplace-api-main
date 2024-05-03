using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class OfertaxDocumentoServices : IOfertaxDocumentoServices
    {
        private readonly IOfertaxDocumentoRepository _OfertaxDocumentoRepo;

        public OfertaxDocumentoServices(IOfertaxDocumentoRepository OfertaxDocumentoRepo)
        {
            _OfertaxDocumentoRepo = OfertaxDocumentoRepo;
        }

        public OfertaxDocumento InsertOfertaxDocumento(OfertaxDocumento objOfertaxDocumento)
        {
            return _OfertaxDocumentoRepo.InsertOfertaxDocumento(objOfertaxDocumento);
        }

        public bool UpdateOfertaxDocumento(OfertaxDocumento objOfertaxDocumento)
        {
            return _OfertaxDocumentoRepo.UpdateOfertaxDocumento(objOfertaxDocumento);
        }

        public bool AtivarOfertaxDocumento(int OXD_Id)
        {
            return _OfertaxDocumentoRepo.AtivarOfertaxDocumento(OXD_Id);
        }

        public bool DeletarOfertaxDocumento(int OXD_Id)
        {
            return _OfertaxDocumentoRepo.DeletarOfertaxDocumento(OXD_Id);
        }

        public OfertaxDocumento GetOfertaxDocumentoById(int OXD_Id, bool join)
        {
            return _OfertaxDocumentoRepo.GetOfertaxDocumentoById(OXD_Id, join);
        }

        public IEnumerable<OfertaxDocumento> GetAllOfertaxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxDocumentoRepo.GetAllOfertaxDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxDocumento> GetAllOfertaxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxDocumentoRepo.GetAllOfertaxDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxDocumento> GetAllOfertaxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxDocumentoRepo.GetAllOfertaxDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarOfertaxDocumentoByOferta(int OXD_OfertaId)
        {
            return _OfertaxDocumentoRepo.DeletarOfertaxDocumentoByOferta(OXD_OfertaId);
        }
    }
}

