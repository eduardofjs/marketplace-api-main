
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ModoCultivoModoProducaoAppServices : IModoCultivoModoProducaoAppServices
    {
        private readonly IModoCultivoModoProducaoServices _ModoCultivoModoProducaoServices;


        public ModoCultivoModoProducaoAppServices(IModoCultivoModoProducaoServices ModoCultivoModoProducaoServices)
        {
            _ModoCultivoModoProducaoServices = ModoCultivoModoProducaoServices;

        }

        public ModoCultivoModoProducao InsertModoCultivoModoProducao(ModoCultivoModoProducao objModoCultivoModoProducao)
        {


            return _ModoCultivoModoProducaoServices.InsertModoCultivoModoProducao(objModoCultivoModoProducao);
        }

        public bool UpdateModoCultivoModoProducao(ModoCultivoModoProducao objModoCultivoModoProducao)
        {

            return _ModoCultivoModoProducaoServices.UpdateModoCultivoModoProducao(objModoCultivoModoProducao);
        }

        public bool AtivarModoCultivoModoProducao(int MCM_Id)
        {
            return _ModoCultivoModoProducaoServices.AtivarModoCultivoModoProducao(MCM_Id);
        }

        public bool DeletarModoCultivoModoProducao(int MCM_Id)
        {
            return _ModoCultivoModoProducaoServices.DeletarModoCultivoModoProducao(MCM_Id);
        }

        public ModoCultivoModoProducao GetModoCultivoModoProducaoById(int MCM_Id, bool join)
        {
            return _ModoCultivoModoProducaoServices.GetModoCultivoModoProducaoById(MCM_Id, join);
        }

        public IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoModoProducaoServices.GetAllModoCultivoModoProducao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoModoProducaoServices.GetAllModoCultivoModoProducaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoModoProducaoServices.GetAllModoCultivoModoProducaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}


