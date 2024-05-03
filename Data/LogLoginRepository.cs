
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

namespace Data.Repositories
{
    public class LogLoginRepository : RepositoryBase, ILogLoginRepository
    {
        
        public LogLogin InsertLogLogin(LogLogin objLogLogin)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into LogLogin ");
                    strInsert.Append("(LLG_UsuarioId, LLG_ipEstacao, LLG_DataHoraLogin, LLG_DataHoraLogout, LLG_Observacao, LLG_Token, LLG_FlagLogin, LLG_FlagLogout, LLG_PlataformaId, LLG_VersaoPlataforma, LLG_VersaoApi)");
                    strInsert.Append(@" VALUES (@LLG_UsuarioId, @LLG_ipEstacao, @LLG_DataHoraLogin, @LLG_DataHoraLogout, @LLG_Observacao, @LLG_Token, @LLG_FlagLogin, @LLG_FlagLogout, @LLG_PlataformaId, @LLG_VersaoPlataforma, @LLG_VersaoApi);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            LLG_UsuarioId = objLogLogin.LLG_UsuarioId,
                            LLG_ipEstacao = objLogLogin.LLG_ipEstacao,
                            LLG_DataHoraLogin = objLogLogin.LLG_DataHoraLogin,
                            LLG_DataHoraLogout = objLogLogin.LLG_DataHoraLogout,
                            LLG_Observacao = objLogLogin.LLG_Observacao,
                            LLG_Token = objLogLogin.LLG_Token,
                            LLG_FlagLogin = objLogLogin.LLG_FlagLogin,
                            LLG_FlagLogout = objLogLogin.LLG_FlagLogout,
                            LLG_PlataformaId = objLogLogin.LLG_PlataformaId,
                            LLG_VersaoPlataforma = objLogLogin.LLG_VersaoPlataforma,
                            LLG_VersaoApi = objLogLogin.LLG_VersaoApi,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objLogLogin.LLG_Id = queryInsert.First();

                    salvaLog(objLogLogin.Log, "", "InsertLogLogin", strInsert.ToString());
                    return objLogLogin;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objLogLogin.Log, "LogLoginRepository", "InsertLogLogin", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objLogLogin.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new LogLogin();
            }
        }


