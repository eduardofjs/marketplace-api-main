
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class NotificacaoAppServices : INotificacaoAppServices
    {
        private readonly INotificacaoServices _NotificacaoServices;
         private readonly IUsuarioServices _UsuarioServices;
        private readonly ITipoNotificacaoServices _TipoNotificacaoServices;
                   

        public NotificacaoAppServices(INotificacaoServices NotificacaoServices  , IUsuarioServices UsuarioServices, ITipoNotificacaoServices TipoNotificacaoServices           )
        {
            _NotificacaoServices = NotificacaoServices;
             _UsuarioServices = UsuarioServices;
            _TipoNotificacaoServices = TipoNotificacaoServices;
                     
        }

        public Notificacao InsertNotificacao(Notificacao objNotificacao)
        {
             if (objNotificacao.Usuario != null)
            {
                objNotificacao.Usuario = _UsuarioServices.InsertUsuario(objNotificacao.Usuario);
                objNotificacao.NOT_UsuarioId = objNotificacao.Usuario.USR_Id;
            }
            if (objNotificacao.TipoNotificacao != null)
            {
                objNotificacao.TipoNotificacao = _TipoNotificacaoServices.InsertTipoNotificacao(objNotificacao.TipoNotificacao);
                objNotificacao.NOT_TipoNotificacaoId = objNotificacao.TipoNotificacao.TPN_Id;
            }
                       
            
            return _NotificacaoServices.InsertNotificacao(objNotificacao);
        }

        public bool UpdateNotificacao(Notificacao objNotificacao)
        {            
             if (objNotificacao.Usuario != null)
            {
                if (objNotificacao.Usuario.USR_Id == 0)
                {
                    objNotificacao.Usuario = _UsuarioServices.InsertUsuario(objNotificacao.Usuario);
                    objNotificacao.NOT_UsuarioId = objNotificacao.Usuario.USR_Id;
                }
                else
                {
                    bool flagUsuario = _UsuarioServices.UpdateUsuario(objNotificacao.Usuario);
                }
            }
            if (objNotificacao.TipoNotificacao != null)
            {
                if (objNotificacao.TipoNotificacao.TPN_Id == 0)
                {
                    objNotificacao.TipoNotificacao = _TipoNotificacaoServices.InsertTipoNotificacao(objNotificacao.TipoNotificacao);
                    objNotificacao.NOT_TipoNotificacaoId = objNotificacao.TipoNotificacao.TPN_Id;
                }
                else
                {
                    bool flagTipoNotificacao = _TipoNotificacaoServices.UpdateTipoNotificacao(objNotificacao.TipoNotificacao);
                }
            }
                      
            return _NotificacaoServices.UpdateNotificacao(objNotificacao);
        }

        public bool AtivarNotificacao(int NOT_Id)
        {
            return _NotificacaoServices.AtivarNotificacao(NOT_Id);
        }

        public bool DeletarNotificacao(int NOT_Id)
        {
            return _NotificacaoServices.DeletarNotificacao(NOT_Id);
        }

        public Notificacao GetNotificacaoById(int NOT_Id, bool join)
        {
            return _NotificacaoServices.GetNotificacaoById(NOT_Id, join);
        }

        public IEnumerable<Notificacao> GetAllNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _NotificacaoServices.GetAllNotificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Notificacao> GetAllNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _NotificacaoServices.GetAllNotificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Notificacao> GetAllNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _NotificacaoServices.GetAllNotificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

