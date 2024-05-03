
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
    public class SubMenuRepository : RepositoryBase, ISubMenuRepository
    {
        
        public SubMenu InsertSubMenu(SubMenu objSubMenu)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [SubMenu] ");
                    strInsert.Append("(SBM_MenuId, SBM_Nome, SBM_Descricao, SBM_Codigo, SBM_Controller, SBM_Ordem, SBM_Ativo, SBM_FLAGMOBILE, SBM_Icone)");
                    strInsert.Append(@" VALUES (@SBM_MenuId, @SBM_Nome, @SBM_Descricao, @SBM_Codigo, @SBM_Controller, @SBM_Ordem, @SBM_Ativo, @SBM_FLAGMOBILE, @SBM_Icone);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            SBM_MenuId = objSubMenu.SBM_MenuId,
                            SBM_Nome = objSubMenu.SBM_Nome,
                            SBM_Descricao = objSubMenu.SBM_Descricao,
                            SBM_Codigo = objSubMenu.SBM_Codigo,
                            SBM_Controller = objSubMenu.SBM_Controller,
                            SBM_Ordem = objSubMenu.SBM_Ordem,
                            SBM_Ativo = 1,
                            SBM_FLAGMOBILE = objSubMenu.SBM_FLAGMOBILE,
                            SBM_Icone = objSubMenu.SBM_Icone,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objSubMenu.SBM_Id = queryInsert.First();

                    salvaLog(objSubMenu.Log, "", "InsertSubMenu", strInsert.ToString());
                    return objSubMenu;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objSubMenu.Log, "SubMenuRepository", "InsertSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objSubMenu.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new SubMenu();
            }
        }


        public bool UpdateSubMenu(SubMenu objSubMenu)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [SubMenu] ");
                    strUpdate.Append(@" SET SBM_MenuId = @SBM_MenuId
                        , SBM_Nome = @SBM_Nome
                        , SBM_Descricao = @SBM_Descricao
                        , SBM_Codigo = @SBM_Codigo
                        , SBM_Controller = @SBM_Controller
                        , SBM_Ordem = @SBM_Ordem
                        , SBM_Ativo = @SBM_Ativo
                        , SBM_FLAGMOBILE = @SBM_FLAGMOBILE
                        , SBM_Icone = @SBM_Icone
                         where SBM_Id = @SBM_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            SBM_MenuId = objSubMenu.SBM_MenuId,
                            SBM_Nome = objSubMenu.SBM_Nome,
                            SBM_Descricao = objSubMenu.SBM_Descricao,
                            SBM_Codigo = objSubMenu.SBM_Codigo,
                            SBM_Controller = objSubMenu.SBM_Controller,
                            SBM_Ordem = objSubMenu.SBM_Ordem,
                            SBM_Ativo = objSubMenu.SBM_Ativo,
                            SBM_FLAGMOBILE = objSubMenu.SBM_FLAGMOBILE,
                            SBM_Icone = objSubMenu.SBM_Icone,
                            
                            SBM_Id = objSubMenu.SBM_Id                            
                           });
                }
                salvaLog(objSubMenu.Log, "", "UpdateSubMenu", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objSubMenu.Log, "SubMenuRepository", "UpdateSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objSubMenu.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarSubMenu(int SBM_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [SubMenu] set ");
                    strUpdate.Append(" SBM_Ativo = @SBM_Ativo ");
                    strUpdate.Append(" where SBM_Id = @SBM_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SBM_Ativo = 1,
                                            SBM_Id = SBM_Id
                                        });
                }
                salvaLog(null, "", "AtivarSubMenu", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "SubMenuRepository", "AtivarSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarSubMenu(int SBM_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [SubMenu] set ");
                    strUpdate.Append(" SBM_Ativo = @SBM_Ativo ");
                    strUpdate.Append(" where SBM_Id = @SBM_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            SBM_Ativo = 0,
                                            SBM_Id = SBM_Id
                                        });
                }
                salvaLog(null, "", "DeletarSubMenu", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "SubMenuRepository", "DeletarSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public SubMenu GetSubMenuById(int SBM_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT SBM_Id, SBM_MenuId, SBM_Nome, SBM_Descricao, SBM_Codigo, SBM_Controller, SBM_Ordem, SBM_Ativo, SBM_FLAGMOBILE, SBM_Icone from [SubMenu] ");
                    strGet.Append(" where SBM_Id = @SBM_Id");

                    var obj = _db.Query<SubMenu>(strGet.ToString(), new { SBM_Id = SBM_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                             var _MenuRepo = new MenuRepository();
                            obj.Menu = _MenuRepo.GetMenuById(obj.SBM_MenuId.GetValueOrDefault(), true);
                                      
                    }

                    salvaLog(null, "", "GetSubMenuById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "SubMenuRepository", "GetSubMenuById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<SubMenu> GetAllSubMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [SubMenu] ");
                    if(join)
                    {
                         strGetAll.Append(@" join Menu on SBM_MenuId = MEN_Id ");
                                
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where SBM_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<SubMenu> lista = null;
                    if (join)
                    {
                        lista = _db.Query<SubMenu, Menu,         SubMenu>(newStrGetAll.ToString(),
                            (objSubMenu,  objMenu        ) => {
                                 objSubMenu.Menu = objMenu;
                                        
                                return objSubMenu;
                            }, new { maxInstances = maxInstances }, 
                            splitOn: " MEN_Id        ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<SubMenu>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllSubMenu", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "SubMenuRepository", "GetAllSubMenu", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<SubMenu> GetAllSubMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [SubMenu] ");
                         
                    if(join)
                    {
                         strGetAll.Append(@" join Menu on SBM_MenuId = MEN_Id ");
                                
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SBM_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<SubMenu> lista = null;
                    if (join)
                    {
                        lista = _db.Query<SubMenu, Menu,         SubMenu>(newStrGetAll.ToString(),
                            (objSubMenu,  objMenu        ) => {
                                 objSubMenu.Menu = objMenu;
                                        
                                return objSubMenu;
                            },
                            new {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }, splitOn: " MEN_Id        ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<SubMenu>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllSubMenuByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "SubMenuRepository", "GetAllSubMenuByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<SubMenu> GetAllSubMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [SubMenu] ");
                    
                    if(join)
                    {
                         strGetAll.Append(@" join Menu on SBM_MenuId = MEN_Id ");
                                
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and SBM_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<SubMenu> lista = null;
                    if (join)
                    {
                        lista = _db.Query<SubMenu, Menu,         SubMenu>(newStrGetAll.ToString(),
                            (objSubMenu,  objMenu        ) => {
                                 objSubMenu.Menu = objMenu;
                                        
                                return objSubMenu;
                            },
                            new {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }, splitOn: " MEN_Id        ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<SubMenu>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllSubMenuByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "SubMenuRepository", "GetAllSubMenuByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
