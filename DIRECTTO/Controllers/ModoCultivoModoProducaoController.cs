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
    public class ModoCultivoModoProducaoController : ApiController
    {
        private readonly IModoCultivoModoProducaoAppServices _ModoCultivoModoProducaoAppServices;

        public ModoCultivoModoProducaoController(IModoCultivoModoProducaoAppServices ModoCultivoModoProducaoAppServices)
        {
            try
            {
                _ModoCultivoModoProducaoAppServices = ModoCultivoModoProducaoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/ModoCultivoModoProducao/AtivarModoCultivoModoProducao")]
        [HttpPut]
        public HttpResponseMessage AtivarModoCultivoModoProducao(int MCM_Id, Log Log)
        {
            try
            {
                var item = _ModoCultivoModoProducaoAppServices.AtivarModoCultivoModoProducao(MCM_Id);
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

        [Route("api/ModoCultivoModoProducao/DeletarModoCultivoModoProducao")]
        [HttpPut]
        public HttpResponseMessage DeletarModoCultivoModoProducao(int MCM_Id, Log Log)
        {
            try
            {
                var item = _ModoCultivoModoProducaoAppServices.DeletarModoCultivoModoProducao(MCM_Id);
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

        [Route("api/ModoCultivoModoProducao/GetAllModoCultivoModoProducao")]
        [HttpPost]
        public HttpResponseMessage GetAllModoCultivoModoProducao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ModoCultivoModoProducaoAppServices.GetAllModoCultivoModoProducao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/ModoCultivoModoProducao/GetAllModoCultivoModoProducaoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllModoCultivoModoProducaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ModoCultivoModoProducaoAppServices.GetAllModoCultivoModoProducaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/ModoCultivoModoProducao/GetAllModoCultivoModoProducaoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllModoCultivoModoProducaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ModoCultivoModoProducaoAppServices.GetAllModoCultivoModoProducaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/ModoCultivoModoProducao/GetModoCultivoModoProducaoById")]
        [HttpPost]
        public HttpResponseMessage GetModoCultivoModoProducaoById(int MCM_Id, bool join, Log Log)
        {
            try
            {
                var item = _ModoCultivoModoProducaoAppServices.GetModoCultivoModoProducaoById(MCM_Id, join);
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

        [Route("api/ModoCultivoModoProducao/GetListModoCultivoModoProducao")]
        [HttpPost]
        public HttpResponseMessage GetListModoCultivoModoProducao(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ModoCultivoModoProducaoAppServices.GetAllModoCultivoModoProducao(true, true, join, maxInstances, order_by);
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

        [Route("api/ModoCultivoModoProducao/CadastroModoCultivoModoProducao")]
        [HttpPut]
        public HttpResponseMessage CadastroModoCultivoModoProducao(ModoCultivoModoProducao objModoCultivoModoProducao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objModoCultivoModoProducao.MCM_Id > 0)
                    {
                        var fUpdate = _ModoCultivoModoProducaoAppServices.UpdateModoCultivoModoProducao(objModoCultivoModoProducao);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objModoCultivoModoProducao);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new ModoCultivoModoProducao());
                    }
                    else
                    {
                        var fInsert = _ModoCultivoModoProducaoAppServices.InsertModoCultivoModoProducao(objModoCultivoModoProducao);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objModoCultivoModoProducao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objModoCultivoModoProducao);
            }
        }

    }
}
