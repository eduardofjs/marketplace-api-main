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
    public class StatusNegociacaoRepository : RepositoryBase, IStatusNegociacaoRepository
    {

        public StatusNegociacao InsertStatusNegociacao(StatusNegociacao objStatusNegociacao)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [StatusNegociacao] ");
                    strInsert.Append("(STN_Nome, STN_Descricao, STN_FlagAtivo, STN_Peso)");
                    strInsert.Append(@" VALUES (@STN_Nome, @STN_Descricao, @STN_FlagAtivo, @STN_Peso);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            STN_Nome = objStatusNegociacao.STN_Nome,
                            STN_Descricao = objStatusNegociacao.STN_Descricao,
                            STN_Peso = objStatusNegociacao.STN_Peso,
                            STN_FlagAtivo = 1,

                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objStatusNegociacao.STN_Id = queryInsert.First();

                    salvaLog(objStatusNegociacao.Log, "", "InsertStatusNegociacao", strInsert.ToString());
                    return objStatusNegociacao;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objStatusNegociacao.Log, "StatusNegociacaoRepository", "InsertStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objStatusNegociacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new StatusNegociacao();
            }
        }


        public bool UpdateStatusNegociacao(StatusNegociacao objStatusNegociacao)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [StatusNegociacao] ");
                    strUpdate.Append(@" SET STN_Nome = @STN_Nome
                        , STN_Descricao = @STN_Descricao
                        , STN_FlagAtivo = @STN_FlagAtivo
                        , STN_Peso = @STN_Peso
                         where STN_Id = @STN_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               STN_Nome = objStatusNegociacao.STN_Nome,
                               STN_Descricao = objStatusNegociacao.STN_Descricao,
                               STN_FlagAtivo = 1,
                               STN_Peso = objStatusNegociacao.STN_Peso,
                               STN_Id = objStatusNegociacao.STN_Id
                           });
                }
                salvaLog(objStatusNegociacao.Log, "", "UpdateStatusNegociacao", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objStatusNegociacao.Log, "StatusNegociacaoRepository", "UpdateStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objStatusNegociacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarStatusNegociacao(int STN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [StatusNegociacao] set ");
                    strUpdate.Append(" STN_FlagAtivo = @STN_FlagAtivo ");
                    strUpdate.Append(" where STN_Id = @STN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            STN_FlagAtivo = 1,
                                            STN_Id = STN_Id
                                        });
                }
                salvaLog(null, "", "AtivarStatusNegociacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusNegociacaoRepository", "AtivarStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarStatusNegociacao(int STN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [StatusNegociacao] set ");
                    strUpdate.Append(" STN_FlagAtivo = @STN_FlagAtivo ");
                    strUpdate.Append(" where STN_Id = @STN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            STN_FlagAtivo = 0,
                                            STN_Id = STN_Id
                                        });
                }
                salvaLog(null, "", "DeletarStatusNegociacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusNegociacaoRepository", "DeletarStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public StatusNegociacao GetStatusNegociacaoById(int STN_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT STN_Id, STN_Nome, STN_Descricao, STN_FlagAtivo, STN_Peso from [StatusNegociacao] ");
                    strGet.Append(" where STN_Id = @STN_Id");

                    var obj = _db.Query<StatusNegociacao>(strGet.ToString(), new { STN_Id = STN_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetStatusNegociacaoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusNegociacaoRepository", "GetStatusNegociacaoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<StatusNegociacao> GetAllStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [StatusNegociacao] ");
                    if (join)
                    {

                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where STN_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<StatusNegociacao> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<StatusNegociacao,   StatusNegociacao>(newStrGetAll.ToString(),
                    //        (objStatusNegociacao,    ) => {

                    //            return objStatusNegociacao;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<StatusNegociacao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    lista = _db.Query<StatusNegociacao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    salvaLog(null, "", "GetAllStatusNegociacao", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusNegociacaoRepository", "GetAllStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<StatusNegociacao> GetAllStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [StatusNegociacao] ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and STN_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<StatusNegociacao> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<StatusNegociacao,   StatusNegociacao>(newStrGetAll.ToString(),
                    //        (objStatusNegociacao,    ) => {

                    //            return objStatusNegociacao;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<StatusNegociacao>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}

                    lista = _db.Query<StatusNegociacao>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllStatusNegociacaoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusNegociacaoRepository", "GetAllStatusNegociacaoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<StatusNegociacao> GetAllStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [StatusNegociacao] ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and STN_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<StatusNegociacao> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<StatusNegociacao,   StatusNegociacao>(newStrGetAll.ToString(),
                    //        (objStatusNegociacao,    ) => {

                    //            return objStatusNegociacao;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<StatusNegociacao>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<StatusNegociacao>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllStatusNegociacaoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusNegociacaoRepository", "GetAllStatusNegociacaoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
