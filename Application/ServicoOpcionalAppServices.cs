
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ServicoOpcionalAppServices : IServicoOpcionalAppServices
    {
        private readonly IServicoOpcionalServices _ServicoOpcionalServices;


        public ServicoOpcionalAppServices(IServicoOpcionalServices ServicoOpcionalServices)
        {
            _ServicoOpcionalServices = ServicoOpcionalServices;

        }

        public ServicoOpcional InsertServicoOpcional(ServicoOpcional objServicoOpcional)
        {


            return _ServicoOpcionalServices.InsertServicoOpcional(objServicoOpcional);
        }

        public bool UpdateServicoOpcional(ServicoOpcional objServicoOpcional)
        {

            return _ServicoOpcionalServices.UpdateServicoOpcional(objServicoOpcional);
        }

        public bool AtivarServicoOpcional(int SEO_Id)
        {
            return _ServicoOpcionalServices.AtivarServicoOpcional(SEO_Id);
        }

        public bool DeletarServicoOpcional(int SEO_Id)
        {
            return _ServicoOpcionalServices.DeletarServicoOpcional(SEO_Id);
        }

        public ServicoOpcional GetServicoOpcionalById(int SEO_Id, bool join)
        {
            return _ServicoOpcionalServices.GetServicoOpcionalById(SEO_Id, join);
        }

        public IEnumerable<ServicoOpcional> GetAllServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoOpcionalServices.GetAllServicoOpcional(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoOpcional> GetAllServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoOpcionalServices.GetAllServicoOpcionalByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<ServicoOpcional> GetAllServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _ServicoOpcionalServices.GetAllServicoOpcionalByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

