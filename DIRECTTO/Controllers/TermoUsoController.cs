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
    public class TermoUsoController : ApiController
    {
        private readonly ITermoUsoAppServices _TermoUsoAppServices;

        public TermoUsoController(ITermoUsoAppServices TermoUsoAppServices)
        {
            try { 
                _TermoUsoAppServices = TermoUsoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TermoUso/AtivarTermoUso")]
        [HttpPut]
        public HttpResponseMessage AtivarTermoUso(int TRU_Id, Log Log)
        {
            try
            {
                var item = _TermoUsoAppServices.AtivarTermoUso(TRU_Id);
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

        [Route("api/TermoUso/DeletarTermoUso")]
        [HttpPost]
        public HttpResponseMessage DeletarTermoUso(int TRU_Id, Log Log)
        {
            try
            {
                var item = _TermoUsoAppServices.DeletarTermoUso(TRU_Id);
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

        [Route("api/TermoUso/GetAllTermoUso")]
        [HttpPost]
        public HttpResponseMessage GetAllTermoUso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TermoUsoAppServices.GetAllTermoUso(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TermoUso/GetAllTermoUsoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTermoUsoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TermoUsoAppServices.GetAllTermoUsoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TermoUso/GetAllTermoUsoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTermoUsoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TermoUsoAppServices.GetAllTermoUsoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/TermoUso/GetTermoUsoById")]
        [HttpPost]
        public HttpResponseMessage GetTermoUsoById(int TRU_Id, bool join, Log Log)
        {
            try
            {
                var item = _TermoUsoAppServices.GetTermoUsoById(TRU_Id, join);
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

        [Route("api/TermoUso/GetListTermoUso")]
        [HttpPost]
        public HttpResponseMessage GetListTermoUso(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TermoUsoAppServices.GetAllTermoUso(true, true, join, maxInstances, order_by);
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
        
        [Route("api/TermoUso/CadastroTermoUso")]
        [HttpPut]
        public HttpResponseMessage CadastroTermoUso(TermoUso objTermoUso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTermoUso.TRU_Id > 0)
                    {
                        var fUpdate = _TermoUsoAppServices.UpdateTermoUso(objTermoUso);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTermoUso);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TermoUso());
                    }
                    else
                    {
                        var fInsert = _TermoUsoAppServices.InsertTermoUso(objTermoUso);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTermoUso.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTermoUso);
            }
        }

    }
}
