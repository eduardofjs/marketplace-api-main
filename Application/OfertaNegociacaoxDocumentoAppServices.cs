
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class OfertaNegociacaoxDocumentoAppServices : IOfertaNegociacaoxDocumentoAppServices
    {
        private readonly IOfertaNegociacaoxDocumentoServices _OfertaNegociacaoxDocumentoServices;


        public OfertaNegociacaoxDocumentoAppServices(IOfertaNegociacaoxDocumentoServices OfertaNegociacaoxDocumentoServices)
        {
            _OfertaNegociacaoxDocumentoServices = OfertaNegociacaoxDocumentoServices;
        }

        public OfertaNegociacaoxDocumento InsertOfertaNegociacaoxDocumento(OfertaNegociacaoxDocumento objOfertaNegociacaoxDocumento)
        {
            return _OfertaNegociacaoxDocumentoServices.InsertOfertaNegociacaoxDocumento(objOfertaNegociacaoxDocumento);
        }

        public bool UpdateOfertaNegociacaoxDocumento(OfertaNegociacaoxDocumento objOfertaNegociacaoxDocumento)
        {
            return _OfertaNegociacaoxDocumentoServices.UpdateOfertaNegociacaoxDocumento(objOfertaNegociacaoxDocumento);
        }

        public bool AtivarOfertaNegociacaoxDocumento(int OND_Id)
        {
            return _OfertaNegociacaoxDocumentoServices.AtivarOfertaNegociacaoxDocumento(OND_Id);
        }

        public bool DeletarOfertaNegociacaoxDocumento(int OND_Id)
        {
            return _OfertaNegociacaoxDocumentoServices.DeletarOfertaNegociacaoxDocumento(OND_Id);
        }

        public OfertaNegociacaoxDocumento GetOfertaNegociacaoxDocumentoById(int OND_Id, bool join)
        {
            return _OfertaNegociacaoxDocumentoServices.GetOfertaNegociacaoxDocumentoById(OND_Id, join);
        }

        public IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxDocumentoServices.GetAllOfertaNegociacaoxDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxDocumentoServices.GetAllOfertaNegociacaoxDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaNegociacaoxDocumentoServices.GetAllOfertaNegociacaoxDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

