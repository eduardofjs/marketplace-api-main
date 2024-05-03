
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class StatusProdutoServices : IStatusProdutoServices
    {
        private readonly IStatusProdutoRepository _StatusProdutoRepo;

        public StatusProdutoServices(IStatusProdutoRepository StatusProdutoRepo)
        {
            _StatusProdutoRepo = StatusProdutoRepo;
        }

        public StatusProduto InsertStatusProduto(StatusProduto objStatusProduto)
        {
            return _StatusProdutoRepo.InsertStatusProduto(objStatusProduto);
        }

        public bool UpdateStatusProduto(StatusProduto objStatusProduto)
        {
            return _StatusProdutoRepo.UpdateStatusProduto(objStatusProduto);
        }

        public bool AtivarStatusProduto(int SPR_Id)
        {
            return _StatusProdutoRepo.AtivarStatusProduto(SPR_Id);
        }

        public bool DeletarStatusProduto(int SPR_Id)
        {
            return _StatusProdutoRepo.DeletarStatusProduto(SPR_Id);
        }

        public StatusProduto GetStatusProdutoById(int SPR_Id, bool join)
        {
            return _StatusProdutoRepo.GetStatusProdutoById(SPR_Id, join);
        }

        public IEnumerable<StatusProduto> GetAllStatusProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusProdutoRepo.GetAllStatusProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusProduto> GetAllStatusProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusProdutoRepo.GetAllStatusProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusProduto> GetAllStatusProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusProdutoRepo.GetAllStatusProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

