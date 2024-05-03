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
    public class OfertaxQuantidadeProdutoRepository : RepositoryBase, IOfertaxQuantidadeProdutoRepository
    {

        public OfertaxQuantidadeProduto InsertOfertaxQuantidadeProduto(OfertaxQuantidadeProduto objOfertaxQuantidadeProduto)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT INTO [OfertaxQuantidadeProduto] ");
                    strInsert.Append("(OXQ_OfertaId,OXQ_UnidadePesoId,OXQ_Peso,OXQ_MoedaId,OXQ_MenorPreco,OXQ_MaiorPreco,OXQ_PercentualAdiantamento,OXQ_DataEntregaInicio,OXQ_DataEntregaFim,OXQ_FlagAtivo,OXQ_DataExpiracao)");
                    strInsert.Append(@" VALUES (@OXQ_OfertaId,@OXQ_UnidadePesoId,@OXQ_Peso,@OXQ_MoedaId,@OXQ_MenorPreco,@OXQ_MaiorPreco,@OXQ_PercentualAdiantamento,@OXQ_DataEntregaInicio,@OXQ_DataEntregaFim,@OXQ_FlagAtivo,@OXQ_DataExpiracao);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            OXQ_OfertaId = objOfertaxQuantidadeProduto.OXQ_OfertaId,
                            OXQ_UnidadePesoId = objOfertaxQuantidadeProduto.OXQ_UnidadePesoId,
                            OXQ_Peso = objOfertaxQuantidadeProduto.OXQ_Peso,
                            OXQ_MoedaId = objOfertaxQuantidadeProduto.OXQ_MoedaId,
                            OXQ_MenorPreco = objOfertaxQuantidadeProduto.OXQ_MenorPreco,
                            OXQ_MaiorPreco = objOfertaxQuantidadeProduto.OXQ_MaiorPreco,
                            OXQ_PercentualAdiantamento = objOfertaxQuantidadeProduto.OXQ_PercentualAdiantamento,
                            OXQ_DataEntregaInicio = objOfertaxQuantidadeProduto.OXQ_DataEntregaInicio,
                            OXQ_DataEntregaFim = objOfertaxQuantidadeProduto.OXQ_DataEntregaFim,
                            OXQ_FlagAtivo = true,
                            OXQ_DataExpiracao = objOfertaxQuantidadeProduto.OXQ_DataExpiracao,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objOfertaxQuantidadeProduto.OXQ_Id = queryInsert.First();

                    salvaLog(objOfertaxQuantidadeProduto.Log, "", "InsertOfertaxQuantidadeProduto", strInsert.ToString());
                    return objOfertaxQuantidadeProduto;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxQuantidadeProduto.Log, "OfertaxQuantidadeProdutoRepository", "InsertOfertaxQuantidadeProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objOfertaxQuantidadeProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new OfertaxQuantidadeProduto();
            }
        }

        public bool UpdateOfertaxQuantidadeProduto(OfertaxQuantidadeProduto objOfertaxQuantidadeProduto)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" UPDATE [OfertaxQuantidadeProduto] ");
                    strUpdate.Append(@" SET OXQ_OfertaId = @OXQ_OfertaId
                        , OXQ_UnidadePesoId = @OXQ_UnidadePesoId
                        , OXQ_Peso = @OXQ_Peso
                        , OXQ_MoedaId = @OXQ_MoedaId
                        , OXQ_MenorPreco = @OXQ_MenorPreco
                        , OXQ_MaiorPreco = @OXQ_MaiorPreco
                        , OXQ_PercentualAdiantamento = @OXQ_PercentualAdiantamento
                        , OXQ_DataEntregaInicio = @OXQ_DataEntregaInicio
                        , OXQ_DataEntregaFim = @OXQ_DataEntregaFim
                        , OXQ_FlagAtivo = @OXQ_FlagAtivo
                        , OXQ_DataExpiracao = @OXQ_DataExpiracao
                         WHERE OXQ_Id = @OXQ_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               OXQ_OfertaId = objOfertaxQuantidadeProduto.OXQ_OfertaId,
                               OXQ_UnidadePesoId = objOfertaxQuantidadeProduto.OXQ_UnidadePesoId,
                               OXQ_Peso = objOfertaxQuantidadeProduto.OXQ_Peso,
                               OXQ_MoedaId = objOfertaxQuantidadeProduto.OXQ_MoedaId,
                               OXQ_MenorPreco = objOfertaxQuantidadeProduto.OXQ_MenorPreco,
                               OXQ_MaiorPreco = objOfertaxQuantidadeProduto.OXQ_MaiorPreco,
                               OXQ_PercentualAdiantamento = objOfertaxQuantidadeProduto.OXQ_PercentualAdiantamento,
                               OXQ_DataEntregaInicio = objOfertaxQuantidadeProduto.OXQ_DataEntregaInicio,
                               OXQ_DataEntregaFim = objOfertaxQuantidadeProduto.OXQ_DataEntregaFim,
                               OXQ_FlagAtivo = objOfertaxQuantidadeProduto.OXQ_FlagAtivo,
                               OXQ_DataExpiracao = objOfertaxQuantidadeProduto.OXQ_DataExpiracao,
                               OXQ_Id = objOfertaxQuantidadeProduto.OXQ_Id
                           });
                }
                salvaLog(objOfertaxQuantidadeProduto.Log, "", "UpdateOfertaxQuantidadeProduto", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxQuantidadeProduto.Log, "OfertaxQuantidadeProdutoRepository", "UpdateOfertaxQuantidadeProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objOfertaxQuantidadeProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarOfertaxQuantidadeProduto(int OXQ_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaxQuantidadeProduto] SET ");
                    strUpdate.Append(" OXQ_FlagAtivo = @OXQ_FlagAtivo ");
                    strUpdate.Append(" WHERE OXQ_Id = @OXQ_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXQ_FlagAtivo = 1,
                                            OXQ_Id = OXQ_Id
                                        });
                }
                salvaLog(null, "", "AtivarOfertaxQuantidadeProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxQuantidadeProdutoRepository", "AtivarOfertaxQuantidadeProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarOfertaxQuantidadeProduto(int OXQ_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaxQuantidadeProduto] SET ");
                    strUpdate.Append(" OXQ_FlagAtivo = @OXQ_FlagAtivo ");
                    strUpdate.Append(" WHERE OXQ_Id = @OXQ_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXQ_FlagAtivo = 0,
                                            OXQ_Id = OXQ_Id
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxQuantidadeProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxQuantidadeProdutoRepository", "DeletarOfertaxQuantidadeProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public OfertaxQuantidadeProduto GetOfertaxQuantidadeProdutoById(int OXQ_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * FROM [OfertaxQuantidadeProduto] ");

                    OfertaxQuantidadeProduto obj = null;

                    if (join)
                    {
                        strGet.Append(@" INNER JOIN Oferta on OFE_Id = OXQ_OfertaId ");
                        strGet.Append(@" INNER JOIN UnidadePeso on UNP_Id = OXQ_UnidadePesoId ");
                        strGet.Append(@" INNER JOIN Moeda on MOE_Id = OXQ_MoedaId ");
                        strGet.Append(@" inner join [TipoProduto] on TPR_Id = OFE_TipoProdutoId ");
                        strGet.Append(@" inner join [Produto] on PDT_Id = OFE_ProdutoId ");
                        strGet.Append(@" inner join [ModoCultivoSistemaProdutivo] on MCS_Id = OFE_ModoCultivoSistemaProdutivoId ");

                        strGet.Append(" WHERE OXQ_Id = @OXQ_Id");

                        obj = _db.Query<OfertaxQuantidadeProduto, Oferta, UnidadePeso, Moeda, TipoProduto, Produto, ModoCultivoSistemaProdutivo, OfertaxQuantidadeProduto>(strGet.ToString(),
                            (objOfertaxQuantidadeProduto, objOferta, objUnidadePeso, objMoeda, objTipoProduto, objProduto, objModoCultivoSistemaProdutivo) =>
                            {
                                objOfertaxQuantidadeProduto.Oferta = objOferta;
                                objOfertaxQuantidadeProduto.UnidadePeso = objUnidadePeso;
                                objOfertaxQuantidadeProduto.Moeda = objMoeda;
                                objOfertaxQuantidadeProduto.Oferta.TipoProduto = objTipoProduto;
                                objOfertaxQuantidadeProduto.Oferta.Produto = objProduto;
                                objOfertaxQuantidadeProduto.Oferta.ModoCultivoSistemaProdutivo = objModoCultivoSistemaProdutivo;

                                var _EnderecoRepo = new EnderecoRepository();
                                objOfertaxQuantidadeProduto.Oferta.Endereco = _EnderecoRepo.GetEnderecoById(objOferta.OFE_EnderecoOrigemId, true);

                                var _EmpresaRepo = new EmpresaRepository();
                                objOfertaxQuantidadeProduto.Oferta.Empresa = _EmpresaRepo.GetEmpresaById(objOferta.OFE_EmpresaId, true);

                                var _ModoCultivoModoProducaoRepo = new ModoCultivoModoProducaoRepository();
                                objOfertaxQuantidadeProduto.Oferta.ModoCultivoModoProducao = _ModoCultivoModoProducaoRepo.GetModoCultivoModoProducaoById(objOferta.OFE_ModoCultivoModoProducaoId, true);

                                var _StatusProdutoRepo = new StatusProdutoRepository();
                                objOfertaxQuantidadeProduto.Oferta.StatusProduto = _StatusProdutoRepo.GetStatusProdutoById(objOferta.OFE_StatusProdutoId, true);

                                var _OfertaxDocumentoRepo = new OfertaxDocumentoRepository();
                                var listaOfertaxDocumento = _OfertaxDocumentoRepo.GetAllOfertaxDocumentoByValorExato(objOferta.OFE_Id.ToString(), "OXD_OfertaId", true, true, 0, "OXD_Id");

                                objOfertaxQuantidadeProduto.Oferta.listaOfertaxDocumento = listaOfertaxDocumento.ToList();
                                return objOfertaxQuantidadeProduto;

                            }, new { OXQ_Id = OXQ_Id },
                            splitOn: " OFE_Id,UNP_Id,MOE_Id,TPR_Id,PDT_Id,MCS_Id  ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" WHERE OXQ_Id = @OXQ_Id");
                        obj = _db.Query<OfertaxQuantidadeProduto>(strGet.ToString(), new { OXQ_Id = OXQ_Id }).FirstOrDefault();
                    }

                    if (obj.OXQ_Id > 0)
                    {
                        if (!string.IsNullOrEmpty(obj.Oferta.TipoProduto.TPR_PathUrl))
                            obj.Oferta.TipoProduto.TPR_PathUrl = ReadString("CGL_UrlImagem") + obj.Oferta.TipoProduto.TPR_PathUrl.Replace("\\", "/");

                        if (!string.IsNullOrEmpty(obj.Oferta.TipoProduto.TPR_PathUrlOferta))
                            obj.Oferta.TipoProduto.TPR_PathUrlOferta = ReadString("CGL_UrlImagem") + obj.Oferta.TipoProduto.TPR_PathUrlOferta.Replace("\\", "/");

                        var listaOXQP = GetAllOfertaxQuantidadeProdutoByValorExato(obj.Oferta.OFE_Id.ToString(), "OXQ_OfertaId", true, true, 0, "OXQ_Id");
                        obj.listaOXQNegociacao = listaOXQP.ToList();
                    }

                    salvaLog(null, "", "GetOfertaxQuantidadeProdutoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxQuantidadeProdutoRepository", "GetOfertaxQuantidadeProdutoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaxQuantidadeProduto] ");
                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN Oferta on OFE_Id = OXQ_OfertaId ");
                        strGetAll.Append(@" INNER JOIN UnidadePeso on UNP_Id = OXQ_UnidadePesoId ");
                        strGetAll.Append(@" INNER JOIN Moeda on MOE_Id = OXQ_MoedaId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" WHERE OXQ_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<OfertaxQuantidadeProduto> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxQuantidadeProduto, Oferta, UnidadePeso, Moeda, OfertaxQuantidadeProduto>(newStrGetAll.ToString(),
                             (objOfertaxQuantidadeProduto, objOferta, objUnidadePeso, objMoeda) =>
                             {
                                 objOfertaxQuantidadeProduto.Oferta = objOferta;
                                 objOfertaxQuantidadeProduto.UnidadePeso = objUnidadePeso;
                                 objOfertaxQuantidadeProduto.Moeda = objMoeda;

                                 return objOfertaxQuantidadeProduto;
                             }, new { maxInstances = maxInstances },
                            splitOn: " OFE_Id,UNP_Id,MOE_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxQuantidadeProduto>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }


                    salvaLog(null, "", "GetAllOfertaxQuantidadeProduto", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxQuantidadeProdutoRepository", "GetAllOfertaxQuantidadeProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaxQuantidadeProduto] ");

                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN Oferta on OFE_Id = OXQ_OfertaId ");
                        strGetAll.Append(@" INNER JOIN UnidadePeso on UNP_Id = OXQ_UnidadePesoId ");
                        strGetAll.Append(@" INNER JOIN Moeda on MOE_Id = OXQ_MoedaId ");
                    }

                    strGetAll.Append(@" WHERE ({0} LIKE @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND OXQ_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<OfertaxQuantidadeProduto> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxQuantidadeProduto, Oferta, UnidadePeso, Moeda, OfertaxQuantidadeProduto>(newStrGetAll.ToString(),
                             (objOfertaxQuantidadeProduto, objOferta, objUnidadePeso, objMoeda) =>
                             {
                                 objOfertaxQuantidadeProduto.Oferta = objOferta;
                                 objOfertaxQuantidadeProduto.UnidadePeso = objUnidadePeso;
                                 objOfertaxQuantidadeProduto.Moeda = objMoeda;

                                 return objOfertaxQuantidadeProduto;
                             },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " OFE_Id,UNP_Id,MOE_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxQuantidadeProduto>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaxQuantidadeProdutoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxQuantidadeProdutoRepository", "GetAllOfertaxQuantidadeProdutoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaxQuantidadeProduto] ");

                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN Oferta on OFE_Id = OXQ_OfertaId ");
                        strGetAll.Append(@" INNER JOIN UnidadePeso on UNP_Id = OXQ_UnidadePesoId ");
                        strGetAll.Append(@" INNER JOIN Moeda on MOE_Id = OXQ_MoedaId ");
                        strGetAll.Append(@" inner join [TipoProduto] on TPR_Id = OFE_TipoProdutoId ");
                        strGetAll.Append(@" inner join [Produto] on PDT_Id = OFE_ProdutoId ");
                        strGetAll.Append(@" inner join [ModoCultivoSistemaProdutivo] on MCS_Id = OFE_ModoCultivoSistemaProdutivoId ");
                    }

                    strGetAll.Append(@" WHERE ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND OXQ_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<OfertaxQuantidadeProduto> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxQuantidadeProduto, Oferta, UnidadePeso, Moeda, TipoProduto, Produto, ModoCultivoSistemaProdutivo, OfertaxQuantidadeProduto>(newStrGetAll.ToString(),
                             (objOfertaxQuantidadeProduto, objOferta, objUnidadePeso, objMoeda, objTipoProduto, objProduto, objModoCultivoSistemaProdutivo) =>
                             {
                                 objOfertaxQuantidadeProduto.Oferta = objOferta;
                                 objOfertaxQuantidadeProduto.UnidadePeso = objUnidadePeso;
                                 objOfertaxQuantidadeProduto.Moeda = objMoeda;
                                 objOfertaxQuantidadeProduto.Oferta.TipoProduto = objTipoProduto;
                                 objOfertaxQuantidadeProduto.Oferta.Produto = objProduto;
                                 objOfertaxQuantidadeProduto.Oferta.ModoCultivoSistemaProdutivo = objModoCultivoSistemaProdutivo;

                                 var _EnderecoRepo = new EnderecoRepository();
                                 objOfertaxQuantidadeProduto.Oferta.Endereco = _EnderecoRepo.GetEnderecoById(objOferta.OFE_EnderecoOrigemId, true);

                                 var _StatusProdutoRepo = new StatusProdutoRepository();
                                 objOfertaxQuantidadeProduto.Oferta.StatusProduto = _StatusProdutoRepo.GetStatusProdutoById(objOferta.OFE_StatusProdutoId, true);

                                 return objOfertaxQuantidadeProduto;
                             }, new
                             {
                                 strValorExato = strValorExato,
                                 maxInstances = maxInstances
                             },
                            splitOn: " OFE_Id,UNP_Id,MOE_Id,TPR_Id,PDT_Id,MCS_Id ").AsEnumerable();

                    }
                    else
                    {
                        lista = _db.Query<OfertaxQuantidadeProduto>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    if (lista.Count() > 0 && join)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.Oferta.TipoProduto.TPR_PathUrl))
                                item.Oferta.TipoProduto.TPR_PathUrl = ReadString("CGL_UrlImagem") + item.Oferta.TipoProduto.TPR_PathUrl.Replace("\\", "/");
                            if (!string.IsNullOrEmpty(item.Oferta.TipoProduto.TPR_PathUrlOferta))
                                item.Oferta.TipoProduto.TPR_PathUrlOferta = ReadString("CGL_UrlImagem") + item.Oferta.TipoProduto.TPR_PathUrlOferta.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllOfertaxQuantidadeProdutoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxQuantidadeProdutoRepository", "GetAllOfertaxQuantidadeProdutoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool DeletarOfertaxQuantidadeProdutoByOferta(int OXQ_OfertaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaxQuantidadeProduto] SET ");
                    strUpdate.Append(" OXQ_FlagAtivo = @OXQ_FlagAtivo ");
                    strUpdate.Append(" WHERE OXQ_OfertaId = @OXQ_OfertaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXQ_FlagAtivo = 0,
                                            OXQ_OfertaId = OXQ_OfertaId
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxQuantidadeProdutoByOferta", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxQuantidadeProdutoRepository", "DeletarOfertaxQuantidadeProdutoByOferta", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public IEnumerable<OfertaxQuantidadeProduto> GetAllOfertaxQuantidadeProdutoByFiltro(string produto = "", int idCategoria = 0, int idSistemaProdutivo = 0, int idModoProducao = 0, int idStatusProduto = 0, int anoColheita = 0, decimal peso = 0, int idVolume = 0, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaxQuantidadeProduto] ");

                    strGetAll.Append(@" INNER JOIN Oferta on OFE_Id = OXQ_OfertaId ");
                    strGetAll.Append(@" INNER JOIN UnidadePeso on UNP_Id = OXQ_UnidadePesoId ");
                    strGetAll.Append(@" INNER JOIN Moeda on MOE_Id = OXQ_MoedaId ");
                    strGetAll.Append(@" inner join [TipoProduto] on TPR_Id = OFE_TipoProdutoId ");
                    strGetAll.Append(@" inner join [Produto] on PDT_Id = OFE_ProdutoId ");
                    strGetAll.Append(@" inner join [ModoCultivoSistemaProdutivo] on MCS_Id = OFE_ModoCultivoSistemaProdutivoId ");

                    strGetAll.Append(@" WHERE OXQ_FlagAtivo = 1 ");

                    if (produto != null && produto != "" && produto != " ")
                        strGetAll.Append(" AND dbo.fncRemove_Acentuacao(PDT_Nome) like '%" + removerAcentos(produto).ToUpper() + "%' ");

                    if (idCategoria != null && idCategoria != 0)
                        strGetAll.Append(" AND OFE_CategoriaId = @idCategoria ");

                    if (idSistemaProdutivo != null && idSistemaProdutivo != 0)
                        strGetAll.Append(" AND OFE_ModoCultivoSistemaProdutivoId = @idSistemaProdutivo ");

                    if (idModoProducao != null && idModoProducao != 0)
                        strGetAll.Append(" AND OFE_ModoCultivoModoProducaoId = @idModoProducao ");

                    if (idStatusProduto != null && idStatusProduto != 0)
                        strGetAll.Append(" AND OFE_StatusProdutoId = @idStatusProduto ");

                    if (anoColheita != null && anoColheita != 0)
                        strGetAll.Append(" AND OFE_AnoColheita = @anoColheita ");

                    if (peso != null && peso != 0)
                        strGetAll.Append(" AND OXQ_Peso = @peso ");

                    if (idVolume != null && idVolume != 0)
                        strGetAll.Append(" AND OXQ_UnidadePesoId = @idVolume ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);
                    IEnumerable<OfertaxQuantidadeProduto> lista = null;

                    lista = _db.Query<OfertaxQuantidadeProduto, Oferta, UnidadePeso, Moeda, TipoProduto, Produto, ModoCultivoSistemaProdutivo, OfertaxQuantidadeProduto>(newStrGetAll.ToString(),
                         (objOfertaxQuantidadeProduto, objOferta, objUnidadePeso, objMoeda, objTipoProduto, objProduto, objModoCultivoSistemaProdutivo) =>
                         {
                             objOfertaxQuantidadeProduto.Oferta = objOferta;
                             objOfertaxQuantidadeProduto.UnidadePeso = objUnidadePeso;
                             objOfertaxQuantidadeProduto.Moeda = objMoeda;
                             objOfertaxQuantidadeProduto.Oferta.TipoProduto = objTipoProduto;
                             objOfertaxQuantidadeProduto.Oferta.Produto = objProduto;
                             objOfertaxQuantidadeProduto.Oferta.ModoCultivoSistemaProdutivo = objModoCultivoSistemaProdutivo;

                             var _EnderecoRepo = new EnderecoRepository();
                             objOfertaxQuantidadeProduto.Oferta.Endereco = _EnderecoRepo.GetEnderecoById(objOferta.OFE_EnderecoOrigemId, true);

                             var _StatusProdutoRepo = new StatusProdutoRepository();
                             objOfertaxQuantidadeProduto.Oferta.StatusProduto = _StatusProdutoRepo.GetStatusProdutoById(objOferta.OFE_StatusProdutoId, true);

                             return objOfertaxQuantidadeProduto;
                         }, new
                         {
                             idCategoria = idCategoria,
                             idSistemaProdutivo = idSistemaProdutivo,
                             idModoProducao = idModoProducao,
                             idStatusProduto = idStatusProduto,
                             anoColheita = anoColheita,
                             peso = peso,
                             idVolume = idVolume,
                             maxInstances = maxInstances
                         },
                        splitOn: " OFE_Id,UNP_Id,MOE_Id,TPR_Id,PDT_Id,MCS_Id ").AsEnumerable();


                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.Oferta.TipoProduto.TPR_PathUrl))
                                item.Oferta.TipoProduto.TPR_PathUrl = ReadString("CGL_UrlImagem") + item.Oferta.TipoProduto.TPR_PathUrl.Replace("\\", "/");
                            if (!string.IsNullOrEmpty(item.Oferta.TipoProduto.TPR_PathUrlOferta))
                                item.Oferta.TipoProduto.TPR_PathUrlOferta = ReadString("CGL_UrlImagem") + item.Oferta.TipoProduto.TPR_PathUrlOferta.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllOfertaxQuantidadeProdutoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxQuantidadeProdutoRepository", "GetAllOfertaxQuantidadeProdutoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public static string removerAcentos(string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }

    }
}

