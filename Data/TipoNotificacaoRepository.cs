
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
    public class TipoNotificacaoRepository : RepositoryBase, ITipoNotificacaoRepository
    {
        
        public TipoNotificacao InsertTipoNotificacao(TipoNotificacao objTipoNotificacao)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [TipoNotificacao] ");
                    strInsert.Append("(TPN_Nome, TPN_Ativo, TPN_Controller, TPN_Cor, TPN_IconPath)");
                    strInsert.Append(@" VALUES (@TPN_Nome, @TPN_Ativo, @TPN_Controller, @TPN_Cor, @TPN_IconPath);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TPN_Nome = objTipoNotificacao.TPN_Nome,
                            TPN_Ativo = 1,
                            TPN_Controller = objTipoNotificacao.TPN_Controller,
                            TPN_Cor = objTipoNotificacao.TPN_Cor,
                            TPN_IconPath = objTipoNotificacao.TPN_IconPath,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTipoNotificacao.TPN_Id = queryInsert.First();

                    salvaLog(objTipoNotificacao.Log, "", "InsertTipoNotificacao", strInsert.ToString());
                    return objTipoNotificacao;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objTipoNotificacao.Log, "TipoNotificacaoRepository", "InsertTipoNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTipoNotificacao.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TipoNotificacao();
            }
        }


        public bool UpdateTipoNotificacao(TipoNotificacao objTipoNotificacao)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [TipoNotificacao] ");
                    strUpdate.Append(@" SET TPN_Nome = @TPN_Nome
                        , TPN_Ativo = @TPN_Ativo
                        , TPN_Controller = @TPN_Controller
                        , TPN_Cor = @TPN_Cor
                        , TPN_IconPath = @TPN_IconPath
                         where TPN_Id = @TPN_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            TPN_Nome = objTipoNotificacao.TPN_Nome,
                            TPN_Ativo = 1,
                            TPN_Controller = objTipoNotificacao.TPN_Controller,
                            TPN_Cor = objTipoNotificacao.TPN_Cor,
                            TPN_IconPath = objTipoNotificacao.TPN_IconPath,
                            
                            TPN_Id = objTipoNotificacao.TPN_Id                            
                           });
                }
                salvaLog(objTipoNotificacao.Log, "", "UpdateTipoNotificacao", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objTipoNotificacao.Log, "TipoNotificacaoRepository", "UpdateTipoNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objTipoNotificacao.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarTipoNotificacao(int TPN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoNotificacao] set ");
                    strUpdate.Append(" TPN_Ativo = @TPN_Ativo ");
                    strUpdate.Append(" where TPN_Id = @TPN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TPN_Ativo = 1,
                                            TPN_Id = TPN_Id
                                        });
                }
                salvaLog(null, "", "AtivarTipoNotificacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoNotificacaoRepository", "AtivarTipoNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTipoNotificacao(int TPN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoNotificacao] set ");
                    strUpdate.Append(" TPN_Ativo = @TPN_Ativo ");
                    strUpdate.Append(" where TPN_Id = @TPN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TPN_Ativo = 0,
                                            TPN_Id = TPN_Id
                                        });
                }
                salvaLog(null, "", "DeletarTipoNotificacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoNotificacaoRepository", "DeletarTipoNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TipoNotificacao GetTipoNotificacaoById(int TPN_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT TPN_Id, TPN_Nome, TPN_Ativo, TPN_Controller, TPN_Cor, TPN_IconPath from [TipoNotificacao] ");
                    strGet.Append(" where TPN_Id = @TPN_Id");

                    var obj = _db.Query<TipoNotificacao>(strGet.ToString(), new { TPN_Id = TPN_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                                    
                    }

                    salvaLog(null, "", "GetTipoNotificacaoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoNotificacaoRepository", "GetTipoNotificacaoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoNotificacao> GetAllTipoNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [TipoNotificacao] ");
                    if(join)
                    {
                              
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TPN_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<TipoNotificacao> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<TipoNotificacao,      TipoNotificacao>(newStrGetAll.ToString(),
                    //        (objTipoNotificacao,       ) => {
                                      
                    //            return objTipoNotificacao;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "      ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<TipoNotificacao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}
                    lista = _db.Query<TipoNotificacao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    salvaLog(null, "", "GetAllTipoNotificacao", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoNotificacaoRepository", "GetAllTipoNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoNotificacao> GetAllTipoNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [TipoNotificacao] ");
                         
                    if(join)
                    {
                              
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TPN_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<TipoNotificacao> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<TipoNotificacao,      TipoNotificacao>(newStrGetAll.ToString(),
                    //        (objTipoNotificacao,       ) => {
                                      
                    //            return objTipoNotificacao;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "      ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<TipoNotificacao>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<TipoNotificacao>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    salvaLog(null, "", "GetAllTipoNotificacaoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoNotificacaoRepository", "GetAllTipoNotificacaoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TipoNotificacao> GetAllTipoNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [TipoNotificacao] ");
                    
                    if(join)
                    {
                              
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TPN_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<TipoNotificacao> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<TipoNotificacao,      TipoNotificacao>(newStrGetAll.ToString(),
                    //        (objTipoNotificacao,       ) => {
                                      
                    //            return objTipoNotificacao;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "      ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<TipoNotificacao>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<TipoNotificacao>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllTipoNotificacaoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoNotificacaoRepository", "GetAllTipoNotificacaoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
