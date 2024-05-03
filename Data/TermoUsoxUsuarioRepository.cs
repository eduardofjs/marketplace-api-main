
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
    public class TermoUsoxUsuarioRepository : RepositoryBase, ITermoUsoxUsuarioRepository
    {
        
        public TermoUsoxUsuario InsertTermoUsoxUsuario(TermoUsoxUsuario objTermoUsoxUsuario)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into TermoUsoxUsuario ");
                    strInsert.Append("(TXU_UsuarioId, TXU_Aceite, TXU_TermoUsoId, TXU_DataAceite, TXU_Ativo)");
                    strInsert.Append(@" VALUES (@TXU_UsuarioId, @TXU_Aceite, @TXU_TermoUsoId, @TXU_DataAceite, @TXU_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TXU_UsuarioId = objTermoUsoxUsuario.TXU_UsuarioId,
                            TXU_Aceite = objTermoUsoxUsuario.TXU_Aceite,
                            TXU_TermoUsoId = objTermoUsoxUsuario.TXU_TermoUsoId,
                            TXU_DataAceite = objTermoUsoxUsuario.TXU_DataAceite,
                            TXU_Ativo = objTermoUsoxUsuario.TXU_Ativo,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTermoUsoxUsuario.TXU_Id = queryInsert.First();

                    salvaLog(objTermoUsoxUsuario.Log, "", "InsertTermoUsoxUsuario", strInsert.ToString());
                    return objTermoUsoxUsuario;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objTermoUsoxUsuario.Log, "TermoUsoxUsuarioRepository", "InsertTermoUsoxUsuario", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTermoUsoxUsuario.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TermoUsoxUsuario();
            }
        }


        public bool UpdateTermoUsoxUsuario(TermoUsoxUsuario objTermoUsoxUsuario)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update TermoUsoxUsuario ");
                    strUpdate.Append(@" SET TXU_UsuarioId = @TXU_UsuarioId
                        , TXU_Aceite = @TXU_Aceite
                        , TXU_TermoUsoId = @TXU_TermoUsoId
                        , TXU_DataAceite = @TXU_DataAceite
                        , TXU_Ativo = @TXU_Ativo
                         where TXU_Id = @TXU_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            TXU_UsuarioId = objTermoUsoxUsuario.TXU_UsuarioId,
                            TXU_Aceite = objTermoUsoxUsuario.TXU_Aceite,
                            TXU_TermoUsoId = objTermoUsoxUsuario.TXU_TermoUsoId,
                            TXU_DataAceite = objTermoUsoxUsuario.TXU_DataAceite,
                            TXU_Ativo = objTermoUsoxUsuario.TXU_Ativo,
                            
                            TXU_Id = objTermoUsoxUsuario.TXU_Id                            
                           });
                }
                salvaLog(objTermoUsoxUsuario.Log, "", "UpdateTermoUsoxUsuario", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objTermoUsoxUsuario.Log, "TermoUsoxUsuarioRepository", "UpdateTermoUsoxUsuario", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objTermoUsoxUsuario.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarTermoUsoxUsuario(int TXU_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TermoUsoxUsuario set ");
                    strUpdate.Append(" TXU_Ativo = @TXU_Ativo ");
                    strUpdate.Append(" where TXU_Id = @TXU_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TXU_Ativo = 1,
                                            TXU_Id = TXU_Id
                                        });
                }
                salvaLog(null, "", "AtivarTermoUsoxUsuario", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoxUsuarioRepository", "AtivarTermoUsoxUsuario", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTermoUsoxUsuario(int TXU_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TermoUsoxUsuario set ");
                    strUpdate.Append(" TXU_Ativo = @TXU_Ativo ");
                    strUpdate.Append(" where TXU_Id = @TXU_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TXU_Ativo = 0,
                                            TXU_Id = TXU_Id
                                        });
                }
                salvaLog(null, "", "DeletarTermoUsoxUsuario", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoxUsuarioRepository", "DeletarTermoUsoxUsuario", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TermoUsoxUsuario GetTermoUsoxUsuarioById(int TXU_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from TermoUsoxUsuario ");
                    if(join)
                    {
                         strGet.Append(@" join Usuario on TXU_UsuarioId = USR_Id ");
                         strGet.Append(@" join TermoUso on TXU_TermoUsoId = TRU_Id ");
                          
                    }

                    strGet.Append(" where TXU_Id = @TXU_Id");                    

                    TermoUsoxUsuario obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<TermoUsoxUsuario, Usuario,  TermoUso,   TermoUsoxUsuario>(strGet.ToString(),
                        //    (objTermoUsoxUsuario,  objUsuario, objTermoUso,  ) => {
                        //         objTermoUsoxUsuario.Usuario = objUsuario;
                        //         objTermoUsoxUsuario.TermoUso = objTermoUso;
                        //          
                        //        return objTermoUsoxUsuario;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:" USR_Id, TRU_Id  ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<TermoUsoxUsuario>(strGet.ToString(), new { TXU_Id = TXU_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetTermoUsoxUsuarioById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoxUsuarioRepository", "GetTermoUsoxUsuarioById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TermoUsoxUsuario ");
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on TXU_UsuarioId = USR_Id ");
                         strGetAll.Append(@" join TermoUso on TXU_TermoUsoId = TRU_Id ");
                          
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TXU_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<TermoUsoxUsuario> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TermoUsoxUsuario, Usuario,  TermoUso,   TermoUsoxUsuario>(newStrGetAll.ToString(),
                        //    (objTermoUsoxUsuario,  objUsuario, objTermoUso,  ) => {
                        //         objTermoUsoxUsuario.Usuario = objUsuario;
                        //         objTermoUsoxUsuario.TermoUso = objTermoUso;
                        //          
                        //        return objTermoUsoxUsuario;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:" USR_Id, TRU_Id  ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TermoUsoxUsuario>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllTermoUsoxUsuario", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoxUsuarioRepository", "GetAllTermoUsoxUsuario", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TermoUsoxUsuario ");
                         
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on TXU_UsuarioId = USR_Id ");
                         strGetAll.Append(@" join TermoUso on TXU_TermoUsoId = TRU_Id ");
                          
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TXU_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<TermoUsoxUsuario> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TermoUsoxUsuario, Usuario,  TermoUso,   TermoUsoxUsuario>(newStrGetAll.ToString(),
                        //    (objTermoUsoxUsuario,  objUsuario, objTermoUso,  ) => {
                        //         objTermoUsoxUsuario.Usuario = objUsuario;
                        //         objTermoUsoxUsuario.TermoUso = objTermoUso;
                        //          
                        //        return objTermoUsoxUsuario;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:" USR_Id, TRU_Id  ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TermoUsoxUsuario>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllTermoUsoxUsuarioByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoxUsuarioRepository", "GetAllTermoUsoxUsuarioByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from TermoUsoxUsuario ");
                    
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on TXU_UsuarioId = USR_Id ");
                         strGetAll.Append(@" join TermoUso on TXU_TermoUsoId = TRU_Id ");
                          
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TXU_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<TermoUsoxUsuario> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<TermoUsoxUsuario, Usuario,  TermoUso,   TermoUsoxUsuario>(newStrGetAll.ToString(),
                        //    (objTermoUsoxUsuario,  objUsuario, objTermoUso,  ) => {
                        //         objTermoUsoxUsuario.Usuario = objUsuario;
                        //         objTermoUsoxUsuario.TermoUso = objTermoUso;
                        //          
                        //        return objTermoUsoxUsuario;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:" USR_Id, TRU_Id  ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<TermoUsoxUsuario>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllTermoUsoxUsuarioByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TermoUsoxUsuarioRepository", "GetAllTermoUsoxUsuarioByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
