using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class EmpresaxLogisticaServices : IEmpresaxLogisticaServices
    {
        private readonly IEmpresaxLogisticaRepository _EmpresaxLogisticaRepo;

        public EmpresaxLogisticaServices(IEmpresaxLogisticaRepository EmpresaxLogisticaRepo)
        {
            _EmpresaxLogisticaRepo = EmpresaxLogisticaRepo;
        }

        public EmpresaxLogistica InsertEmpresaxLogistica(EmpresaxLogistica objEmpresaxLogistica)
        {
            return _EmpresaxLogisticaRepo.InsertEmpresaxLogistica(objEmpresaxLogistica);
        }

        public bool UpdateEmpresaxLogistica(EmpresaxLogistica objEmpresaxLogistica)
        {
            return _EmpresaxLogisticaRepo.UpdateEmpresaxLogistica(objEmpresaxLogistica);
        }

        public bool AtivarEmpresaxLogistica(int EXL_Id)
        {
            return _EmpresaxLogisticaRepo.AtivarEmpresaxLogistica(EXL_Id);
        }

        public bool DeletarEmpresaxLogistica(int EXL_Id)
        {
            return _EmpresaxLogisticaRepo.DeletarEmpresaxLogistica(EXL_Id);
        }

        public EmpresaxLogistica GetEmpresaxLogisticaById(int EXL_Id, bool join)
        {
            return _EmpresaxLogisticaRepo.GetEmpresaxLogisticaById(EXL_Id, join);
        }

        public IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogistica(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxLogisticaRepo.GetAllEmpresaxLogistica(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogisticaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxLogisticaRepo.GetAllEmpresaxLogisticaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogisticaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaxLogisticaRepo.GetAllEmpresaxLogisticaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool DeletarEmpresaxLogisticaByEmpresa(int EXL_EmpresaId)
        {
            return _EmpresaxLogisticaRepo.DeletarEmpresaxLogisticaByEmpresa(EXL_EmpresaId);
        }
    }
}


