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
    public class TipoProdutoController : ApiController
    {
        private readonly ITipoProdutoAppServices _TipoProdutoAppServices;

        public TipoProdutoController(ITipoProdutoAppServices TipoProdutoAppServices)
        {
            try
            {
                _TipoProdutoAppServices = TipoProdutoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TipoProduto/AtivarTipoProduto")]
        [HttpPut]
        public HttpResponseMessage AtivarTipoProduto(int TPR_Id, Log Log)
        {
            try
            {
                var item = _TipoProdutoAppServices.AtivarTipoProduto(TPR_Id);
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

        [Route("api/TipoProduto/DeletarTipoProduto")]
        [HttpPut]
        public HttpResponseMessage DeletarTipoProduto(int TPR_Id, Log Log)
        {
            try
            {
                var item = _TipoProdutoAppServices.DeletarTipoProduto(TPR_Id);
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

        [Route("api/TipoProduto/GetAllTipoProduto")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoProdutoAppServices.GetAllTipoProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TipoProduto/GetAllTipoProdutoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoProdutoAppServices.GetAllTipoProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TipoProduto/GetAllTipoProdutoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoProdutoAppServices.GetAllTipoProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/TipoProduto/GetTipoProdutoById")]
        [HttpPost]
        public HttpResponseMessage GetTipoProdutoById(int TPR_Id, bool join, Log Log)
        {
            try
            {
                var item = _TipoProdutoAppServices.GetTipoProdutoById(TPR_Id, join);
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

        [Route("api/TipoProduto/GetListTipoProduto")]
        [HttpPost]
        public HttpResponseMessage GetListTipoProduto(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoProdutoAppServices.GetAllTipoProduto(true, true, join, maxInstances, order_by);
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

        [Route("api/TipoProduto/CadastroTipoProduto")]
        [HttpPut]
        public HttpResponseMessage CadastroTipoProduto(TipoProduto objTipoProduto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTipoProduto.TPR_Id > 0)
                    {
                        var fUpdate = _TipoProdutoAppServices.UpdateTipoProduto(objTipoProduto);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTipoProduto);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TipoProduto());
                    }
                    else
                    {
                        var fInsert = _TipoProdutoAppServices.InsertTipoProduto(objTipoProduto);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTipoProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTipoProduto);
            }
        }

    }
}
