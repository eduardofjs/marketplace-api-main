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
    public class PoliticaPrivacidadexUsuarioController : ApiController
    {
        private readonly IPoliticaPrivacidadexUsuarioAppServices _PoliticaPrivacidadexUsuarioAppServices;

        public PoliticaPrivacidadexUsuarioController(IPoliticaPrivacidadexUsuarioAppServices PoliticaPrivacidadexUsuarioAppServices)
        {
            try { 
                _PoliticaPrivacidadexUsuarioAppServices = PoliticaPrivacidadexUsuarioAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/PoliticaPrivacidadexUsuario/AtivarPoliticaPrivacidadexUsuario")]
        [HttpPut]
        public HttpResponseMessage AtivarPoliticaPrivacidadexUsuario(int PVU_Id, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadexUsuarioAppServices.AtivarPoliticaPrivacidadexUsuario(PVU_Id);
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

        [Route("api/PoliticaPrivacidadexUsuario/DeletarPoliticaPrivacidadexUsuario")]
        [HttpPut]
        public HttpResponseMessage DeletarPoliticaPrivacidadexUsuario(int PVU_Id, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadexUsuarioAppServices.DeletarPoliticaPrivacidadexUsuario(PVU_Id);
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

        [Route("api/PoliticaPrivacidadexUsuario/GetAllPoliticaPrivacidadexUsuario")]
        [HttpPost]
        public HttpResponseMessage GetAllPoliticaPrivacidadexUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadexUsuarioAppServices.GetAllPoliticaPrivacidadexUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/PoliticaPrivacidadexUsuario/GetAllPoliticaPrivacidadexUsuarioByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllPoliticaPrivacidadexUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadexUsuarioAppServices.GetAllPoliticaPrivacidadexUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/PoliticaPrivacidadexUsuario/GetAllPoliticaPrivacidadexUsuarioByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllPoliticaPrivacidadexUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadexUsuarioAppServices.GetAllPoliticaPrivacidadexUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/PoliticaPrivacidadexUsuario/GetPoliticaPrivacidadexUsuarioById")]
        [HttpPost]
        public HttpResponseMessage GetPoliticaPrivacidadexUsuarioById(int PVU_Id, bool join, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadexUsuarioAppServices.GetPoliticaPrivacidadexUsuarioById(PVU_Id, join);
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

        [Route("api/PoliticaPrivacidadexUsuario/GetListPoliticaPrivacidadexUsuario")]
        [HttpPost]
        public HttpResponseMessage GetListPoliticaPrivacidadexUsuario(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _PoliticaPrivacidadexUsuarioAppServices.GetAllPoliticaPrivacidadexUsuario(true, true, join, maxInstances, order_by);
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
        
        [Route("api/PoliticaPrivacidadexUsuario/CadastroPoliticaPrivacidadexUsuario")]
        [HttpPut]
        public HttpResponseMessage CadastroPoliticaPrivacidadexUsuario(PoliticaPrivacidadexUsuario objPoliticaPrivacidadexUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objPoliticaPrivacidadexUsuario.PVU_Id > 0)
                    {
                        var fUpdate = _PoliticaPrivacidadexUsuarioAppServices.UpdatePoliticaPrivacidadexUsuario(objPoliticaPrivacidadexUsuario);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objPoliticaPrivacidadexUsuario);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new PoliticaPrivacidadexUsuario());
                    }
                    else
                    {
                        var fInsert = _PoliticaPrivacidadexUsuarioAppServices.InsertPoliticaPrivacidadexUsuario(objPoliticaPrivacidadexUsuario);
                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objPoliticaPrivacidadexUsuario.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objPoliticaPrivacidadexUsuario);
            }
        }

        [Route("api/PoliticaPrivacidadexUsuario/CadastroPoliticaPrivacidadexUsuarioWeb")]
        [HttpPut]
        public bool CadastroPoliticaPrivacidadexUsuarioWeb(int idUser, int idPolitica)
        {
            try
            {
                PoliticaPrivacidadexUsuario politica = new PoliticaPrivacidadexUsuario();
                politica.PVU_Id = 0;
                politica.PVU_UsuarioId = idUser;
                politica.PVU_PoliticaPrivacidadeId = idPolitica;
                politica.PVU_Aceite = true;
                politica.PVU_DataAceite = DateTime.Now;
                politica.PVU_Ativo = true;
                var obj = CadastroPoliticaPrivacidadexUsuario(politica);

                //se existe, volta usuario completo com pessoa
                if (obj != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLogError(null, "PoliticaPrivacidadexUsuarioController", "CadastroPoliticaPrivacidadexUsuarioWeb", e.InnerException.ToString(), e.Message, e.StackTrace, "");
                throw;
            }
        }

    }
}
