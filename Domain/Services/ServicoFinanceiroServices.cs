using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class ServicoFinanceiroServices : IServicoFinanceiroServices
    {
        private readonly IServicoFinanceiroRepository _ServicoFinanceiroRepo;

        public ServicoFinanceiroServices(IServicoFinanceiroRepository ServicoFinanceiroRepo)
        {
            _ServicoFinanceiroRepo = ServicoFinanceiroRepo;
        }

        public ServicoFinanceiro InsertServicoFinanceiro(ServicoFinanceiro objServicoFinanceiro)
        {
            return _ServicoFinanceiroRepo.InsertServicoFinanceiro(objServicoFinanceiro);
        }

        public bool UpdateServicoFinanceiro(ServicoFinanceiro objServicoFinanceiro)
        {
            return _ServicoFinanceiroRepo.UpdateServicoFinanceiro(objServicoFinanceiro);
        }

        public bool AtivarServicoFinanceiro(int SEF_Id)
        {
            return _ServicoFinanceiroRepo.AtivarServicoFinanceiro(SEF_Id);
        }

        public bool DeletarServicoFinanceiro(int SEF_Id)
        {
            return _ServicoFinanceiroRepo.DeletarServicoFinanceiro(SEF_Id);
        }

        public ServicoFinanceiro GetServicoFinanceiroById(int SEF_Id, bool join)
        {
            return _ServicoFinanceiroRepo.GetServicoFinanceiroById(SEF_Id, join);
        }

        public IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoFinanceiroRepo.GetAllServicoFinanceiro(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoFinanceiroRepo.GetAllServicoFinanceiroByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoFinanceiroRepo.GetAllServicoFinanceiroByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}


