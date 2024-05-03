
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TermoUsoAppServices : ITermoUsoAppServices
    {
        private readonly ITermoUsoServices _TermoUsoServices;
                

        public TermoUsoAppServices(ITermoUsoServices TermoUsoServices         )
        {
            _TermoUsoServices = TermoUsoServices;
                  
        }

        public TermoUso InsertTermoUso(TermoUso objTermoUso)
        {
                    
            
            return _TermoUsoServices.InsertTermoUso(objTermoUso);
        }

        public bool UpdateTermoUso(TermoUso objTermoUso)
        {            
                   
            return _TermoUsoServices.UpdateTermoUso(objTermoUso);
        }

        public bool AtivarTermoUso(int TRU_Id)
        {
            return _TermoUsoServices.AtivarTermoUso(TRU_Id);
        }

        public bool DeletarTermoUso(int TRU_Id)
        {
            return _TermoUsoServices.DeletarTermoUso(TRU_Id);
        }

        public TermoUso GetTermoUsoById(int TRU_Id, bool join)
        {
            return _TermoUsoServices.GetTermoUsoById(TRU_Id, join);
        }

        public IEnumerable<TermoUso> GetAllTermoUso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoServices.GetAllTermoUso(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TermoUso> GetAllTermoUsoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoServices.GetAllTermoUsoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TermoUso> GetAllTermoUsoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoServices.GetAllTermoUsoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

