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
    public class TipoEmpresaController : ApiController
    {
        private readonly ITipoEmpresaAppServices _TipoEmpresaAppServices;

        public TipoEmpresaController(ITipoEmpresaAppServices TipoEmpresaAppServices)
        {
            try
            {
                _TipoEmpresaAppServices = TipoEmpresaAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TipoEmpresa/AtivarTipoEmpresa")]
        [HttpPut]
        public HttpResponseMessage AtivarTipoEmpresa(int TEM_Id, Log Log)
        {
            try
            {
                var item = _TipoEmpresaAppServices.AtivarTipoEmpresa(TEM_Id);
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

        [Route("api/TipoEmpresa/DeletarTipoEmpresa")]
        [HttpPut]
        public HttpResponseMessage DeletarTipoEmpresa(int TEM_Id, Log Log)
        {
            try
            {
                var item = _TipoEmpresaAppServices.DeletarTipoEmpresa(TEM_Id);
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

        [Route("api/TipoEmpresa/GetAllTipoEmpresa")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoEmpresaAppServices.GetAllTipoEmpresa(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TipoEmpresa/GetAllTipoEmpresaByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoEmpresaAppServices.GetAllTipoEmpresaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TipoEmpresa/GetAllTipoEmpresaByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoEmpresaAppServices.GetAllTipoEmpresaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/TipoEmpresa/GetTipoEmpresaById")]
        [HttpPost]
        public HttpResponseMessage GetTipoEmpresaById(int TEM_Id, bool join, Log Log)
        {
            try
            {
                var item = _TipoEmpresaAppServices.GetTipoEmpresaById(TEM_Id, join);
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

        [Route("api/TipoEmpresa/GetListTipoEmpresa")]
        [HttpPost]
        public HttpResponseMessage GetListTipoEmpresa(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoEmpresaAppServices.GetAllTipoEmpresa(true, true, join, maxInstances, order_by);
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

        [Route("api/TipoEmpresa/CadastroTipoEmpresa")]
        [HttpPut]
        public HttpResponseMessage CadastroTipoEmpresa(TipoEmpresa objTipoEmpresa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTipoEmpresa.TEM_Id > 0)
                    {
                        var fUpdate = _TipoEmpresaAppServices.UpdateTipoEmpresa(objTipoEmpresa);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTipoEmpresa);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TipoEmpresa());
                    }
                    else
                    {
                        var fInsert = _TipoEmpresaAppServices.InsertTipoEmpresa(objTipoEmpresa);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTipoEmpresa.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTipoEmpresa);
            }
        }

    }
}