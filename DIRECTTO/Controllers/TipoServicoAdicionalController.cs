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
    public class TipoServicoAdicionalController : ApiController
    {
        private readonly ITipoServicoAdicionalAppServices _TipoServicoAdicionalAppServices;

        public TipoServicoAdicionalController(ITipoServicoAdicionalAppServices TipoServicoAdicionalAppServices)
        {
            try
            {
                _TipoServicoAdicionalAppServices = TipoServicoAdicionalAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TipoServicoAdicional/AtivarTipoServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage AtivarTipoServicoAdicional(int TSA_Id, Log Log)
        {
            try
            {
                var item = _TipoServicoAdicionalAppServices.AtivarTipoServicoAdicional(TSA_Id);
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

        [Route("api/TipoServicoAdicional/DeletarTipoServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage DeletarTipoServicoAdicional(int TSA_Id, Log Log)
        {
            try
            {
                var item = _TipoServicoAdicionalAppServices.DeletarTipoServicoAdicional(TSA_Id);
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

        [Route("api/TipoServicoAdicional/GetAllTipoServicoAdicional")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoServicoAdicionalAppServices.GetAllTipoServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TipoServicoAdicional/GetAllTipoServicoAdicionalByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoServicoAdicionalAppServices.GetAllTipoServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TipoServicoAdicional/GetAllTipoServicoAdicionalByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoServicoAdicionalAppServices.GetAllTipoServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/TipoServicoAdicional/GetTipoServicoAdicionalById")]
        [HttpPost]
        public HttpResponseMessage GetTipoServicoAdicionalById(int TSA_Id, bool join, Log Log)
        {
            try
            {
                var item = _TipoServicoAdicionalAppServices.GetTipoServicoAdicionalById(TSA_Id, join);
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

        [Route("api/TipoServicoAdicional/GetListTipoServicoAdicional")]
        [HttpPost]
        public HttpResponseMessage GetListTipoServicoAdicional(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoServicoAdicionalAppServices.GetAllTipoServicoAdicional(true, true, join, maxInstances, order_by);
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

        [Route("api/TipoServicoAdicional/CadastroTipoServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage CadastroTipoServicoAdicional(TipoServicoAdicional objTipoServicoAdicional)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTipoServicoAdicional.TSA_Id > 0)
                    {
                        var fUpdate = _TipoServicoAdicionalAppServices.UpdateTipoServicoAdicional(objTipoServicoAdicional);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTipoServicoAdicional);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TipoServicoAdicional());
                    }
                    else
                    {
                        var fInsert = _TipoServicoAdicionalAppServices.InsertTipoServicoAdicional(objTipoServicoAdicional);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTipoServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTipoServicoAdicional);
            }
        }

    }
}
