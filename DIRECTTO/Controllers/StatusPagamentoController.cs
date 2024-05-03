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
    public class StatusPagamentoController : ApiController
    {
        private readonly IStatusPagamentoAppServices _StatusPagamentoAppServices;

        public StatusPagamentoController(IStatusPagamentoAppServices StatusPagamentoAppServices)
        {
            try { 
                _StatusPagamentoAppServices = StatusPagamentoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/StatusPagamento/AtivarStatusPagamento")]
        [HttpPut]
        public HttpResponseMessage AtivarStatusPagamento(int SPG_Id, Log Log)
        {
            try
            {
                var item = _StatusPagamentoAppServices.AtivarStatusPagamento(SPG_Id);
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

        [Route("api/StatusPagamento/DeletarStatusPagamento")]
        [HttpPut]
        public HttpResponseMessage DeletarStatusPagamento(int SPG_Id, Log Log)
        {
            try
            {
                var item = _StatusPagamentoAppServices.DeletarStatusPagamento(SPG_Id);
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

        [Route("api/StatusPagamento/GetAllStatusPagamento")]
        [HttpPost]
        public HttpResponseMessage GetAllStatusPagamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusPagamentoAppServices.GetAllStatusPagamento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/StatusPagamento/GetAllStatusPagamentoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllStatusPagamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusPagamentoAppServices.GetAllStatusPagamentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/StatusPagamento/GetAllStatusPagamentoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllStatusPagamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusPagamentoAppServices.GetAllStatusPagamentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/StatusPagamento/GetStatusPagamentoById")]
        [HttpPost]
        public HttpResponseMessage GetStatusPagamentoById(int SPG_Id, bool join, Log Log)
        {
            try
            {
                var item = _StatusPagamentoAppServices.GetStatusPagamentoById(SPG_Id, join);
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

        [Route("api/StatusPagamento/GetListStatusPagamento")]
        [HttpPost]
        public HttpResponseMessage GetListStatusPagamento(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusPagamentoAppServices.GetAllStatusPagamento(true, true, join, maxInstances, order_by);
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
        
        [Route("api/StatusPagamento/CadastroStatusPagamento")]
        [HttpPut]
        public HttpResponseMessage CadastroStatusPagamento(StatusPagamento objStatusPagamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objStatusPagamento.SPG_Id > 0)
                    {
                        var fUpdate = _StatusPagamentoAppServices.UpdateStatusPagamento(objStatusPagamento);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objStatusPagamento);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new StatusPagamento());
                    }
                    else
                    {
                        var fInsert = _StatusPagamentoAppServices.InsertStatusPagamento(objStatusPagamento);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objStatusPagamento.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objStatusPagamento);
            }
        }

    }
}
