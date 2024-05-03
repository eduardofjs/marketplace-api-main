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
    public class OfertaRepository : RepositoryBase, IOfertaRepository
    {

        public Oferta InsertOferta(Oferta objOferta)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into Oferta ");
                    strInsert.Append("(OFE_FlagVender,OFE_FlagMercadoExterno ,OFE_UsuarioInsercaoId ,OFE_EmpresaId ,OFE_CategoriaId ,OFE_TipoProdutoId ,OFE_ProdutoId ,OFE_ModoCultivoSistemaProdutivoId ,OFE_ModoCultivoModoProducaoId ,OFE_StatusProdutoId ,OFE_EnderecoOrigemId ,OFE_TipoLogisticoSistemaProdutivoId ,OFE_TipoLogisticoPortoId ,OFE_AnoColheita, OFE_Descricao ,OFE_DataCadastro ,OFE_FlagAtivo, OFE_FlagAprovado)");
                    strInsert.Append(@" VALUES (@OFE_FlagVender, @OFE_FlagMercadoExterno ,@OFE_UsuarioInsercaoId ,@OFE_EmpresaId ,@OFE_CategoriaId ,@OFE_TipoProdutoId ,@OFE_ProdutoId ,@OFE_ModoCultivoSistemaProdutivoId ,@OFE_ModoCultivoModoProducaoId ,@OFE_StatusProdutoId ,@OFE_EnderecoOrigemId ,@OFE_TipoLogisticoSistemaProdutivoId ,@OFE_TipoLogisticoPortoId ,@OFE_AnoColheita, @OFE_Descricao ,GETDATE() ,@OFE_FlagAtivo, @OFE_FlagAprovado);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            OFE_FlagVender = objOferta.OFE_FlagVender,
                            OFE_FlagMercadoExterno = objOferta.OFE_FlagMercadoExterno,
                            OFE_UsuarioInsercaoId = objOferta.OFE_UsuarioInsercaoId,
                            OFE_EmpresaId = objOferta.OFE_EmpresaId,
                            OFE_CategoriaId = objOferta.OFE_CategoriaId,
                            OFE_TipoProdutoId = objOferta.OFE_TipoProdutoId,
                            OFE_ProdutoId = objOferta.OFE_ProdutoId,
                            OFE_ModoCultivoSistemaProdutivoId = objOferta.OFE_ModoCultivoSistemaProdutivoId,
                            OFE_ModoCultivoModoProducaoId = objOferta.OFE_ModoCultivoModoProducaoId,
                            OFE_StatusProdutoId = objOferta.OFE_StatusProdutoId,
                            OFE_EnderecoOrigemId = objOferta.OFE_EnderecoOrigemId,
                            OFE_TipoLogisticoSistemaProdutivoId = objOferta.OFE_TipoLogisticoSistemaProdutivoId,
                            OFE_TipoLogisticoPortoId = objOferta.OFE_TipoLogisticoPortoId,                            
                            OFE_AnoColheita = objOferta.OFE_AnoColheita,
                            OFE_Descricao = objOferta.OFE_Descricao,
                            OFE_FlagAtivo = objOferta.OFE_FlagAtivo,
                            OFE_FlagAprovado = objOferta.OFE_FlagAprovado

                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objOferta.OFE_Id = queryInsert.First();

                    salvaLog(objOferta.Log, "", "InsertOferta", strInsert.ToString());
                    return objOferta;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objOferta.Log, "OfertaRepository", "InsertOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objOferta.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Oferta();
            }
        }

        public bool UpdateOferta(Oferta objOferta)
        {
            var _OfertaxServicoAdicionalRepository = new OfertaxServicoAdicionalRepository();
            if (objOferta.listaOfertaxServicoAdicional != null && objOferta.listaOfertaxServicoAdicional.Count > 0)
            {                
                List<OfertaxServicoAdicional> lista = new List<OfertaxServicoAdicional>();
                _OfertaxServicoAdicionalRepository.DeletarOfertaxServicoAdicionalByOferta(objOferta.OFE_Id);
                foreach (OfertaxServicoAdicional item in objOferta.listaOfertaxServicoAdicional)
                {
                    item.OXA_OfertaId = objOferta.OFE_Id;
                    item.OXA_FlagAtivo = false;
                    var data = _OfertaxServicoAdicionalRepository.InsertOfertaxServicoAdicional(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxServicoAdicional = lista;
            }
            else
                _OfertaxServicoAdicionalRepository.DeletarOfertaxServicoAdicionalByOferta(objOferta.OFE_Id);

            var _OfertaxServicoOpcionalRepository = new OfertaxServicoOpcionalRepository();
            if (objOferta.listaOfertaxServicoOpcional != null && objOferta.listaOfertaxServicoOpcional.Count > 0)
            {                
                List<OfertaxServicoOpcional> lista = new List<OfertaxServicoOpcional>();
                _OfertaxServicoOpcionalRepository.DeletarOfertaxServicoOpcionalByOferta(objOferta.OFE_Id);
                foreach (OfertaxServicoOpcional item in objOferta.listaOfertaxServicoOpcional)
                {
                    item.OXS_OfertaId = objOferta.OFE_Id;
                    item.OXS_FlagAtivo = false;
                    var data = _OfertaxServicoOpcionalRepository.InsertOfertaxServicoOpcional(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxServicoOpcional = lista;
            }
            else
                _OfertaxServicoOpcionalRepository.DeletarOfertaxServicoOpcionalByOferta(objOferta.OFE_Id);

            var _OfertaxQuantidadeProdutoRepository = new OfertaxQuantidadeProdutoRepository();
            if (objOferta.listaOfertaxQuantidadeProduto != null && objOferta.listaOfertaxQuantidadeProduto.Count > 0)
            {                
                List<OfertaxQuantidadeProduto> lista = new List<OfertaxQuantidadeProduto>();
                _OfertaxQuantidadeProdutoRepository.DeletarOfertaxQuantidadeProdutoByOferta(objOferta.OFE_Id);
                foreach (OfertaxQuantidadeProduto item in objOferta.listaOfertaxQuantidadeProduto)
                {
                    item.OXQ_OfertaId = objOferta.OFE_Id;
                    item.OXQ_FlagAtivo = false;
                    var data = _OfertaxQuantidadeProdutoRepository.InsertOfertaxQuantidadeProduto(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxQuantidadeProduto = lista;
            }
            else
                _OfertaxQuantidadeProdutoRepository.DeletarOfertaxQuantidadeProdutoByOferta(objOferta.OFE_Id);

            var _OfertaxCertificacaoRepository = new OfertaxCertificacaoRepository();
            if (objOferta.listaOfertaxCertificacao != null && objOferta.listaOfertaxCertificacao.Count > 0)
            {                
                List<OfertaxCertificacao> lista = new List<OfertaxCertificacao>();
                _OfertaxCertificacaoRepository.DeletarOfertaxCertificacaoByOferta(objOferta.OFE_Id);
                foreach (OfertaxCertificacao item in objOferta.listaOfertaxCertificacao)
                {
                    item.OXC_OfertaId = objOferta.OFE_Id;
                    item.OXC_FlagAtivo = false;
                    var data = _OfertaxCertificacaoRepository.InsertOfertaxCertificacao(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxCertificacao = lista;
            }
            else
            {
                _OfertaxCertificacaoRepository.DeletarOfertaxCertificacaoByOferta(objOferta.OFE_Id);
            }

            var _OfertaxDocumentoRepository = new OfertaxDocumentoRepository();
            if (objOferta.listaOfertaxDocumento != null && objOferta.listaOfertaxDocumento.Count > 0)
            {             
                List<OfertaxDocumento> lista = new List<OfertaxDocumento>();
                _OfertaxDocumentoRepository.DeletarOfertaxDocumentoByOferta(objOferta.OFE_Id);
                foreach (OfertaxDocumento item in objOferta.listaOfertaxDocumento)
                {
                    item.OXD_OfertaId = objOferta.OFE_Id;
                    item.OXD_FlagAtivo = true;
                    var data = _OfertaxDocumentoRepository.InsertOfertaxDocumento(item);
                    lista.Add(data);
                }

                objOferta.listaOfertaxDocumento = lista;
            }
            else
                _OfertaxDocumentoRepository.DeletarOfertaxDocumentoByOferta(objOferta.OFE_Id);
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update Oferta ");
                    strUpdate.Append(@" SET OFE_FlagVender = @OFE_FlagVender,
                                    OFE_FlagMercadoExterno = @OFE_FlagMercadoExterno,
                                    OFE_UsuarioInsercaoId = @OFE_UsuarioInsercaoId,
                                    OFE_EmpresaId = @OFE_EmpresaId,
                                    OFE_CategoriaId = @OFE_CategoriaId,
                                    OFE_TipoProdutoId = @OFE_TipoProdutoId,
                                    OFE_ProdutoId = @OFE_ProdutoId,
                                    OFE_ModoCultivoSistemaProdutivoId = @OFE_ModoCultivoSistemaProdutivoId,
                                    OFE_ModoCultivoModoProducaoId = @OFE_ModoCultivoModoProducaoId,
                                    OFE_StatusProdutoId = @OFE_StatusProdutoId,
                                    OFE_EnderecoOrigemId = @OFE_EnderecoOrigemId,
                                    OFE_TipoLogisticoSistemaProdutivoId = @OFE_TipoLogisticoSistemaProdutivoId,
                                    OFE_TipoLogisticoPortoId = @OFE_TipoLogisticoPortoId,                                    
                                    OFE_AnoColheita = @OFE_AnoColheita,                          
                                    OFE_Descricao = @OFE_Descricao,
                                    OFE_FlagAtivo = @OFE_FlagAtivo,
                                    OFE_UsuarioAlteracaoId = @OFE_UsuarioAlteracaoId,
                                    OFE_DataAlteracao = GETDATE()
                         where OFE_Id = @OFE_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               OFE_FlagVender = objOferta.OFE_FlagVender,
                               OFE_FlagMercadoExterno = objOferta.OFE_FlagMercadoExterno,
                               OFE_UsuarioInsercaoId = objOferta.OFE_UsuarioInsercaoId,
                               OFE_EmpresaId = objOferta.OFE_EmpresaId,
                               OFE_CategoriaId = objOferta.OFE_CategoriaId,
                               OFE_TipoProdutoId = objOferta.OFE_TipoProdutoId,
                               OFE_ProdutoId = objOferta.OFE_ProdutoId,
                               OFE_ModoCultivoSistemaProdutivoId = objOferta.OFE_ModoCultivoSistemaProdutivoId,
                               OFE_ModoCultivoModoProducaoId = objOferta.OFE_ModoCultivoModoProducaoId,
                               OFE_StatusProdutoId = objOferta.OFE_StatusProdutoId,
                               OFE_EnderecoOrigemId = objOferta.OFE_EnderecoOrigemId,
                               OFE_TipoLogisticoSistemaProdutivoId = objOferta.OFE_TipoLogisticoSistemaProdutivoId,
                               OFE_TipoLogisticoPortoId = objOferta.OFE_TipoLogisticoPortoId,                               
                               OFE_AnoColheita = objOferta.OFE_AnoColheita,
                               OFE_Descricao = objOferta.OFE_Descricao,
                               OFE_FlagAtivo = objOferta.OFE_FlagAtivo,
                               OFE_UsuarioAlteracaoId = objOferta.OFE_UsuarioAlteracaoId,
                               OFE_Id = objOferta.OFE_Id
                           });
                }
                salvaLog(objOferta.Log, "", "UpdateOferta", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objOferta.Log, "OfertaRepository", "UpdateOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objOferta.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarOferta(int OFE_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Oferta set ");
                    strUpdate.Append(" OFE_FlagAtivo = @OFE_FlagAtivo ");
                    strUpdate.Append(" where OFE_Id = @OFE_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFE_FlagAtivo = 1,
                                            OFE_Id = OFE_Id
                                        });
                }
                salvaLog(null, "", "AtivarOferta", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaRepository", "AtivarOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarOferta(int OFE_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Oferta set ");
                    strUpdate.Append(" OFE_FlagAtivo = @OFE_FlagAtivo ");
                    strUpdate.Append(" where OFE_Id = @OFE_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFE_FlagAtivo = 0,
                                            OFE_Id = OFE_Id
                                        });
                }
                salvaLog(null, "", "DeletarOferta", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaRepository", "DeletarOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Oferta GetOfertaById(int OFE_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from Oferta ");
                    if (join)
                    {
                        strGet.Append(@" inner join [Empresa] on EMP_Id = OFE_EmpresaId ");
                        strGet.Append(@" inner join [Categoria] on CAT_Id = OFE_CategoriaId ");
                        strGet.Append(@" inner join [TipoProduto] on TPR_Id = OFE_TipoProdutoId ");
                        strGet.Append(@" inner join [Produto] on PDT_Id = OFE_ProdutoId ");
                        strGet.Append(@" inner join [ModoCultivoSistemaProdutivo] on MCS_Id = OFE_ModoCultivoSistemaProdutivoId ");
                        strGet.Append(@" inner join [ModoCultivoModoProducao] on MCM_Id = OFE_ModoCultivoModoProducaoId ");
                    }

                    strGet.Append(" where OFE_Id = @OFE_Id");

                    Oferta obj = null;
                    if (join)
                    {
                        obj = _db.Query<Oferta, Empresa, Categoria, TipoProduto, Produto, ModoCultivoSistemaProdutivo, ModoCultivoModoProducao, Oferta>(strGet.ToString(),
                            (objOferta, objEmpresa, objCategoria, objTipoProduto, objProduto, objModoCultivoSistemaProdutivo, objModoCultivoModoProducao) =>
                            {
                                objOferta.Empresa = objEmpresa;
                                objOferta.Categoria = objCategoria;
                                objOferta.TipoProduto = objTipoProduto;
                                objOferta.Produto = objProduto;
                                objOferta.ModoCultivoSistemaProdutivo = objModoCultivoSistemaProdutivo;
                                objOferta.ModoCultivoModoProducao = objModoCultivoModoProducao;

                                var _UsuarioRepo = new UsuarioRepository();
                                objOferta.Usuario = _UsuarioRepo.GetUsuarioById(objOferta.OFE_UsuarioInsercaoId, true);
                                objOferta.Empresa.Usuario = _UsuarioRepo.GetUsuarioById(objOferta.Empresa.EMP_UsuarioId, true);

                                var _StatusProdutoRepo = new StatusProdutoRepository();
                                objOferta.StatusProduto = _StatusProdutoRepo.GetStatusProdutoById(objOferta.OFE_StatusProdutoId, true);

                                var _EnderecoRepo = new EnderecoRepository();
                                objOferta.Endereco = _EnderecoRepo.GetEnderecoById(objOferta.OFE_EnderecoOrigemId, true);

                                var _TipoLogisticoSistemaProdutivoRepo = new TipoLogisticoSistemaProdutivoRepository();
                                objOferta.TipoLogisticoSistemaProdutivo = _TipoLogisticoSistemaProdutivoRepo.GetTipoLogisticoSistemaProdutivoById(objOferta.OFE_TipoLogisticoSistemaProdutivoId, true);

                                var _TipoLogisticoPortoRepo = new TipoLogisticoPortoRepository();
                                objOferta.TipoLogisticoPorto = _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(objOferta.OFE_TipoLogisticoPortoId, true);
                                                                
                                return objOferta;
                            }, new { OFE_Id = OFE_Id },
                            splitOn: "EMP_Id,CAT_Id,TPR_Id,PDT_Id,MCS_Id,MCM_Id").FirstOrDefault();
                    }
                    else
                    {
                        obj = _db.Query<Oferta>(strGet.ToString(), new { OFE_Id = OFE_Id }).FirstOrDefault();
                    }


                    salvaLog(null, "", "GetOfertaById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaRepository", "GetOfertaById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Oferta> GetAllOferta(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from Oferta ");
                    if (join)
                    {
                        strGetAll.Append(@" inner join [Empresa] on EMP_Id = OFE_EmpresaId ");
                        strGetAll.Append(@" inner join [Categoria] on CAT_Id = OFE_CategoriaId ");
                        strGetAll.Append(@" inner join [TipoProduto] on TPR_Id = OFE_TipoProdutoId ");
                        strGetAll.Append(@" inner join [Produto] on PDT_Id = OFE_ProdutoId ");
                        strGetAll.Append(@" inner join [ModoCultivoSistemaProdutivo] on MCS_Id = OFE_ModoCultivoSistemaProdutivoId ");
                        strGetAll.Append(@" inner join [ModoCultivoModoProducao] on MCM_Id = OFE_ModoCultivoModoProducaoId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where OFE_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<Oferta> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Oferta, Empresa, Categoria, TipoProduto, Produto, ModoCultivoSistemaProdutivo, ModoCultivoModoProducao, Oferta>(newStrGetAll.ToString(),
                            (objOferta, objEmpresa, objCategoria, objTipoProduto, objProduto, objModoCultivoSistemaProdutivo, objModoCultivoModoProducao) =>
                            {
                                objOferta.Empresa = objEmpresa;
                                objOferta.Categoria = objCategoria;
                                objOferta.TipoProduto = objTipoProduto;
                                objOferta.Produto = objProduto;
                                objOferta.ModoCultivoSistemaProdutivo = objModoCultivoSistemaProdutivo;
                                objOferta.ModoCultivoModoProducao = objModoCultivoModoProducao;

                                var _UsuarioRepo = new UsuarioRepository();
                                objOferta.Usuario = _UsuarioRepo.GetUsuarioById(objOferta.OFE_UsuarioInsercaoId, true);

                                var _StatusProdutoRepo = new StatusProdutoRepository();
                                objOferta.StatusProduto = _StatusProdutoRepo.GetStatusProdutoById(objOferta.OFE_StatusProdutoId, true);

                                var _EnderecoRepo = new EnderecoRepository();
                                objOferta.Endereco = _EnderecoRepo.GetEnderecoById(objOferta.OFE_EnderecoOrigemId, true);

                                var _TipoLogisticoSistemaProdutivoRepo = new TipoLogisticoSistemaProdutivoRepository();
                                objOferta.TipoLogisticoSistemaProdutivo = _TipoLogisticoSistemaProdutivoRepo.GetTipoLogisticoSistemaProdutivoById(objOferta.OFE_TipoLogisticoSistemaProdutivoId, true);

                                var _TipoLogisticoPortoRepo = new TipoLogisticoPortoRepository();
                                objOferta.TipoLogisticoPorto = _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(objOferta.OFE_TipoLogisticoPortoId, true);

                                return objOferta;
                            }, new { maxInstances = maxInstances },
                            splitOn: "EMP_Id,CAT_Id,TPR_Id,PDT_Id,MCS_Id,MCM_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Oferta>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOferta", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaRepository", "GetAllOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Oferta> GetAllOfertaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from Oferta ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join [Empresa] on EMP_Id = OFE_EmpresaId ");
                        strGetAll.Append(@" inner join [Categoria] on CAT_Id = OFE_CategoriaId ");
                        strGetAll.Append(@" inner join [TipoProduto] on TPR_Id = OFE_TipoProdutoId ");
                        strGetAll.Append(@" inner join [Produto] on PDT_Id = OFE_ProdutoId ");
                        strGetAll.Append(@" inner join [ModoCultivoSistemaProdutivo] on MCS_Id = OFE_ModoCultivoSistemaProdutivoId ");
                        strGetAll.Append(@" inner join [ModoCultivoModoProducao] on MCM_Id = OFE_ModoCultivoModoProducaoId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OFE_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Oferta> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Oferta, Empresa, Categoria, TipoProduto, Produto, ModoCultivoSistemaProdutivo, ModoCultivoModoProducao, Oferta>(newStrGetAll.ToString(),
                            (objOferta, objEmpresa, objCategoria, objTipoProduto, objProduto, objModoCultivoSistemaProdutivo, objModoCultivoModoProducao) =>
                            {
                                objOferta.Empresa = objEmpresa;
                                objOferta.Categoria = objCategoria;
                                objOferta.TipoProduto = objTipoProduto;
                                objOferta.Produto = objProduto;
                                objOferta.ModoCultivoSistemaProdutivo = objModoCultivoSistemaProdutivo;
                                objOferta.ModoCultivoModoProducao = objModoCultivoModoProducao;

                                var _UsuarioRepo = new UsuarioRepository();
                                objOferta.Usuario = _UsuarioRepo.GetUsuarioById(objOferta.OFE_UsuarioInsercaoId, true);

                                var _StatusProdutoRepo = new StatusProdutoRepository();
                                objOferta.StatusProduto = _StatusProdutoRepo.GetStatusProdutoById(objOferta.OFE_StatusProdutoId, true);

                                var _EnderecoRepo = new EnderecoRepository();
                                objOferta.Endereco = _EnderecoRepo.GetEnderecoById(objOferta.OFE_EnderecoOrigemId, true);

                                var _TipoLogisticoSistemaProdutivoRepo = new TipoLogisticoSistemaProdutivoRepository();
                                objOferta.TipoLogisticoSistemaProdutivo = _TipoLogisticoSistemaProdutivoRepo.GetTipoLogisticoSistemaProdutivoById(objOferta.OFE_TipoLogisticoSistemaProdutivoId, true);

                                var _TipoLogisticoPortoRepo = new TipoLogisticoPortoRepository();
                                objOferta.TipoLogisticoPorto = _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(objOferta.OFE_TipoLogisticoPortoId, true);

                                return objOferta;
                            }, new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: "EMP_Id,CAT_Id,TPR_Id,PDT_Id,MCS_Id,MCM_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Oferta>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaRepository", "GetAllOfertaByPartial", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Oferta> GetAllOfertaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from Oferta ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join [Empresa] on EMP_Id = OFE_EmpresaId ");
                        strGetAll.Append(@" inner join [Categoria] on CAT_Id = OFE_CategoriaId ");
                        strGetAll.Append(@" inner join [TipoProduto] on TPR_Id = OFE_TipoProdutoId ");
                        strGetAll.Append(@" inner join [Produto] on PDT_Id = OFE_ProdutoId ");
                        strGetAll.Append(@" inner join [ModoCultivoSistemaProdutivo] on MCS_Id = OFE_ModoCultivoSistemaProdutivoId ");
                        strGetAll.Append(@" inner join [ModoCultivoModoProducao] on MCM_Id = OFE_ModoCultivoModoProducaoId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OFE_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Oferta> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Oferta, Empresa, Categoria, TipoProduto, Produto, ModoCultivoSistemaProdutivo, ModoCultivoModoProducao, Oferta>(newStrGetAll.ToString(),
                            (objOferta, objEmpresa, objCategoria, objTipoProduto, objProduto, objModoCultivoSistemaProdutivo, objModoCultivoModoProducao) =>
                            {
                                objOferta.Empresa = objEmpresa;
                                objOferta.Categoria = objCategoria;
                                objOferta.TipoProduto = objTipoProduto;
                                objOferta.Produto = objProduto;
                                objOferta.ModoCultivoSistemaProdutivo = objModoCultivoSistemaProdutivo;
                                objOferta.ModoCultivoModoProducao = objModoCultivoModoProducao;

                                var _UsuarioRepo = new UsuarioRepository();
                                objOferta.Usuario = _UsuarioRepo.GetUsuarioById(objOferta.OFE_UsuarioInsercaoId, true);

                                var _StatusProdutoRepo = new StatusProdutoRepository();
                                objOferta.StatusProduto = _StatusProdutoRepo.GetStatusProdutoById(objOferta.OFE_StatusProdutoId, true);

                                var _EnderecoRepo = new EnderecoRepository();
                                objOferta.Endereco = _EnderecoRepo.GetEnderecoById(objOferta.OFE_EnderecoOrigemId, true);

                                var _TipoLogisticoSistemaProdutivoRepo = new TipoLogisticoSistemaProdutivoRepository();
                                objOferta.TipoLogisticoSistemaProdutivo = _TipoLogisticoSistemaProdutivoRepo.GetTipoLogisticoSistemaProdutivoById(objOferta.OFE_TipoLogisticoSistemaProdutivoId, true);

                                var _TipoLogisticoPortoRepo = new TipoLogisticoPortoRepository();
                                objOferta.TipoLogisticoPorto = _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(objOferta.OFE_TipoLogisticoPortoId, true);

                                return objOferta;
                            }, new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: "EMP_Id,CAT_Id,TPR_Id,PDT_Id,MCS_Id,MCM_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Oferta>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllOfertaByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaRepository", "GetAllOfertaByValorExato", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool AprovarOferta(int OFE_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Oferta set ");
                    strUpdate.Append(" OFE_FlagAprovado = @OFE_FlagAprovado, ");
                    strUpdate.Append(" OFE_DataAprovado = GETDATE() ");
                    strUpdate.Append(" where OFE_Id = @OFE_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFE_FlagAprovado = 1,
                                            OFE_Id = OFE_Id
                                        });
                }
                salvaLog(null, "", "AprovarOferta", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaRepository", "AprovarOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool ReprovarOferta(int OFE_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Oferta set ");
                    strUpdate.Append(" OFE_FlagAprovado = @OFE_FlagAprovado, ");
                    strUpdate.Append(" OFE_DataReprovado = GETDATE() ");
                    strUpdate.Append(" where OFE_Id = @OFE_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OFE_FlagAprovado = 0,
                                            OFE_Id = OFE_Id
                                        });
                }
                salvaLog(null, "", "ReprovarOferta", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaRepository", "ReprovarOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Oferta GetOfertaEditarById(int OFE_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from Oferta ");
                    if (join)
                    {
                        strGet.Append(@" inner join [Empresa] on EMP_Id = OFE_EmpresaId ");
                        strGet.Append(@" inner join [Categoria] on CAT_Id = OFE_CategoriaId ");
                        strGet.Append(@" inner join [TipoProduto] on TPR_Id = OFE_TipoProdutoId ");
                        strGet.Append(@" inner join [Produto] on PDT_Id = OFE_ProdutoId ");
                        strGet.Append(@" inner join [ModoCultivoSistemaProdutivo] on MCS_Id = OFE_ModoCultivoSistemaProdutivoId ");
                        strGet.Append(@" inner join [ModoCultivoModoProducao] on MCM_Id = OFE_ModoCultivoModoProducaoId ");
                    }

                    strGet.Append(" where OFE_Id = @OFE_Id");

                    Oferta obj = null;
                    if (join)
                    {
                        obj = _db.Query<Oferta, Empresa, Categoria, TipoProduto, Produto, ModoCultivoSistemaProdutivo, ModoCultivoModoProducao, Oferta>(strGet.ToString(),
                            (objOferta, objEmpresa, objCategoria, objTipoProduto, objProduto, objModoCultivoSistemaProdutivo, objModoCultivoModoProducao) =>
                            {
                                objOferta.Empresa = objEmpresa;
                                objOferta.Categoria = objCategoria;
                                objOferta.TipoProduto = objTipoProduto;
                                objOferta.Produto = objProduto;
                                objOferta.ModoCultivoSistemaProdutivo = objModoCultivoSistemaProdutivo;
                                objOferta.ModoCultivoModoProducao = objModoCultivoModoProducao;

                                var _UsuarioRepo = new UsuarioRepository();
                                objOferta.Usuario = _UsuarioRepo.GetUsuarioById(objOferta.OFE_UsuarioInsercaoId, true);
                                objOferta.Empresa.Usuario = _UsuarioRepo.GetUsuarioById(objOferta.Empresa.EMP_UsuarioId, true);

                                var _StatusProdutoRepo = new StatusProdutoRepository();
                                objOferta.StatusProduto = _StatusProdutoRepo.GetStatusProdutoById(objOferta.OFE_StatusProdutoId, true);

                                var _EnderecoRepo = new EnderecoRepository();
                                objOferta.Endereco = _EnderecoRepo.GetEnderecoById(objOferta.OFE_EnderecoOrigemId, true);

                                var _TipoLogisticoSistemaProdutivoRepo = new TipoLogisticoSistemaProdutivoRepository();
                                objOferta.TipoLogisticoSistemaProdutivo = _TipoLogisticoSistemaProdutivoRepo.GetTipoLogisticoSistemaProdutivoById(objOferta.OFE_TipoLogisticoSistemaProdutivoId, true);

                                var _TipoLogisticoPortoRepo = new TipoLogisticoPortoRepository();
                                objOferta.TipoLogisticoPorto = _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(objOferta.OFE_TipoLogisticoPortoId, true);

                                var _OfertaxCertificacaoRepo = new OfertaxCertificacaoRepository();
                                objOferta.listaOfertaxCertificacao = _OfertaxCertificacaoRepo.GetAllOfertaxCertificacaoByValorExato(objOferta.OFE_Id.ToString(), "OXC_OfertaId", true, true).ToList();

                                var _OfertaxDocumentoRepo = new OfertaxDocumentoRepository();
                                objOferta.listaOfertaxDocumento = _OfertaxDocumentoRepo.GetAllOfertaxDocumentoByValorExato(objOferta.OFE_Id.ToString(), "OXD_OfertaId", true, true).ToList();

                                var _OfertaxQuantidadeProdutoRepo = new OfertaxQuantidadeProdutoRepository();
                                objOferta.listaOfertaxQuantidadeProduto = _OfertaxQuantidadeProdutoRepo.GetAllOfertaxQuantidadeProdutoByValorExato(objOferta.OFE_Id.ToString(), "OXQ_OfertaId", true, true).ToList();

                                var _OfertaxServicoAdicionalRepo = new OfertaxServicoAdicionalRepository();
                                objOferta.listaOfertaxServicoAdicional = _OfertaxServicoAdicionalRepo.GetAllOfertaxServicoAdicionalByValorExato(objOferta.OFE_Id.ToString(), "OXA_OfertaId", true, true).ToList();

                                var _OfertaxServicoOpcionalRepo = new OfertaxServicoOpcionalRepository();
                                objOferta.listaOfertaxServicoOpcional = _OfertaxServicoOpcionalRepo.GetAllOfertaxServicoOpcionalByValorExato(objOferta.OFE_Id.ToString(), "OXS_OfertaId", true, true).ToList();

                                return objOferta;
                            }, new { OFE_Id = OFE_Id },
                            splitOn: "EMP_Id,CAT_Id,TPR_Id,PDT_Id,MCS_Id,MCM_Id").FirstOrDefault();
                    }
                    else
                    {
                        obj = _db.Query<Oferta>(strGet.ToString(), new { OFE_Id = OFE_Id }).FirstOrDefault();
                    }


                    salvaLog(null, "", "GetOfertaEditarById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaRepository", "GetOfertaEditarById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}



