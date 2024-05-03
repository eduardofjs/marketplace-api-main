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
    public class ServicoFinanceiroRepository : RepositoryBase, IServicoFinanceiroRepository
    {

        public ServicoFinanceiro InsertServicoFinanceiro(ServicoFinanceiro objServicoFinanceiro)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [ServicoFinanceiro] ");
                    strInsert.Append("(SEF_Nome,SEF_FlagAtivo)");
                    strInsert.Append(@" VALUES (@SEF_Nome,@SEF_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            SEF_Nome = objServicoFinanceiro.SEF_Nome,
                            SEF_FlagAtivo = objServicoFinanceiro.SEF_FlagAtivo,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objServicoFinanceiro.SEF_Id = queryInsert.First();

                    salvaLog(objServicoFinanceiro.Log, "", "InsertServicoFinanceiro", strInsert.ToString());
                    return objServicoFinanceiro;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objServicoFinanceiro.Log, "ServicoFinanceiroRepository", "InsertServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objServicoFinanceiro.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new ServicoFinanceiro();
            }
        }


        public bool UpdateServicoFinanceiro(ServicoFinanceiro objServicoFinanceiro)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [ServicoFinanceiro] ");
                    strUpdate.Append(@" SET SEF_Nome = @SEF_Nome
                        , SEF_FlagAtivo = @SEF_FlagAtivo
                         where SEF_Id = @SEF_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               SEF_Nome = objServicoFinanceiro.SEF_Nome,
                               SEF_FlagAtivo = objServicoFinanceiro.SEF_FlagAtivo,
                               SEF_Id = objServicoFinanceiro.SEF_Id
                           });
                }
                salvaLog(objServicoFinanceiro.Log, "", "UpdateServicoFinanceiro", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objServicoFinanceiro.Log, "ServicoFinanceiroRepository", "UpdateServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objServicoFinanceiro.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarServicoFinanceiro(int SEF_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [ServicoFinanceiro] set ");
                    strUpdate.Append(" SEF_FlagAtivo = @SEF_FlagAtivo ");
                    strUpdate.Append(" where SEF_Id = @SEF_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SEF_FlagAtivo = 1,
                                            SEF_Id = SEF_Id
                                        });
                }
                salvaLog(null, "", "AtivarServicoFinanceiro", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoFinanceiroRepository", "AtivarServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarServicoFinanceiro(int SEF_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [ServicoFinanceiro] set ");
                    strUpdate.Append(" SEF_FlagAtivo = @SEF_FlagAtivo ");
                    strUpdate.Append(" where SEF_Id = @SEF_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SEF_FlagAtivo = 0,
                                            SEF_Id = SEF_Id
                                        });
                }
                salvaLog(null, "", "DeletarServicoFinanceiro", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoFinanceiroRepository", "DeletarServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public ServicoFinanceiro GetServicoFinanceiroById(int SEF_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [ServicoFinanceiro] ");
                    strGet.Append(" where SEF_Id = @SEF_Id");

                    var obj = _db.Query<ServicoFinanceiro>(strGet.ToString(), new { SEF_Id = SEF_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetServicoFinanceiroById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoFinanceiroRepository", "GetServicoFinanceiroById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [ServicoFinanceiro] ");
                    if (join)
                    {

                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where SEF_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<ServicoFinanceiro> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<ServicoFinanceiro,   ServicoFinanceiro>(newStrGetAll.ToString(),
                    //        (objServicoFinanceiro,    ) => {

                    //            return objServicoFinanceiro;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<ServicoFinanceiro>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    lista = _db.Query<ServicoFinanceiro>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    salvaLog(null, "", "GetAllServicoFinanceiro", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoFinanceiroRepository", "GetAllServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [ServicoFinanceiro] ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SEF_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<ServicoFinanceiro> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<ServicoFinanceiro,   ServicoFinanceiro>(newStrGetAll.ToString(),
                    //        (objServicoFinanceiro,    ) => {

                    //            return objServicoFinanceiro;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<ServicoFinanceiro>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}

                    lista = _db.Query<ServicoFinanceiro>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllServicoFinanceiroByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoFinanceiroRepository", "GetAllServicoFinanceiroByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<ServicoFinanceiro> GetAllServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [ServicoFinanceiro] ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SEF_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<ServicoFinanceiro> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<ServicoFinanceiro,   ServicoFinanceiro>(newStrGetAll.ToString(),
                    //        (objServicoFinanceiro,    ) => {

                    //            return objServicoFinanceiro;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<ServicoFinanceiro>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<ServicoFinanceiro>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllServicoFinanceiroByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoFinanceiroRepository", "GetAllServicoFinanceiroByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}

