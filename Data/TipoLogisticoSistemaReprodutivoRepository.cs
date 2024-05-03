
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
    public class TipoLogisticoSistemaProdutivoRepository : RepositoryBase, ITipoLogisticoSistemaProdutivoRepository
    {

        public TipoLogisticoSistemaProdutivo InsertTipoLogisticoSistemaProdutivo(TipoLogisticoSistemaProdutivo objTipoLogisticoSistemaProdutivo)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [TipoLogisticoSistemaProdutivo] ");
                    strInsert.Append("(TLS_Descricao, TLS_FlagAtivo)");
                    strInsert.Append(@" VALUES (@TLS_Descricao, @TLS_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TLS_Descricao = objTipoLogisticoSistemaProdutivo.TLS_Descricao,
                            TLS_FlagAtivo = objTipoLogisticoSistemaProdutivo.TLS_FlagAtivo
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTipoLogisticoSistemaProdutivo.TLS_Id = queryInsert.First();

                    salvaLog(objTipoLogisticoSistemaProdutivo.Log, "", "InsertTipoLogisticoSistemaProdutivo", strInsert.ToString());
                    return objTipoLogisticoSistemaProdutivo;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objTipoLogisticoSistemaProdutivo.Log, "TipoLogisticoSistemaProdutivoRepository", "InsertTipoLogisticoSistemaProdutivo", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTipoLogisticoSistemaProdutivo.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TipoLogisticoSistemaProdutivo();
            }
        }


        public bool UpdateTipoLogisticoSistemaProdutivo(TipoLogisticoSistemaProdutivo objTipoLogisticoSistemaProdutivo)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [TipoLogisticoSistemaProdutivo] ");
                    strUpdate.Append(@" SET TLS_Descricao = @TLS_Descricao
                        , TLS_FlagAtivo = @TLS_FlagAtivo
                         where TLS_Id = @TLS_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TLS_Descricao = objTipoLogisticoSistemaProdutivo.TLS_Descricao,
                            TLS_FlagAtivo = objTipoLogisticoSistemaProdutivo.TLS_FlagAtivo,

                            TLS_Id = objTipoLogisticoSistemaProdutivo.TLS_Id
                        });
                }
                salvaLog(objTipoLogisticoSistemaProdutivo.Log, "", "UpdateTipoLogisticoSistemaProdutivo", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(objTipoLogisticoSistemaProdutivo.Log, "TipoLogisticoSistemaProdutivoRepository", "UpdateTipoLogisticoSistemaProdutivo", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objTipoLogisticoSistemaProdutivo.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarTipoLogisticoSistemaProdutivo(int TLS_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoLogisticoSistemaProdutivo] set ");
                    strUpdate.Append(" TLS_FlagAtivo = @TLS_FlagAtivo ");
                    strUpdate.Append(" where TLS_Id = @TLS_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TLS_FlagAtivo = 1,
                            TLS_Id = TLS_Id
                        });
                }
                salvaLog(null, "", "AtivarTipoLogisticoSistemaProdutivo", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoSistemaProdutivoRepository", "AtivarTipoLogisticoSistemaProdutivo", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTipoLogisticoSistemaProdutivo(int TLS_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoLogisticoSistemaProdutivo] set ");
                    strUpdate.Append(" TLS_FlagAtivo = @TLS_FlagAtivo ");
                    strUpdate.Append(" where TLS_Id = @TLS_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TLS_FlagAtivo = 0,
                            TLS_Id = TLS_Id
                        });
                }
                salvaLog(null, "", "DeletarTipoLogisticoSistemaProdutivo", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoSistemaProdutivoRepository", "DeletarTipoLogisticoSistemaProdutivo", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TipoLogisticoSistemaProdutivo GetTipoLogisticoSistemaProdutivoById(int TLS_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT TLS_Id, TLS_Descricao, TLS_FlagAtivo from [TipoLogisticoSistemaProdutivo] ");
                    strGet.Append(" where TLS_Id = @TLS_Id");

                    var obj = _db.Query<TipoLogisticoSistemaProdutivo>(strGet.ToString(), new { TLS_Id = TLS_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetTipoLogisticoSistemaProdutivoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoSistemaProdutivoRepository", "GetTipoLogisticoSistemaProdutivoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " TLS_Id, TLS_Descricao, TLS_FlagAtivo from [TipoLogisticoSistemaProdutivo] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TLS_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<TipoLogisticoSistemaProdutivo>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllTipoLogisticoSistemaProdutivo", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoSistemaProdutivoRepository", "GetAllTipoLogisticoSistemaProdutivo", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  TLS_Id, TLS_Descricao, TLS_FlagAtivo from [TipoLogisticoSistemaProdutivo] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TLS_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<TipoLogisticoSistemaProdutivo>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllTipoLogisticoSistemaProdutivoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoSistemaProdutivoRepository", "GetAllTipoLogisticoSistemaProdutivoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " TLS_Id, TLS_Descricao, TLS_FlagAtivo from [TipoLogisticoSistemaProdutivo] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TLS_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<TipoLogisticoSistemaProdutivo>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllTipoLogisticoSistemaProdutivoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoSistemaProdutivoRepository", "GetAllTipoLogisticoSistemaProdutivoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
