
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TipoNotificacaoServices : ITipoNotificacaoServices
    {
        private readonly ITipoNotificacaoRepository _TipoNotificacaoRepo;

        public TipoNotificacaoServices(ITipoNotificacaoRepository TipoNotificacaoRepo)
        {
            _TipoNotificacaoRepo = TipoNotificacaoRepo;
        }
		
        public TipoNotificacao InsertTipoNotificacao(TipoNotificacao objTipoNotificacao)
        {
            return _TipoNotificacaoRepo.InsertTipoNotificacao(objTipoNotificacao);
        }

        public bool UpdateTipoNotificacao(TipoNotificacao objTipoNotificacao)
        {
            return _TipoNotificacaoRepo.UpdateTipoNotificacao(objTipoNotificacao);
        }

        public bool AtivarTipoNotificacao(int TPN_Id)
        {
            return _TipoNotificacaoRepo.AtivarTipoNotificacao(TPN_Id);
        }

        public bool DeletarTipoNotificacao(int TPN_Id)
        {
            return _TipoNotificacaoRepo.DeletarTipoNotificacao(TPN_Id);
        }
        
        public TipoNotificacao GetTipoNotificacaoById(int TPN_Id, bool join)
        {
            return _TipoNotificacaoRepo.GetTipoNotificacaoById(TPN_Id, join);
        }

        public IEnumerable<TipoNotificacao> GetAllTipoNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoNotificacaoRepo.GetAllTipoNotificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoNotificacao> GetAllTipoNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoNotificacaoRepo.GetAllTipoNotificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoNotificacao> GetAllTipoNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoNotificacaoRepo.GetAllTipoNotificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

