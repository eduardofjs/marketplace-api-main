
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class LogAppServices : ILogAppServices
    {
        private readonly ILogServices _LogServices;
         private readonly ISubMenuServices _SubMenuServices;
        private readonly IUsuarioServices _UsuarioServices;
            private readonly ITipoTransacaoLogServices _TipoTransacaoLogServices;
            private readonly IPerfilServices _PerfilServices;
                

        public LogAppServices(ILogServices LogServices  , ISubMenuServices SubMenuServices, IUsuarioServices UsuarioServices    , ITipoTransacaoLogServices TipoTransacaoLogServices    , IPerfilServices PerfilServices        )
        {
            _LogServices = LogServices;
             _SubMenuServices = SubMenuServices;
            _UsuarioServices = UsuarioServices;
                _TipoTransacaoLogServices = TipoTransacaoLogServices;
                _PerfilServices = PerfilServices;
                  
        }

        public Log InsertLog(Log objLog)
        {
             if (objLog.SubMenu != null)
            {
                objLog.SubMenu = _SubMenuServices.InsertSubMenu(objLog.SubMenu);
                objLog.LOG_SubMenuId = objLog.SubMenu.SBM_Id;
            }
            if (objLog.Usuario != null)
            {
                objLog.Usuario = _UsuarioServices.InsertUsuario(objLog.Usuario);
                objLog.LOG_UsuarioId = objLog.Usuario.USR_Id;
            }
                if (objLog.TipoTransacaoLog != null)
            {
                objLog.TipoTransacaoLog = _TipoTransacaoLogServices.InsertTipoTransacaoLog(objLog.TipoTransacaoLog);
                objLog.LOG_TipoTransacaoId = objLog.TipoTransacaoLog.TTL_Id;
            }
                if (objLog.Perfil != null)
            {
                objLog.Perfil = _PerfilServices.InsertPerfil(objLog.Perfil);
                objLog.LOG_PerfilId = objLog.Perfil.PRF_Id;
            }
                    
            
            return _LogServices.InsertLog(objLog);
        }

        public bool UpdateLog(Log objLog)
        {            
             if (objLog.SubMenu != null)
            {
                if (objLog.SubMenu.SBM_Id == 0)
                {
                    objLog.SubMenu = _SubMenuServices.InsertSubMenu(objLog.SubMenu);
                    objLog.LOG_SubMenuId = objLog.SubMenu.SBM_Id;
                }
                else
                {
                    bool flagSubMenu = _SubMenuServices.UpdateSubMenu(objLog.SubMenu);
                }
            }
            if (objLog.Usuario != null)
            {
                if (objLog.Usuario.USR_Id == 0)
                {
                    objLog.Usuario = _UsuarioServices.InsertUsuario(objLog.Usuario);
                    objLog.LOG_UsuarioId = objLog.Usuario.USR_Id;
                }
                else
                {
                    bool flagUsuario = _UsuarioServices.UpdateUsuario(objLog.Usuario);
                }
            }
                if (objLog.TipoTransacaoLog != null)
            {
                if (objLog.TipoTransacaoLog.TTL_Id == 0)
                {
                    objLog.TipoTransacaoLog = _TipoTransacaoLogServices.InsertTipoTransacaoLog(objLog.TipoTransacaoLog);
                    objLog.LOG_TipoTransacaoId = objLog.TipoTransacaoLog.TTL_Id;
                }
                else
                {
                    bool flagTipoTransacaoLog = _TipoTransacaoLogServices.UpdateTipoTransacaoLog(objLog.TipoTransacaoLog);
                }
            }
                if (objLog.Perfil != null)
            {
                if (objLog.Perfil.PRF_Id == 0)
                {
                    objLog.Perfil = _PerfilServices.InsertPerfil(objLog.Perfil);
                    objLog.LOG_PerfilId = objLog.Perfil.PRF_Id;
                }
                else
                {
                    bool flagPerfil = _PerfilServices.UpdatePerfil(objLog.Perfil);
                }
            }
                   
            return _LogServices.UpdateLog(objLog);
        }

        public bool AtivarLog(int LOG_Id)
        {
            return _LogServices.AtivarLog(LOG_Id);
        }

        public bool DeletarLog(int LOG_Id)
        {
            return _LogServices.DeletarLog(LOG_Id);
        }

        public Log GetLogById(int LOG_Id, bool join)
        {
            return _LogServices.GetLogById(LOG_Id, join);
        }

        public IEnumerable<Log> GetAllLog(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogServices.GetAllLog(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Log> GetAllLogByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogServices.GetAllLogByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Log> GetAllLogByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogServices.GetAllLogByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

