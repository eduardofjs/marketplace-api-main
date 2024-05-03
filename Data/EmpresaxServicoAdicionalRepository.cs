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
    public class EmpresaxServicoAdicionalRepository : RepositoryBase, IEmpresaxServicoAdicionalRepository
    {

        public EmpresaxServicoAdicional InsertEmpresaxServicoAdicional(EmpresaxServicoAdicional objEmpresaxServicoAdicional)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [EmpresaxServicoAdicional] ");
                    strInsert.Append("(ESA_EmpresaId,ESA_ServicoAdicionalId,ESA_FlagAtivo,ESA_DataCadastro)");
                    strInsert.Append(@" VALUES (@ESA_EmpresaId,@ESA_ServicoAdicionalId,@ESA_FlagAtivo,GETDATE());");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            ESA_EmpresaId = objEmpresaxServicoAdicional.ESA_EmpresaId,
                            ESA_ServicoAdicionalId = objEmpresaxServicoAdicional.ESA_ServicoAdicionalId,
                            ESA_FlagAtivo = objEmpresaxServicoAdicional.ESA_FlagAtivo
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objEmpresaxServicoAdicional.ESA_Id = queryInsert.First();

                    salvaLog(objEmpresaxServicoAdicional.Log, "", "InsertEmpresaxServicoAdicional", strInsert.ToString());
                    return objEmpresaxServicoAdicional;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxServicoAdicional.Log, "EmpresaxServicoAdicionalRepository", "InsertEmpresaxServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objEmpresaxServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new EmpresaxServicoAdicional();
            }
        }


        public bool UpdateEmpresaxServicoAdicional(EmpresaxServicoAdicional objEmpresaxServicoAdicional)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [EmpresaxServicoAdicional] ");
                    strUpdate.Append(@" SET ESA_EmpresaId = @ESA_EmpresaId
                        , ESA_ServicoAdicionalId = @ESA_ServicoAdicionalId
                        , ESA_FlagAtivo = @ESA_FlagAtivo
                         where ESA_Id = @ESA_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               ESA_EmpresaId = objEmpresaxServicoAdicional.ESA_EmpresaId,
                               ESA_ServicoAdicionalId = objEmpresaxServicoAdicional.ESA_ServicoAdicionalId,
                               ESA_FlagAtivo = objEmpresaxServicoAdicional.ESA_FlagAtivo,
                               ESA_Id = objEmpresaxServicoAdicional.ESA_Id
                           });
                }
                salvaLog(objEmpresaxServicoAdicional.Log, "", "UpdateEmpresaxServicoAdicional", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxServicoAdicional.Log, "EmpresaxServicoAdicionalRepository", "UpdateEmpresaxServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objEmpresaxServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarEmpresaxServicoAdicional(int ESA_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxServicoAdicional] set ");
                    strUpdate.Append(" ESA_FlagAtivo = @ESA_FlagAtivo ");
                    strUpdate.Append(" where ESA_Id = @ESA_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ESA_FlagAtivo = 1,
                                            ESA_Id = ESA_Id
                                        });
                }
                salvaLog(null, "", "AtivarEmpresaxServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoAdicionalRepository", "AtivarEmpresaxServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarEmpresaxServicoAdicional(int ESA_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxServicoAdicional] set ");
                    strUpdate.Append(" ESA_FlagAtivo = @ESA_FlagAtivo ");
                    strUpdate.Append(" where ESA_Id = @ESA_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ESA_FlagAtivo = 0,
                                            ESA_Id = ESA_Id
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoAdicionalRepository", "DeletarEmpresaxServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public EmpresaxServicoAdicional GetEmpresaxServicoAdicionalById(int ESA_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [EmpresaxServicoAdicional] ");                    

                    EmpresaxServicoAdicional obj = null;

                    if (obj != null && join)
                    {
                        strGet.Append(@" join Empresa on EMP_Id = ESA_EmpresaId ");
                        strGet.Append(@" join ServicoAdicional on SEA_Id = ESA_ServicoAdicionalId ");
                        strGet.Append(" where ESA_Id = @ESA_Id");

                        obj = _db.Query<EmpresaxServicoAdicional, Empresa, ServicoAdicional, EmpresaxServicoAdicional>(strGet.ToString(),
                            (objEmpresaxDocumento, objEmpresa, objServicoAdicional) => {
                                objEmpresaxDocumento.Empresa = objEmpresa;
                                objEmpresaxDocumento.ServicoAdicional = objServicoAdicional;

                                return objEmpresaxDocumento;
                            }, new { ESA_Id = ESA_Id },
                            splitOn: " EMP_Id,SEA_Id ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" where ESA_Id = @ESA_Id");
                        obj = _db.Query<EmpresaxServicoAdicional>(strGet.ToString(), new { ESA_Id = ESA_Id }).FirstOrDefault();
                    }

                    salvaLog(null, "", "GetEmpresaxServicoAdicionalById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoAdicionalRepository", "GetEmpresaxServicoAdicionalById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxServicoAdicional] ");
                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = ESA_EmpresaId ");
                        strGetAll.Append(@" join ServicoAdicional on SEA_Id = ESA_ServicoAdicionalId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where ESA_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<EmpresaxServicoAdicional> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxServicoAdicional, Empresa, ServicoAdicional, EmpresaxServicoAdicional>(newStrGetAll.ToString(),
                            (objEmpresaxDocumento, objEmpresa, objServicoAdicional) => {
                                objEmpresaxDocumento.Empresa = objEmpresa;
                                objEmpresaxDocumento.ServicoAdicional = objServicoAdicional;

                                return objEmpresaxDocumento;
                            }, new { maxInstances = maxInstances },
                            splitOn: " EMP_Id,SEA_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxServicoAdicional>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaxServicoAdicional", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoAdicionalRepository", "GetAllEmpresaxServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxServicoAdicional] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = ESA_EmpresaId ");
                        strGetAll.Append(@" join ServicoAdicional on SEA_Id = ESA_ServicoAdicionalId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and ESA_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<EmpresaxServicoAdicional> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxServicoAdicional, Empresa, ServicoAdicional, EmpresaxServicoAdicional>(newStrGetAll.ToString(),
                            (objEmpresaxDocumento, objEmpresa, objServicoAdicional) => {
                                objEmpresaxDocumento.Empresa = objEmpresa;
                                objEmpresaxDocumento.ServicoAdicional = objServicoAdicional;

                                return objEmpresaxDocumento;
                            }, new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,SEA_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxServicoAdicional>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaxServicoAdicionalByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoAdicionalRepository", "GetAllEmpresaxServicoAdicionalByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<EmpresaxServicoAdicional> GetAllEmpresaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxServicoAdicional] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = ESA_EmpresaId ");
                        strGetAll.Append(@" join ServicoAdicional on SEA_Id = ESA_ServicoAdicionalId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and ESA_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<EmpresaxServicoAdicional> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxServicoAdicional, Empresa, ServicoAdicional, EmpresaxServicoAdicional>(newStrGetAll.ToString(),
                            (objEmpresaxDocumento, objEmpresa, objServicoAdicional) => {
                                objEmpresaxDocumento.Empresa = objEmpresa;
                                objEmpresaxDocumento.ServicoAdicional = objServicoAdicional;

                                return objEmpresaxDocumento;
                            }, new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,SEA_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxServicoAdicional>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllEmpresaxServicoAdicionalByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoAdicionalRepository", "GetAllEmpresaxServicoAdicionalByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool DeletarEmpresaxServicoAdicionalByEmpresa(int ESA_EmpresaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxServicoAdicional] set ");
                    strUpdate.Append(" ESA_FlagAtivo = @ESA_FlagAtivo ");
                    strUpdate.Append(" where ESA_EmpresaId = @ESA_EmpresaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ESA_FlagAtivo = 0,
                                            ESA_EmpresaId = ESA_EmpresaId
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxServicoAdicionalRepository", "DeletarEmpresaxServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}

