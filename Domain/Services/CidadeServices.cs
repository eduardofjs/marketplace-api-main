
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class CidadeServices : ICidadeServices
    {
        private readonly ICidadeRepository _CidadeRepo;

        public CidadeServices(ICidadeRepository CidadeRepo)
        {
            _CidadeRepo = CidadeRepo;
        }
		
        public Cidade InsertCidade(Cidade objCidade)
        {
            return _CidadeRepo.InsertCidade(objCidade);
        }

        public bool UpdateCidade(Cidade objCidade)
        {
            return _CidadeRepo.UpdateCidade(objCidade);
        }

        public bool AtivarCidade(int CDD_Id)
        {
            return _CidadeRepo.AtivarCidade(CDD_Id);
        }

        public bool DeletarCidade(int CDD_Id)
        {
            return _CidadeRepo.DeletarCidade(CDD_Id);
        }
        
        public Cidade GetCidadeById(int CDD_Id, bool join)
        {
            return _CidadeRepo.GetCidadeById(CDD_Id, join);
        }

        public IEnumerable<Cidade> GetAllCidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CidadeRepo.GetAllCidade(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Cidade> GetAllCidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CidadeRepo.GetAllCidadeByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Cidade> GetAllCidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CidadeRepo.GetAllCidadeByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

