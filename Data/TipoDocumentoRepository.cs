
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
    public class TipoDocumentoRepository : RepositoryBase, ITipoDocumentoRepository
    {

        public TipoDocumento InsertTipoDocumento(TipoDocumento objTipoDocumento)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into TipoDocumento ");
                    strInsert.Append("(TDC_Descricao, TDC_Ativo, TDC_flagCirurgia, TDC_flagExame, TDC_flagContaMedica, TDC_flagObrigatorio, TDC_Label)");
                    strInsert.Append(@" VALUES (@TDC_Descricao, @TDC_Ativo, @TDC_flagCirurgia, @TDC_flagExame, @TDC_flagContaMedica, @TDC_flagObrigatorio, @TDC_Label);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            TDC_Descricao = objTipoDocumento.TDC_Descricao,
                            TDC_Ativo = objTipoDocumento.TDC_Ativo,
                            TDC_flagCirurgia = objTipoDocumento.TDC_flagCirurgia,
                            TDC_flagExame = objTipoDocumento.TDC_flagExame,
                            TDC_flagContaMedica = objTipoDocumento.TDC_flagContaMedica,
                            TDC_flagObrigatorio = objTipoDocumento.TDC_flagObrigatorio,
                            TDC_Label = objTipoDocumento.TDC_Label
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objTipoDocumento.TDC_Id = queryInsert.First();

                    salvaLog(objTipoDocumento.Log, "", "InsertTipoDocumento", strInsert.ToString());
                    return objTipoDocumento;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objTipoDocumento.Log, "TipoDocumentoRepository", "InsertTipoDocumento", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objTipoDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new TipoDocumento();
            }
        }


        public bool UpdateTipoDocumento(TipoDocumento objTipoDocumento)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update TipoDocumento ");
                    strUpdate.Append(@" SET TDC_Descricao = @TDC_Descricao
                        , TDC_Ativo = @TDC_Ativo
                        , TDC_flagCirurgia = @TDC_flagCirurgia
                        , TDC_flagExame = @TDC_flagExame
                        , TDC_flagContaMedica = @TDC_flagContaMedica
                        , TDC_flagObrigatorio = @TDC_flagObrigatorio
                        , TDC_Label = @TDC_Label
                         where TDC_Id = @TDC_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               TDC_Descricao = objTipoDocumento.TDC_Descricao,
                               TDC_Ativo = objTipoDocumento.TDC_Ativo,
                               TDC_flagCirurgia = objTipoDocumento.TDC_flagCirurgia,
                               TDC_flagExame = objTipoDocumento.TDC_flagExame,
                               TDC_flagContaMedica = objTipoDocumento.TDC_flagContaMedica,
                               TDC_flagObrigatorio = objTipoDocumento.TDC_flagObrigatorio,
                               TDC_Label = objTipoDocumento.TDC_Label,
                               TDC_Id = objTipoDocumento.TDC_Id
                           });
                }
                salvaLog(objTipoDocumento.Log, "", "UpdateTipoDocumento", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objTipoDocumento.Log, "TipoDocumentoRepository", "UpdateTipoDocumento", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objTipoDocumento.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarTipoDocumento(int TDC_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TipoDocumento set ");
                    strUpdate.Append(" TDC_Ativo = @TDC_Ativo ");
                    strUpdate.Append(" where TDC_Id = @TDC_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TDC_Ativo = 1,
                                            TDC_Id = TDC_Id
                                        });
                }
                salvaLog(null, "", "AtivarTipoDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoDocumentoRepository", "AtivarTipoDocumento", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarTipoDocumento(int TDC_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update TipoDocumento set ");
                    strUpdate.Append(" TDC_Ativo = @TDC_Ativo ");
                    strUpdate.Append(" where TDC_Id = @TDC_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            TDC_Ativo = 0,
                                            TDC_Id = TDC_Id
                                        });
                }
                salvaLog(null, "", "DeletarTipoDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoDocumentoRepository", "DeletarTipoDocumento", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public TipoDocumento GetTipoDocumentoById(int TDC_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from TipoDocumento ");
                    if (join)
                    {

                    }

                    strGet.Append(" where TDC_Id = @TDC_Id");

                    TipoDocumento obj = null;
                    //if (join)
                    //{
                    //obj = _db.Query<TipoDocumento,   TipoDocumento>(strGet.ToString(),
                    //    (objTipoDocumento,    ) => {
                    //           
                    //        return objTipoDocumento;
                    //    }, new { maxInstances = maxInstances }, 
                    //    splitOn:"   ").FirstOrDefault();
                    //}
                    //else
                    //{
                    obj = _db.Query<TipoDocumento>(strGet.ToString(), new { TDC_Id = TDC_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetTipoDocumentoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoDocumentoRepository", "GetTipoDocumentoById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoDocumento> GetAllTipoDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from TipoDocumento ");
                    if (join)
                    {

                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where TDC_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<TipoDocumento> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<TipoDocumento,   TipoDocumento>(newStrGetAll.ToString(),
                    //    (objTipoDocumento,    ) => {
                    //           
                    //        return objTipoDocumento;
                    //    }, new { maxInstances = maxInstances }, 
                    //    splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<TipoDocumento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllTipoDocumento", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoDocumentoRepository", "GetAllTipoDocumento", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<TipoDocumento> GetAllTipoDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from TipoDocumento ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TDC_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<TipoDocumento> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<TipoDocumento,   TipoDocumento>(newStrGetAll.ToString(),
                    //    (objTipoDocumento,    ) => {
                    //           
                    //        return objTipoDocumento;
                    //    },
                    //    new {
                    //        strPartial = "%" + strPartial + "%",
                    //        maxInstances = maxInstances
                    //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<TipoDocumento>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllTipoDocumentoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoDocumentoRepository", "GetAllTipoDocumentoByPartial", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<TipoDocumento> GetAllTipoDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from TipoDocumento ");

                    if (join)
                    {

                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and TDC_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<TipoDocumento> lista = null;
                    //if (join)
                    //{
                    //lista = _db.Query<TipoDocumento,   TipoDocumento>(newStrGetAll.ToString(),
                    //    (objTipoDocumento,    ) => {
                    //           
                    //        return objTipoDocumento;
                    //    },
                    //    new {
                    //        strValorExato = strValorExato,
                    //        maxInstances = maxInstances
                    //    }, splitOn:"   ").AsEnumerable();
                    //}
                    //else
                    //{
                    lista = _db.Query<TipoDocumento>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllTipoDocumentoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "TipoDocumentoRepository", "GetAllTipoDocumentoByValorExato", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
