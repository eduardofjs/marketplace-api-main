using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IOfertaxQuantidadeProdutoServices
    {
        OfertaxQuantidadeProduto InsertOfertaxQuantidadeProduto(OfertaxQuantidadeProduto objOfertaxQuantidadeProduto);
        bool UpdateOfertaxQuantidadeProduto(OfertaxQuantidadeProduto objOfertaxQuantidadeProduto);
        bool AtivarOfertaxQuantidadeProduto(int OXQ_Id);
        bool DeletarOfertaxQuantidadeProduto(int OXQ_Id);
        bool DeletarOfertaxQuantidadeProdutoByOferta(int OXQ_OfertaId);
        OfertaxQuantidadeProduto GetOfertaxQuantidadeProdutoById(int OXQ_Id, bool join);
        IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProdutoByFiltro(string produto = "", int idCategoria = 0, int idSistemaProdutivo = 0, int idModoProducao = 0, int idStatusProduto = 0, int anoColheita = 0, decimal peso = 0, int idVolume = 0, int maxInstances = 0, string order_by = "");
    }
}
