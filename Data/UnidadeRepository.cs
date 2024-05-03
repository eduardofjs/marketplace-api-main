
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
    public class UnidadeRepository : RepositoryBase, IUnidadeRepository
    {
        
        public Unidade InsertUnidade(Unidade objUnidade)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into Unidade ");
                    strInsert.Append("(UNI_RazaoSocial, UNI_NomeFantasia, UNI_CNPJ, UNI_EnderecoId, UNI_Telefone, UNI_Contato, UNI_ImagePath, UNI_Site, UNI_FlagAtivo)");
                    strInsert.Append(@" VALUES (@UNI_RazaoSocial, @UNI_NomeFantasia, @UNI_CNPJ, @UNI_EnderecoId, @UNI_Telefone, @UNI_Contato, @UNI_ImagePath, @UNI_Site, @UNI_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            UNI_RazaoSocial = objUnidade.UNI_RazaoSocial,
                            UNI_NomeFantasia = objUnidade.UNI_NomeFantasia,
                            UNI_CNPJ = objUnidade.UNI_CNPJ,
                            UNI_EnderecoId = objUnidade.UNI_EnderecoId,
                            UNI_Telefone = objUnidade.UNI_Telefone,
                            UNI_Contato = objUnidade.UNI_Contato,
                            UNI_ImagePath = objUnidade.UNI_ImagePath,
                            UNI_Site = objUnidade.UNI_Site,
                            UNI_FlagAtivo = objUnidade.UNI_FlagAtivo,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objUnidade.UNI_Id = queryInsert.First();

                    salvaLog(objUnidade.Log, "", "InsertUnidade", strInsert.ToString());
                    return objUnidade;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objUnidade.Log, "UnidadeRepository", "InsertUnidade", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objUnidade.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Unidade();
            }
        }


        public bool UpdateUnidade(Unidade objUnidade)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update Unidade ");
                    strUpdate.Append(@" SET UNI_RazaoSocial = @UNI_RazaoSocial
                        , UNI_NomeFantasia = @UNI_NomeFantasia
                        , UNI_CNPJ = @UNI_CNPJ
                        , UNI_EnderecoId = @UNI_EnderecoId
                        , UNI_Telefone = @UNI_Telefone
                        , UNI_Contato = @UNI_Contato
                        , UNI_ImagePath = @UNI_ImagePath
                        , UNI_Site = @UNI_Site
                        , UNI_FlagAtivo = @UNI_FlagAtivo
                         where UNI_Id = @UNI_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            UNI_RazaoSocial = objUnidade.UNI_RazaoSocial,
                            UNI_NomeFantasia = objUnidade.UNI_NomeFantasia,
                            UNI_CNPJ = objUnidade.UNI_CNPJ,
                            UNI_EnderecoId = objUnidade.UNI_EnderecoId,
                            UNI_Telefone = objUnidade.UNI_Telefone,
                            UNI_Contato = objUnidade.UNI_Contato,
                            UNI_ImagePath = objUnidade.UNI_ImagePath,
                            UNI_Site = objUnidade.UNI_Site,
                            UNI_FlagAtivo = objUnidade.UNI_FlagAtivo,
                            
                            UNI_Id = objUnidade.UNI_Id                            
                           });
                }
                salvaLog(objUnidade.Log, "", "UpdateUnidade", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objUnidade.Log, "UnidadeRepository", "UpdateUnidade", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objUnidade.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarUnidade(int UNI_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Unidade set ");
                    strUpdate.Append(" UNI_Ativo = @UNI_Ativo ");
                    strUpdate.Append(" where UNI_Id = @UNI_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            UNI_Ativo = 1,
                                            UNI_Id = UNI_Id
                                        });
                }
                salvaLog(null, "", "AtivarUnidade", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadeRepository", "AtivarUnidade", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarUnidade(int UNI_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Unidade set ");
                    strUpdate.Append(" UNI_Ativo = @UNI_Ativo ");
                    strUpdate.Append(" where UNI_Id = @UNI_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            UNI_Ativo = 0,
                                            UNI_Id = UNI_Id
                                        });
                }
                salvaLog(null, "", "DeletarUnidade", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadeRepository", "DeletarUnidade", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Unidade GetUnidadeById(int UNI_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from Unidade ");
                    if(join)
                    {
                            strGet.Append(@" join Endereco on UNI_EnderecoId = END_Id ");
                             
                    }

                    strGet.Append(" where UNI_Id = @UNI_Id");                    

                    Unidade obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<Unidade,    Endereco,      Unidade>(strGet.ToString(),
                        //    (objUnidade,     objEndereco,     ) => {
                        //            objUnidade.Endereco = objEndereco;
                        //             
                        //        return objUnidade;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"    END_Id,     ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<Unidade>(strGet.ToString(), new { UNI_Id = UNI_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetUnidadeById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadeRepository", "GetUnidadeById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Unidade> GetAllUnidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from Unidade ");
                    if(join)
                    {
                            strGetAll.Append(@" join Endereco on UNI_EnderecoId = END_Id ");
                             
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where UNI_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Unidade> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<Unidade,    Endereco,      Unidade>(newStrGetAll.ToString(),
                        //    (objUnidade,     objEndereco,     ) => {
                        //            objUnidade.Endereco = objEndereco;
                        //             
                        //        return objUnidade;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"    END_Id,     ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<Unidade>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllUnidade", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadeRepository", "GetAllUnidade", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<Unidade> GetAllUnidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from Unidade ");
                         
                    if(join)
                    {
                            strGetAll.Append(@" join Endereco on UNI_EnderecoId = END_Id ");
                             
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and UNI_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Unidade> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<Unidade,    Endereco,      Unidade>(newStrGetAll.ToString(),
                        //    (objUnidade,     objEndereco,     ) => {
                        //            objUnidade.Endereco = objEndereco;
                        //             
                        //        return objUnidade;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:"    END_Id,     ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<Unidade>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllUnidadeByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadeRepository", "GetAllUnidadeByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Unidade> GetAllUnidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from Unidade ");
                    
                    if(join)
                    {
                            strGetAll.Append(@" join Endereco on UNI_EnderecoId = END_Id ");
                             
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and UNI_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Unidade> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<Unidade,    Endereco,      Unidade>(newStrGetAll.ToString(),
                        //    (objUnidade,     objEndereco,     ) => {
                        //            objUnidade.Endereco = objEndereco;
                        //             
                        //        return objUnidade;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:"    END_Id,     ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<Unidade>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllUnidadeByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "UnidadeRepository", "GetAllUnidadeByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
