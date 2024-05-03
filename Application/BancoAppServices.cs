
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class BancoAppServices : IBancoAppServices
    {
        private readonly IBancoServices _BancoServices;
                

        public BancoAppServices(IBancoServices BancoServices         )
        {
            _BancoServices = BancoServices;
                  
        }

        public Banco InsertBanco(Banco objBanco)
        {
                    
            
            return _BancoServices.InsertBanco(objBanco);
        }

        public bool UpdateBanco(Banco objBanco)
        {            
                   
            return _BancoServices.UpdateBanco(objBanco);
        }

        public bool AtivarBanco(int BAN_Id)
        {
            return _BancoServices.AtivarBanco(BAN_Id);
        }

        public bool DeletarBanco(int BAN_Id)
        {
            return _BancoServices.DeletarBanco(BAN_Id);
        }

        public Banco GetBancoById(int BAN_Id, bool join)
        {
            return _BancoServices.GetBancoById(BAN_Id, join);
        }

        public IEnumerable<Banco> GetAllBanco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _BancoServices.GetAllBanco(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Banco> GetAllBancoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _BancoServices.GetAllBancoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Banco> GetAllBancoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _BancoServices.GetAllBancoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

