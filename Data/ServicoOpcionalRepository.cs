
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
    public class ServicoOpcionalRepository : RepositoryBase, IServicoOpcionalRepository
    {

        public ServicoOpcional InsertServicoOpcional(ServicoOpcional objServicoOpcional)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [ServicoOpcional] ");
                    strInsert.Append("(SEO_Descricao, SEO_FlagAtivo, SEO_DescricaoIngles, SEO_TipoLogisticoPortoId)");
                    strInsert.Append(@" VALUES (@SEO_Descricao, @SEO_FlagAtivo, @SEO_DescricaoIngles, @SEO_TipoLogisticoPortoId);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            SEO_Descricao = objServicoOpcional.SEO_Descricao,
                            SEO_FlagAtivo = objServicoOpcional.SEO_FlagAtivo,
                            SEO_DescricaoIngles = objServicoOpcional.SEO_DescricaoIngles,
                            SEO_TipoLogisticoPortoId = objServicoOpcional.SEO_TipoLogisticoPortoId,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objServicoOpcional.SEO_Id = queryInsert.First();

                    salvaLog(objServicoOpcional.Log, "", "InsertServicoOpcional", strInsert.ToString());
                    return objServicoOpcional;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objServicoOpcional.Log, "ServicoOpcionalRepository", "InsertServicoOpcional", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objServicoOpcional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new ServicoOpcional();
            }
        }


        public bool UpdateServicoOpcional(ServicoOpcional objServicoOpcional)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [ServicoOpcional] ");
                    strUpdate.Append(@" SET SEO_Descricao = @SEO_Descricao
                        , SEO_FlagAtivo = @SEO_FlagAtivo
                        , SEO_DescricaoIngles = @SEO_DescricaoIngles
                        , SEO_TipoLogisticoPortoId = @SEO_TipoLogisticoPortoId
                         where SEO_Id = @SEO_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            SEO_Descricao = objServicoOpcional.SEO_Descricao,
                            SEO_FlagAtivo = objServicoOpcional.SEO_FlagAtivo,
                            SEO_DescricaoIngles = objServicoOpcional.SEO_DescricaoIngles,
                            SEO_TipoLogisticoPortoId = objServicoOpcional.SEO_TipoLogisticoPortoId,
                            SEO_Id = objServicoOpcional.SEO_Id
                        });
                }
                salvaLog(objServicoOpcional.Log, "", "UpdateServicoOpcional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(objServicoOpcional.Log, "ServicoOpcionalRepository", "UpdateServicoOpcional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objServicoOpcional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarServicoOpcional(int SEO_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [ServicoOpcional] set ");
                    strUpdate.Append(" SEO_FlagAtivo = @SEO_FlagAtivo ");
                    strUpdate.Append(" where SEO_Id = @SEO_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            SEO_FlagAtivo = 1,
                            SEO_Id = SEO_Id
                        });
                }
                salvaLog(null, "", "AtivarServicoOpcional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoOpcionalRepository", "AtivarServicoOpcional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarServicoOpcional(int SEO_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [ServicoOpcional] set ");
                    strUpdate.Append(" SEO_FlagAtivo = @SEO_FlagAtivo ");
                    strUpdate.Append(" where SEO_Id = @SEO_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            SEO_FlagAtivo = 0,
                            SEO_Id = SEO_Id
                        });
                }
                salvaLog(null, "", "DeletarServicoOpcional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoOpcionalRepository", "DeletarServicoOpcional", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public ServicoOpcional GetServicoOpcionalById(int SEO_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT SEO_Id, SEO_Descricao, SEO_FlagAtivo, SEO_DescricaoIngles, SEO_TipoLogisticoPortoId from [ServicoOpcional] ");
                    strGet.Append(" where SEO_Id = @SEO_Id");

                    var obj = _db.Query<ServicoOpcional>(strGet.ToString(), new { SEO_Id = SEO_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {
                        var _TipoLogisticoPortoRepo = new TipoLogisticoPortoRepository();
                        obj.TipoLogisticoPorto = _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(obj.SEO_TipoLogisticoPortoId, true);
                    }

                    salvaLog(null, "", "GetServicoOpcionalById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoOpcionalRepository", "GetServicoOpcionalById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ServicoOpcional> GetAllServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " SEO_Id, SEO_Descricao, SEO_FlagAtivo, SEO_DescricaoIngles, SEO_TipoLogisticoPortoId from [ServicoOpcional] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where SEO_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<ServicoOpcional>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _TipoLogisticoPortoRepo = new TipoLogisticoPortoRepository();
                            obj.TipoLogisticoPorto = _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(obj.SEO_TipoLogisticoPortoId, true);
                        }
                    }
                    salvaLog(null, "", "GetAllServicoOpcional", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoOpcionalRepository", "GetAllServicoOpcional", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ServicoOpcional> GetAllServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  SEO_Id, SEO_Descricao, SEO_FlagAtivo, SEO_DescricaoIngles, SEO_TipoLogisticoPortoId from [ServicoOpcional] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SEO_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<ServicoOpcional>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _TipoLogisticoPortoRepo = new TipoLogisticoPortoRepository();
                            obj.TipoLogisticoPorto = _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(obj.SEO_TipoLogisticoPortoId, true);
                        }
                    }
                    salvaLog(null, "", "GetAllServicoOpcionalByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoOpcionalRepository", "GetAllServicoOpcionalByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<ServicoOpcional> GetAllServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " SEO_Id, SEO_Descricao, SEO_FlagAtivo, SEO_DescricaoIngles, SEO_TipoLogisticoPortoId from [ServicoOpcional] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SEO_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<ServicoOpcional>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _TipoLogisticoPortoRepo = new TipoLogisticoPortoRepository();
                            obj.TipoLogisticoPorto = _TipoLogisticoPortoRepo.GetTipoLogisticoPortoById(obj.SEO_TipoLogisticoPortoId, true);
                        }
                    }
                    salvaLog(null, "", "GetAllServicoOpcionalByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ServicoOpcionalRepository", "GetAllServicoOpcionalByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
