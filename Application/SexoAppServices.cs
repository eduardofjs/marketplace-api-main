
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class SexoAppServices : ISexoAppServices
    {
        private readonly ISexoServices _SexoServices;
              

        public SexoAppServices(ISexoServices SexoServices       )
        {
            _SexoServices = SexoServices;
                
        }

        public Sexo InsertSexo(Sexo objSexo)
        {
                  
            
            return _SexoServices.InsertSexo(objSexo);
        }

        public bool UpdateSexo(Sexo objSexo)
        {            
                 
            return _SexoServices.UpdateSexo(objSexo);
        }

        public bool AtivarSexo(int SEX_Id)
        {
            return _SexoServices.AtivarSexo(SEX_Id);
        }

        public bool DeletarSexo(int SEX_Id)
        {
            return _SexoServices.DeletarSexo(SEX_Id);
        }

        public Sexo GetSexoById(int SEX_Id, bool join)
        {
            return _SexoServices.GetSexoById(SEX_Id, join);
        }

        public IEnumerable<Sexo> GetAllSexo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SexoServices.GetAllSexo(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Sexo> GetAllSexoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SexoServices.GetAllSexoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Sexo> GetAllSexoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SexoServices.GetAllSexoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

