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
    public class ServicoAdicionalController : ApiController
    {
        private readonly IServicoAdicionalAppServices _ServicoAdicionalAppServices;

        public ServicoAdicionalController(IServicoAdicionalAppServices ServicoAdicionalAppServices)
        {
            try
            {
                _ServicoAdicionalAppServices = ServicoAdicionalAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/ServicoAdicional/AtivarServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage AtivarServicoAdicional(int SEA_Id, Log Log)
        {
            try
            {
                var item = _ServicoAdicionalAppServices.AtivarServicoAdicional(SEA_Id);
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

        [Route("api/ServicoAdicional/DeletarServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage DeletarServicoAdicional(int SEA_Id, Log Log)
        {
            try
            {
                var item = _ServicoAdicionalAppServices.DeletarServicoAdicional(SEA_Id);
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

        [Route("api/ServicoAdicional/GetAllServicoAdicional")]
        [HttpPost]
        public HttpResponseMessage GetAllServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoAdicionalAppServices.GetAllServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/ServicoAdicional/GetAllServicoAdicionalByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoAdicionalAppServices.GetAllServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/ServicoAdicional/GetAllServicoAdicionalByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoAdicionalAppServices.GetAllServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/ServicoAdicional/GetServicoAdicionalById")]
        [HttpPost]
        public HttpResponseMessage GetServicoAdicionalById(int SEA_Id, bool join, Log Log)
        {
            try
            {
                var item = _ServicoAdicionalAppServices.GetServicoAdicionalById(SEA_Id, join);
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

        [Route("api/ServicoAdicional/GetListServicoAdicional")]
        [HttpPost]
        public HttpResponseMessage GetListServicoAdicional(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoAdicionalAppServices.GetAllServicoAdicional(true, true, join, maxInstances, order_by);
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

        [Route("api/ServicoAdicional/CadastroServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage CadastroServicoAdicional(ServicoAdicional objServicoAdicional)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objServicoAdicional.SEA_Id > 0)
                    {
                        var fUpdate = _ServicoAdicionalAppServices.UpdateServicoAdicional(objServicoAdicional);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objServicoAdicional);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new ServicoAdicional());
                    }
                    else
                    {
                        var fInsert = _ServicoAdicionalAppServices.InsertServicoAdicional(objServicoAdicional);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objServicoAdicional);
            }
        }

    }
}
