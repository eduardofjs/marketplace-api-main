using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class ModoCultivoModoProducaoServices : IModoCultivoModoProducaoServices
    {
        private readonly IModoCultivoModoProducaoRepository _ModoCultivoModoProducaoRepo;

        public ModoCultivoModoProducaoServices(IModoCultivoModoProducaoRepository ModoCultivoModoProducaoRepo)
        {
            _ModoCultivoModoProducaoRepo = ModoCultivoModoProducaoRepo;
        }

        public ModoCultivoModoProducao InsertModoCultivoModoProducao(ModoCultivoModoProducao objModoCultivoModoProducao)
        {
            return _ModoCultivoModoProducaoRepo.InsertModoCultivoModoProducao(objModoCultivoModoProducao);
        }

        public bool UpdateModoCultivoModoProducao(ModoCultivoModoProducao objModoCultivoModoProducao)
        {
            return _ModoCultivoModoProducaoRepo.UpdateModoCultivoModoProducao(objModoCultivoModoProducao);
        }

        public bool AtivarModoCultivoModoProducao(int MCM_Id)
        {
            return _ModoCultivoModoProducaoRepo.AtivarModoCultivoModoProducao(MCM_Id);
        }

        public bool DeletarModoCultivoModoProducao(int MCM_Id)
        {
            return _ModoCultivoModoProducaoRepo.DeletarModoCultivoModoProducao(MCM_Id);
        }

        public ModoCultivoModoProducao GetModoCultivoModoProducaoById(int MCM_Id, bool join)
        {
            return _ModoCultivoModoProducaoRepo.GetModoCultivoModoProducaoById(MCM_Id, join);
        }

        public IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoModoProducaoRepo.GetAllModoCultivoModoProducao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoModoProducaoRepo.GetAllModoCultivoModoProducaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoModoProducaoRepo.GetAllModoCultivoModoProducaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

