
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class PoliticaPrivacidadeAppServices : IPoliticaPrivacidadeAppServices
    {
        private readonly IPoliticaPrivacidadeServices _PoliticaPrivacidadeServices;
                

        public PoliticaPrivacidadeAppServices(IPoliticaPrivacidadeServices PoliticaPrivacidadeServices         )
        {
            _PoliticaPrivacidadeServices = PoliticaPrivacidadeServices;
                  
        }

        public PoliticaPrivacidade InsertPoliticaPrivacidade(PoliticaPrivacidade objPoliticaPrivacidade)
        {
                    
            
            return _PoliticaPrivacidadeServices.InsertPoliticaPrivacidade(objPoliticaPrivacidade);
        }

        public bool UpdatePoliticaPrivacidade(PoliticaPrivacidade objPoliticaPrivacidade)
        {            
                   
            return _PoliticaPrivacidadeServices.UpdatePoliticaPrivacidade(objPoliticaPrivacidade);
        }

        public bool AtivarPoliticaPrivacidade(int PVD_Id)
        {
            return _PoliticaPrivacidadeServices.AtivarPoliticaPrivacidade(PVD_Id);
        }

        public bool DeletarPoliticaPrivacidade(int PVD_Id)
        {
            return _PoliticaPrivacidadeServices.DeletarPoliticaPrivacidade(PVD_Id);
        }

        public PoliticaPrivacidade GetPoliticaPrivacidadeById(int PVD_Id, bool join)
        {
            return _PoliticaPrivacidadeServices.GetPoliticaPrivacidadeById(PVD_Id, join);
        }

        public IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadeServices.GetAllPoliticaPrivacidade(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadeServices.GetAllPoliticaPrivacidadeByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadeServices.GetAllPoliticaPrivacidadeByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

