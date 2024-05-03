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
    public class PerfilxUsuarioController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IPerfilxUsuarioAppServices _PerfilxUsuarioAppServices;

        public PerfilxUsuarioController(IPerfilxUsuarioAppServices PerfilxUsuarioAppServices)
        {
            try { 
                _PerfilxUsuarioAppServices = PerfilxUsuarioAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/PerfilxUsuario/AtivarPerfilxUsuario")]
        [HttpPost]
        public HttpResponseMessage AtivarPerfilxUsuario(int PXU_Id, Log Log)
        {
            try
            {
                var item = _PerfilxUsuarioAppServices.AtivarPerfilxUsuario(PXU_Id);
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

        [Route("api/PerfilxUsuario/DeletarPerfilxUsuario")]
        [HttpPost]
        public HttpResponseMessage DeletarPerfilxUsuario(int PXU_PerfilId, int PXU_UsuarioId, Log Log)
        {
            try
            {
                var item = _PerfilxUsuarioAppServices.DeletarPerfilxUsuario(PXU_PerfilId, PXU_UsuarioId);
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

        [Route("api/PerfilxUsuario/GetAllPerfilxUsuario")]
        [HttpPost]
        public HttpResponseMessage GetAllPerfilxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilxUsuarioAppServices.GetAllPerfilxUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/PerfilxUsuario/GetAllPerfilxUsuarioByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllPerfilxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilxUsuarioAppServices.GetAllPerfilxUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/PerfilxUsuario/GetAllPerfilxUsuarioByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllPerfilxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilxUsuarioAppServices.GetAllPerfilxUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/PerfilxUsuario/GetPerfilxUsuarioById")]
        [HttpPost]
        public HttpResponseMessage GetPerfilxUsuarioById(int PXU_Id, bool join, Log Log)
        {
            try
            {
                var item = _PerfilxUsuarioAppServices.GetPerfilxUsuarioById(PXU_Id, join);
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

        [Route("api/PerfilxUsuario/GetListPerfilxUsuario")]
        [HttpPost]
        public HttpResponseMessage GetListPerfilxUsuario(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilxUsuarioAppServices.GetAllPerfilxUsuario(true, true, join, maxInstances, order_by);
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
        
        [Route("api/PerfilxUsuario/CadastroPerfilxUsuario")]
        [HttpPut]
        public HttpResponseMessage CadastroPerfilxUsuario(PerfilxUsuario objPerfilxUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objPerfilxUsuario.PXU_Id > 0)
                    {
                        var fUpdate = _PerfilxUsuarioAppServices.UpdatePerfilxUsuario(objPerfilxUsuario);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objPerfilxUsuario);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new PerfilxUsuario());
                    }
                    else
                    {
                        var fInsert = _PerfilxUsuarioAppServices.InsertPerfilxUsuario(objPerfilxUsuario);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objPerfilxUsuario.Log,  e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objPerfilxUsuario);
            }
        }

        [Route("api/PerfilxUsuario/ListasPerfilxUsuario")]
        [HttpPut]
        public HttpResponseMessage ListasPerfilxUsuario(List<PerfilxUsuario> registrosPerfilxUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var flag = _PerfilxUsuarioAppServices.ListasPerfilxUsuario(registrosPerfilxUsuario);
                    if (flag)
                        return Request.CreateResponse(HttpStatusCode.OK, registrosPerfilxUsuario);
                    else
                        return Request.CreateResponse(HttpStatusCode.OK, new List<PerfilxUsuario>());
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLogError(registrosPerfilxUsuario[0].Log, "PerfilxUsuarioController", "ListasPerfilxUsuario", e.InnerException.ToString(), e.Message, e.StackTrace, "");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, registrosPerfilxUsuario);
            }

        }

    }
}
