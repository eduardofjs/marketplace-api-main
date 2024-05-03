
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _UsuarioRepo;

        public UsuarioServices(IUsuarioRepository UsuarioRepo)
        {
            _UsuarioRepo = UsuarioRepo;
        }
		
        public Usuario InsertUsuario(Usuario objUsuario)
        {
            return _UsuarioRepo.InsertUsuario(objUsuario);
        }

        public bool UpdateUsuario(Usuario objUsuario)
        {
            return _UsuarioRepo.UpdateUsuario(objUsuario);
        }

        public bool AtivarUsuario(int USR_Id)
        {
            return _UsuarioRepo.AtivarUsuario(USR_Id);
        }

        public bool DeletarUsuario(int USR_Id)
        {
            return _UsuarioRepo.DeletarUsuario(USR_Id);
        }
        
        public Usuario GetUsuarioById(int USR_Id, bool join)
        {
            return _UsuarioRepo.GetUsuarioById(USR_Id, join);
        }

        public IEnumerable<Usuario> GetAllUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UsuarioRepo.GetAllUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Usuario> GetAllUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UsuarioRepo.GetAllUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Usuario> GetAllUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UsuarioRepo.GetAllUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }

        public Usuario GetUsuarioLogin(string Login, string Senha)
        {
            return _UsuarioRepo.GetUsuarioLogin(Login, Senha);
        }

        public Usuario GetUsuarioByCPF(string CPF, int unidadeId = 1)
        {
            return _UsuarioRepo.GetUsuarioByCPF(CPF, unidadeId);
        }

        public Usuario CreateTokenRecoveryEmail(string email, bool isProfessional)
        {
            return _UsuarioRepo.CreateTokenRecoveryEmail(email, isProfessional);
        }

        public Usuario ValidTokenRecovery(string sToken)
        {
            return _UsuarioRepo.ValidTokenRecovery(sToken);
        }

        public Usuario UpdatePassword(string sToken, string sPassword)
        {
            return _UsuarioRepo.UpdatePassword(sToken, sPassword);
        }

        public bool SalvarAvisoCoranaLido(int uSR_Id)
        {
            return _UsuarioRepo.SalvarAvisoCoranaLido(uSR_Id);
        }
    }
}

