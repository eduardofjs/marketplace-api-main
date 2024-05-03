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
using Domain.Dto;

namespace DIRECTTO.Controllers
{
    [MyBasicAuthenticationFilter]    [LogActionFilter]
    public class EmpresaController : ApiController
    {
        private readonly IEmpresaAppServices _EmpresaAppServices;
        private readonly IPerfilxUsuarioAppServices _PerfilxUsuarioAppServices;
        private readonly IDigitalTwinAppServices _DigitalTwinAppServices;
        private readonly IUsuarioAppServices _UsuarioAppServices;

        public EmpresaController(IEmpresaAppServices EmpresaAppServices, IPerfilxUsuarioAppServices PerfilxUsuarioAppServices, 
            IDigitalTwinAppServices DigitalTwinAppServices,
            IUsuarioAppServices UsuarioAppServices)
        {
            try { 
                _EmpresaAppServices = EmpresaAppServices;
                _PerfilxUsuarioAppServices = PerfilxUsuarioAppServices;
                _DigitalTwinAppServices = DigitalTwinAppServices;
                _UsuarioAppServices = UsuarioAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/Empresa/AtivarEmpresa")]
        [HttpPut]
        public HttpResponseMessage AtivarEmpresa(int EMP_Id, Log Log)
        {
            try
            {
                var item = _EmpresaAppServices.AtivarEmpresa(EMP_Id);
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

        [Route("api/Empresa/DeletarEmpresa")]
        [HttpPut]
        public HttpResponseMessage DeletarEmpresa(int EMP_Id, Log Log)
        {
            try
            {
                var item = _EmpresaAppServices.DeletarEmpresa(EMP_Id);
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

        [Route("api/Empresa/GetAllEmpresa")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaAppServices.GetAllEmpresa(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/Empresa/GetAllEmpresaByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaAppServices.GetAllEmpresaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/Empresa/GetAllEmpresaByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaAppServices.GetAllEmpresaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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

                

        [Route("api/Empresa/GetEmpresaById")]
        [HttpPost]
        public HttpResponseMessage GetEmpresaById(int EMP_Id, bool join, Log Log)
        {
            try
            {
                var item = _EmpresaAppServices.GetEmpresaById(EMP_Id, join);
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

        [Route("api/Empresa/GetListEmpresa")]
        [HttpPost]
        public HttpResponseMessage GetListEmpresa(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _EmpresaAppServices.GetAllEmpresa(true, true, join, maxInstances, order_by);
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
        
        [Route("api/Empresa/CadastroEmpresa")]
        [HttpPut]
        public HttpResponseMessage CadastroEmpresa(Empresa objEmpresa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objEmpresa.EMP_Id > 0)
                    {
                        // Atualizar empresa Directto
                        var fUpdate = _EmpresaAppServices.UpdateEmpresa(objEmpresa);

                        // Integracao com a Digital Twin para atualizar company
                        _DigitalTwinAppServices.UpdateCompany(new DigitalTwinCompanyDto(objEmpresa));

                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objEmpresa);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Empresa());

                        
                    }
                    else
                    {
                       
                        // Cadastrar a empresa Directto
                        Empresa fInsert = _EmpresaAppServices.InsertEmpresa(objEmpresa);
                        if (fInsert.EMP_Id > 0)
                        {
                            //criar perfilxusuario
                            if (objEmpresa.EMP_TipoEmpresaId == 1)
                            {
                                PerfilxUsuario pxu = new PerfilxUsuario();
                                pxu.PXU_Id = 0;
                                pxu.PXU_Ativo = true;
                                pxu.PXU_PerfilId = 18;
                                pxu.PXU_UsuarioId = objEmpresa.EMP_UsuarioId;
                                var fInsertPxU = _PerfilxUsuarioAppServices.InsertPerfilxUsuario(pxu);
                            }
                            else if (objEmpresa.EMP_TipoEmpresaId == 2)
                            {
                                PerfilxUsuario pxu = new PerfilxUsuario();
                                pxu.PXU_Id = 0;
                                pxu.PXU_Ativo = true;
                                pxu.PXU_PerfilId = 23;
                                pxu.PXU_UsuarioId = objEmpresa.EMP_UsuarioId;
                                var fInsertPxU = _PerfilxUsuarioAppServices.InsertPerfilxUsuario(pxu);
                            }


                            if (objEmpresa.EMP_FlagIngles == null)
                                objEmpresa.EMP_FlagIngles = false;

                            // Nao enviar email se flagEmail false
                            if (objEmpresa.EMP_FlagEmail != null && objEmpresa.EMP_FlagEmail == false)
                            {
                                // Ok, nada aqui
                            }
                            else
                            {
                                //Disparo de E-mail Bem-Vindo
                                bool fValida = false;

                                if (objEmpresa.EMP_FlagIngles.Value)
                                    fValida = SendMail.sendMailMessageRedesSociais(objEmpresa.Usuario.USR_Email, 12, "Additional information validation", 2, 0); //template 6 - padrão sem redes sociais             
                                else
                                    fValida = SendMail.sendMailMessageRedesSociais(objEmpresa.Usuario.USR_Email, 2, "Validação de informações adicionais", 2, 0); //template 6 - padrão sem redes sociais
                                                                                                                                                                  //
                                if (fValida)
                                    fInsert.Usuario.mensagemSucesso = "Foi enviado um email de Cadastro de Empresa ao usuário!";
                                else
                                    fInsert.Usuario.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";

                            }

                            // Obter email de contato do user
                            IEnumerable<Usuario> listaUsuario = _UsuarioAppServices.GetAllUsuarioByValorExato(objEmpresa.EMP_UsuarioId.ToString(), "USR_Id", true, false, 1, "USR_Id");
                            fInsert.EMP_Contato = listaUsuario.ToArray()[0].USR_Email;

                            // Integracao com a Digital Twin para cadastro de company
                            _DigitalTwinAppServices.InsertCompany(new DigitalTwinCompanyDto(fInsert));

                            return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                        }
                        else
                            return Request.CreateResponse(HttpStatusCode.BadRequest, fInsert.Usuario.mensagemSucesso);
                    }
                }
                catch (Exception e)
                {
                    Log Log = new Log();
                    RepositoryBase.salvaLog(Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objEmpresa);
            }
        }

        [Route("api/Empresa/AprovarEmpresa")]
        [HttpPut]
        public HttpResponseMessage AprovarEmpresa(int EMP_Id, Log Log)
        {
            try
            {
                var item = _EmpresaAppServices.AprovarEmpresa(EMP_Id);
                Empresa objEmpresa = _EmpresaAppServices.GetEmpresaById(EMP_Id, true);

                //Disparo de E-mail Validação completada com sucesso
                bool fValida;

                if (objEmpresa.EMP_FlagIngles == null)
                    objEmpresa.EMP_FlagIngles = false;
                
                if (objEmpresa.EMP_FlagIngles.Value)
                    fValida = SendMail.sendMailMessageRedesSociais(objEmpresa.Usuario.USR_Email, 13, "Validation completed sucessfully", 2, 0); //template 6 - padrão sem redes sociais             
                else
                    fValida = SendMail.sendMailMessageRedesSociais(objEmpresa.Usuario.USR_Email, 3, "Validação completada com sucesso", 2, 0); //template 6 - padrão sem redes sociais
                                                                                                                                               
                if (fValida)
                    objEmpresa.Usuario.mensagemSucesso = "Foi enviado um email de Validação completada com sucesso ao usuário!";
                else
                    objEmpresa.Usuario.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";


                return Request.CreateResponse(HttpStatusCode.OK, objEmpresa);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/Empresa/ReprovarEmpresa")]
        [HttpPut]
        public HttpResponseMessage ReprovarEmpresa(int EMP_Id, Log Log)
        {
            try
            {
                var item = _EmpresaAppServices.ReprovarEmpresa(EMP_Id);
                Empresa objEmpresa = _EmpresaAppServices.GetEmpresaById(EMP_Id, true);

                //Disparo de E-mail Informações inconsistentes
                bool fValida;

                if (objEmpresa.EMP_FlagIngles == null)
                    objEmpresa.EMP_FlagIngles = false;

                if (objEmpresa.EMP_FlagIngles.Value)
                    fValida = SendMail.sendMailMessageRedesSociais(objEmpresa.Usuario.USR_Email, 14, "Inconsistent information", 2, 0); //template 6 - padrão sem redes sociais             
                else
                    fValida = SendMail.sendMailMessageRedesSociais(objEmpresa.Usuario.USR_Email, 4, "Informações inconsistentes", 2, 0); //template 6 - padrão sem redes sociais
                                                                                                                                         
                if (fValida)
                    objEmpresa.Usuario.mensagemSucesso = "Foi enviado um email de Informações inconsistentes ao usuário!";
                else
                    objEmpresa.Usuario.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";


                return Request.CreateResponse(HttpStatusCode.OK, objEmpresa);
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
