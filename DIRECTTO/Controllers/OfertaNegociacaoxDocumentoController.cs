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
    public class OfertaNegociacaoxDocumentoController : ApiController
    {
        private readonly IOfertaNegociacaoxDocumentoAppServices _OfertaNegociacaoxDocumentoAppServices;
        private readonly IEmpresaAppServices _EmpresaAppServices;

        public OfertaNegociacaoxDocumentoController(IOfertaNegociacaoxDocumentoAppServices OfertaNegociacaoxDocumentoAppServices, IEmpresaAppServices EmpresaAppServices)
        {
            try
            {
                _OfertaNegociacaoxDocumentoAppServices = OfertaNegociacaoxDocumentoAppServices;
                _EmpresaAppServices = EmpresaAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/OfertaNegociacaoxDocumento/AtivarOfertaNegociacaoxDocumento")]
        [HttpPut]
        public HttpResponseMessage AtivarOfertaNegociacaoxDocumento(int OND_Id, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxDocumentoAppServices.AtivarOfertaNegociacaoxDocumento(OND_Id);
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

        [Route("api/OfertaNegociacaoxDocumento/DeletarOfertaNegociacaoxDocumento")]
        [HttpPut]
        public HttpResponseMessage DeletarOfertaNegociacaoxDocumento(int OND_Id, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxDocumentoAppServices.DeletarOfertaNegociacaoxDocumento(OND_Id);
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

        [Route("api/OfertaNegociacaoxDocumento/GetAllOfertaNegociacaoxDocumento")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaNegociacaoxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxDocumentoAppServices.GetAllOfertaNegociacaoxDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/OfertaNegociacaoxDocumento/GetAllOfertaNegociacaoxDocumentoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaNegociacaoxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxDocumentoAppServices.GetAllOfertaNegociacaoxDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/OfertaNegociacaoxDocumento/GetAllOfertaNegociacaoxDocumentoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaNegociacaoxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxDocumentoAppServices.GetAllOfertaNegociacaoxDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/OfertaNegociacaoxDocumento/GetOfertaNegociacaoxDocumentoById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaNegociacaoxDocumentoById(int OND_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxDocumentoAppServices.GetOfertaNegociacaoxDocumentoById(OND_Id, join);
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

        [Route("api/OfertaNegociacaoxDocumento/GetListOfertaNegociacaoxDocumento")]
        [HttpPost]
        public HttpResponseMessage GetListOfertaNegociacaoxDocumento(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoxDocumentoAppServices.GetAllOfertaNegociacaoxDocumento(true, true, join, maxInstances, order_by);
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

        [Route("api/OfertaNegociacaoxDocumento/CadastroOfertaNegociacaoxDocumento")]
        [HttpPut]
        public HttpResponseMessage CadastroOfertaNegociacaoxDocumento(OfertaNegociacaoxDocumento objOfertaNegociacaoxDocumento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objOfertaNegociacaoxDocumento.OND_DocumentoId == 0)
                        objOfertaNegociacaoxDocumento.OND_DocumentoId = null;

                    if (objOfertaNegociacaoxDocumento.OND_StatusDocumentoId == 0)
                        objOfertaNegociacaoxDocumento.OND_StatusDocumentoId = null;

                    if (objOfertaNegociacaoxDocumento.OND_Id > 0)
                    {
                        var fUpdate = _OfertaNegociacaoxDocumentoAppServices.UpdateOfertaNegociacaoxDocumento(objOfertaNegociacaoxDocumento);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objOfertaNegociacaoxDocumento);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new OfertaNegociacaoxDocumento());
                    }
                    else
                    {
                        var fInsert = _OfertaNegociacaoxDocumentoAppServices.InsertOfertaNegociacaoxDocumento(objOfertaNegociacaoxDocumento);

                        //buscar pelo empresaid
                        var empresa = _EmpresaAppServices.GetEmpresaById(objOfertaNegociacaoxDocumento.OND_EmpresaId,true);

                        //enviar msg
                        string mensagem = "Doc: " + objOfertaNegociacaoxDocumento.OND_Descricao;
                        bool fValida;
                        if (!objOfertaNegociacaoxDocumento.OND_FlagIngles.Value)
                            fValida = SendMail.sendMailMessageNegociacao(empresa.Usuario.USR_Email, 12, "Nova Notificação", 2, mensagem); //template 15 
                        else
                            fValida = SendMail.sendMailMessageNegociacao(empresa.Usuario.USR_Email, 13, "New Notification", 2, mensagem); //template 15E 
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objOfertaNegociacaoxDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objOfertaNegociacaoxDocumento);
            }
        }

    }
}
