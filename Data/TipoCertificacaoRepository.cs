
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
    public class TipoCertificacaoRepository : RepositoryBase, ITipoCertificacaoRepository
    {

        public TipoCertificacao InsertTipoCertificacao(TipoCertificacao objTipoCertificacao)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [TipoCertificacao] ");
                    strInsert.Append("(TPC_Descricao, TPC_FlagAtivo,TPC_DescricaoIngles)");
                    strInsert.Append(@" VALUES (@TPC_Descricao, @TPC_FlagAtivo,@TPC_DescricaoIngles);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TPC_Descricao = objTipoCertificacao.TPC_Descricao,
                            TPC_FlagAtivo = objTipoCertificacao.TPC_FlagAtivo,
                            TPC_DescricaoIngles = objTipoCertificacao.TPC_DescricaoIngles,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTipoCertificacao.TPC_Id = queryInsert.First();

                    salvaLog(objTipoCertificacao.Log, "", "InsertTipoCertificacao", strInsert.ToString());
                    return objTipoCertificacao;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objTipoCertificacao.Log, "TipoCertificacaoRepository", "InsertTipoCertificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTipoCertificacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TipoCertificacao();
            }
        }


        public bool UpdateTipoCertificacao(TipoCertificacao objTipoCertificacao)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [TipoCertificacao] ");
                    strUpdate.Append(@" SET TPC_Descricao = @TPC_Descricao
                        , TPC_FlagAtivo = @TPC_FlagAtivo
                        , TPC_DescricaoIngles = @TPC_DescricaoIngles
                         where TPC_Id = @TPC_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TPC_Descricao = objTipoCertificacao.TPC_Descricao,
                            TPC_FlagAtivo = objTipoCertificacao.TPC_FlagAtivo,
                            TPC_DescricaoIngles = objTipoCertificacao.TPC_DescricaoIngles,
                            TPC_Id = objTipoCertificacao.TPC_Id
                        });
                }
                salvaLog(objTipoCertificacao.Log, "", "UpdateTipoCertificacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(objTipoCertificacao.Log, "TipoCertificacaoRepository", "UpdateTipoCertificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objTipoCertificacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarTipoCertificacao(int TPC_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoCertificacao] set ");
                    strUpdate.Append(" TPC_FlagAtivo = @TPC_FlagAtivo ");
                    strUpdate.Append(" where TPC_Id = @TPC_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TPC_FlagAtivo = 1,
                            TPC_Id = TPC_Id
                        });
                }
                salvaLog(null, "", "AtivarTipoCertificacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoCertificacaoRepository", "AtivarTipoCertificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTipoCertificacao(int TPC_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoCertificacao] set ");
                    strUpdate.Append(" TPC_FlagAtivo = @TPC_FlagAtivo ");
                    strUpdate.Append(" where TPC_Id = @TPC_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TPC_FlagAtivo = 0,
                            TPC_Id = TPC_Id
                        });
                }
                salvaLog(null, "", "DeletarTipoCertificacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoCertificacaoRepository", "DeletarTipoCertificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TipoCertificacao GetTipoCertificacaoById(int TPC_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT TPC_Id, TPC_Descricao, TPC_FlagAtivo, TPC_DescricaoIngles from [TipoCertificacao] ");
                    strGet.Append(" where TPC_Id = @TPC_Id");

                    var obj = _db.Query<TipoCertificacao>(strGet.ToString(), new { TPC_Id = TPC_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetTipoCertificacaoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoCertificacaoRepository", "GetTipoCertificacaoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoCertificacao> GetAllTipoCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " TPC_Id, TPC_Descricao, TPC_FlagAtivo, TPC_DescricaoIngles from [TipoCertificacao] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TPC_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<TipoCertificacao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllTipoCertificacao", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoCertificacaoRepository", "GetAllTipoCertificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoCertificacao> GetAllTipoCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  TPC_Id, TPC_Descricao, TPC_FlagAtivo, TPC_DescricaoIngles from [TipoCertificacao] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TPC_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<TipoCertificacao>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllTipoCertificacaoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoCertificacaoRepository", "GetAllTipoCertificacaoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TipoCertificacao> GetAllTipoCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " TPC_Id, TPC_Descricao, TPC_FlagAtivo, TPC_DescricaoIngles from [TipoCertificacao] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TPC_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<TipoCertificacao>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllTipoCertificacaoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoCertificacaoRepository", "GetAllTipoCertificacaoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
