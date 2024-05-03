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
    public class OfertaxQuantidadeProdutoController : ApiController
    {
        private readonly IOfertaxQuantidadeProdutoAppServices _OfertaxQuantidadeProdutoAppServices;

        public OfertaxQuantidadeProdutoController(IOfertaxQuantidadeProdutoAppServices OfertaxQuantidadeProdutoAppServices)
        {
            try
            {
                _OfertaxQuantidadeProdutoAppServices = OfertaxQuantidadeProdutoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/OfertaxQuantidadeProduto/AtivarOfertaxQuantidadeProduto")]
        [HttpPut]
        public HttpResponseMessage AtivarOfertaxQuantidadeProduto(int OXQ_Id, Log Log)
        {
            try
            {
                var item = _OfertaxQuantidadeProdutoAppServices.AtivarOfertaxQuantidadeProduto(OXQ_Id);
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

        [Route("api/OfertaxQuantidadeProduto/DeletarOfertaxQuantidadeProduto")]
        [HttpPut]
        public HttpResponseMessage DeletarOfertaxQuantidadeProduto(int OXQ_Id, Log Log)
        {
            try
            {
                var item = _OfertaxQuantidadeProdutoAppServices.DeletarOfertaxQuantidadeProduto(OXQ_Id);
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

        [Route("api/OfertaxQuantidadeProduto/GetAllOfertaxQuantidadeProduto")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxQuantidadeProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxQuantidadeProdutoAppServices.GetAllOfertaxQuantidadeProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/OfertaxQuantidadeProduto/GetAllOfertaxQuantidadeProdutoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxQuantidadeProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxQuantidadeProdutoAppServices.GetAllOfertaxQuantidadeProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/OfertaxQuantidadeProduto/GetAllOfertaxQuantidadeProdutoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxQuantidadeProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxQuantidadeProdutoAppServices.GetAllOfertaxQuantidadeProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/OfertaxQuantidadeProduto/GetOfertaxQuantidadeProdutoById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaxQuantidadeProdutoById(int OXQ_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaxQuantidadeProdutoAppServices.GetOfertaxQuantidadeProdutoById(OXQ_Id, join);
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

        [Route("api/OfertaxQuantidadeProduto/GetListOfertaxQuantidadeProduto")]
        [HttpPost]
        public HttpResponseMessage GetListOfertaxQuantidadeProduto(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxQuantidadeProdutoAppServices.GetAllOfertaxQuantidadeProduto(true, true, join, maxInstances, order_by);
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

        [Route("api/OfertaxQuantidadeProduto/CadastroOfertaxQuantidadeProduto")]
        [HttpPut]
        public HttpResponseMessage CadastroOfertaxQuantidadeProduto(OfertaxQuantidadeProduto objOfertaxQuantidadeProduto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objOfertaxQuantidadeProduto.OXQ_Id > 0)
                    {
                        var fUpdate = _OfertaxQuantidadeProdutoAppServices.UpdateOfertaxQuantidadeProduto(objOfertaxQuantidadeProduto);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objOfertaxQuantidadeProduto);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new OfertaxQuantidadeProduto());
                    }
                    else
                    {
                        var fInsert = _OfertaxQuantidadeProdutoAppServices.InsertOfertaxQuantidadeProduto(objOfertaxQuantidadeProduto);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objOfertaxQuantidadeProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objOfertaxQuantidadeProduto);
            }
        }

        [Route("api/OfertaxQuantidadeProduto/GetAllOfertaxQuantidadeProdutoByFiltro")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxQuantidadeProdutoByFiltro(Log Log, string produto = "", int idCategoria = 0, int idSistemaProdutivo = 0, int idModoProducao = 0, int idStatusProduto = 0, int anoColheita = 0, decimal peso = 0, int idVolume = 0, int maxInstances = 0, string order_by = "")
        {
            try
            {
                var item = _OfertaxQuantidadeProdutoAppServices.GetAllOfertaxQuantidadeProdutoByFiltro(produto, idCategoria, idSistemaProdutivo, idModoProducao, idStatusProduto, anoColheita, peso, idVolume, maxInstances, order_by);
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

    }
}