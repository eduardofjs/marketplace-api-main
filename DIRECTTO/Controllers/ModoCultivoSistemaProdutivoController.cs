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
    public class ModoCultivoSistemaProdutivoController : ApiController
    {
        private readonly IModoCultivoSistemaProdutivoAppServices _ModoCultivoSistemaProdutivoAppServices;

        public ModoCultivoSistemaProdutivoController(IModoCultivoSistemaProdutivoAppServices ModoCultivoSistemaProdutivoAppServices)
        {
            try
            {
                _ModoCultivoSistemaProdutivoAppServices = ModoCultivoSistemaProdutivoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/ModoCultivoSistemaProdutivo/AtivarModoCultivoSistemaProdutivo")]
        [HttpPut]
        public HttpResponseMessage AtivarModoCultivoSistemaProdutivo(int MCS_Id, Log Log)
        {
            try
            {
                var item = _ModoCultivoSistemaProdutivoAppServices.AtivarModoCultivoSistemaProdutivo(MCS_Id);
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

        [Route("api/ModoCultivoSistemaProdutivo/DeletarModoCultivoSistemaProdutivo")]
        [HttpPut]
        public HttpResponseMessage DeletarModoCultivoSistemaProdutivo(int MCS_Id, Log Log)
        {
            try
            {
                var item = _ModoCultivoSistemaProdutivoAppServices.DeletarModoCultivoSistemaProdutivo(MCS_Id);
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

        [Route("api/ModoCultivoSistemaProdutivo/GetAllModoCultivoSistemaProdutivo")]
        [HttpPost]
        public HttpResponseMessage GetAllModoCultivoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ModoCultivoSistemaProdutivoAppServices.GetAllModoCultivoSistemaProdutivo(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/ModoCultivoSistemaProdutivo/GetAllModoCultivoSistemaProdutivoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllModoCultivoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ModoCultivoSistemaProdutivoAppServices.GetAllModoCultivoSistemaProdutivoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/ModoCultivoSistemaProdutivo/GetAllModoCultivoSistemaProdutivoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllModoCultivoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ModoCultivoSistemaProdutivoAppServices.GetAllModoCultivoSistemaProdutivoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/ModoCultivoSistemaProdutivo/GetModoCultivoSistemaProdutivoById")]
        [HttpPost]
        public HttpResponseMessage GetModoCultivoSistemaProdutivoById(int MCS_Id, bool join, Log Log)
        {
            try
            {
                var item = _ModoCultivoSistemaProdutivoAppServices.GetModoCultivoSistemaProdutivoById(MCS_Id, join);
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

        [Route("api/ModoCultivoSistemaProdutivo/GetListModoCultivoSistemaProdutivo")]
        [HttpPost]
        public HttpResponseMessage GetListModoCultivoSistemaProdutivo(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ModoCultivoSistemaProdutivoAppServices.GetAllModoCultivoSistemaProdutivo(true, true, join, maxInstances, order_by);
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

        [Route("api/ModoCultivoSistemaProdutivo/CadastroModoCultivoSistemaProdutivo")]
        [HttpPut]
        public HttpResponseMessage CadastroModoCultivoSistemaProdutivo(ModoCultivoSistemaProdutivo objModoCultivoSistemaProdutivo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objModoCultivoSistemaProdutivo.MCS_Id > 0)
                    {
                        var fUpdate = _ModoCultivoSistemaProdutivoAppServices.UpdateModoCultivoSistemaProdutivo(objModoCultivoSistemaProdutivo);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objModoCultivoSistemaProdutivo);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new ModoCultivoSistemaProdutivo());
                    }
                    else
                    {
                        var fInsert = _ModoCultivoSistemaProdutivoAppServices.InsertModoCultivoSistemaProdutivo(objModoCultivoSistemaProdutivo);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objModoCultivoSistemaProdutivo.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objModoCultivoSistemaProdutivo);
            }
        }

    }
}
