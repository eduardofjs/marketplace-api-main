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
    public class EmpresaxServicoAdicionalController : ApiController
    {
        private readonly IEmpresaxServicoAdicionalAppServices _EmpresaxServicoAdicionalAppServices;

        public EmpresaxServicoAdicionalController(IEmpresaxServicoAdicionalAppServices EmpresaxServicoAdicionalAppServices)
        {
            try
            {
                _EmpresaxServicoAdicionalAppServices = EmpresaxServicoAdicionalAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/EmpresaxServicoAdicional/AtivarEmpresaxServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage AtivarEmpresaxServicoAdicional(int ESA_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoAdicionalAppServices.AtivarEmpresaxServicoAdicional(ESA_Id);
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

        [Route("api/EmpresaxServicoAdicional/DeletarEmpresaxServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage DeletarEmpresaxServicoAdicional(int ESA_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoAdicionalAppServices.DeletarEmpresaxServicoAdicional(ESA_Id);
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

        [Route("api/EmpresaxServicoAdicional/GetAllEmpresaxServicoAdicional")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoAdicionalAppServices.GetAllEmpresaxServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/EmpresaxServicoAdicional/GetAllEmpresaxServicoAdicionalByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoAdicionalAppServices.GetAllEmpresaxServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/EmpresaxServicoAdicional/GetAllEmpresaxServicoAdicionalByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoAdicionalAppServices.GetAllEmpresaxServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/EmpresaxServicoAdicional/GetEmpresaxServicoAdicionalById")]
        [HttpPost]
        public HttpResponseMessage GetEmpresaxServicoAdicionalById(int ESA_Id, bool join, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoAdicionalAppServices.GetEmpresaxServicoAdicionalById(ESA_Id, join);
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

        [Route("api/EmpresaxServicoAdicional/GetListEmpresaxServicoAdicional")]
        [HttpPost]
        public HttpResponseMessage GetListEmpresaxServicoAdicional(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoAdicionalAppServices.GetAllEmpresaxServicoAdicional(true, true, join, maxInstances, order_by);
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

        [Route("api/EmpresaxServicoAdicional/CadastroEmpresaxServicoAdicional")]
        [HttpPut]
        public HttpResponseMessage CadastroEmpresaxServicoAdicional(EmpresaxServicoAdicional objEmpresaxServicoAdicional)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objEmpresaxServicoAdicional.ESA_Id > 0)
                    {
                        var fUpdate = _EmpresaxServicoAdicionalAppServices.UpdateEmpresaxServicoAdicional(objEmpresaxServicoAdicional);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxServicoAdicional);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new EmpresaxServicoAdicional());
                    }
                    else
                    {
                        var fInsert = _EmpresaxServicoAdicionalAppServices.InsertEmpresaxServicoAdicional(objEmpresaxServicoAdicional);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objEmpresaxServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxServicoAdicional);
            }
        }

    }
}
