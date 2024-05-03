using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria InsertCategoria(Categoria objCategoria);
        bool UpdateCategoria(Categoria objCategoria);
        bool AtivarCategoria(int CAT_Id);
        bool DeletarCategoria(int CAT_Id);
        Categoria GetCategoriaById(int CAT_Id, bool join);
        IEnumerable<Categoria> GetAllCategoria(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Categoria> GetAllCategoriaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Categoria> GetAllCategoriaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
