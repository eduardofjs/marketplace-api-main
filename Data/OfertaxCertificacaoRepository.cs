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
    public class OfertaxCertificacaoRepository : RepositoryBase, IOfertaxCertificacaoRepository
    {

        public OfertaxCertificacao InsertOfertaxCertificacao(OfertaxCertificacao objOfertaxCertificacao)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into OfertaxCertificacao ");
                    strInsert.Append("(OXC_OfertaId, OXC_TipoCertificacaoId, OXC_DocumentoId, OXC_Comentarios, OXC_FlagAtivo)");
                    strInsert.Append(@" VALUES (@OXC_OfertaId, @OXC_TipoCertificacaoId, @OXC_DocumentoId, @OXC_Comentarios, @OXC_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            OXC_OfertaId = objOfertaxCertificacao.OXC_OfertaId,
                            OXC_TipoCertificacaoId = objOfertaxCertificacao.OXC_TipoCertificacaoId,
                            OXC_DocumentoId = objOfertaxCertificacao.OXC_DocumentoId,
                            OXC_Comentarios = objOfertaxCertificacao.OXC_Comentarios,
                            OXC_FlagAtivo = objOfertaxCertificacao.OXC_FlagAtivo,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objOfertaxCertificacao.OXC_Id = queryInsert.First();

                    salvaLog(objOfertaxCertificacao.Log, "", "InsertOfertaxCertificacao", strInsert.ToString());
                    return objOfertaxCertificacao;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxCertificacao.Log, "OfertaxCertificacaoRepository", "InsertOfertaxCertificacao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objOfertaxCertificacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new OfertaxCertificacao();
            }
        }


        public bool UpdateOfertaxCertificacao(OfertaxCertificacao objOfertaxCertificacao)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update OfertaxCertificacao ");
                    strUpdate.Append(@" SET OXC_OfertaId = @OXC_OfertaId
                        , OXC_TipoCertificacaoId = @OXC_TipoCertificacaoId
                        , OXC_FlagAtivo = @OXC_FlagAtivo
                        , OXC_DocumentoId = @OXC_DocumentoId
                        , OXC_Comentarios = @OXC_Comentarios
                         where OXC_Id = @OXC_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               OXC_OfertaId = objOfertaxCertificacao.OXC_OfertaId,
                               OXC_TipoCertificacaoId = objOfertaxCertificacao.OXC_TipoCertificacaoId,
                               OXC_FlagAtivo = objOfertaxCertificacao.OXC_FlagAtivo,
                               OXC_DocumentoId = objOfertaxCertificacao.OXC_DocumentoId,
                               OXC_Comentarios = objOfertaxCertificacao.OXC_Comentarios,
                               OXC_Id = objOfertaxCertificacao.OXC_Id
                           });
                }
                salvaLog(objOfertaxCertificacao.Log, "", "UpdateOfertaxCertificacao", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxCertificacao.Log, "OfertaxCertificacaoRepository", "UpdateOfertaxCertificacao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objOfertaxCertificacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarOfertaxCertificacao(int OXC_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update OfertaxCertificacao set ");
                    strUpdate.Append(" OXC_FlagAtivo = @OXC_FlagAtivo ");
                    strUpdate.Append(" where OXC_Id = @OXC_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXC_FlagAtivo = 1,
                                            OXC_Id = OXC_Id
                                        });
                }
                salvaLog(null, "", "AtivarOfertaxCertificacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxCertificacaoRepository", "AtivarOfertaxCertificacao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarOfertaxCertificacao(int OXC_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update OfertaxCertificacao set ");
                    strUpdate.Append(" OXC_FlagAtivo = @OXC_FlagAtivo ");
                    strUpdate.Append(" where OXC_Id = @OXC_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXC_FlagAtivo = 0,
                                            OXC_Id = OXC_Id
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxCertificacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxCertificacaoRepository", "DeletarOfertaxCertificacao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public OfertaxCertificacao GetOfertaxCertificacaoById(int OXC_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from OfertaxCertificacao ");
                    if (join)
                    {
                        strGet.Append(@" inner join [Oferta] on OFE_Id = OXC_OfertaId ");
                        strGet.Append(@" inner join [TipoCertificacao] on TPC_Id = OXC_TipoCertificacaoId ");
                        strGet.Append(@" inner join [Documento] on DOC_Id = OXC_DocumentoId ");
                    }

                    strGet.Append(" where OXC_Id = @OXC_Id");

                    OfertaxCertificacao obj = null;
                    if (join)
                    {
                        obj = _db.Query<OfertaxCertificacao, Oferta, TipoCertificacao, Documento, OfertaxCertificacao>(strGet.ToString(),
                            (objOfertaxCertificacao, objOferta, objTipoCertificacao, objDocumento) =>
                            {
                                objOfertaxCertificacao.Oferta = objOferta;
                                objOfertaxCertificacao.TipoCertificacao = objTipoCertificacao;
                                objOfertaxCertificacao.Documento = objDocumento;
                                return objOfertaxCertificacao;
                            }, new { OXC_Id = OXC_Id },
                            splitOn: "OFE_Id,TPC_Id,DOC_Id").FirstOrDefault();
                    }
                    else
                    {
                        obj = _db.Query<OfertaxCertificacao>(strGet.ToString(), new { OXC_Id = OXC_Id }).FirstOrDefault();
                    }

                    if (obj != null && obj.Documento != null)
                    {
                        if (!string.IsNullOrEmpty(obj.Documento.DOC_PathUrl))
                            obj.Documento.DOC_PathUrl = ReadString("CGL_UrlImagem") + obj.Documento.DOC_PathUrl.Replace("\\", "/");
                    }

                    salvaLog(null, "", "GetOfertaxCertificacaoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxCertificacaoRepository", "GetOfertaxCertificacaoById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from OfertaxCertificacao ");
                    if (join)
                    {
                        strGetAll.Append(@" inner join [Oferta] on OFE_Id = OXC_OfertaId ");
                        strGetAll.Append(@" inner join [TipoCertificacao] on TPC_Id = OXC_TipoCertificacaoId ");
                        strGetAll.Append(@" inner join [Documento] on DOC_Id = OXC_DocumentoId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where OXC_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<OfertaxCertificacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxCertificacao, Oferta, TipoCertificacao, Documento, OfertaxCertificacao>(newStrGetAll.ToString(),
                            (objOfertaxCertificacao, objOferta, objTipoCertificacao, objDocumento) =>
                            {
                                objOfertaxCertificacao.Oferta = objOferta;
                                objOfertaxCertificacao.TipoCertificacao = objTipoCertificacao;
                                objOfertaxCertificacao.Documento = objDocumento;
                                return objOfertaxCertificacao;
                            }, new { maxInstances = maxInstances },
                            splitOn: "OFE_Id,TPC_Id,DOC_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxCertificacao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (item.Documento != null && !string.IsNullOrEmpty(item.Documento.DOC_PathUrl))
                                item.Documento.DOC_PathUrl = ReadString("CGL_UrlImagem") + item.Documento.DOC_PathUrl.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllOfertaxCertificacao", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxCertificacaoRepository", "GetAllOfertaxCertificacao", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from OfertaxCertificacao ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join [Oferta] on OFE_Id = OXC_OfertaId ");
                        strGetAll.Append(@" inner join [TipoCertificacao] on TPC_Id = OXC_TipoCertificacaoId ");
                        strGetAll.Append(@" inner join [Documento] on DOC_Id = OXC_DocumentoId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OXC_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<OfertaxCertificacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxCertificacao, Oferta, TipoCertificacao, Documento, OfertaxCertificacao>(newStrGetAll.ToString(),
                            (objOfertaxCertificacao, objOferta, objTipoCertificacao, objDocumento) =>
                            {
                                objOfertaxCertificacao.Oferta = objOferta;
                                objOfertaxCertificacao.TipoCertificacao = objTipoCertificacao;
                                objOfertaxCertificacao.Documento = objDocumento;
                                return objOfertaxCertificacao;
                            }, new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: "OFE_Id,TPC_Id,DOC_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxCertificacao>(newStrGetAll.ToString(),
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

                    salvaLog(null, "", "GetAllOfertaxCertificacaoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxCertificacaoRepository", "GetAllOfertaxCertificacaoByPartial", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from OfertaxCertificacao ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join [Oferta] on OFE_Id = OXC_OfertaId ");
                        strGetAll.Append(@" inner join [TipoCertificacao] on TPC_Id = OXC_TipoCertificacaoId ");
                        strGetAll.Append(@" inner join [Documento] on DOC_Id = OXC_DocumentoId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OXC_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<OfertaxCertificacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxCertificacao, Oferta, TipoCertificacao, Documento, OfertaxCertificacao>(newStrGetAll.ToString(),
                            (objOfertaxCertificacao, objOferta, objTipoCertificacao, objDocumento) =>
                            {
                                objOfertaxCertificacao.Oferta = objOferta;
                                objOfertaxCertificacao.TipoCertificacao = objTipoCertificacao;
                                objOfertaxCertificacao.Documento = objDocumento;
                                return objOfertaxCertificacao;
                            }, new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: "OFE_Id,TPC_Id,DOC_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxCertificacao>(newStrGetAll.ToString(),
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

                    salvaLog(null, "", "GetAllOfertaxCertificacaoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxCertificacaoRepository", "GetAllOfertaxCertificacaoByValorExato", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public bool DeletarOfertaxCertificacaoByOferta(int OXC_OfertaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update OfertaxCertificacao set ");
                    strUpdate.Append(" OXC_FlagAtivo = @OXC_FlagAtivo ");
                    strUpdate.Append(" where OXC_OfertaId = @OXC_OfertaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXC_FlagAtivo = 0,
                                            OXC_OfertaId = OXC_OfertaId
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxCertificacaoByOferta", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxCertificacaoRepository", "DeletarOfertaxCertificacaoByOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}



