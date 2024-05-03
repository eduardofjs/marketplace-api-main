
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
    public class PoliticaPrivacidadeRepository : RepositoryBase, IPoliticaPrivacidadeRepository
    {
        
        public PoliticaPrivacidade InsertPoliticaPrivacidade(PoliticaPrivacidade objPoliticaPrivacidade)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into PoliticaPrivacidade ");
                    strInsert.Append("(PVD_Nome, PVD_PathUrl, PVD_Versao, PVD_VersaoLabel, PVD_Ativo)");
                    strInsert.Append(@" VALUES (@PVD_Nome, @PVD_PathUrl, @PVD_Versao, @PVD_VersaoLabel, @PVD_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            PVD_Nome = objPoliticaPrivacidade.PVD_Nome,
                            PVD_PathUrl = objPoliticaPrivacidade.PVD_PathUrl,
                            PVD_Versao = objPoliticaPrivacidade.PVD_Versao,
                            PVD_VersaoLabel = objPoliticaPrivacidade.PVD_VersaoLabel,
                            PVD_Ativo = objPoliticaPrivacidade.PVD_Ativo,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objPoliticaPrivacidade.PVD_Id = queryInsert.First();

                    salvaLog(objPoliticaPrivacidade.Log, "", "InsertPoliticaPrivacidade", strInsert.ToString());
                    return objPoliticaPrivacidade;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objPoliticaPrivacidade.Log, "PoliticaPrivacidadeRepository", "InsertPoliticaPrivacidade", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objPoliticaPrivacidade.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new PoliticaPrivacidade();
            }
        }


        public bool UpdatePoliticaPrivacidade(PoliticaPrivacidade objPoliticaPrivacidade)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update PoliticaPrivacidade ");
                    strUpdate.Append(@" SET PVD_Nome = @PVD_Nome
                        , PVD_PathUrl = @PVD_PathUrl
                        , PVD_Versao = @PVD_Versao
                        , PVD_VersaoLabel = @PVD_VersaoLabel
                        , PVD_Ativo = @PVD_Ativo
                         where PVD_Id = @PVD_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            PVD_Nome = objPoliticaPrivacidade.PVD_Nome,
                            PVD_PathUrl = objPoliticaPrivacidade.PVD_PathUrl,
                            PVD_Versao = objPoliticaPrivacidade.PVD_Versao,
                            PVD_VersaoLabel = objPoliticaPrivacidade.PVD_VersaoLabel,
                            PVD_Ativo = objPoliticaPrivacidade.PVD_Ativo,
                            
                            PVD_Id = objPoliticaPrivacidade.PVD_Id                            
                           });
                }
                salvaLog(objPoliticaPrivacidade.Log, "", "UpdatePoliticaPrivacidade", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objPoliticaPrivacidade.Log, "PoliticaPrivacidadeRepository", "UpdatePoliticaPrivacidade", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objPoliticaPrivacidade.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarPoliticaPrivacidade(int PVD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update PoliticaPrivacidade set ");
                    strUpdate.Append(" PVD_Ativo = @PVD_Ativo ");
                    strUpdate.Append(" where PVD_Id = @PVD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PVD_Ativo = 1,
                                            PVD_Id = PVD_Id
                                        });
                }
                salvaLog(null, "", "AtivarPoliticaPrivacidade", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadeRepository", "AtivarPoliticaPrivacidade", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarPoliticaPrivacidade(int PVD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update PoliticaPrivacidade set ");
                    strUpdate.Append(" PVD_Ativo = @PVD_Ativo ");
                    strUpdate.Append(" where PVD_Id = @PVD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PVD_Ativo = 0,
                                            PVD_Id = PVD_Id
                                        });
                }
                salvaLog(null, "", "DeletarPoliticaPrivacidade", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadeRepository", "DeletarPoliticaPrivacidade", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public PoliticaPrivacidade GetPoliticaPrivacidadeById(int PVD_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from PoliticaPrivacidade ");
                    if(join)
                    {
                              
                    }

                    strGet.Append(" where PVD_Id = @PVD_Id");                    

                    PoliticaPrivacidade obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<PoliticaPrivacidade,      PoliticaPrivacidade>(strGet.ToString(),
                        //    (objPoliticaPrivacidade,       ) => {
                        //              
                        //        return objPoliticaPrivacidade;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"      ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<PoliticaPrivacidade>(strGet.ToString(), new { PVD_Id = PVD_Id }).FirstOrDefault();
                    //}
                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(obj.PVD_PathUrl))
                            obj.PVD_PathUrl = ReadString("CGL_UrlImagem") + obj.PVD_PathUrl.Replace("//", "/");
                    }

                    salvaLog(null, "", "GetPoliticaPrivacidadeById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadeRepository", "GetPoliticaPrivacidadeById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from PoliticaPrivacidade ");
                    if(join)
                    {
                              
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where PVD_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<PoliticaPrivacidade> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<PoliticaPrivacidade,      PoliticaPrivacidade>(newStrGetAll.ToString(),
                        //    (objPoliticaPrivacidade,       ) => {
                        //              
                        //        return objPoliticaPrivacidade;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"      ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<PoliticaPrivacidade>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.PVD_PathUrl))
                                item.PVD_PathUrl = ReadString("CGL_UrlImagem") + item.PVD_PathUrl.Replace("//", "/");
                        }
                    }


                    salvaLog(null, "", "GetAllPoliticaPrivacidade", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadeRepository", "GetAllPoliticaPrivacidade", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from PoliticaPrivacidade ");
                         
                    if(join)
                    {
                              
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PVD_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<PoliticaPrivacidade> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<PoliticaPrivacidade,      PoliticaPrivacidade>(newStrGetAll.ToString(),
                        //    (objPoliticaPrivacidade,       ) => {
                        //              
                        //        return objPoliticaPrivacidade;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:"      ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<PoliticaPrivacidade>(newStrGetAll.ToString(),
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
                            if (!string.IsNullOrEmpty(item.PVD_PathUrl))
                                item.PVD_PathUrl = ReadString("CGL_UrlImagem") + item.PVD_PathUrl.Replace("//", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllPoliticaPrivacidadeByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadeRepository", "GetAllPoliticaPrivacidadeByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from PoliticaPrivacidade ");
                    
                    if(join)
                    {
                              
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PVD_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<PoliticaPrivacidade> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<PoliticaPrivacidade,      PoliticaPrivacidade>(newStrGetAll.ToString(),
                        //    (objPoliticaPrivacidade,       ) => {
                        //              
                        //        return objPoliticaPrivacidade;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:"      ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<PoliticaPrivacidade>(newStrGetAll.ToString(),
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
                            if (!string.IsNullOrEmpty(item.PVD_PathUrl))
                                item.PVD_PathUrl = ReadString("CGL_UrlImagem") + item.PVD_PathUrl.Replace("//", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllPoliticaPrivacidadeByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadeRepository", "GetAllPoliticaPrivacidadeByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
