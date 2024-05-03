
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
    public class LogRepository : RepositoryBase, ILogRepository
    {
        
        public Log InsertLog(Log objLog)
        {
            //StringBuilder strInsert = new StringBuilder();
            //try
            //{
            //    using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
            //    {
            //        strInsert.Append("INSERT into Log ");
            //        strInsert.Append("(LOG_SubMenuId, LOG_UsuarioId, LOG_DataHora, LOG_Token, LOG_IpEstacao, LOG_Observacao, LOG_TipoTransacaoId, LOG_Ativo, LOG_PlataformaId, LOG_VersaoPlataforma, LOG_VersaoApi, LOG_PerfilId, LOG_Metodo, LOG_ParametroJson, LOG_UnidadeId, LOG_QueryString, LOG_InternoSympor, LOG_EmpresaId)");
            //        strInsert.Append(@" VALUES (@LOG_SubMenuId, @LOG_UsuarioId, @LOG_DataHora, @LOG_Token, @LOG_IpEstacao, @LOG_Observacao, @LOG_TipoTransacaoId, @LOG_Ativo, @LOG_PlataformaId, @LOG_VersaoPlataforma, @LOG_VersaoApi, @LOG_PerfilId, @LOG_Metodo, @LOG_ParametroJson, @LOG_UnidadeId, @LOG_QueryString, @LOG_InternoSympor, @LOG_EmpresaId);");
            //        strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

            //        var queryInsert = _db.Query<int>(strInsert.ToString(),
            //            new
            //            {
            //                LOG_SubMenuId = objLog.LOG_SubMenuId,
            //                LOG_UsuarioId = objLog.LOG_UsuarioId,
            //                LOG_DataHora = objLog.LOG_DataHora,
            //                LOG_Token = objLog.LOG_Token,
            //                LOG_IpEstacao = objLog.LOG_IpEstacao,
            //                LOG_Observacao = objLog.LOG_Observacao,
            //                LOG_TipoTransacaoId = objLog.LOG_TipoTransacaoId,
            //                LOG_Ativo = objLog.LOG_Ativo,
            //                LOG_PlataformaId = objLog.LOG_PlataformaId,
            //                LOG_VersaoPlataforma = objLog.LOG_VersaoPlataforma,
            //                LOG_VersaoApi = objLog.LOG_VersaoApi,
            //                LOG_PerfilId = objLog.LOG_PerfilId,
            //                LOG_Metodo = objLog.LOG_Metodo,
            //                LOG_ParametroJson = objLog.LOG_ParametroJson,
            //                LOG_UnidadeId = objLog.LOG_UnidadeId,
            //                LOG_QueryString = objLog.LOG_QueryString,
            //                LOG_InternoSympor = objLog.LOG_InternoSympor,
            //                LOG_EmpresaId = objLog.LOG_EmpresaId,

            //            });

            //        if (queryInsert != null && queryInsert.First() > 0)
            //            objLog.LOG_Id = queryInsert.First();

            //        return objLog;
            //    }
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}
            return new Log();
        }


        public bool UpdateLog(Log objLog)
        {
            //StringBuilder strUpdate = new StringBuilder();
            //try
            //{

            //    using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
            //    {
            //        strUpdate.Append(" Update Log ");
            //        strUpdate.Append(@" SET LOG_SubMenuId = @LOG_SubMenuId
            //            , LOG_UsuarioId = @LOG_UsuarioId
            //            , LOG_DataHora = @LOG_DataHora
            //            , LOG_Token = @LOG_Token
            //            , LOG_IpEstacao = @LOG_IpEstacao
            //            , LOG_Observacao = @LOG_Observacao
            //            , LOG_TipoTransacaoId = @LOG_TipoTransacaoId
            //            , LOG_Ativo = @LOG_Ativo
            //            , LOG_PlataformaId = @LOG_PlataformaId
            //            , LOG_VersaoPlataforma = @LOG_VersaoPlataforma
            //            , LOG_VersaoApi = @LOG_VersaoApi
            //            , LOG_PerfilId = @LOG_PerfilId
            //            , LOG_Metodo = @LOG_Metodo
            //            , LOG_ParametroJson = @LOG_ParametroJson
            //            , LOG_UnidadeId = @LOG_UnidadeId
            //            , LOG_QueryString = @LOG_QueryString
            //            , LOG_InternoSympor = @LOG_InternoSympor
            //            , LOG_EmpresaId = @LOG_EmpresaId
            //             where LOG_Id = @LOG_Id ");

            //        _db.Execute(
            //              strUpdate.ToString(),
            //               new
            //               {
            //                LOG_SubMenuId = objLog.LOG_SubMenuId,
            //                LOG_UsuarioId = objLog.LOG_UsuarioId,
            //                LOG_DataHora = objLog.LOG_DataHora,
            //                LOG_Token = objLog.LOG_Token,
            //                LOG_IpEstacao = objLog.LOG_IpEstacao,
            //                LOG_Observacao = objLog.LOG_Observacao,
            //                LOG_TipoTransacaoId = objLog.LOG_TipoTransacaoId,
            //                LOG_Ativo = objLog.LOG_Ativo,
            //                LOG_PlataformaId = objLog.LOG_PlataformaId,
            //                LOG_VersaoPlataforma = objLog.LOG_VersaoPlataforma,
            //                LOG_VersaoApi = objLog.LOG_VersaoApi,
            //                LOG_PerfilId = objLog.LOG_PerfilId,
            //                LOG_Metodo = objLog.LOG_Metodo,
            //                LOG_ParametroJson = objLog.LOG_ParametroJson,
            //                LOG_UnidadeId = objLog.LOG_UnidadeId,
            //                LOG_QueryString = objLog.LOG_QueryString,
            //                LOG_InternoSympor = objLog.LOG_InternoSympor,
            //                LOG_EmpresaId = objLog.LOG_EmpresaId,

            //                LOG_Id = objLog.LOG_Id                            
            //               });
            //    }
            //    return true;

            //}
            //catch (Exception e)
            //{   
            //    return false;
            //}
            return true;
        }

        public bool AtivarLog(int LOG_Id)
        {
            //StringBuilder strUpdate = new StringBuilder();
            //try
            //{
            //    using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
            //    {
            //        strUpdate.Append("update Log set ");
            //        strUpdate.Append(" LOG_Ativo = @LOG_Ativo ");
            //        strUpdate.Append(" where LOG_Id = @LOG_Id ");

            //        _db.Execute(
            //             strUpdate.ToString(),
            //                            new
            //                            {
            //                                LOG_Ativo = 1,
            //                                LOG_Id = LOG_Id
            //                            });
            //    }
            //    salvaLog(null, "", "AtivarLog", strUpdate.ToString());
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    salvaLogError(null, "LogRepository", "AtivarLog", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
            //    salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
            //    return false;
            //}
            return true;
        }

        public bool DeletarLog(int LOG_Id)
        {
            //StringBuilder strUpdate = new StringBuilder();
            //try
            //{

            //    using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
            //    {
            //        strUpdate.Append("update Log set ");
            //        strUpdate.Append(" LOG_Ativo = @LOG_Ativo ");
            //        strUpdate.Append(" where LOG_Id = @LOG_Id ");

            //        _db.Execute(
            //             strUpdate.ToString(),
            //                            new
            //                            {
            //                                LOG_Ativo = 0,
            //                                LOG_Id = LOG_Id
            //                            });
            //    }
            //    salvaLog(null, "", "DeletarLog", strUpdate.ToString());
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    salvaLogError(null, "LogRepository", "DeletarLog", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
            //    salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
            //    return false;
            //}
            return true;
        }

        public Log GetLogById(int LOG_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from Log ");
                    if(join)
                    {
                         strGet.Append(@" join SubMenu on LOG_SubMenuId = SBM_Id ");
                        strGet.Append(@" join Usuario on LOG_UsuarioId = USR_Id ");
                                        
                    }

                    strGet.Append(" where LOG_Id = @LOG_Id");                    

                    Log obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<Log, SubMenu, Usuario,                 Log>(strGet.ToString(),
                        //    (objLog,  objSubMenu,objUsuario,                ) => {
                        //         objLog.SubMenu = objSubMenu;
                        //        objLog.Usuario = objUsuario;
                        //                        
                        //        return objLog;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:" SBM_Id,USR_Id,                ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<Log>(strGet.ToString(), new { LOG_Id = LOG_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetLogById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogRepository", "GetLogById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Log> GetAllLog(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from Log ");
                    if(join)
                    {
                         strGetAll.Append(@" join SubMenu on LOG_SubMenuId = SBM_Id ");
                        strGetAll.Append(@" join Usuario on LOG_UsuarioId = USR_Id ");
                                        
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where LOG_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Log> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<Log, SubMenu, Usuario,                 Log>(newStrGetAll.ToString(),
                        //    (objLog,  objSubMenu,objUsuario,                ) => {
                        //         objLog.SubMenu = objSubMenu;
                        //        objLog.Usuario = objUsuario;
                        //                        
                        //        return objLog;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:" SBM_Id,USR_Id,                ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<Log>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllLog", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogRepository", "GetAllLog", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<Log> GetAllLogByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from Log ");
                         
                    if(join)
                    {
                         strGetAll.Append(@" join SubMenu on LOG_SubMenuId = SBM_Id ");
                        strGetAll.Append(@" join Usuario on LOG_UsuarioId = USR_Id ");
                                        
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and LOG_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Log> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<Log, SubMenu, Usuario,                 Log>(newStrGetAll.ToString(),
                        //    (objLog,  objSubMenu,objUsuario,                ) => {
                        //         objLog.SubMenu = objSubMenu;
                        //        objLog.Usuario = objUsuario;
                        //                        
                        //        return objLog;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:" SBM_Id,USR_Id,                ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<Log>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllLogByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogRepository", "GetAllLogByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Log> GetAllLogByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from Log ");
                    
                    if(join)
                    {
                         strGetAll.Append(@" join SubMenu on LOG_SubMenuId = SBM_Id ");
                        strGetAll.Append(@" join Usuario on LOG_UsuarioId = USR_Id ");
                                        
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and LOG_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Log> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<Log, SubMenu, Usuario,                 Log>(newStrGetAll.ToString(),
                        //    (objLog,  objSubMenu,objUsuario,                ) => {
                        //         objLog.SubMenu = objSubMenu;
                        //        objLog.Usuario = objUsuario;
                        //                        
                        //        return objLog;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:" SBM_Id,USR_Id,                ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<Log>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllLogByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogRepository", "GetAllLogByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
