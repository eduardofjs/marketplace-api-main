
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
    public class TipoLogisticoPortoRepository : RepositoryBase, ITipoLogisticoPortoRepository
    {

        public TipoLogisticoPorto InsertTipoLogisticoPorto(TipoLogisticoPorto objTipoLogisticoPorto)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [TipoLogisticoPorto] ");
                    strInsert.Append("(TLP_Descricao, TLP_FlagAtivo, TLP_DescricaoIngles)");
                    strInsert.Append(@" VALUES (@TLP_Descricao, @TLP_FlagAtivo, @TLP_DescricaoIngles);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TLP_Descricao = objTipoLogisticoPorto.TLP_Descricao,
                            TLP_FlagAtivo = objTipoLogisticoPorto.TLP_FlagAtivo,
                            TLP_DescricaoIngles = objTipoLogisticoPorto.TLP_DescricaoIngles,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTipoLogisticoPorto.TLP_Id = queryInsert.First();

                    salvaLog(objTipoLogisticoPorto.Log, "", "InsertTipoLogisticoPorto", strInsert.ToString());
                    return objTipoLogisticoPorto;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objTipoLogisticoPorto.Log, "TipoLogisticoPortoRepository", "InsertTipoLogisticoPorto", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTipoLogisticoPorto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TipoLogisticoPorto();
            }
        }


        public bool UpdateTipoLogisticoPorto(TipoLogisticoPorto objTipoLogisticoPorto)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [TipoLogisticoPorto] ");
                    strUpdate.Append(@" SET TLP_Descricao = @TLP_Descricao
                        , TLP_FlagAtivo = @TLP_FlagAtivo
                        , TLP_DescricaoIngles = @TLP_DescricaoIngles
                         where TLP_Id = @TLP_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TLP_Descricao = objTipoLogisticoPorto.TLP_Descricao,
                            TLP_FlagAtivo = objTipoLogisticoPorto.TLP_FlagAtivo,
                            TLP_DescricaoIngles = objTipoLogisticoPorto.TLP_DescricaoIngles,
                            TLP_Id = objTipoLogisticoPorto.TLP_Id
                        });
                }
                salvaLog(objTipoLogisticoPorto.Log, "", "UpdateTipoLogisticoPorto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(objTipoLogisticoPorto.Log, "TipoLogisticoPortoRepository", "UpdateTipoLogisticoPorto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objTipoLogisticoPorto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarTipoLogisticoPorto(int TLP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoLogisticoPorto] set ");
                    strUpdate.Append(" TLP_FlagAtivo = @TLP_FlagAtivo ");
                    strUpdate.Append(" where TLP_Id = @TLP_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TLP_FlagAtivo = 1,
                            TLP_Id = TLP_Id
                        });
                }
                salvaLog(null, "", "AtivarTipoLogisticoPorto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoPortoRepository", "AtivarTipoLogisticoPorto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTipoLogisticoPorto(int TLP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [TipoLogisticoPorto] set ");
                    strUpdate.Append(" TLP_FlagAtivo = @TLP_FlagAtivo ");
                    strUpdate.Append(" where TLP_Id = @TLP_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            TLP_FlagAtivo = 0,
                            TLP_Id = TLP_Id
                        });
                }
                salvaLog(null, "", "DeletarTipoLogisticoPorto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoPortoRepository", "DeletarTipoLogisticoPorto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TipoLogisticoPorto GetTipoLogisticoPortoById(int TLP_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [TipoLogisticoPorto] ");
                    strGet.Append(" where TLP_Id = @TLP_Id");

                    var obj = _db.Query<TipoLogisticoPorto>(strGet.ToString(), new { TLP_Id = TLP_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetTipoLogisticoPortoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoPortoRepository", "GetTipoLogisticoPortoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPorto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [TipoLogisticoPorto] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TLP_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<TipoLogisticoPorto>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllTipoLogisticoPorto", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoPortoRepository", "GetAllTipoLogisticoPorto", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPortoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [TipoLogisticoPorto] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TLP_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<TipoLogisticoPorto>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllTipoLogisticoPortoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoPortoRepository", "GetAllTipoLogisticoPortoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPortoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [TipoLogisticoPorto] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TLP_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<TipoLogisticoPorto>(newStrGetAll.ToString(),
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
                    salvaLog(null, "", "GetAllTipoLogisticoPortoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoLogisticoPortoRepository", "GetAllTipoLogisticoPortoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
