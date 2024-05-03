
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class ServicoOpcionalServices : IServicoOpcionalServices
    {
        private readonly IServicoOpcionalRepository _ServicoOpcionalRepo;

        public ServicoOpcionalServices(IServicoOpcionalRepository ServicoOpcionalRepo)
        {
            _ServicoOpcionalRepo = ServicoOpcionalRepo;
        }

        public ServicoOpcional InsertServicoOpcional(ServicoOpcional objServicoOpcional)
        {
            return _ServicoOpcionalRepo.InsertServicoOpcional(objServicoOpcional);
        }

        public bool UpdateServicoOpcional(ServicoOpcional objServicoOpcional)
        {
            return _ServicoOpcionalRepo.UpdateServicoOpcional(objServicoOpcional);
        }

        public bool AtivarServicoOpcional(int SEO_Id)
        {
            return _ServicoOpcionalRepo.AtivarServicoOpcional(SEO_Id);
        }

        public bool DeletarServicoOpcional(int SEO_Id)
        {
            return _ServicoOpcionalRepo.DeletarServicoOpcional(SEO_Id);
        }

        public ServicoOpcional GetServicoOpcionalById(int SEO_Id, bool join)
        {
            return _ServicoOpcionalRepo.GetServicoOpcionalById(SEO_Id, join);
        }

        public IEnumerable<ServicoOpcional> GetAllServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoOpcionalRepo.GetAllServicoOpcional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoOpcional> GetAllServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoOpcionalRepo.GetAllServicoOpcionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoOpcional> GetAllServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoOpcionalRepo.GetAllServicoOpcionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

