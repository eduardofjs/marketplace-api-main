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
    public class OfertaNegociacaoxStatusNegociacaoController : ApiController
    {
        private readonly IOfertaNegociacaoxStatusNegociacaoAppServices _OfertaNegociacaoxStatusNegociacaoAppServices;

        public OfertaNegociacaoxStatusNegociacaoController(IOfertaNegociacaoxStatusNegociacaoAppServices OfertaNegociacaoxStatusNegociacaoAppServices)
        {
            try
            {
                _OfertaNegociacaoxStatusNegociacaoAppServices = OfertaNegociacaoxStatusNegociacaoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/OfertaNegociacaoxStatusNegociacao/AtivarOfertaNegociacaoxStatusNegociacao")]
        [HttpPut]
        public HttpResponseMessage AtivarOfertaNegociacaoxStatusNegociacao(int ONS_Id, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxStatusNegociacaoAppServices.AtivarOfertaNegociacaoxStatusNegociacao(ONS_Id);
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

        [Route("api/OfertaNegociacaoxStatusNegociacao/DeletarOfertaNegociacaoxStatusNegociacao")]
        [HttpPut]
        public HttpResponseMessage DeletarOfertaNegociacaoxStatusNegociacao(int ONS_Id, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxStatusNegociacaoAppServices.DeletarOfertaNegociacaoxStatusNegociacao(ONS_Id);
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

        [Route("api/OfertaNegociacaoxStatusNegociacao/GetAllOfertaNegociacaoxStatusNegociacao")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaNegociacaoxStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxStatusNegociacaoAppServices.GetAllOfertaNegociacaoxStatusNegociacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/OfertaNegociacaoxStatusNegociacao/GetAllOfertaNegociacaoxStatusNegociacaoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaNegociacaoxStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxStatusNegociacaoAppServices.GetAllOfertaNegociacaoxStatusNegociacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/OfertaNegociacaoxStatusNegociacao/GetAllOfertaNegociacaoxStatusNegociacaoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaNegociacaoxStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxStatusNegociacaoAppServices.GetAllOfertaNegociacaoxStatusNegociacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/OfertaNegociacaoxStatusNegociacao/GetOfertaNegociacaoxStatusNegociacaoById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaNegociacaoxStatusNegociacaoById(int ONS_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxStatusNegociacaoAppServices.GetOfertaNegociacaoxStatusNegociacaoById(ONS_Id, join);
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

        [Route("api/OfertaNegociacaoxStatusNegociacao/GetListOfertaNegociacaoxStatusNegociacao")]
        [HttpPost]
        public HttpResponseMessage GetListOfertaNegociacaoxStatusNegociacao(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxStatusNegociacaoAppServices.GetAllOfertaNegociacaoxStatusNegociacao(true, true, join, maxInstances, order_by);
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

        [Route("api/OfertaNegociacaoxStatusNegociacao/CadastroOfertaNegociacaoxStatusNegociacao")]
        [HttpPut]
        public HttpResponseMessage CadastroOfertaNegociacaoxStatusNegociacao(OfertaNegociacaoxStatusNegociacao objOfertaNegociacaoxStatusNegociacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objOfertaNegociacaoxStatusNegociacao.ONS_Id > 0)
                    {
                        var fUpdate = _OfertaNegociacaoxStatusNegociacaoAppServices.UpdateOfertaNegociacaoxStatusNegociacao(objOfertaNegociacaoxStatusNegociacao);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objOfertaNegociacaoxStatusNegociacao);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new OfertaNegociacaoxStatusNegociacao());
                    }
                    else
                    {
                        var fInsert = _OfertaNegociacaoxStatusNegociacaoAppServices.InsertOfertaNegociacaoxStatusNegociacao(objOfertaNegociacaoxStatusNegociacao);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objOfertaNegociacaoxStatusNegociacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objOfertaNegociacaoxStatusNegociacao);
            }
        }

    }
}
