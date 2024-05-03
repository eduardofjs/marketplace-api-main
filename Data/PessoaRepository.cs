
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
    public class PessoaRepository : RepositoryBase, IPessoaRepository
    {

        public Pessoa InsertPessoa(Pessoa objPessoa)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Pessoa] ");
                    strInsert.Append("(PES_Nome, PES_SexoId, PES_CPF, PES_DataNascimento, PES_Ativo, PES_RG, PES_EnderecoId, PES_EnderecoFoto, PES_TelefoneResidencial, PES_Celular, PES_Email, PES_PronomeTratamentoId, PES_Renda, PES_SexoBiologico,PES_NomeResponsavel,PES_CPFResponsavel, PES_flagDoador)");
                    strInsert.Append(@" VALUES (@PES_Nome, @PES_SexoId, @PES_CPF, @PES_DataNascimento, @PES_Ativo, @PES_RG, @PES_EnderecoId, @PES_EnderecoFoto, @PES_TelefoneResidencial, @PES_Celular, @PES_Email, @PES_PronomeTratamentoId, @PES_Renda, @PES_SexoBiologico,@PES_NomeResponsavel,@PES_CPFResponsavel, @PES_flagDoador);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            PES_Nome = objPessoa.PES_Nome,
                            PES_SexoId = objPessoa.PES_SexoId,
                            PES_CPF = objPessoa.PES_CPF,
                            PES_DataNascimento = objPessoa.PES_DataNascimento,
                            PES_Ativo = 1,
                            PES_RG = objPessoa.PES_RG,
                            PES_EnderecoId = objPessoa.PES_EnderecoId,
                            PES_EnderecoFoto = objPessoa.PES_EnderecoFoto,
                            PES_TelefoneResidencial = objPessoa.PES_TelefoneResidencial,
                            PES_Celular = objPessoa.PES_Celular,
                            PES_Email = objPessoa.PES_Email,
                            PES_PronomeTratamentoId = objPessoa.PES_PronomeTratamentoId,
                            PES_Renda = objPessoa.PES_Renda,
                            PES_SexoBiologico = objPessoa.PES_SexoBiologico,
                            PES_NomeResponsavel = objPessoa.PES_NomeResponsavel,
                            PES_CPFResponsavel = objPessoa.PES_CPFResponsavel,
                            PES_flagDoador = objPessoa.PES_flagDoador,
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objPessoa.PES_Id = queryInsert.First();

                    salvaLog(objPessoa.Log, "", "InsertPessoa", strInsert.ToString());
                    return objPessoa;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objPessoa.Log, "PessoaRepository", "InsertPessoa", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objPessoa.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Pessoa();
            }
        }


        public bool UpdatePessoa(Pessoa objPessoa)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Pessoa] ");
                    strUpdate.Append(@" SET PES_Nome = @PES_Nome
                        , PES_SexoId = @PES_SexoId
                        , PES_CPF = @PES_CPF
                        , PES_DataNascimento = @PES_DataNascimento
                        , PES_Ativo = @PES_Ativo
                        , PES_RG = @PES_RG
                        , PES_EnderecoId = @PES_EnderecoId
                        , PES_TelefoneResidencial = @PES_TelefoneResidencial
                        , PES_Celular = @PES_Celular
                        , PES_Email = @PES_Email
                        , PES_PronomeTratamentoId = @PES_PronomeTratamentoId
                        , PES_Renda = @PES_Renda
                        , PES_SexoBiologico = @PES_SexoBiologico
                        , PES_NomeResponsavel = @PES_NomeResponsavel
                        , PES_CPFResponsavel = @PES_CPFResponsavel
                        , PES_flagDoador = @PES_flagDoador");

                    if (!string.IsNullOrEmpty(objPessoa.PES_EnderecoFoto))
                        strUpdate.Append(@", PES_EnderecoFoto = @PES_EnderecoFoto ");
                    strUpdate.Append(@"  where PES_Id = @PES_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                               PES_Nome = objPessoa.PES_Nome,
                               PES_SexoId = objPessoa.PES_SexoId,
                               PES_CPF = objPessoa.PES_CPF,
                               PES_DataNascimento = objPessoa.PES_DataNascimento,
                               PES_Ativo = 1,
                               PES_RG = objPessoa.PES_RG,
                               PES_EnderecoId = objPessoa.PES_EnderecoId,
                               PES_EnderecoFoto = objPessoa.PES_EnderecoFoto,
                               PES_TelefoneResidencial = objPessoa.PES_TelefoneResidencial,
                               PES_Celular = objPessoa.PES_Celular,
                               PES_Email = objPessoa.PES_Email,
                               PES_PronomeTratamentoId = objPessoa.PES_PronomeTratamentoId,
                               PES_Renda = objPessoa.PES_Renda,
                               PES_SexoBiologico = objPessoa.PES_SexoBiologico,
                               PES_NomeResponsavel = objPessoa.PES_NomeResponsavel,
                               PES_CPFResponsavel = objPessoa.PES_CPFResponsavel,
                               PES_flagDoador = objPessoa.PES_flagDoador,
                               PES_Id = objPessoa.PES_Id
                           });
                }
                salvaLog(objPessoa.Log, "", "UpdatePessoa", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {
                salvaLogError(objPessoa.Log, "PessoaRepository", "UpdatePessoa", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objPessoa.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarPessoa(int PES_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Pessoa] set ");
                    strUpdate.Append(" PES_Ativo = @PES_Ativo ");
                    strUpdate.Append(" where PES_Id = @PES_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PES_Ativo = 1,
                                            PES_Id = PES_Id
                                        });
                }
                salvaLog(null, "", "AtivarPessoa", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PessoaRepository", "AtivarPessoa", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarPessoa(int PES_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Pessoa] set ");
                    strUpdate.Append(" PES_Ativo = @PES_Ativo ");
                    strUpdate.Append(" where PES_Id = @PES_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            PES_Ativo = 0,
                                            PES_Id = PES_Id
                                        });
                }
                salvaLog(null, "", "DeletarPessoa", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "PessoaRepository", "DeletarPessoa", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Pessoa GetPessoaById(int PES_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT PES_Id, PES_Nome, PES_SexoId, PES_CPF, PES_DataNascimento, PES_Ativo, PES_RG, PES_EnderecoId, PES_EnderecoFoto, PES_TelefoneResidencial, PES_Celular, PES_Email, PES_PronomeTratamentoId, PES_Renda, PES_SexoBiologico, PES_NomeResponsavel,PES_CPFResponsavel,PES_flagDoador from [Pessoa] ");
                    strGet.Append(" where PES_Id = @PES_Id");

                    var obj = _db.Query<Pessoa>(strGet.ToString(), new { PES_Id = PES_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {
                        var _SexoRepo = new SexoRepository();
                        obj.Sexo = _SexoRepo.GetSexoById(obj.PES_SexoId.GetValueOrDefault(), true);
                        var _EnderecoRepo = new EnderecoRepository();
                        obj.Endereco = _EnderecoRepo.GetEnderecoById(obj.PES_EnderecoId.GetValueOrDefault(), true);
                        var _PronomeTratamentoRepo = new PronomeTratamentoRepository();
                        obj.PronomeTratamento = _PronomeTratamentoRepo.GetPronomeTratamentoById(obj.PES_PronomeTratamentoId.GetValueOrDefault(), true);

                    }

                    if (obj != null)
                    {

                        if (!string.IsNullOrEmpty(obj.PES_EnderecoFoto))
                            obj.PES_EnderecoFoto = ReadString("CGL_UrlImagem") + obj.PES_EnderecoFoto.Replace("\\", "/");
                    }

                    salvaLog(null, "", "GetPessoaById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PessoaRepository", "GetPessoaById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Pessoa> GetAllPessoa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Pessoa] ");
                    if (join)
                    {
                        strGetAll.Append(@" join Sexo on PES_SexoId = SEX_Id ");
                        strGetAll.Append(@" join Endereco on PES_EnderecoId = END_Id ");
                        strGetAll.Append(@" join PronomeTratamento on PES_PronomeTratamentoId = PRT_Id ");

                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" where PES_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);


                    IEnumerable<Pessoa> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Pessoa, Sexo, Endereco, PronomeTratamento, Pessoa>(newStrGetAll.ToString(),
                            (objPessoa, objSexo, objEndereco, objPronomeTratamento) =>
                            {
                                objPessoa.Sexo = objSexo;
                                objPessoa.Endereco = objEndereco;
                                objPessoa.PronomeTratamento = objPronomeTratamento;

                                return objPessoa;
                            }, new { maxInstances = maxInstances },
                            splitOn: "  SEX_Id,    END_Id,    PRT_Id,").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Pessoa>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.PES_EnderecoFoto))
                                item.PES_EnderecoFoto = ReadString("CGL_UrlImagem") + item.PES_EnderecoFoto.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllPessoa", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PessoaRepository", "GetAllPessoa", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Pessoa> GetAllPessoaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Pessoa] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Sexo on PES_SexoId = SEX_Id ");
                        strGetAll.Append(@" join Endereco on PES_EnderecoId = END_Id ");
                        strGetAll.Append(@" join PronomeTratamento on PES_PronomeTratamentoId = PRT_Id ");

                    }

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PES_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Pessoa> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Pessoa, Sexo, Endereco, PronomeTratamento, Pessoa>(newStrGetAll.ToString(),
                            (objPessoa, objSexo, objEndereco, objPronomeTratamento) =>
                            {
                                objPessoa.Sexo = objSexo;
                                objPessoa.Endereco = objEndereco;
                                objPessoa.PronomeTratamento = objPronomeTratamento;

                                return objPessoa;
                            },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }, splitOn: "  SEX_Id,    END_Id,    PRT_Id,").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Pessoa>(newStrGetAll.ToString(),
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.PES_EnderecoFoto))
                                item.PES_EnderecoFoto = ReadString("CGL_UrlImagem") + item.PES_EnderecoFoto.Replace("\\", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllPessoaByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PessoaRepository", "GetAllPessoaByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Pessoa> GetAllPessoaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Pessoa] ");

                    if (join)
                    {
                        strGetAll.Append(@" join Sexo on PES_SexoId = SEX_Id ");
                        strGetAll.Append(@" join Endereco on PES_EnderecoId = END_Id ");
                        strGetAll.Append(@" join PronomeTratamento on PES_PronomeTratamentoId = PRT_Id ");

                    }

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PES_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Pessoa> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Pessoa, Sexo, Endereco, PronomeTratamento, Pessoa>(newStrGetAll.ToString(),
                            (objPessoa, objSexo, objEndereco, objPronomeTratamento) =>
                            {
                                objPessoa.Sexo = objSexo;
                                objPessoa.Endereco = objEndereco;
                                objPessoa.PronomeTratamento = objPronomeTratamento;

                                return objPessoa;
                            },
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }, splitOn: "  SEX_Id,    END_Id,    PRT_Id,").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Pessoa>(newStrGetAll.ToString(),
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }).AsEnumerable();
                    }

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.PES_EnderecoFoto))
                                item.PES_EnderecoFoto = ReadString("CGL_UrlImagem") + item.PES_EnderecoFoto.Replace("\\", "/");
                        }
                    }
                    salvaLog(null, "", "GetAllPessoaByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "PessoaRepository", "GetAllPessoaByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
