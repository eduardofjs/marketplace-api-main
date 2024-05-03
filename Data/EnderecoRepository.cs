
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
    public class EnderecoRepository : RepositoryBase, IEnderecoRepository
    {
        
        public Endereco InsertEndereco(Endereco objEndereco)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Endereco] ");
                    strInsert.Append("(END_Logradouro, END_Numero, END_Bairro, END_Cidade, END_Estado, END_Pais, END_Complemento, END_CEP, END_CidadeId, END_EstadoId, END_Latitude, END_Longitude, END_Ativo, END_Regiao, END_CodIBGE)");
                    strInsert.Append(@" VALUES (@END_Logradouro, @END_Numero, @END_Bairro, @END_Cidade, @END_Estado, @END_Pais, @END_Complemento, @END_CEP, @END_CidadeId, @END_EstadoId, @END_Latitude, @END_Longitude, @END_Ativo, @END_Regiao, @END_CodIBGE);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            END_Logradouro = objEndereco.END_Logradouro,
                            END_Numero = objEndereco.END_Numero,
                            END_Bairro = objEndereco.END_Bairro,
                            END_Cidade = objEndereco.END_Cidade,
                            END_Estado = objEndereco.END_Estado,
                            END_Pais = objEndereco.END_Pais,
                            END_Complemento = objEndereco.END_Complemento,
                            END_CEP = objEndereco.END_CEP,
                            END_CidadeId = objEndereco.END_CidadeId,
                            END_EstadoId = objEndereco.END_EstadoId,
                            END_Latitude = objEndereco.END_Latitude,
                            END_Longitude = objEndereco.END_Longitude,
                            END_Ativo = 1,
                            END_Regiao = objEndereco.END_Regiao,
                            END_CodIBGE = objEndereco.END_CodIBGE,
                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objEndereco.END_Id = queryInsert.First();

                    salvaLog(objEndereco.Log, "", "InsertEndereco", strInsert.ToString());
                    return objEndereco;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objEndereco.Log, "EnderecoRepository", "InsertEndereco", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objEndereco.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Endereco();
            }
        }


        public bool UpdateEndereco(Endereco objEndereco)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Endereco] ");
                    strUpdate.Append(@" SET END_Logradouro = @END_Logradouro
                        , END_Numero = @END_Numero
                        , END_Bairro = @END_Bairro
                        , END_Cidade = @END_Cidade
                        , END_Estado = @END_Estado
                        , END_Pais = @END_Pais
                        , END_Complemento = @END_Complemento
                        , END_CEP = @END_CEP
                        , END_CidadeId = @END_CidadeId
                        , END_EstadoId = @END_EstadoId
                        , END_Latitude = @END_Latitude
                        , END_Longitude = @END_Longitude
                        , END_Ativo = @END_Ativo
                        , END_Regiao = @END_Regiao
                        , END_CodIBGE = @END_CodIBGE
                         where END_Id = @END_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                            END_Logradouro = objEndereco.END_Logradouro,
                            END_Numero = objEndereco.END_Numero,
                            END_Bairro = objEndereco.END_Bairro,
                            END_Cidade = objEndereco.END_Cidade,
                            END_Estado = objEndereco.END_Estado,
                            END_Pais = objEndereco.END_Pais,
                            END_Complemento = objEndereco.END_Complemento,
                            END_CEP = objEndereco.END_CEP,
                            END_CidadeId = objEndereco.END_CidadeId,
                            END_EstadoId = objEndereco.END_EstadoId,
                            END_Latitude = objEndereco.END_Latitude,
                            END_Longitude = objEndereco.END_Longitude,
                            END_Ativo = 1,
                            END_Regiao = objEndereco.END_Regiao,
                            END_CodIBGE = objEndereco.END_CodIBGE,
                            
                            END_Id = objEndereco.END_Id                            
                           });
                }
                salvaLog(objEndereco.Log, "", "UpdateEndereco", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objEndereco.Log, "EnderecoRepository", "UpdateEndereco", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objEndereco.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarEndereco(int END_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Endereco] set ");
                    strUpdate.Append(" END_Ativo = @END_Ativo ");
                    strUpdate.Append(" where END_Id = @END_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            END_Ativo = 1,
                                            END_Id = END_Id
                                        });
                }
                salvaLog(null, "", "AtivarEndereco", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EnderecoRepository", "AtivarEndereco", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarEndereco(int END_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Endereco] set ");
                    strUpdate.Append(" END_Ativo = @END_Ativo ");
                    strUpdate.Append(" where END_Id = @END_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            END_Ativo = 0,
                                            END_Id = END_Id
                                        });
                }
                salvaLog(null, "", "DeletarEndereco", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EnderecoRepository", "DeletarEndereco", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Endereco GetEnderecoById(int END_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT END_Id, END_Logradouro, END_Numero, END_Bairro, END_Cidade, END_Estado, END_Pais, END_Complemento, END_CEP, END_CidadeId, END_EstadoId, END_Latitude, END_Longitude, END_Ativo, END_Regiao, END_CodIBGE from [Endereco] ");
                    strGet.Append(" where END_Id = @END_Id");

                    var obj = _db.Query<Endereco>(strGet.ToString(), new { END_Id = END_Id }).FirstOrDefault();

                    if(obj != null && join){                          
                                    var _CidadeRepo = new CidadeRepository();
                            obj.Cidade = _CidadeRepo.GetCidadeById(obj.END_CidadeId.GetValueOrDefault(), true);
                            var _EstadoRepo = new EstadoRepository();
                            obj.Estado = _EstadoRepo.GetEstadoById(obj.END_EstadoId.GetValueOrDefault(), true);
                                   
                    }

                    salvaLog(null, "", "GetEnderecoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EnderecoRepository", "GetEnderecoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Endereco> GetAllEndereco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Endereco] ");
                    if(join)
                    {
                                strGetAll.Append(@" join Cidade on END_CidadeId = CDD_Id ");
                        strGetAll.Append(@" join Estado on END_EstadoId = ESD_Id ");
                             
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where END_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Endereco> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Endereco,        Cidade, Estado,      Endereco>(newStrGetAll.ToString(),
                            (objEndereco,         objCidade,objEstado     ) => {
                                        objEndereco.Cidade = objCidade;
                                objEndereco.Estado = objEstado;
                                     
                                return objEndereco;
                            }, new { maxInstances = maxInstances }, 
                            splitOn: "CDD_Id,ESD_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Endereco>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEndereco", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EnderecoRepository", "GetAllEndereco", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Endereco> GetAllEnderecoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Endereco] ");
                         
                    if(join)
                    {
                                strGetAll.Append(@" join Cidade on END_CidadeId = CDD_Id ");
                        strGetAll.Append(@" join Estado on END_EstadoId = ESD_Id ");
                             
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and END_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Endereco> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Endereco,        Cidade, Estado,      Endereco>(newStrGetAll.ToString(),
                            (objEndereco,         objCidade,objEstado     ) => {
                                        objEndereco.Cidade = objCidade;
                                objEndereco.Estado = objEstado;
                                     
                                return objEndereco;
                            },
                            new {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }, splitOn: "        CDD_Id,ESD_Id     ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Endereco>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEnderecoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EnderecoRepository", "GetAllEnderecoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Endereco> GetAllEnderecoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") +" * from [Endereco] ");
                    
                    if(join)
                    {
                                strGetAll.Append(@" join Cidade on END_CidadeId = CDD_Id ");
                        strGetAll.Append(@" join Estado on END_EstadoId = ESD_Id ");
                             
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and END_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Endereco> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Endereco,        Cidade, Estado,      Endereco>(newStrGetAll.ToString(),
                            (objEndereco,         objCidade,objEstado     ) => {
                                        objEndereco.Cidade = objCidade;
                                objEndereco.Estado = objEstado;
                                     
                                return objEndereco;
                            },
                            new {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }, splitOn: "        CDD_Id,ESD_Id     ").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Endereco>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllEnderecoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EnderecoRepository", "GetAllEnderecoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
