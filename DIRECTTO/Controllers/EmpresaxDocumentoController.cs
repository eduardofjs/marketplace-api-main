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
    public class EmpresaxDocumentoController : ApiController
    {
        private readonly IEmpresaxDocumentoAppServices _EmpresaxDocumentoAppServices;

        public EmpresaxDocumentoController(IEmpresaxDocumentoAppServices EmpresaxDocumentoAppServices)
        {
            try
            {
                _EmpresaxDocumentoAppServices = EmpresaxDocumentoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/EmpresaxDocumento/AtivarEmpresaxDocumento")]
        [HttpPut]
        public HttpResponseMessage AtivarEmpresaxDocumento(int EXD_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxDocumentoAppServices.AtivarEmpresaxDocumento(EXD_Id);
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

        [Route("api/EmpresaxDocumento/DeletarEmpresaxDocumento")]
        [HttpPut]
        public HttpResponseMessage DeletarEmpresaxDocumento(int EXD_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxDocumentoAppServices.DeletarEmpresaxDocumento(EXD_Id);
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

        [Route("api/EmpresaxDocumento/GetAllEmpresaxDocumento")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxDocumentoAppServices.GetAllEmpresaxDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/EmpresaxDocumento/GetAllEmpresaxDocumentoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxDocumentoAppServices.GetAllEmpresaxDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/EmpresaxDocumento/GetAllEmpresaxDocumentoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxDocumentoAppServices.GetAllEmpresaxDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/EmpresaxDocumento/GetEmpresaxDocumentoById")]
        [HttpPost]
        public HttpResponseMessage GetEmpresaxDocumentoById(int EXD_Id, bool join, Log Log)
        {
            try
            {
                var item = _EmpresaxDocumentoAppServices.GetEmpresaxDocumentoById(EXD_Id, join);
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

        [Route("api/EmpresaxDocumento/GetListEmpresaxDocumento")]
        [HttpPost]
        public HttpResponseMessage GetListEmpresaxDocumento(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxDocumentoAppServices.GetAllEmpresaxDocumento(true, true, join, maxInstances, order_by);
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

        [Route("api/EmpresaxDocumento/CadastroEmpresaxDocumento")]
        [HttpPut]
        public HttpResponseMessage CadastroEmpresaxDocumento(EmpresaxDocumento objEmpresaxDocumento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objEmpresaxDocumento.EXD_Id > 0)
                    {
                        var fUpdate = _EmpresaxDocumentoAppServices.UpdateEmpresaxDocumento(objEmpresaxDocumento);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxDocumento);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new EmpresaxDocumento());
                    }
                    else
                    {
                        var fInsert = _EmpresaxDocumentoAppServices.InsertEmpresaxDocumento(objEmpresaxDocumento);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objEmpresaxDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxDocumento);
            }
        }

    }
}
