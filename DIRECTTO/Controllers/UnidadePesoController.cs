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
    public class UnidadePesoController : ApiController
    {
        private readonly IUnidadePesoAppServices _UnidadePesoAppServices;

        public UnidadePesoController(IUnidadePesoAppServices UnidadePesoAppServices)
        {
            try
            {
                _UnidadePesoAppServices = UnidadePesoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/UnidadePeso/AtivarUnidadePeso")]
        [HttpPut]
        public HttpResponseMessage AtivarUnidadePeso(int UNP_Id, Log Log)
        {
            try
            {
                var item = _UnidadePesoAppServices.AtivarUnidadePeso(UNP_Id);
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

        [Route("api/UnidadePeso/DeletarUnidadePeso")]
        [HttpPut]
        public HttpResponseMessage DeletarUnidadePeso(int UNP_Id, Log Log)
        {
            try
            {
                var item = _UnidadePesoAppServices.DeletarUnidadePeso(UNP_Id);
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

        [Route("api/UnidadePeso/GetAllUnidadePeso")]
        [HttpPost]
        public HttpResponseMessage GetAllUnidadePeso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _UnidadePesoAppServices.GetAllUnidadePeso(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/UnidadePeso/GetAllUnidadePesoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllUnidadePesoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _UnidadePesoAppServices.GetAllUnidadePesoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/UnidadePeso/GetAllUnidadePesoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllUnidadePesoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _UnidadePesoAppServices.GetAllUnidadePesoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/UnidadePeso/GetUnidadePesoById")]
        [HttpPost]
        public HttpResponseMessage GetUnidadePesoById(int UNP_Id, bool join, Log Log)
        {
            try
            {
                var item = _UnidadePesoAppServices.GetUnidadePesoById(UNP_Id, join);
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

        [Route("api/UnidadePeso/GetListUnidadePeso")]
        [HttpPost]
        public HttpResponseMessage GetListUnidadePeso(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _UnidadePesoAppServices.GetAllUnidadePeso(true, true, join, maxInstances, order_by);
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

        [Route("api/UnidadePeso/CadastroUnidadePeso")]
        [HttpPut]
        public HttpResponseMessage CadastroUnidadePeso(UnidadePeso objUnidadePeso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objUnidadePeso.UNP_Id > 0)
                    {
                        var fUpdate = _UnidadePesoAppServices.UpdateUnidadePeso(objUnidadePeso);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objUnidadePeso);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new UnidadePeso());
                    }
                    else
                    {
                        var fInsert = _UnidadePesoAppServices.InsertUnidadePeso(objUnidadePeso);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objUnidadePeso.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objUnidadePeso);
            }
        }

    }
}
