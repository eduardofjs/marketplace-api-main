
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
    public class SexoRepository : RepositoryBase, ISexoRepository
    {
        
        public Sexo InsertSexo(Sexo objSexo)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Sexo] ");
                    strInsert.Append("(SEX_Nome, SEX_Sigla, SEX_Ativo)");
                    strInsert.Append(@" VALUES (@SEX_Nome, @SEX_Sigla, @SEX_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            SEX_Nome = objSexo.SEX_Nome,
                            SEX_Sigla = objSexo.SEX_Sigla,
                            SEX_Ativo = 1,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objSexo.SEX_Id = queryInsert.First();

                    salvaLog(objSexo.Log, "", "InsertSexo", strInsert.ToString());
                    return objSexo;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objSexo.Log, "SexoRepository", "InsertSexo", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objSexo.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Sexo();
            }
        }


        public bool UpdateSexo(Sexo objSexo)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Sexo] ");
                    strUpdate.Append(@" SET SEX_Nome = @SEX_Nome
                        , SEX_Sigla = @SEX_Sigla
                        , SEX_Ativo = @SEX_Ativo
                         where SEX_Id = @SEX_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            SEX_Nome = objSexo.SEX_Nome,
                            SEX_Sigla = objSexo.SEX_Sigla,
                            SEX_Ativo = 1,
                            
                            SEX_Id = objSexo.SEX_Id                            
                           });
                }
                salvaLog(objSexo.Log, "", "UpdateSexo", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objSexo.Log, "SexoRepository", "UpdateSexo", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objSexo.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarSexo(int SEX_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Sexo] set ");
                    strUpdate.Append(" SEX_Ativo = @SEX_Ativo ");
                    strUpdate.Append(" where SEX_Id = @SEX_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SEX_Ativo = 1,
                                            SEX_Id = SEX_Id
                                        });
                }
                salvaLog(null, "", "AtivarSexo", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "SexoRepository", "AtivarSexo", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarSexo(int SEX_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Sexo] set ");
                    strUpdate.Append(" SEX_Ativo = @SEX_Ativo ");
                    strUpdate.Append(" where SEX_Id = @SEX_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SEX_Ativo = 0,
                                            SEX_Id = SEX_Id
                                        });
                }
                salvaLog(null, "", "DeletarSexo", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "SexoRepository", "DeletarSexo", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Sexo GetSexoById(int SEX_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT SEX_Id, SEX_Nome, SEX_Sigla, SEX_Ativo from [Sexo] ");
                    strGet.Append(" where SEX_Id = @SEX_Id");

                    var obj = _db.Query<Sexo>(strGet.ToString(), new { SEX_Id = SEX_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                                  
                    }

                    salvaLog(null, "", "GetSexoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "SexoRepository", "GetSexoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Sexo> GetAllSexo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Sexo] ");
                    if(join)
                    {
                            
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where SEX_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Sexo> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Sexo,    Sexo>(newStrGetAll.ToString(),
                    //        (objSexo,     ) => {
                                    
                    //            return objSexo;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "    ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Sexo>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}
                    lista = _db.Query<Sexo>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    salvaLog(null, "", "GetAllSexo", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "SexoRepository", "GetAllSexo", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Sexo> GetAllSexoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Sexo] ");
                         
                    if(join)
                    {
                            
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SEX_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Sexo> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Sexo,    Sexo>(newStrGetAll.ToString(),
                    //        (objSexo,     ) => {
                                    
                    //            return objSexo;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "    ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Sexo>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<Sexo>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    salvaLog(null, "", "GetAllSexoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "SexoRepository", "GetAllSexoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Sexo> GetAllSexoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Sexo] ");
                    
                    if(join)
                    {
                            
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SEX_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Sexo> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Sexo,    Sexo>(newStrGetAll.ToString(),
                    //        (objSexo,     ) => {
                                    
                    //            return objSexo;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "    ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Sexo>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<Sexo>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllSexoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "SexoRepository", "GetAllSexoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
