
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
    public class ServicoAdicionalRepository : RepositoryBase, IServicoAdicionalRepository
    {

        public ServicoAdicional InsertServicoAdicional(ServicoAdicional objServicoAdicional)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [ServicoAdicional] ");
                    strInsert.Append("(SEA_TipoServicoAdicionalId, SEA_Descricao, SEA_FlagAtivo, SEA_DescricaoIngles)");
                    strInsert.Append(@" VALUES (@SEA_TipoServicoAdicionalId, @SEA_Descricao, @SEA_FlagAtivo, @SEA_DescricaoIngles);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            SEA_TipoServicoAdicionalId = objServicoAdicional.SEA_TipoServicoAdicionalId,
                            SEA_Descricao = objServicoAdicional.SEA_Descricao,
                            SEA_FlagAtivo = objServicoAdicional.SEA_FlagAtivo,
                            SEA_DescricaoIngles = objServicoAdicional.SEA_DescricaoIngles,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objServicoAdicional.SEA_Id = queryInsert.First();

                    salvaLog(objServicoAdicional.Log, "", "InsertServicoAdicional", strInsert.ToString());
                    return objServicoAdicional;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objServicoAdicional.Log, "ServicoAdicionalRepository", "InsertServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new ServicoAdicional();
            }
        }


        public bool UpdateServicoAdicional(ServicoAdicional objServicoAdicional)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [ServicoAdicional] ");
                    strUpdate.Append(@" SET SEA_TipoServicoAdicionalId = @SEA_TipoServicoAdicionalId
                        , SEA_Descricao = @SEA_Descricao
                        , SEA_FlagAtivo = @SEA_FlagAtivo
                        , SEA_DescricaoIngles = @SEA_DescricaoIngles
                         where SEA_Id = @SEA_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            SEA_TipoServicoAdicionalId = objServicoAdicional.SEA_TipoServicoAdicionalId,
                            SEA_Descricao = objServicoAdicional.SEA_Descricao,
                            SEA_FlagAtivo = objServicoAdicional.SEA_FlagAtivo,
                            SEA_DescricaoIngles = objServicoAdicional.SEA_DescricaoIngles,
                            SEA_Id = objServicoAdicional.SEA_Id
                        });
                }
                salvaLog(objServicoAdicional.Log, "", "UpdateServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(objServicoAdicional.Log, "ServicoAdicionalRepository", "UpdateServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarServicoAdicional(int SEA_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [ServicoAdicional] set ");
                    strUpdate.Append(" SEA_FlagAtivo = @SEA_FlagAtivo ");
                    strUpdate.Append(" where SEA_Id = @SEA_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            SEA_FlagAtivo = 1,
                            SEA_Id = SEA_Id
                        });
                }
                salvaLog(null, "", "AtivarServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoAdicionalRepository", "AtivarServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarServicoAdicional(int SEA_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [ServicoAdicional] set ");
                    strUpdate.Append(" SEA_FlagAtivo = @SEA_FlagAtivo ");
                    strUpdate.Append(" where SEA_Id = @SEA_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            SEA_FlagAtivo = 0,
                            SEA_Id = SEA_Id
                        });
                }
                salvaLog(null, "", "DeletarServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoAdicionalRepository", "DeletarServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public ServicoAdicional GetServicoAdicionalById(int SEA_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT SEA_Id, SEA_TipoServicoAdicionalId, SEA_Descricao, SEA_FlagAtivo, SEA_DescricaoIngles from [ServicoAdicional] ");
                    strGet.Append(" where SEA_Id = @SEA_Id");

                    var obj = _db.Query<ServicoAdicional>(strGet.ToString(), new { SEA_Id = SEA_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {
                        var _TipoServicoAdicionalRepo = new TipoServicoAdicionalRepository();
                        obj.TipoServicoAdicional = _TipoServicoAdicionalRepo.GetTipoServicoAdicionalById(obj.SEA_TipoServicoAdicionalId, true);
                    }

                    salvaLog(null, "", "GetServicoAdicionalById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoAdicionalRepository", "GetServicoAdicionalById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ServicoAdicional> GetAllServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " SEA_Id, SEA_TipoServicoAdicionalId, SEA_Descricao, SEA_FlagAtivo, SEA_DescricaoIngles from [ServicoAdicional] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where SEA_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<ServicoAdicional>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _TipoServicoAdicionalRepo = new TipoServicoAdicionalRepository();
                            obj.TipoServicoAdicional = _TipoServicoAdicionalRepo.GetTipoServicoAdicionalById(obj.SEA_TipoServicoAdicionalId, true);
                        }
                    }
                    salvaLog(null, "", "GetAllServicoAdicional", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoAdicionalRepository", "GetAllServicoAdicional", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ServicoAdicional> GetAllServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  SEA_Id, SEA_TipoServicoAdicionalId, SEA_Descricao, SEA_FlagAtivo, SEA_DescricaoIngles from [ServicoAdicional] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SEA_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<ServicoAdicional>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _TipoServicoAdicionalRepo = new TipoServicoAdicionalRepository();
                            obj.TipoServicoAdicional = _TipoServicoAdicionalRepo.GetTipoServicoAdicionalById(obj.SEA_TipoServicoAdicionalId, true);
                        }
                    }
                    salvaLog(null, "", "GetAllServicoAdicionalByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoAdicionalRepository", "GetAllServicoAdicionalByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<ServicoAdicional> GetAllServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " SEA_Id, SEA_TipoServicoAdicionalId, SEA_Descricao, SEA_FlagAtivo, SEA_DescricaoIngles from [ServicoAdicional] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SEA_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<ServicoAdicional>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _TipoServicoAdicionalRepo = new TipoServicoAdicionalRepository();
                            obj.TipoServicoAdicional = _TipoServicoAdicionalRepo.GetTipoServicoAdicionalById(obj.SEA_TipoServicoAdicionalId, true);
                        }
                    }
                    salvaLog(null, "", "GetAllServicoAdicionalByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoAdicionalRepository", "GetAllServicoAdicionalByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
