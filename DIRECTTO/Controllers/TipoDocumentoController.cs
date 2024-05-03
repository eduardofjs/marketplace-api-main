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
    [MyBasicAuthenticationFilter]    [LogActionFilter]
    public class TipoDocumentoController : ApiController
    {
        private readonly ITipoDocumentoAppServices _TipoDocumentoAppServices;

        public TipoDocumentoController(ITipoDocumentoAppServices TipoDocumentoAppServices)
        {
            try { 
                _TipoDocumentoAppServices = TipoDocumentoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TipoDocumento/AtivarTipoDocumento")]
        [HttpPut]
        public HttpResponseMessage AtivarTipoDocumento(int TDC_Id, Log Log)
        {
            try
            {
                var item = _TipoDocumentoAppServices.AtivarTipoDocumento(TDC_Id);
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

        [Route("api/TipoDocumento/DeletarTipoDocumento")]
        [HttpPost]
        public HttpResponseMessage DeletarTipoDocumento(int TDC_Id, Log Log)
        {
            try
            {
                var item = _TipoDocumentoAppServices.DeletarTipoDocumento(TDC_Id);
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

        [Route("api/TipoDocumento/GetAllTipoDocumento")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoDocumentoAppServices.GetAllTipoDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TipoDocumento/GetAllTipoDocumentoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoDocumentoAppServices.GetAllTipoDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TipoDocumento/GetAllTipoDocumentoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoDocumentoAppServices.GetAllTipoDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/TipoDocumento/GetTipoDocumentoById")]
        [HttpPost]
        public HttpResponseMessage GetTipoDocumentoById(int TDC_Id, bool join, Log Log)
        {
            try
            {
                var item = _TipoDocumentoAppServices.GetTipoDocumentoById(TDC_Id, join);
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

        [Route("api/TipoDocumento/GetListTipoDocumento")]
        [HttpPost]
        public HttpResponseMessage GetListTipoDocumento(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoDocumentoAppServices.GetAllTipoDocumento(true, true, join, maxInstances, order_by);
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
        
        [Route("api/TipoDocumento/CadastroTipoDocumento")]
        [HttpPut]
        public HttpResponseMessage CadastroTipoDocumento(TipoDocumento objTipoDocumento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTipoDocumento.TDC_Id > 0)
                    {
                        var fUpdate = _TipoDocumentoAppServices.UpdateTipoDocumento(objTipoDocumento);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTipoDocumento);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TipoDocumento());
                    }
                    else
                    {
                        var fInsert = _TipoDocumentoAppServices.InsertTipoDocumento(objTipoDocumento);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTipoDocumento.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTipoDocumento);
            }
        }

    }
}
