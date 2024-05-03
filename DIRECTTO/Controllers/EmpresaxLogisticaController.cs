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
    public class EmpresaxLogisticaController : ApiController
    {
        private readonly IEmpresaxLogisticaAppServices _EmpresaxLogisticaAppServices;

        public EmpresaxLogisticaController(IEmpresaxLogisticaAppServices EmpresaxLogisticaAppServices)
        {
            try
            {
                _EmpresaxLogisticaAppServices = EmpresaxLogisticaAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/EmpresaxLogistica/AtivarEmpresaxLogistica")]
        [HttpPut]
        public HttpResponseMessage AtivarEmpresaxLogistica(int EXL_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxLogisticaAppServices.AtivarEmpresaxLogistica(EXL_Id);
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

        [Route("api/EmpresaxLogistica/DeletarEmpresaxLogistica")]
        [HttpPut]
        public HttpResponseMessage DeletarEmpresaxLogistica(int EXL_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxLogisticaAppServices.DeletarEmpresaxLogistica(EXL_Id);
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

        [Route("api/EmpresaxLogistica/GetAllEmpresaxLogistica")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxLogistica(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxLogisticaAppServices.GetAllEmpresaxLogistica(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/EmpresaxLogistica/GetAllEmpresaxLogisticaByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxLogisticaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxLogisticaAppServices.GetAllEmpresaxLogisticaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/EmpresaxLogistica/GetAllEmpresaxLogisticaByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxLogisticaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxLogisticaAppServices.GetAllEmpresaxLogisticaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/EmpresaxLogistica/GetEmpresaxLogisticaById")]
        [HttpPost]
        public HttpResponseMessage GetEmpresaxLogisticaById(int EXL_Id, bool join, Log Log)
        {
            try
            {
                var item = _EmpresaxLogisticaAppServices.GetEmpresaxLogisticaById(EXL_Id, join);
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

        [Route("api/EmpresaxLogistica/GetListEmpresaxLogistica")]
        [HttpPost]
        public HttpResponseMessage GetListEmpresaxLogistica(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxLogisticaAppServices.GetAllEmpresaxLogistica(true, true, join, maxInstances, order_by);
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

        [Route("api/EmpresaxLogistica/CadastroEmpresaxLogistica")]
        [HttpPut]
        public HttpResponseMessage CadastroEmpresaxLogistica(EmpresaxLogistica objEmpresaxLogistica)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objEmpresaxLogistica.EXL_Id > 0)
                    {
                        var fUpdate = _EmpresaxLogisticaAppServices.UpdateEmpresaxLogistica(objEmpresaxLogistica);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxLogistica);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new EmpresaxLogistica());
                    }
                    else
                    {
                        var fInsert = _EmpresaxLogisticaAppServices.InsertEmpresaxLogistica(objEmpresaxLogistica);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objEmpresaxLogistica.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxLogistica);
            }
        }

    }
}
