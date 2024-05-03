using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class EmpresaxDocumentoServices : IEmpresaxDocumentoServices
    {
        private readonly IEmpresaxDocumentoRepository _EmpresaxDocumentoRepo;

        public EmpresaxDocumentoServices(IEmpresaxDocumentoRepository EmpresaxDocumentoRepo)
        {
            _EmpresaxDocumentoRepo = EmpresaxDocumentoRepo;
        }

        public EmpresaxDocumento InsertEmpresaxDocumento(EmpresaxDocumento objEmpresaxDocumento)
        {
            return _EmpresaxDocumentoRepo.InsertEmpresaxDocumento(objEmpresaxDocumento);
        }

        public bool UpdateEmpresaxDocumento(EmpresaxDocumento objEmpresaxDocumento)
        {
            return _EmpresaxDocumentoRepo.UpdateEmpresaxDocumento(objEmpresaxDocumento);
        }

        public bool AtivarEmpresaxDocumento(int EXD_Id)
        {
            return _EmpresaxDocumentoRepo.AtivarEmpresaxDocumento(EXD_Id);
        }

        public bool DeletarEmpresaxDocumento(int EXD_Id)
        {
            return _EmpresaxDocumentoRepo.DeletarEmpresaxDocumento(EXD_Id);
        }

        public EmpresaxDocumento GetEmpresaxDocumentoById(int EXD_Id, bool join)
        {
            return _EmpresaxDocumentoRepo.GetEmpresaxDocumentoById(EXD_Id, join);
        }

        public IEnumerable<EmpresaxDocumento> GetAllEmpresaxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxDocumentoRepo.GetAllEmpresaxDocumento(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxDocumento> GetAllEmpresaxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxDocumentoRepo.GetAllEmpresaxDocumentoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxDocumento> GetAllEmpresaxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxDocumentoRepo.GetAllEmpresaxDocumentoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarEmpresaxDocumentoByEmpresa(int EXD_EmpresaId)
        {
            return _EmpresaxDocumentoRepo.DeletarEmpresaxDocumentoByEmpresa(EXD_EmpresaId);
        }
    }
}

