
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class PoliticaPrivacidadeServices : IPoliticaPrivacidadeServices
    {
        private readonly IPoliticaPrivacidadeRepository _PoliticaPrivacidadeRepo;

        public PoliticaPrivacidadeServices(IPoliticaPrivacidadeRepository PoliticaPrivacidadeRepo)
        {
            _PoliticaPrivacidadeRepo = PoliticaPrivacidadeRepo;
        }
		
        public PoliticaPrivacidade InsertPoliticaPrivacidade(PoliticaPrivacidade objPoliticaPrivacidade)
        {
            return _PoliticaPrivacidadeRepo.InsertPoliticaPrivacidade(objPoliticaPrivacidade);
        }

        public bool UpdatePoliticaPrivacidade(PoliticaPrivacidade objPoliticaPrivacidade)
        {
            return _PoliticaPrivacidadeRepo.UpdatePoliticaPrivacidade(objPoliticaPrivacidade);
        }

        public bool AtivarPoliticaPrivacidade(int PVD_Id)
        {
            return _PoliticaPrivacidadeRepo.AtivarPoliticaPrivacidade(PVD_Id);
        }

        public bool DeletarPoliticaPrivacidade(int PVD_Id)
        {
            return _PoliticaPrivacidadeRepo.DeletarPoliticaPrivacidade(PVD_Id);
        }
        
        public PoliticaPrivacidade GetPoliticaPrivacidadeById(int PVD_Id, bool join)
        {
            return _PoliticaPrivacidadeRepo.GetPoliticaPrivacidadeById(PVD_Id, join);
        }

        public IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadeRepo.GetAllPoliticaPrivacidade(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadeRepo.GetAllPoliticaPrivacidadeByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadeRepo.GetAllPoliticaPrivacidadeByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

