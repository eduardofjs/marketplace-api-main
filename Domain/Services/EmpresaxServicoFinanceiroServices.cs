using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class EmpresaxServicoFinanceiroServices : IEmpresaxServicoFinanceiroServices
    {
        private readonly IEmpresaxServicoFinanceiroRepository _EmpresaxServicoFinanceiroRepo;

        public EmpresaxServicoFinanceiroServices(IEmpresaxServicoFinanceiroRepository EmpresaxServicoFinanceiroRepo)
        {
            _EmpresaxServicoFinanceiroRepo = EmpresaxServicoFinanceiroRepo;
        }

        public EmpresaxServicoFinanceiro InsertEmpresaxServicoFinanceiro(EmpresaxServicoFinanceiro objEmpresaxServicoFinanceiro)
        {
            return _EmpresaxServicoFinanceiroRepo.InsertEmpresaxServicoFinanceiro(objEmpresaxServicoFinanceiro);
        }

        public bool UpdateEmpresaxServicoFinanceiro(EmpresaxServicoFinanceiro objEmpresaxServicoFinanceiro)
        {
            return _EmpresaxServicoFinanceiroRepo.UpdateEmpresaxServicoFinanceiro(objEmpresaxServicoFinanceiro);
        }

        public bool AtivarEmpresaxServicoFinanceiro(int ESF_Id)
        {
            return _EmpresaxServicoFinanceiroRepo.AtivarEmpresaxServicoFinanceiro(ESF_Id);
        }

        public bool DeletarEmpresaxServicoFinanceiro(int ESF_Id)
        {
            return _EmpresaxServicoFinanceiroRepo.DeletarEmpresaxServicoFinanceiro(ESF_Id);
        }

        public EmpresaxServicoFinanceiro GetEmpresaxServicoFinanceiroById(int ESF_Id, bool join)
        {
            return _EmpresaxServicoFinanceiroRepo.GetEmpresaxServicoFinanceiroById(ESF_Id, join);
        }

        public IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoFinanceiroRepo.GetAllEmpresaxServicoFinanceiro(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoFinanceiroRepo.GetAllEmpresaxServicoFinanceiroByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoFinanceiroRepo.GetAllEmpresaxServicoFinanceiroByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarEmpresaxServicoFinanceiroByEmpresa(int ESF_EmpresaId)
        {
            return _EmpresaxServicoFinanceiroRepo.DeletarEmpresaxServicoFinanceiroByEmpresa(ESF_EmpresaId);
        }
    }
}


