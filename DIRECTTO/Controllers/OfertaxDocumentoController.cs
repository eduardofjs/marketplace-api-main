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
    public class OfertaxDocumentoController : ApiController
    {
        private readonly IOfertaxDocumentoAppServices _OfertaxDocumentoAppServices;

        public OfertaxDocumentoController(IOfertaxDocumentoAppServices OfertaxDocumentoAppServices)
        {
            try
            {
                _OfertaxDocumentoAppServices = OfertaxDocumentoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/OfertaxDocumento/AtivarOfertaxDocumento")]
        [HttpPut]
        public HttpResponseMessage AtivarOfertaxDocumento(int OXD_Id, Log Log)
        {
            try
            {
                var item = _OfertaxDocumentoAppServices.AtivarOfertaxDocumento(OXD_Id);
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

        [Route("api/OfertaxDocumento/DeletarOfertaxDocumento")]
        [HttpPut]
        public HttpResponseMessage DeletarOfertaxDocumento(int OXD_Id, Log Log)
        {
            try
            {
                var item = _OfertaxDocumentoAppServices.DeletarOfertaxDocumento(OXD_Id);
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

        [Route("api/OfertaxDocumento/GetAllOfertaxDocumento")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxDocumentoAppServices.GetAllOfertaxDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/OfertaxDocumento/GetAllOfertaxDocumentoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxDocumentoAppServices.GetAllOfertaxDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/OfertaxDocumento/GetAllOfertaxDocumentoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxDocumentoAppServices.GetAllOfertaxDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/OfertaxDocumento/GetOfertaxDocumentoById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaxDocumentoById(int OXD_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaxDocumentoAppServices.GetOfertaxDocumentoById(OXD_Id, join);
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

        [Route("api/OfertaxDocumento/GetListOfertaxDocumento")]
        [HttpPost]
        public HttpResponseMessage GetListOfertaxDocumento(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxDocumentoAppServices.GetAllOfertaxDocumento(true, true, join, maxInstances, order_by);
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

        [Route("api/OfertaxDocumento/CadastroOfertaxDocumento")]
        [HttpPut]
        public HttpResponseMessage CadastroOfertaxDocumento(OfertaxDocumento objOfertaxDocumento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objOfertaxDocumento.OXD_Id > 0)
                    {
                        var fUpdate = _OfertaxDocumentoAppServices.UpdateOfertaxDocumento(objOfertaxDocumento);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objOfertaxDocumento);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new OfertaxDocumento());
                    }
                    else
                    {
                        var fInsert = _OfertaxDocumentoAppServices.InsertOfertaxDocumento(objOfertaxDocumento);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objOfertaxDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objOfertaxDocumento);
            }
        }

    }
}
