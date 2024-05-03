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
    public class CategoriaRepository : RepositoryBase, ICategoriaRepository
    {

        public Categoria InsertCategoria(Categoria objCategoria)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into Categoria ");
                    strInsert.Append("(CAT_Descricao, CAT_FlagAtivo)");
                    strInsert.Append(@" VALUES (@CAT_Descricao, @CAT_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            CAT_Descricao = objCategoria.CAT_Descricao,
                            CAT_FlagAtivo = objCategoria.CAT_FlagAtivo,

                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objCategoria.CAT_Id = queryInsert.First();

                    salvaLog(objCategoria.Log, "", "InsertCategoria", strInsert.ToString());
                    return objCategoria;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objCategoria.Log, "CategoriaRepository", "InsertCategoria", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objCategoria.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Categoria();
            }
        }


        public bool UpdateCategoria(Categoria objCategoria)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update Categoria ");
                    strUpdate.Append(@" SET CAT_Descricao = @CAT_Descricao
                        , CAT_FlagAtivo = @CAT_FlagAtivo
                         where CAT_Id = @CAT_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               CAT_Descricao = objCategoria.CAT_Descricao,
                               CAT_FlagAtivo = objCategoria.CAT_FlagAtivo,

                               CAT_Id = objCategoria.CAT_Id
                           });
                }
                salvaLog(objCategoria.Log, "", "UpdateCategoria", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objCategoria.Log, "CategoriaRepository", "UpdateCategoria", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objCategoria.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarCategoria(int CAT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Categoria set ");
                    strUpdate.Append(" CAT_FlagAtivo = @CAT_FlagAtivo ");
                    strUpdate.Append(" where CAT_Id = @CAT_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            CAT_FlagAtivo = 1,
                                            CAT_Id = CAT_Id
                                        });
                }
                salvaLog(null, "", "AtivarCategoria", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "CategoriaRepository", "AtivarCategoria", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarCategoria(int CAT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Categoria set ");
                    strUpdate.Append(" CAT_FlagAtivo = @CAT_FlagAtivo ");
                    strUpdate.Append(" where CAT_Id = @CAT_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            CAT_FlagAtivo = 0,
                                            CAT_Id = CAT_Id
                                        });
                }
                salvaLog(null, "", "DeletarCategoria", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "CategoriaRepository", "DeletarCategoria", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Categoria GetCategoriaById(int CAT_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from Categoria ");
                    if (join)
                    {

                    }

                    strGet.Append(" where CAT_Id = @CAT_Id");

                    Categoria obj = null;
                    //if (join)
                    //{
                    //obj = _db.Query<Categoria,   Categoria>(strGet.ToString(),
                    //    (objCategoria,    ) => {
                    //           
                    //        return objCategoria;
                    //    }, new { maxInstances = maxInstances }, 
                    //    splitOn:"   ").FirstOrDefault();
                    //}
                    //else
                    //{
                    obj = _db.Query<Categoria>(strGet.ToString(), new { CAT_Id = CAT_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetCategoriaById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "CategoriaRepository", "GetCategoriaById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Categoria> GetAllCategoria(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from Categoria ");
                    if (join)
                    {

                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where CAT_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<Categoria> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<Categoria,   Categoria>(newStrGetAll.ToString(),
                    //    (objCategoria,    ) => {
                    //           
                    //        return objCategoria;
                    //    }, new { maxInstances = maxInstances }, 
                    //    splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<Categoria>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllCategoria", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "CategoriaRepository", "GetAllCategoria", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Categoria> GetAllCategoriaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from Categoria ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and CAT_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Categoria> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<Categoria,   Categoria>(newStrGetAll.ToString(),
                    //    (objCategoria,    ) => {
                    //           
                    //        return objCategoria;
                    //    },
                    //    new {
                    //        strPartial = "%" + strPartial + "%",
                    //        maxInstances = maxInstances
                    //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<Categoria>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllCategoriaByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "CategoriaRepository", "GetAllCategoriaByPartial", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Categoria> GetAllCategoriaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from Categoria ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and CAT_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Categoria> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<Categoria,   Categoria>(newStrGetAll.ToString(),
                    //    (objCategoria,    ) => {
                    //           
                    //        return objCategoria;
                    //    },
                    //    new {
                    //        strValorExato = strValorExato,
                    //        maxInstances = maxInstances
                    //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<Categoria>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllCategoriaByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "CategoriaRepository", "GetAllCategoriaByValorExato", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}

