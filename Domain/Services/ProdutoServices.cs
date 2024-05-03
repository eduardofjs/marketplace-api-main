
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoRepository _ProdutoRepo;

        public ProdutoServices(IProdutoRepository ProdutoRepo)
        {
            _ProdutoRepo = ProdutoRepo;
        }

        public Produto InsertProduto(Produto objProduto)
        {
            return _ProdutoRepo.InsertProduto(objProduto);
        }

        public bool UpdateProduto(Produto objProduto)
        {
            return _ProdutoRepo.UpdateProduto(objProduto);
        }

        public bool AtivarProduto(int PDT_Id)
        {
            return _ProdutoRepo.AtivarProduto(PDT_Id);
        }

        public bool DeletarProduto(int PDT_Id)
        {
            return _ProdutoRepo.DeletarProduto(PDT_Id);
        }

        public Produto GetProdutoById(int PDT_Id, bool join)
        {
            return _ProdutoRepo.GetProdutoById(PDT_Id, join);
        }

        public IEnumerable<Produto> GetAllProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ProdutoRepo.GetAllProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Produto> GetAllProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ProdutoRepo.GetAllProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Produto> GetAllProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ProdutoRepo.GetAllProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

