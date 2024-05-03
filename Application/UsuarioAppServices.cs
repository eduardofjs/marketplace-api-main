
using Application.Interfaces;
using CriptoODGT.Class;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class UsuarioAppServices : IUsuarioAppServices
    {
        private readonly IUsuarioServices _UsuarioServices;
        private readonly IPessoaServices _PessoaServices;
        private readonly IPessoaAppServices _PessoaAppServices;


        public UsuarioAppServices(IUsuarioServices UsuarioServices, IPessoaAppServices PessoaAppServices, IPessoaServices PessoaServices       )
        {
            _UsuarioServices = UsuarioServices;
            _PessoaServices = PessoaServices;
            _PessoaAppServices = PessoaAppServices;

        }

        public Usuario InsertUsuario(Usuario objUsuario)
        {
            var verificacao = _UsuarioServices.GetAllUsuarioByPartial(objUsuario.USR_Email, "USR_Email", true, false, 0, "USR_Email desc");
            objUsuario.sucesso = true;
            if (verificacao.Count() > 0)
            {

                objUsuario.sucesso = false;
                objUsuario.mensagemSucesso = "Esse e-mail já esta sendo utilizado na nossa plataforma.";
                return objUsuario;
            }
            else
            {
                objUsuario.sucesso = true;
            }

            if (objUsuario.Pessoa != null)
            {
                if (objUsuario.Pessoa.PES_SexoId == null)
                    objUsuario.Pessoa.PES_SexoId = 3;
                if (objUsuario.Pessoa.PES_DataNascimento == null)
                    objUsuario.Pessoa.PES_DataNascimento = DateTime.Today;
                objUsuario.Pessoa = _PessoaAppServices.InsertPessoa(objUsuario.Pessoa);
                objUsuario.USR_PessoaId = objUsuario.Pessoa.PES_Id;
            }

            if (objUsuario.USR_Senha != null)
                objUsuario.USR_Senha = Cripto.EncryptString(objUsuario.USR_Senha, ReadString("ChaveCripto"));

            return _UsuarioServices.InsertUsuario(objUsuario);
        }

        public bool UpdateUsuario(Usuario objUsuario)
        {
            if (objUsuario.USR_Senha != null)
                objUsuario.USR_Senha = Cripto.EncryptString(objUsuario.USR_Senha, ReadString("ChaveCripto"));

            /*if (objUsuario.Pessoa != null && objUsuario.Pessoa.PES_CPF != null)
            {
                var verificacaoCPF = _PessoaAppServices.GetAllPessoaByPartial(objUsuario.Pessoa.PES_CPF, "PES_CPF", true, false, 0, "PES_CPF desc");
                if (verificacaoCPF.Count() > 0)
                {
                    objUsuario.sucesso = false;
                    objUsuario.mensagemSucesso = "Esse CPF já esta sendo utilizado na nossa plataforma.";
                    return false;
                }
            }*/

            if (objUsuario.Pessoa != null)
            {
                if (objUsuario.Pessoa.PES_Id == 0)
                {
                    objUsuario.Pessoa = _PessoaAppServices.InsertPessoa(objUsuario.Pessoa);
                    objUsuario.USR_PessoaId = objUsuario.Pessoa.PES_Id;
                }
                else
                {
                    bool flagPessoa = _PessoaAppServices.UpdatePessoa(objUsuario.Pessoa);
                }

                objUsuario.Pessoa = _PessoaAppServices.GetPessoaById(objUsuario.Pessoa.PES_Id, true);
            }

            return _UsuarioServices.UpdateUsuario(objUsuario);
        }

        public bool AtivarUsuario(int USR_Id)
        {
            return _UsuarioServices.AtivarUsuario(USR_Id);
        }

        public bool DeletarUsuario(int USR_Id)
        {
            return _UsuarioServices.DeletarUsuario(USR_Id);
        }

        public Usuario GetUsuarioById(int USR_Id, bool join)
        {
            return _UsuarioServices.GetUsuarioById(USR_Id, join);
        }

        public IEnumerable<Usuario> GetAllUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UsuarioServices.GetAllUsuario(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Usuario> GetAllUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UsuarioServices.GetAllUsuarioByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Usuario> GetAllUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UsuarioServices.GetAllUsuarioByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
        public Usuario GetUsuarioLogin(string Login, string Senha)
        {
            return _UsuarioServices.GetUsuarioLogin(Login, Cripto.EncryptString(Senha, ReadString("ChaveCripto")));
        }

        public Usuario GetUsuarioByCPF(string CPF, int unidadeId = 1)
        {
            return _UsuarioServices.GetUsuarioByCPF(CPF, unidadeId);
        }

        public static string ReadString(string key)
        {
            try
            {
                System.Configuration.AppSettingsReader rd = new System.Configuration.AppSettingsReader();
                return rd.GetValue(key, typeof(String)).ToString();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public Usuario CreateTokenRecoveryEmail(string email, bool isProfessional)
        {
            return _UsuarioServices.CreateTokenRecoveryEmail(email, isProfessional);
        }

        public Usuario ValidTokenRecovery(string sToken)
        {
            return _UsuarioServices.ValidTokenRecovery(sToken);
        }

        public Usuario UpdatePassword(string sToken, string sPassword)
        {
            if (sPassword != null)
                sPassword = Cripto.EncryptString(sPassword, ReadString("ChaveCripto"));
            return _UsuarioServices.UpdatePassword(sToken, sPassword);
        }

        public bool SalvarAvisoCoranaLido(int USR_Id)
        {
            return _UsuarioServices.SalvarAvisoCoranaLido(USR_Id);
        }
    }
}

