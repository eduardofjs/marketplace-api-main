
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
    public class TipoProdutoRepository : RepositoryBase, ITipoProdutoRepository
    {

        public TipoProduto InsertTipoProduto(TipoProduto objTipoProduto)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [TipoProduto] ");
                    strInsert.Append("(TPR_Descricao, TPR_FlagAtivo,TPR_DescricaoIngles,TPR_PathUrl,TPR_PathUrlOferta)");
                    strInsert.Append(@" VALUES (@TPR_Descricao, @TPR_FlagAtivo,@TPR_DescricaoIngles,@TPR_PathUrl,@TPR_PathUrlOferta);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TPR_Descricao = objTipoProduto.TPR_Descricao,
                            TPR_FlagAtivo = objTipoProduto.TPR_FlagAtivo,
                            TPR_DescricaoIngles = objTipoProduto.TPR_DescricaoIngles,
                            TPR_PathUrl = objTipoProduto.TPR_PathUrl,
                            TPR_PathUrlOferta = objTipoProduto.TPR_PathUrlOferta
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTipoProduto.TPR_Id = queryInsert.First();

                    salvaLog(objTipoProduto.Log, "", "InsertTipoProduto", strInsert.ToString());
                    return objTipoProduto;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objTipoProduto.Log, "TipoProdutoRepository", "InsertTipoProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTipoProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TipoProduto();
            }
        }


        public bool UpdateTipoProduto(TipoProduto objTipoProduto)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [TipoProduto] ");
                    strUpdate.Append(@" SET TPR_Descricao = @TPR_Descricao
                        , TPR_FlagAtivo = @TPR_FlagAtivo
                        , TPR_DescricaoIngles = @TPR_DescricaoIngles
                        , TPR_PathUrl = @TPR_PathUrl
                        , TPR_PathUrlOferta = @TPR_PathUrlOferta
                         where TPR_Id = @TPR_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TPR_Descricao = objTipoProduto.TPR_Descricao,
                            TPR_FlagAtivo = objTipoProduto.TPR_FlagAtivo,
                            TPR_DescricaoIngles = objTipoProduto.TPR_DescricaoIngles,
                            TPR_PathUrl = objTipoProduto.TPR_PathUrl,
                            TPR_PathUrlOferta = objTipoProduto.TPR_PathUrlOferta,
                            TPR_Id = objTipoProduto.TPR_Id
                        });
                }
                salvaLog(objTipoProduto.Log, "", "UpdateTipoProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(objTipoProduto.Log, "TipoProdutoRepository", "UpdateTipoProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objTipoProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarTipoProduto(int TPR_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoProduto] set ");
                    strUpdate.Append(" TPR_FlagAtivo = @TPR_FlagAtivo ");
                    strUpdate.Append(" where TPR_Id = @TPR_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TPR_FlagAtivo = 1,
                            TPR_Id = TPR_Id
                        });
                }
                salvaLog(null, "", "AtivarTipoProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoProdutoRepository", "AtivarTipoProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTipoProduto(int TPR_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoProduto] set ");
                    strUpdate.Append(" TPR_FlagAtivo = @TPR_FlagAtivo ");
                    strUpdate.Append(" where TPR_Id = @TPR_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TPR_FlagAtivo = 0,
                            TPR_Id = TPR_Id
                        });
                }
                salvaLog(null, "", "DeletarTipoProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoProdutoRepository", "DeletarTipoProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TipoProduto GetTipoProdutoById(int TPR_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT TPR_Id, TPR_Descricao, TPR_FlagAtivo, TPR_DescricaoIngles, TPR_PathUrl, TPR_PathUrlOferta from [TipoProduto] ");
                    strGet.Append(" where TPR_Id = @TPR_Id"); 

                    var obj = _db.Query<TipoProduto>(strGet.ToString(), new { TPR_Id = TPR_Id }).FirstOrDefault();

                    
                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(obj.TPR_PathUrl))
                            obj.TPR_PathUrl = ReadString("CGL_UrlImagem") + obj.TPR_PathUrl.Replace("\\", "/");
                        if (!string.IsNullOrEmpty(obj.TPR_PathUrlOferta))
                            obj.TPR_PathUrlOferta = ReadString("CGL_UrlImagem") + obj.TPR_PathUrlOferta.Replace("\\", "/");
                    }

                    salvaLog(null, "", "GetTipoProdutoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoProdutoRepository", "GetTipoProdutoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoProduto> GetAllTipoProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " TPR_Id, TPR_Descricao, TPR_FlagAtivo, TPR_DescricaoIngles, TPR_PathUrl, TPR_PathUrlOferta from [TipoProduto] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TPR_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<TipoProduto>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    
                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.TPR_PathUrl))
                                item.TPR_PathUrl = ReadString("CGL_UrlImagem") + item.TPR_PathUrl.Replace("\\", "/");
                            if (!string.IsNullOrEmpty(item.TPR_PathUrlOferta))
                                item.TPR_PathUrlOferta = ReadString("CGL_UrlImagem") + item.TPR_PathUrlOferta.Replace("\\", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllTipoProduto", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoProdutoRepository", "GetAllTipoProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoProduto> GetAllTipoProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  TPR_Id, TPR_Descricao, TPR_FlagAtivo, TPR_DescricaoIngles, TPR_PathUrl, TPR_PathUrlOferta from [TipoProduto] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TPR_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<TipoProduto>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.TPR_PathUrl))
                                item.TPR_PathUrl = ReadString("CGL_UrlImagem") + item.TPR_PathUrl.Replace("\\", "/");
                            if (!string.IsNullOrEmpty(item.TPR_PathUrlOferta))
                                item.TPR_PathUrlOferta = ReadString("CGL_UrlImagem") + item.TPR_PathUrlOferta.Replace("\\", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllTipoProdutoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoProdutoRepository", "GetAllTipoProdutoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TipoProduto> GetAllTipoProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " TPR_Id, TPR_Descricao, TPR_FlagAtivo, TPR_DescricaoIngles, TPR_PathUrl, TPR_PathUrlOferta from [TipoProduto] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TPR_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<TipoProduto>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.TPR_PathUrl))
                                item.TPR_PathUrl = ReadString("CGL_UrlImagem") + item.TPR_PathUrl.Replace("\\", "/");
                            if (!string.IsNullOrEmpty(item.TPR_PathUrlOferta))
                                item.TPR_PathUrlOferta = ReadString("CGL_UrlImagem") + item.TPR_PathUrlOferta.Replace("\\", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllTipoProdutoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoProdutoRepository", "GetAllTipoProdutoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
