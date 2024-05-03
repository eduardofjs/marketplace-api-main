using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class EmpresaxProdutoAppServices : IEmpresaxProdutoAppServices
    {
        private readonly IEmpresaxProdutoServices _EmpresaxProdutoServices;


        public EmpresaxProdutoAppServices(IEmpresaxProdutoServices EmpresaxProdutoServices)
        {
            _EmpresaxProdutoServices = EmpresaxProdutoServices;

        }

        public EmpresaxProduto InsertEmpresaxProduto(EmpresaxProduto objEmpresaxProduto)
        {


            return _EmpresaxProdutoServices.InsertEmpresaxProduto(objEmpresaxProduto);
        }

        public bool UpdateEmpresaxProduto(EmpresaxProduto objEmpresaxProduto)
        {

            return _EmpresaxProdutoServices.UpdateEmpresaxProduto(objEmpresaxProduto);
        }

        public bool AtivarEmpresaxProduto(int EXP_Id)
        {
            return _EmpresaxProdutoServices.AtivarEmpresaxProduto(EXP_Id);
        }

        public bool DeletarEmpresaxProduto(int EXP_Id)
        {
            return _EmpresaxProdutoServices.DeletarEmpresaxProduto(EXP_Id);
        }

        public EmpresaxProduto GetEmpresaxProdutoById(int EXP_Id, bool join)
        {
            return _EmpresaxProdutoServices.GetEmpresaxProdutoById(EXP_Id, join);
        }

        public IEnumerable<EmpresaxProduto> GetAllEmpresaxProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxProdutoServices.GetAllEmpresaxProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxProduto> GetAllEmpresaxProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxProdutoServices.GetAllEmpresaxProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxProduto> GetAllEmpresaxProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxProdutoServices.GetAllEmpresaxProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarEmpresaxProdutoByEmpresa(int EXP_EmpresaId)
        {
            return _EmpresaxProdutoServices.DeletarEmpresaxProdutoByEmpresa(EXP_EmpresaId);
        }
    }
}
