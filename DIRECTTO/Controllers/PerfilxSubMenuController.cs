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
    public class PerfilxSubMenuController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IPerfilxSubMenuAppServices _PerfilxSubMenuAppServices;

        public PerfilxSubMenuController(IPerfilxSubMenuAppServices PerfilxSubMenuAppServices)
        {
            try { 
                _PerfilxSubMenuAppServices = PerfilxSubMenuAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/PerfilxSubMenu/AtivarPerfilxSubMenu")]
        [HttpPost]
        public HttpResponseMessage AtivarPerfilxSubMenu(int PXS_Id, Log Log)
        {
            try
            {
                var item = _PerfilxSubMenuAppServices.AtivarPerfilxSubMenu(PXS_Id);
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

        [Route("api/PerfilxSubMenu/DeletarPerfilxSubMenu")]
        [HttpPost]
        public HttpResponseMessage DeletarPerfilxSubMenu(int PXS_SubMenuId, int PXS_PerfilId, Log Log)
        {
            try
            {
                var item = _PerfilxSubMenuAppServices.DeletarPerfilxSubMenu(PXS_SubMenuId, PXS_PerfilId);
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

        [Route("api/PerfilxSubMenu/GetAllPerfilxSubMenu")]
        [HttpPost]
        public HttpResponseMessage GetAllPerfilxSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilxSubMenuAppServices.GetAllPerfilxSubMenu(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/PerfilxSubMenu/GetAllPerfilxSubMenuByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllPerfilxSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilxSubMenuAppServices.GetAllPerfilxSubMenuByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/PerfilxSubMenu/GetAllPerfilxSubMenuByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllPerfilxSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilxSubMenuAppServices.GetAllPerfilxSubMenuByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/PerfilxSubMenu/GetPerfilxSubMenuById")]
        [HttpPost]
        public HttpResponseMessage GetPerfilxSubMenuById(int PXS_Id, bool join, Log Log)
        {
            try
            {
                var item = _PerfilxSubMenuAppServices.GetPerfilxSubMenuById(PXS_Id, join);
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

        [Route("api/PerfilxSubMenu/GetListPerfilxSubMenu")]
        [HttpPost]
        public HttpResponseMessage GetListPerfilxSubMenu(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PerfilxSubMenuAppServices.GetAllPerfilxSubMenu(true, true, join, maxInstances, order_by);
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
        
        [Route("api/PerfilxSubMenu/CadastroPerfilxSubMenu")]
        [HttpPut]
        public HttpResponseMessage CadastroPerfilxSubMenu(PerfilxSubMenu objPerfilxSubMenu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objPerfilxSubMenu.PXS_Id > 0)
                    {
                        var fUpdate = _PerfilxSubMenuAppServices.UpdatePerfilxSubMenu(objPerfilxSubMenu);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objPerfilxSubMenu);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new PerfilxSubMenu());
                    }
                    else
                    {
                        var fInsert = _PerfilxSubMenuAppServices.InsertPerfilxSubMenu(objPerfilxSubMenu);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objPerfilxSubMenu.Log,  e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objPerfilxSubMenu);
            }
        }

    }
}
