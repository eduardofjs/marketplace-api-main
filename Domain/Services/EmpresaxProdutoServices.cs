using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class EmpresaxProdutoServices : IEmpresaxProdutoServices
    {
        private readonly IEmpresaxProdutoRepository _EmpresaxProdutoRepo;

        public EmpresaxProdutoServices(IEmpresaxProdutoRepository EmpresaxProdutoRepo)
        {
            _EmpresaxProdutoRepo = EmpresaxProdutoRepo;
        }

        public EmpresaxProduto InsertEmpresaxProduto(EmpresaxProduto objEmpresaxProduto)
        {
            return _EmpresaxProdutoRepo.InsertEmpresaxProduto(objEmpresaxProduto);
        }

        public bool UpdateEmpresaxProduto(EmpresaxProduto objEmpresaxProduto)
        {
            return _EmpresaxProdutoRepo.UpdateEmpresaxProduto(objEmpresaxProduto);
        }

        public bool AtivarEmpresaxProduto(int EXP_Id)
        {
            return _EmpresaxProdutoRepo.AtivarEmpresaxProduto(EXP_Id);
        }

        public bool DeletarEmpresaxProduto(int EXP_Id)
        {
            return _EmpresaxProdutoRepo.DeletarEmpresaxProduto(EXP_Id);
        }

        public EmpresaxProduto GetEmpresaxProdutoById(int EXP_Id, bool join)
        {
            return _EmpresaxProdutoRepo.GetEmpresaxProdutoById(EXP_Id, join);
        }

        public IEnumerable<EmpresaxProduto> GetAllEmpresaxProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxProdutoRepo.GetAllEmpresaxProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxProduto> GetAllEmpresaxProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxProdutoRepo.GetAllEmpresaxProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxProduto> GetAllEmpresaxProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxProdutoRepo.GetAllEmpresaxProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarEmpresaxProdutoByEmpresa(int EXP_EmpresaId)
        {
            return _EmpresaxProdutoRepo.DeletarEmpresaxProdutoByEmpresa(EXP_EmpresaId);
        }
    }
}


