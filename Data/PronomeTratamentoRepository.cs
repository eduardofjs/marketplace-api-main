
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
    public class PronomeTratamentoRepository : RepositoryBase, IPronomeTratamentoRepository
    {
        
        public PronomeTratamento InsertPronomeTratamento(PronomeTratamento objPronomeTratamento)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [PronomeTratamento] ");
                    strInsert.Append("(PRT_Nome, PRT_Descricao, PRT_Ativo)");
                    strInsert.Append(@" VALUES (@PRT_Nome, @PRT_Descricao, @PRT_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            PRT_Nome = objPronomeTratamento.PRT_Nome,
                            PRT_Descricao = objPronomeTratamento.PRT_Descricao,
                            PRT_Ativo = 1,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objPronomeTratamento.PRT_Id = queryInsert.First();

                    salvaLog(objPronomeTratamento.Log, "", "InsertPronomeTratamento", strInsert.ToString());
                    return objPronomeTratamento;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objPronomeTratamento.Log, "PronomeTratamentoRepository", "InsertPronomeTratamento", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objPronomeTratamento.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new PronomeTratamento();
            }
        }


        public bool UpdatePronomeTratamento(PronomeTratamento objPronomeTratamento)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [PronomeTratamento] ");
                    strUpdate.Append(@" SET PRT_Nome = @PRT_Nome
                        , PRT_Descricao = @PRT_Descricao
                        , PRT_Ativo = @PRT_Ativo
                         where PRT_Id = @PRT_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            PRT_Nome = objPronomeTratamento.PRT_Nome,
                            PRT_Descricao = objPronomeTratamento.PRT_Descricao,
                            PRT_Ativo = 1,
                            
                            PRT_Id = objPronomeTratamento.PRT_Id                            
                           });
                }
                salvaLog(objPronomeTratamento.Log, "", "UpdatePronomeTratamento", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objPronomeTratamento.Log, "PronomeTratamentoRepository", "UpdatePronomeTratamento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objPronomeTratamento.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarPronomeTratamento(int PRT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [PronomeTratamento] set ");
                    strUpdate.Append(" PRT_Ativo = @PRT_Ativo ");
                    strUpdate.Append(" where PRT_Id = @PRT_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PRT_Ativo = 1,
                                            PRT_Id = PRT_Id
                                        });
                }
                salvaLog(null, "", "AtivarPronomeTratamento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PronomeTratamentoRepository", "AtivarPronomeTratamento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarPronomeTratamento(int PRT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [PronomeTratamento] set ");
                    strUpdate.Append(" PRT_Ativo = @PRT_Ativo ");
                    strUpdate.Append(" where PRT_Id = @PRT_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PRT_Ativo = 0,
                                            PRT_Id = PRT_Id
                                        });
                }
                salvaLog(null, "", "DeletarPronomeTratamento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PronomeTratamentoRepository", "DeletarPronomeTratamento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public PronomeTratamento GetPronomeTratamentoById(int PRT_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT PRT_Id, PRT_Nome, PRT_Descricao, PRT_Ativo from [PronomeTratamento] ");
                    strGet.Append(" where PRT_Id = @PRT_Id");

                    var obj = _db.Query<PronomeTratamento>(strGet.ToString(), new { PRT_Id = PRT_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                                  
                    }

                    salvaLog(null, "", "GetPronomeTratamentoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PronomeTratamentoRepository", "GetPronomeTratamentoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<PronomeTratamento> GetAllPronomeTratamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [PronomeTratamento] ");
                    if(join)
                    {
                            
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where PRT_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<PronomeTratamento> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<PronomeTratamento,    PronomeTratamento>(newStrGetAll.ToString(),
                    //        (objPronomeTratamento,     ) => {
                                    
                    //            return objPronomeTratamento;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "    ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<PronomeTratamento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    lista = _db.Query<PronomeTratamento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    salvaLog(null, "", "GetAllPronomeTratamento", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PronomeTratamentoRepository", "GetAllPronomeTratamento", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<PronomeTratamento> GetAllPronomeTratamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [PronomeTratamento] ");
                         
                    if(join)
                    {
                            
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PRT_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<PronomeTratamento> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<PronomeTratamento,    PronomeTratamento>(newStrGetAll.ToString(),
                    //        (objPronomeTratamento,     ) => {
                                    
                    //            return objPronomeTratamento;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "    ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<PronomeTratamento>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<PronomeTratamento>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    salvaLog(null, "", "GetAllPronomeTratamentoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PronomeTratamentoRepository", "GetAllPronomeTratamentoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<PronomeTratamento> GetAllPronomeTratamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [PronomeTratamento] ");
                    
                    if(join)
                    {
                            
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PRT_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<PronomeTratamento> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<PronomeTratamento,    PronomeTratamento>(newStrGetAll.ToString(),
                    //        (objPronomeTratamento,     ) => {
                                    
                    //            return objPronomeTratamento;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "    ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<PronomeTratamento>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<PronomeTratamento>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllPronomeTratamentoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PronomeTratamentoRepository", "GetAllPronomeTratamentoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
