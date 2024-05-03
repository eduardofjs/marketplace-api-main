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
    [MyBasicAuthenticationFilter]
    [LogActionFilter]
    public class BancoController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IBancoAppServices _BancoAppServices;

        public BancoController(IBancoAppServices BancoAppServices)
        {
            try { 
                _BancoAppServices = BancoAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
            }
        }

        [Route("api/Banco/AtivarBanco")]
        [HttpPut]
        public HttpResponseMessage AtivarBanco(int BAN_Id, Log Log)
        {
            try
            {
                var item = _BancoAppServices.AtivarBanco(BAN_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Banco/DeletarBanco")]
        [HttpPut]
        public HttpResponseMessage DeletarBanco(int BAN_Id, Log Log)
        {
            try
            {
                var item = _BancoAppServices.DeletarBanco(BAN_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Banco/GetAllBanco")]
        [HttpPost]
        public HttpResponseMessage GetAllBanco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _BancoAppServices.GetAllBanco(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Banco/GetAllBancoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllBancoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _BancoAppServices.GetAllBancoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }


        [Route("api/Banco/GetAllBancoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllBancoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _BancoAppServices.GetAllBancoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

                

        [Route("api/Banco/GetBancoById")]
        [HttpPost]
        public HttpResponseMessage GetBancoById(int BAN_Id, bool join, Log Log)
        {
            try
            {
                var item = _BancoAppServices.GetBancoById(BAN_Id, join);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Banco/GetListBanco")]
        [HttpPost]
        public HttpResponseMessage GetListBanco(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _BancoAppServices.GetAllBanco(true, true, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }
        
        [Route("api/Banco/CadastroBanco")]
        [HttpPut]
        public HttpResponseMessage CadastroBanco(Banco objBanco)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objBanco.BAN_Id > 0)
                    {
                        var fUpdate = _BancoAppServices.UpdateBanco(objBanco);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objBanco);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Banco());
                    }
                    else
                    {
                        var fInsert = _BancoAppServices.InsertBanco(objBanco);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    log.Error("Error", e);
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objBanco);
            }
        }

    }
}
