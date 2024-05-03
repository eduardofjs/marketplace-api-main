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
    public class TipoCertificacaoController : ApiController
    {
        private readonly ITipoCertificacaoAppServices _TipoCertificacaoAppServices;

        public TipoCertificacaoController(ITipoCertificacaoAppServices TipoCertificacaoAppServices)
        {
            try
            {
                _TipoCertificacaoAppServices = TipoCertificacaoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TipoCertificacao/AtivarTipoCertificacao")]
        [HttpPut]
        public HttpResponseMessage AtivarTipoCertificacao(int TPC_Id, Log Log)
        {
            try
            {
                var item = _TipoCertificacaoAppServices.AtivarTipoCertificacao(TPC_Id);
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

        [Route("api/TipoCertificacao/DeletarTipoCertificacao")]
        [HttpPut]
        public HttpResponseMessage DeletarTipoCertificacao(int TPC_Id, Log Log)
        {
            try
            {
                var item = _TipoCertificacaoAppServices.DeletarTipoCertificacao(TPC_Id);
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

        [Route("api/TipoCertificacao/GetAllTipoCertificacao")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoCertificacaoAppServices.GetAllTipoCertificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TipoCertificacao/GetAllTipoCertificacaoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoCertificacaoAppServices.GetAllTipoCertificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TipoCertificacao/GetAllTipoCertificacaoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoCertificacaoAppServices.GetAllTipoCertificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/TipoCertificacao/GetTipoCertificacaoById")]
        [HttpPost]
        public HttpResponseMessage GetTipoCertificacaoById(int TPC_Id, bool join, Log Log)
        {
            try
            {
                var item = _TipoCertificacaoAppServices.GetTipoCertificacaoById(TPC_Id, join);
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

        [Route("api/TipoCertificacao/GetListTipoCertificacao")]
        [HttpPost]
        public HttpResponseMessage GetListTipoCertificacao(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoCertificacaoAppServices.GetAllTipoCertificacao(true, true, join, maxInstances, order_by);
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

        [Route("api/TipoCertificacao/CadastroTipoCertificacao")]
        [HttpPut]
        public HttpResponseMessage CadastroTipoCertificacao(TipoCertificacao objTipoCertificacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTipoCertificacao.TPC_Id > 0)
                    {
                        var fUpdate = _TipoCertificacaoAppServices.UpdateTipoCertificacao(objTipoCertificacao);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTipoCertificacao);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TipoCertificacao());
                    }
                    else
                    {
                        var fInsert = _TipoCertificacaoAppServices.InsertTipoCertificacao(objTipoCertificacao);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTipoCertificacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTipoCertificacao);
            }
        }

    }
}
