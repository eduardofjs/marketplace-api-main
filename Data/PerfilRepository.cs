
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
    public class PerfilRepository : RepositoryBase, IPerfilRepository
    {
        
        public Perfil InsertPerfil(Perfil objPerfil)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Perfil] ");
                    strInsert.Append("(PRF_UnidadeId, PRF_Descricao, PRF_Nome, PRF_Ativo)");
                    strInsert.Append(@" VALUES (@PRF_UnidadeId, @PRF_Descricao, @PRF_Nome, @PRF_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            PRF_UnidadeId = objPerfil.PRF_UnidadeId,
                            PRF_Descricao = objPerfil.PRF_Descricao,
                            PRF_Nome = objPerfil.PRF_Nome,
                            PRF_Ativo = 1,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objPerfil.PRF_Id = queryInsert.First();

                    salvaLog(objPerfil.Log, "", "InsertPerfil", strInsert.ToString());
                    return objPerfil;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objPerfil.Log, "PerfilRepository", "InsertPerfil", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objPerfil.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Perfil();
            }
        }


        public bool UpdatePerfil(Perfil objPerfil)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Perfil] ");
                    strUpdate.Append(@" SET PRF_UnidadeId = @PRF_UnidadeId
                        , PRF_Descricao = @PRF_Descricao
                        , PRF_Nome = @PRF_Nome
                        , PRF_Ativo = @PRF_Ativo
                         where PRF_Id = @PRF_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            PRF_UnidadeId = objPerfil.PRF_UnidadeId,
                            PRF_Descricao = objPerfil.PRF_Descricao,
                            PRF_Nome = objPerfil.PRF_Nome,
                            PRF_Ativo = 1,
                            
                            PRF_Id = objPerfil.PRF_Id                            
                           });
                }
                salvaLog(objPerfil.Log, "", "UpdatePerfil", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objPerfil.Log, "PerfilRepository", "UpdatePerfil", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objPerfil.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarPerfil(int PRF_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Perfil] set ");
                    strUpdate.Append(" PRF_Ativo = @PRF_Ativo ");
                    strUpdate.Append(" where PRF_Id = @PRF_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PRF_Ativo = 1,
                                            PRF_Id = PRF_Id
                                        });
                }
                salvaLog(null, "", "AtivarPerfil", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilRepository", "AtivarPerfil", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarPerfil(int PRF_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Perfil] set ");
                    strUpdate.Append(" PRF_Ativo = @PRF_Ativo ");
                    strUpdate.Append(" where PRF_Id = @PRF_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PRF_Ativo = 0,
                                            PRF_Id = PRF_Id
                                        });
                }
                salvaLog(null, "", "DeletarPerfil", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilRepository", "DeletarPerfil", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Perfil GetPerfilById(int PRF_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT PRF_Id, PRF_UnidadeId, PRF_Descricao, PRF_Nome, PRF_Ativo from [Perfil] ");
                    strGet.Append(" where PRF_Id = @PRF_Id");

                    var obj = _db.Query<Perfil>(strGet.ToString(), new { PRF_Id = PRF_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                                   
                    }

                    salvaLog(null, "", "GetPerfilById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilRepository", "GetPerfilById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Perfil> GetAllPerfil(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Perfil] ");
                    if(join)
                    {
                             
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where PRF_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Perfil> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Perfil,     Perfil>(newStrGetAll.ToString(),
                    //        (objPerfil,      ) => {
                                     
                    //            return objPerfil;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "     ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Perfil>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    lista = _db.Query<Perfil>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    salvaLog(null, "", "GetAllPerfil", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilRepository", "GetAllPerfil", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Perfil> GetAllPerfilByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Perfil] ");
                         
                    if(join)
                    {
                             
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PRF_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Perfil> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Perfil,     Perfil>(newStrGetAll.ToString(),
                    //        (objPerfil,      ) => {
                                     
                    //            return objPerfil;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "     ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Perfil>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<Perfil>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    salvaLog(null, "", "GetAllPerfilByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilRepository", "GetAllPerfilByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Perfil> GetAllPerfilByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Perfil] ");
                    
                    if(join)
                    {
                             
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PRF_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Perfil> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Perfil,     Perfil>(newStrGetAll.ToString(),
                    //        (objPerfil,      ) => {
                                     
                    //            return objPerfil;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "     ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Perfil>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<Perfil>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllPerfilByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilRepository", "GetAllPerfilByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
