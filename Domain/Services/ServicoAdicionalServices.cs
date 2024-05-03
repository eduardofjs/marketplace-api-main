
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class ServicoAdicionalServices : IServicoAdicionalServices
    {
        private readonly IServicoAdicionalRepository _ServicoAdicionalRepo;

        public ServicoAdicionalServices(IServicoAdicionalRepository ServicoAdicionalRepo)
        {
            _ServicoAdicionalRepo = ServicoAdicionalRepo;
        }

        public ServicoAdicional InsertServicoAdicional(ServicoAdicional objServicoAdicional)
        {
            return _ServicoAdicionalRepo.InsertServicoAdicional(objServicoAdicional);
        }

        public bool UpdateServicoAdicional(ServicoAdicional objServicoAdicional)
        {
            return _ServicoAdicionalRepo.UpdateServicoAdicional(objServicoAdicional);
        }

        public bool AtivarServicoAdicional(int SEA_Id)
        {
            return _ServicoAdicionalRepo.AtivarServicoAdicional(SEA_Id);
        }

        public bool DeletarServicoAdicional(int SEA_Id)
        {
            return _ServicoAdicionalRepo.DeletarServicoAdicional(SEA_Id);
        }

        public ServicoAdicional GetServicoAdicionalById(int SEA_Id, bool join)
        {
            return _ServicoAdicionalRepo.GetServicoAdicionalById(SEA_Id, join);
        }

        public IEnumerable<ServicoAdicional> GetAllServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoAdicionalRepo.GetAllServicoAdicional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoAdicional> GetAllServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoAdicionalRepo.GetAllServicoAdicionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoAdicional> GetAllServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoAdicionalRepo.GetAllServicoAdicionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