        public bool UpdateLogLogin(LogLogin objLogLogin)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update LogLogin ");
                    strUpdate.Append(@" SET LLG_UsuarioId = @LLG_UsuarioId
                        , LLG_ipEstacao = @LLG_ipEstacao
                        , LLG_DataHoraLogin = @LLG_DataHoraLogin
                        , LLG_DataHoraLogout = @LLG_DataHoraLogout
                        , LLG_Observacao = @LLG_Observacao
                        , LLG_Token = @LLG_Token
                        , LLG_FlagLogin = @LLG_FlagLogin
                        , LLG_FlagLogout = @LLG_FlagLogout
                        , LLG_PlataformaId = @LLG_PlataformaId
                        , LLG_VersaoPlataforma = @LLG_VersaoPlataforma
                        , LLG_VersaoApi = @LLG_VersaoApi
                         where LLG_Id = @LLG_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            LLG_UsuarioId = objLogLogin.LLG_UsuarioId,
                            LLG_ipEstacao = objLogLogin.LLG_ipEstacao,
                            LLG_DataHoraLogin = objLogLogin.LLG_DataHoraLogin,
                            LLG_DataHoraLogout = objLogLogin.LLG_DataHoraLogout,
                            LLG_Observacao = objLogLogin.LLG_Observacao,
                            LLG_Token = objLogLogin.LLG_Token,
                            LLG_FlagLogin = objLogLogin.LLG_FlagLogin,
                            LLG_FlagLogout = objLogLogin.LLG_FlagLogout,
                            LLG_PlataformaId = objLogLogin.LLG_PlataformaId,
                            LLG_VersaoPlataforma = objLogLogin.LLG_VersaoPlataforma,
                            LLG_VersaoApi = objLogLogin.LLG_VersaoApi,
                            
                            LLG_Id = objLogLogin.LLG_Id                            
                           });
                }
                salvaLog(objLogLogin.Log, "", "UpdateLogLogin", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objLogLogin.Log, "LogLoginRepository", "UpdateLogLogin", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objLogLogin.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarLogLogin(int LLG_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update LogLogin set ");
                    strUpdate.Append(" LLG_Ativo = @LLG_Ativo ");
                    strUpdate.Append(" where LLG_Id = @LLG_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            LLG_Ativo = 1,
                                            LLG_Id = LLG_Id
                                        });
                }
                salvaLog(null, "", "AtivarLogLogin", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogLoginRepository", "AtivarLogLogin", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarLogLogin(int LLG_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update LogLogin set ");
                    strUpdate.Append(" LLG_Ativo = @LLG_Ativo ");
                    strUpdate.Append(" where LLG_Id = @LLG_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            LLG_Ativo = 0,
                                            LLG_Id = LLG_Id
                                        });
                }
                salvaLog(null, "", "DeletarLogLogin", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogLoginRepository", "DeletarLogLogin", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public LogLogin GetLogLoginById(int LLG_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from LogLogin ");
                    if(join)
                    {
                         strGet.Append(@" join Usuario on LLG_UsuarioId = USR_Id ");
                                  
                    }

                    strGet.Append(" where LLG_Id = @LLG_Id");                    

                    LogLogin obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<LogLogin, Usuario,           LogLogin>(strGet.ToString(),
                        //    (objLogLogin,  objUsuario,          ) => {
                        //         objLogLogin.Usuario = objUsuario;
                        //                  
                        //        return objLogLogin;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:" USR_Id,          ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<LogLogin>(strGet.ToString(), new { LLG_Id = LLG_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetLogLoginById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogLoginRepository", "GetLogLoginById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<LogLogin> GetAllLogLogin(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from LogLogin ");
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on LLG_UsuarioId = USR_Id ");
                                  
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where LLG_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<LogLogin> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<LogLogin, Usuario,           LogLogin>(newStrGetAll.ToString(),
                        //    (objLogLogin,  objUsuario,          ) => {
                        //         objLogLogin.Usuario = objUsuario;
                        //                  
                        //        return objLogLogin;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:" USR_Id,          ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<LogLogin>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllLogLogin", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogLoginRepository", "GetAllLogLogin", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<LogLogin> GetAllLogLoginByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from LogLogin ");
                         
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on LLG_UsuarioId = USR_Id ");
                                  
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and LLG_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<LogLogin> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<LogLogin, Usuario,           LogLogin>(newStrGetAll.ToString(),
                        //    (objLogLogin,  objUsuario,          ) => {
                        //         objLogLogin.Usuario = objUsuario;
                        //                  
                        //        return objLogLogin;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:" USR_Id,          ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<LogLogin>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllLogLoginByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogLoginRepository", "GetAllLogLoginByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<LogLogin> GetAllLogLoginByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from LogLogin ");
                    
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on LLG_UsuarioId = USR_Id ");
                                  
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and LLG_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<LogLogin> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<LogLogin, Usuario,           LogLogin>(newStrGetAll.ToString(),
                        //    (objLogLogin,  objUsuario,          ) => {
                        //         objLogLogin.Usuario = objUsuario;
                        //                  
                        //        return objLogLogin;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:" USR_Id,          ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<LogLogin>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllLogLoginByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogLoginRepository", "GetAllLogLoginByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<LogLogin> GetAllLogLoginAuditorOnline(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances, string order_by)
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(" select distinct " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP (1000)") + "     LLG_UsuarioId");
                     strGetAll.Append("  FROM [DIRECTTO].[dbo].[LogLogin] A inner join[dbo].[Usuario] U on A.LLG_UsuarioId = U.[USR_Id]");
                    strGetAll.Append("  where U.USR_FlagProfissional = 1 and U.USR_FlagGestor = 0");
                    strGetAll.Append("  and DATEDIFF(MINUTE, [LLG_DataHoraLogin], getDate()) < 2 ");
                 
                    if (fSomenteAtivos)
                        strGetAll.Append(" where LLG_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<LogLogin> lista = null;
 
                    lista = _db.Query<LogLogin>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                  
                    salvaLog(null, "", "GetAllLogLoginAuditorOnline", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogLoginRepository", "GetAllLogLoginAuditorOnline", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
