
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class EmpresaAppServices : IEmpresaAppServices
    {
        private readonly IEmpresaServices _EmpresaServices;
        private readonly ITipoEmpresaServices _TipoEmpresaServices;
        private readonly IEnderecoServices _EnderecoServices;

        private readonly IUsuarioAppServices _UsuarioServices;
        private readonly IEmpresaxDocumentoServices _EmpresaxDocumentoServices;
        private readonly IEmpresaxLogisticaServices _EmpresaxLogisticaServices;
        private readonly IEmpresaxServicoAdicionalServices _EmpresaxServicoAdicionalServices;
        private readonly IEmpresaxServicoFinanceiroServices _EmpresaxServicoFinanceiroServices;
        private readonly IEmpresaxProdutoServices _EmpresaxProdutoServices;
        private readonly IProdutoServices _ProdutoServices;

        public EmpresaAppServices(IEmpresaServices EmpresaServices, ITipoEmpresaServices TipoEmpresaServices, IEmpresaxDocumentoServices EmpresaxDocumentoServices, IEmpresaxLogisticaServices EmpresaxLogisticaServices, IEmpresaxServicoAdicionalServices EmpresaxServicoAdicionalServices, IEmpresaxServicoFinanceiroServices EmpresaxServicoFinanceiroServices, IUsuarioAppServices UsuarioServices, IEnderecoServices EnderecoServices, IEmpresaxProdutoServices EmpresaxProdutoServices, IProdutoServices ProdutoServices)
        {            
            _EmpresaServices = EmpresaServices;
            _TipoEmpresaServices = TipoEmpresaServices;
            _EmpresaxDocumentoServices = EmpresaxDocumentoServices;
            _EmpresaxLogisticaServices = EmpresaxLogisticaServices;
            _EmpresaxServicoAdicionalServices = EmpresaxServicoAdicionalServices;
            _EmpresaxServicoFinanceiroServices = EmpresaxServicoFinanceiroServices;
            _UsuarioServices = UsuarioServices;
            _EnderecoServices = EnderecoServices;
            _EmpresaxProdutoServices = EmpresaxProdutoServices;
            _ProdutoServices = ProdutoServices;
        }

        public Empresa InsertEmpresa(Empresa objEmpresa)
        {
            if (objEmpresa.TipoEmpresa != null)
            {
                objEmpresa.TipoEmpresa = _TipoEmpresaServices.InsertTipoEmpresa(objEmpresa.TipoEmpresa);
                objEmpresa.EMP_TipoEmpresaId = objEmpresa.TipoEmpresa.TEM_Id;
            }
            if (objEmpresa.Usuario != null)
            {
                objEmpresa.Usuario = _UsuarioServices.InsertUsuario(objEmpresa.Usuario);
                objEmpresa.EMP_UsuarioId = objEmpresa.Usuario.USR_Id;
                if (!objEmpresa.Usuario.sucesso)
                    return objEmpresa;
            }
            else
            {
                objEmpresa.Usuario = _UsuarioServices.GetUsuarioById(objEmpresa.EMP_UsuarioId,true);
                objEmpresa.Usuario.sucesso = true;
            }
            if (objEmpresa.Endereco != null)
            {
                objEmpresa.Endereco = _EnderecoServices.InsertEndereco(objEmpresa.Endereco);
                objEmpresa.EMP_EnderecoId = objEmpresa.Endereco.END_Id;
            }

            if (objEmpresa.EMP_Ativo == null)
                objEmpresa.EMP_Ativo = true;
            if (objEmpresa.EMP_FlagAprovado == null)
                objEmpresa.EMP_FlagAprovado = false;
            if (objEmpresa.EMP_DataAbertura == null || objEmpresa.EMP_DataAbertura.Year == 1)
                objEmpresa.EMP_DataAbertura = DateTime.Now;            
            objEmpresa.EMP_DataCadastro = DateTime.Now;
            Empresa emp = _EmpresaServices.InsertEmpresa(objEmpresa);
            objEmpresa.EMP_Id = emp.EMP_Id;

            if (objEmpresa.listaEmpresaxDocumento != null && objEmpresa.listaEmpresaxDocumento.Count > 0)
            {
                List<EmpresaxDocumento> lista = new List<EmpresaxDocumento>();
                _EmpresaxDocumentoServices.DeletarEmpresaxDocumentoByEmpresa(objEmpresa.EMP_Id);
                foreach (EmpresaxDocumento item in objEmpresa.listaEmpresaxDocumento)
                {
                    var data = _EmpresaxDocumentoServices.InsertEmpresaxDocumento(item);
                    lista.Add(data);
                }

                objEmpresa.listaEmpresaxDocumento = lista;
            }

            if (objEmpresa.listaEmpresaxLogistica != null && objEmpresa.listaEmpresaxLogistica.Count > 0)
            {
                List<EmpresaxLogistica> lista = new List<EmpresaxLogistica>();
                _EmpresaxLogisticaServices.DeletarEmpresaxLogisticaByEmpresa(objEmpresa.EMP_Id);
                foreach (EmpresaxLogistica item in objEmpresa.listaEmpresaxLogistica)
                {
                    var data = _EmpresaxLogisticaServices.InsertEmpresaxLogistica(item);
                    lista.Add(data);
                }

                objEmpresa.listaEmpresaxLogistica = lista;
            }

            if (objEmpresa.listaEmpresaxServicoAdicional != null && objEmpresa.listaEmpresaxServicoAdicional.Count > 0)
            {
                List<EmpresaxServicoAdicional> lista = new List<EmpresaxServicoAdicional>();
                _EmpresaxServicoAdicionalServices.DeletarEmpresaxServicoAdicionalByEmpresa(objEmpresa.EMP_Id);
                foreach (EmpresaxServicoAdicional item in objEmpresa.listaEmpresaxServicoAdicional)
                {
                    var data = _EmpresaxServicoAdicionalServices.InsertEmpresaxServicoAdicional(item);
                    lista.Add(data);
                }

                objEmpresa.listaEmpresaxServicoAdicional = lista;
            }

            if (objEmpresa.listaEmpresaxServicoFinanceiro != null && objEmpresa.listaEmpresaxServicoFinanceiro.Count > 0)
            {
                List<EmpresaxServicoFinanceiro> lista = new List<EmpresaxServicoFinanceiro>();
                _EmpresaxServicoFinanceiroServices.DeletarEmpresaxServicoFinanceiroByEmpresa(objEmpresa.EMP_Id);
                foreach (EmpresaxServicoFinanceiro item in objEmpresa.listaEmpresaxServicoFinanceiro)
                {
                    var data = _EmpresaxServicoFinanceiroServices.InsertEmpresaxServicoFinanceiro(item);
                    lista.Add(data);
                }

                objEmpresa.listaEmpresaxServicoFinanceiro = lista;
            }

            if (objEmpresa.listaEmpresaxProduto != null && objEmpresa.listaEmpresaxProduto.Count > 0)
            {
            	List<EmpresaxProduto> lista = new List<EmpresaxProduto>();
            	_EmpresaxProdutoServices.DeletarEmpresaxProdutoByEmpresa(objEmpresa.EMP_Id);
            	foreach (EmpresaxProduto item in objEmpresa.listaEmpresaxProduto)
            	{
                    item.EXP_EmpresaId = objEmpresa.EMP_Id;
                    item.EXP_ProdutoId = item.Produto.PDT_Id;
                    item.EXP_FlagAtivo = true;
                    if (item.EXP_ProdutoId == 0 && item.Produto != null)
                    {
                        item.EXP_FlagAtivo = false;
                        _ProdutoServices.InsertProduto(item.Produto);
                    }
            		var data = _EmpresaxProdutoServices.InsertEmpresaxProduto(item);
            		lista.Add(data);
            	}
            
            	objEmpresa.listaEmpresaxProduto = lista;
            }
            return objEmpresa;
        }

        public bool UpdateEmpresa(Empresa objEmpresa)
        {
            if (objEmpresa.TipoEmpresa != null)
            {
                if (objEmpresa.TipoEmpresa.TEM_Id == 0)
                {
                    objEmpresa.TipoEmpresa = _TipoEmpresaServices.InsertTipoEmpresa(objEmpresa.TipoEmpresa);
                    objEmpresa.EMP_TipoEmpresaId = objEmpresa.TipoEmpresa.TEM_Id;
                }
                else
                {
                    bool flagTipoEmpresa = _TipoEmpresaServices.UpdateTipoEmpresa(objEmpresa.TipoEmpresa);
                }
            }

            if (objEmpresa.Usuario != null)
            {
                if (objEmpresa.Usuario.USR_Id == 0)
                {
                    objEmpresa.Usuario = _UsuarioServices.InsertUsuario(objEmpresa.Usuario);
                    objEmpresa.EMP_UsuarioId = objEmpresa.Usuario.USR_Id;
                }
                else
                {
                    bool flagUsuario = _UsuarioServices.UpdateUsuario(objEmpresa.Usuario);
                }
            }

            if (objEmpresa.Endereco != null)
            {
                if (objEmpresa.Endereco.END_Id == 0)
                {
                    objEmpresa.Endereco = _EnderecoServices.InsertEndereco(objEmpresa.Endereco);
                    objEmpresa.EMP_EnderecoId = objEmpresa.Endereco.END_Id;
                }
                else
                {
                    bool flagEndereco = _EnderecoServices.UpdateEndereco(objEmpresa.Endereco);
                }
            }

            bool emp = _EmpresaServices.UpdateEmpresa(objEmpresa);

            if (objEmpresa.listaEmpresaxDocumento != null && objEmpresa.listaEmpresaxDocumento.Count > 0)
            {
                List<EmpresaxDocumento> lista = new List<EmpresaxDocumento>();
                _EmpresaxDocumentoServices.DeletarEmpresaxDocumentoByEmpresa(objEmpresa.EMP_Id);
                foreach (EmpresaxDocumento item in objEmpresa.listaEmpresaxDocumento)
                {
                    var data = _EmpresaxDocumentoServices.InsertEmpresaxDocumento(item);
                    lista.Add(data);
                }

                objEmpresa.listaEmpresaxDocumento = lista;
            }

            if (objEmpresa.listaEmpresaxLogistica != null && objEmpresa.listaEmpresaxLogistica.Count > 0)
            {
                List<EmpresaxLogistica> lista = new List<EmpresaxLogistica>();
                _EmpresaxLogisticaServices.DeletarEmpresaxLogisticaByEmpresa(objEmpresa.EMP_Id);
                foreach (EmpresaxLogistica item in objEmpresa.listaEmpresaxLogistica)
                {
                    var data = _EmpresaxLogisticaServices.InsertEmpresaxLogistica(item);
                    lista.Add(data);
                }

                objEmpresa.listaEmpresaxLogistica = lista;
            }

            if (objEmpresa.listaEmpresaxServicoAdicional != null && objEmpresa.listaEmpresaxServicoAdicional.Count > 0)
            {
                List<EmpresaxServicoAdicional> lista = new List<EmpresaxServicoAdicional>();
                _EmpresaxServicoAdicionalServices.DeletarEmpresaxServicoAdicionalByEmpresa(objEmpresa.EMP_Id);
                foreach (EmpresaxServicoAdicional item in objEmpresa.listaEmpresaxServicoAdicional)
                {
                    var data = _EmpresaxServicoAdicionalServices.InsertEmpresaxServicoAdicional(item);
                    lista.Add(data);
                }

                objEmpresa.listaEmpresaxServicoAdicional = lista;
            }

            if (objEmpresa.listaEmpresaxServicoFinanceiro != null && objEmpresa.listaEmpresaxServicoFinanceiro.Count > 0)
            {
                List<EmpresaxServicoFinanceiro> lista = new List<EmpresaxServicoFinanceiro>();
                _EmpresaxServicoFinanceiroServices.DeletarEmpresaxServicoFinanceiroByEmpresa(objEmpresa.EMP_Id);
                foreach (EmpresaxServicoFinanceiro item in objEmpresa.listaEmpresaxServicoFinanceiro)
                {
                    var data = _EmpresaxServicoFinanceiroServices.InsertEmpresaxServicoFinanceiro(item);
                    lista.Add(data);
                }

                objEmpresa.listaEmpresaxServicoFinanceiro = lista;
            }

            if (objEmpresa.listaEmpresaxProduto != null && objEmpresa.listaEmpresaxProduto.Count > 0)
            {
                List<EmpresaxProduto> lista = new List<EmpresaxProduto>();
                _EmpresaxProdutoServices.DeletarEmpresaxProdutoByEmpresa(objEmpresa.EMP_Id);
                foreach (EmpresaxProduto item in objEmpresa.listaEmpresaxProduto)
                {
                    item.EXP_EmpresaId = objEmpresa.EMP_Id;
                    item.EXP_ProdutoId = item.Produto.PDT_Id;
                    item.EXP_FlagAtivo = true;
                    if (item.EXP_ProdutoId == 0 && item.Produto != null)
                    {
                        item.EXP_FlagAtivo = false;
                        _ProdutoServices.InsertProduto(item.Produto);
                    }
                    var data = _EmpresaxProdutoServices.InsertEmpresaxProduto(item);
                    lista.Add(data);
                }

                objEmpresa.listaEmpresaxProduto = lista;
            }
            return emp;
        }

        public bool AtivarEmpresa(int EMP_Id)
        {
            return _EmpresaServices.AtivarEmpresa(EMP_Id);
        }

        public bool DeletarEmpresa(int EMP_Id)
        {
            return _EmpresaServices.DeletarEmpresa(EMP_Id);
        }

        public Empresa GetEmpresaById(int EMP_Id, bool join)
        {
            return _EmpresaServices.GetEmpresaById(EMP_Id, join);
        }

        public IEnumerable<Empresa> GetAllEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaServices.GetAllEmpresa(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Empresa> GetAllEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaServices.GetAllEmpresaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Empresa> GetAllEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaServices.GetAllEmpresaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool AprovarEmpresa(int EMP_Id)
        {
            return _EmpresaServices.AprovarEmpresa(EMP_Id);
        }

        public bool ReprovarEmpresa(int EMP_Id)
        {
            return _EmpresaServices.ReprovarEmpresa(EMP_Id);
        }
    }
}

