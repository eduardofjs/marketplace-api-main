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
    public class OfertaNegociacaoRepository : RepositoryBase, IOfertaNegociacaoRepository
    {

        public OfertaNegociacao InsertOfertaNegociacao(OfertaNegociacao objOfertaNegociacao)
        {

            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    //incrementando quantidade de contraOferta de Ofertador ou Cliente
                    //StringBuilder strGet = new StringBuilder();
                    //strGet.Append("SELECT OFN_Id, EMP_Id as OFN_EmpresaId, OFN_ContadorOfertador, OFN_ContadorCliente FROM OfertaNegociacao ");
                    //strGet.Append("INNER JOIN OfertaxQuantidadeProduto ON OXQ_Id = OFN_OfertaxQuantidadeProdutoId ");
                    //strGet.Append("INNER JOIN Oferta ON OFE_Id = OXQ_OfertaId ");
                    //strGet.Append("INNER JOIN Empresa ON EMP_Id = OFE_EmpresaId ");
                    //strGet.Append("WHERE OFN_OfertaxQuantidadeProdutoId = @OFN_OfertaxQuantidadeProdutoId ");
                    //strGet.Append("AND OFN_EmpresaId = @OFN_EmpresaId ");
                    //strGet.Append("AND OFN_FlagAtivo = 1 ");
                    //strGet.Append("order by OFN_Id desc ");
                    //
                    //var obj = _db.Query<OfertaNegociacao>(strGet.ToString(), new { OFN_OfertaxQuantidadeProdutoId = objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId, OFN_EmpresaId = objOfertaNegociacao.OFN_EmpresaId }).FirstOrDefault();

                    //primeira negociação, é do cliente
                    if (objOfertaNegociacao.OFN_ContadorCliente == null && objOfertaNegociacao.OFN_ContadorOfertador == null)
                    {
                        if (objOfertaNegociacao.OFN_FlagVendedor.Value)
                        {
                            objOfertaNegociacao.OFN_ContadorCliente = 0;
                            objOfertaNegociacao.OFN_ContadorOfertador = 1;
                        }
                        else
                        {
                            objOfertaNegociacao.OFN_ContadorCliente = 1;
                            objOfertaNegociacao.OFN_ContadorOfertador = 0;
                        }
                    }
                    else
                    {
                        //verifica se a contraoferta é do cliente ou do ofertador
                        if (objOfertaNegociacao.OFN_FlagVendedor.Value)//ofertador
                            objOfertaNegociacao.OFN_ContadorOfertador = objOfertaNegociacao.OFN_ContadorOfertador + 1;
                        else
                            objOfertaNegociacao.OFN_ContadorCliente = objOfertaNegociacao.OFN_ContadorCliente + 1;
                    }

                    //Limite máximo de 4 contraofertas para cada
                    if (objOfertaNegociacao.OFN_ContadorOfertador > 4 || objOfertaNegociacao.OFN_ContadorCliente > 4)
                    {
                        objOfertaNegociacao = new OfertaNegociacao();
                        objOfertaNegociacao.OFN_Mensagem = "O número de contraofertas excedeu o limite estabelecido. Você será contacto pelo time da directto para sabe como proceder";
                        return objOfertaNegociacao;
                    }
                    else
                    {
                        
                        //listar todos da ofertaxquantidadeproduto e verificar qual ativo existe na base destas empresas para desativar antes de criar a nova
                        var lista = GetAllOfertaNegociacaoByValorExato(objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId.ToString(), "OFN_OfertaxQuantidadeProdutoId",true,true);
                        if (lista.Count() > 0)
                        {
                            if (objOfertaNegociacao.OfertaxQuantidadeProduto == null)
                            {
                                objOfertaNegociacao.OfertaxQuantidadeProduto = new OfertaxQuantidadeProduto();
                                var _OfertaxQuantidadeProdutoRepo = new OfertaxQuantidadeProdutoRepository();
                                objOfertaNegociacao.OfertaxQuantidadeProduto = _OfertaxQuantidadeProdutoRepo.GetOfertaxQuantidadeProdutoById(objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId, true);
                            }

                            foreach (var item in lista)
                            {
                                if (item.OFN_EmpresaOriginalId == objOfertaNegociacao.OFN_EmpresaOriginalId && item.OfertaxQuantidadeProduto.Oferta.OFE_EmpresaId == objOfertaNegociacao.OfertaxQuantidadeProduto.Oferta.OFE_EmpresaId)                                    
                                    DeletarOfertaNegociacao(item.OFN_Id);
                            }
                        }
                        
                        objOfertaNegociacao.OFN_NumeroPedido = GerarCodigo();

                        StringBuilder strInsert = new StringBuilder();
                        strInsert.Append("INSERT INTO [OfertaNegociacao] ");
                        strInsert.Append("(OFN_OfertaxQuantidadeProdutoId,OFN_EmpresaId,OFN_StatusPagamentoId,OFN_NumeroPedido,OFN_Peso,OFN_ValorProposta,OFN_Mensagem,OFN_FlagContato,OFN_FlagAceite,OFN_DataCadastro,OFN_DataAtualizacao,OFN_FlagDirectto,OFN_ContadorOfertador,OFN_ContadorCliente,OFN_FlagAtivo, OFN_MeioTransporteId, OFN_DataEmbarque, OFN_DataEstimativaEmbarque, OFN_FlagVendedor, OFN_EmpresaOriginalId,OFN_FlagLiberaOfertador,OFN_FlagLiberaCliente,OFN_EtapaNegociacaoDirectto,OFN_EtapaNegociacaoOfertador,OFN_EtapaNegociacaoCliente, OFN_TermosPagamento)");
                        strInsert.Append(@" VALUES (@OFN_OfertaxQuantidadeProdutoId,@OFN_EmpresaId,@OFN_StatusPagamentoId,@OFN_NumeroPedido,@OFN_Peso,@OFN_ValorProposta,@OFN_Mensagem,@OFN_FlagContato,@OFN_FlagAceite,GETDATE(),GETDATE(),@OFN_FlagDirectto,@OFN_ContadorOfertador,@OFN_ContadorCliente,@OFN_FlagAtivo, @OFN_MeioTransporteId, @OFN_DataEmbarque, @OFN_DataEstimativaEmbarque, @OFN_FlagVendedor, @OFN_EmpresaOriginalId,0,0,0,0,0, @OFN_TermosPagamento);");
                        strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                        _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString);

                        var queryInsert = _db.Query<int>(strInsert.ToString(),
                            new
                            {
                                OFN_OfertaxQuantidadeProdutoId = objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId,
                                OFN_EmpresaId = objOfertaNegociacao.OFN_EmpresaId,
                                OFN_StatusPagamentoId = objOfertaNegociacao.OFN_StatusPagamentoId,
                                OFN_NumeroPedido = objOfertaNegociacao.OFN_NumeroPedido,
                                OFN_Peso = objOfertaNegociacao.OFN_Peso,
                                OFN_ValorProposta = objOfertaNegociacao.OFN_ValorProposta,
                                OFN_Mensagem = objOfertaNegociacao.OFN_Mensagem,
                                OFN_FlagContato = objOfertaNegociacao.OFN_FlagContato,
                                OFN_FlagAceite = objOfertaNegociacao.OFN_FlagAceite,
                                OFN_FlagDirectto = objOfertaNegociacao.OFN_FlagDirectto,
                                OFN_ContadorOfertador = objOfertaNegociacao.OFN_ContadorOfertador,
                                OFN_ContadorCliente = objOfertaNegociacao.OFN_ContadorCliente,
                                OFN_FlagAtivo = true,
                                OFN_MeioTransporteId = objOfertaNegociacao.OFN_MeioTransporteId,
                                OFN_DataEmbarque = objOfertaNegociacao.OFN_DataEmbarque,
                                OFN_DataEstimativaEmbarque = objOfertaNegociacao.OFN_DataEstimativaEmbarque,
                                OFN_FlagVendedor = objOfertaNegociacao.OFN_FlagVendedor,
                                OFN_EmpresaOriginalId = objOfertaNegociacao.OFN_EmpresaOriginalId,
                                OFN_TermosPagamento = objOfertaNegociacao.OFN_TermosPagamento
                            });

                        if (queryInsert != null && queryInsert.First() > 0)
                            objOfertaNegociacao.OFN_Id = queryInsert.First();
                        salvaLog(objOfertaNegociacao.Log, "", "InsertOfertaNegociacao", strInsert.ToString());
                    }

                    var objON = GetOfertaNegociacaoById(objOfertaNegociacao.OFN_Id,true);
                    return objON;
                }
            }
            catch (Exception e)
            {

                salvaLog(objOfertaNegociacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new OfertaNegociacao();
            }
        }

        public bool UpdateOfertaNegociacao(OfertaNegociacao objOfertaNegociacao)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" UPDATE [OfertaNegociacao] ");
                    strUpdate.Append(@" SET OFN_OfertaxQuantidadeProdutoId = @OFN_OfertaxQuantidadeProdutoId
                        , OFN_EmpresaId = @OFN_EmpresaId
                        , OFN_StatusPagamentoId = @OFN_StatusPagamentoId
                        , OFN_NumeroPedido = @OFN_NumeroPedido
                        , OFN_Peso = @OFN_Peso
                        , OFN_ValorProposta = @OFN_ValorProposta
                        , OFN_Mensagem = @OFN_Mensagem
                        , OFN_FlagContato = @OFN_FlagContato
                        , OFN_FlagAceite = @OFN_FlagAceite
                        , OFN_MeioTransporteId = @OFN_MeioTransporteId
                        , OFN_DataEmbarque = @OFN_DataEmbarque
                        , OFN_DataEstimativaEmbarque = @OFN_DataEstimativaEmbarque
                        , OFN_FlagVendedor = @OFN_FlagVendedor
                        , OFN_EmpresaOriginalId = @OFN_EmpresaOriginalId
                        , OFN_TermosPagamento = @OFN_TermosPagamento
                         WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               OFN_OfertaxQuantidadeProdutoId = objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId,
                               OFN_EmpresaId = objOfertaNegociacao.OFN_EmpresaId,
                               OFN_StatusPagamentoId = objOfertaNegociacao.OFN_StatusPagamentoId,
                               OFN_NumeroPedido = objOfertaNegociacao.OFN_NumeroPedido,
                               OFN_Peso = objOfertaNegociacao.OFN_Peso,
                               OFN_ValorProposta = objOfertaNegociacao.OFN_ValorProposta,
                               OFN_Mensagem = objOfertaNegociacao.OFN_Mensagem,
                               OFN_FlagContato = objOfertaNegociacao.OFN_FlagContato,
                               OFN_FlagAceite = objOfertaNegociacao.OFN_FlagAceite,
                               OFN_MeioTransporteId = objOfertaNegociacao.OFN_MeioTransporteId,
                               OFN_DataEmbarque = objOfertaNegociacao.OFN_DataEmbarque,
                               OFN_DataEstimativaEmbarque = objOfertaNegociacao.OFN_DataEstimativaEmbarque,
                               OFN_FlagVendedor = objOfertaNegociacao.OFN_FlagVendedor,
                               OFN_EmpresaOriginalId = objOfertaNegociacao.OFN_EmpresaOriginalId,
                               OFN_TermosPagamento = objOfertaNegociacao.OFN_TermosPagamento,
                               OFN_Id = objOfertaNegociacao.OFN_Id
                           });
                }
                salvaLog(objOfertaNegociacao.Log, "", "UpdateOfertaNegociacao", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objOfertaNegociacao.Log, "OfertaNegociacaoRepository", "UpdateOfertaNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objOfertaNegociacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarOfertaNegociacao(int OFN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_FlagAtivo = @OFN_FlagAtivo ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_FlagAtivo = 1,
                                            OFN_Id = OFN_Id
                                        });
                }
                salvaLog(null, "", "AtivarOfertaNegociacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "AtivarOfertaNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarOfertaNegociacao(int OFN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_FlagAtivo = @OFN_FlagAtivo ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_FlagAtivo = 0,
                                            OFN_Id = OFN_Id
                                        });
                }
                salvaLog(null, "", "DeletarOfertaNegociacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "DeletarOfertaNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public OfertaNegociacao GetOfertaNegociacaoById(int OFN_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * FROM [OfertaNegociacao] ");

                    OfertaNegociacao obj = null;

                    if (join)
                    {
                        strGet.Append(@" INNER JOIN Empresa on EMP_Id = OFN_EmpresaId ");
                        strGet.Append(@" LEFT JOIN StatusPagamento on SPG_Id = OFN_StatusPagamentoId ");

                        strGet.Append(" WHERE OFN_Id = @OFN_Id");

                        obj = _db.Query<OfertaNegociacao, Empresa, StatusPagamento, OfertaNegociacao>(strGet.ToString(),
                            (objOfertaNegociacao, objEmpresa, objStatusPagamento) =>
                            {
                                var _OfertaxQuantidadeProdutoRepo = new OfertaxQuantidadeProdutoRepository();
                                objOfertaNegociacao.OfertaxQuantidadeProduto = _OfertaxQuantidadeProdutoRepo.GetOfertaxQuantidadeProdutoById(objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId, true);

                                objOfertaNegociacao.Empresa = objEmpresa;

                                var _UsuarioRepo = new UsuarioRepository();
                                objOfertaNegociacao.Empresa.Usuario = _UsuarioRepo.GetUsuarioById(objOfertaNegociacao.Empresa.EMP_UsuarioId, true);


                                objOfertaNegociacao.StatusPagamento = objStatusPagamento;

                                return objOfertaNegociacao;
                            }, new { OFN_Id = OFN_Id },
                            splitOn: " EMP_Id,SPG_Id ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" WHERE OFN_Id = @OFN_Id");
                        obj = _db.Query<OfertaNegociacao>(strGet.ToString(), new { OFN_Id = OFN_Id }).FirstOrDefault();
                    }

                    //if (obj.OFN_EmpresaId == obj.OfertaxQuantidadeProduto.Oferta.OFE_EmpresaId)
                    //    obj.OFN_FlagVendedor = true;
                    //else
                    //    obj.OFN_FlagVendedor = false;

                    StringBuilder strGetEtapa = new StringBuilder();
                    strGetEtapa.Append("SELECT * FROM [EtapaNegociacaoHistorico] ");
                    strGetEtapa.Append("WHERE ENH_OfertaNegociacaoId = @OFN_Id AND ENH_FlagAtivo = 1 ");

                    var objEtapa = _db.Query<EtapaNegociacaoHistorico>(strGetEtapa.ToString(), new { OFN_Id = OFN_Id }).AsEnumerable();
                    obj.listaEtapaNegociacaoHistorico = objEtapa.ToList();

                    salvaLog(null, "", "GetOfertaNegociacaoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "GetOfertaNegociacaoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaNegociacao> GetAllOfertaNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacao] ");
                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN Empresa on EMP_Id = OFN_EmpresaId ");
                        strGetAll.Append(@" LEFT JOIN StatusPagamento on SPG_Id = OFN_StatusPagamentoId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" WHERE OFN_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<OfertaNegociacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaNegociacao, Empresa, StatusPagamento, OfertaNegociacao>(newStrGetAll.ToString(),
                             (objOfertaNegociacao, objEmpresa, objStatusPagamento) =>
                             {
                                 var _OfertaxQuantidadeProdutoRepo = new OfertaxQuantidadeProdutoRepository();
                                 objOfertaNegociacao.OfertaxQuantidadeProduto = _OfertaxQuantidadeProdutoRepo.GetOfertaxQuantidadeProdutoById(objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId, true);

                                 objOfertaNegociacao.Empresa = objEmpresa;
                                 objOfertaNegociacao.StatusPagamento = objStatusPagamento;

                                 return objOfertaNegociacao;
                             }, new { maxInstances = maxInstances },
                            splitOn: " EMP_Id,SPG_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaNegociacao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }


                    salvaLog(null, "", "GetAllOfertaNegociacao", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "GetAllOfertaNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaNegociacao> GetAllOfertaNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacao] ");

                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN Empresa on EMP_Id = OFN_EmpresaId ");
                        strGetAll.Append(@" LEFT JOIN StatusPagamento on SPG_Id = OFN_StatusPagamentoId ");
                    }

                    strGetAll.Append(@" WHERE ({0} LIKE @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND OFN_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<OfertaNegociacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaNegociacao, Empresa, StatusPagamento, OfertaNegociacao>(newStrGetAll.ToString(),
                             (objOfertaNegociacao, objEmpresa, objStatusPagamento) =>
                             {
                                 var _OfertaxQuantidadeProdutoRepo = new OfertaxQuantidadeProdutoRepository();
                                 objOfertaNegociacao.OfertaxQuantidadeProduto = _OfertaxQuantidadeProdutoRepo.GetOfertaxQuantidadeProdutoById(objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId, true);

                                 objOfertaNegociacao.Empresa = objEmpresa;
                                 objOfertaNegociacao.StatusPagamento = objStatusPagamento;

                                 return objOfertaNegociacao;
                             },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " EMP_Id,SPG_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaNegociacao>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaNegociacaoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "GetAllOfertaNegociacaoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaNegociacao> GetAllOfertaNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacao] ");

                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN Empresa on EMP_Id = OFN_EmpresaId ");
                        strGetAll.Append(@" LEFT JOIN StatusPagamento on SPG_Id = OFN_StatusPagamentoId ");
                    }

                    strGetAll.Append(@" WHERE ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND OFN_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<OfertaNegociacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaNegociacao, Empresa, StatusPagamento, OfertaNegociacao>(newStrGetAll.ToString(),
                             (objOfertaNegociacao, objEmpresa, objStatusPagamento) =>
                             {
                                 var _OfertaxQuantidadeProdutoRepo = new OfertaxQuantidadeProdutoRepository();
                                 objOfertaNegociacao.OfertaxQuantidadeProduto = _OfertaxQuantidadeProdutoRepo.GetOfertaxQuantidadeProdutoById(objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId, true);

                                 objOfertaNegociacao.Empresa = objEmpresa;
                                 objOfertaNegociacao.StatusPagamento = objStatusPagamento;

                                 return objOfertaNegociacao;
                             }, new
                             {
                                 strValorExato = strValorExato,
                                 maxInstances = maxInstances
                             },
                            splitOn: " EMP_Id,SPG_Id ").AsEnumerable();

                    }
                    else
                    {
                        lista = _db.Query<OfertaNegociacao>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaNegociacaoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "GetAllOfertaNegociacaoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool AprovarOfertaNegociacao(int OFN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_FlagAceite = @OFN_FlagAceite, ");
                    strUpdate.Append(" OFN_DataAtualizacao = getdate() ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_FlagAceite = 1,
                                            OFN_Id = OFN_Id
                                        });

                    //desativar do card OfertaxQuantidadeProduto

                    var obj = GetOfertaNegociacaoById(OFN_Id, false);
                    StringBuilder strDesativar = new StringBuilder();

                    strDesativar.Append("UPDATE [OfertaxQuantidadeProduto] SET ");
                    strDesativar.Append(" OXQ_FlagAtivo = 0 ");
                    strDesativar.Append(" WHERE OXQ_Id = @OXQ_Id ");
                    _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString);

                    var queryDesativar = _db.Query<int>(strDesativar.ToString(),
                        new
                        {
                            OXQ_Id = obj.OFN_OfertaxQuantidadeProdutoId
                        });

                }
                salvaLog(null, "", "AprovarOfertaNegociacao", strUpdate.ToString());

                

                
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "AprovarOfertaNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool ReprovarOfertaNegociacao(int OFN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_FlagAceite = @OFN_FlagAceite, ");
                    strUpdate.Append(" OFN_FlagAtivo = @OFN_FlagAtivo, ");
                    strUpdate.Append(" OFN_DataAtualizacao = getdate() ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_FlagAceite = 0,
                                            OFN_FlagAtivo = 0,
                                            OFN_Id = OFN_Id
                                        });
                }
                salvaLog(null, "", "ReprovarOfertaNegociacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "ReprovarOfertaNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public IEnumerable<OfertaNegociacao> GetOfertaNegociacaoByEmpresaId(int EmpresaId, bool fSomenteAtivos, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacao] ");


                    strGetAll.Append(@" INNER JOIN Empresa on EMP_Id = OFN_EmpresaId ");
                    strGetAll.Append(@" INNER JOIN OfertaxQuantidadeProduto on OFN_OfertaxQuantidadeProdutoId = OXQ_Id  ");
                    strGetAll.Append(@" INNER JOIN Oferta on OXQ_OfertaId = OFE_Id  ");
                    strGetAll.Append(@" INNER JOIN Empresa EO on EO.EMP_Id = OFE_EmpresaId  ");
                    strGetAll.Append(@" LEFT JOIN StatusPagamento on SPG_Id = OFN_StatusPagamentoId ");


                    strGetAll.Append(@" WHERE OFN_EmpresaId = @EmpresaId or OFE_EmpresaId = @EmpresaId or OFN_EmpresaOriginalId = @EmpresaId ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND OFN_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);
                    IEnumerable<OfertaNegociacao> lista = null;
                    
                    lista = _db.Query<OfertaNegociacao, Empresa, StatusPagamento, OfertaNegociacao>(newStrGetAll.ToString(),
                            (objOfertaNegociacao, objEmpresa, objStatusPagamento) =>
                            {
                                var _OfertaxQuantidadeProdutoRepo = new OfertaxQuantidadeProdutoRepository();
                                objOfertaNegociacao.OfertaxQuantidadeProduto = _OfertaxQuantidadeProdutoRepo.GetOfertaxQuantidadeProdutoById(objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId, true);

                                objOfertaNegociacao.Empresa = objEmpresa;
                                objOfertaNegociacao.StatusPagamento = objStatusPagamento;

                                return objOfertaNegociacao;
                            }, new
                            {
                                EmpresaId = EmpresaId,
                                maxInstances = maxInstances
                            },
                        splitOn: " EMP_Id,SPG_Id ").AsEnumerable();

                    
                    salvaLog(null, "", "GetOfertaNegociacaoByEmpresaId", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "GetOfertaNegociacaoByEmpresaId", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public string GerarCodigo()
        {
            StringBuilder strExiste = new StringBuilder();
            var codigo = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strExiste.Append(" SELECT LEFT(NEWID(), 16) ");
                    codigo = _db.Query<string>(strExiste.ToString()).FirstOrDefault();

                    bool flag = false;
                    while (flag == false)
                    {
                        flag = ValidarCodigo(codigo);
                    }
                    if (flag)
                        return codigo;
                    else
                        return null;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "GerarCodigo", e.InnerException.ToString(), e.Message, e.StackTrace, strExiste.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
        public bool ValidarCodigo(string OFN_NumeroPedido)
        {
            StringBuilder strExiste = new StringBuilder();
            var count = 0;
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strExiste.Append(" select Count(*) from [OfertaNegociacao] where OFN_NumeroPedido = @OFN_NumeroPedido ");
                    count = _db.Query<int>(strExiste.ToString(), new { OFN_NumeroPedido = OFN_NumeroPedido }).FirstOrDefault();

                    if (count == 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "ValidarCodigo", e.InnerException.ToString(), e.Message, e.StackTrace, strExiste.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool OfertaNegociacaoLiberaOfertador(int OFN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_FlagLiberaOfertador = @OFN_FlagLiberaOfertador ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_FlagLiberaOfertador = 1,
                                            OFN_Id = OFN_Id
                                        });
                }
                salvaLog(null, "", "OfertaNegociacaoFlagDirectto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "OfertaNegociacaoFlagDirectto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool OfertaNegociacaoLiberaCliente(int OFN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_FlagLiberaCliente = @OFN_FlagLiberaCliente ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_FlagLiberaCliente = 1,
                                            OFN_Id = OFN_Id
                                        });
                }
                salvaLog(null, "", "OfertaNegociacaoLiberaCliente", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "OfertaNegociacaoLiberaCliente", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool UpdateOfertaNegociacaoDirectto(int OFN_Id, int OFN_MeioTransporteId, DateTime OFN_DataEmbarque, DateTime OFN_DataEstimativaEmbarque, string OFN_TermosPagamento,  int OFN_StatusPagamentoId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_MeioTransporteId = @OFN_MeioTransporteId, ");
                    strUpdate.Append(" OFN_DataEmbarque = @OFN_DataEmbarque, ");
                    strUpdate.Append(" OFN_DataEstimativaEmbarque = @OFN_DataEstimativaEmbarque, ");
                    strUpdate.Append(" OFN_TermosPagamento = @OFN_TermosPagamento, ");
                    strUpdate.Append(" OFN_StatusPagamentoId = @OFN_StatusPagamentoId ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_MeioTransporteId = OFN_MeioTransporteId,
                                            OFN_DataEmbarque = OFN_DataEmbarque,
                                            OFN_DataEstimativaEmbarque = OFN_DataEstimativaEmbarque,
                                            OFN_TermosPagamento = OFN_TermosPagamento,
                                            OFN_StatusPagamentoId = OFN_StatusPagamentoId,
                                            OFN_Id = OFN_Id
                                        });
                }
                salvaLog(null, "", "UpdateOfertaNegociacaoDirectto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "UpdateOfertaNegociacaoDirectto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool UpdateEtapaNegociacaoDirectto(int OFN_Id, int OFN_EtapaNegociacaoDirectto)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_EtapaNegociacaoDirectto = @OFN_EtapaNegociacaoDirectto ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_EtapaNegociacaoDirectto = OFN_EtapaNegociacaoDirectto,
                                            OFN_Id = OFN_Id
                                        });

                    StringBuilder strInsert = new StringBuilder();
                    strInsert.Append("INSERT INTO [EtapaNegociacaoHistorico] ");
                    strInsert.Append("(ENH_OfertaNegociacaoId, ENH_EtapaNegociacaoDirectto, ENH_EtapaNegociacaoOfertador, ENH_EtapaNegociacaoCliente, ENH_DataCadastro, ENH_FlagAtivo)");
                    strInsert.Append(@" VALUES (@ENH_OfertaNegociacaoId, @ENH_EtapaNegociacaoDirectto, 0, 0, getdate(), 1);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString);

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            ENH_OfertaNegociacaoId = OFN_Id,
                            ENH_EtapaNegociacaoDirectto = OFN_EtapaNegociacaoDirectto
                        });

                    //se Etapa 3 - Transporte ou 4 - Entrega, replica no Histórico para Ofertador e Cliente  
                    if (OFN_EtapaNegociacaoDirectto == 3 || OFN_EtapaNegociacaoDirectto == 4)
                    {

                        strInsert = new StringBuilder();
                        strInsert.Append("INSERT INTO [EtapaNegociacaoHistorico] ");
                        strInsert.Append("(ENH_OfertaNegociacaoId, ENH_EtapaNegociacaoDirectto, ENH_EtapaNegociacaoOfertador, ENH_EtapaNegociacaoCliente, ENH_DataCadastro, ENH_FlagAtivo)");
                        strInsert.Append(@" VALUES (@ENH_OfertaNegociacaoId, 0, @ENH_EtapaNegociacaoOfertador, 0, getdate(), 1);");
                        strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                        _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString);

                        queryInsert = _db.Query<int>(strInsert.ToString(),
                            new
                            {
                                ENH_OfertaNegociacaoId = OFN_Id,
                                ENH_EtapaNegociacaoOfertador = OFN_EtapaNegociacaoDirectto
                            });

                        strInsert = new StringBuilder();
                        strInsert.Append("INSERT INTO [EtapaNegociacaoHistorico] ");
                        strInsert.Append("(ENH_OfertaNegociacaoId, ENH_EtapaNegociacaoDirectto, ENH_EtapaNegociacaoOfertador, ENH_EtapaNegociacaoCliente, ENH_DataCadastro, ENH_FlagAtivo)");
                        strInsert.Append(@" VALUES (@ENH_OfertaNegociacaoId, 0, 0, @ENH_EtapaNegociacaoCliente, getdate(), 1);");
                        strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                        _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString);

                        queryInsert = _db.Query<int>(strInsert.ToString(),
                            new
                            {
                                ENH_OfertaNegociacaoId = OFN_Id,
                                ENH_EtapaNegociacaoCliente = OFN_EtapaNegociacaoDirectto
                            });
                    }

                }
                salvaLog(null, "", "UpdateEtapaNegociacaoDirectto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "UpdateEtapaNegociacaoDirectto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool UpdateEtapaNegociacaoOfertador(int OFN_Id, int OFN_EtapaNegociacaoOfertador)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_EtapaNegociacaoOfertador = @OFN_EtapaNegociacaoOfertador ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_EtapaNegociacaoOfertador = OFN_EtapaNegociacaoOfertador,
                                            OFN_Id = OFN_Id
                                        });

                    StringBuilder strInsert = new StringBuilder();
                    strInsert.Append("INSERT INTO [EtapaNegociacaoHistorico] ");
                    strInsert.Append("(ENH_OfertaNegociacaoId, ENH_EtapaNegociacaoDirectto, ENH_EtapaNegociacaoOfertador, ENH_EtapaNegociacaoCliente, ENH_DataCadastro, ENH_FlagAtivo)");
                    strInsert.Append(@" VALUES (@ENH_OfertaNegociacaoId, 0, @ENH_EtapaNegociacaoOfertador, 0, getdate(), 1);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString);

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            ENH_OfertaNegociacaoId = OFN_Id,
                            ENH_EtapaNegociacaoOfertador = OFN_EtapaNegociacaoOfertador
                        });
                }
                salvaLog(null, "", "UpdateEtapaNegociacaoOfertador", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "UpdateEtapaNegociacaoOfertador", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool UpdateEtapaNegociacaoCliente(int OFN_Id, int OFN_EtapaNegociacaoCliente)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(" OFN_EtapaNegociacaoCliente = @OFN_EtapaNegociacaoCliente ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_EtapaNegociacaoCliente = OFN_EtapaNegociacaoCliente,
                                            OFN_Id = OFN_Id
                                        });

                    StringBuilder strInsert = new StringBuilder();
                    strInsert.Append("INSERT INTO [EtapaNegociacaoHistorico] ");
                    strInsert.Append("(ENH_OfertaNegociacaoId, ENH_EtapaNegociacaoDirectto, ENH_EtapaNegociacaoOfertador, ENH_EtapaNegociacaoCliente, ENH_DataCadastro, ENH_FlagAtivo)");
                    strInsert.Append(@" VALUES (@ENH_OfertaNegociacaoId, 0, 0, @ENH_EtapaNegociacaoCliente, getdate(), 1);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString);

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            ENH_OfertaNegociacaoId = OFN_Id,
                            ENH_EtapaNegociacaoCliente = OFN_EtapaNegociacaoCliente
                        });
                }
                salvaLog(null, "", "UpdateEtapaNegociacaoCliente", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "UpdateEtapaNegociacaoCliente", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool UpdateEtapaNegociacaoDatas(int OFN_Id, string CampoData)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacao] SET ");
                    strUpdate.Append(CampoData + " = getdate() ");
                    strUpdate.Append(" WHERE OFN_Id = @OFN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFN_Id = OFN_Id
                                        });
                    
                }
                salvaLog(null, "", "UpdateEtapaNegociacaoDatas", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "UpdateEtapaNegociacaoDatas", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool ValidaRegraVendedorComprador(OfertaNegociacao objOfertaNegociacao)
        {
            StringBuilder strGet1 = new StringBuilder();
            StringBuilder strGet2 = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString);

                    strGet1.Append(" SELECT ofe.* ");
                    strGet1.Append(" FROM [OfertaxQuantidadeProduto] oxq ");
                    strGet1.Append(" INNER JOIN [Oferta] ofe ON ofe.OFE_Id = oxq.OXQ_OfertaId ");
                    strGet1.Append(" WHERE oxq.OXQ_Id = @OFN_OfertaxQuantidadeProdutoId ");

                    var oferta = _db.Query<Oferta>(strGet1.ToString(),
                        new
                        {
                            OFN_OfertaxQuantidadeProdutoId = objOfertaNegociacao.OFN_OfertaxQuantidadeProdutoId
                        }).FirstOrDefault();


                    strGet2.Append(" SELECT EMP_TipoEmpresaId ");
                    strGet2.Append(" FROM [Empresa] ");
                    strGet2.Append(" WHERE EMP_Id = @OFN_EmpresaId ");

                    var EMP_TipoEmpresaId = _db.Query<int>(strGet2.ToString(),
                        new
                        {
                            OFN_EmpresaId = objOfertaNegociacao.OFN_EmpresaId
                        }).FirstOrDefault();

                    if ((oferta.OFE_FlagVender.Value && EMP_TipoEmpresaId == 1) || (!oferta.OFE_FlagVender.Value && EMP_TipoEmpresaId == 2) || (oferta.OFE_FlagVender.Value && EMP_TipoEmpresaId == 2 && oferta.OFE_EmpresaId == objOfertaNegociacao.OFN_EmpresaId))
                        return true;                   
                    else
                        return false;

                }
                salvaLog(null, "", "ValidaRegraVendedorComprador", strGet1.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "ValidaRegraVendedorComprador", e.InnerException.ToString(), e.Message, e.StackTrace, strGet1.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool ValidaExistenciaNegociacao(int OfertaId)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append(" SELECT count(OFN_Id) ");
                    strGet.Append(" FROM [OfertaNegociacao] ");
                    strGet.Append(" INNER JOIN [OfertaxQuantidadeProduto] ON OFN_OfertaxQuantidadeProdutoId = OXQ_Id ");
                    strGet.Append(" WHERE OXQ_OfertaId = @OfertaId ");

                    var valor = _db.Query<int>(strGet.ToString(),
                        new
                        {
                            OfertaId = OfertaId
                        }).FirstOrDefault();


                    if (valor > 0) 
                        return true;
                    else
                        return false;

                }
                salvaLog(null, "", "ValidaExistenciaNegociacao", strGet.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoRepository", "ValidaExistenciaNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}
