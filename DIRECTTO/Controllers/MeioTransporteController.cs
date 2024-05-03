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
    public class MeioTransporteController : ApiController
    {
        private readonly IMeioTransporteAppServices _MeioTransporteAppServices;

        public MeioTransporteController(IMeioTransporteAppServices MeioTransporteAppServices)
        {
            try
            {
                _MeioTransporteAppServices = MeioTransporteAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/MeioTransporte/AtivarMeioTransporte")]
        [HttpPut]
        public HttpResponseMessage AtivarMeioTransporte(int MTR_Id, Log Log)
        {
            try
            {
                var item = _MeioTransporteAppServices.AtivarMeioTransporte(MTR_Id);
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

        [Route("api/MeioTransporte/DeletarMeioTransporte")]
        [HttpPut]
        public HttpResponseMessage DeletarMeioTransporte(int MTR_Id, Log Log)
        {
            try
            {
                var item = _MeioTransporteAppServices.DeletarMeioTransporte(MTR_Id);
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

        [Route("api/MeioTransporte/GetAllMeioTransporte")]
        [HttpPost]
        public HttpResponseMessage GetAllMeioTransporte(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _MeioTransporteAppServices.GetAllMeioTransporte(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/MeioTransporte/GetAllMeioTransporteByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllMeioTransporteByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _MeioTransporteAppServices.GetAllMeioTransporteByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/MeioTransporte/GetAllMeioTransporteByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllMeioTransporteByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _MeioTransporteAppServices.GetAllMeioTransporteByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/MeioTransporte/GetMeioTransporteById")]
        [HttpPost]
        public HttpResponseMessage GetMeioTransporteById(int MTR_Id, bool join, Log Log)
        {
            try
            {
                var item = _MeioTransporteAppServices.GetMeioTransporteById(MTR_Id, join);
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

        [Route("api/MeioTransporte/GetListMeioTransporte")]
        [HttpPost]
        public HttpResponseMessage GetListMeioTransporte(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _MeioTransporteAppServices.GetAllMeioTransporte(true, true, join, maxInstances, order_by);
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

        [Route("api/MeioTransporte/CadastroMeioTransporte")]
        [HttpPut]
        public HttpResponseMessage CadastroMeioTransporte(MeioTransporte objMeioTransporte)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objMeioTransporte.MTR_Id > 0)
                    {
                        var fUpdate = _MeioTransporteAppServices.UpdateMeioTransporte(objMeioTransporte);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objMeioTransporte);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new MeioTransporte());
                    }
                    else
                    {
                        var fInsert = _MeioTransporteAppServices.InsertMeioTransporte(objMeioTransporte);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objMeioTransporte.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objMeioTransporte);
            }
        }

    }
}
