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
    public class OfertaxServicoAdicionalRepository : RepositoryBase, IOfertaxServicoAdicionalRepository
    {

        public OfertaxServicoAdicional InsertOfertaxServicoAdicional(OfertaxServicoAdicional objOfertaxServicoAdicional)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into OfertaxServicoAdicional ");
                    strInsert.Append("(OXA_OfertaId, OXA_ServicoAdicionalId, OXA_FlagAtivo)");
                    strInsert.Append(@" VALUES (@OXA_OfertaId, @OXA_ServicoAdicionalId, @OXA_FlagAtivo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            OXA_OfertaId = objOfertaxServicoAdicional.OXA_OfertaId,
                            OXA_ServicoAdicionalId = objOfertaxServicoAdicional.OXA_ServicoAdicionalId,
                            OXA_FlagAtivo = objOfertaxServicoAdicional.OXA_FlagAtivo,

                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objOfertaxServicoAdicional.OXA_Id = queryInsert.First();

                    salvaLog(objOfertaxServicoAdicional.Log, "", "InsertOfertaxServicoAdicional", strInsert.ToString());
                    return objOfertaxServicoAdicional;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxServicoAdicional.Log, "OfertaxServicoAdicionalRepository", "InsertOfertaxServicoAdicional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objOfertaxServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new OfertaxServicoAdicional();
            }
        }


        public bool UpdateOfertaxServicoAdicional(OfertaxServicoAdicional objOfertaxServicoAdicional)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update OfertaxServicoAdicional ");
                    strUpdate.Append(@" SET OXA_OfertaId = @OXA_OfertaId
                        , OXA_ServicoAdicionalId = @OXA_ServicoAdicionalId
                        , OXA_FlagAtivo = @OXA_FlagAtivo
                         where OXA_Id = @OXA_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               OXA_OfertaId = objOfertaxServicoAdicional.OXA_OfertaId,
                               OXA_ServicoAdicionalId = objOfertaxServicoAdicional.OXA_ServicoAdicionalId,
                               OXA_FlagAtivo = objOfertaxServicoAdicional.OXA_FlagAtivo,
                               OXA_Id = objOfertaxServicoAdicional.OXA_Id
                           });
                }
                salvaLog(objOfertaxServicoAdicional.Log, "", "UpdateOfertaxServicoAdicional", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objOfertaxServicoAdicional.Log, "OfertaxServicoAdicionalRepository", "UpdateOfertaxServicoAdicional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objOfertaxServicoAdicional.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarOfertaxServicoAdicional(int OXA_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update OfertaxServicoAdicional set ");
                    strUpdate.Append(" OXA_FlagAtivo = @OXA_FlagAtivo ");
                    strUpdate.Append(" where OXA_Id = @OXA_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXA_FlagAtivo = 1,
                                            OXA_Id = OXA_Id
                                        });
                }
                salvaLog(null, "", "AtivarOfertaxServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoAdicionalRepository", "AtivarOfertaxServicoAdicional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarOfertaxServicoAdicional(int OXA_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update OfertaxServicoAdicional set ");
                    strUpdate.Append(" OXA_FlagAtivo = @OXA_FlagAtivo ");
                    strUpdate.Append(" where OXA_Id = @OXA_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXA_FlagAtivo = 0,
                                            OXA_Id = OXA_Id
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxServicoAdicional", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoAdicionalRepository", "DeletarOfertaxServicoAdicional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public OfertaxServicoAdicional GetOfertaxServicoAdicionalById(int OXA_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from OfertaxServicoAdicional ");
                    if (join)
                    {
                        strGet.Append(@" inner join [Oferta] on OFE_Id = OXA_OfertaId ");
                        strGet.Append(@" inner join [ServicoAdicional] on SEA_Id = OXA_ServicoAdicionalId ");
                    }

                    strGet.Append(" where OXA_Id = @OXA_Id");

                    OfertaxServicoAdicional obj = null;
                    if (join)
                    {
                        obj = _db.Query<OfertaxServicoAdicional, Oferta, ServicoAdicional, OfertaxServicoAdicional>(strGet.ToString(),
                            (objOfertaxServicoAdicional, objOferta, objServicoAdicional) =>
                            {
                                objOfertaxServicoAdicional.Oferta = objOferta;
                                objOfertaxServicoAdicional.ServicoAdicional = objServicoAdicional;
                                return objOfertaxServicoAdicional;
                            }, new { OXA_Id = OXA_Id },
                            splitOn: "OFE_Id,SEA_Id").FirstOrDefault();
                    }
                    else
                    {
                        obj = _db.Query<OfertaxServicoAdicional>(strGet.ToString(), new { OXA_Id = OXA_Id }).FirstOrDefault();
                    }


                    salvaLog(null, "", "GetOfertaxServicoAdicionalById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoAdicionalRepository", "GetOfertaxServicoAdicionalById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from OfertaxServicoAdicional ");
                    if (join)
                    {
                        strGetAll.Append(@" inner join [Oferta] on OFE_Id = OXA_OfertaId ");
                        strGetAll.Append(@" inner join [ServicoAdicional] on SEA_Id = OXA_ServicoAdicionalId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where OXA_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<OfertaxServicoAdicional> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxServicoAdicional, Oferta, ServicoAdicional, OfertaxServicoAdicional>(newStrGetAll.ToString(),
                            (objOfertaxServicoAdicional, objOferta, objServicoAdicional) =>
                            {
                                objOfertaxServicoAdicional.Oferta = objOferta;
                                objOfertaxServicoAdicional.ServicoAdicional = objServicoAdicional;
                                return objOfertaxServicoAdicional;
                            }, new { maxInstances = maxInstances },
                            splitOn: "OFE_Id,SEA_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxServicoAdicional>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaxServicoAdicional", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoAdicionalRepository", "GetAllOfertaxServicoAdicional", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from OfertaxServicoAdicional ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join [Oferta] on OFE_Id = OXA_OfertaId ");
                        strGetAll.Append(@" inner join [ServicoAdicional] on SEA_Id = OXA_ServicoAdicionalId ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OXA_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<OfertaxServicoAdicional> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxServicoAdicional, Oferta, ServicoAdicional, OfertaxServicoAdicional>(newStrGetAll.ToString(),
                            (objOfertaxServicoAdicional, objOferta, objServicoAdicional) =>
                            {
                                objOfertaxServicoAdicional.Oferta = objOferta;
                                objOfertaxServicoAdicional.ServicoAdicional = objServicoAdicional;
                                return objOfertaxServicoAdicional;
                            }, new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: "OFE_Id,SEA_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxServicoAdicional>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllOfertaxServicoAdicionalByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoAdicionalRepository", "GetAllOfertaxServicoAdicionalByPartial", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from OfertaxServicoAdicional ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join [Oferta] on OFE_Id = OXA_OfertaId ");
                        strGetAll.Append(@" inner join [ServicoAdicional] on SEA_Id = OXA_ServicoAdicionalId ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and OXA_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<OfertaxServicoAdicional> lista = null;
                    if (join)
                    {
                        lista = _db.Query<OfertaxServicoAdicional, Oferta, ServicoAdicional, OfertaxServicoAdicional>(newStrGetAll.ToString(),
                            (objOfertaxServicoAdicional, objOferta, objServicoAdicional) =>
                            {
                                objOfertaxServicoAdicional.Oferta = objOferta;
                                objOfertaxServicoAdicional.ServicoAdicional = objServicoAdicional;
                                return objOfertaxServicoAdicional;
                            }, new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: "OFE_Id,SEA_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<OfertaxServicoAdicional>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllOfertaxServicoAdicionalByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoAdicionalRepository", "GetAllOfertaxServicoAdicionalByValorExato", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        
        public bool DeletarOfertaxServicoAdicionalByOferta(int OXA_OfertaId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update OfertaxServicoAdicional set ");
                    strUpdate.Append(" OXA_FlagAtivo = @OXA_FlagAtivo ");
                    strUpdate.Append(" where OXA_OfertaId = @OXA_OfertaId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            OXA_FlagAtivo = 0,
                                            OXA_OfertaId = OXA_OfertaId
                                        });
                }
                salvaLog(null, "", "DeletarOfertaxServicoAdicionalByOferta", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "OfertaxServicoAdicionalRepository", "DeletarOfertaxServicoAdicionalByOferta", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}



