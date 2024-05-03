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
    public class PronomeTratamentoController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IPronomeTratamentoAppServices _PronomeTratamentoAppServices;

        public PronomeTratamentoController(IPronomeTratamentoAppServices PronomeTratamentoAppServices)
        {
            try { 
                _PronomeTratamentoAppServices = PronomeTratamentoAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/PronomeTratamento/AtivarPronomeTratamento")]
        [HttpPost]
        public HttpResponseMessage AtivarPronomeTratamento(int PRT_Id, Log Log)
        {
            try
            {
                var item = _PronomeTratamentoAppServices.AtivarPronomeTratamento(PRT_Id);
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

        [Route("api/PronomeTratamento/DeletarPronomeTratamento")]
        [HttpPost]
        public HttpResponseMessage DeletarPronomeTratamento(int PRT_Id, Log Log)
        {
            try
            {
                var item = _PronomeTratamentoAppServices.DeletarPronomeTratamento(PRT_Id);
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

        [Route("api/PronomeTratamento/GetAllPronomeTratamento")]
        [HttpPost]
        public HttpResponseMessage GetAllPronomeTratamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PronomeTratamentoAppServices.GetAllPronomeTratamento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/PronomeTratamento/GetAllPronomeTratamentoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllPronomeTratamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PronomeTratamentoAppServices.GetAllPronomeTratamentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/PronomeTratamento/GetAllPronomeTratamentoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllPronomeTratamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PronomeTratamentoAppServices.GetAllPronomeTratamentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/PronomeTratamento/GetPronomeTratamentoById")]
        [HttpPost]
        public HttpResponseMessage GetPronomeTratamentoById(int PRT_Id, bool join, Log Log)
        {
            try
            {
                var item = _PronomeTratamentoAppServices.GetPronomeTratamentoById(PRT_Id, join);
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

        [Route("api/PronomeTratamento/GetListPronomeTratamento")]
        [HttpPost]
        public HttpResponseMessage GetListPronomeTratamento(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PronomeTratamentoAppServices.GetAllPronomeTratamento(true, true, join, maxInstances, order_by);
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
        
        [Route("api/PronomeTratamento/CadastroPronomeTratamento")]
        [HttpPut]
        public HttpResponseMessage CadastroPronomeTratamento(PronomeTratamento objPronomeTratamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objPronomeTratamento.PRT_Id > 0)
                    {
                        var fUpdate = _PronomeTratamentoAppServices.UpdatePronomeTratamento(objPronomeTratamento);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objPronomeTratamento);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new PronomeTratamento());
                    }
                    else
                    {
                        var fInsert = _PronomeTratamentoAppServices.InsertPronomeTratamento(objPronomeTratamento);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objPronomeTratamento.Log,  e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objPronomeTratamento);
            }
        }

    }
}
