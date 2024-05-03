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
    public class OfertaNegociacaoxStatusNegociacaoRepository : RepositoryBase, IOfertaNegociacaoxStatusNegociacaoRepository
    {

        public OfertaNegociacaoxStatusNegociacao InsertOfertaNegociacaoxStatusNegociacao(OfertaNegociacaoxStatusNegociacao objOfertaNegociacaoxStatusNegociacao)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    //incrementando quantidade de contraOferta de Ofertador ou Cliente
                    StringBuilder strGet = new StringBuilder();
                    strGet.Append("SELECT ONS_Id, EMP_Id as ONS_StatusNegociacaoId, ONS_ContadorOfertador, ONS_ContadorCliente FROM OfertaNegociacaoxStatusNegociacao ");
                    strGet.Append("INNER JOIN OfertaNegociacao ON OFN_Id = ONS_OfertaNegociacaoId ");
                    strGet.Append("INNER JOIN OfertaxQuantidadeProduto ON OXQ_Id = OFN_OfertaxQuantidadeProdutoId");
                    strGet.Append("INNER JOIN Oferta ON OFE_Id = OXQ_OfertaId ");
                    strGet.Append("INNER JOIN Empresa ON EMP_Id = OFE_EmpresaId");
                    strGet.Append("WHERE OFN_OfertaxQuantidadeProdutoId = @OFN_OfertaxQuantidadeProdutoId ");
                    strGet.Append("AND OFN_EmpresaId = @OFN_EmpresaId ");
                    strGet.Append("AND ONS_FlagAtivo = 1 ");

                    var obj = _db.Query<OfertaNegociacaoxStatusNegociacao>(strGet.ToString()).FirstOrDefault();

                    //primeira negociação, é do cliente
                    if (obj == null)
                    {
                        objOfertaNegociacaoxStatusNegociacao.ONS_ContadorCliente = 1;
                        objOfertaNegociacaoxStatusNegociacao.ONS_ContadorOfertador = 0;
                    }
                    else
                    {
                        //verifica se a contraoferta é do cliente ou do ofertador
                        if (obj.ONS_StatusNegociacaoId == objOfertaNegociacaoxStatusNegociacao.ONS_EmpresaId)//ofertador
                            objOfertaNegociacaoxStatusNegociacao.ONS_ContadorOfertador = obj.ONS_ContadorOfertador + 1;
                        else
                            objOfertaNegociacaoxStatusNegociacao.ONS_ContadorCliente = obj.ONS_ContadorCliente + 1;
                    }

                    //Limite máximo de 4 contraofertas para cada
                    if (objOfertaNegociacaoxStatusNegociacao.ONS_ContadorOfertador > 4 || objOfertaNegociacaoxStatusNegociacao.ONS_ContadorCliente > 4)
                    {
                        objOfertaNegociacaoxStatusNegociacao = new OfertaNegociacaoxStatusNegociacao();
                        objOfertaNegociacaoxStatusNegociacao.ONS_Mensagem = "O número de contraofertas excedeu o limite estabelecido. Você será contacto pelo time da directto para sabe como proceder";
                    }
                    else
                    {
                        //desativa a contraoferta atual antes de inserir a nova
                        DeletarOfertaNegociacaoxStatusNegociacao(obj.ONS_Id);

                        strInsert.Append("INSERT INTO [OfertaNegociacaoxStatusNegociacao] ");
                        strInsert.Append("(ONS_OfertaNegociacaoId,ONS_StatusNegociacaoId,ONS_FlagAtivo,ONS_DataCadastro, ONS_ValorProposta, ONS_DataStatusNegociacao, ONS_FlagDirectto, ONS_ContadorOfertador, ONS_ContadorCliente)");
                        strInsert.Append(@" VALUES (@ONS_OfertaNegociacaoId,@ONS_StatusNegociacaoId,@ONS_FlagAtivo,GETDATE(), @ONS_ValorProposta, @ONS_DataStatusNegociacao, @ONS_FlagDirectto, @ONS_ContadorOfertador, @ONS_ContadorCliente);");
                        strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                        var queryInsert = _db.Query<int>(strInsert.ToString(),
                            new
                            {
                                ONS_OfertaNegociacaoId = objOfertaNegociacaoxStatusNegociacao.ONS_OfertaNegociacaoId,
                                ONS_StatusNegociacaoId = objOfertaNegociacaoxStatusNegociacao.ONS_StatusNegociacaoId,
                                ONS_FlagAtivo = true,
                                ONS_ValorProposta = objOfertaNegociacaoxStatusNegociacao.ONS_ValorProposta,
                                ONS_DataStatusNegociacao = objOfertaNegociacaoxStatusNegociacao.ONS_DataStatusNegociacao,
                                ONS_FlagDirectto = objOfertaNegociacaoxStatusNegociacao.ONS_FlagDirectto,
                                ONS_ContadorOfertador = objOfertaNegociacaoxStatusNegociacao.ONS_ContadorOfertador,
                                ONS_ContadorCliente = objOfertaNegociacaoxStatusNegociacao.ONS_ContadorCliente
                            });

                        if (queryInsert != null && queryInsert.First() > 0)
                            objOfertaNegociacaoxStatusNegociacao.ONS_Id = queryInsert.First();
                    }
                    salvaLog(objOfertaNegociacaoxStatusNegociacao.Log, "", "InsertOfertaNegociacaoxStatusNegociacao", strInsert.ToString());
                    return objOfertaNegociacaoxStatusNegociacao;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objOfertaNegociacaoxStatusNegociacao.Log, "OfertaNegociacaoxStatusNegociacaoRepository", "InsertOfertaNegociacaoxStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objOfertaNegociacaoxStatusNegociacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new OfertaNegociacaoxStatusNegociacao();
            }
        }

        public bool UpdateOfertaNegociacaoxStatusNegociacao(OfertaNegociacaoxStatusNegociacao objOfertaNegociacaoxStatusNegociacao)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" UPDATE [OfertaNegociacaoxStatusNegociacao] ");
                    strUpdate.Append(@" SET ONS_OfertaNegociacaoId = @ONS_OfertaNegociacaoId
                        , ONS_StatusNegociacaoId = @ONS_StatusNegociacaoId
                        , ONS_FlagAtivo = @ONS_FlagAtivo
                        , ONS_ValorProposta = @ONS_ValorProposta
                        , ONS_DataStatusNegociacao = @ONS_DataStatusNegociacao
                         WHERE ONS_Id = @ONS_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               ONS_OfertaNegociacaoId = objOfertaNegociacaoxStatusNegociacao.ONS_OfertaNegociacaoId,
                               ONS_StatusNegociacaoId = objOfertaNegociacaoxStatusNegociacao.ONS_StatusNegociacaoId,
                               ONS_FlagAtivo = objOfertaNegociacaoxStatusNegociacao.ONS_FlagAtivo,
                               ONS_ValorProposta = objOfertaNegociacaoxStatusNegociacao.ONS_ValorProposta,
                               ONS_DataStatusNegociacao = objOfertaNegociacaoxStatusNegociacao.ONS_DataStatusNegociacao,
                               ONS_Id = objOfertaNegociacaoxStatusNegociacao.ONS_Id
                           });
                }
                salvaLog(objOfertaNegociacaoxStatusNegociacao.Log, "", "UpdateOfertaNegociacaoxStatusNegociacao", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objOfertaNegociacaoxStatusNegociacao.Log, "OfertaNegociacaoxStatusNegociacaoRepository", "UpdateOfertaNegociacaoxStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objOfertaNegociacaoxStatusNegociacao.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarOfertaNegociacaoxStatusNegociacao(int ONS_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacaoxStatusNegociacao] SET ");
                    strUpdate.Append(" ONS_FlagAtivo = @ONS_FlagAtivo ");
                    strUpdate.Append(" WHERE ONS_Id = @ONS_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ONS_FlagAtivo = 1,
                                            ONS_Id = ONS_Id
                                        });
                }
                salvaLog(null, "", "AtivarOfertaNegociacaoxStatusNegociacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxStatusNegociacaoRepository", "AtivarOfertaNegociacaoxStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarOfertaNegociacaoxStatusNegociacao(int ONS_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE [OfertaNegociacaoxStatusNegociacao] SET ");
                    strUpdate.Append(" ONS_FlagAtivo = @ONS_FlagAtivo ");
                    strUpdate.Append(" WHERE ONS_Id = @ONS_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            ONS_FlagAtivo = 0,
                                            ONS_Id = ONS_Id
                                        });
                }
                salvaLog(null, "", "DeletarOfertaNegociacaoxStatusNegociacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxStatusNegociacaoRepository", "DeletarOfertaNegociacaoxStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public OfertaNegociacaoxStatusNegociacao GetOfertaNegociacaoxStatusNegociacaoById(int ONS_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * FROM [OfertaNegociacaoxStatusNegociacao] ");

                    OfertaNegociacaoxStatusNegociacao obj = null;

                    if (join)
                    {
                        strGet.Append(@" INNER JOIN OfertaNegociacao on OFN_Id = ONS_OfertaNegociacaoId ");
                        strGet.Append(@" INNER JOIN StatusNegociacao on STN_Id = ONS_StatusNegociacaoId ");

                        strGet.Append(" WHERE ONS_Id = @ONS_Id");

                        obj = _db.Query<OfertaNegociacaoxStatusNegociacao, OfertaNegociacao, StatusNegociacao, OfertaNegociacaoxStatusNegociacao>(strGet.ToString(),
                            (objOfertaNegociacaoxStatusNegociacao, objOfertaNegociacao, objStatusNegociacao) => {
                                objOfertaNegociacaoxStatusNegociacao.OfertaNegociacao = objOfertaNegociacao;
                                objOfertaNegociacaoxStatusNegociacao.StatusNegociacao = objStatusNegociacao;

                                return objOfertaNegociacaoxStatusNegociacao;
                            }, new { ONS_Id = ONS_Id },
                            splitOn: " OFN_Id,STN_Id ").FirstOrDefault();
                    }
                    else
                    {
                        strGet.Append(" WHERE ONS_Id = @ONS_Id");
                        obj = _db.Query<OfertaNegociacaoxStatusNegociacao>(strGet.ToString(), new { ONS_Id = ONS_Id }).FirstOrDefault();
                    }

                    salvaLog(null, "", "GetOfertaNegociacaoxStatusNegociacaoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxStatusNegociacaoRepository", "GetOfertaNegociacaoxStatusNegociacaoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacaoxStatusNegociacao] ");
                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN OfertaNegociacao on OFN_Id = ONS_OfertaNegociacaoId ");
                        strGetAll.Append(@" INNER JOIN StatusNegociacao on STN_Id = ONS_StatusNegociacaoId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" WHERE ONS_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<OfertaNegociacaoxStatusNegociacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaNegociacaoxStatusNegociacao, OfertaNegociacao, StatusNegociacao, OfertaNegociacaoxStatusNegociacao>(newStrGetAll.ToString(),
                           (objOfertaNegociacaoxStatusNegociacao, objOfertaNegociacao, objStatusNegociacao) => {
                               objOfertaNegociacaoxStatusNegociacao.OfertaNegociacao = objOfertaNegociacao;
                               objOfertaNegociacaoxStatusNegociacao.StatusNegociacao = objStatusNegociacao;

                               return objOfertaNegociacaoxStatusNegociacao;
                             }, new { maxInstances = maxInstances },
                            splitOn: " OFN_Id,STN_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaNegociacaoxStatusNegociacao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }


                    salvaLog(null, "", "GetAllOfertaNegociacaoxStatusNegociacao", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxStatusNegociacaoRepository", "GetAllOfertaNegociacaoxStatusNegociacao", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacaoxStatusNegociacao] ");

                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN OfertaNegociacao on OFN_Id = ONS_OfertaNegociacaoId ");
                        strGetAll.Append(@" INNER JOIN StatusNegociacao on STN_Id = ONS_StatusNegociacaoId ");
                    }

                    strGetAll.Append(@" WHERE ({0} LIKE @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND ONS_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<OfertaNegociacaoxStatusNegociacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query <OfertaNegociacaoxStatusNegociacao, OfertaNegociacao, StatusNegociacao, OfertaNegociacaoxStatusNegociacao> (newStrGetAll.ToString(),
                             (objOfertaNegociacaoxStatusNegociacao, objOfertaNegociacao, objStatusNegociacao) => {
                                 objOfertaNegociacaoxStatusNegociacao.OfertaNegociacao = objOfertaNegociacao;
                                 objOfertaNegociacaoxStatusNegociacao.StatusNegociacao = objStatusNegociacao;

                                 return objOfertaNegociacaoxStatusNegociacao;
                             },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: " OFN_Id,STN_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaNegociacaoxStatusNegociacao>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaNegociacaoxStatusNegociacaoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxStatusNegociacaoRepository", "GetAllOfertaNegociacaoxStatusNegociacaoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<OfertaNegociacaoxStatusNegociacao> GetAllOfertaNegociacaoxStatusNegociacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * FROM [OfertaNegociacaoxStatusNegociacao] ");

                    if (join)
                    {
                        strGetAll.Append(@" INNER JOIN OfertaNegociacao on OFN_Id = ONS_OfertaNegociacaoId ");
                        strGetAll.Append(@" INNER JOIN StatusNegociacao on STN_Id = ONS_StatusNegociacaoId ");
                    }

                    strGetAll.Append(@" WHERE ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND ONS_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<OfertaNegociacaoxStatusNegociacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaNegociacaoxStatusNegociacao, OfertaNegociacao, StatusNegociacao, OfertaNegociacaoxStatusNegociacao>(newStrGetAll.ToString(),
                               (objOfertaNegociacaoxStatusNegociacao, objOfertaNegociacao, objStatusNegociacao) => {
                                   objOfertaNegociacaoxStatusNegociacao.OfertaNegociacao = objOfertaNegociacao;
                                   objOfertaNegociacaoxStatusNegociacao.StatusNegociacao = objStatusNegociacao;

                                   return objOfertaNegociacaoxStatusNegociacao;
                             }, new
                             {
                                 strValorExato = strValorExato,
                                 maxInstances = maxInstances
                             },
                            splitOn: " OFN_Id,STN_Id ").AsEnumerable();

                    }
                    else
                    {
                        lista = _db.Query<OfertaNegociacaoxStatusNegociacao>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaNegociacaoxStatusNegociacaoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaNegociacaoxStatusNegociacaoRepository", "GetAllOfertaNegociacaoxStatusNegociacaoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
