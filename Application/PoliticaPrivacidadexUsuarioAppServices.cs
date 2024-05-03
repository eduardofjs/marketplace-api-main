
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class PoliticaPrivacidadexUsuarioAppServices : IPoliticaPrivacidadexUsuarioAppServices
    {
        private readonly IPoliticaPrivacidadexUsuarioServices _PoliticaPrivacidadexUsuarioServices;
         private readonly IUsuarioServices _UsuarioServices;
         private readonly IPoliticaPrivacidadeServices _PoliticaPrivacidadeServices;
            

        public PoliticaPrivacidadexUsuarioAppServices(IPoliticaPrivacidadexUsuarioServices PoliticaPrivacidadexUsuarioServices  , IUsuarioServices UsuarioServices , IPoliticaPrivacidadeServices PoliticaPrivacidadeServices    )
        {
            _PoliticaPrivacidadexUsuarioServices = PoliticaPrivacidadexUsuarioServices;
             _UsuarioServices = UsuarioServices;
             _PoliticaPrivacidadeServices = PoliticaPrivacidadeServices;
              
        }

        public PoliticaPrivacidadexUsuario InsertPoliticaPrivacidadexUsuario(PoliticaPrivacidadexUsuario objPoliticaPrivacidadexUsuario)
        {
             if (objPoliticaPrivacidadexUsuario.Usuario != null)
            {
                objPoliticaPrivacidadexUsuario.Usuario = _UsuarioServices.InsertUsuario(objPoliticaPrivacidadexUsuario.Usuario);
                objPoliticaPrivacidadexUsuario.PVU_UsuarioId = objPoliticaPrivacidadexUsuario.Usuario.USR_Id;
            }
             if (objPoliticaPrivacidadexUsuario.PoliticaPrivacidade != null)
            {
                objPoliticaPrivacidadexUsuario.PoliticaPrivacidade = _PoliticaPrivacidadeServices.InsertPoliticaPrivacidade(objPoliticaPrivacidadexUsuario.PoliticaPrivacidade);
                objPoliticaPrivacidadexUsuario.PVU_PoliticaPrivacidadeId = objPoliticaPrivacidadexUsuario.PoliticaPrivacidade.PVD_Id;
            }
                
            
            return _PoliticaPrivacidadexUsuarioServices.InsertPoliticaPrivacidadexUsuario(objPoliticaPrivacidadexUsuario);
        }

        public bool UpdatePoliticaPrivacidadexUsuario(PoliticaPrivacidadexUsuario objPoliticaPrivacidadexUsuario)
        {            
             if (objPoliticaPrivacidadexUsuario.Usuario != null)
            {
                if (objPoliticaPrivacidadexUsuario.Usuario.USR_Id == 0)
                {
                    objPoliticaPrivacidadexUsuario.Usuario = _UsuarioServices.InsertUsuario(objPoliticaPrivacidadexUsuario.Usuario);
                    objPoliticaPrivacidadexUsuario.PVU_UsuarioId = objPoliticaPrivacidadexUsuario.Usuario.USR_Id;
                }
                else
                {
                    bool flagUsuario = _UsuarioServices.UpdateUsuario(objPoliticaPrivacidadexUsuario.Usuario);
                }
            }
             if (objPoliticaPrivacidadexUsuario.PoliticaPrivacidade != null)
            {
                if (objPoliticaPrivacidadexUsuario.PoliticaPrivacidade.PVD_Id == 0)
                {
                    objPoliticaPrivacidadexUsuario.PoliticaPrivacidade = _PoliticaPrivacidadeServices.InsertPoliticaPrivacidade(objPoliticaPrivacidadexUsuario.PoliticaPrivacidade);
                    objPoliticaPrivacidadexUsuario.PVU_PoliticaPrivacidadeId = objPoliticaPrivacidadexUsuario.PoliticaPrivacidade.PVD_Id;
                }
                else
                {
                    bool flagPoliticaPrivacidade = _PoliticaPrivacidadeServices.UpdatePoliticaPrivacidade(objPoliticaPrivacidadexUsuario.PoliticaPrivacidade);
                }
            }
               
            return _PoliticaPrivacidadexUsuarioServices.UpdatePoliticaPrivacidadexUsuario(objPoliticaPrivacidadexUsuario);
        }

        public bool AtivarPoliticaPrivacidadexUsuario(int PVU_Id)
        {
            return _PoliticaPrivacidadexUsuarioServices.AtivarPoliticaPrivacidadexUsuario(PVU_Id);
        }

        public bool DeletarPoliticaPrivacidadexUsuario(int PVU_Id)
        {
            return _PoliticaPrivacidadexUsuarioServices.DeletarPoliticaPrivacidadexUsuario(PVU_Id);
        }

        public PoliticaPrivacidadexUsuario GetPoliticaPrivacidadexUsuarioById(int PVU_Id, bool join)
        {
            return _PoliticaPrivacidadexUsuarioServices.GetPoliticaPrivacidadexUsuarioById(PVU_Id, join);
        }

        public IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadexUsuarioServices.GetAllPoliticaPrivacidadexUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadexUsuarioServices.GetAllPoliticaPrivacidadexUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PoliticaPrivacidadexUsuarioServices.GetAllPoliticaPrivacidadexUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

