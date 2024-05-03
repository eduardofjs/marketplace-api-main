
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class BancoServices : IBancoServices
    {
        private readonly IBancoRepository _BancoRepo;

        public BancoServices(IBancoRepository BancoRepo)
        {
            _BancoRepo = BancoRepo;
        }
		
        public Banco InsertBanco(Banco objBanco)
        {
            return _BancoRepo.InsertBanco(objBanco);
        }

        public bool UpdateBanco(Banco objBanco)
        {
            return _BancoRepo.UpdateBanco(objBanco);
        }

        public bool AtivarBanco(int BAN_Id)
        {
            return _BancoRepo.AtivarBanco(BAN_Id);
        }

        public bool DeletarBanco(int BAN_Id)
        {
            return _BancoRepo.DeletarBanco(BAN_Id);
        }
        
        public Banco GetBancoById(int BAN_Id, bool join)
        {
            return _BancoRepo.GetBancoById(BAN_Id, join);
        }

        public IEnumerable<Banco> GetAllBanco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _BancoRepo.GetAllBanco(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Banco> GetAllBancoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _BancoRepo.GetAllBancoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Banco> GetAllBancoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _BancoRepo.GetAllBancoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

