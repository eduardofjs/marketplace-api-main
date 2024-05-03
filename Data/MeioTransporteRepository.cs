
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
    public class MeioTransporteRepository : RepositoryBase, IMeioTransporteRepository
    {

        public MeioTransporte InsertMeioTransporte(MeioTransporte objMeioTransporte)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [MeioTransporte] ");
                    strInsert.Append("(MTR_Descricao, MTR_FlagAtivo, MTR_DescricaoIngles, MTR_DataCadastro)");
                    strInsert.Append(@" VALUES (@MTR_Descricao, @MTR_FlagAtivo, @MTR_DescricaoIngles, GETDATE());");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            MTR_Descricao = objMeioTransporte.MTR_Descricao,
                            MTR_FlagAtivo = objMeioTransporte.MTR_FlagAtivo,
                            MTR_DescricaoIngles = objMeioTransporte.MTR_DescricaoIngles,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objMeioTransporte.MTR_Id = queryInsert.First();

                    salvaLog(objMeioTransporte.Log, "", "InsertMeioTransporte", strInsert.ToString());
                    return objMeioTransporte;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objMeioTransporte.Log, "MeioTransporteRepository", "InsertMeioTransporte", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objMeioTransporte.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new MeioTransporte();
            }
        }


        public bool UpdateMeioTransporte(MeioTransporte objMeioTransporte)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [MeioTransporte] ");
                    strUpdate.Append(@" SET MTR_Descricao = @MTR_Descricao
                        , MTR_FlagAtivo = @MTR_FlagAtivo
                        , MTR_DescricaoIngles = @MTR_DescricaoIngles
                         where MTR_Id = @MTR_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               MTR_Descricao = objMeioTransporte.MTR_Descricao,
                               MTR_FlagAtivo = objMeioTransporte.MTR_FlagAtivo,
                               MTR_DescricaoIngles = objMeioTransporte.MTR_DescricaoIngles,
                               MTR_Id = objMeioTransporte.MTR_Id
                           });
                }
                salvaLog(objMeioTransporte.Log, "", "UpdateMeioTransporte", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objMeioTransporte.Log, "MeioTransporteRepository", "UpdateMeioTransporte", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objMeioTransporte.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarMeioTransporte(int MTR_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [MeioTransporte] set ");
                    strUpdate.Append(" MTR_FlagAtivo = @MTR_FlagAtivo ");
                    strUpdate.Append(" where MTR_Id = @MTR_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            MTR_FlagAtivo = 1,
                                            MTR_Id = MTR_Id
                                        });
                }
                salvaLog(null, "", "AtivarMeioTransporte", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "MeioTransporteRepository", "AtivarMeioTransporte", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarMeioTransporte(int MTR_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [MeioTransporte] set ");
                    strUpdate.Append(" MTR_FlagAtivo = @MTR_FlagAtivo ");
                    strUpdate.Append(" where MTR_Id = @MTR_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            MTR_FlagAtivo = 0,
                                            MTR_Id = MTR_Id
                                        });
                }
                salvaLog(null, "", "DeletarMeioTransporte", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "MeioTransporteRepository", "DeletarMeioTransporte", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public MeioTransporte GetMeioTransporteById(int MTR_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [MeioTransporte] ");
                    strGet.Append(" where MTR_Id = @MTR_Id");

                    var obj = _db.Query<MeioTransporte>(strGet.ToString(), new { MTR_Id = MTR_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {

                    }

                    salvaLog(null, "", "GetMeioTransporteById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "MeioTransporteRepository", "GetMeioTransporteById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<MeioTransporte> GetAllMeioTransporte(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [MeioTransporte] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where MTR_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<MeioTransporte>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllMeioTransporte", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "MeioTransporteRepository", "GetAllMeioTransporte", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<MeioTransporte> GetAllMeioTransporteByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  * from [MeioTransporte] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and MTR_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<MeioTransporte>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllMeioTransporteByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "MeioTransporteRepository", "GetAllMeioTransporteByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<MeioTransporte> GetAllMeioTransporteByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [MeioTransporte] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and MTR_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<MeioTransporte>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {

                        }
                    }
                    salvaLog(null, "", "GetAllMeioTransporteByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "MeioTransporteRepository", "GetAllMeioTransporteByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
