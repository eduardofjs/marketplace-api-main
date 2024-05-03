
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
    public class StatusProdutoRepository : RepositoryBase, IStatusProdutoRepository
    {

        public StatusProduto InsertStatusProduto(StatusProduto objStatusProduto)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [StatusProduto] ");
                    strInsert.Append("(SPR_Descricao, SPR_FlagAtivo,SPR_DescricaoIngles)");
                    strInsert.Append(@" VALUES (@SPR_Descricao, @SPR_FlagAtivo,@SPR_DescricaoIngles);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            SPR_Descricao = objStatusProduto.SPR_Descricao,
                            SPR_FlagAtivo = objStatusProduto.SPR_FlagAtivo,
                            SPR_DescricaoIngles = objStatusProduto.SPR_DescricaoIngles,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objStatusProduto.SPR_Id = queryInsert.First();

                    salvaLog(objStatusProduto.Log, "", "InsertStatusProduto", strInsert.ToString());
                    return objStatusProduto;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objStatusProduto.Log, "StatusProdutoRepository", "InsertStatusProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objStatusProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new StatusProduto();
            }
        }


        public bool UpdateStatusProduto(StatusProduto objStatusProduto)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [StatusProduto] ");
                    strUpdate.Append(@" SET SPR_Descricao = @SPR_Descricao
                        , SPR_FlagAtivo = @SPR_FlagAtivo
                        , SPR_DescricaoIngles = @SPR_DescricaoIngles
                         where SPR_Id = @SPR_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            SPR_Descricao = objStatusProduto.SPR_Descricao,
                            SPR_FlagAtivo = objStatusProduto.SPR_FlagAtivo,
                            SPR_DescricaoIngles = objStatusProduto.SPR_DescricaoIngles,
                            SPR_Id = objStatusProduto.SPR_Id
                        });
                }
                salvaLog(objStatusProduto.Log, "", "UpdateStatusProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(objStatusProduto.Log, "StatusProdutoRepository", "UpdateStatusProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objStatusProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarStatusProduto(int SPR_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [StatusProduto] set ");
                    strUpdate.Append(" SPR_FlagAtivo = @SPR_FlagAtivo ");
                    strUpdate.Append(" where SPR_Id = @SPR_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            SPR_FlagAtivo = 1,
                            SPR_Id = SPR_Id
                        });
                }
                salvaLog(null, "", "AtivarStatusProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusProdutoRepository", "AtivarStatusProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarStatusProduto(int SPR_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [StatusProduto] set ");
                    strUpdate.Append(" SPR_FlagAtivo = @SPR_FlagAtivo ");
                    strUpdate.Append(" where SPR_Id = @SPR_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            SPR_FlagAtivo = 0,
                            SPR_Id = SPR_Id
                        });
                }
                salvaLog(null, "", "DeletarStatusProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusProdutoRepository", "DeletarStatusProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public StatusProduto GetStatusProdutoById(int SPR_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT SPR_Id, SPR_Descricao, SPR_FlagAtivo, SPR_DescricaoIngles from [StatusProduto] ");
                    strGet.Append(" where SPR_Id = @SPR_Id");

                    var obj = _db.Query<StatusProduto>(strGet.ToString(), new { SPR_Id = SPR_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetStatusProdutoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusProdutoRepository", "GetStatusProdutoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<StatusProduto> GetAllStatusProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " SPR_Id, SPR_Descricao, SPR_FlagAtivo, SPR_DescricaoIngles from [StatusProduto] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where SPR_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<StatusProduto>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllStatusProduto", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusProdutoRepository", "GetAllStatusProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<StatusProduto> GetAllStatusProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  SPR_Id, SPR_Descricao, SPR_FlagAtivo, SPR_DescricaoIngles from [StatusProduto] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SPR_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<StatusProduto>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllStatusProdutoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusProdutoRepository", "GetAllStatusProdutoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<StatusProduto> GetAllStatusProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " SPR_Id, SPR_Descricao, SPR_FlagAtivo, SPR_DescricaoIngles from [StatusProduto] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SPR_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<StatusProduto>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllStatusProdutoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusProdutoRepository", "GetAllStatusProdutoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
