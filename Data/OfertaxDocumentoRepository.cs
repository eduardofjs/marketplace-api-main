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
    public class OfertaxDocumentoRepository : RepositoryBase, IOfertaxDocumentoRepository
    {

        public OfertaxDocumento InsertOfertaxDocumento(OfertaxDocumento objOfertaxDocumento)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [OfertaxDocumento] ");
                    strInsert.Append("(OXD_OfertaId,OXD_DocumentoId,OXD_FlagAtivo,OXD_DataCadastro)");
                    strInsert.Append(@" VALUES (@OXD_OfertaId,@OXD_DocumentoId,@OXD_FlagAtivo,GETDATE());");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            OXD_OfertaId = objOfertaxDocumento.OXD_OfertaId,
                            OXD_DocumentoId = objOfertaxDocumento.OXD_DocumentoId,
                            OXD_FlagAtivo = objOfertaxDocumento.OXD_FlagAtivo
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objOfertaxDocumento.OXD_Id = queryInsert.First();

                    salvaLog(objOfertaxDocumento.Log, "", "InsertOfertaxDocumento", strInsert.ToString());
                    return objOfertaxDocumento;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxDocumento.Log, "OfertaxDocumentoRepository", "InsertOfertaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objOfertaxDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new OfertaxDocumento();
            }
        }

        public bool UpdateOfertaxDocumento(OfertaxDocumento objOfertaxDocumento)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [OfertaxDocumento] ");
                    strUpdate.Append(@" SET OXD_OfertaId = @OXD_OfertaId
                        , OXD_DocumentoId = @OXD_DocumentoId
                        , OXD_FlagAtivo = @OXD_FlagAtivo
                         where OXD_Id = @OXD_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               OXD_OfertaId = objOfertaxDocumento.OXD_OfertaId,
                               OXD_DocumentoId = objOfertaxDocumento.OXD_DocumentoId,
                               OXD_FlagAtivo = objOfertaxDocumento.OXD_FlagAtivo,
                               OXD_Id = objOfertaxDocumento.OXD_Id
                           });
                }
                salvaLog(objOfertaxDocumento.Log, "", "UpdateOfertaxDocumento", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxDocumento.Log, "OfertaxDocumentoRepository", "UpdateOfertaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objOfertaxDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarOfertaxDocumento(int OXD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [OfertaxDocumento] set ");
                    strUpdate.Append(" OXD_FlagAtivo = @OXD_FlagAtivo ");
                    strUpdate.Append(" where OXD_Id = @OXD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXD_FlagAtivo = 1,
                                            OXD_Id = OXD_Id
                                        });
                }
                salvaLog(null, "", "AtivarOfertaxDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxDocumentoRepository", "AtivarOfertaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarOfertaxDocumento(int OXD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [OfertaxDocumento] set ");
                    strUpdate.Append(" OXD_FlagAtivo = @OXD_FlagAtivo ");
                    strUpdate.Append(" where OXD_Id = @OXD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXD_FlagAtivo = 0,
                                            OXD_Id = OXD_Id
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxDocumentoRepository", "DeletarOfertaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public OfertaxDocumento GetOfertaxDocumentoById(int OXD_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [OfertaxDocumento] ");

                    OfertaxDocumento obj = null;

                    if (join)
                    {
                        strGet.Append(@" join Oferta on OFE_Id = OXD_OfertaId ");
                        strGet.Append(@" join Documento on DOC_Id = OXD_DocumentoId ");
                        strGet.Append(" where OXD_Id = @OXD_Id");

                        obj = _db.Query<OfertaxDocumento, Oferta, Documento, OfertaxDocumento>(strGet.ToString(),
                            (objOfertaxDocumento, objOferta, objDocumento) => {
                                objOfertaxDocumento.Oferta = objOferta;
                                objOfertaxDocumento.Documento = objDocumento;

                                return objOfertaxDocumento;
                            }, new { OXD_Id = OXD_Id },
                            splitOn: " OFE_Id,DOC_Id ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" where OXD_Id = @OXD_Id");
                        obj = _db.Query<OfertaxDocumento>(strGet.ToString(), new { OXD_Id = OXD_Id }).FirstOrDefault();
                    }

                    if (obj != null && obj.Documento != null)
                    {
                        if (!string.IsNullOrEmpty(obj.Documento.DOC_PathUrl))
                            obj.Documento.DOC_PathUrl = ReadString("CGL_UrlImagem") + obj.Documento.DOC_PathUrl.Replace("\\", "/");
                    }

                    salvaLog(null, "", "GetOfertaxDocumentoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxDocumentoRepository", "GetOfertaxDocumentoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxDocumento> GetAllOfertaxDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [OfertaxDocumento] ");
                    if (join)
                    {
                        strGetAll.Append(@" join Oferta on OFE_Id = OXD_OfertaId ");
                        strGetAll.Append(@" join Documento on DOC_Id = OXD_DocumentoId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where OXD_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<OfertaxDocumento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxDocumento, Oferta, Documento, OfertaxDocumento>(newStrGetAll.ToString(),
                            (objOfertaxDocumento, objOferta, objDocumento) => {
                                objOfertaxDocumento.Oferta = objOferta;
                                objOfertaxDocumento.Documento = objDocumento;

                                return objOfertaxDocumento;
                            }, new { maxInstances = maxInstances },
                            splitOn: " OFE_Id,DOC_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxDocumento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (item.Documento != null && !string.IsNullOrEmpty(item.Documento.DOC_PathUrl))
                                item.Documento.DOC_PathUrl = ReadString("CGL_UrlImagem") + item.Documento.DOC_PathUrl.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllOfertaxDocumento", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxDocumentoRepository", "GetAllOfertaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxDocumento> GetAllOfertaxDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [OfertaxDocumento] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Oferta on OFE_Id = OXD_OfertaId ");
                        strGetAll.Append(@" join Documento on DOC_Id = OXD_DocumentoId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OXD_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<OfertaxDocumento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxDocumento, Oferta, Documento, OfertaxDocumento>(newStrGetAll.ToString(),
                            (objOfertaxDocumento, objOferta, objDocumento) => {
                                objOfertaxDocumento.Oferta = objOferta;
                                objOfertaxDocumento.Documento = objDocumento;

                                return objOfertaxDocumento;
                            },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " OFE_Id,DOC_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxDocumento>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (item.Documento != null && !string.IsNullOrEmpty(item.Documento.DOC_PathUrl))
                                item.Documento.DOC_PathUrl = ReadString("CGL_UrlImagem") + item.Documento.DOC_PathUrl.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllOfertaxDocumentoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxDocumentoRepository", "GetAllOfertaxDocumentoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<OfertaxDocumento> GetAllOfertaxDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [OfertaxDocumento] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Oferta on OFE_Id = OXD_OfertaId ");
                        strGetAll.Append(@" join Documento on DOC_Id = OXD_DocumentoId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OXD_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<OfertaxDocumento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxDocumento, Oferta, Documento, OfertaxDocumento>(newStrGetAll.ToString(),
                            (objOfertaxDocumento, objOferta, objDocumento) => {
                                objOfertaxDocumento.Oferta = objOferta;
                                objOfertaxDocumento.Documento = objDocumento;

                                return objOfertaxDocumento;
                            }, new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: " OFE_Id,DOC_Id ").AsEnumerable();

                    }
                    else
                    {
                        lista = _db.Query<OfertaxDocumento>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (item.Documento != null && !string.IsNullOrEmpty(item.Documento.DOC_PathUrl))
                                item.Documento.DOC_PathUrl = ReadString("CGL_UrlImagem") + item.Documento.DOC_PathUrl.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllOfertaxDocumentoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxDocumentoRepository", "GetAllOfertaxDocumentoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool DeletarOfertaxDocumentoByOferta(int OXD_OfertaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [OfertaxDocumento] set ");
                    strUpdate.Append(" OXD_FlagAtivo = @OXD_FlagAtivo ");
                    strUpdate.Append(" where OXD_OfertaId = @OXD_OfertaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXD_FlagAtivo = 0,
                                            OXD_OfertaId = OXD_OfertaId
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxDocumentoRepository", "DeletarOfertaxDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}
