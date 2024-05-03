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
    public class EmpresaxServicoFinanceiroController : ApiController
    {
        private readonly IEmpresaxServicoFinanceiroAppServices _EmpresaxServicoFinanceiroAppServices;

        public EmpresaxServicoFinanceiroController(IEmpresaxServicoFinanceiroAppServices EmpresaxServicoFinanceiroAppServices)
        {
            try
            {
                _EmpresaxServicoFinanceiroAppServices = EmpresaxServicoFinanceiroAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/EmpresaxServicoFinanceiro/AtivarEmpresaxServicoFinanceiro")]
        [HttpPut]
        public HttpResponseMessage AtivarEmpresaxServicoFinanceiro(int ESF_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoFinanceiroAppServices.AtivarEmpresaxServicoFinanceiro(ESF_Id);
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

        [Route("api/EmpresaxServicoFinanceiro/DeletarEmpresaxServicoFinanceiro")]
        [HttpPut]
        public HttpResponseMessage DeletarEmpresaxServicoFinanceiro(int ESF_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoFinanceiroAppServices.DeletarEmpresaxServicoFinanceiro(ESF_Id);
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

        [Route("api/EmpresaxServicoFinanceiro/GetAllEmpresaxServicoFinanceiro")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoFinanceiroAppServices.GetAllEmpresaxServicoFinanceiro(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/EmpresaxServicoFinanceiro/GetAllEmpresaxServicoFinanceiroByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoFinanceiroAppServices.GetAllEmpresaxServicoFinanceiroByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/EmpresaxServicoFinanceiro/GetAllEmpresaxServicoFinanceiroByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoFinanceiroAppServices.GetAllEmpresaxServicoFinanceiroByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/EmpresaxServicoFinanceiro/GetEmpresaxServicoFinanceiroById")]
        [HttpPost]
        public HttpResponseMessage GetEmpresaxServicoFinanceiroById(int ESF_Id, bool join, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoFinanceiroAppServices.GetEmpresaxServicoFinanceiroById(ESF_Id, join);
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

        [Route("api/EmpresaxServicoFinanceiro/GetListEmpresaxServicoFinanceiro")]
        [HttpPost]
        public HttpResponseMessage GetListEmpresaxServicoFinanceiro(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxServicoFinanceiroAppServices.GetAllEmpresaxServicoFinanceiro(true, true, join, maxInstances, order_by);
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

        [Route("api/EmpresaxServicoFinanceiro/CadastroEmpresaxServicoFinanceiro")]
        [HttpPut]
        public HttpResponseMessage CadastroEmpresaxServicoFinanceiro(EmpresaxServicoFinanceiro objEmpresaxServicoFinanceiro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objEmpresaxServicoFinanceiro.ESF_Id > 0)
                    {
                        var fUpdate = _EmpresaxServicoFinanceiroAppServices.UpdateEmpresaxServicoFinanceiro(objEmpresaxServicoFinanceiro);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxServicoFinanceiro);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new EmpresaxServicoFinanceiro());
                    }
                    else
                    {
                        var fInsert = _EmpresaxServicoFinanceiroAppServices.InsertEmpresaxServicoFinanceiro(objEmpresaxServicoFinanceiro);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objEmpresaxServicoFinanceiro.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxServicoFinanceiro);
            }
        }

    }
}