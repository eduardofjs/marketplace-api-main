
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
    public class LogErroRepository : RepositoryBase, ILogErroRepository
    {
        
        public LogErro InsertLogErro(LogErro objLogErro)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into LogErro ");
                    strInsert.Append("(LGE_DataHora, LGE_UsuarioId, LGE_token, LGE_SubMenuId, LGE_className, LGE_functionName, LGE_erroFullName, LGE_erroMessage, LGE_erroStackTrace, LGE_erroData, LGE_PlataformaId, LGE_VersaoPlataforma, LGE_VersaoApi, LGE_QueryString)");
                    strInsert.Append(@" VALUES (@LGE_DataHora, @LGE_UsuarioId, @LGE_token, @LGE_SubMenuId, @LGE_className, @LGE_functionName, @LGE_erroFullName, @LGE_erroMessage, @LGE_erroStackTrace, @LGE_erroData, @LGE_PlataformaId, @LGE_VersaoPlataforma, @LGE_VersaoApi, @LGE_QueryString);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            LGE_DataHora = objLogErro.LGE_DataHora,
                            LGE_UsuarioId = objLogErro.LGE_UsuarioId,
                            LGE_token = objLogErro.LGE_token,
                            LGE_SubMenuId = objLogErro.LGE_SubMenuId,
                            LGE_className = objLogErro.LGE_className,
                            LGE_functionName = objLogErro.LGE_functionName,
                            LGE_erroFullName = objLogErro.LGE_erroFullName,
                            LGE_erroMessage = objLogErro.LGE_erroMessage,
                            LGE_erroStackTrace = objLogErro.LGE_erroStackTrace,
                            LGE_erroData = objLogErro.LGE_erroData,
                            LGE_PlataformaId = objLogErro.LGE_PlataformaId,
                            LGE_VersaoPlataforma = objLogErro.LGE_VersaoPlataforma,
                            LGE_VersaoApi = objLogErro.LGE_VersaoApi,
                            LGE_QueryString = objLogErro.LGE_QueryString,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objLogErro.LGE_Id = queryInsert.First();

                    salvaLog(objLogErro.Log, "", "InsertLogErro", strInsert.ToString());
                    return objLogErro;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objLogErro.Log, "LogErroRepository", "InsertLogErro", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objLogErro.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new LogErro();
            }
        }


        public bool UpdateLogErro(LogErro objLogErro)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update LogErro ");
                    strUpdate.Append(@" SET LGE_DataHora = @LGE_DataHora
                        , LGE_UsuarioId = @LGE_UsuarioId
                        , LGE_token = @LGE_token
                        , LGE_SubMenuId = @LGE_SubMenuId
                        , LGE_className = @LGE_className
                        , LGE_functionName = @LGE_functionName
                        , LGE_erroFullName = @LGE_erroFullName
                        , LGE_erroMessage = @LGE_erroMessage
                        , LGE_erroStackTrace = @LGE_erroStackTrace
                        , LGE_erroData = @LGE_erroData
                        , LGE_PlataformaId = @LGE_PlataformaId
                        , LGE_VersaoPlataforma = @LGE_VersaoPlataforma
                        , LGE_VersaoApi = @LGE_VersaoApi
                        , LGE_QueryString = @LGE_QueryString
                         where LGE_Id = @LGE_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            LGE_DataHora = objLogErro.LGE_DataHora,
                            LGE_UsuarioId = objLogErro.LGE_UsuarioId,
                            LGE_token = objLogErro.LGE_token,
                            LGE_SubMenuId = objLogErro.LGE_SubMenuId,
                            LGE_className = objLogErro.LGE_className,
                            LGE_functionName = objLogErro.LGE_functionName,
                            LGE_erroFullName = objLogErro.LGE_erroFullName,
                            LGE_erroMessage = objLogErro.LGE_erroMessage,
                            LGE_erroStackTrace = objLogErro.LGE_erroStackTrace,
                            LGE_erroData = objLogErro.LGE_erroData,
                            LGE_PlataformaId = objLogErro.LGE_PlataformaId,
                            LGE_VersaoPlataforma = objLogErro.LGE_VersaoPlataforma,
                            LGE_VersaoApi = objLogErro.LGE_VersaoApi,
                            LGE_QueryString = objLogErro.LGE_QueryString,
                            
                            LGE_Id = objLogErro.LGE_Id                            
                           });
                }
                salvaLog(objLogErro.Log, "", "UpdateLogErro", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objLogErro.Log, "LogErroRepository", "UpdateLogErro", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objLogErro.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarLogErro(int LGE_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update LogErro set ");
                    strUpdate.Append(" LGE_Ativo = @LGE_Ativo ");
                    strUpdate.Append(" where LGE_Id = @LGE_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            LGE_Ativo = 1,
                                            LGE_Id = LGE_Id
                                        });
                }
                salvaLog(null, "", "AtivarLogErro", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogErroRepository", "AtivarLogErro", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarLogErro(int LGE_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update LogErro set ");
                    strUpdate.Append(" LGE_Ativo = @LGE_Ativo ");
                    strUpdate.Append(" where LGE_Id = @LGE_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            LGE_Ativo = 0,
                                            LGE_Id = LGE_Id
                                        });
                }
                salvaLog(null, "", "DeletarLogErro", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogErroRepository", "DeletarLogErro", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public LogErro GetLogErroById(int LGE_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from LogErro ");
                    if(join)
                    {
                            strGet.Append(@" join SubMenu on LGE_SubMenuId = SBM_Id ");
                                  
                    }

                    strGet.Append(" where LGE_Id = @LGE_Id");                    

                    LogErro obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<LogErro,    SubMenu,           LogErro>(strGet.ToString(),
                        //    (objLogErro,     objSubMenu,          ) => {
                        //            objLogErro.SubMenu = objSubMenu;
                        //                  
                        //        return objLogErro;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"    SBM_Id,          ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<LogErro>(strGet.ToString(), new { LGE_Id = LGE_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetLogErroById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogErroRepository", "GetLogErroById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<LogErro> GetAllLogErro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from LogErro ");
                    if(join)
                    {
                            strGetAll.Append(@" join SubMenu on LGE_SubMenuId = SBM_Id ");
                                  
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where LGE_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<LogErro> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<LogErro,    SubMenu,           LogErro>(newStrGetAll.ToString(),
                        //    (objLogErro,     objSubMenu,          ) => {
                        //            objLogErro.SubMenu = objSubMenu;
                        //                  
                        //        return objLogErro;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"    SBM_Id,          ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<LogErro>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllLogErro", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogErroRepository", "GetAllLogErro", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<LogErro> GetAllLogErroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from LogErro ");
                         
                    if(join)
                    {
                            strGetAll.Append(@" join SubMenu on LGE_SubMenuId = SBM_Id ");
                                  
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and LGE_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<LogErro> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<LogErro,    SubMenu,           LogErro>(newStrGetAll.ToString(),
                        //    (objLogErro,     objSubMenu,          ) => {
                        //            objLogErro.SubMenu = objSubMenu;
                        //                  
                        //        return objLogErro;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:"    SBM_Id,          ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<LogErro>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllLogErroByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogErroRepository", "GetAllLogErroByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<LogErro> GetAllLogErroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from LogErro ");
                    
                    if(join)
                    {
                            strGetAll.Append(@" join SubMenu on LGE_SubMenuId = SBM_Id ");
                                  
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and LGE_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<LogErro> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<LogErro,    SubMenu,           LogErro>(newStrGetAll.ToString(),
                        //    (objLogErro,     objSubMenu,          ) => {
                        //            objLogErro.SubMenu = objSubMenu;
                        //                  
                        //        return objLogErro;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:"    SBM_Id,          ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<LogErro>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllLogErroByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogErroRepository", "GetAllLogErroByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
