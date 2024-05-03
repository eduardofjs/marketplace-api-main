
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TermoUsoxUsuarioAppServices : ITermoUsoxUsuarioAppServices
    {
        private readonly ITermoUsoxUsuarioServices _TermoUsoxUsuarioServices;
         private readonly IUsuarioServices _UsuarioServices;
         private readonly ITermoUsoServices _TermoUsoServices;
            

        public TermoUsoxUsuarioAppServices(ITermoUsoxUsuarioServices TermoUsoxUsuarioServices  , IUsuarioServices UsuarioServices , ITermoUsoServices TermoUsoServices    )
        {
            _TermoUsoxUsuarioServices = TermoUsoxUsuarioServices;
             _UsuarioServices = UsuarioServices;
             _TermoUsoServices = TermoUsoServices;
              
        }

        public TermoUsoxUsuario InsertTermoUsoxUsuario(TermoUsoxUsuario objTermoUsoxUsuario)
        {
             if (objTermoUsoxUsuario.Usuario != null)
            {
                objTermoUsoxUsuario.Usuario = _UsuarioServices.InsertUsuario(objTermoUsoxUsuario.Usuario);
                objTermoUsoxUsuario.TXU_UsuarioId = objTermoUsoxUsuario.Usuario.USR_Id;
            }
             if (objTermoUsoxUsuario.TermoUso != null)
            {
                objTermoUsoxUsuario.TermoUso = _TermoUsoServices.InsertTermoUso(objTermoUsoxUsuario.TermoUso);
                objTermoUsoxUsuario.TXU_TermoUsoId = objTermoUsoxUsuario.TermoUso.TRU_Id;
            }
                
            
            return _TermoUsoxUsuarioServices.InsertTermoUsoxUsuario(objTermoUsoxUsuario);
        }

        public bool UpdateTermoUsoxUsuario(TermoUsoxUsuario objTermoUsoxUsuario)
        {            
             if (objTermoUsoxUsuario.Usuario != null)
            {
                if (objTermoUsoxUsuario.Usuario.USR_Id == 0)
                {
                    objTermoUsoxUsuario.Usuario = _UsuarioServices.InsertUsuario(objTermoUsoxUsuario.Usuario);
                    objTermoUsoxUsuario.TXU_UsuarioId = objTermoUsoxUsuario.Usuario.USR_Id;
                }
                else
                {
                    bool flagUsuario = _UsuarioServices.UpdateUsuario(objTermoUsoxUsuario.Usuario);
                }
            }
             if (objTermoUsoxUsuario.TermoUso != null)
            {
                if (objTermoUsoxUsuario.TermoUso.TRU_Id == 0)
                {
                    objTermoUsoxUsuario.TermoUso = _TermoUsoServices.InsertTermoUso(objTermoUsoxUsuario.TermoUso);
                    objTermoUsoxUsuario.TXU_TermoUsoId = objTermoUsoxUsuario.TermoUso.TRU_Id;
                }
                else
                {
                    bool flagTermoUso = _TermoUsoServices.UpdateTermoUso(objTermoUsoxUsuario.TermoUso);
                }
            }
               
            return _TermoUsoxUsuarioServices.UpdateTermoUsoxUsuario(objTermoUsoxUsuario);
        }

        public bool AtivarTermoUsoxUsuario(int TXU_Id)
        {
            return _TermoUsoxUsuarioServices.AtivarTermoUsoxUsuario(TXU_Id);
        }

        public bool DeletarTermoUsoxUsuario(int TXU_Id)
        {
            return _TermoUsoxUsuarioServices.DeletarTermoUsoxUsuario(TXU_Id);
        }

        public TermoUsoxUsuario GetTermoUsoxUsuarioById(int TXU_Id, bool join)
        {
            return _TermoUsoxUsuarioServices.GetTermoUsoxUsuarioById(TXU_Id, join);
        }

        public IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoxUsuarioServices.GetAllTermoUsoxUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoxUsuarioServices.GetAllTermoUsoxUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TermoUsoxUsuarioServices.GetAllTermoUsoxUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

