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
    public class OfertaNegociacaoController : ApiController
    {
        private readonly IOfertaNegociacaoAppServices _OfertaNegociacaoAppServices;
        private readonly IEmpresaAppServices _EmpresaAppServices;
        public OfertaNegociacaoController(IOfertaNegociacaoAppServices OfertaNegociacaoAppServices, IEmpresaAppServices EmpresaAppServices)
        {
            try
            {
                _OfertaNegociacaoAppServices = OfertaNegociacaoAppServices;
                _EmpresaAppServices = EmpresaAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/OfertaNegociacao/AtivarOfertaNegociacao")]
        [HttpPut]
        public HttpResponseMessage AtivarOfertaNegociacao(int OFN_Id, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.AtivarOfertaNegociacao(OFN_Id);
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

        [Route("api/OfertaNegociacao/DeletarOfertaNegociacao")]
        [HttpPut]
        public HttpResponseMessage DeletarOfertaNegociacao(int OFN_Id, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.DeletarOfertaNegociacao(OFN_Id);
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

        [Route("api/OfertaNegociacao/GetAllOfertaNegociacao")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.GetAllOfertaNegociacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/OfertaNegociacao/GetAllOfertaNegociacaoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.GetAllOfertaNegociacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/OfertaNegociacao/GetAllOfertaNegociacaoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllOfertaNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.GetAllOfertaNegociacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/OfertaNegociacao/GetOfertaNegociacaoById")]
        [HttpPost]
        public HttpResponseMessage GetOfertaNegociacaoById(int OFN_Id, bool join, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.GetOfertaNegociacaoById(OFN_Id, join);
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

        [Route("api/OfertaNegociacao/GetListOfertaNegociacao")]
        [HttpPost]
        public HttpResponseMessage GetListOfertaNegociacao(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.GetAllOfertaNegociacao(true, true, join, maxInstances, order_by);
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

        [Route("api/OfertaNegociacao/CadastroOfertaNegociacao")]
        [HttpPut]
        public HttpResponseMessage CadastroOfertaNegociacao(OfertaNegociacao objOfertaNegociacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objOfertaNegociacao.OFN_Id > 0)
                    {
                        var fUpdate = _OfertaNegociacaoAppServices.UpdateOfertaNegociacao(objOfertaNegociacao);
                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objOfertaNegociacao);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new OfertaNegociacao());
                    }
                    else
                    {
                        //Validação de oferta apenas para empresa compradora e de demanda apenas para empresa vendedora
                        var fValidacao = _OfertaNegociacaoAppServices.ValidaRegraVendedorComprador(objOfertaNegociacao);
                        if (!fValidacao)
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Sua empresa é incompatível com este tipo de negociação.");
                        }

                        var fInsert = _OfertaNegociacaoAppServices.InsertOfertaNegociacao(objOfertaNegociacao);

                        if(fInsert.OFN_Mensagem == "O número de contraofertas excedeu o limite estabelecido. Você será contacto pelo time da directto para sabe como proceder")
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "O número de contraofertas excedeu o limite estabelecido. Você será contacto pelo time da directto para saber como proceder.");
                        //Disparo de E-mail Informações da OfertaNegociacao/demanda inconsistentes
                        bool fValida;
                        string temp = "";

                        if (objOfertaNegociacao.OFN_FlagIngles == null)
                            objOfertaNegociacao.OFN_FlagIngles = false;

                        string mensagemPT = fInsert.OfertaxQuantidadeProduto.Oferta.Produto.PDT_Nome + ", R$" + fInsert.OFN_ValorProposta;
                        string mensagemEN = fInsert.OfertaxQuantidadeProduto.Oferta.Produto.PDT_NomeIngles + ", US$" + fInsert.OFN_ValorProposta;
                        if (objOfertaNegociacao.OFN_FlagVendedor == false)
                        {//comprador
                            if (objOfertaNegociacao.OFN_FlagIngles.Value)
                            {
                                fValida = SendMail.sendMailMessageNegociacao(fInsert.Empresa.Usuario.USR_Email, 2, "Counter offer successfully created", 2, mensagemPT); 
                                fValida = SendMail.sendMailMessageNegociacao(fInsert.OfertaxQuantidadeProduto.Oferta.Empresa.Usuario.USR_Email, 3, "Você tem uma contra oferta - (ENVIAR TEXTO EM INGLÊS!!!)", 2, mensagemPT); //enviando email em PT pois não tem EN no template
                            }
                            else
                            {
                                fValida = SendMail.sendMailMessageNegociacao(fInsert.Empresa.Usuario.USR_Email, 1, "Contra oferta feita com sucesso", 2, mensagemPT); 
                                fValida = SendMail.sendMailMessageNegociacao(fInsert.OfertaxQuantidadeProduto.Oferta.Empresa.Usuario.USR_Email, 3, "Você tem uma contra oferta", 2, mensagemPT); 
                            }
                            temp = "Comprador";
                        }
                        else
                        { //vendedor
                            if (objOfertaNegociacao.OFN_FlagIngles.Value)
                            {
                                fValida = SendMail.sendMailMessageNegociacao(fInsert.OfertaxQuantidadeProduto.Oferta.Empresa.Usuario.USR_Email, 10, "Contra oferta feita com sucesso - (ENVIAR TEXTO EM INGLÊS!!!)", 2, mensagemPT); //template 6 - padrão sem redes sociais
                                fValida = SendMail.sendMailMessageNegociacao(fInsert.Empresa.Usuario.USR_Email, 11, "Você tem uma contra oferta - (ENVIAR TEXTO EM INGLÊS!!!)", 2, mensagemPT); //template 6 - padrão sem redes sociais     
                            }
                            else
                            {
                                fValida = SendMail.sendMailMessageNegociacao(fInsert.OfertaxQuantidadeProduto.Oferta.Empresa.Usuario.USR_Email, 10, "Contra oferta feita com sucesso", 2, mensagemPT); //template 6 - padrão sem redes sociais
                                fValida = SendMail.sendMailMessageNegociacao(fInsert.Empresa.Usuario.USR_Email, 11, "Você tem uma contra oferta", 2, mensagemPT); //template 6 - padrão sem redes sociais
                            }
                            temp = "Vendedor";
                        }

                        if (fValida)
                            objOfertaNegociacao.mensagemSucesso = "Foi enviado um email ao " + temp + "!";
                        else
                            objOfertaNegociacao.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";

                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objOfertaNegociacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objOfertaNegociacao);
            }
        }

        [Route("api/OfertaNegociacao/AprovarOfertaNegociacao")]
        [HttpPut]
        public HttpResponseMessage AprovarOfertaNegociacao(int OFN_Id, bool OFN_FlagVendedor, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.AprovarOfertaNegociacao(OFN_Id);
                OfertaNegociacao objOfertaNegociacao = _OfertaNegociacaoAppServices.GetOfertaNegociacaoById(OFN_Id, true);

                //Disparo de E-mail Sua OfertaNegociacao/demanda já foi publicada
                bool fValida;
                string temp = "";

                if (objOfertaNegociacao.OFN_FlagIngles == null)
                    objOfertaNegociacao.OFN_FlagIngles = false;

                string mensagemPT = objOfertaNegociacao.OfertaxQuantidadeProduto.Oferta.Produto.PDT_Nome + ", R$" + objOfertaNegociacao.OFN_ValorProposta;
                string mensagemEN = objOfertaNegociacao.OfertaxQuantidadeProduto.Oferta.Produto.PDT_NomeIngles + ", US$" + objOfertaNegociacao.OFN_ValorProposta;
                if (OFN_FlagVendedor == false)
                {//comprador aprovou e o vendedor vai receber a msg
                 //if (objOfertaNegociacao.OFN_FlagIngles.Value)
                 //    fValida = SendMail.sendMailMessageNegociacao(objOfertaNegociacao.OfertaxQuantidadeProduto.Oferta.Empresa.Usuario.USR_Email, 17, "Your offer has already been published", 2, mensagem); //template 6 - padrão sem redes sociais             
                 //else
                    fValida = SendMail.sendMailMessageNegociacao(objOfertaNegociacao.OfertaxQuantidadeProduto.Oferta.Empresa.Usuario.USR_Email, 8, "Contra oferta aprovada", 2, mensagemPT); //template 6 - padrão sem redes sociais
                    temp = "Vendedor";
                }
                else
                { //vendedor aprovou e o comprador vai receber a msg
                    if (objOfertaNegociacao.OFN_FlagIngles.Value)
                        fValida = SendMail.sendMailMessageNegociacao(objOfertaNegociacao.Empresa.Usuario.USR_Email, 5, "Counter offer approved", 2, mensagemEN); //template 6 - padrão sem redes sociais             
                    else
                        fValida = SendMail.sendMailMessageNegociacao(objOfertaNegociacao.Empresa.Usuario.USR_Email, 4, "Contra oferta aprovada", 2, mensagemPT); //template 6 - padrão sem redes sociais
                    temp = "Comprador";
                }
                if (fValida)
                    objOfertaNegociacao.mensagemSucesso = "Foi enviado um email ao " + temp + "!";
                else
                    objOfertaNegociacao.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";


                return Request.CreateResponse(HttpStatusCode.OK, objOfertaNegociacao);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/OfertaNegociacao/ReprovarOfertaNegociacao")]
        [HttpPut]
        public HttpResponseMessage ReprovarOfertaNegociacao(int OFN_Id, bool OFN_FlagVendedor, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.ReprovarOfertaNegociacao(OFN_Id);
                OfertaNegociacao objOfertaNegociacao = _OfertaNegociacaoAppServices.GetOfertaNegociacaoById(OFN_Id, true);

                //Disparo de E-mail Informações da OfertaNegociacao/demanda inconsistentes
                bool fValida;
                string temp = "";

                if (objOfertaNegociacao.OFN_FlagIngles == null)
                    objOfertaNegociacao.OFN_FlagIngles = false;

                string mensagemPT = objOfertaNegociacao.OfertaxQuantidadeProduto.Oferta.Produto.PDT_Nome + ", R$" + objOfertaNegociacao.OFN_ValorProposta;
                string mensagemEN = objOfertaNegociacao.OfertaxQuantidadeProduto.Oferta.Produto.PDT_NomeIngles + ", US$" + objOfertaNegociacao.OFN_ValorProposta;
                if (OFN_FlagVendedor == false)
                {//comprador recusou e o vendedor vai receber a msg
                 //if (objOfertaNegociacao.OFN_FlagIngles.Value)
                 //    fValida = SendMail.sendMailMessageNegociacao(objOfertaNegociacao.OfertaxQuantidadeProduto.Oferta.Empresa.Usuario.USR_Email, 17, "Your offer has already been published", 2, mensagem); //template 6 - padrão sem redes sociais             
                 //else
                    fValida = SendMail.sendMailMessageNegociacao(objOfertaNegociacao.OfertaxQuantidadeProduto.Oferta.Empresa.Usuario.USR_Email, 9, "Contra oferta recusada", 2, mensagemPT); //template 6 - padrão sem redes sociais
                    temp = "Vendedor";
                }
                else
                { //vendedor recusou e o comprador vai receber a msg
                    if (objOfertaNegociacao.OFN_FlagIngles.Value)
                        fValida = SendMail.sendMailMessageNegociacao(objOfertaNegociacao.Empresa.Usuario.USR_Email, 7, "Counter offer not accepted", 2, mensagemEN); //template 6 - padrão sem redes sociais             
                    else
                        fValida = SendMail.sendMailMessageNegociacao(objOfertaNegociacao.Empresa.Usuario.USR_Email, 6, "Contra oferta recusada", 2, mensagemPT); //template 6 - padrão sem redes sociais
                    temp = "Comprador";
                }

                if (fValida)
                    objOfertaNegociacao.mensagemSucesso = "Foi enviado um email ao " + temp + "!";
                else
                    objOfertaNegociacao.mensagemSucesso = "Ocorreu um erro ao enviar o e-mail ao usuário. Entre em contato com o administrador do sistema!";



                return Request.CreateResponse(HttpStatusCode.OK, objOfertaNegociacao);
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
        }

        [Route("api/OfertaNegociacao/GetOfertaNegociacaoByEmpresaId")]
        [HttpPost]
        public HttpResponseMessage GetOfertaNegociacaoByEmpresaId(int EmpresaId, bool fSomenteAtivos, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.GetOfertaNegociacaoByEmpresaId(EmpresaId, fSomenteAtivos, maxInstances, order_by);
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

        [Route("api/OfertaNegociacao/OfertaNegociacaoLiberaOfertador")]
        [HttpPut]
        public HttpResponseMessage OfertaNegociacaoLiberaOfertador(int OFN_Id, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.OfertaNegociacaoLiberaOfertador(OFN_Id);
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

        [Route("api/OfertaNegociacao/OfertaNegociacaoLiberaCliente")]
        [HttpPut]
        public HttpResponseMessage OfertaNegociacaoLiberaCliente(int OFN_Id,Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.OfertaNegociacaoLiberaCliente(OFN_Id);
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

        [Route("api/OfertaNegociacao/UpdateOfertaNegociacaoDirectto")]
        [HttpPut]
        public HttpResponseMessage UpdateOfertaNegociacaoDirectto(int OFN_Id, int OFN_MeioTransporteId, DateTime OFN_DataEmbarque, DateTime OFN_DataEstimativaEmbarque, string OFN_TermosPagamento, int OFN_StatusPagamentoId, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.UpdateOfertaNegociacaoDirectto(OFN_Id, OFN_MeioTransporteId, OFN_DataEmbarque, OFN_DataEstimativaEmbarque, OFN_TermosPagamento, OFN_StatusPagamentoId);
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

        [Route("api/OfertaNegociacao/UpdateEtapaNegociacaoDirectto")]
        [HttpPut]
        public HttpResponseMessage UpdateEtapaNegociacaoDirectto(int OFN_Id, int OFN_EtapaNegociacaoDirectto, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.UpdateEtapaNegociacaoDirectto(OFN_Id, OFN_EtapaNegociacaoDirectto);
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

        [Route("api/OfertaNegociacao/UpdateEtapaNegociacaoOfertador")]
        [HttpPut]
        public HttpResponseMessage UpdateEtapaNegociacaoOfertador(int OFN_Id, int OFN_EtapaNegociacaoOfertador, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.UpdateEtapaNegociacaoOfertador(OFN_Id, OFN_EtapaNegociacaoOfertador);
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
        [Route("api/OfertaNegociacao/UpdateEtapaNegociacaoCliente")]
        [HttpPut]
        public HttpResponseMessage UpdateEtapaNegociacaoCliente(int OFN_Id, int OFN_EtapaNegociacaoCliente, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.UpdateEtapaNegociacaoCliente(OFN_Id, OFN_EtapaNegociacaoCliente);
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
        [Route("api/OfertaNegociacao/UpdateEtapaNegociacaoDatas")]
        [HttpPut]
        public HttpResponseMessage UpdateEtapaNegociacaoDatas(int OFN_Id, string CampoData, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.UpdateEtapaNegociacaoDatas(OFN_Id, CampoData);
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

        [Route("api/OfertaNegociacao/EnvioEmailContato")]
        [HttpPost]
        public HttpResponseMessage EnvioEmailContato(int empresaId, string mensagem, bool flagIngles)
        {            
            try
            { 
                //buscar pelo empresaid
                var empresa = _EmpresaAppServices.GetEmpresaById(empresaId, true);

                //enviar msg
                bool fValida;
                if (!flagIngles)
                    fValida = SendMail.sendMailMessageNegociacao(empresa.Usuario.USR_Email, 12, "Nova Notificação", 2, mensagem); //template 15 
                else
                    fValida = SendMail.sendMailMessageNegociacao(empresa.Usuario.USR_Email, 13, "New Notification", 2, mensagem); //template 15E 
                return Request.CreateResponse(HttpStatusCode.OK, "E-mail enviado com sucesso!");
               
            }
            catch (Exception e)
            {
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            
        }


        [Route("api/OfertaNegociacao/ValidaExistenciaNegociacao")]
        [HttpPut]
        public HttpResponseMessage ValidaExistenciaNegociacao(int OfertaId, Log Log)
        {
            try
            {
                var item = _OfertaNegociacaoAppServices.ValidaExistenciaNegociacao(OfertaId);

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

    }
}
