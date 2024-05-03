
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TipoProdutoServices : ITipoProdutoServices
    {
        private readonly ITipoProdutoRepository _TipoProdutoRepo;

        public TipoProdutoServices(ITipoProdutoRepository TipoProdutoRepo)
        {
            _TipoProdutoRepo = TipoProdutoRepo;
        }

        public TipoProduto InsertTipoProduto(TipoProduto objTipoProduto)
        {
            return _TipoProdutoRepo.InsertTipoProduto(objTipoProduto);
        }

        public bool UpdateTipoProduto(TipoProduto objTipoProduto)
        {
            return _TipoProdutoRepo.UpdateTipoProduto(objTipoProduto);
        }

        public bool AtivarTipoProduto(int TPR_Id)
        {
            return _TipoProdutoRepo.AtivarTipoProduto(TPR_Id);
        }

        public bool DeletarTipoProduto(int TPR_Id)
        {
            return _TipoProdutoRepo.DeletarTipoProduto(TPR_Id);
        }

        public TipoProduto GetTipoProdutoById(int TPR_Id, bool join)
        {
            return _TipoProdutoRepo.GetTipoProdutoById(TPR_Id, join);
        }

        public IEnumerable<TipoProduto> GetAllTipoProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoProdutoRepo.GetAllTipoProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoProduto> GetAllTipoProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoProdutoRepo.GetAllTipoProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoProduto> GetAllTipoProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoProdutoRepo.GetAllTipoProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

