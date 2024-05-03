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
    public class OfertaxServicoOpcionalRepository : RepositoryBase, IOfertaxServicoOpcionalRepository
    {

        public OfertaxServicoOpcional InsertOfertaxServicoOpcional(OfertaxServicoOpcional objOfertaxServicoOpcional)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into OfertaxServicoOpcional ");
                    strInsert.Append("(OXS_OfertaId, OXS_ServicoOpcionalId, OXS_FlagAtivo)");
                    strInsert.Append(@" VALUES (@OXS_OfertaId, @OXS_ServicoOpcionalId, @OXS_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            OXS_OfertaId = objOfertaxServicoOpcional.OXS_OfertaId,
                            OXS_ServicoOpcionalId = objOfertaxServicoOpcional.OXS_ServicoOpcionalId,
                            OXS_FlagAtivo = objOfertaxServicoOpcional.OXS_FlagAtivo,

                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objOfertaxServicoOpcional.OXS_Id = queryInsert.First();

                    salvaLog(objOfertaxServicoOpcional.Log, "", "InsertOfertaxServicoOpcional", strInsert.ToString());
                    return objOfertaxServicoOpcional;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxServicoOpcional.Log, "OfertaxServicoOpcionalRepository", "InsertOfertaxServicoOpcional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objOfertaxServicoOpcional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new OfertaxServicoOpcional();
            }
        }


        public bool UpdateOfertaxServicoOpcional(OfertaxServicoOpcional objOfertaxServicoOpcional)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update OfertaxServicoOpcional ");
                    strUpdate.Append(@" SET OXS_OfertaId = @OXS_OfertaId
                        , OXS_ServicoOpcionalId = @OXS_ServicoOpcionalId
                        , OXS_FlagAtivo = @OXS_FlagAtivo
                         where OXS_Id = @OXS_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               OXS_OfertaId = objOfertaxServicoOpcional.OXS_OfertaId,
                               OXS_ServicoOpcionalId = objOfertaxServicoOpcional.OXS_ServicoOpcionalId,
                               OXS_FlagAtivo = objOfertaxServicoOpcional.OXS_FlagAtivo,
                               OXS_Id = objOfertaxServicoOpcional.OXS_Id
                           });
                }
                salvaLog(objOfertaxServicoOpcional.Log, "", "UpdateOfertaxServicoOpcional", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxServicoOpcional.Log, "OfertaxServicoOpcionalRepository", "UpdateOfertaxServicoOpcional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objOfertaxServicoOpcional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarOfertaxServicoOpcional(int OXS_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update OfertaxServicoOpcional set ");
                    strUpdate.Append(" OXS_FlagAtivo = @OXS_FlagAtivo ");
                    strUpdate.Append(" where OXS_Id = @OXS_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXS_FlagAtivo = 1,
                                            OXS_Id = OXS_Id
                                        });
                }
                salvaLog(null, "", "AtivarOfertaxServicoOpcional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoOpcionalRepository", "AtivarOfertaxServicoOpcional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarOfertaxServicoOpcional(int OXS_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update OfertaxServicoOpcional set ");
                    strUpdate.Append(" OXS_FlagAtivo = @OXS_FlagAtivo ");
                    strUpdate.Append(" where OXS_Id = @OXS_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXS_FlagAtivo = 0,
                                            OXS_Id = OXS_Id
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxServicoOpcional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoOpcionalRepository", "DeletarOfertaxServicoOpcional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public OfertaxServicoOpcional GetOfertaxServicoOpcionalById(int OXS_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from OfertaxServicoOpcional ");
                    if (join)
                    {
                        strGet.Append(@" inner join [Oferta] on OFE_Id = OXS_OfertaId ");
                        strGet.Append(@" inner join [ServicoOpcional] on SEO_Id = OXS_ServicoOpcionalId ");
                    }

                    strGet.Append(" where OXS_Id = @OXS_Id");

                    OfertaxServicoOpcional obj = null;
                    if (join)
                    {
                        obj = _db.Query<OfertaxServicoOpcional, Oferta, ServicoOpcional, OfertaxServicoOpcional>(strGet.ToString(),
                            (objOfertaxServicoOpcional, objOferta, objServicoOpcional) =>
                            {
                                objOfertaxServicoOpcional.Oferta = objOferta;
                                objOfertaxServicoOpcional.ServicoOpcional = objServicoOpcional;
                                return objOfertaxServicoOpcional;
                            }, new { OXS_Id = OXS_Id },
                            splitOn: "OFE_Id,SEO_Id").FirstOrDefault();
                    }
                    else
                    {
                        obj = _db.Query<OfertaxServicoOpcional>(strGet.ToString(), new { OXS_Id = OXS_Id }).FirstOrDefault();
                    }


                    salvaLog(null, "", "GetOfertaxServicoOpcionalById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoOpcionalRepository", "GetOfertaxServicoOpcionalById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from OfertaxServicoOpcional ");
                    if (join)
                    {
                        strGetAll.Append(@" inner join [Oferta] on OFE_Id = OXS_OfertaId ");
                        strGetAll.Append(@" inner join [ServicoOpcional] on SEO_Id = OXS_ServicoOpcionalId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where OXS_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<OfertaxServicoOpcional> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxServicoOpcional, Oferta, ServicoOpcional, OfertaxServicoOpcional>(newStrGetAll.ToString(),
                            (objOfertaxServicoOpcional, objOferta, objServicoOpcional) =>
                            {
                                objOfertaxServicoOpcional.Oferta = objOferta;
                                objOfertaxServicoOpcional.ServicoOpcional = objServicoOpcional;
                                return objOfertaxServicoOpcional;
                            }, new { maxInstances = maxInstances },
                            splitOn: "OFE_Id,SEO_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxServicoOpcional>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaxServicoOpcional", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoOpcionalRepository", "GetAllOfertaxServicoOpcional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from OfertaxServicoOpcional ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join [Oferta] on OFE_Id = OXS_OfertaId ");
                        strGetAll.Append(@" inner join [ServicoOpcional] on SEO_Id = OXS_ServicoOpcionalId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OXS_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<OfertaxServicoOpcional> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxServicoOpcional, Oferta, ServicoOpcional, OfertaxServicoOpcional>(newStrGetAll.ToString(),
                            (objOfertaxServicoOpcional, objOferta, objServicoOpcional) =>
                            {
                                objOfertaxServicoOpcional.Oferta = objOferta;
                                objOfertaxServicoOpcional.ServicoOpcional = objServicoOpcional;
                                return objOfertaxServicoOpcional;
                            }, new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: "OFE_Id,SEO_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxServicoOpcional>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaxServicoOpcionalByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoOpcionalRepository", "GetAllOfertaxServicoOpcionalByPartial", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from OfertaxServicoOpcional ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join [Oferta] on OFE_Id = OXS_OfertaId ");
                        strGetAll.Append(@" inner join [ServicoOpcional] on SEO_Id = OXS_ServicoOpcionalId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OXS_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<OfertaxServicoOpcional> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxServicoOpcional, Oferta, ServicoOpcional, OfertaxServicoOpcional>(newStrGetAll.ToString(),
                            (objOfertaxServicoOpcional, objOferta, objServicoOpcional) =>
                            {
                                objOfertaxServicoOpcional.Oferta = objOferta;
                                objOfertaxServicoOpcional.ServicoOpcional = objServicoOpcional;
                                return objOfertaxServicoOpcional;
                            }, new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: "OFE_Id,SEO_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxServicoOpcional>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllOfertaxServicoOpcionalByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoOpcionalRepository", "GetAllOfertaxServicoOpcionalByValorExato", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public bool DeletarOfertaxServicoOpcionalByOferta(int OXS_OfertaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update OfertaxServicoOpcional set ");
                    strUpdate.Append(" OXS_FlagAtivo = @OXS_FlagAtivo ");
                    strUpdate.Append(" where OXS_OfertaId = @OXS_OfertaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXS_FlagAtivo = 0,
                                            OXS_OfertaId = OXS_OfertaId
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxServicoOpcionalByOferta", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoOpcionalRepository", "DeletarOfertaxServicoOpcionalByOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}


