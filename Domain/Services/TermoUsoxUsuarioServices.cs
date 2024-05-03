
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TermoUsoxUsuarioServices : ITermoUsoxUsuarioServices
    {
        private readonly ITermoUsoxUsuarioRepository _TermoUsoxUsuarioRepo;

        public TermoUsoxUsuarioServices(ITermoUsoxUsuarioRepository TermoUsoxUsuarioRepo)
        {
            _TermoUsoxUsuarioRepo = TermoUsoxUsuarioRepo;
        }
		
        public TermoUsoxUsuario InsertTermoUsoxUsuario(TermoUsoxUsuario objTermoUsoxUsuario)
        {
            return _TermoUsoxUsuarioRepo.InsertTermoUsoxUsuario(objTermoUsoxUsuario);
        }

        public bool UpdateTermoUsoxUsuario(TermoUsoxUsuario objTermoUsoxUsuario)
        {
            return _TermoUsoxUsuarioRepo.UpdateTermoUsoxUsuario(objTermoUsoxUsuario);
        }

        public bool AtivarTermoUsoxUsuario(int TXU_Id)
        {
            return _TermoUsoxUsuarioRepo.AtivarTermoUsoxUsuario(TXU_Id);
        }

        public bool DeletarTermoUsoxUsuario(int TXU_Id)
        {
            return _TermoUsoxUsuarioRepo.DeletarTermoUsoxUsuario(TXU_Id);
        }
        
        public TermoUsoxUsuario GetTermoUsoxUsuarioById(int TXU_Id, bool join)
        {
            return _TermoUsoxUsuarioRepo.GetTermoUsoxUsuarioById(TXU_Id, join);
        }

        public IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoxUsuarioRepo.GetAllTermoUsoxUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoxUsuarioRepo.GetAllTermoUsoxUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoxUsuarioRepo.GetAllTermoUsoxUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

