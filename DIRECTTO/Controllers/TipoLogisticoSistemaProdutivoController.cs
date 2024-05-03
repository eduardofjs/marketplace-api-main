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
    public class TipoLogisticoSistemaProdutivoController : ApiController
    {
        private readonly ITipoLogisticoSistemaProdutivoAppServices _TipoLogisticoSistemaProdutivoAppServices;

        public TipoLogisticoSistemaProdutivoController(ITipoLogisticoSistemaProdutivoAppServices TipoLogisticoSistemaProdutivoAppServices)
        {
            try
            {
                _TipoLogisticoSistemaProdutivoAppServices = TipoLogisticoSistemaProdutivoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TipoLogisticoSistemaProdutivo/AtivarTipoLogisticoSistemaProdutivo")]
        [HttpPut]
        public HttpResponseMessage AtivarTipoLogisticoSistemaProdutivo(int TLS_Id, Log Log)
        {
            try
            {
                var item = _TipoLogisticoSistemaProdutivoAppServices.AtivarTipoLogisticoSistemaProdutivo(TLS_Id);
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

        [Route("api/TipoLogisticoSistemaProdutivo/DeletarTipoLogisticoSistemaProdutivo")]
        [HttpPut]
        public HttpResponseMessage DeletarTipoLogisticoSistemaProdutivo(int TLS_Id, Log Log)
        {
            try
            {
                var item = _TipoLogisticoSistemaProdutivoAppServices.DeletarTipoLogisticoSistemaProdutivo(TLS_Id);
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

        [Route("api/TipoLogisticoSistemaProdutivo/GetAllTipoLogisticoSistemaProdutivo")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoLogisticoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoLogisticoSistemaProdutivoAppServices.GetAllTipoLogisticoSistemaProdutivo(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TipoLogisticoSistemaProdutivo/GetAllTipoLogisticoSistemaProdutivoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoLogisticoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoLogisticoSistemaProdutivoAppServices.GetAllTipoLogisticoSistemaProdutivoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TipoLogisticoSistemaProdutivo/GetAllTipoLogisticoSistemaProdutivoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoLogisticoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoLogisticoSistemaProdutivoAppServices.GetAllTipoLogisticoSistemaProdutivoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/TipoLogisticoSistemaProdutivo/GetTipoLogisticoSistemaProdutivoById")]
        [HttpPost]
        public HttpResponseMessage GetTipoLogisticoSistemaProdutivoById(int TLS_Id, bool join, Log Log)
        {
            try
            {
                var item = _TipoLogisticoSistemaProdutivoAppServices.GetTipoLogisticoSistemaProdutivoById(TLS_Id, join);
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

        [Route("api/TipoLogisticoSistemaProdutivo/GetListTipoLogisticoSistemaProdutivo")]
        [HttpPost]
        public HttpResponseMessage GetListTipoLogisticoSistemaProdutivo(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoLogisticoSistemaProdutivoAppServices.GetAllTipoLogisticoSistemaProdutivo(true, true, join, maxInstances, order_by);
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

        [Route("api/TipoLogisticoSistemaProdutivo/CadastroTipoLogisticoSistemaProdutivo")]
        [HttpPut]
        public HttpResponseMessage CadastroTipoLogisticoSistemaProdutivo(TipoLogisticoSistemaProdutivo objTipoLogisticoSistemaProdutivo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTipoLogisticoSistemaProdutivo.TLS_Id > 0)
                    {
                        var fUpdate = _TipoLogisticoSistemaProdutivoAppServices.UpdateTipoLogisticoSistemaProdutivo(objTipoLogisticoSistemaProdutivo);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTipoLogisticoSistemaProdutivo);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TipoLogisticoSistemaProdutivo());
                    }
                    else
                    {
                        var fInsert = _TipoLogisticoSistemaProdutivoAppServices.InsertTipoLogisticoSistemaProdutivo(objTipoLogisticoSistemaProdutivo);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTipoLogisticoSistemaProdutivo.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTipoLogisticoSistemaProdutivo);
            }
        }

    }
}
