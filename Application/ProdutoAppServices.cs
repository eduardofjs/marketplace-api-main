
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ProdutoAppServices : IProdutoAppServices
    {
        private readonly IProdutoServices _ProdutoServices;


        public ProdutoAppServices(IProdutoServices ProdutoServices)
        {
            _ProdutoServices = ProdutoServices;

        }

        public Produto InsertProduto(Produto objProduto)
        {


            return _ProdutoServices.InsertProduto(objProduto);
        }

        public bool UpdateProduto(Produto objProduto)
        {

            return _ProdutoServices.UpdateProduto(objProduto);
        }

        public bool AtivarProduto(int PDT_Id)
        {
            return _ProdutoServices.AtivarProduto(PDT_Id);
        }

        public bool DeletarProduto(int PDT_Id)
        {
            return _ProdutoServices.DeletarProduto(PDT_Id);
        }

        public Produto GetProdutoById(int PDT_Id, bool join)
        {
            return _ProdutoServices.GetProdutoById(PDT_Id, join);
        }

        public IEnumerable<Produto> GetAllProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ProdutoServices.GetAllProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Produto> GetAllProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ProdutoServices.GetAllProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Produto> GetAllProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ProdutoServices.GetAllProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

