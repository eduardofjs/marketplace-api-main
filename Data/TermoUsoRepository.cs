
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
    public class TermoUsoRepository : RepositoryBase, ITermoUsoRepository
    {
        
        public TermoUso InsertTermoUso(TermoUso objTermoUso)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into TermoUso ");
                    strInsert.Append("(TRU_Nome, TRU_PathUrl, TRU_Versao, TRU_VersaoLabel, TRU_Ativo)");
                    strInsert.Append(@" VALUES (@TRU_Nome, @TRU_PathUrl, @TRU_Versao, @TRU_VersaoLabel, @TRU_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TRU_Nome = objTermoUso.TRU_Nome,
                            TRU_PathUrl = objTermoUso.TRU_PathUrl,
                            TRU_Versao = objTermoUso.TRU_Versao,
                            TRU_VersaoLabel = objTermoUso.TRU_VersaoLabel,
                            TRU_Ativo = objTermoUso.TRU_Ativo,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTermoUso.TRU_Id = queryInsert.First();

                    salvaLog(objTermoUso.Log, "", "InsertTermoUso", strInsert.ToString());
                    return objTermoUso;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objTermoUso.Log, "TermoUsoRepository", "InsertTermoUso", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTermoUso.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TermoUso();
            }
        }


        public bool UpdateTermoUso(TermoUso objTermoUso)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update TermoUso ");
                    strUpdate.Append(@" SET TRU_Nome = @TRU_Nome
                        , TRU_PathUrl = @TRU_PathUrl
                        , TRU_Versao = @TRU_Versao
                        , TRU_VersaoLabel = @TRU_VersaoLabel
                        , TRU_Ativo = @TRU_Ativo
                         where TRU_Id = @TRU_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            TRU_Nome = objTermoUso.TRU_Nome,
                            TRU_PathUrl = objTermoUso.TRU_PathUrl,
                            TRU_Versao = objTermoUso.TRU_Versao,
                            TRU_VersaoLabel = objTermoUso.TRU_VersaoLabel,
                            TRU_Ativo = objTermoUso.TRU_Ativo,
                            
                            TRU_Id = objTermoUso.TRU_Id                            
                           });
                }
                salvaLog(objTermoUso.Log, "", "UpdateTermoUso", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objTermoUso.Log, "TermoUsoRepository", "UpdateTermoUso", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objTermoUso.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarTermoUso(int TRU_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TermoUso set ");
                    strUpdate.Append(" TRU_Ativo = @TRU_Ativo ");
                    strUpdate.Append(" where TRU_Id = @TRU_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TRU_Ativo = 1,
                                            TRU_Id = TRU_Id
                                        });
                }
                salvaLog(null, "", "AtivarTermoUso", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoRepository", "AtivarTermoUso", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTermoUso(int TRU_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TermoUso set ");
                    strUpdate.Append(" TRU_Ativo = @TRU_Ativo ");
                    strUpdate.Append(" where TRU_Id = @TRU_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TRU_Ativo = 0,
                                            TRU_Id = TRU_Id
                                        });
                }
                salvaLog(null, "", "DeletarTermoUso", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoRepository", "DeletarTermoUso", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TermoUso GetTermoUsoById(int TRU_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from TermoUso ");
                    if(join)
                    {
                              
                    }

                    strGet.Append(" where TRU_Id = @TRU_Id");                    

                    TermoUso obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<TermoUso,      TermoUso>(strGet.ToString(),
                        //    (objTermoUso,       ) => {
                        //              
                        //        return objTermoUso;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"      ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<TermoUso>(strGet.ToString(), new { TRU_Id = TRU_Id }).FirstOrDefault();
                    //}
                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(obj.TRU_PathUrl))
                            obj.TRU_PathUrl = ReadString("CGL_UrlImagem") + obj.TRU_PathUrl.Replace("//", "/");
                    }

                    salvaLog(null, "", "GetTermoUsoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoRepository", "GetTermoUsoById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TermoUso> GetAllTermoUso(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TermoUso ");
                    if(join)
                    {
                              
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TRU_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<TermoUso> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TermoUso,      TermoUso>(newStrGetAll.ToString(),
                        //    (objTermoUso,       ) => {
                        //              
                        //        return objTermoUso;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"      ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TermoUso>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.TRU_PathUrl))
                                item.TRU_PathUrl = ReadString("CGL_UrlImagem") + item.TRU_PathUrl.Replace("//", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllTermoUso", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoRepository", "GetAllTermoUso", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<TermoUso> GetAllTermoUsoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TermoUso ");
                         
                    if(join)
                    {
                              
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TRU_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<TermoUso> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TermoUso,      TermoUso>(newStrGetAll.ToString(),
                        //    (objTermoUso,       ) => {
                        //              
                        //        return objTermoUso;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:"      ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TermoUso>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.TRU_PathUrl))
                                item.TRU_PathUrl = ReadString("CGL_UrlImagem") + item.TRU_PathUrl.Replace("//", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllTermoUsoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoRepository", "GetAllTermoUsoByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TermoUso> GetAllTermoUsoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TermoUso ");
                    
                    if(join)
                    {
                              
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TRU_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<TermoUso> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TermoUso,      TermoUso>(newStrGetAll.ToString(),
                        //    (objTermoUso,       ) => {
                        //              
                        //        return objTermoUso;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:"      ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TermoUso>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.TRU_PathUrl))
                                item.TRU_PathUrl = ReadString("CGL_UrlImagem") + item.TRU_PathUrl.Replace("//", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllTermoUsoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoRepository", "GetAllTermoUsoByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
