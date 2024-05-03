
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class UnidadeServices : IUnidadeServices
    {
        private readonly IUnidadeRepository _UnidadeRepo;

        public UnidadeServices(IUnidadeRepository UnidadeRepo)
        {
            _UnidadeRepo = UnidadeRepo;
        }
		
        public Unidade InsertUnidade(Unidade objUnidade)
        {
            return _UnidadeRepo.InsertUnidade(objUnidade);
        }

        public bool UpdateUnidade(Unidade objUnidade)
        {
            return _UnidadeRepo.UpdateUnidade(objUnidade);
        }

        public bool AtivarUnidade(int UNI_Id)
        {
            return _UnidadeRepo.AtivarUnidade(UNI_Id);
        }

        public bool DeletarUnidade(int UNI_Id)
        {
            return _UnidadeRepo.DeletarUnidade(UNI_Id);
        }
        
        public Unidade GetUnidadeById(int UNI_Id, bool join)
        {
            return _UnidadeRepo.GetUnidadeById(UNI_Id, join);
        }

        public IEnumerable<Unidade> GetAllUnidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadeRepo.GetAllUnidade(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Unidade> GetAllUnidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadeRepo.GetAllUnidadeByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Unidade> GetAllUnidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadeRepo.GetAllUnidadeByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

