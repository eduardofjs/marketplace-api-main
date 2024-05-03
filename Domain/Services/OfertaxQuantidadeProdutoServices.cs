using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class OfertaxQuantidadeProdutoServices : IOfertaxQuantidadeProdutoServices
    {
        private readonly IOfertaxQuantidadeProdutoRepository _OfertaxQuantidadeProdutoRepo;

        public OfertaxQuantidadeProdutoServices(IOfertaxQuantidadeProdutoRepository OfertaxQuantidadeProdutoRepo)
        {
            _OfertaxQuantidadeProdutoRepo = OfertaxQuantidadeProdutoRepo;
        }

        public OfertaxQuantidadeProduto InsertOfertaxQuantidadeProduto(OfertaxQuantidadeProduto objOfertaxQuantidadeProduto)
        {
            return _OfertaxQuantidadeProdutoRepo.InsertOfertaxQuantidadeProduto(objOfertaxQuantidadeProduto);
        }

        public bool UpdateOfertaxQuantidadeProduto(OfertaxQuantidadeProduto objOfertaxQuantidadeProduto)
        {
            return _OfertaxQuantidadeProdutoRepo.UpdateOfertaxQuantidadeProduto(objOfertaxQuantidadeProduto);
        }

        public bool AtivarOfertaxQuantidadeProduto(int OXQ_Id)
        {
            return _OfertaxQuantidadeProdutoRepo.AtivarOfertaxQuantidadeProduto(OXQ_Id);
        }

        public bool DeletarOfertaxQuantidadeProduto(int OXQ_Id)
        {
            return _OfertaxQuantidadeProdutoRepo.DeletarOfertaxQuantidadeProduto(OXQ_Id);
        }

        public OfertaxQuantidadeProduto GetOfertaxQuantidadeProdutoById(int OXQ_Id, bool join)
        {
            return _OfertaxQuantidadeProdutoRepo.GetOfertaxQuantidadeProdutoById(OXQ_Id, join);
        }

        public IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxQuantidadeProdutoRepo.GetAllOfertaxQuantidadeProduto(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxQuantidadeProdutoRepo.GetAllOfertaxQuantidadeProdutoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxQuantidadeProdutoRepo.GetAllOfertaxQuantidadeProdutoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarOfertaxQuantidadeProdutoByOferta(int OXQ_OfertaId)
        {
            return _OfertaxQuantidadeProdutoRepo.DeletarOfertaxQuantidadeProdutoByOferta(OXQ_OfertaId);
        }

        public IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProdutoByFiltro(string produto = "", int idCategoria = 0, int idSistemaProdutivo = 0, int idModoProducao = 0, int idStatusProduto = 0, int anoColheita = 0, decimal peso = 0, int idVolume = 0, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxQuantidadeProdutoRepo.GetAllOfertaxQuantidadeProdutoByFiltro(produto, idCategoria, idSistemaProdutivo, idModoProducao, idStatusProduto, anoColheita, peso, idVolume, maxInstances, order_by);
        }
    }
}


