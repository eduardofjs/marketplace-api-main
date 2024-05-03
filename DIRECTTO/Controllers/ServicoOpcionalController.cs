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
    public class ServicoOpcionalController : ApiController
    {
        private readonly IServicoOpcionalAppServices _ServicoOpcionalAppServices;

        public ServicoOpcionalController(IServicoOpcionalAppServices ServicoOpcionalAppServices)
        {
            try
            {
                _ServicoOpcionalAppServices = ServicoOpcionalAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/ServicoOpcional/AtivarServicoOpcional")]
        [HttpPut]
        public HttpResponseMessage AtivarServicoOpcional(int SEO_Id, Log Log)
        {
            try
            {
                var item = _ServicoOpcionalAppServices.AtivarServicoOpcional(SEO_Id);
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

        [Route("api/ServicoOpcional/DeletarServicoOpcional")]
        [HttpPut]
        public HttpResponseMessage DeletarServicoOpcional(int SEO_Id, Log Log)
        {
            try
            {
                var item = _ServicoOpcionalAppServices.DeletarServicoOpcional(SEO_Id);
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

        [Route("api/ServicoOpcional/GetAllServicoOpcional")]
        [HttpPost]
        public HttpResponseMessage GetAllServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoOpcionalAppServices.GetAllServicoOpcional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/ServicoOpcional/GetAllServicoOpcionalByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoOpcionalAppServices.GetAllServicoOpcionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/ServicoOpcional/GetAllServicoOpcionalByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoOpcionalAppServices.GetAllServicoOpcionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/ServicoOpcional/GetServicoOpcionalById")]
        [HttpPost]
        public HttpResponseMessage GetServicoOpcionalById(int SEO_Id, bool join, Log Log)
        {
            try
            {
                var item = _ServicoOpcionalAppServices.GetServicoOpcionalById(SEO_Id, join);
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

        [Route("api/ServicoOpcional/GetListServicoOpcional")]
        [HttpPost]
        public HttpResponseMessage GetListServicoOpcional(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoOpcionalAppServices.GetAllServicoOpcional(true, true, join, maxInstances, order_by);
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

        [Route("api/ServicoOpcional/CadastroServicoOpcional")]
        [HttpPut]
        public HttpResponseMessage CadastroServicoOpcional(ServicoOpcional objServicoOpcional)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objServicoOpcional.SEO_Id > 0)
                    {
                        var fUpdate = _ServicoOpcionalAppServices.UpdateServicoOpcional(objServicoOpcional);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objServicoOpcional);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new ServicoOpcional());
                    }
                    else
                    {
                        var fInsert = _ServicoOpcionalAppServices.InsertServicoOpcional(objServicoOpcional);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objServicoOpcional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objServicoOpcional);
            }
        }

    }
}
