
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class NotificacaoServices : INotificacaoServices
    {
        private readonly INotificacaoRepository _NotificacaoRepo;

        public NotificacaoServices(INotificacaoRepository NotificacaoRepo)
        {
            _NotificacaoRepo = NotificacaoRepo;
        }
		
        public Notificacao InsertNotificacao(Notificacao objNotificacao)
        {
            return _NotificacaoRepo.InsertNotificacao(objNotificacao);
        }

        public bool UpdateNotificacao(Notificacao objNotificacao)
        {
            return _NotificacaoRepo.UpdateNotificacao(objNotificacao);
        }

        public bool AtivarNotificacao(int NOT_Id)
        {
            return _NotificacaoRepo.AtivarNotificacao(NOT_Id);
        }

        public bool DeletarNotificacao(int NOT_Id)
        {
            return _NotificacaoRepo.DeletarNotificacao(NOT_Id);
        }
        
        public Notificacao GetNotificacaoById(int NOT_Id, bool join)
        {
            return _NotificacaoRepo.GetNotificacaoById(NOT_Id, join);
        }

        public IEnumerable<Notificacao> GetAllNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _NotificacaoRepo.GetAllNotificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Notificacao> GetAllNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _NotificacaoRepo.GetAllNotificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Notificacao> GetAllNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _NotificacaoRepo.GetAllNotificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

