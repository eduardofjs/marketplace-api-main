
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
    public class StatusPagamentoRepository : RepositoryBase, IStatusPagamentoRepository
    {
        
        public StatusPagamento InsertStatusPagamento(StatusPagamento objStatusPagamento)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [StatusPagamento] ");
                    strInsert.Append("(SPG_Nome, SPG_NomeIngles, SPG_Ativo)");
                    strInsert.Append(@" VALUES (@SPG_Nome, @SPG_NomeIngles, @SPG_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            SPG_Nome = objStatusPagamento.SPG_Nome,
                            SPG_NomeIngles = objStatusPagamento.SPG_NomeIngles,
                            SPG_Ativo = 1,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objStatusPagamento.SPG_Id = queryInsert.First();

                    salvaLog(objStatusPagamento.Log, "", "InsertStatusPagamento", strInsert.ToString());
                    return objStatusPagamento;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objStatusPagamento.Log, "StatusPagamentoRepository", "InsertStatusPagamento", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objStatusPagamento.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new StatusPagamento();
            }
        }


        public bool UpdateStatusPagamento(StatusPagamento objStatusPagamento)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [StatusPagamento] ");
                    strUpdate.Append(@" SET SPG_Nome = @SPG_Nome
                        , SPG_NomeIngles = @SPG_NomeIngles
                        , SPG_Ativo = @SPG_Ativo
                         where SPG_Id = @SPG_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                                SPG_Nome = objStatusPagamento.SPG_Nome,
                                SPG_NomeIngles = objStatusPagamento.SPG_NomeIngles,
                                SPG_Ativo = 1,
                            
                                SPG_Id = objStatusPagamento.SPG_Id                            
                           });
                }
                salvaLog(objStatusPagamento.Log, "", "UpdateStatusPagamento", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objStatusPagamento.Log, "StatusPagamentoRepository", "UpdateStatusPagamento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objStatusPagamento.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarStatusPagamento(int SPG_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [StatusPagamento] set ");
                    strUpdate.Append(" SPG_Ativo = @SPG_Ativo ");
                    strUpdate.Append(" where SPG_Id = @SPG_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SPG_Ativo = 1,
                                            SPG_Id = SPG_Id
                                        });
                }
                salvaLog(null, "", "AtivarStatusPagamento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusPagamentoRepository", "AtivarStatusPagamento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarStatusPagamento(int SPG_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [StatusPagamento] set ");
                    strUpdate.Append(" SPG_Ativo = @SPG_Ativo ");
                    strUpdate.Append(" where SPG_Id = @SPG_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SPG_Ativo = 0,
                                            SPG_Id = SPG_Id
                                        });
                }
                salvaLog(null, "", "DeletarStatusPagamento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusPagamentoRepository", "DeletarStatusPagamento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public StatusPagamento GetStatusPagamentoById(int SPG_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [StatusPagamento] ");
                    strGet.Append(" where SPG_Id = @SPG_Id");

                    var obj = _db.Query<StatusPagamento>(strGet.ToString(), new { SPG_Id = SPG_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                                 
                    }

                    salvaLog(null, "", "GetStatusPagamentoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusPagamentoRepository", "GetStatusPagamentoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<StatusPagamento> GetAllStatusPagamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [StatusPagamento] ");
                    if(join)
                    {
                           
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where SPG_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<StatusPagamento> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<StatusPagamento,   StatusPagamento>(newStrGetAll.ToString(),
                    //        (objStatusPagamento,    ) => {
                                   
                    //            return objStatusPagamento;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<StatusPagamento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    lista = _db.Query<StatusPagamento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    salvaLog(null, "", "GetAllStatusPagamento", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusPagamentoRepository", "GetAllStatusPagamento", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<StatusPagamento> GetAllStatusPagamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [StatusPagamento] ");
                         
                    if(join)
                    {
                           
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SPG_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<StatusPagamento> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<StatusPagamento,   StatusPagamento>(newStrGetAll.ToString(),
                    //        (objStatusPagamento,    ) => {
                                   
                    //            return objStatusPagamento;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<StatusPagamento>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}

                    lista = _db.Query<StatusPagamento>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllStatusPagamentoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusPagamentoRepository", "GetAllStatusPagamentoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<StatusPagamento> GetAllStatusPagamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [StatusPagamento] ");
                    
                    if(join)
                    {
                           
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SPG_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<StatusPagamento> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<StatusPagamento,   StatusPagamento>(newStrGetAll.ToString(),
                    //        (objStatusPagamento,    ) => {
                                   
                    //            return objStatusPagamento;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<StatusPagamento>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<StatusPagamento>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllStatusPagamentoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusPagamentoRepository", "GetAllStatusPagamentoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
