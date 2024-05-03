
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class EmpresaServices : IEmpresaServices
    {
        private readonly IEmpresaRepository _EmpresaRepo;

        public EmpresaServices(IEmpresaRepository EmpresaRepo)
        {
            _EmpresaRepo = EmpresaRepo;
        }
		
        public Empresa InsertEmpresa(Empresa objEmpresa)
        {
            return _EmpresaRepo.InsertEmpresa(objEmpresa);
        }

        public bool UpdateEmpresa(Empresa objEmpresa)
        {
            return _EmpresaRepo.UpdateEmpresa(objEmpresa);
        }

        public bool AtivarEmpresa(int EMP_Id)
        {
            return _EmpresaRepo.AtivarEmpresa(EMP_Id);
        }

        public bool DeletarEmpresa(int EMP_Id)
        {
            return _EmpresaRepo.DeletarEmpresa(EMP_Id);
        }
        
        public Empresa GetEmpresaById(int EMP_Id, bool join)
        {
            return _EmpresaRepo.GetEmpresaById(EMP_Id, join);
        }

        public IEnumerable<Empresa> GetAllEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaRepo.GetAllEmpresa(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Empresa> GetAllEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaRepo.GetAllEmpresaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Empresa> GetAllEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EmpresaRepo.GetAllEmpresaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public bool AprovarEmpresa(int EMP_Id)
        {
            return _EmpresaRepo.AprovarEmpresa(EMP_Id);
        }

        public bool ReprovarEmpresa(int EMP_Id)
        {
            return _EmpresaRepo.ReprovarEmpresa(EMP_Id);
        }
    }
}

