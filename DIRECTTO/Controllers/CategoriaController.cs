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
    [MyBasicAuthenticationFilter]
    [LogActionFilter]
    public class CategoriaController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ICategoriaAppServices _CategoriaAppServices;

        public CategoriaController(ICategoriaAppServices CategoriaAppServices)
        {
            try
            {
                _CategoriaAppServices = CategoriaAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/Categoria/AtivarCategoria")]
        [HttpPut]
        public HttpResponseMessage AtivarCategoria(int CAT_Id, Log Log)
        {
            try
            {
                var item = _CategoriaAppServices.AtivarCategoria(CAT_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Categoria/DeletarCategoria")]
        [HttpPut]
        public HttpResponseMessage DeletarCategoria(int CAT_Id, Log Log)
        {
            try
            {
                var item = _CategoriaAppServices.DeletarCategoria(CAT_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Categoria/GetAllCategoria")]
        [HttpPost]
        public HttpResponseMessage GetAllCategoria(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _CategoriaAppServices.GetAllCategoria(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Categoria/GetAllCategoriaByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllCategoriaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _CategoriaAppServices.GetAllCategoriaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }


        [Route("api/Categoria/GetAllCategoriaByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllCategoriaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _CategoriaAppServices.GetAllCategoriaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }



        [Route("api/Categoria/GetCategoriaById")]
        [HttpPost]
        public HttpResponseMessage GetCategoriaById(int CAT_Id, bool join, Log Log)
        {
            try
            {
                var item = _CategoriaAppServices.GetCategoriaById(CAT_Id, join);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Categoria/GetListCategoria")]
        [HttpPost]
        public HttpResponseMessage GetListCategoria(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _CategoriaAppServices.GetAllCategoria(true, true, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Categoria/CadastroCategoria")]
        [HttpPut]
        public HttpResponseMessage CadastroCategoria(Categoria objCategoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objCategoria.CAT_Id > 0)
                    {
                        var fUpdate = _CategoriaAppServices.UpdateCategoria(objCategoria);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objCategoria);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Categoria());
                    }
                    else
                    {
                        var fInsert = _CategoriaAppServices.InsertCategoria(objCategoria);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    log.Error("Error", e);
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCategoria);
            }
        }

    }
}
