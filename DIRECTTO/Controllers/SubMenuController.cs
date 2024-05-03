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
    public class SubMenuController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ISubMenuAppServices _SubMenuAppServices;

        public SubMenuController(ISubMenuAppServices SubMenuAppServices)
        {
            try { 
                _SubMenuAppServices = SubMenuAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/SubMenu/AtivarSubMenu")]
        [HttpPost]
        public HttpResponseMessage AtivarSubMenu(int SBM_Id, Log Log)
        {
            try
            {
                var item = _SubMenuAppServices.AtivarSubMenu(SBM_Id);
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

        [Route("api/SubMenu/DeletarSubMenu")]
        [HttpPost]
        public HttpResponseMessage DeletarSubMenu(int SBM_Id, Log Log)
        {
            try
            {
                var item = _SubMenuAppServices.DeletarSubMenu(SBM_Id);
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

        [Route("api/SubMenu/GetAllSubMenu")]
        [HttpPost]
        public HttpResponseMessage GetAllSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _SubMenuAppServices.GetAllSubMenu(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/SubMenu/GetAllSubMenuByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _SubMenuAppServices.GetAllSubMenuByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/SubMenu/GetAllSubMenuByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _SubMenuAppServices.GetAllSubMenuByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/SubMenu/GetSubMenuById")]
        [HttpPost]
        public HttpResponseMessage GetSubMenuById(int SBM_Id, bool join, Log Log)
        {
            try
            {
                var item = _SubMenuAppServices.GetSubMenuById(SBM_Id, join);
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

        [Route("api/SubMenu/GetListSubMenu")]
        [HttpPost]
        public HttpResponseMessage GetListSubMenu(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _SubMenuAppServices.GetAllSubMenu(true, true, join, maxInstances, order_by);
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
        
        [Route("api/SubMenu/CadastroSubMenu")]
        [HttpPut]
        public HttpResponseMessage CadastroSubMenu(SubMenu objSubMenu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objSubMenu.SBM_Id > 0)
                    {
                        var fUpdate = _SubMenuAppServices.UpdateSubMenu(objSubMenu);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objSubMenu);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new SubMenu());
                    }
                    else
                    {
                        var fInsert = _SubMenuAppServices.InsertSubMenu(objSubMenu);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objSubMenu.Log,  e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objSubMenu);
            }
        }

    }
}
