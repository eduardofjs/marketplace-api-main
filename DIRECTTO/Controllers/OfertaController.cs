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
    public class OfertaController : ApiController
    {
        private readonly IOfertaAppServices _OfertaAppServices;
        private readonly IUsuarioAppServices _UsuarioAppServices;

        public OfertaController(IOfertaAppServices OfertaAppServices, IUsuarioAppServices UsuarioAppServices)
        {
            try
            {
                _OfertaAppServices = OfertaAppServices;
                _UsuarioAppServices = UsuarioAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/Oferta/AtivarOferta")]
        [HttpPut]
        public HttpResponseMessage AtivarOferta(int OFE_Id, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.AtivarOferta(OFE_Id);
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

        [Route("api/Oferta/DeletarOferta")]
        [HttpPut]
        public HttpResponseMessage DeletarOferta(int OFE_Id, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.DeletarOferta(OFE_Id);
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

        [Route("api/Oferta/GetAllOferta")]
        [HttpPost]
        public HttpResponseMessage GetAllOferta(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.GetAllOferta(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/Oferta/GetAllOfertaByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.GetAllOfertaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/Oferta/GetAllOfertaByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.GetAllOfertaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/Oferta/GetOfertaById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaById(int OFE_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.GetOfertaById(OFE_Id, join);
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

        [Route("api/Oferta/GetOfertaEditarById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaEditarById(int OFE_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.GetOfertaEditarById(OFE_Id, join);
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

        [Route("api/Oferta/GetListOferta")]
        [HttpPost]
        public HttpResponseMessage GetListOferta(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.GetAllOferta(true, true, join, maxInstances, order_by);
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

        [Route("api/Oferta/CadastroOferta")]
        [HttpPut]
        public HttpResponseMessage CadastroOferta(Oferta objOferta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objOferta.OFE_Id > 0)
                    {
                        var fUpdate = _OfertaAppServices.UpdateOferta(objOferta);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objOferta);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Oferta());
                    }
                    else
                    {
                        if (objOferta.OFE_FlagAtivo == null)
                            objOferta.OFE_FlagAtivo = true;
                        if (objOferta.OFE_FlagAprovado == null)
                            objOferta.OFE_FlagAprovado = false;
                        var fInsert = _OfertaAppServices.InsertOferta(objOferta);
                        if (fInsert.OFE_Id > 0)
                        {
                            objOferta.Usuario = _UsuarioAppServices.GetUsuarioById(fInsert.OFE_UsuarioInsercaoId, true);
                            //Disparo de E-mail Recebemos dados da sua oferta/demanda
                            bool fValida;
                            string temp = "";

                            if (objOferta.OFE_FlagIngles == null)
                                objOferta.OFE_FlagIngles = false;

                            if (objOferta.OFE_FlagVender.Value)
                            {
                                if (objOferta.OFE_FlagIngles.Value)
                                    fValida = SendMail.sendMailMessageRedesSociais(objOferta.Usuario.USR_Email, 15, "We received your offer data", 2, 0); //template 6 - padrão sem redes sociais             
                                else
                                    fValida = SendMail.sendMailMessageRedesSociais(objOferta.Usuario.USR_Email, 5, "Recebemos dados da sua oferta", 2, 0); //template 6 - padrão sem redes sociais
                                temp = "Oferta";
                            }
                            else
                            {
                                if (objOferta.OFE_FlagIngles.Value)
                                    fValida = SendMail.sendMailMessageRedesSociais(objOferta.Usuario.USR_Email, 16, "We received your demand data", 2, 0); //template 6 - padrão sem redes sociais             
                                else
                                    fValida = SendMail.sendMailMessageRedesSociais(objOferta.Usuario.USR_Email, 6, "Recebemos dados da sua demanda", 2, 0); //template 6 - padrão sem redes sociais
                                temp = "Demanda";
                            }

                            if (fValida)
                                fInsert.Usuario.mensagemSucesso = "Foi enviado um email de Cadastro de sua "+ temp + "!";
                            else
                                fInsert.Usuario.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";


                            return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                        }
                        else
                            return Request.CreateResponse(HttpStatusCode.BadRequest, fInsert.Usuario.mensagemSucesso);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objOferta.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objOferta);
            }
        }

        [Route("api/Oferta/AprovarOferta")]
        [HttpPut]
        public HttpResponseMessage AprovarOferta(int OFE_Id, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.AprovarOferta(OFE_Id);
                Oferta objOferta = _OfertaAppServices.GetOfertaById(OFE_Id, true);

                //Disparo de E-mail Sua oferta/demanda já foi publicada
                bool fValida;
                string temp = "";

                if (objOferta.OFE_FlagIngles == null)
                    objOferta.OFE_FlagIngles = false;

                if (objOferta.OFE_FlagVender.Value)
                {
                    if (objOferta.OFE_FlagIngles.Value)
                        fValida = SendMail.sendMailMessageRedesSociais(objOferta.Empresa.Usuario.USR_Email, 17, "Your offer has already been published", 2, 0); //template 6 - padrão sem redes sociais             
                    else
                        fValida = SendMail.sendMailMessageRedesSociais(objOferta.Empresa.Usuario.USR_Email, 7, "Sua oferta já foi publicada", 2, 0); //template 6 - padrão sem redes sociais
                    temp = "Oferta";
                }
                else
                {
                    if (objOferta.OFE_FlagIngles.Value)
                        fValida = SendMail.sendMailMessageRedesSociais(objOferta.Empresa.Usuario.USR_Email, 18, "Your demand has already been published", 2, 0); //template 6 - padrão sem redes sociais             
                    else
                        fValida = SendMail.sendMailMessageRedesSociais(objOferta.Empresa.Usuario.USR_Email, 8, "Sua demanda já foi publicada", 2, 0); //template 6 - padrão sem redes sociais
                    temp = "Demanda";
                }
                if (fValida)
                    objOferta.Usuario.mensagemSucesso = "Foi enviado um email de publicação de " + temp + " ao usuário!";
                else
                    objOferta.Usuario.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";


                return Request.CreateResponse(HttpStatusCode.OK, objOferta);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Oferta/ReprovarOferta")]
        [HttpPut]
        public HttpResponseMessage ReprovarOferta(int OFE_Id, Log Log)
        {
            try
            {
                var item = _OfertaAppServices.ReprovarOferta(OFE_Id);
                Oferta objOferta = _OfertaAppServices.GetOfertaById(OFE_Id, true);

                //Disparo de E-mail Informações da oferta/demanda inconsistentes
                bool fValida;
                string temp = "";

                if (objOferta.OFE_FlagIngles == null)
                    objOferta.OFE_FlagIngles = false;

                if (objOferta.OFE_FlagVender.Value)
                {
                    if (objOferta.OFE_FlagIngles.Value)
                        fValida = SendMail.sendMailMessageRedesSociais(objOferta.Empresa.Usuario.USR_Email, 19, "Inconsistent offer information", 2, 0); //template 6 - padrão sem redes sociais             
                    else
                        fValida = SendMail.sendMailMessageRedesSociais(objOferta.Empresa.Usuario.USR_Email, 9, "Informações da oferta inconsistentes", 2, 0); //template 6 - padrão sem redes sociais                    
                    temp = "Oferta";
                }
                else
                {
                    if (objOferta.OFE_FlagIngles.Value)
                        fValida = SendMail.sendMailMessageRedesSociais(objOferta.Empresa.Usuario.USR_Email, 20, "Inconsistent demand information", 2, 0); //template 6 - padrão sem redes sociais             
                    else
                        fValida = SendMail.sendMailMessageRedesSociais(objOferta.Empresa.Usuario.USR_Email, 10, "Informações da demanda inconsistentes", 2, 0); //template 6 - padrão sem redes sociais    
                    temp = "Demanda";
                }
                
                if (fValida)
                    objOferta.Usuario.mensagemSucesso = "Foi enviado um email de Informações da " + temp + " inconsistentes ao usuário!";
                else
                    objOferta.Usuario.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";


                return Request.CreateResponse(HttpStatusCode.OK, objOferta);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

    }
}
