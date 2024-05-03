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
    [MyBasicAuthenticationFilter]
    [LogActionFilter]
    public class UsuarioController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUsuarioAppServices _UsuarioAppServices;
        private readonly IEmpresaAppServices _EmpresaAppServices;

        public UsuarioController(IUsuarioAppServices UsuarioAppServices, IEmpresaAppServices EmpresaAppServices)
        {
            try
            {
                _UsuarioAppServices = UsuarioAppServices;
                _EmpresaAppServices = EmpresaAppServices;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/Usuario/AtivarUsuario")]
        [HttpPost]
        public HttpResponseMessage AtivarUsuario(int USR_Id, Log Log)
        {
            try
            {
                var item = _UsuarioAppServices.AtivarUsuario(USR_Id);
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

        [Route("api/Usuario/DeletarUsuario")]
        [HttpPost]
        public HttpResponseMessage DeletarUsuario(int USR_Id, Log Log)
        {
            try
            {
                var item = _UsuarioAppServices.DeletarUsuario(USR_Id);
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

        [Route("api/Usuario/GetAllUsuario")]
        [HttpPost]
        public HttpResponseMessage GetAllUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _UsuarioAppServices.GetAllUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/Usuario/GetAllUsuarioByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _UsuarioAppServices.GetAllUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/Usuario/GetAllUsuarioByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _UsuarioAppServices.GetAllUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/Usuario/GetUsuarioById")]
        [HttpPost]
        public HttpResponseMessage GetUsuarioById(int USR_Id, bool join, Log Log)
        {
            try
            {
                var item = _UsuarioAppServices.GetUsuarioById(USR_Id, join);
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

        [Route("api/Usuario/GetListUsuario")]
        [HttpPost]
        public HttpResponseMessage GetListUsuario(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _UsuarioAppServices.GetAllUsuario(true, true, join, maxInstances, order_by);
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

        [Route("api/Usuario/CadastroUsuario")]
        [HttpPut]
        public HttpResponseMessage CadastroUsuario(Usuario objUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objUsuario.USR_Id > 0)
                    {
                        var fUpdate = _UsuarioAppServices.UpdateUsuario(objUsuario);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objUsuario);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Usuario());
                    }
                    else
                    {
                        if (objUsuario.USR_OrigemId == null || objUsuario.USR_OrigemId == 0)
                            objUsuario.USR_OrigemId = 1;//directto
                        var fInsert = _UsuarioAppServices.InsertUsuario(objUsuario);
                        if (fInsert.USR_Id > 0)
                        {
                            bool fValida;

                            if (objUsuario.USR_FlagIngles == null)
                                objUsuario.USR_FlagIngles = false;

                            if (objUsuario.USR_FlagIngles.Value)
                                fValida = SendMail.sendMailMessageRedesSociais(objUsuario.USR_Email, 11, "Welcome to Directto!", 2, fInsert.USR_Id); //template 6 - padrão sem redes sociais             
                            else
                                fValida = SendMail.sendMailMessageRedesSociais(objUsuario.USR_Email, 1, "Bem vindo a Directto!", 2, fInsert.USR_Id); //template 6 - padrão sem redes sociais                    

                            if (fValida)
                                fInsert.mensagemSucesso = "Foi enviado um email de Cadastro de Usuário!";
                            else
                                fInsert.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";


                            return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                        }
                        return Request.CreateResponse(HttpStatusCode.BadRequest, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objUsuario.Log, e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objUsuario);
            }
        }


        /// <summary>
        /// Faz login, retorna nulo se cadastro nao existe
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [Route("api/Usuario/Login")]
        [HttpPut]
        public HttpResponseMessage Login(string email, string senha)
        {
            try
            {
                var usuario = _UsuarioAppServices.GetUsuarioLogin(email, senha);


                //se existe, volta usuario completo com pessoa
                if (usuario != null && usuario.USR_Id > 0)
                {
                    if (usuario.Empresa.EMP_FlagAprovado == false)
                    {
                        usuario.mensagemSucesso = "Este login aguarda aprovação da Directto.";
                        return Request.CreateResponse(HttpStatusCode.BadRequest, usuario);
                    }
                    if (usuario.USR_Ativo == false)
                    {
                        usuario.mensagemSucesso = "Este login não está mais ativo. Quaisquer duvidas entre em contato com a Directto.";
                        return Request.CreateResponse(HttpStatusCode.BadRequest, usuario);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, usuario);
                    
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, false);


            }
            catch (Exception e)
            {
                log.Error("Error", e);
                throw;
            }
        }

        [Route("api/Usuario/GetUsuarioByCPF")]
        [HttpPost]
        public HttpResponseMessage GetUsuarioByCPF(string CPF, int unidadeId = 1)
        {
            try
            {
                var item = _UsuarioAppServices.GetUsuarioByCPF(CPF, unidadeId);
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

        [Route("api/Usuario/RecoveryPasswordEmail")]
        [HttpPost]
        public HttpResponseMessage RecoveryPasswordEmail(string sEmail, bool isProfessional = false)
        {
            try
            {
                var geraToken = _UsuarioAppServices.CreateTokenRecoveryEmail(sEmail, isProfessional);
                if (geraToken == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Nenhum usuário encontado com o email informado!", obj = false });
                }
                else if (geraToken.USR_TokenDateExpire != null && geraToken.USR_TokenDateExpire.Value < DateTime.Now)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Token inválido!", obj = false });
                }
                else
                {
                    var fValida = SendMail.sendMailRecovery(sEmail, geraToken.USR_TokenRecoveryPassword);

                    if (fValida)
                        return Request.CreateResponse(HttpStatusCode.OK, new { mensagem = "Foi enviado um email com link para recuperação de senha!", obj = true });
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Ocorreu um erro ao enviar email!", obj = false });
                }

            }
            catch (Exception ex)
            {
                RepositoryBase.salvaLog(ex.Message + " " + ex.InnerException + "\n" + ex.StackTrace + "\n" + "\n");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Ocorreu um erro no servidor!", obj = false });
            }

        }

        [Route("api/Usuario/UpdateRecoveryPassword")]
        [HttpPost]
        public HttpResponseMessage UpdateRecoveryPassword(string sToken, string sSenha)
        {
            try
            {
                var validaToken = _UsuarioAppServices.ValidTokenRecovery(sToken);
                if (validaToken == null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Nenhum token encontrados!", obj = true });


                //if (validaToken.USR_TokenDateExpire != null && validaToken.USR_TokenDateExpire.Value < DateTime.Now)
                //    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Token expirado!", obj = false });


                var userUpdate = _UsuarioAppServices.UpdatePassword(sToken, sSenha);

                if (userUpdate != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new { mensagem = "Senha alterada com sucesso!", obj = true });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Ocorreu um erro ao alterar a senha!", obj = true });

            }
            catch (Exception ex)
            {
                RepositoryBase.salvaLog(ex.Message + " " + ex.InnerException + "\n" + ex.StackTrace + "\n" + "\n");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Ocorreu um erro no servidor!", obj = false });
            }
        }

        [Route("api/Usuario/SalvarAvisoCoranaLido")]
        [HttpPost]
        public HttpResponseMessage SalvarAvisoCoranaLido(int USR_Id)
        {
            try
            {
                var userUpdate = _UsuarioAppServices.SalvarAvisoCoranaLido(USR_Id);

                if (userUpdate == true)
                    return Request.CreateResponse(HttpStatusCode.OK, new { mensagem = "Data alterada com sucesso!", obj = true });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Ocorreu um erro ao alterar a data!", obj = true });

            }
            catch (Exception ex)
            {
                RepositoryBase.salvaLog(ex.Message + " " + ex.InnerException + "\n" + ex.StackTrace + "\n" + "\n");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { mensagem = "Ocorreu um erro no servidor!", obj = false });
            }
        }
    }
}
