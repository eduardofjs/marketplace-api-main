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
using log4net;

namespace DIRECTTO.Controllers
{
    [MyBasicAuthenticationFilter]    [LogActionFilter]
    public class NotificacaoController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly INotificacaoAppServices _NotificacaoAppServices;

        public NotificacaoController(INotificacaoAppServices NotificacaoAppServices)
        {
            try { 
                _NotificacaoAppServices = NotificacaoAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/Notificacao/AtivarNotificacao")]
        [HttpPost]
        public HttpResponseMessage AtivarNotificacao(int NOT_Id, Log Log)
        {
            try
            {
                var item = _NotificacaoAppServices.AtivarNotificacao(NOT_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Notificacao/DeletarNotificacao")]
        [HttpPost]
        public HttpResponseMessage DeletarNotificacao(int NOT_Id, Log Log)
        {
            try
            {
                var item = _NotificacaoAppServices.DeletarNotificacao(NOT_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Notificacao/GetAllNotificacao")]
        [HttpPost]
        public HttpResponseMessage GetAllNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _NotificacaoAppServices.GetAllNotificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Notificacao/GetAllNotificacaoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _NotificacaoAppServices.GetAllNotificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }


        [Route("api/Notificacao/GetAllNotificacaoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _NotificacaoAppServices.GetAllNotificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

                

        [Route("api/Notificacao/GetNotificacaoById")]
        [HttpPost]
        public HttpResponseMessage GetNotificacaoById(int NOT_Id, bool join, Log Log)
        {
            try
            {
                var item = _NotificacaoAppServices.GetNotificacaoById(NOT_Id, join);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Notificacao/GetListNotificacao")]
        [HttpPost]
        public HttpResponseMessage GetListNotificacao(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _NotificacaoAppServices.GetAllNotificacao(true, true, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }
        
        [Route("api/Notificacao/CadastroNotificacao")]
        [HttpPut]
        public HttpResponseMessage CadastroNotificacao(Notificacao objNotificacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objNotificacao.NOT_Id > 0)
                    {
                        var fUpdate = _NotificacaoAppServices.UpdateNotificacao(objNotificacao);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objNotificacao);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Notificacao());
                    }
                    else
                    {
                        var fInsert = _NotificacaoAppServices.InsertNotificacao(objNotificacao);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objNotificacao.Log,  e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objNotificacao);
            }
        }

    }
}
