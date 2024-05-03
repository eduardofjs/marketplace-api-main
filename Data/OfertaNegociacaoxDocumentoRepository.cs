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
    public class OfertaNegociacaoxDocumentoRepository : RepositoryBase, IOfertaNegociacaoxDocumentoRepository
    {

        public OfertaNegociacaoxDocumento InsertOfertaNegociacaoxDocumento(OfertaNegociacaoxDocumento objOfertaNegociacaoxDocumento)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT INTO [OfertaNegociacaoxDocumento] ");
                    strInsert.Append("(OND_OfertaNegociacaoId,OND_EmpresaId,OND_DocumentoId,OND_StatusDocumentoId,OND_FlagAtivo,OND_DataCadastro, OND_Descricao, OND_Justificativa, OND_FlagAprovado, OND_DataAtualizacao)");
                    strInsert.Append(@" VALUES (@OND_OfertaNegociacaoId, @OND_EmpresaId, @OND_DocumentoId, @OND_StatusDocumentoId, @OND_FlagAtivo, GETDATE(), @OND_Descricao, @OND_Justificativa, @OND_FlagAprovado, @OND_DataAtualizacao);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            OND_OfertaNegociacaoId = objOfertaNegociacaoxDocumento.OND_OfertaNegociacaoId,
                            OND_EmpresaId = objOfertaNegociacaoxDocumento.OND_EmpresaId,
                            OND_DocumentoId = objOfertaNegociacaoxDocumento.OND_DocumentoId,
                            OND_StatusDocumentoId = objOfertaNegociacaoxDocumento.OND_StatusDocumentoId,
                            OND_FlagAtivo = true,
                            OND_Descricao = objOfertaNegociacaoxDocumento.OND_Descricao,
                            OND_Justificativa = objOfertaNegociacaoxDocumento.OND_Justificativa,
                            OND_FlagAprovado = objOfertaNegociacaoxDocumento.OND_FlagAprovado,
                            OND_DataAtualizacao = objOfertaNegociacaoxDocumento.OND_DataAtualizacao
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objOfertaNegociacaoxDocumento.OND_Id = queryInsert.First();

                    salvaLog(objOfertaNegociacaoxDocumento.Log, "", "InsertOfertaNegociacaoxDocumento", strInsert.ToString());
                    return objOfertaNegociacaoxDocumento;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objOfertaNegociacaoxDocumento.Log, "OfertaNegociacaoxDocumentoRepository", "InsertOfertaNegociacaoxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objOfertaNegociacaoxDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new OfertaNegociacaoxDocumento();
            }
        }

        public bool UpdateOfertaNegociacaoxDocumento(OfertaNegociacaoxDocumento objOfertaNegociacaoxDocumento)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" UPDATE [OfertaNegociacaoxDocumento] ");
                    strUpdate.Append(@" SET OND_DocumentoId = @OND_DocumentoId
                        , OND_StatusDocumentoId = @OND_StatusDocumentoId
                        , OND_FlagAtivo = @OND_FlagAtivo
                        , OND_Descricao = @OND_Descricao
                        , OND_Justificativa = @OND_Justificativa
                        , OND_FlagAprovado = @OND_FlagAprovado
                        , OND_DataAtualizacao = GETDATE()
                         WHERE OND_Id = @OND_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {                              
                               OND_DocumentoId = objOfertaNegociacaoxDocumento.OND_DocumentoId,
                               OND_StatusDocumentoId = objOfertaNegociacaoxDocumento.OND_StatusDocumentoId,
                               OND_FlagAtivo = objOfertaNegociacaoxDocumento.OND_FlagAtivo,
                               OND_Descricao = objOfertaNegociacaoxDocumento.OND_Descricao,
                               OND_Justificativa = objOfertaNegociacaoxDocumento.OND_Justificativa,
                               OND_FlagAprovado = objOfertaNegociacaoxDocumento.OND_FlagAprovado,
                               OND_Id = objOfertaNegociacaoxDocumento.OND_Id
                           });
                }
                salvaLog(objOfertaNegociacaoxDocumento.Log, "", "UpdateOfertaNegociacaoxDocumento", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objOfertaNegociacaoxDocumento.Log, "OfertaNegociacaoxDocumentoRepository", "UpdateOfertaNegociacaoxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objOfertaNegociacaoxDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarOfertaNegociacaoxDocumento(int OND_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacaoxDocumento] SET ");
                    strUpdate.Append(" OND_FlagAtivo = @OND_FlagAtivo ");
                    strUpdate.Append(" WHERE OND_Id = @OND_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OND_FlagAtivo = 1,
                                            OND_Id = OND_Id
                                        });
                }
                salvaLog(null, "", "AtivarOfertaNegociacaoxDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxDocumentoRepository", "AtivarOfertaNegociacaoxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarOfertaNegociacaoxDocumento(int OND_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacaoxDocumento] SET ");
                    strUpdate.Append(" OND_FlagAtivo = @OND_FlagAtivo ");
                    strUpdate.Append(" WHERE OND_Id = @OND_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OND_FlagAtivo = 0,
                                            OND_Id = OND_Id
                                        });
                }
                salvaLog(null, "", "DeletarOfertaNegociacaoxDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxDocumentoRepository", "DeletarOfertaNegociacaoxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public OfertaNegociacaoxDocumento GetOfertaNegociacaoxDocumentoById(int OND_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * FROM [OfertaNegociacaoxDocumento] ");

                    OfertaNegociacaoxDocumento obj = null;

                    if (join)
                    {
                        strGet.Append(@" INNER JOIN OfertaNegociacao on OFN_Id = OND_OfertaNegociacaoId ");
                        strGet.Append(@" INNER JOIN Empresa on EMP_Id = OND_EmpresaId ");
                        strGet.Append(@" LEFT JOIN Documento on DOC_Id = OND_DocumentoId ");
                        strGet.Append(@" LEFT JOIN StatusDocumento on SDO_Id = OND_StatusDocumentoId ");

                        strGet.Append(" WHERE OND_Id = @OND_Id");

                        obj = _db.Query<OfertaNegociacaoxDocumento, OfertaNegociacao, Empresa, Documento, StatusDocumento, OfertaNegociacaoxDocumento>(strGet.ToString(),
                            (objOfertaNegociacaoxDocumento, objOfertaNegociacao, objEmpresa, objDocumento, objStatusDocumento) => {
                                objOfertaNegociacaoxDocumento.OfertaNegociacao = objOfertaNegociacao;
                                objOfertaNegociacaoxDocumento.Empresa = objEmpresa;
                                objOfertaNegociacaoxDocumento.Documento = objDocumento;
                                objOfertaNegociacaoxDocumento.StatusDocumento = objStatusDocumento;

                                return objOfertaNegociacaoxDocumento;
                            }, new { OND_Id = OND_Id },
                            splitOn: " OFN_Id,EMP_Id,DOC_Id,SDO_Id ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" WHERE OND_Id = @OND_Id");
                        obj = _db.Query<OfertaNegociacaoxDocumento>(strGet.ToString(), new { OND_Id = OND_Id }).FirstOrDefault();
                    }

                    salvaLog(null, "", "GetOfertaNegociacaoxDocumentoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxDocumentoRepository", "GetOfertaNegociacaoxDocumentoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacaoxDocumento] ");
                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN OfertaNegociacao on OFN_Id = OND_OfertaNegociacaoId ");
                        strGetAll.Append(@" INNER JOIN Empresa on EMP_Id = OND_EmpresaId ");
                        strGetAll.Append(@" LEFT JOIN Documento on DOC_Id = OND_DocumentoId ");
                        strGetAll.Append(@" LEFT JOIN StatusDocumento on SDO_Id = OND_StatusDocumentoId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" WHERE OND_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<OfertaNegociacaoxDocumento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaNegociacaoxDocumento, OfertaNegociacao, Empresa, Documento, StatusDocumento, OfertaNegociacaoxDocumento>(newStrGetAll.ToString(),
                           (objOfertaNegociacaoxDocumento, objOfertaNegociacao, objEmpresa, objDocumento, objStatusDocumento) => {
                               objOfertaNegociacaoxDocumento.OfertaNegociacao = objOfertaNegociacao;
                               objOfertaNegociacaoxDocumento.Empresa = objEmpresa;
                               objOfertaNegociacaoxDocumento.Documento = objDocumento;
                               objOfertaNegociacaoxDocumento.StatusDocumento = objStatusDocumento;

                               return objOfertaNegociacaoxDocumento;
                           }, new { maxInstances = maxInstances },
                            splitOn: " OFN_Id,EMP_Id,DOC_Id,SDO_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaNegociacaoxDocumento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }


                    salvaLog(null, "", "GetAllOfertaNegociacaoxDocumento", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxDocumentoRepository", "GetAllOfertaNegociacaoxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacaoxDocumento] ");

                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN OfertaNegociacao on OFN_Id = OND_OfertaNegociacaoId ");
                        strGetAll.Append(@" INNER JOIN Empresa on EMP_Id = OND_EmpresaId ");
                        strGetAll.Append(@" LEFT JOIN Documento on DOC_Id = OND_DocumentoId ");
                        strGetAll.Append(@" LEFT JOIN StatusDocumento on SDO_Id = OND_StatusDocumentoId ");
                    }

                    strGetAll.Append(@" WHERE ({0} LIKE @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND OND_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<OfertaNegociacaoxDocumento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaNegociacaoxDocumento, OfertaNegociacao, Empresa, Documento, StatusDocumento, OfertaNegociacaoxDocumento>(newStrGetAll.ToString(),
                             (objOfertaNegociacaoxDocumento, objOfertaNegociacao, objEmpresa, objDocumento, objStatusDocumento) => {
                                 objOfertaNegociacaoxDocumento.OfertaNegociacao = objOfertaNegociacao;
                                 objOfertaNegociacaoxDocumento.Empresa = objEmpresa;
                                 objOfertaNegociacaoxDocumento.Documento = objDocumento;
                                 objOfertaNegociacaoxDocumento.StatusDocumento = objStatusDocumento;

                                 return objOfertaNegociacaoxDocumento;
                             },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " OFN_Id,EMP_Id,DOC_Id,SDO_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaNegociacaoxDocumento>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaNegociacaoxDocumentoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxDocumentoRepository", "GetAllOfertaNegociacaoxDocumentoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<OfertaNegociacaoxDocumento> GetAllOfertaNegociacaoxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacaoxDocumento] ");

                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN OfertaNegociacao on OFN_Id = OND_OfertaNegociacaoId ");
                        strGetAll.Append(@" INNER JOIN Empresa on EMP_Id = OND_EmpresaId ");
                        strGetAll.Append(@" LEFT JOIN Documento on DOC_Id = OND_DocumentoId ");
                        strGetAll.Append(@" LEFT JOIN StatusDocumento on SDO_Id = OND_StatusDocumentoId ");
                    }

                    strGetAll.Append(@" WHERE ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND OND_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<OfertaNegociacaoxDocumento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaNegociacaoxDocumento, OfertaNegociacao, Empresa, Documento, StatusDocumento, OfertaNegociacaoxDocumento>(newStrGetAll.ToString(),
                               (objOfertaNegociacaoxDocumento, objOfertaNegociacao, objEmpresa, objDocumento, objStatusDocumento) => {
                                   objOfertaNegociacaoxDocumento.OfertaNegociacao = objOfertaNegociacao;
                                   objOfertaNegociacaoxDocumento.Empresa = objEmpresa;
                                   objOfertaNegociacaoxDocumento.Documento = objDocumento;
                                   objOfertaNegociacaoxDocumento.StatusDocumento = objStatusDocumento;

                                   return objOfertaNegociacaoxDocumento;
                               }, new
                               {
                                   strValorExato = strValorExato,
                                   maxInstances = maxInstances
                               },
                            splitOn: " OFN_Id,EMP_Id,DOC_Id,SDO_Id ").AsEnumerable();

                    }
                    else
                    {
                        lista = _db.Query<OfertaNegociacaoxDocumento>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaNegociacaoxDocumentoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxDocumentoRepository", "GetAllOfertaNegociacaoxDocumentoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
