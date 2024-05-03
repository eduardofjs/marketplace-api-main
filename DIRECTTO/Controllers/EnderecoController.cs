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
    [MyBasicAuthenticationFilter]    [LogActionFilter]
    public class EnderecoController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IEnderecoAppServices _EnderecoAppServices;

        public EnderecoController(IEnderecoAppServices EnderecoAppServices)
        {
            try { 
                _EnderecoAppServices = EnderecoAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/Endereco/AtivarEndereco")]
        [HttpPost]
        public HttpResponseMessage AtivarEndereco(int END_Id, Log Log)
        {
            try
            {
                var item = _EnderecoAppServices.AtivarEndereco(END_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Endereco/DeletarEndereco")]
        [HttpPost]
        public HttpResponseMessage DeletarEndereco(int END_Id, Log Log)
        {
            try
            {
                var item = _EnderecoAppServices.DeletarEndereco(END_Id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Endereco/GetAllEndereco")]
        [HttpPost]
        public HttpResponseMessage GetAllEndereco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EnderecoAppServices.GetAllEndereco(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Endereco/GetAllEnderecoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllEnderecoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EnderecoAppServices.GetAllEnderecoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }


        [Route("api/Endereco/GetAllEnderecoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllEnderecoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EnderecoAppServices.GetAllEnderecoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

                

        [Route("api/Endereco/GetEnderecoById")]
        [HttpPost]
        public HttpResponseMessage GetEnderecoById(int END_Id, bool join, Log Log)
        {
            try
            {
                var item = _EnderecoAppServices.GetEnderecoById(END_Id, join);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Endereco/GetListEndereco")]
        [HttpPost]
        public HttpResponseMessage GetListEndereco(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EnderecoAppServices.GetAllEndereco(true, true, join, maxInstances, order_by);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }
        
        [Route("api/Endereco/CadastroEndereco")]
        [HttpPut]
        public HttpResponseMessage CadastroEndereco(Endereco objEndereco)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objEndereco.END_Id > 0)
                    {
                        var fUpdate = _EnderecoAppServices.UpdateEndereco(objEndereco);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objEndereco);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Endereco());
                    }
                    else
                    {
                        var fInsert = _EnderecoAppServices.InsertEndereco(objEndereco);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objEndereco.Log,  e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objEndereco);
            }
        }

    }
}
