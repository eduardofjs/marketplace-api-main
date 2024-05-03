
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioServices
    {
        Usuario InsertUsuario(Usuario objUsuario);
        bool UpdateUsuario(Usuario objUsuario);
        bool AtivarUsuario(int USR_Id);
        bool DeletarUsuario(int USR_Id);
        Usuario GetUsuarioById(int USR_Id, bool join);
        IEnumerable<Usuario> GetAllUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Usuario> GetAllUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Usuario> GetAllUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        Usuario GetUsuarioLogin(string Login, string Senha);
        Usuario GetUsuarioByCPF(string CPF, int unidadeId = 1);
        Usuario CreateTokenRecoveryEmail(string email, bool isProfessional);
        Usuario ValidTokenRecovery(string sToken);
        Usuario UpdatePassword(string sToken, string sPassword);
		bool SalvarAvisoCoranaLido(int uSR_Id);
	}
}
