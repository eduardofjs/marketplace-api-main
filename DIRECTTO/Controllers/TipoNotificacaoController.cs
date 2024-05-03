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
    public class TipoNotificacaoController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ITipoNotificacaoAppServices _TipoNotificacaoAppServices;

        public TipoNotificacaoController(ITipoNotificacaoAppServices TipoNotificacaoAppServices)
        {
            try { 
                _TipoNotificacaoAppServices = TipoNotificacaoAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TipoNotificacao/AtivarTipoNotificacao")]
        [HttpPost]
        public HttpResponseMessage AtivarTipoNotificacao(int TPN_Id, Log Log)
        {
            try
            {
                var item = _TipoNotificacaoAppServices.AtivarTipoNotificacao(TPN_Id);
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

        [Route("api/TipoNotificacao/DeletarTipoNotificacao")]
        [HttpPost]
        public HttpResponseMessage DeletarTipoNotificacao(int TPN_Id, Log Log)
        {
            try
            {
                var item = _TipoNotificacaoAppServices.DeletarTipoNotificacao(TPN_Id);
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

        [Route("api/TipoNotificacao/GetAllTipoNotificacao")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoNotificacaoAppServices.GetAllTipoNotificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TipoNotificacao/GetAllTipoNotificacaoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoNotificacaoAppServices.GetAllTipoNotificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TipoNotificacao/GetAllTipoNotificacaoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoNotificacaoAppServices.GetAllTipoNotificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/TipoNotificacao/GetTipoNotificacaoById")]
        [HttpPost]
        public HttpResponseMessage GetTipoNotificacaoById(int TPN_Id, bool join, Log Log)
        {
            try
            {
                var item = _TipoNotificacaoAppServices.GetTipoNotificacaoById(TPN_Id, join);
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

        [Route("api/TipoNotificacao/GetListTipoNotificacao")]
        [HttpPost]
        public HttpResponseMessage GetListTipoNotificacao(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoNotificacaoAppServices.GetAllTipoNotificacao(true, true, join, maxInstances, order_by);
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
        
        [Route("api/TipoNotificacao/CadastroTipoNotificacao")]
        [HttpPut]
        public HttpResponseMessage CadastroTipoNotificacao(TipoNotificacao objTipoNotificacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTipoNotificacao.TPN_Id > 0)
                    {
                        var fUpdate = _TipoNotificacaoAppServices.UpdateTipoNotificacao(objTipoNotificacao);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTipoNotificacao);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TipoNotificacao());
                    }
                    else
                    {
                        var fInsert = _TipoNotificacaoAppServices.InsertTipoNotificacao(objTipoNotificacao);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTipoNotificacao.Log,  e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTipoNotificacao);
            }
        }

    }
}
