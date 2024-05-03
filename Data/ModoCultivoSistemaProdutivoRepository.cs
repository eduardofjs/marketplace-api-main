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
    public class ModoCultivoSistemaProdutivoRepository : RepositoryBase, IModoCultivoSistemaProdutivoRepository
    {

        public ModoCultivoSistemaProdutivo InsertModoCultivoSistemaProdutivo(ModoCultivoSistemaProdutivo objModoCultivoSistemaProdutivo)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into ModoCultivoSistemaProdutivo ");
                    strInsert.Append("(MCS_Descricao, MCS_FlagAtivo)");
                    strInsert.Append(@" VALUES (@MCS_Descricao, @MCS_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            MCS_Descricao = objModoCultivoSistemaProdutivo.MCS_Descricao,
                            MCS_FlagAtivo = objModoCultivoSistemaProdutivo.MCS_FlagAtivo,

                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objModoCultivoSistemaProdutivo.MCS_Id = queryInsert.First();

                    salvaLog(objModoCultivoSistemaProdutivo.Log, "", "InsertModoCultivoSistemaProdutivo", strInsert.ToString());
                    return objModoCultivoSistemaProdutivo;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objModoCultivoSistemaProdutivo.Log, "ModoCultivoSistemaProdutivoRepository", "InsertModoCultivoSistemaProdutivo", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objModoCultivoSistemaProdutivo.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new ModoCultivoSistemaProdutivo();
            }
        }


        public bool UpdateModoCultivoSistemaProdutivo(ModoCultivoSistemaProdutivo objModoCultivoSistemaProdutivo)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update ModoCultivoSistemaProdutivo ");
                    strUpdate.Append(@" SET MCS_Descricao = @MCS_Descricao
                        , MCS_FlagAtivo = @MCS_FlagAtivo
                         where MCS_Id = @MCS_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               MCS_Descricao = objModoCultivoSistemaProdutivo.MCS_Descricao,
                               MCS_FlagAtivo = objModoCultivoSistemaProdutivo.MCS_FlagAtivo,

                               MCS_Id = objModoCultivoSistemaProdutivo.MCS_Id
                           });
                }
                salvaLog(objModoCultivoSistemaProdutivo.Log, "", "UpdateModoCultivoSistemaProdutivo", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objModoCultivoSistemaProdutivo.Log, "ModoCultivoSistemaProdutivoRepository", "UpdateModoCultivoSistemaProdutivo", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objModoCultivoSistemaProdutivo.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarModoCultivoSistemaProdutivo(int MCS_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update ModoCultivoSistemaProdutivo set ");
                    strUpdate.Append(" MCS_FlagAtivo = @MCS_FlagAtivo ");
                    strUpdate.Append(" where MCS_Id = @MCS_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            MCS_FlagAtivo = 1,
                                            MCS_Id = MCS_Id
                                        });
                }
                salvaLog(null, "", "AtivarModoCultivoSistemaProdutivo", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoSistemaProdutivoRepository", "AtivarModoCultivoSistemaProdutivo", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarModoCultivoSistemaProdutivo(int MCS_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update ModoCultivoSistemaProdutivo set ");
                    strUpdate.Append(" MCS_FlagAtivo = @MCS_FlagAtivo ");
                    strUpdate.Append(" where MCS_Id = @MCS_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            MCS_FlagAtivo = 0,
                                            MCS_Id = MCS_Id
                                        });
                }
                salvaLog(null, "", "DeletarModoCultivoSistemaProdutivo", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoSistemaProdutivoRepository", "DeletarModoCultivoSistemaProdutivo", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public ModoCultivoSistemaProdutivo GetModoCultivoSistemaProdutivoById(int MCS_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from ModoCultivoSistemaProdutivo ");
                    if (join)
                    {

                    }

                    strGet.Append(" where MCS_Id = @MCS_Id");

                    ModoCultivoSistemaProdutivo obj = null;
                    //if (join)
                    //{
                    //obj = _db.Query<ModoCultivoSistemaProdutivo,   ModoCultivoSistemaProdutivo>(strGet.ToString(),
                    //    (objModoCultivoSistemaProdutivo,    ) => {
                    //           
                    //        return objModoCultivoSistemaProdutivo;
                    //    }, new { maxInstances = maxInstances }, 
                    //    splitOn:"   ").FirstOrDefault();
                    //}
                    //else
                    //{
                    obj = _db.Query<ModoCultivoSistemaProdutivo>(strGet.ToString(), new { MCS_Id = MCS_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetModoCultivoSistemaProdutivoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoSistemaProdutivoRepository", "GetModoCultivoSistemaProdutivoById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from ModoCultivoSistemaProdutivo ");
                    if (join)
                    {

                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where MCS_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<ModoCultivoSistemaProdutivo> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<ModoCultivoSistemaProdutivo,   ModoCultivoSistemaProdutivo>(newStrGetAll.ToString(),
                    //    (objModoCultivoSistemaProdutivo,    ) => {
                    //           
                    //        return objModoCultivoSistemaProdutivo;
                    //    }, new { maxInstances = maxInstances }, 
                    //    splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<ModoCultivoSistemaProdutivo>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllModoCultivoSistemaProdutivo", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoSistemaProdutivoRepository", "GetAllModoCultivoSistemaProdutivo", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from ModoCultivoSistemaProdutivo ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and MCS_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<ModoCultivoSistemaProdutivo> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<ModoCultivoSistemaProdutivo,   ModoCultivoSistemaProdutivo>(newStrGetAll.ToString(),
                    //    (objModoCultivoSistemaProdutivo,    ) => {
                    //           
                    //        return objModoCultivoSistemaProdutivo;
                    //    },
                    //    new {
                    //        strPartial = "%" + strPartial + "%",
                    //        maxInstances = maxInstances
                    //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<ModoCultivoSistemaProdutivo>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllModoCultivoSistemaProdutivoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoSistemaProdutivoRepository", "GetAllModoCultivoSistemaProdutivoByPartial", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from ModoCultivoSistemaProdutivo ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and MCS_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<ModoCultivoSistemaProdutivo> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<ModoCultivoSistemaProdutivo,   ModoCultivoSistemaProdutivo>(newStrGetAll.ToString(),
                    //    (objModoCultivoSistemaProdutivo,    ) => {
                    //           
                    //        return objModoCultivoSistemaProdutivo;
                    //    },
                    //    new {
                    //        strValorExato = strValorExato,
                    //        maxInstances = maxInstances
                    //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<ModoCultivoSistemaProdutivo>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllModoCultivoSistemaProdutivoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ModoCultivoSistemaProdutivoRepository", "GetAllModoCultivoSistemaProdutivoByValorExato", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}

