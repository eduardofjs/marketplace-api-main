using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class EmpresaxServicoAdicionalServices : IEmpresaxServicoAdicionalServices
    {
        private readonly IEmpresaxServicoAdicionalRepository _EmpresaxServicoAdicionalRepo;

        public EmpresaxServicoAdicionalServices(IEmpresaxServicoAdicionalRepository EmpresaxServicoAdicionalRepo)
        {
            _EmpresaxServicoAdicionalRepo = EmpresaxServicoAdicionalRepo;
        }

        public EmpresaxServicoAdicional InsertEmpresaxServicoAdicional(EmpresaxServicoAdicional objEmpresaxServicoAdicional)
        {
            return _EmpresaxServicoAdicionalRepo.InsertEmpresaxServicoAdicional(objEmpresaxServicoAdicional);
        }

        public bool UpdateEmpresaxServicoAdicional(EmpresaxServicoAdicional objEmpresaxServicoAdicional)
        {
            return _EmpresaxServicoAdicionalRepo.UpdateEmpresaxServicoAdicional(objEmpresaxServicoAdicional);
        }

        public bool AtivarEmpresaxServicoAdicional(int ESA_Id)
        {
            return _EmpresaxServicoAdicionalRepo.AtivarEmpresaxServicoAdicional(ESA_Id);
        }

        public bool DeletarEmpresaxServicoAdicional(int ESA_Id)
        {
            return _EmpresaxServicoAdicionalRepo.DeletarEmpresaxServicoAdicional(ESA_Id);
        }

        public EmpresaxServicoAdicional GetEmpresaxServicoAdicionalById(int ESA_Id, bool join)
        {
            return _EmpresaxServicoAdicionalRepo.GetEmpresaxServicoAdicionalById(ESA_Id, join);
        }

        public IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoAdicionalRepo.GetAllEmpresaxServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoAdicionalRepo.GetAllEmpresaxServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoAdicionalRepo.GetAllEmpresaxServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarEmpresaxServicoAdicionalByEmpresa(int ESA_EmpresaId)
        {
            return _EmpresaxServicoAdicionalRepo.DeletarEmpresaxServicoAdicionalByEmpresa(ESA_EmpresaId);
        }
    }
}

