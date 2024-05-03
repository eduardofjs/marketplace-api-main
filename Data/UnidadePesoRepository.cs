
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
    public class UnidadePesoRepository : RepositoryBase, IUnidadePesoRepository
    {

        public UnidadePeso InsertUnidadePeso(UnidadePeso objUnidadePeso)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [UnidadePeso] ");
                    strInsert.Append("(UNP_Descricao, UNP_FlagAtivo)");
                    strInsert.Append(@" VALUES (@UNP_Descricao, @UNP_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            UNP_Descricao = objUnidadePeso.UNP_Descricao,
                            UNP_FlagAtivo = objUnidadePeso.UNP_FlagAtivo
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objUnidadePeso.UNP_Id = queryInsert.First();

                    salvaLog(objUnidadePeso.Log, "", "InsertUnidadePeso", strInsert.ToString());
                    return objUnidadePeso;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objUnidadePeso.Log, "UnidadePesoRepository", "InsertUnidadePeso", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objUnidadePeso.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new UnidadePeso();
            }
        }


        public bool UpdateUnidadePeso(UnidadePeso objUnidadePeso)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [UnidadePeso] ");
                    strUpdate.Append(@" SET UNP_Descricao = @UNP_Descricao
                        , UNP_FlagAtivo = @UNP_FlagAtivo
                         where UNP_Id = @UNP_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            UNP_Descricao = objUnidadePeso.UNP_Descricao,
                            UNP_FlagAtivo = objUnidadePeso.UNP_FlagAtivo,

                            UNP_Id = objUnidadePeso.UNP_Id
                        });
                }
                salvaLog(objUnidadePeso.Log, "", "UpdateUnidadePeso", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(objUnidadePeso.Log, "UnidadePesoRepository", "UpdateUnidadePeso", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objUnidadePeso.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarUnidadePeso(int UNP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [UnidadePeso] set ");
                    strUpdate.Append(" UNP_FlagAtivo = @UNP_FlagAtivo ");
                    strUpdate.Append(" where UNP_Id = @UNP_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            UNP_FlagAtivo = 1,
                            UNP_Id = UNP_Id
                        });
                }
                salvaLog(null, "", "AtivarUnidadePeso", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadePesoRepository", "AtivarUnidadePeso", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarUnidadePeso(int UNP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [UnidadePeso] set ");
                    strUpdate.Append(" UNP_FlagAtivo = @UNP_FlagAtivo ");
                    strUpdate.Append(" where UNP_Id = @UNP_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            UNP_FlagAtivo = 0,
                            UNP_Id = UNP_Id
                        });
                }
                salvaLog(null, "", "DeletarUnidadePeso", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadePesoRepository", "DeletarUnidadePeso", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public UnidadePeso GetUnidadePesoById(int UNP_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT UNP_Id, UNP_Descricao, UNP_FlagAtivo from [UnidadePeso] ");
                    strGet.Append(" where UNP_Id = @UNP_Id");

                    var obj = _db.Query<UnidadePeso>(strGet.ToString(), new { UNP_Id = UNP_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetUnidadePesoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadePesoRepository", "GetUnidadePesoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<UnidadePeso> GetAllUnidadePeso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " UNP_Id, UNP_Descricao, UNP_FlagAtivo from [UnidadePeso] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where UNP_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<UnidadePeso>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllUnidadePeso", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadePesoRepository", "GetAllUnidadePeso", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<UnidadePeso> GetAllUnidadePesoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  UNP_Id, UNP_Descricao, UNP_FlagAtivo from [UnidadePeso] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and UNP_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<UnidadePeso>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllUnidadePesoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadePesoRepository", "GetAllUnidadePesoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<UnidadePeso> GetAllUnidadePesoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " UNP_Id, UNP_Descricao, UNP_FlagAtivo from [UnidadePeso] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and UNP_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<UnidadePeso>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllUnidadePesoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadePesoRepository", "GetAllUnidadePesoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
