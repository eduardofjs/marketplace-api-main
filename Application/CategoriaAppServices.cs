
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class CategoriaAppServices : ICategoriaAppServices
    {
        private readonly ICategoriaServices _CategoriaServices;


        public CategoriaAppServices(ICategoriaServices CategoriaServices)
        {
            _CategoriaServices = CategoriaServices;

        }

        public Categoria InsertCategoria(Categoria objCategoria)
        {


            return _CategoriaServices.InsertCategoria(objCategoria);
        }

        public bool UpdateCategoria(Categoria objCategoria)
        {

            return _CategoriaServices.UpdateCategoria(objCategoria);
        }

        public bool AtivarCategoria(int CAT_Id)
        {
            return _CategoriaServices.AtivarCategoria(CAT_Id);
        }

        public bool DeletarCategoria(int CAT_Id)
        {
            return _CategoriaServices.DeletarCategoria(CAT_Id);
        }

        public Categoria GetCategoriaById(int CAT_Id, bool join)
        {
            return _CategoriaServices.GetCategoriaById(CAT_Id, join);
        }

        public IEnumerable<Categoria> GetAllCategoria(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CategoriaServices.GetAllCategoria(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Categoria> GetAllCategoriaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CategoriaServices.GetAllCategoriaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Categoria> GetAllCategoriaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CategoriaServices.GetAllCategoriaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

