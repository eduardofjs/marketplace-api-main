using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class StatusDocumentoServices : IStatusDocumentoServices
    {
        private readonly IStatusDocumentoRepository _StatusDocumentoRepo;

        public StatusDocumentoServices(IStatusDocumentoRepository StatusDocumentoRepo)
        {
            _StatusDocumentoRepo = StatusDocumentoRepo;
        }

        public StatusDocumento InsertStatusDocumento(StatusDocumento objStatusDocumento)
        {
            return _StatusDocumentoRepo.InsertStatusDocumento(objStatusDocumento);
        }

        public bool UpdateStatusDocumento(StatusDocumento objStatusDocumento)
        {
            return _StatusDocumentoRepo.UpdateStatusDocumento(objStatusDocumento);
        }

        public bool AtivarStatusDocumento(int SDO_Id)
        {
            return _StatusDocumentoRepo.AtivarStatusDocumento(SDO_Id);
        }

        public bool DeletarStatusDocumento(int SDO_Id)
        {
            return _StatusDocumentoRepo.DeletarStatusDocumento(SDO_Id);
        }

        public StatusDocumento GetStatusDocumentoById(int SDO_Id, bool join)
        {
            return _StatusDocumentoRepo.GetStatusDocumentoById(SDO_Id, join);
        }

        public IEnumerable<StatusDocumento> GetAllStatusDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusDocumentoRepo.GetAllStatusDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusDocumento> GetAllStatusDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusDocumentoRepo.GetAllStatusDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusDocumento> GetAllStatusDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusDocumentoRepo.GetAllStatusDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

