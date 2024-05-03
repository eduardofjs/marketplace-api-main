
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
    public class EstadoRepository : RepositoryBase, IEstadoRepository
    {
        
        public Estado InsertEstado(Estado objEstado)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Estado] ");
                    strInsert.Append("(ESD_Nome, ESD_Sigla, ESD_Ativo)");
                    strInsert.Append(@" VALUES (@ESD_Nome, @ESD_Sigla, @ESD_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            ESD_Nome = objEstado.ESD_Nome,
                            ESD_Sigla = objEstado.ESD_Sigla,
                            ESD_Ativo = 1,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objEstado.ESD_Id = queryInsert.First();

                    salvaLog(objEstado.Log, "", "InsertEstado", strInsert.ToString());
                    return objEstado;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objEstado.Log, "EstadoRepository", "InsertEstado", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objEstado.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Estado();
            }
        }


        public bool UpdateEstado(Estado objEstado)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Estado] ");
                    strUpdate.Append(@" SET ESD_Nome = @ESD_Nome
                        , ESD_Sigla = @ESD_Sigla
                        , ESD_Ativo = @ESD_Ativo
                         where ESD_Id = @ESD_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            ESD_Nome = objEstado.ESD_Nome,
                            ESD_Sigla = objEstado.ESD_Sigla,
                            ESD_Ativo = 1,
                            
                            ESD_Id = objEstado.ESD_Id                            
                           });
                }
                salvaLog(objEstado.Log, "", "UpdateEstado", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objEstado.Log, "EstadoRepository", "UpdateEstado", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objEstado.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarEstado(int ESD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Estado] set ");
                    strUpdate.Append(" ESD_Ativo = @ESD_Ativo ");
                    strUpdate.Append(" where ESD_Id = @ESD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ESD_Ativo = 1,
                                            ESD_Id = ESD_Id
                                        });
                }
                salvaLog(null, "", "AtivarEstado", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EstadoRepository", "AtivarEstado", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarEstado(int ESD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Estado] set ");
                    strUpdate.Append(" ESD_Ativo = @ESD_Ativo ");
                    strUpdate.Append(" where ESD_Id = @ESD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ESD_Ativo = 0,
                                            ESD_Id = ESD_Id
                                        });
                }
                salvaLog(null, "", "DeletarEstado", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EstadoRepository", "DeletarEstado", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Estado GetEstadoById(int ESD_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT ESD_Id, ESD_Nome, ESD_Sigla, ESD_Ativo from [Estado] ");
                    strGet.Append(" where ESD_Id = @ESD_Id");

                    var obj = _db.Query<Estado>(strGet.ToString(), new { ESD_Id = ESD_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                                  
                    }

                    salvaLog(null, "", "GetEstadoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EstadoRepository", "GetEstadoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Estado> GetAllEstado(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Estado] ");
                    if(join)
                    {
                            
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where ESD_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Estado> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Estado,    Estado>(newStrGetAll.ToString(),
                    //        (objEstado,     ) => {
                                    
                    //            return objEstado;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "    ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Estado>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    lista = _db.Query<Estado>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    salvaLog(null, "", "GetAllEstado", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EstadoRepository", "GetAllEstado", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Estado> GetAllEstadoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Estado] ");
                         
                    if(join)
                    {
                            
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and ESD_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Estado> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Estado,    Estado>(newStrGetAll.ToString(),
                    //        (objEstado,     ) => {
                                    
                    //            return objEstado;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "    ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Estado>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<Estado>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    salvaLog(null, "", "GetAllEstadoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EstadoRepository", "GetAllEstadoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Estado> GetAllEstadoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Estado] ");
                    
                    if(join)
                    {
                            
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and ESD_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Estado> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Estado,    Estado>(newStrGetAll.ToString(),
                    //        (objEstado,     ) => {
                                    
                    //            return objEstado;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "    ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Estado>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<Estado>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllEstadoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EstadoRepository", "GetAllEstadoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
