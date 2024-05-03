
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
    public class NotificacaoRepository : RepositoryBase, INotificacaoRepository
    {
        
        public Notificacao InsertNotificacao(Notificacao objNotificacao)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Notificacao] ");
                    strInsert.Append("(NOT_UsuarioId, NOT_TipoNotificacaoId, NOT_Descricao, NOT_Ativo, NOT_DataEnvioNotificacao, NOT_Lido, NOT_TabelaReferenciaId, NOT_Titulo, NOT_FlagEnviarParaTodos, NOT_DataNotificacaoLida, NOT_LinklExterno)");
                    strInsert.Append(@" VALUES (@NOT_UsuarioId, @NOT_TipoNotificacaoId, @NOT_Descricao, @NOT_Ativo, @NOT_DataEnvioNotificacao, @NOT_Lido, @NOT_TabelaReferenciaId, @NOT_Titulo, @NOT_FlagEnviarParaTodos, @NOT_DataNotificacaoLida, @NOT_LinklExterno);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            NOT_UsuarioId = objNotificacao.NOT_UsuarioId,
                            NOT_TipoNotificacaoId = objNotificacao.NOT_TipoNotificacaoId,
                            NOT_Descricao = objNotificacao.NOT_Descricao,
                            NOT_Ativo = 1,
                            NOT_DataEnvioNotificacao = objNotificacao.NOT_DataEnvioNotificacao,
                            NOT_Lido = objNotificacao.NOT_Lido,
                            NOT_TabelaReferenciaId = objNotificacao.NOT_TabelaReferenciaId,
                            NOT_Titulo = objNotificacao.NOT_Titulo,
                            NOT_FlagEnviarParaTodos = objNotificacao.NOT_FlagEnviarParaTodos,
                            NOT_DataNotificacaoLida = objNotificacao.NOT_DataNotificacaoLida,
                            NOT_LinklExterno = objNotificacao.NOT_LinklExterno,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objNotificacao.NOT_Id = queryInsert.First();

                    salvaLog(objNotificacao.Log, "", "InsertNotificacao", strInsert.ToString());
                    return objNotificacao;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objNotificacao.Log, "NotificacaoRepository", "InsertNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objNotificacao.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Notificacao();
            }
        }


        public bool UpdateNotificacao(Notificacao objNotificacao)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Notificacao] ");
                    strUpdate.Append(@" SET NOT_UsuarioId = @NOT_UsuarioId
                        , NOT_TipoNotificacaoId = @NOT_TipoNotificacaoId
                        , NOT_Descricao = @NOT_Descricao
                        , NOT_Ativo = @NOT_Ativo
                        , NOT_DataEnvioNotificacao = @NOT_DataEnvioNotificacao
                        , NOT_Lido = @NOT_Lido
                        , NOT_TabelaReferenciaId = @NOT_TabelaReferenciaId
                        , NOT_Titulo = @NOT_Titulo
                        , NOT_FlagEnviarParaTodos = @NOT_FlagEnviarParaTodos
                        , NOT_DataNotificacaoLida = @NOT_DataNotificacaoLida
                        , NOT_LinklExterno = @NOT_LinklExterno
                         where NOT_Id = @NOT_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            NOT_UsuarioId = objNotificacao.NOT_UsuarioId,
                            NOT_TipoNotificacaoId = objNotificacao.NOT_TipoNotificacaoId,
                            NOT_Descricao = objNotificacao.NOT_Descricao,
                            NOT_Ativo = 1,
                            NOT_DataEnvioNotificacao = objNotificacao.NOT_DataEnvioNotificacao,
                            NOT_Lido = objNotificacao.NOT_Lido,
                            NOT_TabelaReferenciaId = objNotificacao.NOT_TabelaReferenciaId,
                            NOT_Titulo = objNotificacao.NOT_Titulo,
                            NOT_FlagEnviarParaTodos = objNotificacao.NOT_FlagEnviarParaTodos,
                            NOT_DataNotificacaoLida = objNotificacao.NOT_DataNotificacaoLida,
                            NOT_LinklExterno = objNotificacao.NOT_LinklExterno,
                            
                            NOT_Id = objNotificacao.NOT_Id                            
                           });
                }
                salvaLog(objNotificacao.Log, "", "UpdateNotificacao", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objNotificacao.Log, "NotificacaoRepository", "UpdateNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objNotificacao.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarNotificacao(int NOT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Notificacao] set ");
                    strUpdate.Append(" NOT_Ativo = @NOT_Ativo ");
                    strUpdate.Append(" where NOT_Id = @NOT_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            NOT_Ativo = 1,
                                            NOT_Id = NOT_Id
                                        });
                }
                salvaLog(null, "", "AtivarNotificacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "NotificacaoRepository", "AtivarNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarNotificacao(int NOT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Notificacao] set ");
                    strUpdate.Append(" NOT_Ativo = @NOT_Ativo ");
                    strUpdate.Append(" where NOT_Id = @NOT_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            NOT_Ativo = 0,
                                            NOT_Id = NOT_Id
                                        });
                }
                salvaLog(null, "", "DeletarNotificacao", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "NotificacaoRepository", "DeletarNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Notificacao GetNotificacaoById(int NOT_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT NOT_Id, NOT_UsuarioId, NOT_TipoNotificacaoId, NOT_Descricao, NOT_Ativo, NOT_DataEnvioNotificacao, NOT_Lido, NOT_TabelaReferenciaId, NOT_Titulo, NOT_FlagEnviarParaTodos, NOT_DataNotificacaoLida, NOT_LinklExterno from [Notificacao] ");
                    strGet.Append(" where NOT_Id = @NOT_Id");

                    var obj = _db.Query<Notificacao>(strGet.ToString(), new { NOT_Id = NOT_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                             var _UsuarioRepo = new UsuarioRepository();
                            obj.Usuario = _UsuarioRepo.GetUsuarioById(obj.NOT_UsuarioId.GetValueOrDefault(), true);
                            var _TipoNotificacaoRepo = new TipoNotificacaoRepository();
                            obj.TipoNotificacao = _TipoNotificacaoRepo.GetTipoNotificacaoById(obj.NOT_TipoNotificacaoId.GetValueOrDefault(), true);
                                       
                    }

                    salvaLog(null, "", "GetNotificacaoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "NotificacaoRepository", "GetNotificacaoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Notificacao> GetAllNotificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Notificacao] ");
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on NOT_UsuarioId = USR_Id ");
                        strGetAll.Append(@" join TipoNotificacao on NOT_TipoNotificacaoId = TPN_Id ");
                                 
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where NOT_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Notificacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Notificacao, Usuario, TipoNotificacao,          Notificacao>(newStrGetAll.ToString(),
                            (objNotificacao,  objUsuario,objTipoNotificacao         ) => {
                                 objNotificacao.Usuario = objUsuario;
                                objNotificacao.TipoNotificacao = objTipoNotificacao;
                                         
                                return objNotificacao;
                            }, new { maxInstances = maxInstances }, 
                            splitOn: " USR_Id,TPN_Id         ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Notificacao>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllNotificacao", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "NotificacaoRepository", "GetAllNotificacao", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Notificacao> GetAllNotificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Notificacao] ");
                         
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on NOT_UsuarioId = USR_Id ");
                        strGetAll.Append(@" join TipoNotificacao on NOT_TipoNotificacaoId = TPN_Id ");
                                 
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and NOT_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Notificacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Notificacao, Usuario, TipoNotificacao,          Notificacao>(newStrGetAll.ToString(),
                            (objNotificacao,  objUsuario,objTipoNotificacao         ) => {
                                 objNotificacao.Usuario = objUsuario;
                                objNotificacao.TipoNotificacao = objTipoNotificacao;
                                         
                                return objNotificacao;
                            },
                            new {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }, splitOn: " USR_Id,TPN_Id         ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Notificacao>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllNotificacaoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "NotificacaoRepository", "GetAllNotificacaoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Notificacao> GetAllNotificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Notificacao] ");
                    
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on NOT_UsuarioId = USR_Id ");
                        strGetAll.Append(@" join TipoNotificacao on NOT_TipoNotificacaoId = TPN_Id ");
                                 
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and NOT_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Notificacao> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Notificacao, Usuario, TipoNotificacao,          Notificacao>(newStrGetAll.ToString(),
                            (objNotificacao,  objUsuario,objTipoNotificacao         ) => {
                                 objNotificacao.Usuario = objUsuario;
                                objNotificacao.TipoNotificacao = objTipoNotificacao;
                                         
                                return objNotificacao;
                            },
                            new {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }, splitOn: " USR_Id,TPN_Id         ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Notificacao>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllNotificacaoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "NotificacaoRepository", "GetAllNotificacaoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
