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
    public class LogisticaRepository : RepositoryBase, ILogisticaRepository
    {

        public Logistica InsertLogistica(Logistica objLogistica)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Logistica] ");
                    strInsert.Append("(LGT_Nome,LGT_FlagAtivo)");
                    strInsert.Append(@" VALUES (@LGT_Nome,@LGT_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            LGT_Nome = objLogistica.LGT_Nome,
                            LGT_FlagAtivo = objLogistica.LGT_FlagAtivo,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objLogistica.LGT_Id = queryInsert.First();

                    salvaLog(objLogistica.Log, "", "InsertLogistica", strInsert.ToString());
                    return objLogistica;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objLogistica.Log, "LogisticaRepository", "InsertLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objLogistica.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Logistica();
            }
        }


        public bool UpdateLogistica(Logistica objLogistica)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Logistica] ");
                    strUpdate.Append(@" SET LGT_Nome = @LGT_Nome
                        , LGT_FlagAtivo = @LGT_FlagAtivo
                         where LGT_Id = @LGT_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               LGT_Nome = objLogistica.LGT_Nome,
                               LGT_FlagAtivo = objLogistica.LGT_FlagAtivo,
                               LGT_Id = objLogistica.LGT_Id
                           });
                }
                salvaLog(objLogistica.Log, "", "UpdateLogistica", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objLogistica.Log, "LogisticaRepository", "UpdateLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objLogistica.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarLogistica(int LGT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Logistica] set ");
                    strUpdate.Append(" LGT_FlagAtivo = @LGT_FlagAtivo ");
                    strUpdate.Append(" where LGT_Id = @LGT_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            LGT_FlagAtivo = 1,
                                            LGT_Id = LGT_Id
                                        });
                }
                salvaLog(null, "", "AtivarLogistica", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogisticaRepository", "AtivarLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarLogistica(int LGT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Logistica] set ");
                    strUpdate.Append(" LGT_FlagAtivo = @LGT_FlagAtivo ");
                    strUpdate.Append(" where LGT_Id = @LGT_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            LGT_FlagAtivo = 0,
                                            LGT_Id = LGT_Id
                                        });
                }
                salvaLog(null, "", "DeletarLogistica", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogisticaRepository", "DeletarLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Logistica GetLogisticaById(int LGT_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [Logistica] ");
                    strGet.Append(" where LGT_Id = @LGT_Id");

                    var obj = _db.Query<Logistica>(strGet.ToString(), new { LGT_Id = LGT_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetLogisticaById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogisticaRepository", "GetLogisticaById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Logistica> GetAllLogistica(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Logistica] ");
                    if (join)
                    {

                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where LGT_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<Logistica> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Logistica,   Logistica>(newStrGetAll.ToString(),
                    //        (objLogistica,    ) => {

                    //            return objLogistica;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Logistica>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    lista = _db.Query<Logistica>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    salvaLog(null, "", "GetAllLogistica", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogisticaRepository", "GetAllLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Logistica> GetAllLogisticaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Logistica] ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and LGT_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Logistica> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Logistica,   Logistica>(newStrGetAll.ToString(),
                    //        (objLogistica,    ) => {

                    //            return objLogistica;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Logistica>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}

                    lista = _db.Query<Logistica>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllLogisticaByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogisticaRepository", "GetAllLogisticaByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Logistica> GetAllLogisticaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Logistica] ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and LGT_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Logistica> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Logistica,   Logistica>(newStrGetAll.ToString(),
                    //        (objLogistica,    ) => {

                    //            return objLogistica;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Logistica>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<Logistica>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllLogisticaByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "LogisticaRepository", "GetAllLogisticaByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}

