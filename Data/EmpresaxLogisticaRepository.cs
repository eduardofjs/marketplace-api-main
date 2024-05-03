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
    public class EmpresaxLogisticaRepository : RepositoryBase, IEmpresaxLogisticaRepository
    {

        public EmpresaxLogistica InsertEmpresaxLogistica(EmpresaxLogistica objEmpresaxLogistica)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [EmpresaxLogistica] ");
                    strInsert.Append("(EXL_EmpresaId,EXL_LogisticaId,EXL_FlagAtivo,EXL_DataCadastro)");
                    strInsert.Append(@" VALUES (@EXL_EmpresaId,@EXL_LogisticaId,@EXL_FlagAtivo,GETDATE());");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            EXL_EmpresaId = objEmpresaxLogistica.EXL_EmpresaId,
                            EXL_LogisticaId = objEmpresaxLogistica.EXL_LogisticaId,
                            EXL_FlagAtivo = objEmpresaxLogistica.EXL_FlagAtivo
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objEmpresaxLogistica.EXL_Id = queryInsert.First();

                    salvaLog(objEmpresaxLogistica.Log, "", "InsertEmpresaxLogistica", strInsert.ToString());
                    return objEmpresaxLogistica;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxLogistica.Log, "EmpresaxLogisticaRepository", "InsertEmpresaxLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objEmpresaxLogistica.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new EmpresaxLogistica();
            }
        }


        public bool UpdateEmpresaxLogistica(EmpresaxLogistica objEmpresaxLogistica)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [EmpresaxLogistica] ");
                    strUpdate.Append(@" SET EXL_EmpresaId = @EXL_EmpresaId
                        , EXL_LogisticaId = @EXL_LogisticaId
                        , EXL_FlagAtivo = @EXL_FlagAtivo
                         where EXL_Id = @EXL_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               EXL_EmpresaId = objEmpresaxLogistica.EXL_EmpresaId,
                               EXL_LogisticaId = objEmpresaxLogistica.EXL_LogisticaId,
                               EXL_FlagAtivo = objEmpresaxLogistica.EXL_FlagAtivo,
                               EXL_Id = objEmpresaxLogistica.EXL_Id
                           });
                }
                salvaLog(objEmpresaxLogistica.Log, "", "UpdateEmpresaxLogistica", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxLogistica.Log, "EmpresaxLogisticaRepository", "UpdateEmpresaxLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objEmpresaxLogistica.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarEmpresaxLogistica(int EXL_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxLogistica] set ");
                    strUpdate.Append(" EXL_FlagAtivo = @EXL_FlagAtivo ");
                    strUpdate.Append(" where EXL_Id = @EXL_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EXL_FlagAtivo = 1,
                                            EXL_Id = EXL_Id
                                        });
                }
                salvaLog(null, "", "AtivarEmpresaxLogistica", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxLogisticaRepository", "AtivarEmpresaxLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarEmpresaxLogistica(int EXL_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxLogistica] set ");
                    strUpdate.Append(" EXL_FlagAtivo = @EXL_FlagAtivo ");
                    strUpdate.Append(" where EXL_Id = @EXL_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EXL_FlagAtivo = 0,
                                            EXL_Id = EXL_Id
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxLogistica", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxLogisticaRepository", "DeletarEmpresaxLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public EmpresaxLogistica GetEmpresaxLogisticaById(int EXL_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [EmpresaxLogistica] ");
                    

                    EmpresaxLogistica obj = null;

                    if (join)
                    {
                        strGet.Append(@" join Empresa on EMP_Id = EXL_EmpresaId ");
                        strGet.Append(@" join Logistica on LGT_Id = EXL_LogisticaId ");
                        strGet.Append(" where EXL_Id = @EXL_Id");

                        obj = _db.Query<EmpresaxLogistica, Empresa, Logistica, EmpresaxLogistica>(strGet.ToString(),
                            (objEmpresaxLogistica, objEmpresa, objLogistica) => {
                                objEmpresaxLogistica.Empresa = objEmpresa;
                                objEmpresaxLogistica.Logistica = objLogistica;

                                return objEmpresaxLogistica;
                            }, new { EXL_Id = EXL_Id },
                            splitOn: " EMP_Id,LGT_Id ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" where EXL_Id = @EXL_Id");
                        obj = _db.Query<EmpresaxLogistica>(strGet.ToString(), new { EXL_Id = EXL_Id }).FirstOrDefault();
                    }

                    salvaLog(null, "", "GetEmpresaxLogisticaById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxLogisticaRepository", "GetEmpresaxLogisticaById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogistica(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxLogistica] ");
                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = EXL_EmpresaId ");
                        strGetAll.Append(@" join Logistica on LGT_Id = EXL_LogisticaId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where EXL_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<EmpresaxLogistica> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxLogistica, Empresa, Logistica, EmpresaxLogistica>(newStrGetAll.ToString(),
                            (objEmpresaxLogistica, objEmpresa, objLogistica) => {
                                objEmpresaxLogistica.Empresa = objEmpresa;
                                objEmpresaxLogistica.Logistica = objLogistica;

                                return objEmpresaxLogistica;
                            }, new { maxInstances = maxInstances },
                            splitOn: " EMP_Id,LGT_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxLogistica>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaxLogistica", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxLogisticaRepository", "GetAllEmpresaxLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogisticaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxLogistica] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = EXL_EmpresaId ");
                        strGetAll.Append(@" join Logistica on LGT_Id = EXL_LogisticaId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and EXL_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<EmpresaxLogistica> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxLogistica, Empresa, Logistica, EmpresaxLogistica>(newStrGetAll.ToString(),
                            (objEmpresaxLogistica, objEmpresa, objLogistica) => {
                                objEmpresaxLogistica.Empresa = objEmpresa;
                                objEmpresaxLogistica.Logistica = objLogistica;

                                return objEmpresaxLogistica;
                            },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,LGT_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxLogistica>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaxLogisticaByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxLogisticaRepository", "GetAllEmpresaxLogisticaByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<EmpresaxLogistica> GetAllEmpresaxLogisticaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxLogistica] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = EXL_EmpresaId ");
                        strGetAll.Append(@" join Logistica on LGT_Id = EXL_LogisticaId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and EXL_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<EmpresaxLogistica> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxLogistica, Empresa, Logistica, EmpresaxLogistica>(newStrGetAll.ToString(),
                            (objEmpresaxLogistica, objEmpresa, objLogistica) => {
                                objEmpresaxLogistica.Empresa = objEmpresa;
                                objEmpresaxLogistica.Logistica = objLogistica;

                                return objEmpresaxLogistica;
                            },
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,LGT_Id ").AsEnumerable();

                    }
                    else
                    {
                        lista = _db.Query<EmpresaxLogistica>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    
                    salvaLog(null, "", "GetAllEmpresaxLogisticaByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxLogisticaRepository", "GetAllEmpresaxLogisticaByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool DeletarEmpresaxLogisticaByEmpresa(int EXL_EmpresaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxLogistica] set ");
                    strUpdate.Append(" EXL_FlagAtivo = @EXL_FlagAtivo ");
                    strUpdate.Append(" where EXL_EmpresaId = @EXL_EmpresaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EXL_FlagAtivo = 0,
                                            EXL_EmpresaId = EXL_EmpresaId
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxLogistica", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxLogisticaRepository", "DeletarEmpresaxLogistica", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}

