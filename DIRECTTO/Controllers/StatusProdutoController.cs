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
    public class StatusProdutoController : ApiController
    {
        private readonly IStatusProdutoAppServices _StatusProdutoAppServices;

        public StatusProdutoController(IStatusProdutoAppServices StatusProdutoAppServices)
        {
            try
            {
                _StatusProdutoAppServices = StatusProdutoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/StatusProduto/AtivarStatusProduto")]
        [HttpPut]
        public HttpResponseMessage AtivarStatusProduto(int SPR_Id, Log Log)
        {
            try
            {
                var item = _StatusProdutoAppServices.AtivarStatusProduto(SPR_Id);
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

        [Route("api/StatusProduto/DeletarStatusProduto")]
        [HttpPut]
        public HttpResponseMessage DeletarStatusProduto(int SPR_Id, Log Log)
        {
            try
            {
                var item = _StatusProdutoAppServices.DeletarStatusProduto(SPR_Id);
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

        [Route("api/StatusProduto/GetAllStatusProduto")]
        [HttpPost]
        public HttpResponseMessage GetAllStatusProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusProdutoAppServices.GetAllStatusProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/StatusProduto/GetAllStatusProdutoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllStatusProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusProdutoAppServices.GetAllStatusProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/StatusProduto/GetAllStatusProdutoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllStatusProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusProdutoAppServices.GetAllStatusProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/StatusProduto/GetStatusProdutoById")]
        [HttpPost]
        public HttpResponseMessage GetStatusProdutoById(int SPR_Id, bool join, Log Log)
        {
            try
            {
                var item = _StatusProdutoAppServices.GetStatusProdutoById(SPR_Id, join);
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

        [Route("api/StatusProduto/GetListStatusProduto")]
        [HttpPost]
        public HttpResponseMessage GetListStatusProduto(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _StatusProdutoAppServices.GetAllStatusProduto(true, true, join, maxInstances, order_by);
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

        [Route("api/StatusProduto/CadastroStatusProduto")]
        [HttpPut]
        public HttpResponseMessage CadastroStatusProduto(StatusProduto objStatusProduto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objStatusProduto.SPR_Id > 0)
                    {
                        var fUpdate = _StatusProdutoAppServices.UpdateStatusProduto(objStatusProduto);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objStatusProduto);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new StatusProduto());
                    }
                    else
                    {
                        var fInsert = _StatusProdutoAppServices.InsertStatusProduto(objStatusProduto);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objStatusProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objStatusProduto);
            }
        }

    }
}
