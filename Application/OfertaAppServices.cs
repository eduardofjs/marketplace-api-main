using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class OfertaAppServices : IOfertaAppServices
    {
        private readonly IOfertaServices _OfertaServices;
        private readonly IOfertaNegociacaoServices _OfertaNegociacaoServices;
        private readonly IOfertaxServicoAdicionalServices _OfertaxServicoAdicionalServices;
        private readonly IOfertaxServicoOpcionalServices _OfertaxServicoOpcionalServices;
        private readonly IOfertaxQuantidadeProdutoServices _OfertaxQuantidadeProdutoServices;
        private readonly IOfertaxCertificacaoServices _OfertaxCertificacaoServices;
        private readonly IOfertaxDocumentoServices _OfertaxDocumentoServices;
        private readonly IProdutoServices _ProdutoServices;
        private readonly IEnderecoServices _EnderecoServices;

        public OfertaAppServices(IOfertaServices OfertaServices, IOfertaNegociacaoServices OfertaNegociacaoServices, IOfertaxServicoAdicionalServices OfertaxServicoAdicionalServices, IOfertaxServicoOpcionalServices OfertaxServicoOpcionalServices, IOfertaxQuantidadeProdutoServices OfertaxQuantidadeProdutoServices, IOfertaxCertificacaoServices OfertaxCertificacaoServices, IOfertaxDocumentoServices OfertaxDocumentoServices, IProdutoServices ProdutoServices, IEnderecoServices EnderecoServices)
        {
            _OfertaServices = OfertaServices;
            _OfertaNegociacaoServices = OfertaNegociacaoServices;
            _OfertaxServicoAdicionalServices = OfertaxServicoAdicionalServices;
            _OfertaxServicoOpcionalServices = OfertaxServicoOpcionalServices;
            _OfertaxQuantidadeProdutoServices = OfertaxQuantidadeProdutoServices;
            _OfertaxCertificacaoServices = OfertaxCertificacaoServices;
            _OfertaxDocumentoServices = OfertaxDocumentoServices;
            _ProdutoServices = ProdutoServices;
            _EnderecoServices = EnderecoServices;
        }

        public Oferta InsertOferta(Oferta objOferta)
        {

            if (objOferta.OFE_ProdutoId == 0 && objOferta.Produto != null)
            {
                Produto produto = new Produto();
                produto.PDT_Id = 0;
                produto.PDT_Nome = objOferta.Produto.PDT_Nome;
                produto.PDT_NomeIngles = objOferta.Produto.PDT_NomeIngles;
                produto.PDT_FlagAtivo = true;
                produto.PDT_UsuarioInsercaoId = objOferta.OFE_UsuarioInsercaoId;
                objOferta.Produto = _ProdutoServices.InsertProduto(produto);
                objOferta.OFE_ProdutoId = objOferta.Produto.PDT_Id;
            }

            if (objOferta.Endereco != null)
            {
                Endereco endereco = new Endereco();
                endereco = objOferta.Endereco;
                endereco.END_Id = 0;

                objOferta.Endereco = _EnderecoServices.InsertEndereco(endereco);
                objOferta.OFE_EnderecoOrigemId = objOferta.Endereco.END_Id;
            }

            var oferta = _OfertaServices.InsertOferta(objOferta);


            if (objOferta.listaOfertaxServicoAdicional != null && objOferta.listaOfertaxServicoAdicional.Count > 0)
            {
                List<OfertaxServicoAdicional> lista = new List<OfertaxServicoAdicional>();
                //_OfertaxServicoAdicionalServices.DeletarOfertaxServicoAdicionalByEmpresa(objOferta.OFE_Id);
                foreach (OfertaxServicoAdicional item in objOferta.listaOfertaxServicoAdicional)
                {
                    item.OXA_OfertaId = objOferta.OFE_Id;
                    item.OXA_FlagAtivo = false;
                    var data = _OfertaxServicoAdicionalServices.InsertOfertaxServicoAdicional(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxServicoAdicional = lista;
            }

            if (objOferta.listaOfertaxServicoOpcional != null && objOferta.listaOfertaxServicoOpcional.Count > 0)
            {
                List<OfertaxServicoOpcional> lista = new List<OfertaxServicoOpcional>();
                //_OfertaxServicoOpcionalServices.DeletarOfertaxServicoOpcionalByEmpresa(objOferta.OFE_Id);
                foreach (OfertaxServicoOpcional item in objOferta.listaOfertaxServicoOpcional)
                {
                    item.OXS_OfertaId = objOferta.OFE_Id;
                    item.OXS_FlagAtivo = false;
                    var data = _OfertaxServicoOpcionalServices.InsertOfertaxServicoOpcional(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxServicoOpcional = lista;
            }

            if (objOferta.listaOfertaxQuantidadeProduto != null && objOferta.listaOfertaxQuantidadeProduto.Count > 0)
            {
                List<OfertaxQuantidadeProduto> lista = new List<OfertaxQuantidadeProduto>();
                //_OfertaxQuantidadeProdutoServices.DeletarOfertaxQuantidadeProdutoByEmpresa(objOferta.OFE_Id);
                foreach (OfertaxQuantidadeProduto item in objOferta.listaOfertaxQuantidadeProduto)
                {
                    item.OXQ_OfertaId = objOferta.OFE_Id;
                    item.OXQ_FlagAtivo = false;
                    var data = _OfertaxQuantidadeProdutoServices.InsertOfertaxQuantidadeProduto(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxQuantidadeProduto = lista;
            }

            if (objOferta.listaOfertaxCertificacao != null && objOferta.listaOfertaxCertificacao.Count > 0)
            {
                List<OfertaxCertificacao> lista = new List<OfertaxCertificacao>();
                //_OfertaxCertificacaoServices.DeletarOfertaxCertificacaoByEmpresa(objOferta.OFE_Id);
                foreach (OfertaxCertificacao item in objOferta.listaOfertaxCertificacao)
                {
                    item.OXC_OfertaId = objOferta.OFE_Id;
                    item.OXC_FlagAtivo = false;
                    var data = _OfertaxCertificacaoServices.InsertOfertaxCertificacao(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxCertificacao = lista;
            }

            if (objOferta.listaOfertaxDocumento != null && objOferta.listaOfertaxDocumento.Count > 0)
            {
                List<OfertaxDocumento> lista = new List<OfertaxDocumento>();
                //_OfertaxDocumentoServices.DeletarOfertaxDocumentoByEmpresa(objOferta.OFE_Id);
                foreach (OfertaxDocumento item in objOferta.listaOfertaxDocumento)
                {
                    item.OXD_OfertaId = objOferta.OFE_Id;
                    item.OXD_FlagAtivo = true;
                    var data = _OfertaxDocumentoServices.InsertOfertaxDocumento(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxDocumento = lista;
            }

            return oferta;
        }

        public bool UpdateOferta(Oferta objOferta)
        {
            if (objOferta.Produto != null)
            {
                Produto produto = new Produto();                
                produto.PDT_Nome = objOferta.Produto.PDT_Nome;
                produto.PDT_NomeIngles = objOferta.Produto.PDT_NomeIngles;
                produto.PDT_FlagAtivo = true;
                produto.PDT_UsuarioInsercaoId = objOferta.OFE_UsuarioInsercaoId;
                if (objOferta.OFE_ProdutoId == 0)
                {
                    produto.PDT_Id = 0;
                    objOferta.Produto = _ProdutoServices.InsertProduto(produto);
                }
                else
                    _ProdutoServices.UpdateProduto(produto);
                objOferta.OFE_ProdutoId = objOferta.Produto.PDT_Id;
            }

            if (objOferta.Endereco != null)
            {
                Endereco endereco = new Endereco();
                endereco = objOferta.Endereco;
                if (endereco.END_Id == 0)
                    objOferta.Endereco = _EnderecoServices.InsertEndereco(endereco);
                else
                    _EnderecoServices.UpdateEndereco(endereco);
                objOferta.OFE_EnderecoOrigemId = objOferta.Endereco.END_Id;
            }

            return _OfertaServices.UpdateOferta(objOferta);
        }

        public bool AtivarOferta(int OFE_Id)
        {
            return _OfertaServices.AtivarOferta(OFE_Id);
        }

        public bool DeletarOferta(int OFE_Id)
        {
            return _OfertaServices.DeletarOferta(OFE_Id);
        }

        public Oferta GetOfertaById(int OFE_Id, bool join)
        {
            return _OfertaServices.GetOfertaById(OFE_Id, join);
        }

        public IEnumerable<Oferta> GetAllOferta(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaServices.GetAllOferta(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Oferta> GetAllOfertaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaServices.GetAllOfertaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Oferta> GetAllOfertaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaServices.GetAllOfertaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool AprovarOferta(int OFE_Id)
        {
            return _OfertaServices.AprovarOferta(OFE_Id);
        }

        public bool ReprovarOferta(int OFE_Id)
        {
            return _OfertaServices.ReprovarOferta(OFE_Id);
        }

        public Oferta GetOfertaEditarById(int OFE_Id, bool join)
        {
            return _OfertaServices.GetOfertaEditarById(OFE_Id, join);
        }
    }
}

