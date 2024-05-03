using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class OfertaxDocumentoAppServices : IOfertaxDocumentoAppServices
    {
        private readonly IOfertaxDocumentoServices _OfertaxDocumentoServices;


        public OfertaxDocumentoAppServices(IOfertaxDocumentoServices OfertaxDocumentoServices)
        {
            _OfertaxDocumentoServices = OfertaxDocumentoServices;

        }

        public OfertaxDocumento InsertOfertaxDocumento(OfertaxDocumento objOfertaxDocumento)
        {


            return _OfertaxDocumentoServices.InsertOfertaxDocumento(objOfertaxDocumento);
        }

        public bool UpdateOfertaxDocumento(OfertaxDocumento objOfertaxDocumento)
        {

            return _OfertaxDocumentoServices.UpdateOfertaxDocumento(objOfertaxDocumento);
        }

        public bool AtivarOfertaxDocumento(int OXD_Id)
        {
            return _OfertaxDocumentoServices.AtivarOfertaxDocumento(OXD_Id);
        }

        public bool DeletarOfertaxDocumento(int OXD_Id)
        {
            return _OfertaxDocumentoServices.DeletarOfertaxDocumento(OXD_Id);
        }

        public OfertaxDocumento GetOfertaxDocumentoById(int OXD_Id, bool join)
        {
            return _OfertaxDocumentoServices.GetOfertaxDocumentoById(OXD_Id, join);
        }

        public IEnumerable<OfertaxDocumento> GetAllOfertaxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxDocumentoServices.GetAllOfertaxDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxDocumento> GetAllOfertaxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxDocumentoServices.GetAllOfertaxDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxDocumento> GetAllOfertaxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxDocumentoServices.GetAllOfertaxDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarOfertaxDocumentoByOferta(int OXD_OfertaId)
        {
            return _OfertaxDocumentoServices.DeletarOfertaxDocumentoByOferta(OXD_OfertaId);
        }
    }
}
