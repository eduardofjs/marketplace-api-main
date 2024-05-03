
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
    public class CidadeRepository : RepositoryBase, ICidadeRepository
    {
        
        public Cidade InsertCidade(Cidade objCidade)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Cidade] ");
                    strInsert.Append("(CDD_Nome, CDD_EstadoId, CDD_CepInicial, CDD_CepFinal, CDD_FlgNaturalidade, CDD_Ativo)");
                    strInsert.Append(@" VALUES (@CDD_Nome, @CDD_EstadoId, @CDD_CepInicial, @CDD_CepFinal, @CDD_FlgNaturalidade, @CDD_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            CDD_Nome = objCidade.CDD_Nome,
                            CDD_EstadoId = objCidade.CDD_EstadoId,
                            CDD_CepInicial = objCidade.CDD_CepInicial,
                            CDD_CepFinal = objCidade.CDD_CepFinal,
                            CDD_FlgNaturalidade = objCidade.CDD_FlgNaturalidade,
                            CDD_Ativo = 1,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objCidade.CDD_Id = queryInsert.First();

                    salvaLog(objCidade.Log, "", "InsertCidade", strInsert.ToString());
                    return objCidade;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objCidade.Log, "CidadeRepository", "InsertCidade", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objCidade.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Cidade();
            }
        }


        public bool UpdateCidade(Cidade objCidade)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Cidade] ");
                    strUpdate.Append(@" SET CDD_Nome = @CDD_Nome
                        , CDD_EstadoId = @CDD_EstadoId
                        , CDD_CepInicial = @CDD_CepInicial
                        , CDD_CepFinal = @CDD_CepFinal
                        , CDD_FlgNaturalidade = @CDD_FlgNaturalidade
                        , CDD_Ativo = @CDD_Ativo
                         where CDD_Id = @CDD_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            CDD_Nome = objCidade.CDD_Nome,
                            CDD_EstadoId = objCidade.CDD_EstadoId,
                            CDD_CepInicial = objCidade.CDD_CepInicial,
                            CDD_CepFinal = objCidade.CDD_CepFinal,
                            CDD_FlgNaturalidade = objCidade.CDD_FlgNaturalidade,
                            CDD_Ativo = 1,
                            
                            CDD_Id = objCidade.CDD_Id                            
                           });
                }
                salvaLog(objCidade.Log, "", "UpdateCidade", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objCidade.Log, "CidadeRepository", "UpdateCidade", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objCidade.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarCidade(int CDD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Cidade] set ");
                    strUpdate.Append(" CDD_Ativo = @CDD_Ativo ");
                    strUpdate.Append(" where CDD_Id = @CDD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            CDD_Ativo = 1,
                                            CDD_Id = CDD_Id
                                        });
                }
                salvaLog(null, "", "AtivarCidade", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "CidadeRepository", "AtivarCidade", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarCidade(int CDD_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Cidade] set ");
                    strUpdate.Append(" CDD_Ativo = @CDD_Ativo ");
                    strUpdate.Append(" where CDD_Id = @CDD_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            CDD_Ativo = 0,
                                            CDD_Id = CDD_Id
                                        });
                }
                salvaLog(null, "", "DeletarCidade", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "CidadeRepository", "DeletarCidade", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Cidade GetCidadeById(int CDD_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT CDD_Id, CDD_Nome, CDD_EstadoId, CDD_CepInicial, CDD_CepFinal, CDD_FlgNaturalidade, CDD_Ativo from [Cidade] ");
                    strGet.Append(" where CDD_Id = @CDD_Id");

                    var obj = _db.Query<Cidade>(strGet.ToString(), new { CDD_Id = CDD_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                              var _EstadoRepo = new EstadoRepository();
                            obj.Estado = _EstadoRepo.GetEstadoById(obj.CDD_EstadoId.GetValueOrDefault(), true);
                                  
                    }

                    salvaLog(null, "", "GetCidadeById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "CidadeRepository", "GetCidadeById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Cidade> GetAllCidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Cidade] ");
                    if(join)
                    {
                          strGetAll.Append(@" join Estado on CDD_EstadoId = ESD_Id ");
                            
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where CDD_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Cidade> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Cidade,  Estado,     Cidade>(newStrGetAll.ToString(),
                            (objCidade,   objEstado    ) => {
                                  objCidade.Estado = objEstado;
                                    
                                return objCidade;
                            }, new { maxInstances = maxInstances }, 
                            splitOn: "ESD_Id").AsEnumerable();
                    }
                    else
                    {
                    }

                    salvaLog(null, "", "GetAllCidade", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "CidadeRepository", "GetAllCidade", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Cidade> GetAllCidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Cidade] ");
                         
                    if(join)
                    {
                          strGetAll.Append(@" join Estado on CDD_EstadoId = ESD_Id ");
                            
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and CDD_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Cidade> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Cidade,  Estado,     Cidade>(newStrGetAll.ToString(),
                            (objCidade,   objEstado    ) => {
                                  objCidade.Estado = objEstado;
                                    
                                return objCidade;
                            },
                            new {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }, splitOn: "  ESD_Id,    ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Cidade>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllCidadeByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "CidadeRepository", "GetAllCidadeByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Cidade> GetAllCidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Cidade] ");
                    
                    if(join)
                    {
                          strGetAll.Append(@" join Estado on CDD_EstadoId = ESD_Id ");
                            
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and CDD_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Cidade> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Cidade,  Estado,     Cidade>(newStrGetAll.ToString(),
                            (objCidade,   objEstado    ) => {
                                  objCidade.Estado = objEstado;
                                    
                                return objCidade;
                            },
                            new {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }, splitOn: "  ESD_Id,    ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Cidade>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllCidadeByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "CidadeRepository", "GetAllCidadeByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
