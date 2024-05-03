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
    public class PoliticaPrivacidadeController : ApiController
    {
        private readonly IPoliticaPrivacidadeAppServices _PoliticaPrivacidadeAppServices;

        public PoliticaPrivacidadeController(IPoliticaPrivacidadeAppServices PoliticaPrivacidadeAppServices)
        {
            try { 
                _PoliticaPrivacidadeAppServices = PoliticaPrivacidadeAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/PoliticaPrivacidade/AtivarPoliticaPrivacidade")]
        [HttpPut]
        public HttpResponseMessage AtivarPoliticaPrivacidade(int PVD_Id, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadeAppServices.AtivarPoliticaPrivacidade(PVD_Id);
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

        [Route("api/PoliticaPrivacidade/DeletarPoliticaPrivacidade")]
        [HttpPost]
        public HttpResponseMessage DeletarPoliticaPrivacidade(int PVD_Id, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadeAppServices.DeletarPoliticaPrivacidade(PVD_Id);
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

        [Route("api/PoliticaPrivacidade/GetAllPoliticaPrivacidade")]
        [HttpPost]
        public HttpResponseMessage GetAllPoliticaPrivacidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadeAppServices.GetAllPoliticaPrivacidade(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/PoliticaPrivacidade/GetAllPoliticaPrivacidadeByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllPoliticaPrivacidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadeAppServices.GetAllPoliticaPrivacidadeByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/PoliticaPrivacidade/GetAllPoliticaPrivacidadeByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllPoliticaPrivacidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadeAppServices.GetAllPoliticaPrivacidadeByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/PoliticaPrivacidade/GetPoliticaPrivacidadeById")]
        [HttpPost]
        public HttpResponseMessage GetPoliticaPrivacidadeById(int PVD_Id, bool join, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadeAppServices.GetPoliticaPrivacidadeById(PVD_Id, join);
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

        [Route("api/PoliticaPrivacidade/GetListPoliticaPrivacidade")]
        [HttpPost]
        public HttpResponseMessage GetListPoliticaPrivacidade(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadeAppServices.GetAllPoliticaPrivacidade(true, true, join, maxInstances, order_by);
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
        
        [Route("api/PoliticaPrivacidade/CadastroPoliticaPrivacidade")]
        [HttpPut]
        public HttpResponseMessage CadastroPoliticaPrivacidade(PoliticaPrivacidade objPoliticaPrivacidade)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objPoliticaPrivacidade.PVD_Id > 0)
                    {
                        var fUpdate = _PoliticaPrivacidadeAppServices.UpdatePoliticaPrivacidade(objPoliticaPrivacidade);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objPoliticaPrivacidade);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new PoliticaPrivacidade());
                    }
                    else
                    {
                        var fInsert = _PoliticaPrivacidadeAppServices.InsertPoliticaPrivacidade(objPoliticaPrivacidade);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objPoliticaPrivacidade.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objPoliticaPrivacidade);
            }
        }

    }
}
