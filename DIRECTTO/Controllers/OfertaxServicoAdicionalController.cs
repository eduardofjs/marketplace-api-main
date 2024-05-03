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
    public class OfertaxServicoAdicionalController : ApiController
    {
        private readonly IOfertaxServicoAdicionalAppServices _OfertaxServicoAdicionalAppServices;

        public OfertaxServicoAdicionalController(IOfertaxServicoAdicionalAppServices OfertaxServicoAdicionalAppServices)
        {
            try
            {
                _OfertaxServicoAdicionalAppServices = OfertaxServicoAdicionalAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/OfertaxServicoAdicional/AtivarOfertaxServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage AtivarOfertaxServicoAdicional(int OXA_Id, Log Log)
        {
            try
            {
                var item = _OfertaxServicoAdicionalAppServices.AtivarOfertaxServicoAdicional(OXA_Id);
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

        [Route("api/OfertaxServicoAdicional/DeletarOfertaxServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage DeletarOfertaxServicoAdicional(int OXA_Id, Log Log)
        {
            try
            {
                var item = _OfertaxServicoAdicionalAppServices.DeletarOfertaxServicoAdicional(OXA_Id);
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

        [Route("api/OfertaxServicoAdicional/GetAllOfertaxServicoAdicional")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxServicoAdicionalAppServices.GetAllOfertaxServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/OfertaxServicoAdicional/GetAllOfertaxServicoAdicionalByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxServicoAdicionalAppServices.GetAllOfertaxServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/OfertaxServicoAdicional/GetAllOfertaxServicoAdicionalByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxServicoAdicionalAppServices.GetAllOfertaxServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/OfertaxServicoAdicional/GetOfertaxServicoAdicionalById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaxServicoAdicionalById(int OXA_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaxServicoAdicionalAppServices.GetOfertaxServicoAdicionalById(OXA_Id, join);
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

        [Route("api/OfertaxServicoAdicional/GetListOfertaxServicoAdicional")]
        [HttpPost]
        public HttpResponseMessage GetListOfertaxServicoAdicional(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxServicoAdicionalAppServices.GetAllOfertaxServicoAdicional(true, true, join, maxInstances, order_by);
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

        [Route("api/OfertaxServicoAdicional/CadastroOfertaxServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage CadastroOfertaxServicoAdicional(OfertaxServicoAdicional objOfertaxServicoAdicional)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objOfertaxServicoAdicional.OXA_Id > 0)
                    {
                        var fUpdate = _OfertaxServicoAdicionalAppServices.UpdateOfertaxServicoAdicional(objOfertaxServicoAdicional);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objOfertaxServicoAdicional);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new OfertaxServicoAdicional());
                    }
                    else
                    {
                        var fInsert = _OfertaxServicoAdicionalAppServices.InsertOfertaxServicoAdicional(objOfertaxServicoAdicional);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objOfertaxServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objOfertaxServicoAdicional);
            }
        }

    }
}
