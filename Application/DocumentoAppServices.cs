
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class DocumentoAppServices : IDocumentoAppServices
    {
        private readonly IDocumentoServices _DocumentoServices;
        private readonly ITipoDocumentoServices _TipoDocumentoServices;
        private readonly IUsuarioServices _UsuarioServices;


        public DocumentoAppServices(IDocumentoServices DocumentoServices, ITipoDocumentoServices TipoDocumentoServices, IUsuarioServices UsuarioServices)
        {
            _DocumentoServices = DocumentoServices;
            _TipoDocumentoServices = TipoDocumentoServices;
            _UsuarioServices = UsuarioServices;

        }

        public Documento InsertDocumento(Documento objDocumento)
        {
            if (objDocumento.TipoDocumento != null)
            {
                objDocumento.TipoDocumento = _TipoDocumentoServices.InsertTipoDocumento(objDocumento.TipoDocumento);
                objDocumento.DOC_TipoDocumentoId = objDocumento.TipoDocumento.TDC_Id;
            }
            if (objDocumento.Usuario != null)
            {
                objDocumento.Usuario = _UsuarioServices.InsertUsuario(objDocumento.Usuario);
                objDocumento.DOC_UsuarioId = objDocumento.Usuario.USR_Id;
            }


            return _DocumentoServices.InsertDocumento(objDocumento);
        }

        public bool UpdateDocumento(Documento objDocumento)
        {
            if (objDocumento.TipoDocumento != null)
            {
                if (objDocumento.TipoDocumento.TDC_Id == 0)
                {
                    objDocumento.TipoDocumento = _TipoDocumentoServices.InsertTipoDocumento(objDocumento.TipoDocumento);
                    objDocumento.DOC_TipoDocumentoId = objDocumento.TipoDocumento.TDC_Id;
                }
                else
                {
                    bool flagTipoDocumento = _TipoDocumentoServices.UpdateTipoDocumento(objDocumento.TipoDocumento);
                }
            }
            if (objDocumento.Usuario != null)
            {
                if (objDocumento.Usuario.USR_Id == 0)
                {
                    objDocumento.Usuario = _UsuarioServices.InsertUsuario(objDocumento.Usuario);
                    objDocumento.DOC_UsuarioId = objDocumento.Usuario.USR_Id;
                }
                else
                {
                    bool flagUsuario = _UsuarioServices.UpdateUsuario(objDocumento.Usuario);
                }
            }

            return _DocumentoServices.UpdateDocumento(objDocumento);
        }

        public bool AtivarDocumento(int DOC_Id)
        {
            return _DocumentoServices.AtivarDocumento(DOC_Id);
        }

        public bool DeletarDocumento(int DOC_Id)
        {
            return _DocumentoServices.DeletarDocumento(DOC_Id);
        }

        public Documento GetDocumentoById(int DOC_Id, bool join)
        {
            return _DocumentoServices.GetDocumentoById(DOC_Id, join);
        }

        public IEnumerable<Documento> GetAllDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _DocumentoServices.GetAllDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Documento> GetAllDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _DocumentoServices.GetAllDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Documento> GetAllDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _DocumentoServices.GetAllDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

    }
}

