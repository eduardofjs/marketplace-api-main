using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class ModoCultivoSistemaProdutivoServices : IModoCultivoSistemaProdutivoServices
    {
        private readonly IModoCultivoSistemaProdutivoRepository _ModoCultivoSistemaProdutivoRepo;

        public ModoCultivoSistemaProdutivoServices(IModoCultivoSistemaProdutivoRepository ModoCultivoSistemaProdutivoRepo)
        {
            _ModoCultivoSistemaProdutivoRepo = ModoCultivoSistemaProdutivoRepo;
        }

        public ModoCultivoSistemaProdutivo InsertModoCultivoSistemaProdutivo(ModoCultivoSistemaProdutivo objModoCultivoSistemaProdutivo)
        {
            return _ModoCultivoSistemaProdutivoRepo.InsertModoCultivoSistemaProdutivo(objModoCultivoSistemaProdutivo);
        }

        public bool UpdateModoCultivoSistemaProdutivo(ModoCultivoSistemaProdutivo objModoCultivoSistemaProdutivo)
        {
            return _ModoCultivoSistemaProdutivoRepo.UpdateModoCultivoSistemaProdutivo(objModoCultivoSistemaProdutivo);
        }

        public bool AtivarModoCultivoSistemaProdutivo(int MCS_Id)
        {
            return _ModoCultivoSistemaProdutivoRepo.AtivarModoCultivoSistemaProdutivo(MCS_Id);
        }

        public bool DeletarModoCultivoSistemaProdutivo(int MCS_Id)
        {
            return _ModoCultivoSistemaProdutivoRepo.DeletarModoCultivoSistemaProdutivo(MCS_Id);
        }

        public ModoCultivoSistemaProdutivo GetModoCultivoSistemaProdutivoById(int MCS_Id, bool join)
        {
            return _ModoCultivoSistemaProdutivoRepo.GetModoCultivoSistemaProdutivoById(MCS_Id, join);
        }

        public IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoSistemaProdutivoRepo.GetAllModoCultivoSistemaProdutivo(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoSistemaProdutivoRepo.GetAllModoCultivoSistemaProdutivoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoSistemaProdutivoRepo.GetAllModoCultivoSistemaProdutivoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

