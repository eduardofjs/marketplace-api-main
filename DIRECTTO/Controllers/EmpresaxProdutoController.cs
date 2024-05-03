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
    public class EmpresaxProdutoController : ApiController
    {
        private readonly IEmpresaxProdutoAppServices _EmpresaxProdutoAppServices;

        public EmpresaxProdutoController(IEmpresaxProdutoAppServices EmpresaxProdutoAppServices)
        {
            try
            {
                _EmpresaxProdutoAppServices = EmpresaxProdutoAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/EmpresaxProduto/AtivarEmpresaxProduto")]
        [HttpPut]
        public HttpResponseMessage AtivarEmpresaxProduto(int EXP_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxProdutoAppServices.AtivarEmpresaxProduto(EXP_Id);
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

        [Route("api/EmpresaxProduto/DeletarEmpresaxProduto")]
        [HttpPut]
        public HttpResponseMessage DeletarEmpresaxProduto(int EXP_Id, Log Log)
        {
            try
            {
                var item = _EmpresaxProdutoAppServices.DeletarEmpresaxProduto(EXP_Id);
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

        [Route("api/EmpresaxProduto/GetAllEmpresaxProduto")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxProdutoAppServices.GetAllEmpresaxProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/EmpresaxProduto/GetAllEmpresaxProdutoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxProdutoAppServices.GetAllEmpresaxProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/EmpresaxProduto/GetAllEmpresaxProdutoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaxProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxProdutoAppServices.GetAllEmpresaxProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/EmpresaxProduto/GetEmpresaxProdutoById")]
        [HttpPost]
        public HttpResponseMessage GetEmpresaxProdutoById(int EXP_Id, bool join, Log Log)
        {
            try
            {
                var item = _EmpresaxProdutoAppServices.GetEmpresaxProdutoById(EXP_Id, join);
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

        [Route("api/EmpresaxProduto/GetListEmpresaxProduto")]
        [HttpPost]
        public HttpResponseMessage GetListEmpresaxProduto(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaxProdutoAppServices.GetAllEmpresaxProduto(true, true, join, maxInstances, order_by);
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

        [Route("api/EmpresaxProduto/CadastroEmpresaxProduto")]
        [HttpPut]
        public HttpResponseMessage CadastroEmpresaxProduto(EmpresaxProduto objEmpresaxProduto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objEmpresaxProduto.EXP_Id > 0)
                    {
                        var fUpdate = _EmpresaxProdutoAppServices.UpdateEmpresaxProduto(objEmpresaxProduto);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxProduto);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new EmpresaxProduto());
                    }
                    else
                    {
                        var fInsert = _EmpresaxProdutoAppServices.InsertEmpresaxProduto(objEmpresaxProduto);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objEmpresaxProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objEmpresaxProduto);
            }
        }

    }
}
