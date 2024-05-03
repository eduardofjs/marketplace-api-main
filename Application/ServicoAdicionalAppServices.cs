
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ServicoAdicionalAppServices : IServicoAdicionalAppServices
    {
        private readonly IServicoAdicionalServices _ServicoAdicionalServices;


        public ServicoAdicionalAppServices(IServicoAdicionalServices ServicoAdicionalServices)
        {
            _ServicoAdicionalServices = ServicoAdicionalServices;

        }

        public ServicoAdicional InsertServicoAdicional(ServicoAdicional objServicoAdicional)
        {


            return _ServicoAdicionalServices.InsertServicoAdicional(objServicoAdicional);
        }

        public bool UpdateServicoAdicional(ServicoAdicional objServicoAdicional)
        {

            return _ServicoAdicionalServices.UpdateServicoAdicional(objServicoAdicional);
        }

        public bool AtivarServicoAdicional(int SEA_Id)
        {
            return _ServicoAdicionalServices.AtivarServicoAdicional(SEA_Id);
        }

        public bool DeletarServicoAdicional(int SEA_Id)
        {
            return _ServicoAdicionalServices.DeletarServicoAdicional(SEA_Id);
        }

        public ServicoAdicional GetServicoAdicionalById(int SEA_Id, bool join)
        {
            return _ServicoAdicionalServices.GetServicoAdicionalById(SEA_Id, join);
        }

        public IEnumerable<ServicoAdicional> GetAllServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoAdicionalServices.GetAllServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoAdicional> GetAllServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoAdicionalServices.GetAllServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoAdicional> GetAllServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoAdicionalServices.GetAllServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

