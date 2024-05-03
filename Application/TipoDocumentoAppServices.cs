
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TipoDocumentoAppServices : ITipoDocumentoAppServices
    {
        private readonly ITipoDocumentoServices _TipoDocumentoServices;
             

        public TipoDocumentoAppServices(ITipoDocumentoServices TipoDocumentoServices      )
        {
            _TipoDocumentoServices = TipoDocumentoServices;
               
        }

        public TipoDocumento InsertTipoDocumento(TipoDocumento objTipoDocumento)
        {
                 
            
            return _TipoDocumentoServices.InsertTipoDocumento(objTipoDocumento);
        }

        public bool UpdateTipoDocumento(TipoDocumento objTipoDocumento)
        {            
                
            return _TipoDocumentoServices.UpdateTipoDocumento(objTipoDocumento);
        }

        public bool AtivarTipoDocumento(int TDC_Id)
        {
            return _TipoDocumentoServices.AtivarTipoDocumento(TDC_Id);
        }

        public bool DeletarTipoDocumento(int TDC_Id)
        {
            return _TipoDocumentoServices.DeletarTipoDocumento(TDC_Id);
        }

        public TipoDocumento GetTipoDocumentoById(int TDC_Id, bool join)
        {
            return _TipoDocumentoServices.GetTipoDocumentoById(TDC_Id, join);
        }

        public IEnumerable<TipoDocumento> GetAllTipoDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoDocumentoServices.GetAllTipoDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoDocumento> GetAllTipoDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoDocumentoServices.GetAllTipoDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoDocumento> GetAllTipoDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoDocumentoServices.GetAllTipoDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

