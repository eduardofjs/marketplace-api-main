
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
    public class TipoServicoAdicionalRepository : RepositoryBase, ITipoServicoAdicionalRepository
    {

        public TipoServicoAdicional InsertTipoServicoAdicional(TipoServicoAdicional objTipoServicoAdicional)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [TipoServicoAdicional] ");
                    strInsert.Append("(TSA_Descricao, TSA_FlagAtivo, TSA_DescricaoIngles)");
                    strInsert.Append(@" VALUES (@TSA_Descricao, @TSA_FlagAtivo, @TSA_DescricaoIngles);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TSA_Descricao = objTipoServicoAdicional.TSA_Descricao,
                            TSA_FlagAtivo = objTipoServicoAdicional.TSA_FlagAtivo,
                            TSA_DescricaoIngles = objTipoServicoAdicional.TSA_DescricaoIngles,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTipoServicoAdicional.TSA_Id = queryInsert.First();

                    salvaLog(objTipoServicoAdicional.Log, "", "InsertTipoServicoAdicional", strInsert.ToString());
                    return objTipoServicoAdicional;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objTipoServicoAdicional.Log, "TipoServicoAdicionalRepository", "InsertTipoServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTipoServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TipoServicoAdicional();
            }
        }


        public bool UpdateTipoServicoAdicional(TipoServicoAdicional objTipoServicoAdicional)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [TipoServicoAdicional] ");
                    strUpdate.Append(@" SET TSA_Descricao = @TSA_Descricao
                        , TSA_FlagAtivo = @TSA_FlagAtivo
                        , TSA_DescricaoIngles = @TSA_DescricaoIngles
                         where TSA_Id = @TSA_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               TSA_Descricao = objTipoServicoAdicional.TSA_Descricao,
                               TSA_FlagAtivo = objTipoServicoAdicional.TSA_FlagAtivo,
                               TSA_DescricaoIngles = objTipoServicoAdicional.TSA_DescricaoIngles,
                               TSA_Id = objTipoServicoAdicional.TSA_Id
                           });
                }
                salvaLog(objTipoServicoAdicional.Log, "", "UpdateTipoServicoAdicional", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objTipoServicoAdicional.Log, "TipoServicoAdicionalRepository", "UpdateTipoServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objTipoServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarTipoServicoAdicional(int TSA_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoServicoAdicional] set ");
                    strUpdate.Append(" TSA_FlagAtivo = @TSA_FlagAtivo ");
                    strUpdate.Append(" where TSA_Id = @TSA_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TSA_FlagAtivo = 1,
                                            TSA_Id = TSA_Id
                                        });
                }
                salvaLog(null, "", "AtivarTipoServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoServicoAdicionalRepository", "AtivarTipoServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTipoServicoAdicional(int TSA_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoServicoAdicional] set ");
                    strUpdate.Append(" TSA_FlagAtivo = @TSA_FlagAtivo ");
                    strUpdate.Append(" where TSA_Id = @TSA_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TSA_FlagAtivo = 0,
                                            TSA_Id = TSA_Id
                                        });
                }
                salvaLog(null, "", "DeletarTipoServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoServicoAdicionalRepository", "DeletarTipoServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TipoServicoAdicional GetTipoServicoAdicionalById(int TSA_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT TSA_Id, TSA_Descricao, TSA_FlagAtivo, TSA_DescricaoIngles from [TipoServicoAdicional] ");
                    strGet.Append(" where TSA_Id = @TSA_Id");

                    var obj = _db.Query<TipoServicoAdicional>(strGet.ToString(), new { TSA_Id = TSA_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetTipoServicoAdicionalById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoServicoAdicionalRepository", "GetTipoServicoAdicionalById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " TSA_Id, TSA_Descricao, TSA_FlagAtivo, TSA_DescricaoIngles from [TipoServicoAdicional] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TSA_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<TipoServicoAdicional>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllTipoServicoAdicional", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoServicoAdicionalRepository", "GetAllTipoServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  TSA_Id, TSA_Descricao, TSA_FlagAtivo, TSA_DescricaoIngles from [TipoServicoAdicional] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TSA_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<TipoServicoAdicional>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllTipoServicoAdicionalByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoServicoAdicionalRepository", "GetAllTipoServicoAdicionalByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " TSA_Id, TSA_Descricao, TSA_FlagAtivo, TSA_DescricaoIngles from [TipoServicoAdicional] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TSA_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<TipoServicoAdicional>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllTipoServicoAdicionalByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoServicoAdicionalRepository", "GetAllTipoServicoAdicionalByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
