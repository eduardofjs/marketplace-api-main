
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
    public class PerfilxSubMenuRepository : RepositoryBase, IPerfilxSubMenuRepository
    {
        
        public PerfilxSubMenu InsertPerfilxSubMenu(PerfilxSubMenu objPerfilxSubMenu)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [PerfilxSubMenu] ");
                    strInsert.Append("(PXS_SubMenuId, PXS_PerfilId, PXS_Ativo)");
                    strInsert.Append(@" VALUES (@PXS_SubMenuId, @PXS_PerfilId, @PXS_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            PXS_SubMenuId = objPerfilxSubMenu.PXS_SubMenuId,
                            PXS_PerfilId = objPerfilxSubMenu.PXS_PerfilId,
                            PXS_Ativo = 1,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objPerfilxSubMenu.PXS_Id = queryInsert.First();

                    salvaLog(objPerfilxSubMenu.Log, "", "InsertPerfilxSubMenu", strInsert.ToString());
                    return objPerfilxSubMenu;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objPerfilxSubMenu.Log, "PerfilxSubMenuRepository", "InsertPerfilxSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objPerfilxSubMenu.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new PerfilxSubMenu();
            }
        }
        
        public bool UpdatePerfilxSubMenu(PerfilxSubMenu objPerfilxSubMenu)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [PerfilxSubMenu] ");
                    strUpdate.Append(@" SET PXS_SubMenuId = @PXS_SubMenuId
                        , PXS_PerfilId = @PXS_PerfilId
                        , PXS_Ativo = @PXS_Ativo
                         where PXS_Id = @PXS_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            PXS_SubMenuId = objPerfilxSubMenu.PXS_SubMenuId,
                            PXS_PerfilId = objPerfilxSubMenu.PXS_PerfilId,
                            PXS_Ativo = 1,
                            
                            PXS_Id = objPerfilxSubMenu.PXS_Id                            
                           });
                }
                salvaLog(objPerfilxSubMenu.Log, "", "UpdatePerfilxSubMenu", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objPerfilxSubMenu.Log, "PerfilxSubMenuRepository", "UpdatePerfilxSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objPerfilxSubMenu.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarPerfilxSubMenu(int PXS_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [PerfilxSubMenu] set ");
                    strUpdate.Append(" PXS_Ativo = @PXS_Ativo ");
                    strUpdate.Append(" where PXS_Id = @PXS_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PXS_Ativo = 1,
                                            PXS_Id = PXS_Id
                                        });
                }
                salvaLog(null, "", "AtivarPerfilxSubMenu", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxSubMenuRepository", "AtivarPerfilxSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarPerfilxSubMenu(int PXS_SubMenuId, int PXS_PerfilId)
        {
            StringBuilder strDelete = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strDelete.Append(" DELETE FROM PerfilxSubMenu ");
                    strDelete.Append(" where PXS_SubMenuId = @PXS_SubMenuId and PXS_PerfilId = @PXS_PerfilId ");

                    _db.Execute(
                         strDelete.ToString(),
                                        new
                                        {
                                            PXS_SubMenuId = PXS_SubMenuId,
                                            PXS_PerfilId = PXS_PerfilId
                                        });
                }
                salvaLog(null, "", "DeletarPerfilxSubMenu", strDelete.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxSubMenuRepository", "DeletarPerfilxSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strDelete.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public PerfilxSubMenu GetPerfilxSubMenuById(int PXS_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT PXS_Id, PXS_SubMenuId, PXS_PerfilId, PXS_Ativo from [PerfilxSubMenu] ");
                    strGet.Append(" where PXS_Id = @PXS_Id");

                    var obj = _db.Query<PerfilxSubMenu>(strGet.ToString(), new { PXS_Id = PXS_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                             var _SubMenuRepo = new SubMenuRepository();
                            obj.SubMenu = _SubMenuRepo.GetSubMenuById(obj.PXS_SubMenuId.GetValueOrDefault(), true);
                            var _PerfilRepo = new PerfilRepository();
                            obj.Perfil = _PerfilRepo.GetPerfilById(obj.PXS_PerfilId.GetValueOrDefault(), true);
                               
                    }

                    salvaLog(null, "", "GetPerfilxSubMenuById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxSubMenuRepository", "GetPerfilxSubMenuById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [PerfilxSubMenu] ");
                    if(join)
                    {
                         strGetAll.Append(@" join SubMenu on PXS_SubMenuId = SBM_Id ");
                        strGetAll.Append(@" join Perfil on PXS_PerfilId = PRF_Id ");
                         
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where PXS_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<PerfilxSubMenu> lista = null;
                    if (join)
                    {
                        lista = _db.Query<PerfilxSubMenu, SubMenu, Perfil,  PerfilxSubMenu>(newStrGetAll.ToString(),
                            (objPerfilxSubMenu,  objSubMenu,objPerfil) => {
                                 objPerfilxSubMenu.SubMenu = objSubMenu;
                                objPerfilxSubMenu.Perfil = objPerfil;
                                 
                                return objPerfilxSubMenu;
                            }, new { maxInstances = maxInstances }, 
                            splitOn: " SBM_Id,PRF_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<PerfilxSubMenu>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllPerfilxSubMenu", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxSubMenuRepository", "GetAllPerfilxSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [PerfilxSubMenu] ");
                         
                    if(join)
                    {
                         strGetAll.Append(@" join SubMenu on PXS_SubMenuId = SBM_Id ");
                        strGetAll.Append(@" join Perfil on PXS_PerfilId = PRF_Id ");
                         
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PXS_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<PerfilxSubMenu> lista = null;
                    if (join)
                    {
                        lista = _db.Query<PerfilxSubMenu, SubMenu, Perfil,  PerfilxSubMenu>(newStrGetAll.ToString(),
                            (objPerfilxSubMenu,  objSubMenu,objPerfil) => {
                                 objPerfilxSubMenu.SubMenu = objSubMenu;
                                objPerfilxSubMenu.Perfil = objPerfil;
                                 
                                return objPerfilxSubMenu;
                            },
                            new {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }, splitOn: " SBM_Id,PRF_Id ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<PerfilxSubMenu>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllPerfilxSubMenuByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxSubMenuRepository", "GetAllPerfilxSubMenuByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<PerfilxSubMenu> GetAllPerfilxSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    //strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " PXS_Id,PXS_SubMenuId,PXS_PerfilId,PXS_Ativo, ");
                    //strGetAll.Append(@" SBM_Id,SBM_MenuId, SBM_Nome, SBM_Descricao, SBM_Codigo, SBM_Controller, SBM_Ordem, SBM_Ativo, SBM_FLAGMOBILE, SBM_Icone, ");
                    //strGetAll.Append(@" PRF_Id,PRF_UnidadeId, PRF_Descricao, PRF_Nome, PRF_Ativo ");
                    //strGetAll.Append(@" from [PerfilxSubMenu] ");

                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " *  from [PerfilxSubMenu] ");

                    if (join)
                    {
                        strGetAll.Append(@" join SubMenu on PXS_SubMenuId = SBM_Id ");
                        strGetAll.Append(@" join Perfil on PXS_PerfilId = PRF_Id ");                         
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PXS_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<PerfilxSubMenu> lista = null;
                    /*if (join)
                    {
                        lista = _db.Query<PerfilxSubMenu, SubMenu, Perfil,  PerfilxSubMenu>(newStrGetAll.ToString(),
                            (objPerfilxSubMenu,  objSubMenu,objPerfil) => {
                                 objPerfilxSubMenu.SubMenu = objSubMenu;
                                objPerfilxSubMenu.Perfil = objPerfil;
                                 
                                return objPerfilxSubMenu;
                            },
                            new {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }, splitOn: "SBM_Id,PRF_Id").AsEnumerable();
                    }
                    else
                    {*/
                        lista = _db.Query<PerfilxSubMenu>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _SubMenuRepo = new SubMenuRepository();
                            obj.SubMenu = _SubMenuRepo.GetSubMenuById(obj.PXS_SubMenuId.GetValueOrDefault(), true);
                            var _PerfilRepo = new PerfilRepository();
                            obj.Perfil = _PerfilRepo.GetPerfilById(obj.PXS_PerfilId.GetValueOrDefault(), true);
                        }
                    }
                    salvaLog(null, "", "GetAllPerfilxSubMenuByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PerfilxSubMenuRepository", "GetAllPerfilxSubMenuByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
