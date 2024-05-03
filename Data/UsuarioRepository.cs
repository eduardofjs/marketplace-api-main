
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions;
using log4net;

namespace Data.Repositories
{
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Usuario InsertUsuario(Usuario objUsuario)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Usuario] ");
                    strInsert.Append("(USR_Email, USR_Senha, USR_Ativo, USR_PessoaId, USR_UnidadeId, USR_PrimeiroAcesso, USR_DeviceID, USR_TokenRecoveryPassword, USR_TokenDateExpire,USR_FlagGestor,USR_OrigemId)");
                    strInsert.Append(@" VALUES (@USR_Email, @USR_Senha, @USR_Ativo, @USR_PessoaId, @USR_UnidadeId, @USR_PrimeiroAcesso, @USR_DeviceID, @USR_TokenRecoveryPassword, @USR_TokenDateExpire, @USR_FlagGestor,@USR_OrigemId);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            USR_Email = objUsuario.USR_Email,
                            USR_Senha = objUsuario.USR_Senha,
                            USR_Ativo = 1,
                            USR_PessoaId = objUsuario.USR_PessoaId,
                            USR_UnidadeId = objUsuario.USR_UnidadeId,
                            USR_PrimeiroAcesso = objUsuario.USR_PrimeiroAcesso,
                            USR_DeviceID = objUsuario.USR_DeviceID,
                            USR_TokenRecoveryPassword = objUsuario.USR_TokenRecoveryPassword,
                            USR_TokenDateExpire = objUsuario.USR_TokenDateExpire,
                            USR_FlagGestor = objUsuario.USR_FlagGestor,
                            USR_OrigemId = objUsuario.USR_OrigemId,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objUsuario.USR_Id = queryInsert.First();

                    salvaLog(objUsuario.Log, "", "InsertUsuario", strInsert.ToString());
                    return objUsuario;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objUsuario.Log, "UsuarioRepository", "InsertUsuario", (e.InnerException == null ? "" : e.InnerException.ToString()).ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objUsuario.Log, e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                return new Usuario();
            }
        }


        public bool UpdateUsuario(Usuario objUsuario)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Usuario] ");
                    strUpdate.Append(@" SET USR_Email = @USR_Email
                        , USR_Ativo = @USR_Ativo
                        , USR_PessoaId = @USR_PessoaId
                        , USR_UnidadeId = @USR_UnidadeId
                        , USR_PrimeiroAcesso = @USR_PrimeiroAcesso
                        , USR_DeviceID = @USR_DeviceID
                        , USR_TokenRecoveryPassword = @USR_TokenRecoveryPassword
                        , USR_TokenDateExpire = @USR_TokenDateExpire
                        , USR_FlagGestor = @USR_FlagGestor ");

                    //if (!string.IsNullOrEmpty(objUsuario.USR_Senha))
                    //    strUpdate.Append(@",  USR_Senha = @USR_Senha ");

                    strUpdate.Append(@"  where USR_Id = @USR_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               USR_Email = objUsuario.USR_Email,
                               USR_Ativo = 1,
                               USR_PessoaId = objUsuario.USR_PessoaId,
                               USR_UnidadeId = objUsuario.USR_UnidadeId,
                               USR_PrimeiroAcesso = objUsuario.USR_PrimeiroAcesso,
                               USR_DeviceID = objUsuario.USR_DeviceID,
                               USR_TokenRecoveryPassword = objUsuario.USR_TokenRecoveryPassword,
                               USR_TokenDateExpire = objUsuario.USR_TokenDateExpire,
                               USR_FlagGestor = objUsuario.USR_FlagGestor,
                               USR_Id = objUsuario.USR_Id
                           });
                }
                salvaLog(objUsuario.Log, "", "UpdateUsuario", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objUsuario.Log, "UsuarioRepository", "UpdateUsuario", (e.InnerException == null ? "" : e.InnerException.ToString()).ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objUsuario.Log, e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarUsuario(int USR_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Usuario] set ");
                    strUpdate.Append(" USR_Ativo = @USR_Ativo ");
                    strUpdate.Append(" where USR_Id = @USR_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            USR_Ativo = 1,
                                            USR_Id = USR_Id
                                        });
                }
                salvaLog(null, "", "AtivarUsuario", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "UsuarioRepository", "AtivarUsuario", (e.InnerException == null ? "" : e.InnerException.ToString()).ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarUsuario(int USR_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Usuario] set ");
                    strUpdate.Append(" USR_Ativo = @USR_Ativo ");
                    strUpdate.Append(" where USR_Id = @USR_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            USR_Ativo = 0,
                                            USR_Id = USR_Id
                                        });
                }
                salvaLog(null, "", "DeletarUsuario", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "UsuarioRepository", "DeletarUsuario", (e.InnerException == null ? "" : e.InnerException.ToString()).ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Usuario GetUsuarioById(int USR_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [Usuario] ");
                    strGet.Append(" where USR_Id = @USR_Id");

                    var obj = _db.Query<Usuario>(strGet.ToString(), new { USR_Id = USR_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {
                        var _PessoaRepo = new PessoaRepository();
                        obj.Pessoa = _PessoaRepo.GetPessoaById(obj.USR_PessoaId.GetValueOrDefault(), true);

                    }

                    salvaLog(null, "", "GetUsuarioById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UsuarioRepository", "GetUsuarioById", (e.InnerException == null ? "" : e.InnerException.ToString()).ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Usuario> GetAllUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Usuario] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where USR_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<Usuario>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _PessoaRepo = new PessoaRepository();
                            obj.Pessoa = _PessoaRepo.GetPessoaById(obj.USR_PessoaId.GetValueOrDefault(), true);

                        }
                    }
                    salvaLog(null, "", "GetAllUsuario", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UsuarioRepository", "GetAllUsuario", (e.InnerException == null ? "" : e.InnerException.ToString()).ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Usuario> GetAllUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  * from [Usuario] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and USR_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<Usuario>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _PessoaRepo = new PessoaRepository();
                            obj.Pessoa = _PessoaRepo.GetPessoaById(obj.USR_PessoaId.GetValueOrDefault(), true);

                        }
                    }
                    salvaLog(null, "", "GetAllUsuarioByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UsuarioRepository", "GetAllUsuarioByPartial", (e.InnerException == null ? "" : e.InnerException.ToString()).ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Usuario> GetAllUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Usuario] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and USR_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<Usuario>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _PessoaRepo = new PessoaRepository();
                            obj.Pessoa = _PessoaRepo.GetPessoaById(obj.USR_PessoaId.GetValueOrDefault(), true);

                        }
                    }
                    salvaLog(null, "", "GetAllUsuarioByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UsuarioRepository", "GetAllUsuarioByValorExato", (e.InnerException == null ? "" : e.InnerException.ToString()).ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public Usuario GetUsuarioLogin(string Login, string Senha)
        {
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    StringBuilder strGetAll = new StringBuilder();
                    strGetAll.Append(@" select USR_Id, USR_Email, USR_Senha, USR_Ativo, USR_PessoaId, USR_UnidadeId, USR_PrimeiroAcesso, USR_DeviceID, USR_FlagGestor, USR_FlagProfissional, USR_FlagContratante, USR_DataLeituraAvisoCorona, ");
                    strGetAll.Append(@"        PES_Id,PES_Nome,PES_SexoId,PES_CPF,PES_DataNascimento,PES_Ativo,PES_RG,PES_EnderecoId,REPLACE(REPLACE(PES_EnderecoFoto, '" + ReadString("CGL_PathImagem") + "', '" + ReadString("CGL_UrlImagem") + @"'), '\', '/') as PES_EnderecoFoto, ");
                    strGetAll.Append(@"        EMP_Id,EMP_RazaoSocial,EMP_NomeFantasia,EMP_CNPJ,EMP_Ativo,EMP_EnderecoId,EMP_TipoEmpresaId,EMP_UsuarioId,EMP_Telefone,EMP_Contato,EMP_Site,EMP_ImagemPath,EMP_FlagMercadoInterno,EMP_FlagMercadoExterno,EMP_Valor,EMP_CodigoSeguranca,EMP_Faturamento,EMP_DataCadastro,EMP_DataAbertura,EMP_FlagTermoTransporte,EMP_FlagTermoPagamento,EMP_FlagTermoPlataforma,EMP_FlagTermoUsoConta,EMP_FlagTermoPlataformaCobranca,EMP_FlagAprovado,EMP_DataAprovado,EMP_DataReprovado");
                    strGetAll.Append(@" from [Usuario] ");
                    strGetAll.Append(@" inner join [Pessoa] on PES_Id = USR_PessoaId ");
                    strGetAll.Append(@" inner join [Empresa] on USR_Id = EMP_UsuarioId ");

                    strGetAll.Append(@" where USR_Email = @USR_Email and Convert(varchar(max), USR_Senha, 0) = @USR_Senha ");

                    var usuarioReturn = _db.Query<Usuario, Pessoa,Empresa, Usuario>(strGetAll.ToString(),
                        (usuario, pessoa, empresa) =>
                        {
                            usuario.Pessoa = pessoa;
                            usuario.Empresa = empresa;
                            var truRepo = new TermoUsoRepository();
                            var tru = truRepo.GetAllTermoUso(true, true, false, 1, "TRU_Versao desc").FirstOrDefault();
                            var txuRepo = new TermoUsoxUsuarioRepository();
                            var txu = txuRepo.GetAllTermoUsoxUsuarioByValorExato(usuario.USR_Id.ToString(), "TXU_UsuarioId", true, false, 0, "TXU_Id desc");
                            usuario.USR_AceitouTermoUso = false;
                            if (txu.Count() > 0)
                            {
                                foreach (TermoUsoxUsuario txuObj in txu)
                                {
                                    if (txuObj.TXU_TermoUsoId == tru.TRU_Id)
                                    {
                                        if (txuObj.TXU_Aceite == true)
                                        {
                                            usuario.USR_AceitouTermoUso = true;
                                        }
                                        else
                                        {
                                            usuario.USR_AceitouTermoUso = false;
                                        }

                                    }
                                }
                            }
                            else
                            {
                                usuario.USR_AceitouTermoUso = false;
                            }


                            var PPRepo = new PoliticaPrivacidadeRepository();
                            var pp = PPRepo.GetAllPoliticaPrivacidade(true, true, false, 1, "PVD_Versao desc").FirstOrDefault();
                            var pxuRepo = new PoliticaPrivacidadexUsuarioRepository();
                            var pxu = pxuRepo.GetAllPoliticaPrivacidadexUsuarioByValorExato(usuario.USR_Id.ToString(), "PVU_UsuarioId", true, false, 0, "PVU_Id desc");
                            usuario.USR_AceitouPolitica = false;
                            if (pxu.Count() > 0)
                            {
                                foreach (PoliticaPrivacidadexUsuario pxuObj in pxu)
                                {
                                    if (pxuObj.PVU_PoliticaPrivacidadeId == pp.PVD_Id)
                                    {


                                        if (pxuObj.PVU_Aceite == true)
                                        {
                                            usuario.USR_AceitouPolitica = true;
                                        }
                                        else
                                        {
                                            usuario.USR_AceitouPolitica = false;
                                        }
                                    }


                                }
                            }
                            else
                            {
                                usuario.USR_AceitouPolitica = false;
                            }

                            return usuario;
                        },
                        new
                        {
                            USR_Email = Login,
                            USR_Senha = Senha
                        },
                        splitOn: "PES_Id,EMP_Id").FirstOrDefault();

                    if (usuarioReturn != null)
                    {

                        if (!string.IsNullOrEmpty(usuarioReturn.Pessoa.PES_EnderecoFoto))
                            usuarioReturn.Pessoa.PES_EnderecoFoto = ReadString("CGL_UrlImagem") + usuarioReturn.Pessoa.PES_EnderecoFoto.Replace("//", "/");
                    }

                    /*if (usuarioReturn != null)
                    {
                        LogLogin objLogLogin = new LogLogin();
                        objLogLogin.LLG_FlagLogin = true;
                        objLogLogin.LLG_DataHoraLogin = DateTime.Now;
                        objLogLogin.LLG_UsuarioId = usuarioReturn.USR_Id;

                        var _LogLogin = new LogLoginRepository();
                        _LogLogin.InsertLogLogin(objLogLogin);
                    }*/

                    return usuarioReturn;
                }
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                return null;
            }
        }

        public Usuario GetUsuarioByCPF(string CPF, int unidadeId = 1)
        {
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {

                    StringBuilder strGetAll = new StringBuilder();
                    strGetAll.Append(@" select USR_Id, USR_Email, USR_Senha, USR_Ativo, USR_PessoaId, USR_UnidadeId, USR_PrimeiroAcesso, USR_DeviceID,  
                        [USR_TokenRecoveryPassword],[USR_TokenDateExpire],[USR_FlagUsuarioApp],[USR_FlagAcessoLiberado],[USR_FlagDesconectarTodos],[USR_FlagEmpreendedor],
                        [USR_FlagPaciente],[USR_FlagContratante],[USR_FlagProfissional],[USR_FlagGestor],[USR_DataLeituraAvisoCorona], ");
                    strGetAll.Append(@"        PES_Id,PES_Nome,PES_SexoId,PES_CPF,PES_DataNascimento,PES_Ativo,PES_RG,PES_EnderecoId,REPLACE(REPLACE(PES_EnderecoFoto, '" + ReadString("CGL_PathImagem") + "', '" + ReadString("CGL_UrlImagem") + @"'), '\', '/') as PES_EnderecoFoto,
                        [PES_TelefoneResidencial],[PES_Celular],[PES_Email],[PES_PronomeTratamentoId],[PES_FlagFake],[PES_Renda],[PES_SexoBiologico],[PES_NomeResponsavel],[PES_CPFResponsavel],[PES_flagDoador]");
                    strGetAll.Append(@" from [Usuario] ");
                    strGetAll.Append(@" inner join [Pessoa] on PES_Id = USR_PessoaId ");

                    strGetAll.Append(@" where PES_CPF = @PES_CPF ");

                    var usuarioReturn = _db.Query<Usuario, Pessoa, Usuario>(strGetAll.ToString(),
                        (usuario, pessoa) =>
                        {
                            usuario.Pessoa = pessoa;

                            return usuario;
                        },
                        new
                        {
                            PES_CPF = CPF
                        },
                        splitOn: "PES_Id").FirstOrDefault();

                    if (usuarioReturn != null)
                    {

                        if (!string.IsNullOrEmpty(usuarioReturn.Pessoa.PES_EnderecoFoto))
                            usuarioReturn.Pessoa.PES_EnderecoFoto = ReadString("CGL_UrlImagem") + usuarioReturn.Pessoa.PES_EnderecoFoto.Replace("//", "/");
                    }

                    return usuarioReturn;
                }
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                return null;
            }
        }

        public Usuario CreateTokenRecoveryEmail(string email, bool isProfessional)
        {
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    var idUser = 0;
                    if (isProfessional)
                    {
                        var id = _db.Query<int>("select USR_Id from Usuario where USR_Email = @Email", new { Email = email }).FirstOrDefault();
                        idUser = id;
                    }
                    else
                    {
                        var id = _db.Query<int>("select USR_Id from Usuario where USR_Email = @Email", new { Email = email }).FirstOrDefault();
                        idUser = id;

                    }

                    if (idUser == 0)
                    {
                        return null;
                    }

                    string token = idUser.ToString() + "-" + DateTime.Now.ToString("mmssdd");
                    DateTime dtExpire = DateTime.Now.AddMinutes(10);


                    StringBuilder strUpdate = new StringBuilder();
                    strUpdate.Append("Update Usuario ");
                    strUpdate.Append("SET USR_TokenRecoveryPassword = @token, USR_TokenDateExpire = @dtExpire ");
                    strUpdate.Append(" where USR_Id = @UserId ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               UserId = idUser,
                               token = token,
                               dtExpire = dtExpire
                           });

                    strUpdate = new StringBuilder();
                    strUpdate.Append(@"select USR_Id,USR_Email,USR_Senha,USR_Ativo,USR_PessoaId,USR_UnidadeId,USR_PrimeiroAcesso, 
                                       USR_DeviceID,USR_TokenRecoveryPassword,USR_TokenDateExpire from [Usuario] ");

                    strUpdate.Append("where USR_Id = @UserId ");


                    var user = _db.Query<Usuario>(strUpdate.ToString(), new { UserId = idUser }).FirstOrDefault();
                    return user;
                }
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                return null;
            }
        }

        public Usuario ValidTokenRecovery(string sToken)
        {
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    StringBuilder strUpdate = new StringBuilder();
                    strUpdate.Append(@"select USR_Id,USR_Email,USR_Senha,USR_Ativo,USR_PessoaId,USR_UnidadeId,USR_PrimeiroAcesso, 
                                       USR_DeviceID,USR_TokenRecoveryPassword,USR_TokenDateExpire from [Usuario] ");

                    strUpdate.Append("where  USR_TokenRecoveryPassword = @TokenRecoveryPassword");

                    var user = _db.Query<Usuario>(strUpdate.ToString(), new { TokenRecoveryPassword = sToken }).FirstOrDefault();

                    if (user == null)
                        user = new Usuario();
                    user.USR_Id = 0;

                    return user;
                }
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                return null;
            }
        }

        public Usuario UpdatePassword(string sToken, string sPassword)
        {
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    StringBuilder strUpdate = new StringBuilder();
                    strUpdate.Append(" Update Usuario ");
                    strUpdate.Append(" SET USR_Senha = @sPassword ");

                    strUpdate.Append(" where USR_TokenRecoveryPassword = @sToken ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               sToken = sToken,
                               sPassword = sPassword
                           });

                    strUpdate = new StringBuilder();
                    strUpdate.Append(@"select USR_Id,USR_Email,USR_Senha,USR_Ativo,USR_PessoaId,USR_UnidadeId,USR_PrimeiroAcesso, 
                                       USR_DeviceID,USR_TokenRecoveryPassword,USR_TokenDateExpire from [Usuario] ");
                    strUpdate.Append("where  USR_TokenRecoveryPassword = @TokenRecoveryPassword ");

                    var user = _db.Query<Usuario>(strUpdate.ToString(), new { TokenRecoveryPassword = sToken }).FirstOrDefault();
                    return user;
                }
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                return null;
            }
        }


        public bool SalvarAvisoCoranaLido(int USR_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" update [Usuario] set ");
                    strUpdate.Append("   USR_DataLeituraAvisoCorona = @USR_DataLeituraAvisoCorona ");
                    strUpdate.Append(" where USR_Id = @USR_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            USR_DataLeituraAvisoCorona = DateTime.Now,
                                            USR_Id = USR_Id
                                        });
                }
                salvaLog(null, "", "SalvarAvisoCoranaLido", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "UsuarioRepository", "SalvarAvisoCoranaLido", (e.InnerException == null ? "" : e.InnerException.ToString()).ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + (e.InnerException == null ? "" : e.InnerException.ToString()) + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}
