
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class LogErroAppServices : ILogErroAppServices
    {
        private readonly ILogErroServices _LogErroServices;
          private readonly IUsuarioServices _UsuarioServices;
                      

        public LogErroAppServices(ILogErroServices LogErroServices   , IUsuarioServices UsuarioServices              )
        {
            _LogErroServices = LogErroServices;
              _UsuarioServices = UsuarioServices;
                        
        }

        public LogErro InsertLogErro(LogErro objLogErro)
        {
              if (objLogErro.Usuario != null)
            {
                objLogErro.Usuario = _UsuarioServices.InsertUsuario(objLogErro.Usuario);
                objLogErro.LGE_UsuarioId = objLogErro.Usuario.USR_Id;
            }
                          
            
            return _LogErroServices.InsertLogErro(objLogErro);
        }

        public bool UpdateLogErro(LogErro objLogErro)
        {            
              if (objLogErro.Usuario != null)
            {
                if (objLogErro.Usuario.USR_Id == 0)
                {
                    objLogErro.Usuario = _UsuarioServices.InsertUsuario(objLogErro.Usuario);
                    objLogErro.LGE_UsuarioId = objLogErro.Usuario.USR_Id;
                }
                else
                {
                    bool flagUsuario = _UsuarioServices.UpdateUsuario(objLogErro.Usuario);
                }
            }
                         
            return _LogErroServices.UpdateLogErro(objLogErro);
        }

        public bool AtivarLogErro(int LGE_Id)
        {
            return _LogErroServices.AtivarLogErro(LGE_Id);
        }

        public bool DeletarLogErro(int LGE_Id)
        {
            return _LogErroServices.DeletarLogErro(LGE_Id);
        }

        public LogErro GetLogErroById(int LGE_Id, bool join)
        {
            return _LogErroServices.GetLogErroById(LGE_Id, join);
        }

        public IEnumerable<LogErro> GetAllLogErro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogErroServices.GetAllLogErro(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogErro> GetAllLogErroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogErroServices.GetAllLogErroByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<LogErro> GetAllLogErroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _LogErroServices.GetAllLogErroByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

