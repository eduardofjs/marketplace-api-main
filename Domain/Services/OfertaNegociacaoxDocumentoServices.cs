
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class OfertaNegociacaoxDocumentoServices : IOfertaNegociacaoxDocumentoServices
    {
        private readonly IOfertaNegociacaoxDocumentoRepository _OfertaNegociacaoxDocumentoRepo;

        public OfertaNegociacaoxDocumentoServices(IOfertaNegociacaoxDocumentoRepository OfertaNegociacaoxDocumentoRepo)
        {
            _OfertaNegociacaoxDocumentoRepo = OfertaNegociacaoxDocumentoRepo;
        }

        public OfertaNegociacaoxDocumento InsertOfertaNegociacaoxDocumento(OfertaNegociacaoxDocumento objOfertaNegociacaoxDocumento)
        {
            return _OfertaNegociacaoxDocumentoRepo.InsertOfertaNegociacaoxDocumento(objOfertaNegociacaoxDocumento);
        }

        public bool UpdateOfertaNegociacaoxDocumento(OfertaNegociacaoxDocumento objOfertaNegociacaoxDocumento)
        {
            return _OfertaNegociacaoxDocumentoRepo.UpdateOfertaNegociacaoxDocumento(objOfertaNegociacaoxDocumento);
        }

        public bool AtivarOfertaNegociacaoxDocumento(int OND_Id)
        {
            return _OfertaNegociacaoxDocumentoRepo.AtivarOfertaNegociacaoxDocumento(OND_Id);
        }

        public bool DeletarOfertaNegociacaoxDocumento(int OND_Id)
        {
            return _OfertaNegociacaoxDocumentoRepo.DeletarOfertaNegociacaoxDocumento(OND_Id);
        }

        public OfertaNegociacaoxDocumento GetOfertaNegociacaoxDocumentoById(int OND_Id, bool join)
        {
            return _OfertaNegociacaoxDocumentoRepo.GetOfertaNegociacaoxDocumentoById(OND_Id, join);
        }

        public IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxDocumentoRepo.GetAllOfertaNegociacaoxDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxDocumentoRepo.GetAllOfertaNegociacaoxDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxDocumentoRepo.GetAllOfertaNegociacaoxDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

