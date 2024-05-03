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
    public class TipoTransacaoLogController : ApiController
    {
        private readonly ITipoTransacaoLogAppServices _TipoTransacaoLogAppServices;

        public TipoTransacaoLogController(ITipoTransacaoLogAppServices TipoTransacaoLogAppServices)
        {
            try { 
                _TipoTransacaoLogAppServices = TipoTransacaoLogAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TipoTransacaoLog/AtivarTipoTransacaoLog")]
        [HttpPut]
        public HttpResponseMessage AtivarTipoTransacaoLog(int TTL_Id, Log Log)
        {
            try
            {
                var item = _TipoTransacaoLogAppServices.AtivarTipoTransacaoLog(TTL_Id);
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

        [Route("api/TipoTransacaoLog/DeletarTipoTransacaoLog")]
        [HttpPut]
        public HttpResponseMessage DeletarTipoTransacaoLog(int TTL_Id, Log Log)
        {
            try
            {
                var item = _TipoTransacaoLogAppServices.DeletarTipoTransacaoLog(TTL_Id);
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

        [Route("api/TipoTransacaoLog/GetAllTipoTransacaoLog")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoTransacaoLog(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoTransacaoLogAppServices.GetAllTipoTransacaoLog(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TipoTransacaoLog/GetAllTipoTransacaoLogByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoTransacaoLogByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoTransacaoLogAppServices.GetAllTipoTransacaoLogByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TipoTransacaoLog/GetAllTipoTransacaoLogByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoTransacaoLogByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoTransacaoLogAppServices.GetAllTipoTransacaoLogByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/TipoTransacaoLog/GetTipoTransacaoLogById")]
        [HttpPost]
        public HttpResponseMessage GetTipoTransacaoLogById(int TTL_Id, bool join, Log Log)
        {
            try
            {
                var item = _TipoTransacaoLogAppServices.GetTipoTransacaoLogById(TTL_Id, join);
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

        [Route("api/TipoTransacaoLog/GetListTipoTransacaoLog")]
        [HttpPost]
        public HttpResponseMessage GetListTipoTransacaoLog(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoTransacaoLogAppServices.GetAllTipoTransacaoLog(true, true, join, maxInstances, order_by);
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
        
        [Route("api/TipoTransacaoLog/CadastroTipoTransacaoLog")]
        [HttpPut]
        public HttpResponseMessage CadastroTipoTransacaoLog(TipoTransacaoLog objTipoTransacaoLog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTipoTransacaoLog.TTL_Id > 0)
                    {
                        var fUpdate = _TipoTransacaoLogAppServices.UpdateTipoTransacaoLog(objTipoTransacaoLog);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTipoTransacaoLog);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TipoTransacaoLog());
                    }
                    else
                    {
                        var fInsert = _TipoTransacaoLogAppServices.InsertTipoTransacaoLog(objTipoTransacaoLog);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTipoTransacaoLog.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTipoTransacaoLog);
            }
        }

    }
}
