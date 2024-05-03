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
    public class ConfiguracaoGlobalController : ApiController
    {
        private readonly IConfiguracaoGlobalAppServices _ConfiguracaoGlobalAppServices;

        public ConfiguracaoGlobalController(IConfiguracaoGlobalAppServices ConfiguracaoGlobalAppServices)
        {
            try { 
                _ConfiguracaoGlobalAppServices = ConfiguracaoGlobalAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/ConfiguracaoGlobal/AtivarConfiguracaoGlobal")]
        [HttpPut]
        public HttpResponseMessage AtivarConfiguracaoGlobal(int CGL_Id, Log Log)
        {
            try
            {
                var item = _ConfiguracaoGlobalAppServices.AtivarConfiguracaoGlobal(CGL_Id);
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

        [Route("api/ConfiguracaoGlobal/DeletarConfiguracaoGlobal")]
        [HttpPost]
        public HttpResponseMessage DeletarConfiguracaoGlobal(int CGL_Id, Log Log)
        {
            try
            {
                var item = _ConfiguracaoGlobalAppServices.DeletarConfiguracaoGlobal(CGL_Id);
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

        [Route("api/ConfiguracaoGlobal/GetAllConfiguracaoGlobal")]
        [HttpPost]
        public HttpResponseMessage GetAllConfiguracaoGlobal(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ConfiguracaoGlobalAppServices.GetAllConfiguracaoGlobal(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/ConfiguracaoGlobal/GetAllConfiguracaoGlobalByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllConfiguracaoGlobalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ConfiguracaoGlobalAppServices.GetAllConfiguracaoGlobalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/ConfiguracaoGlobal/GetAllConfiguracaoGlobalByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllConfiguracaoGlobalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ConfiguracaoGlobalAppServices.GetAllConfiguracaoGlobalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/ConfiguracaoGlobal/GetConfiguracaoGlobalById")]
        [HttpPost]
        public HttpResponseMessage GetConfiguracaoGlobalById(int CGL_Id, bool join, Log Log)
        {
            try
            {
                var item = _ConfiguracaoGlobalAppServices.GetConfiguracaoGlobalById(CGL_Id, join);
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

        [Route("api/ConfiguracaoGlobal/GetListConfiguracaoGlobal")]
        [HttpPost]
        public HttpResponseMessage GetListConfiguracaoGlobal(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ConfiguracaoGlobalAppServices.GetAllConfiguracaoGlobal(true, true, join, maxInstances, order_by);
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
        
        [Route("api/ConfiguracaoGlobal/CadastroConfiguracaoGlobal")]
        [HttpPut]
        public HttpResponseMessage CadastroConfiguracaoGlobal(ConfiguracaoGlobal objConfiguracaoGlobal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objConfiguracaoGlobal.CGL_Id > 0)
                    {
                        var fUpdate = _ConfiguracaoGlobalAppServices.UpdateConfiguracaoGlobal(objConfiguracaoGlobal);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objConfiguracaoGlobal);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new ConfiguracaoGlobal());
                    }
                    else
                    {
                        var fInsert = _ConfiguracaoGlobalAppServices.InsertConfiguracaoGlobal(objConfiguracaoGlobal);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objConfiguracaoGlobal.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objConfiguracaoGlobal);
            }
        }

    }
}
