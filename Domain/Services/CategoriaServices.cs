using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoriaRepository _CategoriaRepo;

        public CategoriaServices(ICategoriaRepository CategoriaRepo)
        {
            _CategoriaRepo = CategoriaRepo;
        }

        public Categoria InsertCategoria(Categoria objCategoria)
        {
            return _CategoriaRepo.InsertCategoria(objCategoria);
        }

        public bool UpdateCategoria(Categoria objCategoria)
        {
            return _CategoriaRepo.UpdateCategoria(objCategoria);
        }

        public bool AtivarCategoria(int CAT_Id)
        {
            return _CategoriaRepo.AtivarCategoria(CAT_Id);
        }

        public bool DeletarCategoria(int CAT_Id)
        {
            return _CategoriaRepo.DeletarCategoria(CAT_Id);
        }

        public Categoria GetCategoriaById(int CAT_Id, bool join)
        {
            return _CategoriaRepo.GetCategoriaById(CAT_Id, join);
        }

        public IEnumerable<Categoria> GetAllCategoria(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CategoriaRepo.GetAllCategoria(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Categoria> GetAllCategoriaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CategoriaRepo.GetAllCategoriaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Categoria> GetAllCategoriaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CategoriaRepo.GetAllCategoriaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}


