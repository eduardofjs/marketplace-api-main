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
    public class ServicoFinanceiroController : ApiController
    {
        private readonly IServicoFinanceiroAppServices _ServicoFinanceiroAppServices;

        public ServicoFinanceiroController(IServicoFinanceiroAppServices ServicoFinanceiroAppServices)
        {
            try
            {
                _ServicoFinanceiroAppServices = ServicoFinanceiroAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/ServicoFinanceiro/AtivarServicoFinanceiro")]
        [HttpPut]
        public HttpResponseMessage AtivarServicoFinanceiro(int SEF_Id, Log Log)
        {
            try
            {
                var item = _ServicoFinanceiroAppServices.AtivarServicoFinanceiro(SEF_Id);
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

        [Route("api/ServicoFinanceiro/DeletarServicoFinanceiro")]
        [HttpPut]
        public HttpResponseMessage DeletarServicoFinanceiro(int SEF_Id, Log Log)
        {
            try
            {
                var item = _ServicoFinanceiroAppServices.DeletarServicoFinanceiro(SEF_Id);
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

        [Route("api/ServicoFinanceiro/GetAllServicoFinanceiro")]
        [HttpPost]
        public HttpResponseMessage GetAllServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoFinanceiroAppServices.GetAllServicoFinanceiro(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/ServicoFinanceiro/GetAllServicoFinanceiroByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoFinanceiroAppServices.GetAllServicoFinanceiroByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/ServicoFinanceiro/GetAllServicoFinanceiroByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoFinanceiroAppServices.GetAllServicoFinanceiroByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/ServicoFinanceiro/GetServicoFinanceiroById")]
        [HttpPost]
        public HttpResponseMessage GetServicoFinanceiroById(int SEF_Id, bool join, Log Log)
        {
            try
            {
                var item = _ServicoFinanceiroAppServices.GetServicoFinanceiroById(SEF_Id, join);
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

        [Route("api/ServicoFinanceiro/GetListServicoFinanceiro")]
        [HttpPost]
        public HttpResponseMessage GetListServicoFinanceiro(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ServicoFinanceiroAppServices.GetAllServicoFinanceiro(true, true, join, maxInstances, order_by);
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

        [Route("api/ServicoFinanceiro/CadastroServicoFinanceiro")]
        [HttpPut]
        public HttpResponseMessage CadastroServicoFinanceiro(ServicoFinanceiro objServicoFinanceiro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objServicoFinanceiro.SEF_Id > 0)
                    {
                        var fUpdate = _ServicoFinanceiroAppServices.UpdateServicoFinanceiro(objServicoFinanceiro);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objServicoFinanceiro);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new ServicoFinanceiro());
                    }
                    else
                    {
                        var fInsert = _ServicoFinanceiroAppServices.InsertServicoFinanceiro(objServicoFinanceiro);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objServicoFinanceiro.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objServicoFinanceiro);
            }
        }

    }
}