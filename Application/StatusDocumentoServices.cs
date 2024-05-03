using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class StatusDocumentoAppServices : IStatusDocumentoAppServices
    {
        private readonly IStatusDocumentoServices _StatusDocumentoServices;


        public StatusDocumentoAppServices(IStatusDocumentoServices StatusDocumentoServices)
        {
            _StatusDocumentoServices = StatusDocumentoServices;

        }

        public StatusDocumento InsertStatusDocumento(StatusDocumento objStatusDocumento)
        {


            return _StatusDocumentoServices.InsertStatusDocumento(objStatusDocumento);
        }

        public bool UpdateStatusDocumento(StatusDocumento objStatusDocumento)
        {

            return _StatusDocumentoServices.UpdateStatusDocumento(objStatusDocumento);
        }

        public bool AtivarStatusDocumento(int SDO_Id)
        {
            return _StatusDocumentoServices.AtivarStatusDocumento(SDO_Id);
        }

        public bool DeletarStatusDocumento(int SDO_Id)
        {
            return _StatusDocumentoServices.DeletarStatusDocumento(SDO_Id);
        }

        public StatusDocumento GetStatusDocumentoById(int SDO_Id, bool join)
        {
            return _StatusDocumentoServices.GetStatusDocumentoById(SDO_Id, join);
        }

        public IEnumerable<StatusDocumento> GetAllStatusDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusDocumentoServices.GetAllStatusDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusDocumento> GetAllStatusDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusDocumentoServices.GetAllStatusDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<StatusDocumento> GetAllStatusDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _StatusDocumentoServices.GetAllStatusDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

