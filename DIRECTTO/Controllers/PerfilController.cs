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
    public class PerfilController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IPerfilAppServices _PerfilAppServices;

        public PerfilController(IPerfilAppServices PerfilAppServices)
        {
            try { 
                _PerfilAppServices = PerfilAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/Perfil/AtivarPerfil")]
        [HttpPost]
        public HttpResponseMessage AtivarPerfil(int PRF_Id, Log Log)
        {
            try
            {
                var item = _PerfilAppServices.AtivarPerfil(PRF_Id);
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

        [Route("api/Perfil/DeletarPerfil")]
        [HttpPost]
        public HttpResponseMessage DeletarPerfil(int PRF_Id, Log Log)
        {
            try
            {
                var item = _PerfilAppServices.DeletarPerfil(PRF_Id);
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

        [Route("api/Perfil/GetAllPerfil")]
        [HttpPost]
        public HttpResponseMessage GetAllPerfil(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilAppServices.GetAllPerfil(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/Perfil/GetAllPerfilByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllPerfilByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilAppServices.GetAllPerfilByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/Perfil/GetAllPerfilByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllPerfilByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilAppServices.GetAllPerfilByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/Perfil/GetPerfilById")]
        [HttpPost]
        public HttpResponseMessage GetPerfilById(int PRF_Id, bool join, Log Log)
        {
            try
            {
                var item = _PerfilAppServices.GetPerfilById(PRF_Id, join);
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

        [Route("api/Perfil/GetListPerfil")]
        [HttpPost]
        public HttpResponseMessage GetListPerfil(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilAppServices.GetAllPerfil(true, true, join, maxInstances, order_by);
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
        
        [Route("api/Perfil/CadastroPerfil")]
        [HttpPut]
        public HttpResponseMessage CadastroPerfil(Perfil objPerfil)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objPerfil.PRF_Id > 0)
                    {
                        var fUpdate = _PerfilAppServices.UpdatePerfil(objPerfil);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objPerfil);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Perfil());
                    }
                    else
                    {
                        var fInsert = _PerfilAppServices.InsertPerfil(objPerfil);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objPerfil.Log,  e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objPerfil);
            }
        }

    }
}
