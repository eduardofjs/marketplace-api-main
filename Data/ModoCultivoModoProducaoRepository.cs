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
    public class ModoCultivoModoProducaoRepository : RepositoryBase, IModoCultivoModoProducaoRepository
    {

        public ModoCultivoModoProducao InsertModoCultivoModoProducao(ModoCultivoModoProducao objModoCultivoModoProducao)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into ModoCultivoModoProducao ");
                    strInsert.Append("(MCM_Descricao, MCM_FlagAtivo,MCM_DescricaoIngles)");
                    strInsert.Append(@" VALUES (@MCM_Descricao, @MCM_FlagAtivo, @MCM_DescricaoIngles);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            MCM_Descricao = objModoCultivoModoProducao.MCM_Descricao,
                            MCM_FlagAtivo = objModoCultivoModoProducao.MCM_FlagAtivo,
                            MCM_DescricaoIngles = objModoCultivoModoProducao.MCM_DescricaoIngles,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objModoCultivoModoProducao.MCM_Id = queryInsert.First();

                    salvaLog(objModoCultivoModoProducao.Log, "", "InsertModoCultivoModoProducao", strInsert.ToString());
                    return objModoCultivoModoProducao;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objModoCultivoModoProducao.Log, "ModoCultivoModoProducaoRepository", "InsertModoCultivoModoProducao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objModoCultivoModoProducao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new ModoCultivoModoProducao();
            }
        }


        public bool UpdateModoCultivoModoProducao(ModoCultivoModoProducao objModoCultivoModoProducao)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update ModoCultivoModoProducao ");
                    strUpdate.Append(@" SET MCM_Descricao = @MCM_Descricao
                        , MCM_FlagAtivo = @MCM_FlagAtivo
                        , MCM_DescricaoIngles = @MCM_DescricaoIngles
                         where MCM_Id = @MCM_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               MCM_Descricao = objModoCultivoModoProducao.MCM_Descricao,
                               MCM_FlagAtivo = objModoCultivoModoProducao.MCM_FlagAtivo,
                               MCM_DescricaoIngles = objModoCultivoModoProducao.MCM_DescricaoIngles,
                               MCM_Id = objModoCultivoModoProducao.MCM_Id
                           });
                }
                salvaLog(objModoCultivoModoProducao.Log, "", "UpdateModoCultivoModoProducao", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objModoCultivoModoProducao.Log, "ModoCultivoModoProducaoRepository", "UpdateModoCultivoModoProducao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objModoCultivoModoProducao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarModoCultivoModoProducao(int MCM_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update ModoCultivoModoProducao set ");
                    strUpdate.Append(" MCM_FlagAtivo = @MCM_FlagAtivo ");
                    strUpdate.Append(" where MCM_Id = @MCM_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            MCM_FlagAtivo = 1,
                                            MCM_Id = MCM_Id
                                        });
                }
                salvaLog(null, "", "AtivarModoCultivoModoProducao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoModoProducaoRepository", "AtivarModoCultivoModoProducao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarModoCultivoModoProducao(int MCM_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update ModoCultivoModoProducao set ");
                    strUpdate.Append(" MCM_FlagAtivo = @MCM_FlagAtivo ");
                    strUpdate.Append(" where MCM_Id = @MCM_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            MCM_FlagAtivo = 0,
                                            MCM_Id = MCM_Id
                                        });
                }
                salvaLog(null, "", "DeletarModoCultivoModoProducao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoModoProducaoRepository", "DeletarModoCultivoModoProducao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public ModoCultivoModoProducao GetModoCultivoModoProducaoById(int MCM_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from ModoCultivoModoProducao ");
                    if (join)
                    {

                    }

                    strGet.Append(" where MCM_Id = @MCM_Id");

                    ModoCultivoModoProducao obj = null;
                    //if (join)
                    //{
                    //obj = _db.Query<ModoCultivoModoProducao,   ModoCultivoModoProducao>(strGet.ToString(),
                    //    (objModoCultivoModoProducao,    ) => {
                    //           
                    //        return objModoCultivoModoProducao;
                    //    }, new { maxInstances = maxInstances }, 
                    //    splitOn:"   ").FirstOrDefault();
                    //}
                    //else
                    //{
                    obj = _db.Query<ModoCultivoModoProducao>(strGet.ToString(), new { MCM_Id = MCM_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetModoCultivoModoProducaoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoModoProducaoRepository", "GetModoCultivoModoProducaoById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from ModoCultivoModoProducao ");
                    if (join)
                    {

                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where MCM_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<ModoCultivoModoProducao> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<ModoCultivoModoProducao,   ModoCultivoModoProducao>(newStrGetAll.ToString(),
                    //    (objModoCultivoModoProducao,    ) => {
                    //           
                    //        return objModoCultivoModoProducao;
                    //    }, new { maxInstances = maxInstances }, 
                    //    splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<ModoCultivoModoProducao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllModoCultivoModoProducao", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoModoProducaoRepository", "GetAllModoCultivoModoProducao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from ModoCultivoModoProducao ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and MCM_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<ModoCultivoModoProducao> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<ModoCultivoModoProducao,   ModoCultivoModoProducao>(newStrGetAll.ToString(),
                    //    (objModoCultivoModoProducao,    ) => {
                    //           
                    //        return objModoCultivoModoProducao;
                    //    },
                    //    new {
                    //        strPartial = "%" + strPartial + "%",
                    //        maxInstances = maxInstances
                    //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<ModoCultivoModoProducao>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllModoCultivoModoProducaoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoModoProducaoRepository", "GetAllModoCultivoModoProducaoByPartial", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<ModoCultivoModoProducao> GetAllModoCultivoModoProducaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from ModoCultivoModoProducao ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and MCM_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<ModoCultivoModoProducao> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<ModoCultivoModoProducao,   ModoCultivoModoProducao>(newStrGetAll.ToString(),
                    //    (objModoCultivoModoProducao,    ) => {
                    //           
                    //        return objModoCultivoModoProducao;
                    //    },
                    //    new {
                    //        strValorExato = strValorExato,
                    //        maxInstances = maxInstances
                    //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<ModoCultivoModoProducao>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllModoCultivoModoProducaoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoModoProducaoRepository", "GetAllModoCultivoModoProducaoByValorExato", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}

