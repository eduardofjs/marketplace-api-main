
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
    public class TipoEmpresaRepository : RepositoryBase, ITipoEmpresaRepository
    {
        
        public TipoEmpresa InsertTipoEmpresa(TipoEmpresa objTipoEmpresa)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into TipoEmpresa ");
                    strInsert.Append("(TEM_Nome, TEM_Ativo)");
                    strInsert.Append(@" VALUES (@TEM_Nome, @TEM_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TEM_Nome = objTipoEmpresa.TEM_Nome,
                            TEM_Ativo = objTipoEmpresa.TEM_Ativo,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTipoEmpresa.TEM_Id = queryInsert.First();

                    salvaLog(objTipoEmpresa.Log, "", "InsertTipoEmpresa", strInsert.ToString());
                    return objTipoEmpresa;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objTipoEmpresa.Log, "TipoEmpresaRepository", "InsertTipoEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTipoEmpresa.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TipoEmpresa();
            }
        }


        public bool UpdateTipoEmpresa(TipoEmpresa objTipoEmpresa)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update TipoEmpresa ");
                    strUpdate.Append(@" SET TEM_Nome = @TEM_Nome
                        , TEM_Ativo = @TEM_Ativo
                         where TEM_Id = @TEM_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            TEM_Nome = objTipoEmpresa.TEM_Nome,
                            TEM_Ativo = objTipoEmpresa.TEM_Ativo,
                            
                            TEM_Id = objTipoEmpresa.TEM_Id                            
                           });
                }
                salvaLog(objTipoEmpresa.Log, "", "UpdateTipoEmpresa", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objTipoEmpresa.Log, "TipoEmpresaRepository", "UpdateTipoEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objTipoEmpresa.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarTipoEmpresa(int TEM_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TipoEmpresa set ");
                    strUpdate.Append(" TEM_Ativo = @TEM_Ativo ");
                    strUpdate.Append(" where TEM_Id = @TEM_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TEM_Ativo = 1,
                                            TEM_Id = TEM_Id
                                        });
                }
                salvaLog(null, "", "AtivarTipoEmpresa", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoEmpresaRepository", "AtivarTipoEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTipoEmpresa(int TEM_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TipoEmpresa set ");
                    strUpdate.Append(" TEM_Ativo = @TEM_Ativo ");
                    strUpdate.Append(" where TEM_Id = @TEM_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TEM_Ativo = 0,
                                            TEM_Id = TEM_Id
                                        });
                }
                salvaLog(null, "", "DeletarTipoEmpresa", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoEmpresaRepository", "DeletarTipoEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TipoEmpresa GetTipoEmpresaById(int TEM_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from TipoEmpresa ");
                    if(join)
                    {
                           
                    }

                    strGet.Append(" where TEM_Id = @TEM_Id");                    

                    TipoEmpresa obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<TipoEmpresa,   TipoEmpresa>(strGet.ToString(),
                        //    (objTipoEmpresa,    ) => {
                        //           
                        //        return objTipoEmpresa;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"   ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<TipoEmpresa>(strGet.ToString(), new { TEM_Id = TEM_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetTipoEmpresaById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoEmpresaRepository", "GetTipoEmpresaById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoEmpresa> GetAllTipoEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TipoEmpresa ");
                    if(join)
                    {
                           
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TEM_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<TipoEmpresa> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TipoEmpresa,   TipoEmpresa>(newStrGetAll.ToString(),
                        //    (objTipoEmpresa,    ) => {
                        //           
                        //        return objTipoEmpresa;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TipoEmpresa>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllTipoEmpresa", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoEmpresaRepository", "GetAllTipoEmpresa", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<TipoEmpresa> GetAllTipoEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TipoEmpresa ");
                         
                    if(join)
                    {
                           
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TEM_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<TipoEmpresa> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TipoEmpresa,   TipoEmpresa>(newStrGetAll.ToString(),
                        //    (objTipoEmpresa,    ) => {
                        //           
                        //        return objTipoEmpresa;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TipoEmpresa>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllTipoEmpresaByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoEmpresaRepository", "GetAllTipoEmpresaByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TipoEmpresa> GetAllTipoEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TipoEmpresa ");
                    
                    if(join)
                    {
                           
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TEM_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<TipoEmpresa> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TipoEmpresa,   TipoEmpresa>(newStrGetAll.ToString(),
                        //    (objTipoEmpresa,    ) => {
                        //           
                        //        return objTipoEmpresa;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TipoEmpresa>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllTipoEmpresaByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoEmpresaRepository", "GetAllTipoEmpresaByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
