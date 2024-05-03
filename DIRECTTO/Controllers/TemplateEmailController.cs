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
    public class TemplateEmailController : ApiController
    {
        private readonly ITemplateEmailAppServices _TemplateEmailAppServices;

        public TemplateEmailController(ITemplateEmailAppServices TemplateEmailAppServices)
        {
            try { 
                _TemplateEmailAppServices = TemplateEmailAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TemplateEmail/AtivarTemplateEmail")]
        [HttpPut]
        public HttpResponseMessage AtivarTemplateEmail(int TME_Id, Log Log)
        {
            try
            {
                var item = _TemplateEmailAppServices.AtivarTemplateEmail(TME_Id);
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

        [Route("api/TemplateEmail/DeletarTemplateEmail")]
        [HttpPost]
        public HttpResponseMessage DeletarTemplateEmail(int TME_Id, Log Log)
        {
            try
            {
                var item = _TemplateEmailAppServices.DeletarTemplateEmail(TME_Id);
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

        [Route("api/TemplateEmail/GetAllTemplateEmail")]
        [HttpPost]
        public HttpResponseMessage GetAllTemplateEmail(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TemplateEmailAppServices.GetAllTemplateEmail(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TemplateEmail/GetAllTemplateEmailByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTemplateEmailByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TemplateEmailAppServices.GetAllTemplateEmailByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TemplateEmail/GetAllTemplateEmailByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTemplateEmailByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TemplateEmailAppServices.GetAllTemplateEmailByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/TemplateEmail/GetTemplateEmailById")]
        [HttpPost]
        public HttpResponseMessage GetTemplateEmailById(int TME_Id, bool join, Log Log)
        {
            try
            {
                var item = _TemplateEmailAppServices.GetTemplateEmailById(TME_Id, join);
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

        [Route("api/TemplateEmail/GetListTemplateEmail")]
        [HttpPost]
        public HttpResponseMessage GetListTemplateEmail(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TemplateEmailAppServices.GetAllTemplateEmail(true, true, join, maxInstances, order_by);
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
        
        [Route("api/TemplateEmail/CadastroTemplateEmail")]
        [HttpPut]
        public HttpResponseMessage CadastroTemplateEmail(TemplateEmail objTemplateEmail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTemplateEmail.TME_Id > 0)
                    {
                        var fUpdate = _TemplateEmailAppServices.UpdateTemplateEmail(objTemplateEmail);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTemplateEmail);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TemplateEmail());
                    }
                    else
                    {
                        var fInsert = _TemplateEmailAppServices.InsertTemplateEmail(objTemplateEmail);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTemplateEmail.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTemplateEmail);
            }
        }

    }
}
