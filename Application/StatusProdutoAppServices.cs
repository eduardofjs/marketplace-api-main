
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class StatusProdutoAppServices : IStatusProdutoAppServices
    {
        private readonly IStatusProdutoServices _StatusProdutoServices;


        public StatusProdutoAppServices(IStatusProdutoServices StatusProdutoServices)
        {
            _StatusProdutoServices = StatusProdutoServices;

        }

        public StatusProduto InsertStatusProduto(StatusProduto objStatusProduto)
        {


            return _StatusProdutoServices.InsertStatusProduto(objStatusProduto);
        }

        public bool UpdateStatusProduto(StatusProduto objStatusProduto)
        {

            return _StatusProdutoServices.UpdateStatusProduto(objStatusProduto);
        }

        public bool AtivarStatusProduto(int SPR_Id)
        {
            return _StatusProdutoServices.AtivarStatusProduto(SPR_Id);
        }

        public bool DeletarStatusProduto(int SPR_Id)
        {
            return _StatusProdutoServices.DeletarStatusProduto(SPR_Id);
        }

        public StatusProduto GetStatusProdutoById(int SPR_Id, bool join)
        {
            return _StatusProdutoServices.GetStatusProdutoById(SPR_Id, join);
        }

        public IEnumerable<StatusProduto> GetAllStatusProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusProdutoServices.GetAllStatusProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusProduto> GetAllStatusProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusProdutoServices.GetAllStatusProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusProduto> GetAllStatusProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusProdutoServices.GetAllStatusProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

