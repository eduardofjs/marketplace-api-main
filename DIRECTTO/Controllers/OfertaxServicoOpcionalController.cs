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
    public class OfertaxServicoOpcionalController : ApiController
    {
        private readonly IOfertaxServicoOpcionalAppServices _OfertaxServicoOpcionalAppServices;

        public OfertaxServicoOpcionalController(IOfertaxServicoOpcionalAppServices OfertaxServicoOpcionalAppServices)
        {
            try
            {
                _OfertaxServicoOpcionalAppServices = OfertaxServicoOpcionalAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/OfertaxServicoOpcional/AtivarOfertaxServicoOpcional")]
        [HttpPut]
        public HttpResponseMessage AtivarOfertaxServicoOpcional(int OXS_Id, Log Log)
        {
            try
            {
                var item = _OfertaxServicoOpcionalAppServices.AtivarOfertaxServicoOpcional(OXS_Id);
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

        [Route("api/OfertaxServicoOpcional/DeletarOfertaxServicoOpcional")]
        [HttpPut]
        public HttpResponseMessage DeletarOfertaxServicoOpcional(int OXS_Id, Log Log)
        {
            try
            {
                var item = _OfertaxServicoOpcionalAppServices.DeletarOfertaxServicoOpcional(OXS_Id);
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

        [Route("api/OfertaxServicoOpcional/GetAllOfertaxServicoOpcional")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxServicoOpcionalAppServices.GetAllOfertaxServicoOpcional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/OfertaxServicoOpcional/GetAllOfertaxServicoOpcionalByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxServicoOpcionalAppServices.GetAllOfertaxServicoOpcionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/OfertaxServicoOpcional/GetAllOfertaxServicoOpcionalByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaxServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxServicoOpcionalAppServices.GetAllOfertaxServicoOpcionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/OfertaxServicoOpcional/GetOfertaxServicoOpcionalById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaxServicoOpcionalById(int OXS_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaxServicoOpcionalAppServices.GetOfertaxServicoOpcionalById(OXS_Id, join);
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

        [Route("api/OfertaxServicoOpcional/GetListOfertaxServicoOpcional")]
        [HttpPost]
        public HttpResponseMessage GetListOfertaxServicoOpcional(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaxServicoOpcionalAppServices.GetAllOfertaxServicoOpcional(true, true, join, maxInstances, order_by);
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

        [Route("api/OfertaxServicoOpcional/CadastroOfertaxServicoOpcional")]
        [HttpPut]
        public HttpResponseMessage CadastroOfertaxServicoOpcional(OfertaxServicoOpcional objOfertaxServicoOpcional)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objOfertaxServicoOpcional.OXS_Id > 0)
                    {
                        var fUpdate = _OfertaxServicoOpcionalAppServices.UpdateOfertaxServicoOpcional(objOfertaxServicoOpcional);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objOfertaxServicoOpcional);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new OfertaxServicoOpcional());
                    }
                    else
                    {
                        var fInsert = _OfertaxServicoOpcionalAppServices.InsertOfertaxServicoOpcional(objOfertaxServicoOpcional);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objOfertaxServicoOpcional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objOfertaxServicoOpcional);
            }
        }

    }
}
