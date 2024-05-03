
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TipoEmpresaAppServices : ITipoEmpresaAppServices
    {
        private readonly ITipoEmpresaServices _TipoEmpresaServices;
             

        public TipoEmpresaAppServices(ITipoEmpresaServices TipoEmpresaServices      )
        {
            _TipoEmpresaServices = TipoEmpresaServices;
               
        }

        public TipoEmpresa InsertTipoEmpresa(TipoEmpresa objTipoEmpresa)
        {
                 
            
            return _TipoEmpresaServices.InsertTipoEmpresa(objTipoEmpresa);
        }

        public bool UpdateTipoEmpresa(TipoEmpresa objTipoEmpresa)
        {            
                
            return _TipoEmpresaServices.UpdateTipoEmpresa(objTipoEmpresa);
        }

        public bool AtivarTipoEmpresa(int TEM_Id)
        {
            return _TipoEmpresaServices.AtivarTipoEmpresa(TEM_Id);
        }

        public bool DeletarTipoEmpresa(int TEM_Id)
        {
            return _TipoEmpresaServices.DeletarTipoEmpresa(TEM_Id);
        }

        public TipoEmpresa GetTipoEmpresaById(int TEM_Id, bool join)
        {
            return _TipoEmpresaServices.GetTipoEmpresaById(TEM_Id, join);
        }

        public IEnumerable<TipoEmpresa> GetAllTipoEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoEmpresaServices.GetAllTipoEmpresa(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoEmpresa> GetAllTipoEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoEmpresaServices.GetAllTipoEmpresaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoEmpresa> GetAllTipoEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoEmpresaServices.GetAllTipoEmpresaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

