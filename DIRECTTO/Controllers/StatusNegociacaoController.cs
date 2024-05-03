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
    public class StatusNegociacaoController : ApiController
    {
        private readonly IStatusNegociacaoAppServices _StatusNegociacaoAppServices;

        public StatusNegociacaoController(IStatusNegociacaoAppServices StatusNegociacaoAppServices)
        {
            try
            {
                _StatusNegociacaoAppServices = StatusNegociacaoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/StatusNegociacao/AtivarStatusNegociacao")]
        [HttpPut]
        public HttpResponseMessage AtivarStatusNegociacao(int STN_Id, Log Log)
        {
            try
            {
                var item = _StatusNegociacaoAppServices.AtivarStatusNegociacao(STN_Id);
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

        [Route("api/StatusNegociacao/DeletarStatusNegociacao")]
        [HttpPut]
        public HttpResponseMessage DeletarStatusNegociacao(int STN_Id, Log Log)
        {
            try
            {
                var item = _StatusNegociacaoAppServices.DeletarStatusNegociacao(STN_Id);
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

        [Route("api/StatusNegociacao/GetAllStatusNegociacao")]
        [HttpPost]
        public HttpResponseMessage GetAllStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusNegociacaoAppServices.GetAllStatusNegociacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/StatusNegociacao/GetAllStatusNegociacaoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusNegociacaoAppServices.GetAllStatusNegociacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/StatusNegociacao/GetAllStatusNegociacaoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusNegociacaoAppServices.GetAllStatusNegociacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/StatusNegociacao/GetStatusNegociacaoById")]
        [HttpPost]
        public HttpResponseMessage GetStatusNegociacaoById(int STN_Id, bool join, Log Log)
        {
            try
            {
                var item = _StatusNegociacaoAppServices.GetStatusNegociacaoById(STN_Id, join);
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

        [Route("api/StatusNegociacao/GetListStatusNegociacao")]
        [HttpPost]
        public HttpResponseMessage GetListStatusNegociacao(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusNegociacaoAppServices.GetAllStatusNegociacao(true, true, join, maxInstances, order_by);
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

        [Route("api/StatusNegociacao/CadastroStatusNegociacao")]
        [HttpPut]
        public HttpResponseMessage CadastroStatusNegociacao(StatusNegociacao objStatusNegociacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objStatusNegociacao.STN_Id > 0)
                    {
                        var fUpdate = _StatusNegociacaoAppServices.UpdateStatusNegociacao(objStatusNegociacao);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objStatusNegociacao);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new StatusNegociacao());
                    }
                    else
                    {
                        var fInsert = _StatusNegociacaoAppServices.InsertStatusNegociacao(objStatusNegociacao);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objStatusNegociacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objStatusNegociacao);
            }
        }

    }
}
