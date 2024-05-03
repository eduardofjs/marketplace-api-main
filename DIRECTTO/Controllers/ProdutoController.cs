using Application.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Domain.Dto;
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
    public class ProdutoController : ApiController
    {
        private readonly IProdutoAppServices _ProdutoAppServices;
        private readonly IDigitalTwinAppServices _DigitalTwinAppServices;

        public ProdutoController(IProdutoAppServices ProdutoAppServices, IDigitalTwinAppServices DigitalTwinAppServices)
        {
            try
            {
                _ProdutoAppServices = ProdutoAppServices;
                _DigitalTwinAppServices = DigitalTwinAppServices;
            }
            catch (Exception e)
            {
                RepositoryBase.salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                HttpError err = new HttpError(message);
            }
        }

        [Route("api/Produto/AtivarProduto")]
        [HttpPut]
        public HttpResponseMessage AtivarProduto(int PDT_Id, Log Log)
        {
            try
            {
                var item = _ProdutoAppServices.AtivarProduto(PDT_Id);
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

        [Route("api/Produto/DeletarProduto")]
        [HttpPut]
        public HttpResponseMessage DeletarProduto(int PDT_Id, Log Log)
        {
            try
            {
                var item = _ProdutoAppServices.DeletarProduto(PDT_Id);
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

        [Route("api/Produto/GetAllProduto")]
        [HttpPost]
        public HttpResponseMessage GetAllProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ProdutoAppServices.GetAllProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
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

        [Route("api/Produto/GetAllProdutoByPartial")]
        [HttpPost]
        public HttpResponseMessage GetAllProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ProdutoAppServices.GetAllProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
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


        [Route("api/Produto/GetAllProdutoByValorExato")]
        [HttpPost]
        public HttpResponseMessage GetAllProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ProdutoAppServices.GetAllProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
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



        [Route("api/Produto/GetProdutoById")]
        [HttpPost]
        public HttpResponseMessage GetProdutoById(int PDT_Id, bool join, Log Log)
        {
            try
            {
                var item = _ProdutoAppServices.GetProdutoById(PDT_Id, join);
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

        [Route("api/Produto/GetListProduto")]
        [HttpPost]
        public HttpResponseMessage GetListProduto(bool join, int maxInstances, string order_by, Log Log)
        {
            try
            {
                var item = _ProdutoAppServices.GetAllProduto(true, true, join, maxInstances, order_by);
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

        [Route("api/Produto/CadastroProduto")]
        [HttpPut]
        public HttpResponseMessage CadastroProduto(Produto objProduto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduto.PDT_Id > 0)
                    {
                        // Atualizar produto Directto
                        var fUpdate = _ProdutoAppServices.UpdateProduto(objProduto);

                        // Integração Digital Twin para atualizar products
                        _DigitalTwinAppServices.UpdateProduct(new DigitalTwinProductDto(objProduto));

                        if (fUpdate)
                            return Request.CreateResponse(HttpStatusCode.OK, objProduto);
                        else
                            return Request.CreateResponse(HttpStatusCode.OK, new Produto());
                    }
                    else
                    {
                        // Intergração para cadastro de produto Directto
                        var fInsert = _ProdutoAppServices.InsertProduto(objProduto);

                        // Integração Digital Twin para cadastrar products
                        _DigitalTwinAppServices.InsertProduct(new DigitalTwinProductDto(fInsert));

                        return Request.CreateResponse(HttpStatusCode.OK, fInsert);
                    }
                }
                catch (Exception e)
                {
                    RepositoryBase.salvaLog(objProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    var message = string.Format(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, objProduto);
            }
        }

    }
}
