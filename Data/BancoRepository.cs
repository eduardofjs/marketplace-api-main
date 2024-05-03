
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
    public class BancoRepository : RepositoryBase, IBancoRepository
    {
        
        public Banco InsertBanco(Banco objBanco)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into Banco ");
                    strInsert.Append("(BAN_Nome, BAN_CNPJ, BAN_Sigla, BAN_Ativo, BAN_NumeroBanco)");
                    strInsert.Append(@" VALUES (@BAN_Nome, @BAN_CNPJ, @BAN_Sigla, @BAN_Ativo, @BAN_NumeroBanco);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            BAN_Nome = objBanco.BAN_Nome,
                            BAN_CNPJ = objBanco.BAN_CNPJ,
                            BAN_Sigla = objBanco.BAN_Sigla,
                            BAN_Ativo = objBanco.BAN_Ativo,
                            BAN_NumeroBanco = objBanco.BAN_NumeroBanco,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objBanco.BAN_Id = queryInsert.First();

                    salvaLog(objBanco.Log, "", "InsertBanco", strInsert.ToString());
                    return objBanco;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objBanco.Log, "BancoRepository", "InsertBanco", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objBanco.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Banco();
            }
        }


        public bool UpdateBanco(Banco objBanco)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update Banco ");
                    strUpdate.Append(@" SET BAN_Nome = @BAN_Nome
                        , BAN_CNPJ = @BAN_CNPJ
                        , BAN_Sigla = @BAN_Sigla
                        , BAN_Ativo = @BAN_Ativo
                        , BAN_NumeroBanco = @BAN_NumeroBanco
                         where BAN_Id = @BAN_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            BAN_Nome = objBanco.BAN_Nome,
                            BAN_CNPJ = objBanco.BAN_CNPJ,
                            BAN_Sigla = objBanco.BAN_Sigla,
                            BAN_Ativo = objBanco.BAN_Ativo,
                            BAN_NumeroBanco = objBanco.BAN_NumeroBanco,
                            
                            BAN_Id = objBanco.BAN_Id                            
                           });
                }
                salvaLog(objBanco.Log, "", "UpdateBanco", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objBanco.Log, "BancoRepository", "UpdateBanco", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objBanco.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarBanco(int BAN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Banco set ");
                    strUpdate.Append(" BAN_Ativo = @BAN_Ativo ");
                    strUpdate.Append(" where BAN_Id = @BAN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            BAN_Ativo = 1,
                                            BAN_Id = BAN_Id
                                        });
                }
                salvaLog(null, "", "AtivarBanco", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "BancoRepository", "AtivarBanco", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarBanco(int BAN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Banco set ");
                    strUpdate.Append(" BAN_Ativo = @BAN_Ativo ");
                    strUpdate.Append(" where BAN_Id = @BAN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            BAN_Ativo = 0,
                                            BAN_Id = BAN_Id
                                        });
                }
                salvaLog(null, "", "DeletarBanco", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "BancoRepository", "DeletarBanco", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Banco GetBancoById(int BAN_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from Banco ");
                    if(join)
                    {
                              
                    }

                    strGet.Append(" where BAN_Id = @BAN_Id");                    

                    Banco obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<Banco,      Banco>(strGet.ToString(),
                        //    (objBanco,       ) => {
                        //              
                        //        return objBanco;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"      ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<Banco>(strGet.ToString(), new { BAN_Id = BAN_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetBancoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "BancoRepository", "GetBancoById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Banco> GetAllBanco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from Banco ");
                    if(join)
                    {
                              
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where BAN_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Banco> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<Banco,      Banco>(newStrGetAll.ToString(),
                        //    (objBanco,       ) => {
                        //              
                        //        return objBanco;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"      ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<Banco>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllBanco", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "BancoRepository", "GetAllBanco", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<Banco> GetAllBancoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from Banco ");
                         
                    if(join)
                    {
                              
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and BAN_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Banco> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<Banco,      Banco>(newStrGetAll.ToString(),
                        //    (objBanco,       ) => {
                        //              
                        //        return objBanco;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:"      ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<Banco>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllBancoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "BancoRepository", "GetAllBancoByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Banco> GetAllBancoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from Banco ");
                    
                    if(join)
                    {
                              
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and BAN_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Banco> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<Banco,      Banco>(newStrGetAll.ToString(),
                        //    (objBanco,       ) => {
                        //              
                        //        return objBanco;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:"      ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<Banco>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllBancoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "BancoRepository", "GetAllBancoByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
