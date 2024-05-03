
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TipoNotificacaoAppServices : ITipoNotificacaoAppServices
    {
        private readonly ITipoNotificacaoServices _TipoNotificacaoServices;
                

        public TipoNotificacaoAppServices(ITipoNotificacaoServices TipoNotificacaoServices         )
        {
            _TipoNotificacaoServices = TipoNotificacaoServices;
                  
        }

        public TipoNotificacao InsertTipoNotificacao(TipoNotificacao objTipoNotificacao)
        {
                    
            
            return _TipoNotificacaoServices.InsertTipoNotificacao(objTipoNotificacao);
        }

        public bool UpdateTipoNotificacao(TipoNotificacao objTipoNotificacao)
        {            
                   
            return _TipoNotificacaoServices.UpdateTipoNotificacao(objTipoNotificacao);
        }

        public bool AtivarTipoNotificacao(int TPN_Id)
        {
            return _TipoNotificacaoServices.AtivarTipoNotificacao(TPN_Id);
        }

        public bool DeletarTipoNotificacao(int TPN_Id)
        {
            return _TipoNotificacaoServices.DeletarTipoNotificacao(TPN_Id);
        }

        public TipoNotificacao GetTipoNotificacaoById(int TPN_Id, bool join)
        {
            return _TipoNotificacaoServices.GetTipoNotificacaoById(TPN_Id, join);
        }

        public IEnumerable<TipoNotificacao> GetAllTipoNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoNotificacaoServices.GetAllTipoNotificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoNotificacao> GetAllTipoNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoNotificacaoServices.GetAllTipoNotificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoNotificacao> GetAllTipoNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoNotificacaoServices.GetAllTipoNotificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

