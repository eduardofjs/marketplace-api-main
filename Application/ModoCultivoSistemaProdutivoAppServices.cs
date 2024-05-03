
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ModoCultivoSistemaProdutivoAppServices : IModoCultivoSistemaProdutivoAppServices
    {
        private readonly IModoCultivoSistemaProdutivoServices _ModoCultivoSistemaProdutivoServices;


        public ModoCultivoSistemaProdutivoAppServices(IModoCultivoSistemaProdutivoServices ModoCultivoSistemaProdutivoServices)
        {
            _ModoCultivoSistemaProdutivoServices = ModoCultivoSistemaProdutivoServices;

        }

        public ModoCultivoSistemaProdutivo InsertModoCultivoSistemaProdutivo(ModoCultivoSistemaProdutivo objModoCultivoSistemaProdutivo)
        {


            return _ModoCultivoSistemaProdutivoServices.InsertModoCultivoSistemaProdutivo(objModoCultivoSistemaProdutivo);
        }

        public bool UpdateModoCultivoSistemaProdutivo(ModoCultivoSistemaProdutivo objModoCultivoSistemaProdutivo)
        {

            return _ModoCultivoSistemaProdutivoServices.UpdateModoCultivoSistemaProdutivo(objModoCultivoSistemaProdutivo);
        }

        public bool AtivarModoCultivoSistemaProdutivo(int MCS_Id)
        {
            return _ModoCultivoSistemaProdutivoServices.AtivarModoCultivoSistemaProdutivo(MCS_Id);
        }

        public bool DeletarModoCultivoSistemaProdutivo(int MCS_Id)
        {
            return _ModoCultivoSistemaProdutivoServices.DeletarModoCultivoSistemaProdutivo(MCS_Id);
        }

        public ModoCultivoSistemaProdutivo GetModoCultivoSistemaProdutivoById(int MCS_Id, bool join)
        {
            return _ModoCultivoSistemaProdutivoServices.GetModoCultivoSistemaProdutivoById(MCS_Id, join);
        }

        public IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoSistemaProdutivoServices.GetAllModoCultivoSistemaProdutivo(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoSistemaProdutivoServices.GetAllModoCultivoSistemaProdutivoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ModoCultivoSistemaProdutivoServices.GetAllModoCultivoSistemaProdutivoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}


