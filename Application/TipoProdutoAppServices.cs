
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TipoProdutoAppServices : ITipoProdutoAppServices
    {
        private readonly ITipoProdutoServices _TipoProdutoServices;


        public TipoProdutoAppServices(ITipoProdutoServices TipoProdutoServices)
        {
            _TipoProdutoServices = TipoProdutoServices;

        }

        public TipoProduto InsertTipoProduto(TipoProduto objTipoProduto)
        {


            return _TipoProdutoServices.InsertTipoProduto(objTipoProduto);
        }

        public bool UpdateTipoProduto(TipoProduto objTipoProduto)
        {

            return _TipoProdutoServices.UpdateTipoProduto(objTipoProduto);
        }

        public bool AtivarTipoProduto(int TPR_Id)
        {
            return _TipoProdutoServices.AtivarTipoProduto(TPR_Id);
        }

        public bool DeletarTipoProduto(int TPR_Id)
        {
            return _TipoProdutoServices.DeletarTipoProduto(TPR_Id);
        }

        public TipoProduto GetTipoProdutoById(int TPR_Id, bool join)
        {
            return _TipoProdutoServices.GetTipoProdutoById(TPR_Id, join);
        }

        public IEnumerable<TipoProduto> GetAllTipoProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoProdutoServices.GetAllTipoProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoProduto> GetAllTipoProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoProdutoServices.GetAllTipoProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoProduto> GetAllTipoProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoProdutoServices.GetAllTipoProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

