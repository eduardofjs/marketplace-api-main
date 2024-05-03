using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ServicoFinanceiroAppServices : IServicoFinanceiroAppServices
    {
        private readonly IServicoFinanceiroServices _ServicoFinanceiroServices;


        public ServicoFinanceiroAppServices(IServicoFinanceiroServices ServicoFinanceiroServices)
        {
            _ServicoFinanceiroServices = ServicoFinanceiroServices;

        }

        public ServicoFinanceiro InsertServicoFinanceiro(ServicoFinanceiro objServicoFinanceiro)
        {


            return _ServicoFinanceiroServices.InsertServicoFinanceiro(objServicoFinanceiro);
        }

        public bool UpdateServicoFinanceiro(ServicoFinanceiro objServicoFinanceiro)
        {

            return _ServicoFinanceiroServices.UpdateServicoFinanceiro(objServicoFinanceiro);
        }

        public bool AtivarServicoFinanceiro(int SEF_Id)
        {
            return _ServicoFinanceiroServices.AtivarServicoFinanceiro(SEF_Id);
        }

        public bool DeletarServicoFinanceiro(int SEF_Id)
        {
            return _ServicoFinanceiroServices.DeletarServicoFinanceiro(SEF_Id);
        }

        public ServicoFinanceiro GetServicoFinanceiroById(int SEF_Id, bool join)
        {
            return _ServicoFinanceiroServices.GetServicoFinanceiroById(SEF_Id, join);
        }

        public IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoFinanceiroServices.GetAllServicoFinanceiro(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoFinanceiroServices.GetAllServicoFinanceiroByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoFinanceiroServices.GetAllServicoFinanceiroByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}
