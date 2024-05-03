
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
    public class ConfiguracaoGlobalRepository : RepositoryBase, IConfiguracaoGlobalRepository
    {
        
        public ConfiguracaoGlobal InsertConfiguracaoGlobal(ConfiguracaoGlobal objConfiguracaoGlobal)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into ConfiguracaoGlobal ");
                    strInsert.Append("(CGL_UnidadeRaiz, CGL_UrlImagem, CGL_PathImagem, CGL_PathImpressao, CGL_UrlImpressao, CGL_PathLogoImpressao, CGL_UrlLogoImpressao, CGL_PathLogo, CGL_UrlLogo, CGL_PathFonte, CGL_SendMailFrom, CGL_SendMailCCOS, CGL_SendMailSmtpCliente, CGL_SendMailLogin, CGL_SendMailSenha, CGL_SendMailPorta, CGL_FlagPagamentoVoucher, CGL_FlagPagamentoOnline, CGL_Ativo, CGL_UrlWEB, CGL_CronScheduleJob01, CGL_CronScheduleJob02, CGL_CronScheduleJob03)");
                    strInsert.Append(@" VALUES (@CGL_UnidadeRaiz, @CGL_UrlImagem, @CGL_PathImagem, @CGL_PathImpressao, @CGL_UrlImpressao, @CGL_PathLogoImpressao, @CGL_UrlLogoImpressao, @CGL_PathLogo, @CGL_UrlLogo, @CGL_PathFonte, @CGL_SendMailFrom, @CGL_SendMailCCOS, @CGL_SendMailSmtpCliente, @CGL_SendMailLogin, @CGL_SendMailSenha, @CGL_SendMailPorta, @CGL_FlagPagamentoVoucher, @CGL_FlagPagamentoOnline, @CGL_Ativo, @CGL_UrlWEB, @CGL_CronScheduleJob01, @CGL_CronScheduleJob02, @CGL_CronScheduleJob03);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            CGL_UnidadeRaiz = objConfiguracaoGlobal.CGL_UnidadeRaiz,
                            CGL_UrlImagem = objConfiguracaoGlobal.CGL_UrlImagem,
                            CGL_PathImagem = objConfiguracaoGlobal.CGL_PathImagem,
                            CGL_PathImpressao = objConfiguracaoGlobal.CGL_PathImpressao,
                            CGL_UrlImpressao = objConfiguracaoGlobal.CGL_UrlImpressao,
                            CGL_PathLogoImpressao = objConfiguracaoGlobal.CGL_PathLogoImpressao,
                            CGL_UrlLogoImpressao = objConfiguracaoGlobal.CGL_UrlLogoImpressao,
                            CGL_PathLogo = objConfiguracaoGlobal.CGL_PathLogo,
                            CGL_UrlLogo = objConfiguracaoGlobal.CGL_UrlLogo,
                            CGL_PathFonte = objConfiguracaoGlobal.CGL_PathFonte,
                            CGL_SendMailFrom = objConfiguracaoGlobal.CGL_SendMailFrom,
                            CGL_SendMailCCOS = objConfiguracaoGlobal.CGL_SendMailCCOS,
                            CGL_SendMailSmtpCliente = objConfiguracaoGlobal.CGL_SendMailSmtpCliente,
                            CGL_SendMailLogin = objConfiguracaoGlobal.CGL_SendMailLogin,
                            CGL_SendMailSenha = objConfiguracaoGlobal.CGL_SendMailSenha,
                            CGL_SendMailPorta = objConfiguracaoGlobal.CGL_SendMailPorta,
                            CGL_FlagPagamentoVoucher = objConfiguracaoGlobal.CGL_FlagPagamentoVoucher,
                            CGL_FlagPagamentoOnline = objConfiguracaoGlobal.CGL_FlagPagamentoOnline,
                            CGL_Ativo = objConfiguracaoGlobal.CGL_Ativo,
                            CGL_UrlWEB = objConfiguracaoGlobal.CGL_UrlWEB,
                            CGL_CronScheduleJob01 = objConfiguracaoGlobal.CGL_CronScheduleJob01,
                            CGL_CronScheduleJob02 = objConfiguracaoGlobal.CGL_CronScheduleJob02,
                            CGL_CronScheduleJob03 = objConfiguracaoGlobal.CGL_CronScheduleJob03
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objConfiguracaoGlobal.CGL_Id = queryInsert.First();

                    salvaLog(objConfiguracaoGlobal.Log, "", "InsertConfiguracaoGlobal", strInsert.ToString());
                    return objConfiguracaoGlobal;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objConfiguracaoGlobal.Log, "ConfiguracaoGlobalRepository", "InsertConfiguracaoGlobal", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objConfiguracaoGlobal.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new ConfiguracaoGlobal();
            }
        }


        public bool UpdateConfiguracaoGlobal(ConfiguracaoGlobal objConfiguracaoGlobal)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update ConfiguracaoGlobal ");
                    strUpdate.Append(@" SET CGL_UnidadeRaiz = @CGL_UnidadeRaiz
                        , CGL_UrlImagem = @CGL_UrlImagem
                        , CGL_PathImagem = @CGL_PathImagem
                        , CGL_PathImpressao = @CGL_PathImpressao
                        , CGL_UrlImpressao = @CGL_UrlImpressao
                        , CGL_PathLogoImpressao = @CGL_PathLogoImpressao
                        , CGL_UrlLogoImpressao = @CGL_UrlLogoImpressao
                        , CGL_PathLogo = @CGL_PathLogo
                        , CGL_UrlLogo = @CGL_UrlLogo
                        , CGL_PathFonte = @CGL_PathFonte
                        , CGL_SendMailFrom = @CGL_SendMailFrom
                        , CGL_SendMailCCOS = @CGL_SendMailCCOS
                        , CGL_SendMailSmtpCliente = @CGL_SendMailSmtpCliente
                        , CGL_SendMailLogin = @CGL_SendMailLogin
                        , CGL_SendMailSenha = @CGL_SendMailSenha
                        , CGL_SendMailPorta = @CGL_SendMailPorta
                        , CGL_FlagPagamentoVoucher = @CGL_FlagPagamentoVoucher
                        , CGL_FlagPagamentoOnline = @CGL_FlagPagamentoOnline
                        , CGL_Ativo = @CGL_Ativo
                        , CGL_UrlWEB = @CGL_UrlWEB
                        , CGL_CronScheduleJob01 = @CGL_CronScheduleJob01
                        , CGL_CronScheduleJob02 = @CGL_CronScheduleJob02
                        , CGL_CronScheduleJob03 = @CGL_CronScheduleJob03
                         where CGL_Id = @CGL_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            CGL_UnidadeRaiz = objConfiguracaoGlobal.CGL_UnidadeRaiz,
                            CGL_UrlImagem = objConfiguracaoGlobal.CGL_UrlImagem,
                            CGL_PathImagem = objConfiguracaoGlobal.CGL_PathImagem,
                            CGL_PathImpressao = objConfiguracaoGlobal.CGL_PathImpressao,
                            CGL_UrlImpressao = objConfiguracaoGlobal.CGL_UrlImpressao,
                            CGL_PathLogoImpressao = objConfiguracaoGlobal.CGL_PathLogoImpressao,
                            CGL_UrlLogoImpressao = objConfiguracaoGlobal.CGL_UrlLogoImpressao,
                            CGL_PathLogo = objConfiguracaoGlobal.CGL_PathLogo,
                            CGL_UrlLogo = objConfiguracaoGlobal.CGL_UrlLogo,
                            CGL_PathFonte = objConfiguracaoGlobal.CGL_PathFonte,
                            CGL_SendMailFrom = objConfiguracaoGlobal.CGL_SendMailFrom,
                            CGL_SendMailCCOS = objConfiguracaoGlobal.CGL_SendMailCCOS,
                            CGL_SendMailSmtpCliente = objConfiguracaoGlobal.CGL_SendMailSmtpCliente,
                            CGL_SendMailLogin = objConfiguracaoGlobal.CGL_SendMailLogin,
                            CGL_SendMailSenha = objConfiguracaoGlobal.CGL_SendMailSenha,
                            CGL_SendMailPorta = objConfiguracaoGlobal.CGL_SendMailPorta,
                            CGL_FlagPagamentoVoucher = objConfiguracaoGlobal.CGL_FlagPagamentoVoucher,
                            CGL_FlagPagamentoOnline = objConfiguracaoGlobal.CGL_FlagPagamentoOnline,
                            CGL_Ativo = objConfiguracaoGlobal.CGL_Ativo,
                            CGL_UrlWEB = objConfiguracaoGlobal.CGL_UrlWEB,
                            CGL_CronScheduleJob01 = objConfiguracaoGlobal.CGL_CronScheduleJob01,
                            CGL_CronScheduleJob02 = objConfiguracaoGlobal.CGL_CronScheduleJob02,
                            CGL_CronScheduleJob03 = objConfiguracaoGlobal.CGL_CronScheduleJob03,

                            CGL_Id = objConfiguracaoGlobal.CGL_Id                            
                           });
                }
                salvaLog(objConfiguracaoGlobal.Log, "", "UpdateConfiguracaoGlobal", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objConfiguracaoGlobal.Log, "ConfiguracaoGlobalRepository", "UpdateConfiguracaoGlobal", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objConfiguracaoGlobal.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarConfiguracaoGlobal(int CGL_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update ConfiguracaoGlobal set ");
                    strUpdate.Append(" CGL_Ativo = @CGL_Ativo ");
                    strUpdate.Append(" where CGL_Id = @CGL_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            CGL_Ativo = 1,
                                            CGL_Id = CGL_Id
                                        });
                }
                salvaLog(null, "", "AtivarConfiguracaoGlobal", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ConfiguracaoGlobalRepository", "AtivarConfiguracaoGlobal", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarConfiguracaoGlobal(int CGL_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update ConfiguracaoGlobal set ");
                    strUpdate.Append(" CGL_Ativo = @CGL_Ativo ");
                    strUpdate.Append(" where CGL_Id = @CGL_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            CGL_Ativo = 0,
                                            CGL_Id = CGL_Id
                                        });
                }
                salvaLog(null, "", "DeletarConfiguracaoGlobal", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ConfiguracaoGlobalRepository", "DeletarConfiguracaoGlobal", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public ConfiguracaoGlobal GetConfiguracaoGlobalById(int CGL_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from ConfiguracaoGlobal ");
                    if(join)
                    {
                                             
                    }

                    strGet.Append(" where CGL_Id = @CGL_Id");                    

                    ConfiguracaoGlobal obj = null;
                    //if (join)
                    //{
                        //obj = _db.Query<ConfiguracaoGlobal,                     ConfiguracaoGlobal>(strGet.ToString(),
                        //    (objConfiguracaoGlobal,                      ) => {
                        //                             
                        //        return objConfiguracaoGlobal;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"                     ").FirstOrDefault();
                    //}
                    //else
                    //{
                        obj = _db.Query<ConfiguracaoGlobal>(strGet.ToString(), new { CGL_Id = CGL_Id }).FirstOrDefault();
                    //}


                    salvaLog(null, "", "GetConfiguracaoGlobalById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ConfiguracaoGlobalRepository", "GetConfiguracaoGlobalById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobal(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from ConfiguracaoGlobal ");
                    if(join)
                    {
                                             
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where CGL_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<ConfiguracaoGlobal> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<ConfiguracaoGlobal,                     ConfiguracaoGlobal>(newStrGetAll.ToString(),
                        //    (objConfiguracaoGlobal,                      ) => {
                        //                             
                        //        return objConfiguracaoGlobal;
                        //    }, new { maxInstances = maxInstances }, 
                        //    splitOn:"                     ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<ConfiguracaoGlobal>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllConfiguracaoGlobal", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ConfiguracaoGlobalRepository", "GetAllConfiguracaoGlobal", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from ConfiguracaoGlobal ");
                         
                    if(join)
                    {
                                             
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and CGL_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<ConfiguracaoGlobal> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<ConfiguracaoGlobal,                     ConfiguracaoGlobal>(newStrGetAll.ToString(),
                        //    (objConfiguracaoGlobal,                      ) => {
                        //                             
                        //        return objConfiguracaoGlobal;
                        //    },
                        //    new {
                        //        strPartial = "%" + strPartial + "%",
                        //        maxInstances = maxInstances
                        //    }, splitOn:"                     ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<ConfiguracaoGlobal>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}

                    salvaLog(null, "", "GetAllConfiguracaoGlobalByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ConfiguracaoGlobalRepository", "GetAllConfiguracaoGlobalByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<ConfiguracaoGlobal> GetAllConfiguracaoGlobalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * from ConfiguracaoGlobal ");
                    
                    if(join)
                    {
                                             
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and CGL_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<ConfiguracaoGlobal> lista = null;
                    //if (join)
                    //{
                        //lista = _db.Query<ConfiguracaoGlobal,                     ConfiguracaoGlobal>(newStrGetAll.ToString(),
                        //    (objConfiguracaoGlobal,                      ) => {
                        //                             
                        //        return objConfiguracaoGlobal;
                        //    },
                        //    new {
                        //        strValorExato = strValorExato,
                        //        maxInstances = maxInstances
                        //    }, splitOn:"                     ").AsEnumerable();
                    //}
                    //else
                    //{
                        lista = _db.Query<ConfiguracaoGlobal>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    //}
                    salvaLog(null, "", "GetAllConfiguracaoGlobalByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ConfiguracaoGlobalRepository", "GetAllConfiguracaoGlobalByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public string getCampoConfiguracaoGlobal(string key, int CGL_Id)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                string obj;
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("select " + key + " from [ConfiguracaoGlobal] ");
                    strGet.Append(" where CGL_Id = @CGL_Id ");

                    obj = _db.Query<string>(strGet.ToString(), new { CGL_Id = CGL_Id }).FirstOrDefault();
                }
                salvaLog(null, "", "getCampoConfiguracaoGlobal", strGet.ToString());
                return obj;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ConfiguracaoGlobalRepository", "getCampoConfiguracaoGlobal", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return "";
            }
        }
    }
}
