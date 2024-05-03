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
    public class StatusDocumentoRepository : RepositoryBase, IStatusDocumentoRepository
    {

        public StatusDocumento InsertStatusDocumento(StatusDocumento objStatusDocumento)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [StatusDocumento] ");
                    strInsert.Append("(SDO_Descricao, SDO_DescricaoIngles, SDO_FlagAtivo)");
                    strInsert.Append(@" VALUES (@SDO_Descricao, @SDO_DescricaoIngles, @SDO_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            SDO_Descricao = objStatusDocumento.SDO_Descricao,
                            SDO_DescricaoIngles = objStatusDocumento.SDO_DescricaoIngles,
                            SDO_FlagAtivo = 1,

                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objStatusDocumento.SDO_Id = queryInsert.First();

                    salvaLog(objStatusDocumento.Log, "", "InsertStatusDocumento", strInsert.ToString());
                    return objStatusDocumento;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objStatusDocumento.Log, "StatusDocumentoRepository", "InsertStatusDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objStatusDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new StatusDocumento();
            }
        }


        public bool UpdateStatusDocumento(StatusDocumento objStatusDocumento)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [StatusDocumento] ");
                    strUpdate.Append(@" SET SDO_Descricao = @SDO_Descricao
                        , SDO_DescricaoIngles = @SDO_DescricaoIngles
                        , SDO_FlagAtivo = @SDO_FlagAtivo
                         where SDO_Id = @SDO_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               SDO_Descricao = objStatusDocumento.SDO_Descricao,
                               SDO_DescricaoIngles = objStatusDocumento.SDO_DescricaoIngles,
                               SDO_FlagAtivo = 1,
                               SDO_Id = objStatusDocumento.SDO_Id
                           });
                }
                salvaLog(objStatusDocumento.Log, "", "UpdateStatusDocumento", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objStatusDocumento.Log, "StatusDocumentoRepository", "UpdateStatusDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objStatusDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarStatusDocumento(int SDO_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [StatusDocumento] set ");
                    strUpdate.Append(" SDO_FlagAtivo = @SDO_FlagAtivo ");
                    strUpdate.Append(" where SDO_Id = @SDO_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SDO_FlagAtivo = 1,
                                            SDO_Id = SDO_Id
                                        });
                }
                salvaLog(null, "", "AtivarStatusDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusDocumentoRepository", "AtivarStatusDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarStatusDocumento(int SDO_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [StatusDocumento] set ");
                    strUpdate.Append(" SDO_FlagAtivo = @SDO_FlagAtivo ");
                    strUpdate.Append(" where SDO_Id = @SDO_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SDO_FlagAtivo = 0,
                                            SDO_Id = SDO_Id
                                        });
                }
                salvaLog(null, "", "DeletarStatusDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusDocumentoRepository", "DeletarStatusDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public StatusDocumento GetStatusDocumentoById(int SDO_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [StatusDocumento] ");
                    strGet.Append(" where SDO_Id = @SDO_Id");

                    var obj = _db.Query<StatusDocumento>(strGet.ToString(), new { SDO_Id = SDO_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetStatusDocumentoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusDocumentoRepository", "GetStatusDocumentoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<StatusDocumento> GetAllStatusDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [StatusDocumento] ");
                    if (join)
                    {

                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where SDO_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<StatusDocumento> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<StatusDocumento,   StatusDocumento>(newStrGetAll.ToString(),
                    //        (objStatusDocumento,    ) => {

                    //            return objStatusDocumento;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<StatusDocumento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    lista = _db.Query<StatusDocumento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    salvaLog(null, "", "GetAllStatusDocumento", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusDocumentoRepository", "GetAllStatusDocumento", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<StatusDocumento> GetAllStatusDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [StatusDocumento] ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SDO_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<StatusDocumento> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<StatusDocumento,   StatusDocumento>(newStrGetAll.ToString(),
                    //        (objStatusDocumento,    ) => {

                    //            return objStatusDocumento;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<StatusDocumento>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}

                    lista = _db.Query<StatusDocumento>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllStatusDocumentoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusDocumentoRepository", "GetAllStatusDocumentoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<StatusDocumento> GetAllStatusDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [StatusDocumento] ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SDO_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<StatusDocumento> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<StatusDocumento,   StatusDocumento>(newStrGetAll.ToString(),
                    //        (objStatusDocumento,    ) => {

                    //            return objStatusDocumento;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "   ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<StatusDocumento>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<StatusDocumento>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllStatusDocumentoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "StatusDocumentoRepository", "GetAllStatusDocumentoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
