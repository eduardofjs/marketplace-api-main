
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
    public class TipoTransacaoLogRepository : RepositoryBase, ITipoTransacaoLogRepository
    {
        
        public TipoTransacaoLog InsertTipoTransacaoLog(TipoTransacaoLog objTipoTransacaoLog)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [TipoTransacaoLog] ");
                    strInsert.Append("(TTL_Nome, TTL_Descricao, TTL_Ativo)");
                    strInsert.Append(@" VALUES (@TTL_Nome, @TTL_Descricao, @TTL_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TTL_Nome = objTipoTransacaoLog.TTL_Nome,
                            TTL_Descricao = objTipoTransacaoLog.TTL_Descricao,
                            TTL_Ativo = objTipoTransacaoLog.TTL_Ativo,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTipoTransacaoLog.TTL_Id = queryInsert.First();

                    salvaLog(objTipoTransacaoLog.Log, "", "InsertTipoTransacaoLog", strInsert.ToString());
                    return objTipoTransacaoLog;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objTipoTransacaoLog.Log, "TipoTransacaoLogRepository", "InsertTipoTransacaoLog", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTipoTransacaoLog.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TipoTransacaoLog();
            }
        }


        public bool UpdateTipoTransacaoLog(TipoTransacaoLog objTipoTransacaoLog)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [TipoTransacaoLog] ");
                    strUpdate.Append(@" SET TTL_Nome = @TTL_Nome
                        , TTL_Descricao = @TTL_Descricao
                        , TTL_Ativo = @TTL_Ativo
                         where TTL_Id = @TTL_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            TTL_Nome = objTipoTransacaoLog.TTL_Nome,
                            TTL_Descricao = objTipoTransacaoLog.TTL_Descricao,
                            TTL_Ativo = objTipoTransacaoLog.TTL_Ativo,
                            
                            TTL_Id = objTipoTransacaoLog.TTL_Id                            
                           });
                }
                salvaLog(objTipoTransacaoLog.Log, "", "UpdateTipoTransacaoLog", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objTipoTransacaoLog.Log, "TipoTransacaoLogRepository", "UpdateTipoTransacaoLog", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objTipoTransacaoLog.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarTipoTransacaoLog(int TTL_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoTransacaoLog] set ");
                    strUpdate.Append(" TTL_Ativo = @TTL_Ativo ");
                    strUpdate.Append(" where TTL_Id = @TTL_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TTL_Ativo = 1,
                                            TTL_Id = TTL_Id
                                        });
                }
                salvaLog(null, "", "AtivarTipoTransacaoLog", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoTransacaoLogRepository", "AtivarTipoTransacaoLog", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTipoTransacaoLog(int TTL_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoTransacaoLog] set ");
                    strUpdate.Append(" TTL_Ativo = @TTL_Ativo ");
                    strUpdate.Append(" where TTL_Id = @TTL_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TTL_Ativo = 0,
                                            TTL_Id = TTL_Id
                                        });
                }
                salvaLog(null, "", "DeletarTipoTransacaoLog", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoTransacaoLogRepository", "DeletarTipoTransacaoLog", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TipoTransacaoLog GetTipoTransacaoLogById(int TTL_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT TTL_Id, TTL_Nome, TTL_Descricao, TTL_Ativo from [TipoTransacaoLog] ");
                    strGet.Append(" where TTL_Id = @TTL_Id");

                    var obj = _db.Query<TipoTransacaoLog>(strGet.ToString(), new { TTL_Id = TTL_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                                  
                    }

                    salvaLog(null, "", "GetTipoTransacaoLogById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoTransacaoLogRepository", "GetTipoTransacaoLogById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLog(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" TTL_Id, TTL_Nome, TTL_Descricao, TTL_Ativo from [TipoTransacaoLog] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TTL_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<TipoTransacaoLog>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    
                    if(lista != null && lista.Count() > 0 && join){
                        foreach(var obj in lista){                          
                                                              
                        }
                    }
                    salvaLog(null, "", "GetAllTipoTransacaoLog", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoTransacaoLogRepository", "GetAllTipoTransacaoLog", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLogByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +"  TTL_Id, TTL_Nome, TTL_Descricao, TTL_Ativo from [TipoTransacaoLog] ");
                    
                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TTL_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<TipoTransacaoLog>(newStrGetAll.ToString(), 
                        new { 
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                             }).AsEnumerable();
                    
                    if(lista != null && lista.Count() > 0 && join){
                        foreach(var obj in lista){                          
                                                              
                        }
                    }
                    salvaLog(null, "", "GetAllTipoTransacaoLogByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoTransacaoLogRepository", "GetAllTipoTransacaoLogByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TipoTransacaoLog> GetAllTipoTransacaoLogByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" TTL_Id, TTL_Nome, TTL_Descricao, TTL_Ativo from [TipoTransacaoLog] ");
                    
                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TTL_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<TipoTransacaoLog>(newStrGetAll.ToString(), 
                        new { 
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if(lista != null && lista.Count() > 0 && join){
                        foreach(var obj in lista){                          
                                  
                        }
                    }
                    salvaLog(null, "", "GetAllTipoTransacaoLogByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoTransacaoLogRepository", "GetAllTipoTransacaoLogByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
