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
    public class TermoUsoxUsuarioController : ApiController
    {
        private readonly ITermoUsoxUsuarioAppServices _TermoUsoxUsuarioAppServices;

        public TermoUsoxUsuarioController(ITermoUsoxUsuarioAppServices TermoUsoxUsuarioAppServices)
        {
            try { 
                _TermoUsoxUsuarioAppServices = TermoUsoxUsuarioAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/TermoUsoxUsuario/AtivarTermoUsoxUsuario")]
        [HttpPut]
        public HttpResponseMessage AtivarTermoUsoxUsuario(int TXU_Id, Log Log)
        {
            try
            {
                var item = _TermoUsoxUsuarioAppServices.AtivarTermoUsoxUsuario(TXU_Id);
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

        [Route("api/TermoUsoxUsuario/DeletarTermoUsoxUsuario")]
        [HttpPut]
        public HttpResponseMessage DeletarTermoUsoxUsuario(int TXU_Id, Log Log)
        {
            try
            {
                var item = _TermoUsoxUsuarioAppServices.DeletarTermoUsoxUsuario(TXU_Id);
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

        [Route("api/TermoUsoxUsuario/GetAllTermoUsoxUsuario")]
        [HttpPost]
        public HttpResponseMessage GetAllTermoUsoxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TermoUsoxUsuarioAppServices.GetAllTermoUsoxUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/TermoUsoxUsuario/GetAllTermoUsoxUsuarioByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllTermoUsoxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TermoUsoxUsuarioAppServices.GetAllTermoUsoxUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/TermoUsoxUsuario/GetAllTermoUsoxUsuarioByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllTermoUsoxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TermoUsoxUsuarioAppServices.GetAllTermoUsoxUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/TermoUsoxUsuario/GetTermoUsoxUsuarioById")]
        [HttpPost]
        public HttpResponseMessage GetTermoUsoxUsuarioById(int TXU_Id, bool join, Log Log)
        {
            try
            {
                var item = _TermoUsoxUsuarioAppServices.GetTermoUsoxUsuarioById(TXU_Id, join);
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

        [Route("api/TermoUsoxUsuario/GetListTermoUsoxUsuario")]
        [HttpPost]
        public HttpResponseMessage GetListTermoUsoxUsuario(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _TermoUsoxUsuarioAppServices.GetAllTermoUsoxUsuario(true, true, join, maxInstances, order_by);
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
        
        [Route("api/TermoUsoxUsuario/CadastroTermoUsoxUsuario")]
        [HttpPut]
        public HttpResponseMessage CadastroTermoUsoxUsuario(TermoUsoxUsuario objTermoUsoxUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objTermoUsoxUsuario.TXU_Id > 0)
                    {
                        var fUpdate = _TermoUsoxUsuarioAppServices.UpdateTermoUsoxUsuario(objTermoUsoxUsuario);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objTermoUsoxUsuario);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new TermoUsoxUsuario());
                    }
                    else
                    {
                        var fInsert = _TermoUsoxUsuarioAppServices.InsertTermoUsoxUsuario(objTermoUsoxUsuario);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objTermoUsoxUsuario.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objTermoUsoxUsuario);
            }
        }

        [Route("api/TermoUsoxUsuario/CadastroTermoUsoxUsuarioWeb")]
        [HttpPut]
        public bool CadastroTermoUsoxUsuarioWeb(int idUser, int idTermo)
        {
            try
            {
                TermoUsoxUsuario termo = new TermoUsoxUsuario();
                termo.TXU_Id = 0;
                termo.TXU_UsuarioId = idUser;
                termo.TXU_TermoUsoId = idTermo;
                termo.TXU_Aceite = true;
                termo.TXU_DataAceite = DateTime.Now;
                termo.TXU_Ativo = true;
                var obj = CadastroTermoUsoxUsuario(termo);

                //se existe, volta usuario completo com pessoa
                if (obj != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLogError(null, "TermoUsoxUsuarioController", "CadastroTermoUsoxUsuarioWeb", e.InnerException.ToString(), e.Message, e.StackTrace, "");
                throw;
            }
        }
    }
}
