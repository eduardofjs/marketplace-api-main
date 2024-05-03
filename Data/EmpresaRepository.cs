
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
    public class EmpresaRepository : RepositoryBase, IEmpresaRepository
    {

        public Empresa InsertEmpresa(Empresa objEmpresa)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into Empresa ");
                    strInsert.Append("(EMP_RazaoSocial, EMP_NomeFantasia, EMP_CNPJ, EMP_Ativo, EMP_EnderecoId, EMP_TipoEmpresaId, EMP_Telefone, EMP_Contato, EMP_Site, EMP_ImagemPath, EMP_FlagMercadoInterno, EMP_FlagMercadoExterno, EMP_Valor, EMP_UsuarioId, EMP_CodigoSeguranca, EMP_Faturamento, EMP_DataCadastro, EMP_DataAbertura, EMP_FlagTermoTransporte, EMP_FlagTermoPagamento, EMP_FlagTermoPlataforma, EMP_FlagTermoUsoConta, EMP_FlagTermoPlataformaCobranca, EMP_FlagAprovado)");
                    strInsert.Append(@" VALUES (@EMP_RazaoSocial, @EMP_NomeFantasia, @EMP_CNPJ, @EMP_Ativo, @EMP_EnderecoId, @EMP_TipoEmpresaId, @EMP_Telefone, @EMP_Contato, @EMP_Site, @EMP_ImagemPath, @EMP_FlagMercadoInterno, @EMP_FlagMercadoExterno, @EMP_Valor, @EMP_UsuarioId, @EMP_CodigoSeguranca, @EMP_Faturamento, GETDATE(), @EMP_DataAbertura, @EMP_FlagTermoTransporte, @EMP_FlagTermoPagamento, @EMP_FlagTermoPlataforma, @EMP_FlagTermoUsoConta, @EMP_FlagTermoPlataformaCobranca, @EMP_FlagAprovado);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            EMP_RazaoSocial = objEmpresa.EMP_RazaoSocial,
                            EMP_NomeFantasia = objEmpresa.EMP_NomeFantasia,
                            EMP_CNPJ = objEmpresa.EMP_CNPJ,
                            EMP_Ativo = objEmpresa.EMP_Ativo,
                            EMP_EnderecoId = objEmpresa.EMP_EnderecoId,
                            EMP_TipoEmpresaId = objEmpresa.EMP_TipoEmpresaId,
                            EMP_Telefone = objEmpresa.EMP_Telefone,
                            EMP_Contato = objEmpresa.EMP_Contato,
                            EMP_Site = objEmpresa.EMP_Site,
                            EMP_ImagemPath = objEmpresa.EMP_ImagemPath,
                            EMP_FlagMercadoInterno = objEmpresa.EMP_FlagMercadoInterno,
                            EMP_FlagMercadoExterno = objEmpresa.EMP_FlagMercadoExterno,
                            EMP_Valor = objEmpresa.EMP_Valor,
                            EMP_UsuarioId = objEmpresa.EMP_UsuarioId,
                            EMP_CodigoSeguranca = objEmpresa.EMP_CodigoSeguranca,
                            EMP_Faturamento = objEmpresa.EMP_Faturamento,
                            EMP_DataAbertura = objEmpresa.EMP_DataAbertura,
                            EMP_FlagTermoTransporte = objEmpresa.EMP_FlagTermoTransporte,
                            EMP_FlagTermoPagamento = objEmpresa.EMP_FlagTermoPagamento,
                            EMP_FlagTermoPlataforma = objEmpresa.EMP_FlagTermoPlataforma,
                            EMP_FlagTermoUsoConta = objEmpresa.EMP_FlagTermoUsoConta,
                            EMP_FlagTermoPlataformaCobranca = objEmpresa.EMP_FlagTermoPlataformaCobranca,
                            EMP_FlagAprovado = objEmpresa.EMP_FlagAprovado
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objEmpresa.EMP_Id = queryInsert.First();

                    Log Log = new Log();
                    salvaLog(Log, "", "InsertEmpresa", strInsert.ToString());
                    return objEmpresa;
                }
            }
            catch (Exception e)
            {
                Log Log = new Log();
                salvaLogError(Log, "EmpresaRepository", "InsertEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Empresa();
            }
        }

        public bool UpdateEmpresa(Empresa objEmpresa)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update Empresa ");
                    strUpdate.Append(@" SET EMP_RazaoSocial = @EMP_RazaoSocial
                        , EMP_NomeFantasia = @EMP_NomeFantasia
                        , EMP_CNPJ = @EMP_CNPJ
                        , EMP_Ativo = @EMP_Ativo
                        , EMP_EnderecoId = @EMP_EnderecoId
                        , EMP_TipoEmpresaId = @EMP_TipoEmpresaId
                        , EMP_Telefone = @EMP_Telefone
                        , EMP_Contato = @EMP_Contato
                        , EMP_Site = @EMP_Site
                        , EMP_ImagemPath = @EMP_ImagemPath
                        , EMP_FlagMercadoInterno = @EMP_FlagMercadoInterno
                        , EMP_FlagMercadoExterno = @EMP_FlagMercadoExterno
                        , EMP_Valor = @EMP_Valor
                        , EMP_UsuarioId = @EMP_UsuarioId
                        , EMP_CodigoSeguranca = @EMP_CodigoSeguranca
                        , EMP_Faturamento = @EMP_Faturamento
                        , EMP_DataAbertura = @EMP_DataAbertura
                        , EMP_FlagTermoTransporte = @EMP_FlagTermoTransporte
                        , EMP_FlagTermoPagamento = @EMP_FlagTermoPagamento
                        , EMP_FlagTermoPlataforma = @EMP_FlagTermoPlataforma
                        , EMP_FlagTermoUsoConta = @EMP_FlagTermoUsoConta
                        , EMP_FlagTermoPlataformaCobranca = @EMP_FlagTermoPlataformaCobranca
                        , EMP_FlagAprovado = @EMP_FlagAprovado
                         where EMP_Id = @EMP_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               EMP_RazaoSocial = objEmpresa.EMP_RazaoSocial,
                               EMP_NomeFantasia = objEmpresa.EMP_NomeFantasia,
                               EMP_CNPJ = objEmpresa.EMP_CNPJ,
                               EMP_Ativo = objEmpresa.EMP_Ativo,
                               EMP_EnderecoId = objEmpresa.EMP_EnderecoId,
                               EMP_TipoEmpresaId = objEmpresa.EMP_TipoEmpresaId,
                               EMP_Telefone = objEmpresa.EMP_Telefone,
                               EMP_Contato = objEmpresa.EMP_Contato,
                               EMP_Site = objEmpresa.EMP_Site,
                               EMP_ImagemPath = objEmpresa.EMP_ImagemPath,
                               EMP_FlagMercadoInterno = objEmpresa.EMP_FlagMercadoInterno,
                               EMP_FlagMercadoExterno = objEmpresa.EMP_FlagMercadoExterno,
                               EMP_Valor = objEmpresa.EMP_Valor,
                               EMP_UsuarioId = objEmpresa.EMP_UsuarioId,
                               EMP_CodigoSeguranca = objEmpresa.EMP_CodigoSeguranca,
                               EMP_Faturamento = objEmpresa.EMP_Faturamento,
                               EMP_DataAbertura = objEmpresa.EMP_DataAbertura,
                               EMP_FlagTermoTransporte = objEmpresa.EMP_FlagTermoTransporte,
                               EMP_FlagTermoPagamento = objEmpresa.EMP_FlagTermoPagamento,
                               EMP_FlagTermoPlataforma = objEmpresa.EMP_FlagTermoPlataforma,
                               EMP_FlagTermoUsoConta = objEmpresa.EMP_FlagTermoUsoConta,
                               EMP_FlagTermoPlataformaCobranca = objEmpresa.EMP_FlagTermoPlataformaCobranca,
                               EMP_FlagAprovado = objEmpresa.EMP_FlagAprovado,
                               EMP_Id = objEmpresa.EMP_Id
                           });
                }
                Log Log = new Log();
                salvaLog(Log, "", "UpdateEmpresa", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                Log Log = new Log();
                salvaLogError(Log, "EmpresaRepository", "UpdateEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarEmpresa(int EMP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Empresa set ");
                    strUpdate.Append(" EMP_Ativo = @EMP_Ativo ");
                    strUpdate.Append(" where EMP_Id = @EMP_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EMP_Ativo = 1,
                                            EMP_Id = EMP_Id
                                        });
                }
                salvaLog(null, "", "AtivarEmpresa", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaRepository", "AtivarEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarEmpresa(int EMP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Empresa set ");
                    strUpdate.Append(" EMP_Ativo = @EMP_Ativo ");
                    strUpdate.Append(" where EMP_Id = @EMP_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EMP_Ativo = 0,
                                            EMP_Id = EMP_Id
                                        });
                }
                salvaLog(null, "", "DeletarEmpresa", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaRepository", "DeletarEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Empresa GetEmpresaById(int EMP_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from Empresa ");
                    if (join)
                    {
                        strGet.Append(@" join TipoEmpresa on EMP_TipoEmpresaId = TEM_Id ");
                    }

                    strGet.Append(" where EMP_Id = @EMP_Id");

                    Empresa obj = null;
                    //if (join)
                    //{
                    //obj = _db.Query<Empresa,      TipoEmpresa,     Empresa>(strGet.ToString(),
                    //    (objEmpresa,       objTipoEmpresa,    ) => {
                    //              objEmpresa.TipoEmpresa = objTipoEmpresa;
                    //            
                    //        return objEmpresa;
                    //    }, new { maxInstances = maxInstances }, 
                    //    splitOn:"      TEM_Id,    ").FirstOrDefault();
                    //}
                    //else
                    //{
                    obj = _db.Query<Empresa>(strGet.ToString(), new { EMP_Id = EMP_Id }).FirstOrDefault();
                    //}

                    if (join)
                    {
                        var _UsuarioRepo = new UsuarioRepository();
                        obj.Usuario = _UsuarioRepo.GetUsuarioById(obj.EMP_UsuarioId, true);
                    }

                    salvaLog(null, "", "GetEmpresaById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaRepository", "GetEmpresaById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Empresa> GetAllEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from Empresa ");
                    if (join)
                    {
                        strGetAll.Append(@" inner join TipoEmpresa on EMP_TipoEmpresaId = TEM_Id ");
                        strGetAll.Append(@" left join Endereco on EMP_EnderecoId = END_Id ");
                        strGetAll.Append(@" inner join Usuario on EMP_UsuarioId = USR_Id ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where EMP_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<Empresa> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Empresa, TipoEmpresa, Endereco, Usuario, Empresa>(newStrGetAll.ToString(),
                            (objEmpresa, objTipoEmpresa, objEndereco, objUsuario) =>
                            {
                                objEmpresa.TipoEmpresa = objTipoEmpresa;
                                objEmpresa.Endereco = objEndereco;
                                objEmpresa.Usuario = objUsuario;
                                return objEmpresa;
                            }, new { maxInstances = maxInstances },
                            splitOn: "TEM_Id,END_Id,USR_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Empresa>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresa", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaRepository", "GetAllEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Empresa> GetAllEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from Empresa ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join TipoEmpresa on EMP_TipoEmpresaId = TEM_Id ");
                        strGetAll.Append(@" left join Endereco on EMP_EnderecoId = END_Id ");
                        strGetAll.Append(@" inner join Usuario on EMP_UsuarioId = USR_Id ");
                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and EMP_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Empresa> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Empresa, TipoEmpresa, Endereco, Usuario, Empresa>(newStrGetAll.ToString(),
                            (objEmpresa, objTipoEmpresa, objEndereco, objUsuario) =>
                            {
                                objEmpresa.TipoEmpresa = objTipoEmpresa;
                                objEmpresa.Endereco = objEndereco;
                                objEmpresa.Usuario = objUsuario;
                                return objEmpresa;
                            }, new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            },
                            splitOn: "TEM_Id,END_Id,USR_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Empresa>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    salvaLog(null, "", "GetAllEmpresaByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaRepository", "GetAllEmpresaByPartial", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Empresa> GetAllEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") + " * from Empresa ");

                    if (join)
                    {
                        strGetAll.Append(@" inner join TipoEmpresa on EMP_TipoEmpresaId = TEM_Id ");
                        strGetAll.Append(@" left join Endereco on EMP_EnderecoId = END_Id ");
                        strGetAll.Append(@" inner join Usuario on EMP_UsuarioId = USR_Id ");
                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and EMP_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Empresa> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Empresa, TipoEmpresa, Endereco, Usuario, Empresa>(newStrGetAll.ToString(),
                            (objEmpresa, objTipoEmpresa, objEndereco, objUsuario) =>
                            {
                                objEmpresa.TipoEmpresa = objTipoEmpresa;
                                objEmpresa.Endereco = objEndereco;
                                objEmpresa.Usuario = objUsuario;
                                return objEmpresa;
                            }, new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            },
                            splitOn: "TEM_Id,END_Id,USR_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Empresa>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }
                    salvaLog(null, "", "GetAllEmpresaByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaRepository", "GetAllEmpresaByValorExato", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public bool AprovarEmpresa(int EMP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Empresa set ");
                    strUpdate.Append(" EMP_FlagAprovado = @EMP_FlagAprovado, ");
                    strUpdate.Append(" EMP_DataAprovado = GETDATE() ");
                    strUpdate.Append(" where EMP_Id = @EMP_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EMP_FlagAprovado = 1,
                                            EMP_Id = EMP_Id
                                        });
                }
                salvaLog(null, "", "AprovarEmpresa", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaRepository", "AprovarEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool ReprovarEmpresa(int EMP_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update Empresa set ");
                    strUpdate.Append(" EMP_FlagAprovado = @EMP_FlagAprovado, ");
                    strUpdate.Append(" EMP_DataReprovado = GETDATE() ");
                    strUpdate.Append(" where EMP_Id = @EMP_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            EMP_FlagAprovado = 0,
                                            EMP_Id = EMP_Id
                                        });
                }
                salvaLog(null, "", "ReprovarEmpresa", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "EmpresaRepository", "ReprovarEmpresa", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }
    }
}
