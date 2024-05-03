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
    public class TipoLogisticoPortoController : ApiController
    {
        private readonly ITipoLogisticoPortoAppServices _TipoLogisticoPortoAppServices;

        public TipoLogisticoPortoController(ITipoLogisticoPortoAppServices TipoLogisticoPortoAppServices)
        {
            try
            {
                _TipoLogisticoPortoAppServices = TipoLogisticoPortoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TipoLogisticoPorto/AtivarTipoLogisticoPorto")]
        [HttpPut]
        public HttpResponseMessage AtivarTipoLogisticoPorto(int TLP_Id, Log Log)
        {
            try
            {
                var item = _TipoLogisticoPortoAppServices.AtivarTipoLogisticoPorto(TLP_Id);
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

        [Route("api/TipoLogisticoPorto/DeletarTipoLogisticoPorto")]
        [HttpPut]
        public HttpResponseMessage DeletarTipoLogisticoPorto(int TLP_Id, Log Log)
        {
            try
            {
                var item = _TipoLogisticoPortoAppServices.DeletarTipoLogisticoPorto(TLP_Id);
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

        [Route("api/TipoLogisticoPorto/GetAllTipoLogisticoPorto")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoLogisticoPorto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoLogisticoPortoAppServices.GetAllTipoLogisticoPorto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TipoLogisticoPorto/GetAllTipoLogisticoPortoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoLogisticoPortoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoLogisticoPortoAppServices.GetAllTipoLogisticoPortoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TipoLogisticoPorto/GetAllTipoLogisticoPortoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTipoLogisticoPortoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoLogisticoPortoAppServices.GetAllTipoLogisticoPortoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/TipoLogisticoPorto/GetTipoLogisticoPortoById")]
        [HttpPost]
        public HttpResponseMessage GetTipoLogisticoPortoById(int TLP_Id, bool join, Log Log)
        {
            try
            {
                var item = _TipoLogisticoPortoAppServices.GetTipoLogisticoPortoById(TLP_Id, join);
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

        [Route("api/TipoLogisticoPorto/GetListTipoLogisticoPorto")]
        [HttpPost]
        public HttpResponseMessage GetListTipoLogisticoPorto(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TipoLogisticoPortoAppServices.GetAllTipoLogisticoPorto(true, true, join, maxInstances, order_by);
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

        [Route("api/TipoLogisticoPorto/CadastroTipoLogisticoPorto")]
        [HttpPut]
        public HttpResponseMessage CadastroTipoLogisticoPorto(TipoLogisticoPorto objTipoLogisticoPorto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTipoLogisticoPorto.TLP_Id > 0)
                    {
                        var fUpdate = _TipoLogisticoPortoAppServices.UpdateTipoLogisticoPorto(objTipoLogisticoPorto);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTipoLogisticoPorto);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TipoLogisticoPorto());
                    }
                    else
                    {
                        var fInsert = _TipoLogisticoPortoAppServices.InsertTipoLogisticoPorto(objTipoLogisticoPorto);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTipoLogisticoPorto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTipoLogisticoPorto);
            }
        }

    }
}
