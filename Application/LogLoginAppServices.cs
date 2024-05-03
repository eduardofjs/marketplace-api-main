
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class LogLoginAppServices : ILogLoginAppServices
    {
        private readonly ILogLoginServices _LogLoginServices;
         private readonly IUsuarioServices _UsuarioServices;
                    

        public LogLoginAppServices(ILogLoginServices LogLoginServices  , IUsuarioServices UsuarioServices            )
        {
            _LogLoginServices = LogLoginServices;
             _UsuarioServices = UsuarioServices;
                      
        }

        public LogLogin InsertLogLogin(LogLogin objLogLogin)
        {
             if (objLogLogin.Usuario != null)
            {
                objLogLogin.Usuario = _UsuarioServices.InsertUsuario(objLogLogin.Usuario);
                objLogLogin.LLG_UsuarioId = objLogLogin.Usuario.USR_Id;
            }
                        
            
            return _LogLoginServices.InsertLogLogin(objLogLogin);
        }

        public bool UpdateLogLogin(LogLogin objLogLogin)
        {            
             if (objLogLogin.Usuario != null)
            {
                if (objLogLogin.Usuario.USR_Id == 0)
                {
                    objLogLogin.Usuario = _UsuarioServices.InsertUsuario(objLogLogin.Usuario);
                    objLogLogin.LLG_UsuarioId = objLogLogin.Usuario.USR_Id;
                }
                else
                {
                    bool flagUsuario = _UsuarioServices.UpdateUsuario(objLogLogin.Usuario);
                }
            }
                       
            return _LogLoginServices.UpdateLogLogin(objLogLogin);
        }

        public bool AtivarLogLogin(int LLG_Id)
        {
            return _LogLoginServices.AtivarLogLogin(LLG_Id);
        }

        public bool DeletarLogLogin(int LLG_Id)
        {
            return _LogLoginServices.DeletarLogLogin(LLG_Id);
        }

        public LogLogin GetLogLoginById(int LLG_Id, bool join)
        {
            return _LogLoginServices.GetLogLoginById(LLG_Id, join);
        }

        public IEnumerable<LogLogin> GetAllLogLogin(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogLoginServices.GetAllLogLogin(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogLogin> GetAllLogLoginByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogLoginServices.GetAllLogLoginByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogLogin> GetAllLogLoginByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogLoginServices.GetAllLogLoginByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogLogin> GetAllLogLoginAuditorOnline(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by)
        {
            return _LogLoginServices.GetAllLogLoginAuditorOnline(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

