
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TipoDocumentoServices : ITipoDocumentoServices
    {
        private readonly ITipoDocumentoRepository _TipoDocumentoRepo;

        public TipoDocumentoServices(ITipoDocumentoRepository TipoDocumentoRepo)
        {
            _TipoDocumentoRepo = TipoDocumentoRepo;
        }
		
        public TipoDocumento InsertTipoDocumento(TipoDocumento objTipoDocumento)
        {
            return _TipoDocumentoRepo.InsertTipoDocumento(objTipoDocumento);
        }

        public bool UpdateTipoDocumento(TipoDocumento objTipoDocumento)
        {
            return _TipoDocumentoRepo.UpdateTipoDocumento(objTipoDocumento);
        }

        public bool AtivarTipoDocumento(int TDC_Id)
        {
            return _TipoDocumentoRepo.AtivarTipoDocumento(TDC_Id);
        }

        public bool DeletarTipoDocumento(int TDC_Id)
        {
            return _TipoDocumentoRepo.DeletarTipoDocumento(TDC_Id);
        }
        
        public TipoDocumento GetTipoDocumentoById(int TDC_Id, bool join)
        {
            return _TipoDocumentoRepo.GetTipoDocumentoById(TDC_Id, join);
        }

        public IEnumerable<TipoDocumento> GetAllTipoDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoDocumentoRepo.GetAllTipoDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoDocumento> GetAllTipoDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoDocumentoRepo.GetAllTipoDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoDocumento> GetAllTipoDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoDocumentoRepo.GetAllTipoDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

