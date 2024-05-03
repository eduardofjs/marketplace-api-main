
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
using log4net;

namespace Data.Repositories
{
    public class PerfilxUsuarioRepository : RepositoryBase, IPerfilxUsuarioRepository
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PerfilxUsuario InsertPerfilxUsuario(PerfilxUsuario objPerfilxUsuario)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    if (objPerfilxUsuario.PXU_PerfilId == 24)
                    {
                        int UsuarioId = Convert.ToInt32(objPerfilxUsuario.PXU_UsuarioId);
                        StringBuilder strExiste = new StringBuilder();
                        var pxu = new PerfilxUsuario();

                        strExiste.Append(" select * from [PerfilxUsuario] where PXU_UsuarioId = @PXU_UsuarioId and PXU_PerfilId = 24");
                        pxu = _db.Query<PerfilxUsuario>(strExiste.ToString(), new { PXU_UsuarioId = UsuarioId }).FirstOrDefault();
                        if (pxu != null && pxu.PXU_Id > 0)
                            return pxu;
                    }

                    strInsert.Append("INSERT into [PerfilxUsuario] ");
                    strInsert.Append("(PXU_UsuarioId, PXU_PerfilId, PXU_Ativo)");
                    strInsert.Append(@" VALUES (@PXU_UsuarioId, @PXU_PerfilId, @PXU_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            PXU_UsuarioId = objPerfilxUsuario.PXU_UsuarioId,
                            PXU_PerfilId = objPerfilxUsuario.PXU_PerfilId,
                            PXU_Ativo = 1,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objPerfilxUsuario.PXU_Id = queryInsert.First();

                    salvaLog(objPerfilxUsuario.Log, "", "InsertPerfilxUsuario", strInsert.ToString());
                    return objPerfilxUsuario;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objPerfilxUsuario.Log, "PerfilxUsuarioRepository", "InsertPerfilxUsuario", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objPerfilxUsuario.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new PerfilxUsuario();
            }
        }


        public bool UpdatePerfilxUsuario(PerfilxUsuario objPerfilxUsuario)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [PerfilxUsuario] ");
                    strUpdate.Append(@" SET PXU_Id = @PXU_Id
                        , PXU_UsuarioId = @PXU_UsuarioId
                        , PXU_PerfilId = @PXU_PerfilId
                        , PXU_Ativo = @PXU_Ativo
                         where PXU_Id = @PXU_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            PXU_Id = objPerfilxUsuario.PXU_Id,
                            PXU_UsuarioId = objPerfilxUsuario.PXU_UsuarioId,
                            PXU_PerfilId = objPerfilxUsuario.PXU_PerfilId,
                            PXU_Ativo = 1,
                                                    
                           });
                }
                salvaLog(objPerfilxUsuario.Log, "", "UpdatePerfilxUsuario", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objPerfilxUsuario.Log, "PerfilxUsuarioRepository", "UpdatePerfilxUsuario", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objPerfilxUsuario.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarPerfilxUsuario(int PXU_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [PerfilxUsuario] set ");
                    strUpdate.Append(" PXU_Ativo = @PXU_Ativo ");
                    strUpdate.Append(" where PXU_Id = @PXU_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PXU_Ativo = 1,
                                            PXU_Id = PXU_Id
                                        });
                }
                salvaLog(null, "", "AtivarPerfilxUsuario", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxUsuarioRepository", "AtivarPerfilxUsuario", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarPerfilxUsuario(int PXU_PerfilId, int PXU_UsuarioId)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" DELETE FROM PerfilxUsuario ");
                    strUpdate.Append(" where PXU_UsuarioId = @PXU_UsuarioId and PXU_PerfilId = @PXU_PerfilId ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PXU_UsuarioId = PXU_UsuarioId,
                                            PXU_PerfilId = PXU_PerfilId
                                        });
                }
                salvaLog(null, "", "DeletarPerfilxUsuario", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxUsuarioRepository", "DeletarPerfilxUsuario", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public PerfilxUsuario GetPerfilxUsuarioById(int PXU_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT PXU_Id, PXU_UsuarioId, PXU_PerfilId, PXU_Ativo from [PerfilxUsuario] ");
                    strGet.Append(" where PXU_Id = @PXU_Id");

                    var obj = _db.Query<PerfilxUsuario>(strGet.ToString(), new { PXU_Id = PXU_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                             var _UsuarioRepo = new UsuarioRepository();
                            obj.Usuario = _UsuarioRepo.GetUsuarioById(obj.PXU_UsuarioId.GetValueOrDefault(), true);
                            var _PerfilRepo = new PerfilRepository();
                            obj.Perfil = _PerfilRepo.GetPerfilById(obj.PXU_PerfilId.GetValueOrDefault(), true);
                               
                    }

                    salvaLog(null, "", "GetPerfilxUsuarioById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxUsuarioRepository", "GetPerfilxUsuarioById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<PerfilxUsuario> GetAllPerfilxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [PerfilxUsuario] ");
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on PXU_UsuarioId = USR_Id ");
                        strGetAll.Append(@" join Perfil on PXU_PerfilId = PRF_Id ");
                         
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where PXU_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<PerfilxUsuario> lista = null;
                    if (join)
                    {
                        lista = _db.Query<PerfilxUsuario, Usuario, Perfil,  PerfilxUsuario>(newStrGetAll.ToString(),
                            (objPerfilxUsuario,  objUsuario,objPerfil) => {
                                 objPerfilxUsuario.Usuario = objUsuario;
                                objPerfilxUsuario.Perfil = objPerfil;
                                 
                                return objPerfilxUsuario;
                            }, new { maxInstances = maxInstances }, 
                            splitOn: " USR_Id,PRF_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<PerfilxUsuario>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllPerfilxUsuario", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxUsuarioRepository", "GetAllPerfilxUsuario", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<PerfilxUsuario> GetAllPerfilxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [PerfilxUsuario] ");
                         
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on PXU_UsuarioId = USR_Id ");
                        strGetAll.Append(@" join Perfil on PXU_PerfilId = PRF_Id ");
                         
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PXU_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<PerfilxUsuario> lista = null;
                    if (join)
                    {
                        lista = _db.Query<PerfilxUsuario, Usuario, Perfil,  PerfilxUsuario>(newStrGetAll.ToString(),
                            (objPerfilxUsuario,  objUsuario,objPerfil) => {
                                 objPerfilxUsuario.Usuario = objUsuario;
                                objPerfilxUsuario.Perfil = objPerfil;
                                 
                                return objPerfilxUsuario;
                            },
                            new {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }, splitOn: " USR_Id,PRF_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<PerfilxUsuario>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllPerfilxUsuarioByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxUsuarioRepository", "GetAllPerfilxUsuarioByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<PerfilxUsuario> GetAllPerfilxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [PerfilxUsuario] ");
                    
                    if(join)
                    {
                         strGetAll.Append(@" join Usuario on PXU_UsuarioId = USR_Id ");
                        strGetAll.Append(@" join Perfil on PXU_PerfilId = PRF_Id ");
                         
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PXU_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<PerfilxUsuario> lista = null;
                    if (join)
                    {
                        lista = _db.Query<PerfilxUsuario, Usuario, Perfil,  PerfilxUsuario>(newStrGetAll.ToString(),
                            (objPerfilxUsuario,  objUsuario,objPerfil) => {
                                 objPerfilxUsuario.Usuario = objUsuario;
                                objPerfilxUsuario.Perfil = objPerfil;
                                 
                                return objPerfilxUsuario;
                            },
                            new {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }, splitOn: " USR_Id,PRF_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<PerfilxUsuario>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllPerfilxUsuarioByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxUsuarioRepository", "GetAllPerfilxUsuarioByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool ListasPerfilxUsuario(List<PerfilxUsuario> lista)
        {
            try
            {
                StringBuilder strDelete = new StringBuilder();
                StringBuilder strInsert = new StringBuilder();
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strDelete.Append(" DELETE FROM PerfilxUsuario ");
                    strDelete.Append(" where PXU_UsuarioId = @PXU_UsuarioId ");

                    _db.Execute(strDelete.ToString(), new { PXU_UsuarioId = lista[0].PXU_UsuarioId });

                    foreach (var item in lista)
                    {
                        strInsert = new StringBuilder();
                        strInsert.Append("INSERT into [PerfilxUsuario] ");
                        strInsert.Append("(PXU_UsuarioId,PXU_PerfilId,PXU_Ativo)");
                        strInsert.Append(" VALUES (");
                        strInsert.Append("@PXU_UsuarioId,");
                        strInsert.Append("@PXU_PerfilId,");
                        strInsert.Append("@PXU_Ativo");
                        strInsert.Append(");");

                        var queryInsert = _db.Query<int>(strInsert.ToString(),
                            new
                            {
                                PXU_PerfilId = item.PXU_PerfilId,
                                PXU_UsuarioId = item.PXU_UsuarioId,
                                PXU_Ativo = item.PXU_Ativo,
                            });
                    }
                    salvaLog(null, "", "ListasPerfilxUsuario", strInsert.ToString() + " " + strDelete.ToString());
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                return false;
            }
        }
    }
}
