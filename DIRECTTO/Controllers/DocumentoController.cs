using Application.Interfaces;
using Data.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DIRECTTO.Filters;
using DIRECTTO.Helpers;

namespace DIRECTTO.Controllers
{
    [MyBasicAuthenticationFilter]
    [LogActionFilter]
    public class DocumentoController : ApiController
    {
        private readonly IDocumentoAppServices _DocumentoAppServices;

        public DocumentoController(IDocumentoAppServices DocumentoAppServices)
        {
            try
            {
                _DocumentoAppServices = DocumentoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/Documento/AtivarDocumento")]
        [HttpPut]
        public HttpResponseMessage AtivarDocumento(int DOC_Id, Log Log)
        {
            try
            {
                var item = _DocumentoAppServices.AtivarDocumento(DOC_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Documento/DeletarDocumento")]
        [HttpPut]
        public HttpResponseMessage DeletarDocumento(int DOC_Id, Log Log)
        {
            try
            {
                var item = _DocumentoAppServices.DeletarDocumento(DOC_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Documento/GetAllDocumento")]
        [HttpPost]
        public HttpResponseMessage GetAllDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _DocumentoAppServices.GetAllDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Documento/GetAllDocumentoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _DocumentoAppServices.GetAllDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }


        [Route("api/Documento/GetAllDocumentoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _DocumentoAppServices.GetAllDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }



        [Route("api/Documento/GetDocumentoById")]
        [HttpPost]
        public HttpResponseMessage GetDocumentoById(int DOC_Id, bool join, Log Log)
        {
            try
            {
                var item = _DocumentoAppServices.GetDocumentoById(DOC_Id, join);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Documento/GetListDocumento")]
        [HttpPost]
        public HttpResponseMessage GetListDocumento(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _DocumentoAppServices.GetAllDocumento(true, true, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Documento/CadastroDocumento")]
        [HttpPut]
        public HttpResponseMessage CadastroDocumento(Documento objDocumento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objDocumento.DOC_Id > 0)
                    {
                        var fUpdate = _DocumentoAppServices.UpdateDocumento(objDocumento);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objDocumento);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Documento());
                    }
                    else
                    {
                        var fInsert = _DocumentoAppServices.InsertDocumento(objDocumento);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objDocumento);
            }
        }

        [Route("api/Documento/UpdateArquivoPath")]
        [HttpPut]
        public HttpResponseMessage UpdateArquivoPath(Documento objDocumento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fUpdate = _DocumentoAppServices.UpdateDocumento(objDocumento);
                    if (fUpdate)
                        return Request.CreateResponse(HttpStatusCode.OK, objDocumento);
                    else
                        return Request.CreateResponse(HttpStatusCode.OK, new Documento());

                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objDocumento);
            }
        }

       
    }
}
