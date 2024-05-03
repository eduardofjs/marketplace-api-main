
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
    public class PoliticaPrivacidadexUsuarioRepository : RepositoryBase, IPoliticaPrivacidadexUsuarioRepository
    {
        
        public PoliticaPrivacidadexUsuario InsertPoliticaPrivacidadexUsuario(PoliticaPrivacidadexUsuario objPoliticaPrivacidadexUsuario)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into PoliticaPrivacidadexUsuario ");
                    strInsert.Append("(PVU_UsuarioId, PVU_Aceite, PVU_PoliticaPrivacidadeId, PVU_DataAceite, PVU_Ativo)");
                    strInsert.Append(@" VALUES (@PVU_UsuarioId, @PVU_Aceite, @PVU_PoliticaPrivacidadeId, @PVU_DataAceite, @PVU_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            PVU_UsuarioId = objPoliticaPrivacidadexUsuario.PVU_UsuarioId,
                            PVU_Aceite = objPoliticaPrivacidadexUsuario.PVU_Aceite,
                            PVU_PoliticaPrivacidadeId = objPoliticaPrivacidadexUsuario.PVU_PoliticaPrivacidadeId,
                            PVU_DataAceite = objPoliticaPrivacidadexUsuario.PVU_DataAceite,
                            PVU_Ativo = objPoliticaPrivacidadexUsuario.PVU_Ativo,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objPoliticaPrivacidadexUsuario.PVU_Id = queryInsert.First();

                    salvaLog(objPoliticaPrivacidadexUsuario.Log, "", "InsertPoliticaPrivacidadexUsuario", strInsert.ToString());
                    return objPoliticaPrivacidadexUsuario;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objPoliticaPrivacidadexUsuario.Log, "PoliticaPrivacidadexUsuarioRepository", "InsertPoliticaPrivacidadexUsuario", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objPoliticaPrivacidadexUsuario.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new PoliticaPrivacidadexUsuario();
            }
        }


        public bool UpdatePoliticaPrivacidadexUsuario(PoliticaPrivacidadexUsuario objPoliticaPrivacidadexUsuario)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update PoliticaPrivacidadexUsuario ");
                    strUpdate.Append(@" SET PVU_UsuarioId = @PVU_UsuarioId
                        , PVU_Aceite = @PVU_Aceite
                        , PVU_PoliticaPrivacidadeId = @PVU_PoliticaPrivacidadeId
                        , PVU_DataAceite = @PVU_DataAceite
                        , PVU_Ativo = @PVU_Ativo
                         where PVU_Id = @PVU_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            PVU_UsuarioId = objPoliticaPrivacidadexUsuario.PVU_UsuarioId,
                            PVU_Aceite = objPoliticaPrivacidadexUsuario.PVU_Aceite,
                            PVU_PoliticaPrivacidadeId = objPoliticaPrivacidadexUsuario.PVU_PoliticaPrivacidadeId,
                            PVU_DataAceite = objPoliticaPrivacidadexUsuario.PVU_DataAceite,
                            PVU_Ativo = objPoliticaPrivacidadexUsuario.PVU_Ativo,
                            
                            PVU_Id = objPoliticaPrivacidadexUsuario.PVU_Id                            
                           });
                }
                salvaLog(objPoliticaPrivacidadexUsuario.Log, "", "UpdatePoliticaPrivacidadexUsuario", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objPoliticaPrivacidadexUsuario.Log, "PoliticaPrivacidadexUsuarioRepository", "UpdatePoliticaPrivacidadexUsuario", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objPoliticaPrivacidadexUsuario.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarPoliticaPrivacidadexUsuario(int PVU_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update PoliticaPrivacidadexUsuario set ");
                    strUpdate.Append(" PVU_Ativo = @PVU_Ativo ");
                    strUpdate.Append(" where PVU_Id = @PVU_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PVU_Ativo = 1,
                                            PVU_Id = PVU_Id
                                        });
                }
                salvaLog(null, "", "AtivarPoliticaPrivacidadexUsuario", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadexUsuarioRepository", "AtivarPoliticaPrivacidadexUsuario", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarPoliticaPrivacidadexUsuario(int PVU_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update PoliticaPrivacidadexUsuario set ");
                    strUpdate.Append(" PVU_Ativo = @PVU_Ativo ");
                    strUpdate.Append(" where PVU_Id = @PVU_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PVU_Ativo = 0,
                                            PVU_Id = PVU_Id
                                        });
                }
                salvaLog(null, "", "DeletarPoliticaPrivacidadexUsuario", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadexUsuarioRepository", "DeletarPoliticaPrivacidadexUsuario", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public PoliticaPrivacidadexUsuario GetPoliticaPrivacidadexUsuarioById(int PVU_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from PoliticaPrivacidadexUsuario ");
                    if(join)
                    {
                         strGet.Append(@" join Usuario on PVU_UsuarioId = USR_Id ");
                         strGet.Append(@" join PoliticaPrivacidade on PVU_PoliticaPrivacidadeId = PVD_Id ");
                          
                    }

                    strGet.Append(" where PVU_Id = @PVU_Id");                    

                    PoliticaPrivacidadexUsuario obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<PoliticaPrivacidadexUsuario, Usuario,  PoliticaPrivacidade,   PoliticaPrivacidadexUsuario>(strGet.ToString(),
                        //    (objPoliticaPrivacidadexUsuario,  objUsuario, objPoliticaPrivacidade,  ) => {
                        //         objPoliticaPrivacidadexUsuario.Usuario = objUsuario;
                        //         objPoliticaPrivacidadexUsuario.PoliticaPrivacidade = objPoliticaPrivacidade;
                        //          
                        //        return objPoliticaPrivacidadexUsuario;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:" USR_Id, PVD_Id  ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<PoliticaPrivacidadexUsuario>(strGet.ToString(), new { PVU_Id = PVU_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetPoliticaPrivacidadexUsuarioById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadexUsuarioRepository", "GetPoliticaPrivacidadexUsuarioById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from PoliticaPrivacidadexUsuario ");
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on PVU_UsuarioId = USR_Id ");
                         strGetAll.Append(@" join PoliticaPrivacidade on PVU_PoliticaPrivacidadeId = PVD_Id ");
                          
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where PVU_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<PoliticaPrivacidadexUsuario> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<PoliticaPrivacidadexUsuario, Usuario,  PoliticaPrivacidade,   PoliticaPrivacidadexUsuario>(newStrGetAll.ToString(),
                        //    (objPoliticaPrivacidadexUsuario,  objUsuario, objPoliticaPrivacidade,  ) => {
                        //         objPoliticaPrivacidadexUsuario.Usuario = objUsuario;
                        //         objPoliticaPrivacidadexUsuario.PoliticaPrivacidade = objPoliticaPrivacidade;
                        //          
                        //        return objPoliticaPrivacidadexUsuario;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:" USR_Id, PVD_Id  ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<PoliticaPrivacidadexUsuario>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllPoliticaPrivacidadexUsuario", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadexUsuarioRepository", "GetAllPoliticaPrivacidadexUsuario", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from PoliticaPrivacidadexUsuario ");
                         
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on PVU_UsuarioId = USR_Id ");
                         strGetAll.Append(@" join PoliticaPrivacidade on PVU_PoliticaPrivacidadeId = PVD_Id ");
                          
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PVU_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<PoliticaPrivacidadexUsuario> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<PoliticaPrivacidadexUsuario, Usuario,  PoliticaPrivacidade,   PoliticaPrivacidadexUsuario>(newStrGetAll.ToString(),
                        //    (objPoliticaPrivacidadexUsuario,  objUsuario, objPoliticaPrivacidade,  ) => {
                        //         objPoliticaPrivacidadexUsuario.Usuario = objUsuario;
                        //         objPoliticaPrivacidadexUsuario.PoliticaPrivacidade = objPoliticaPrivacidade;
                        //          
                        //        return objPoliticaPrivacidadexUsuario;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:" USR_Id, PVD_Id  ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<PoliticaPrivacidadexUsuario>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllPoliticaPrivacidadexUsuarioByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadexUsuarioRepository", "GetAllPoliticaPrivacidadexUsuarioByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from PoliticaPrivacidadexUsuario ");
                    
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on PVU_UsuarioId = USR_Id ");
                         strGetAll.Append(@" join PoliticaPrivacidade on PVU_PoliticaPrivacidadeId = PVD_Id ");
                          
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PVU_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<PoliticaPrivacidadexUsuario> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<PoliticaPrivacidadexUsuario, Usuario,  PoliticaPrivacidade,   PoliticaPrivacidadexUsuario>(newStrGetAll.ToString(),
                        //    (objPoliticaPrivacidadexUsuario,  objUsuario, objPoliticaPrivacidade,  ) => {
                        //         objPoliticaPrivacidadexUsuario.Usuario = objUsuario;
                        //         objPoliticaPrivacidadexUsuario.PoliticaPrivacidade = objPoliticaPrivacidade;
                        //          
                        //        return objPoliticaPrivacidadexUsuario;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:" USR_Id, PVD_Id  ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<PoliticaPrivacidadexUsuario>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllPoliticaPrivacidadexUsuarioByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PoliticaPrivacidadexUsuarioRepository", "GetAllPoliticaPrivacidadexUsuarioByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
