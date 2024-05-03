using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class EmpresaxServicoFinanceiroAppServices : IEmpresaxServicoFinanceiroAppServices
    {
        private readonly IEmpresaxServicoFinanceiroServices _EmpresaxServicoFinanceiroServices;


        public EmpresaxServicoFinanceiroAppServices(IEmpresaxServicoFinanceiroServices EmpresaxServicoFinanceiroServices)
        {
            _EmpresaxServicoFinanceiroServices = EmpresaxServicoFinanceiroServices;

        }

        public EmpresaxServicoFinanceiro InsertEmpresaxServicoFinanceiro(EmpresaxServicoFinanceiro objEmpresaxServicoFinanceiro)
        {


            return _EmpresaxServicoFinanceiroServices.InsertEmpresaxServicoFinanceiro(objEmpresaxServicoFinanceiro);
        }

        public bool UpdateEmpresaxServicoFinanceiro(EmpresaxServicoFinanceiro objEmpresaxServicoFinanceiro)
        {

            return _EmpresaxServicoFinanceiroServices.UpdateEmpresaxServicoFinanceiro(objEmpresaxServicoFinanceiro);
        }

        public bool AtivarEmpresaxServicoFinanceiro(int ESF_Id)
        {
            return _EmpresaxServicoFinanceiroServices.AtivarEmpresaxServicoFinanceiro(ESF_Id);
        }

        public bool DeletarEmpresaxServicoFinanceiro(int ESF_Id)
        {
            return _EmpresaxServicoFinanceiroServices.DeletarEmpresaxServicoFinanceiro(ESF_Id);
        }

        public EmpresaxServicoFinanceiro GetEmpresaxServicoFinanceiroById(int ESF_Id, bool join)
        {
            return _EmpresaxServicoFinanceiroServices.GetEmpresaxServicoFinanceiroById(ESF_Id, join);
        }

        public IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoFinanceiroServices.GetAllEmpresaxServicoFinanceiro(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoFinanceiroServices.GetAllEmpresaxServicoFinanceiroByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoFinanceiroServices.GetAllEmpresaxServicoFinanceiroByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarEmpresaxServicoFinanceiroByEmpresa(int ESF_EmpresaId)
        {
            return _EmpresaxServicoFinanceiroServices.DeletarEmpresaxServicoFinanceiroByEmpresa(ESF_EmpresaId);
        }
    }
}
