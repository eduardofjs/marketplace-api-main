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
    public class EmpresaxProdutoRepository : RepositoryBase, IEmpresaxProdutoRepository
    {

        public EmpresaxProduto InsertEmpresaxProduto(EmpresaxProduto objEmpresaxProduto)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [EmpresaxProduto] ");
                    strInsert.Append("(EXP_EmpresaId,EXP_ProdutoId,EXP_FlagAtivo,EXP_DataCadastro)");
                    strInsert.Append(@" VALUES (@EXP_EmpresaId,@EXP_ProdutoId,@EXP_FlagAtivo,GETDATE());");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            EXP_EmpresaId = objEmpresaxProduto.EXP_EmpresaId,
                            EXP_ProdutoId = objEmpresaxProduto.EXP_ProdutoId,
                            EXP_FlagAtivo = objEmpresaxProduto.EXP_FlagAtivo
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objEmpresaxProduto.EXP_Id = queryInsert.First();

                    salvaLog(objEmpresaxProduto.Log, "", "InsertEmpresaxProduto", strInsert.ToString());
                    return objEmpresaxProduto;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxProduto.Log, "EmpresaxProdutoRepository", "InsertEmpresaxProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objEmpresaxProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new EmpresaxProduto();
            }
        }


        public bool UpdateEmpresaxProduto(EmpresaxProduto objEmpresaxProduto)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [EmpresaxProduto] ");
                    strUpdate.Append(@" SET EXP_EmpresaId = @EXP_EmpresaId
                        , EXP_ProdutoId = @EXP_ProdutoId
                        , EXP_FlagAtivo = @EXP_FlagAtivo
                         where EXP_Id = @EXP_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               EXP_EmpresaId = objEmpresaxProduto.EXP_EmpresaId,
                               EXP_ProdutoId = objEmpresaxProduto.EXP_ProdutoId,
                               EXP_FlagAtivo = objEmpresaxProduto.EXP_FlagAtivo,
                               EXP_Id = objEmpresaxProduto.EXP_Id
                           });
                }
                salvaLog(objEmpresaxProduto.Log, "", "UpdateEmpresaxProduto", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxProduto.Log, "EmpresaxProdutoRepository", "UpdateEmpresaxProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objEmpresaxProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarEmpresaxProduto(int EXP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxProduto] set ");
                    strUpdate.Append(" EXP_FlagAtivo = @EXP_FlagAtivo ");
                    strUpdate.Append(" where EXP_Id = @EXP_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EXP_FlagAtivo = 1,
                                            EXP_Id = EXP_Id
                                        });
                }
                salvaLog(null, "", "AtivarEmpresaxProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxProdutoRepository", "AtivarEmpresaxProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarEmpresaxProduto(int EXP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxProduto] set ");
                    strUpdate.Append(" EXP_FlagAtivo = @EXP_FlagAtivo ");
                    strUpdate.Append(" where EXP_Id = @EXP_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EXP_FlagAtivo = 0,
                                            EXP_Id = EXP_Id
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxProdutoRepository", "DeletarEmpresaxProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public EmpresaxProduto GetEmpresaxProdutoById(int EXP_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [EmpresaxProduto] ");


                    EmpresaxProduto obj = null;

                    if (join)
                    {
                        strGet.Append(@" join Empresa on EMP_Id = EXP_EmpresaId ");
                        strGet.Append(@" join Produto on PDT_Id = EXP_ProdutoId ");
                        strGet.Append(" where EXP_Id = @EXP_Id");

                        obj = _db.Query<EmpresaxProduto, Empresa, Produto, EmpresaxProduto>(strGet.ToString(),
                            (objEmpresaxProduto, objEmpresa, objProduto) => {
                                objEmpresaxProduto.Empresa = objEmpresa;
                                objEmpresaxProduto.Produto = objProduto;

                                return objEmpresaxProduto;
                            },
                            new
                            {
                                EXP_Id = EXP_Id
                            },
                            splitOn: " EMP_Id,PDT_Id ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" where EXP_Id = @EXP_Id");
                        obj = _db.Query<EmpresaxProduto>(strGet.ToString(), new { EXP_Id = EXP_Id }).FirstOrDefault();
                    }

                    salvaLog(null, "", "GetEmpresaxProdutoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxProdutoRepository", "GetEmpresaxProdutoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxProduto> GetAllEmpresaxProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxProduto] ");
                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = EXP_EmpresaId ");
                        strGetAll.Append(@" join Produto on PDT_Id = EXP_ProdutoId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where EXP_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<EmpresaxProduto> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxProduto, Empresa, Produto, EmpresaxProduto>(newStrGetAll.ToString(),
                            (objEmpresaxProduto, objEmpresa, objProduto) => {
                                objEmpresaxProduto.Empresa = objEmpresa;
                                objEmpresaxProduto.Produto = objProduto;

                                return objEmpresaxProduto;
                            }, new { maxInstances = maxInstances },
                            splitOn: " EMP_Id,PDT_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxProduto>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaxProduto", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxProdutoRepository", "GetAllEmpresaxProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxProduto> GetAllEmpresaxProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxProduto] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = EXP_EmpresaId ");
                        strGetAll.Append(@" join Produto on PDT_Id = EXP_ProdutoId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and EXP_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<EmpresaxProduto> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxProduto, Empresa, Produto, EmpresaxProduto>(newStrGetAll.ToString(),
                            (objEmpresaxProduto, objEmpresa, objProduto) => {
                                objEmpresaxProduto.Empresa = objEmpresa;
                                objEmpresaxProduto.Produto = objProduto;

                                return objEmpresaxProduto;
                            },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,PDT_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxProduto>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaxProdutoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxProdutoRepository", "GetAllEmpresaxProdutoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<EmpresaxProduto> GetAllEmpresaxProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxProduto] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = EXP_EmpresaId ");
                        strGetAll.Append(@" join Produto on PDT_Id = EXP_ProdutoId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and EXP_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<EmpresaxProduto> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxProduto, Empresa, Produto, EmpresaxProduto>(newStrGetAll.ToString(),
                            (objEmpresaxProduto, objEmpresa, objProduto) => {
                                objEmpresaxProduto.Empresa = objEmpresa;
                                objEmpresaxProduto.Produto = objProduto;

                                return objEmpresaxProduto;
                            },
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,PDT_Id ").AsEnumerable();

                    }
                    else
                    {
                        lista = _db.Query<EmpresaxProduto>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaxProdutoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxProdutoRepository", "GetAllEmpresaxProdutoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool DeletarEmpresaxProdutoByEmpresa(int EXP_EmpresaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxProduto] set ");
                    strUpdate.Append(" EXP_FlagAtivo = @EXP_FlagAtivo ");
                    strUpdate.Append(" where EXP_EmpresaId = @EXP_EmpresaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EXP_FlagAtivo = 0,
                                            EXP_EmpresaId = EXP_EmpresaId
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxProdutoRepository", "DeletarEmpresaxProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}

