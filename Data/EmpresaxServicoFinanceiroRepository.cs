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
    public class EmpresaxServicoFinanceiroRepository : RepositoryBase, IEmpresaxServicoFinanceiroRepository
    {

        public EmpresaxServicoFinanceiro InsertEmpresaxServicoFinanceiro(EmpresaxServicoFinanceiro objEmpresaxServicoFinanceiro)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [EmpresaxServicoFinanceiro] ");
                    strInsert.Append("(ESF_EmpresaId,ESF_ServicoFinanceiroId,ESF_FlagAtivo,ESF_DataCadastro)");
                    strInsert.Append(@" VALUES (@ESF_EmpresaId,@ESF_ServicoFinanceiroId,@ESF_FlagAtivo,GETDATE());");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            ESF_EmpresaId = objEmpresaxServicoFinanceiro.ESF_EmpresaId,
                            ESF_ServicoFinanceiroId = objEmpresaxServicoFinanceiro.ESF_ServicoFinanceiroId,
                            ESF_FlagAtivo = objEmpresaxServicoFinanceiro.ESF_FlagAtivo
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objEmpresaxServicoFinanceiro.ESF_Id = queryInsert.First();

                    salvaLog(objEmpresaxServicoFinanceiro.Log, "", "InsertEmpresaxServicoFinanceiro", strInsert.ToString());
                    return objEmpresaxServicoFinanceiro;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxServicoFinanceiro.Log, "EmpresaxServicoFinanceiroRepository", "InsertEmpresaxServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objEmpresaxServicoFinanceiro.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new EmpresaxServicoFinanceiro();
            }
        }

        public bool UpdateEmpresaxServicoFinanceiro(EmpresaxServicoFinanceiro objEmpresaxServicoFinanceiro)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [EmpresaxServicoFinanceiro] ");
                    strUpdate.Append(@" SET ESF_EmpresaId = @ESF_EmpresaId
                        , ESF_ServicoFinanceiroId = @ESF_ServicoFinanceiroId
                        , ESF_FlagAtivo = @ESF_FlagAtivo
                         where ESF_Id = @ESF_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               ESF_EmpresaId = objEmpresaxServicoFinanceiro.ESF_EmpresaId,
                               ESF_ServicoFinanceiroId = objEmpresaxServicoFinanceiro.ESF_ServicoFinanceiroId,
                               ESF_FlagAtivo = objEmpresaxServicoFinanceiro.ESF_FlagAtivo,
                               ESF_Id = objEmpresaxServicoFinanceiro.ESF_Id
                           });
                }
                salvaLog(objEmpresaxServicoFinanceiro.Log, "", "UpdateEmpresaxServicoFinanceiro", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxServicoFinanceiro.Log, "EmpresaxServicoFinanceiroRepository", "UpdateEmpresaxServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objEmpresaxServicoFinanceiro.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarEmpresaxServicoFinanceiro(int ESF_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxServicoFinanceiro] set ");
                    strUpdate.Append(" ESF_FlagAtivo = @ESF_FlagAtivo ");
                    strUpdate.Append(" where ESF_Id = @ESF_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ESF_FlagAtivo = 1,
                                            ESF_Id = ESF_Id
                                        });
                }
                salvaLog(null, "", "AtivarEmpresaxServicoFinanceiro", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoFinanceiroRepository", "AtivarEmpresaxServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarEmpresaxServicoFinanceiro(int ESF_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxServicoFinanceiro] set ");
                    strUpdate.Append(" ESF_FlagAtivo = @ESF_FlagAtivo ");
                    strUpdate.Append(" where ESF_Id = @ESF_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ESF_FlagAtivo = 0,
                                            ESF_Id = ESF_Id
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxServicoFinanceiro", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoFinanceiroRepository", "DeletarEmpresaxServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public EmpresaxServicoFinanceiro GetEmpresaxServicoFinanceiroById(int ESF_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [EmpresaxServicoFinanceiro] ");                    

                    EmpresaxServicoFinanceiro obj = null;

                    if (join)
                    {
                        strGet.Append(@" join Empresa on EMP_Id = ESF_EmpresaId ");
                        strGet.Append(@" join ServicoFinanceiro on SEF_Id = ESF_ServicoFinanceiroId ");
                        strGet.Append(" where ESF_Id = @ESF_Id");

                        obj = _db.Query<EmpresaxServicoFinanceiro, Empresa, ServicoFinanceiro, EmpresaxServicoFinanceiro>(strGet.ToString(),
                            (objEmpresaxServicoFinanceiro, objEmpresa, objServicoFinanceiro) => {
                                objEmpresaxServicoFinanceiro.Empresa = objEmpresa;
                                objEmpresaxServicoFinanceiro.ServicoFinanceiro = objServicoFinanceiro;

                                return objEmpresaxServicoFinanceiro;
                            }, new { ESF_Id = ESF_Id },
                            splitOn: " EMP_Id,SEF_Id ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" where ESF_Id = @ESF_Id");
                        obj = _db.Query<EmpresaxServicoFinanceiro>(strGet.ToString(), new { ESF_Id = ESF_Id }).FirstOrDefault();
                    }

                    salvaLog(null, "", "GetEmpresaxServicoFinanceiroById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoFinanceiroRepository", "GetEmpresaxServicoFinanceiroById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiro(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxServicoFinanceiro] ");
                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = ESF_EmpresaId ");
                        strGetAll.Append(@" join ServicoFinanceiro on SEF_Id = ESF_ServicoFinanceiroId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where ESF_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<EmpresaxServicoFinanceiro> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxServicoFinanceiro, Empresa, ServicoFinanceiro, EmpresaxServicoFinanceiro>(newStrGetAll.ToString(),
                            (objEmpresaxServicoFinanceiro, objEmpresa, objServicoFinanceiro) => {
                                objEmpresaxServicoFinanceiro.Empresa = objEmpresa;
                                objEmpresaxServicoFinanceiro.ServicoFinanceiro = objServicoFinanceiro;

                                return objEmpresaxServicoFinanceiro;
                            }, new { maxInstances = maxInstances },
                            splitOn: " EMP_Id,SEF_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxServicoFinanceiro>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }


                    salvaLog(null, "", "GetAllEmpresaxServicoFinanceiro", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoFinanceiroRepository", "GetAllEmpresaxServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiroByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxServicoFinanceiro] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = ESF_EmpresaId ");
                        strGetAll.Append(@" join ServicoFinanceiro on SEF_Id = ESF_ServicoFinanceiroId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and ESF_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<EmpresaxServicoFinanceiro> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxServicoFinanceiro, Empresa, ServicoFinanceiro, EmpresaxServicoFinanceiro>(newStrGetAll.ToString(),
                            (objEmpresaxServicoFinanceiro, objEmpresa, objServicoFinanceiro) => {
                                objEmpresaxServicoFinanceiro.Empresa = objEmpresa;
                                objEmpresaxServicoFinanceiro.ServicoFinanceiro = objServicoFinanceiro;

                                return objEmpresaxServicoFinanceiro;
                            },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,SEF_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxServicoFinanceiro>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaxServicoFinanceiroByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoFinanceiroRepository", "GetAllEmpresaxServicoFinanceiroByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<EmpresaxServicoFinanceiro> GetAllEmpresaxServicoFinanceiroByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxServicoFinanceiro] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = ESF_EmpresaId ");
                        strGetAll.Append(@" join ServicoFinanceiro on SEF_Id = ESF_ServicoFinanceiroId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and ESF_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<EmpresaxServicoFinanceiro> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxServicoFinanceiro, Empresa, ServicoFinanceiro, EmpresaxServicoFinanceiro>(newStrGetAll.ToString(),
                            (objEmpresaxServicoFinanceiro, objEmpresa, objServicoFinanceiro) => {
                                objEmpresaxServicoFinanceiro.Empresa = objEmpresa;
                                objEmpresaxServicoFinanceiro.ServicoFinanceiro = objServicoFinanceiro;

                                return objEmpresaxServicoFinanceiro;
                            }, new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,SEF_Id ").AsEnumerable();

                    }
                    else
                    {
                        lista = _db.Query<EmpresaxServicoFinanceiro>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaxServicoFinanceiroByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoFinanceiroRepository", "GetAllEmpresaxServicoFinanceiroByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool DeletarEmpresaxServicoFinanceiroByEmpresa(int ESF_EmpresaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxServicoFinanceiro] set ");
                    strUpdate.Append(" ESF_FlagAtivo = @ESF_FlagAtivo ");
                    strUpdate.Append(" where ESF_EmpresaId = @ESF_EmpresaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ESF_FlagAtivo = 0,
                                            ESF_EmpresaId = ESF_EmpresaId
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxServicoFinanceiro", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoFinanceiroRepository", "DeletarEmpresaxServicoFinanceiro", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}

