using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class EmpresaxServicoAdicionalAppServices : IEmpresaxServicoAdicionalAppServices
    {
        private readonly IEmpresaxServicoAdicionalServices _EmpresaxServicoAdicionalServices;


        public EmpresaxServicoAdicionalAppServices(IEmpresaxServicoAdicionalServices EmpresaxServicoAdicionalServices)
        {
            _EmpresaxServicoAdicionalServices = EmpresaxServicoAdicionalServices;

        }

        public EmpresaxServicoAdicional InsertEmpresaxServicoAdicional(EmpresaxServicoAdicional objEmpresaxServicoAdicional)
        {


            return _EmpresaxServicoAdicionalServices.InsertEmpresaxServicoAdicional(objEmpresaxServicoAdicional);
        }

        public bool UpdateEmpresaxServicoAdicional(EmpresaxServicoAdicional objEmpresaxServicoAdicional)
        {

            return _EmpresaxServicoAdicionalServices.UpdateEmpresaxServicoAdicional(objEmpresaxServicoAdicional);
        }

        public bool AtivarEmpresaxServicoAdicional(int ESA_Id)
        {
            return _EmpresaxServicoAdicionalServices.AtivarEmpresaxServicoAdicional(ESA_Id);
        }

        public bool DeletarEmpresaxServicoAdicional(int ESA_Id)
        {
            return _EmpresaxServicoAdicionalServices.DeletarEmpresaxServicoAdicional(ESA_Id);
        }

        public EmpresaxServicoAdicional GetEmpresaxServicoAdicionalById(int ESA_Id, bool join)
        {
            return _EmpresaxServicoAdicionalServices.GetEmpresaxServicoAdicionalById(ESA_Id, join);
        }

        public IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoAdicionalServices.GetAllEmpresaxServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoAdicionalServices.GetAllEmpresaxServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxServicoAdicionalServices.GetAllEmpresaxServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarEmpresaxServicoAdicionalByEmpresa(int ESA_EmpresaId)
        {
            return _EmpresaxServicoAdicionalServices.DeletarEmpresaxServicoAdicionalByEmpresa(ESA_EmpresaId);
        }
    }
}
