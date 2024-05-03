using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class EmpresaxLogisticaAppServices : IEmpresaxLogisticaAppServices
    {
        private readonly IEmpresaxLogisticaServices _EmpresaxLogisticaServices;


        public EmpresaxLogisticaAppServices(IEmpresaxLogisticaServices EmpresaxLogisticaServices)
        {
            _EmpresaxLogisticaServices = EmpresaxLogisticaServices;

        }

        public EmpresaxLogistica InsertEmpresaxLogistica(EmpresaxLogistica objEmpresaxLogistica)
        {


            return _EmpresaxLogisticaServices.InsertEmpresaxLogistica(objEmpresaxLogistica);
        }

        public bool UpdateEmpresaxLogistica(EmpresaxLogistica objEmpresaxLogistica)
        {

            return _EmpresaxLogisticaServices.UpdateEmpresaxLogistica(objEmpresaxLogistica);
        }

        public bool AtivarEmpresaxLogistica(int EXL_Id)
        {
            return _EmpresaxLogisticaServices.AtivarEmpresaxLogistica(EXL_Id);
        }

        public bool DeletarEmpresaxLogistica(int EXL_Id)
        {
            return _EmpresaxLogisticaServices.DeletarEmpresaxLogistica(EXL_Id);
        }

        public EmpresaxLogistica GetEmpresaxLogisticaById(int EXL_Id, bool join)
        {
            return _EmpresaxLogisticaServices.GetEmpresaxLogisticaById(EXL_Id, join);
        }

        public IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogistica(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxLogisticaServices.GetAllEmpresaxLogistica(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogisticaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxLogisticaServices.GetAllEmpresaxLogisticaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogisticaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxLogisticaServices.GetAllEmpresaxLogisticaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarEmpresaxLogisticaByEmpresa(int EXL_EmpresaId)
        {
            return _EmpresaxLogisticaServices.DeletarEmpresaxLogisticaByEmpresa(EXL_EmpresaId);
        }
    }
}
