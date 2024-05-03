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
    public class OfertaxCertificacaoController : ApiController
    {
        private readonly IOfertaxCertificacaoAppServices _OfertaxCertificacaoAppServices;

        public OfertaxCertificacaoController(IOfertaxCertificacaoAppServices OfertaxCertificacaoAppServices)
        {
            try
            {
                _OfertaxCertificacaoAppServices = OfertaxCertificacaoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/OfertaxCertificacao/AtivarOfertaxCertificacao")]
        [HttpPut]
        public HttpResponseMessage AtivarOfertaxCertificacao(int OXC_Id, Log Log)
        {
            try
            {
                var item = _OfertaxCertificacaoAppServices.AtivarOfertaxCertificacao(OXC_Id);
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

        [Route("api/OfertaxCertificacao/DeletarOfertaxCertificacao")]
        [HttpPut]
        public HttpResponseMessage DeletarOfertaxCertificacao(int OXC_Id, Log Log)
        {
            try
            {
                var item = _OfertaxCertificacaoAppServices.DeletarOfertaxCertificacao(OXC_Id);
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

        [Route("api/OfertaxCertificacao/GetAllOfertaxCertificacao")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxCertificacaoAppServices.GetAllOfertaxCertificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/OfertaxCertificacao/GetAllOfertaxCertificacaoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxCertificacaoAppServices.GetAllOfertaxCertificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/OfertaxCertificacao/GetAllOfertaxCertificacaoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxCertificacaoAppServices.GetAllOfertaxCertificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/OfertaxCertificacao/GetOfertaxCertificacaoById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaxCertificacaoById(int OXC_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaxCertificacaoAppServices.GetOfertaxCertificacaoById(OXC_Id, join);
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

        [Route("api/OfertaxCertificacao/GetListOfertaxCertificacao")]
        [HttpPost]
        public HttpResponseMessage GetListOfertaxCertificacao(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxCertificacaoAppServices.GetAllOfertaxCertificacao(true, true, join, maxInstances, order_by);
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

        [Route("api/OfertaxCertificacao/CadastroOfertaxCertificacao")]
        [HttpPut]
        public HttpResponseMessage CadastroOfertaxCertificacao(OfertaxCertificacao objOfertaxCertificacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objOfertaxCertificacao.OXC_Id > 0)
                    {
                        var fUpdate = _OfertaxCertificacaoAppServices.UpdateOfertaxCertificacao(objOfertaxCertificacao);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objOfertaxCertificacao);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new OfertaxCertificacao());
                    }
                    else
                    {
                        var fInsert = _OfertaxCertificacaoAppServices.InsertOfertaxCertificacao(objOfertaxCertificacao);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objOfertaxCertificacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objOfertaxCertificacao);
            }
        }

    }
}
