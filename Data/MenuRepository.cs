
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
    public class MenuRepository : RepositoryBase, IMenuRepository
    {
        
        public Menu InsertMenu(Menu objMenu)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Menu] ");
                    strInsert.Append("(MEN_Nome, MEN_Codigo, MEN_Ativo, MEN_Ordem, MEN_Icone, MEN_FLAGMOBILE)");
                    strInsert.Append(@" VALUES (@MEN_Nome, @MEN_Codigo, @MEN_Ativo, @MEN_Ordem, @MEN_Icone, @MEN_FLAGMOBILE);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            MEN_Nome = objMenu.MEN_Nome,
                            MEN_Codigo = objMenu.MEN_Codigo,
                            MEN_Ativo = 1,
                            MEN_Ordem = objMenu.MEN_Ordem,
                            MEN_Icone = objMenu.MEN_Icone,
                            MEN_FLAGMOBILE = objMenu.MEN_FLAGMOBILE,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objMenu.MEN_Id = queryInsert.First();

                    salvaLog(objMenu.Log, "", "InsertMenu", strInsert.ToString());
                    return objMenu;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objMenu.Log, "MenuRepository", "InsertMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objMenu.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Menu();
            }
        }


        public bool UpdateMenu(Menu objMenu)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Menu] ");
                    strUpdate.Append(@" SET MEN_Nome = @MEN_Nome
                        , MEN_Codigo = @MEN_Codigo
                        , MEN_Ativo = @MEN_Ativo
                        , MEN_Ordem = @MEN_Ordem
                        , MEN_Icone = @MEN_Icone
                        , MEN_FLAGMOBILE = @MEN_FLAGMOBILE
                         where MEN_Id = @MEN_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            MEN_Nome = objMenu.MEN_Nome,
                            MEN_Codigo = objMenu.MEN_Codigo,
                            MEN_Ativo = 1,
                            MEN_Ordem = objMenu.MEN_Ordem,
                            MEN_Icone = objMenu.MEN_Icone,
                            MEN_FLAGMOBILE = objMenu.MEN_FLAGMOBILE,
                            
                            MEN_Id = objMenu.MEN_Id                            
                           });
                }
                salvaLog(objMenu.Log, "", "UpdateMenu", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objMenu.Log, "MenuRepository", "UpdateMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objMenu.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarMenu(int MEN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Menu] set ");
                    strUpdate.Append(" MEN_Ativo = @MEN_Ativo ");
                    strUpdate.Append(" where MEN_Id = @MEN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            MEN_Ativo = 1,
                                            MEN_Id = MEN_Id
                                        });
                }
                salvaLog(null, "", "AtivarMenu", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "MenuRepository", "AtivarMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarMenu(int MEN_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Menu] set ");
                    strUpdate.Append(" MEN_Ativo = @MEN_Ativo ");
                    strUpdate.Append(" where MEN_Id = @MEN_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            MEN_Ativo = 0,
                                            MEN_Id = MEN_Id
                                        });
                }
                salvaLog(null, "", "DeletarMenu", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "MenuRepository", "DeletarMenu", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Menu GetMenuById(int MEN_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT MEN_Id, MEN_Nome, MEN_Codigo, MEN_Ativo, MEN_Ordem, MEN_Icone, MEN_FLAGMOBILE from [Menu] ");
                    strGet.Append(" where MEN_Id = @MEN_Id");

                    var obj = _db.Query<Menu>(strGet.ToString(), new { MEN_Id = MEN_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                                     
                    }

                    salvaLog(null, "", "GetMenuById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "MenuRepository", "GetMenuById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Menu> GetAllMenu(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Menu] ");
                    if(join)
                    {
                               
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where MEN_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Menu> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Menu,       Menu>(newStrGetAll.ToString(),
                    //        (objMenu,        ) => {
                                       
                    //            return objMenu;
                    //        }, new { maxInstances = maxInstances }, 
                    //        splitOn: "       ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Menu>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    lista = _db.Query<Menu>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    salvaLog(null, "", "GetAllMenu", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "MenuRepository", "GetAllMenu", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Menu> GetAllMenuByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Menu] ");
                         
                    if(join)
                    {
                               
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and MEN_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Menu> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Menu,       Menu>(newStrGetAll.ToString(),
                    //        (objMenu,        ) => {
                                       
                    //            return objMenu;
                    //        },
                    //        new {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }, splitOn: "       ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Menu>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strPartial = "%" + strPartial + "%",
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<Menu>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    salvaLog(null, "", "GetAllMenuByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "MenuRepository", "GetAllMenuByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Menu> GetAllMenuByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Menu] ");
                    
                    if(join)
                    {
                               
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and MEN_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Menu> lista = null;
                    //if (join)
                    //{
                    //    lista = _db.Query<Menu,       Menu>(newStrGetAll.ToString(),
                    //        (objMenu,        ) => {
                                       
                    //            return objMenu;
                    //        },
                    //        new {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }, splitOn: "       ").AsEnumerable();
                    //}
                    //else
                    //{
                    //    lista = _db.Query<Menu>(newStrGetAll.ToString(),
                    //        new
                    //        {
                    //            strValorExato = strValorExato,
                    //            maxInstances = maxInstances
                    //        }).AsEnumerable();
                    //}
                    lista = _db.Query<Menu>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();
                    salvaLog(null, "", "GetAllMenuByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "MenuRepository", "GetAllMenuByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
