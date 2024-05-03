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
    public class EmpresaxDocumentoRepository : RepositoryBase, IEmpresaxDocumentoRepository
    {

        public EmpresaxDocumento InsertEmpresaxDocumento(EmpresaxDocumento objEmpresaxDocumento)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [EmpresaxDocumento] ");
                    strInsert.Append("(EXD_EmpresaId,EXD_DocumentoId,EXD_FlagAtivo,EXD_DataCadastro)");
                    strInsert.Append(@" VALUES (@EXD_EmpresaId,@EXD_DocumentoId,@EXD_FlagAtivo,GETDATE());");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            EXD_EmpresaId = objEmpresaxDocumento.EXD_EmpresaId,
                            EXD_DocumentoId = objEmpresaxDocumento.EXD_DocumentoId,
                            EXD_FlagAtivo = objEmpresaxDocumento.EXD_FlagAtivo
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objEmpresaxDocumento.EXD_Id = queryInsert.First();

                    salvaLog(objEmpresaxDocumento.Log, "", "InsertEmpresaxDocumento", strInsert.ToString());
                    return objEmpresaxDocumento;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxDocumento.Log, "EmpresaxDocumentoRepository", "InsertEmpresaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objEmpresaxDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new EmpresaxDocumento();
            }
        }

        public bool UpdateEmpresaxDocumento(EmpresaxDocumento objEmpresaxDocumento)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [EmpresaxDocumento] ");
                    strUpdate.Append(@" SET EXD_EmpresaId = @EXD_EmpresaId
                        , EXD_DocumentoId = @EXD_DocumentoId
                        , EXD_FlagAtivo = @EXD_FlagAtivo
                         where EXD_Id = @EXD_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               EXD_EmpresaId = objEmpresaxDocumento.EXD_EmpresaId,
                               EXD_DocumentoId = objEmpresaxDocumento.EXD_DocumentoId,
                               EXD_FlagAtivo = objEmpresaxDocumento.EXD_FlagAtivo,
                               EXD_Id = objEmpresaxDocumento.EXD_Id
                           });
                }
                salvaLog(objEmpresaxDocumento.Log, "", "UpdateEmpresaxDocumento", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objEmpresaxDocumento.Log, "EmpresaxDocumentoRepository", "UpdateEmpresaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objEmpresaxDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarEmpresaxDocumento(int EXD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxDocumento] set ");
                    strUpdate.Append(" EXD_FlagAtivo = @EXD_FlagAtivo ");
                    strUpdate.Append(" where EXD_Id = @EXD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EXD_FlagAtivo = 1,
                                            EXD_Id = EXD_Id
                                        });
                }
                salvaLog(null, "", "AtivarEmpresaxDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxDocumentoRepository", "AtivarEmpresaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarEmpresaxDocumento(int EXD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxDocumento] set ");
                    strUpdate.Append(" EXD_FlagAtivo = @EXD_FlagAtivo ");
                    strUpdate.Append(" where EXD_Id = @EXD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EXD_FlagAtivo = 0,
                                            EXD_Id = EXD_Id
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxDocumentoRepository", "DeletarEmpresaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public EmpresaxDocumento GetEmpresaxDocumentoById(int EXD_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [EmpresaxDocumento] ");

                    EmpresaxDocumento obj = null;

                    if (join)
                    {
                        strGet.Append(@" join Empresa on EMP_Id = EXD_EmpresaId ");
                        strGet.Append(@" join Documento on DOC_Id = EXD_DocumentoId ");
                        strGet.Append(" where EXD_Id = @EXD_Id");

                        obj = _db.Query<EmpresaxDocumento, Empresa, Documento, EmpresaxDocumento>(strGet.ToString(),
                            (objEmpresaxDocumento, objEmpresa, objDocumento) => {
                                objEmpresaxDocumento.Empresa = objEmpresa;
                                objEmpresaxDocumento.Documento = objDocumento;

                                return objEmpresaxDocumento;
                            }, new { EXD_Id = EXD_Id },
                            splitOn: " EMP_Id,DOC_Id ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" where EXD_Id = @EXD_Id");
                        obj = _db.Query<EmpresaxDocumento>(strGet.ToString(), new { EXD_Id = EXD_Id }).FirstOrDefault();
                    }

                    salvaLog(null, "", "GetEmpresaxDocumentoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxDocumentoRepository", "GetEmpresaxDocumentoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxDocumento> GetAllEmpresaxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxDocumento] ");
                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = EXD_EmpresaId ");
                        strGetAll.Append(@" join Documento on DOC_Id = EXD_DocumentoId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where EXD_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<EmpresaxDocumento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxDocumento, Empresa, Documento, EmpresaxDocumento>(newStrGetAll.ToString(),
                            (objEmpresaxDocumento, objEmpresa, objDocumento) => {
                                objEmpresaxDocumento.Empresa = objEmpresa;
                                objEmpresaxDocumento.Documento = objDocumento;

                                return objEmpresaxDocumento;
                            }, new { maxInstances = maxInstances },
                            splitOn: " EMP_Id,DOC_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxDocumento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    
                    salvaLog(null, "", "GetAllEmpresaxDocumento", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxDocumentoRepository", "GetAllEmpresaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<EmpresaxDocumento> GetAllEmpresaxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxDocumento] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = EXD_EmpresaId ");
                        strGetAll.Append(@" join Documento on DOC_Id = EXD_DocumentoId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and EXD_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<EmpresaxDocumento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxDocumento, Empresa, Documento, EmpresaxDocumento>(newStrGetAll.ToString(),
                            (objEmpresaxDocumento, objEmpresa, objDocumento) => {
                                objEmpresaxDocumento.Empresa = objEmpresa;
                                objEmpresaxDocumento.Documento = objDocumento;

                                return objEmpresaxDocumento;
                            },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,DOC_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<EmpresaxDocumento>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    
                    salvaLog(null, "", "GetAllEmpresaxDocumentoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxDocumentoRepository", "GetAllEmpresaxDocumentoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<EmpresaxDocumento> GetAllEmpresaxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [EmpresaxDocumento] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Empresa on EMP_Id = EXD_EmpresaId ");
                        strGetAll.Append(@" join Documento on DOC_Id = EXD_DocumentoId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and EXD_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<EmpresaxDocumento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<EmpresaxDocumento, Empresa, Documento, EmpresaxDocumento>(newStrGetAll.ToString(),
                            (objEmpresaxDocumento, objEmpresa, objDocumento) => {
                                objEmpresaxDocumento.Empresa = objEmpresa;
                                objEmpresaxDocumento.Documento = objDocumento;

                                return objEmpresaxDocumento;
                            }, new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,DOC_Id ").AsEnumerable();

                    }
                    else
                    {
                        lista = _db.Query<EmpresaxDocumento>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    
                    salvaLog(null, "", "GetAllEmpresaxDocumentoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxDocumentoRepository", "GetAllEmpresaxDocumentoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool DeletarEmpresaxDocumentoByEmpresa(int EXD_EmpresaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [EmpresaxDocumento] set ");
                    strUpdate.Append(" EXD_FlagAtivo = @EXD_FlagAtivo ");
                    strUpdate.Append(" where EXD_EmpresaId = @EXD_EmpresaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EXD_FlagAtivo = 0,
                                            EXD_EmpresaId = EXD_EmpresaId
                                        });
                }
                salvaLog(null, "", "DeletarEmpresaxDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaxDocumentoRepository", "DeletarEmpresaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}
