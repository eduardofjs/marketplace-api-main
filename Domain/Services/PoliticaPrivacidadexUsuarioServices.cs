
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class PoliticaPrivacidadexUsuarioServices : IPoliticaPrivacidadexUsuarioServices
    {
        private readonly IPoliticaPrivacidadexUsuarioRepository _PoliticaPrivacidadexUsuarioRepo;

        public PoliticaPrivacidadexUsuarioServices(IPoliticaPrivacidadexUsuarioRepository PoliticaPrivacidadexUsuarioRepo)
        {
            _PoliticaPrivacidadexUsuarioRepo = PoliticaPrivacidadexUsuarioRepo;
        }
		
        public PoliticaPrivacidadexUsuario InsertPoliticaPrivacidadexUsuario(PoliticaPrivacidadexUsuario objPoliticaPrivacidadexUsuario)
        {
            return _PoliticaPrivacidadexUsuarioRepo.InsertPoliticaPrivacidadexUsuario(objPoliticaPrivacidadexUsuario);
        }

        public bool UpdatePoliticaPrivacidadexUsuario(PoliticaPrivacidadexUsuario objPoliticaPrivacidadexUsuario)
        {
            return _PoliticaPrivacidadexUsuarioRepo.UpdatePoliticaPrivacidadexUsuario(objPoliticaPrivacidadexUsuario);
        }

        public bool AtivarPoliticaPrivacidadexUsuario(int PVU_Id)
        {
            return _PoliticaPrivacidadexUsuarioRepo.AtivarPoliticaPrivacidadexUsuario(PVU_Id);
        }

        public bool DeletarPoliticaPrivacidadexUsuario(int PVU_Id)
        {
            return _PoliticaPrivacidadexUsuarioRepo.DeletarPoliticaPrivacidadexUsuario(PVU_Id);
        }
        
        public PoliticaPrivacidadexUsuario GetPoliticaPrivacidadexUsuarioById(int PVU_Id, bool join)
        {
            return _PoliticaPrivacidadexUsuarioRepo.GetPoliticaPrivacidadexUsuarioById(PVU_Id, join);
        }

        public IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadexUsuarioRepo.GetAllPoliticaPrivacidadexUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadexUsuarioRepo.GetAllPoliticaPrivacidadexUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadexUsuarioRepo.GetAllPoliticaPrivacidadexUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

