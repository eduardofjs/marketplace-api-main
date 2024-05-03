
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
    public class TemplateEmailRepository : RepositoryBase, ITemplateEmailRepository
    {
        
        public TemplateEmail InsertTemplateEmail(TemplateEmail objTemplateEmail)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into TemplateEmail ");
                    strInsert.Append("(TME_Nome, TME_NomeArquivo, TME_PathTemplateEmail, TME_Ativo)");
                    strInsert.Append(@" VALUES (@TME_Nome, @TME_NomeArquivo, @TME_PathTemplateEmail, @TME_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TME_Nome = objTemplateEmail.TME_Nome,
                            TME_NomeArquivo = objTemplateEmail.TME_NomeArquivo,
                            TME_PathTemplateEmail = objTemplateEmail.TME_PathTemplateEmail,
                            TME_Ativo = objTemplateEmail.TME_Ativo,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTemplateEmail.TME_Id = queryInsert.First();

                    salvaLog(objTemplateEmail.Log, "", "InsertTemplateEmail", strInsert.ToString());
                    return objTemplateEmail;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objTemplateEmail.Log, "TemplateEmailRepository", "InsertTemplateEmail", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTemplateEmail.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TemplateEmail();
            }
        }


        public bool UpdateTemplateEmail(TemplateEmail objTemplateEmail)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update TemplateEmail ");
                    strUpdate.Append(@" SET TME_Nome = @TME_Nome
                        , TME_NomeArquivo = @TME_NomeArquivo
                        , TME_PathTemplateEmail = @TME_PathTemplateEmail
                        , TME_Ativo = @TME_Ativo
                         where TME_Id = @TME_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            TME_Nome = objTemplateEmail.TME_Nome,
                            TME_NomeArquivo = objTemplateEmail.TME_NomeArquivo,
                            TME_PathTemplateEmail = objTemplateEmail.TME_PathTemplateEmail,
                            TME_Ativo = objTemplateEmail.TME_Ativo,
                            
                            TME_Id = objTemplateEmail.TME_Id                            
                           });
                }
                salvaLog(objTemplateEmail.Log, "", "UpdateTemplateEmail", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objTemplateEmail.Log, "TemplateEmailRepository", "UpdateTemplateEmail", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objTemplateEmail.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarTemplateEmail(int TME_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TemplateEmail set ");
                    strUpdate.Append(" TME_Ativo = @TME_Ativo ");
                    strUpdate.Append(" where TME_Id = @TME_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TME_Ativo = 1,
                                            TME_Id = TME_Id
                                        });
                }
                salvaLog(null, "", "AtivarTemplateEmail", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TemplateEmailRepository", "AtivarTemplateEmail", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTemplateEmail(int TME_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TemplateEmail set ");
                    strUpdate.Append(" TME_Ativo = @TME_Ativo ");
                    strUpdate.Append(" where TME_Id = @TME_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TME_Ativo = 0,
                                            TME_Id = TME_Id
                                        });
                }
                salvaLog(null, "", "DeletarTemplateEmail", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TemplateEmailRepository", "DeletarTemplateEmail", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TemplateEmail GetTemplateEmailById(int TME_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from TemplateEmail ");
                    if(join)
                    {
                             
                    }

                    strGet.Append(" where TME_Id = @TME_Id");                    

                    TemplateEmail obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<TemplateEmail,     TemplateEmail>(strGet.ToString(),
                        //    (objTemplateEmail,      ) => {
                        //             
                        //        return objTemplateEmail;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"     ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<TemplateEmail>(strGet.ToString(), new { TME_Id = TME_Id }).FirstOrDefault();
                    //}

                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(obj.TME_PathTemplateEmail))
                            obj.TME_PathTemplateEmail = ReadString("CGL_UrlImagem") + obj.TME_PathTemplateEmail.Replace("//", "/");
                    }
                    salvaLog(null, "", "GetTemplateEmailById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TemplateEmailRepository", "GetTemplateEmailById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TemplateEmail> GetAllTemplateEmail(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TemplateEmail ");
                    if(join)
                    {
                             
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TME_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<TemplateEmail> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TemplateEmail,     TemplateEmail>(newStrGetAll.ToString(),
                        //    (objTemplateEmail,      ) => {
                        //             
                        //        return objTemplateEmail;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"     ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TemplateEmail>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}
                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.TME_PathTemplateEmail))
                                item.TME_PathTemplateEmail = ReadString("CGL_UrlImagem") + item.TME_PathTemplateEmail.Replace("//", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllTemplateEmail", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TemplateEmailRepository", "GetAllTemplateEmail", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<TemplateEmail> GetAllTemplateEmailByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TemplateEmail ");
                         
                    if(join)
                    {
                             
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TME_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<TemplateEmail> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TemplateEmail,     TemplateEmail>(newStrGetAll.ToString(),
                        //    (objTemplateEmail,      ) => {
                        //             
                        //        return objTemplateEmail;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:"     ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TemplateEmail>(newStrGetAll.ToString(),
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
                            if (!string.IsNullOrEmpty(item.TME_PathTemplateEmail))
                                item.TME_PathTemplateEmail = ReadString("CGL_UrlImagem") + item.TME_PathTemplateEmail.Replace("//", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllTemplateEmailByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TemplateEmailRepository", "GetAllTemplateEmailByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TemplateEmail> GetAllTemplateEmailByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TemplateEmail ");
                    
                    if(join)
                    {
                             
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TME_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<TemplateEmail> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TemplateEmail,     TemplateEmail>(newStrGetAll.ToString(),
                        //    (objTemplateEmail,      ) => {
                        //             
                        //        return objTemplateEmail;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:"     ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TemplateEmail>(newStrGetAll.ToString(),
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
                            if (!string.IsNullOrEmpty(item.TME_PathTemplateEmail))
                                item.TME_PathTemplateEmail = ReadString("CGL_UrlImagem") + item.TME_PathTemplateEmail.Replace("//", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllTemplateEmailByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TemplateEmailRepository", "GetAllTemplateEmailByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
        public string getTemplateEmail(string key, int TME_Id)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                string obj;
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("select " + key + " from [TemplateEmail] ");
                    strGet.Append(" where TME_Id = @TME_Id ");

                    obj = _db.Query<string>(strGet.ToString(), new { TME_Id = TME_Id }).FirstOrDefault();
                }
                salvaLog(null, "", "getTemplateEmail", strGet.ToString());
                return obj;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TemplateEmailRepository", "getTemplateEmail", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return "";
            }
        }
    }
}
