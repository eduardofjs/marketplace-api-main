
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
    public class ProdutoRepository : RepositoryBase, IProdutoRepository
    {

        public Produto InsertProduto(Produto objProduto)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT into [Produto] ");
                    strInsert.Append("(PDT_UsuarioInsercaoId, PDT_Descricao, PDT_Nome, PDT_DescricaoIngles, PDT_NomeIngles, PDT_FlagAtivo, PDT_DataCadastro)");
                    strInsert.Append(@" VALUES (@PDT_UsuarioInsercaoId, @PDT_Descricao, @PDT_Nome, @PDT_DescricaoIngles, @PDT_NomeIngles, @PDT_FlagAtivo, GETDATE());");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            PDT_UsuarioInsercaoId = objProduto.PDT_UsuarioInsercaoId,
                            PDT_Descricao = objProduto.PDT_Descricao,
                            PDT_Nome = objProduto.PDT_Nome,
                            PDT_DescricaoIngles = objProduto.PDT_DescricaoIngles,
                            PDT_NomeIngles = objProduto.PDT_NomeIngles,
                            PDT_FlagAtivo = objProduto.PDT_FlagAtivo
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objProduto.PDT_Id = queryInsert.First();

                    salvaLog(objProduto.Log, "", "InsertProduto", strInsert.ToString());
                    return objProduto;
                }
            }
            catch (Exception e)
            {
                salvaLogError(objProduto.Log, "ProdutoRepository", "InsertProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Produto();
            }
        }


        public bool UpdateProduto(Produto objProduto)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" Update [Produto] ");
                    strUpdate.Append(@" SET PDT_UsuarioInsercaoId = @PDT_UsuarioInsercaoId
                        , PDT_Descricao = @PDT_Descricao
                        , PDT_Nome = @PDT_Nome
                        , PDT_DescricaoIngles = @PDT_DescricaoIngles
                        , PDT_NomeIngles = @PDT_NomeIngles
                        , PDT_FlagAtivo = @PDT_FlagAtivo
                         where PDT_Id = @PDT_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            PDT_UsuarioInsercaoId = objProduto.PDT_UsuarioInsercaoId,
                            PDT_Descricao = objProduto.PDT_Descricao,
                            PDT_Nome = objProduto.PDT_Nome,
                            PDT_DescricaoIngles = objProduto.PDT_DescricaoIngles,
                            PDT_NomeIngles = objProduto.PDT_NomeIngles,
                            PDT_FlagAtivo = objProduto.PDT_FlagAtivo,

                            PDT_Id = objProduto.PDT_Id
                        });
                }
                salvaLog(objProduto.Log, "", "UpdateProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(objProduto.Log, "ProdutoRepository", "UpdateProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());

                salvaLog(objProduto.Log, e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool AtivarProduto(int PDT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Produto] set ");
                    strUpdate.Append(" PDT_FlagAtivo = @PDT_FlagAtivo ");
                    strUpdate.Append(" where PDT_Id = @PDT_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            PDT_FlagAtivo = 1,
                            PDT_Id = PDT_Id
                        });
                }
                salvaLog(null, "", "AtivarProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ProdutoRepository", "AtivarProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarProduto(int PDT_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("update [Produto] set ");
                    strUpdate.Append(" PDT_FlagAtivo = @PDT_FlagAtivo ");
                    strUpdate.Append(" where PDT_Id = @PDT_Id ");

                    _db.Execute(
                        strUpdate.ToString(),
                        new
                        {
                            PDT_FlagAtivo = 0,
                            PDT_Id = PDT_Id
                        });
                }
                salvaLog(null, "", "DeletarProduto", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "ProdutoRepository", "DeletarProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Produto GetProdutoById(int PDT_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * from [Produto] ");
                    strGet.Append(" where PDT_Id = @PDT_Id");

                    var obj = _db.Query<Produto>(strGet.ToString(), new { PDT_Id = PDT_Id }).FirstOrDefault();

                    if (obj != null && join)
                    {
                        var _UsuarioRepo = new UsuarioRepository();
                        obj.UsuarioInsercao = _UsuarioRepo.GetUsuarioById(obj.PDT_UsuarioInsercaoId, true);
                    }

                    salvaLog(null, "", "GetProdutoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ProdutoRepository", "GetProdutoById", e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Produto> GetAllProduto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Produto] ");
                    if (fSomenteAtivos)
                        strGetAll.Append(" where PDT_FlagAtivo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    var lista = _db.Query<Produto>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _UsuarioRepo = new UsuarioRepository();
                            obj.UsuarioInsercao = _UsuarioRepo.GetUsuarioById(obj.PDT_UsuarioInsercaoId, true);
                        }
                    }
                    salvaLog(null, "", "GetAllProduto", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ProdutoRepository", "GetAllProduto", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Produto> GetAllProdutoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + "  * from [Produto] ");

                    strGetAll.Append(@" where ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PDT_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    var lista = _db.Query<Produto>(newStrGetAll.ToString(),
                        new
                        {
                            strPartial = "%" + strPartial + "%",
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _UsuarioRepo = new UsuarioRepository();
                            obj.UsuarioInsercao = _UsuarioRepo.GetUsuarioById(obj.PDT_UsuarioInsercaoId, true);
                        }
                    }
                    salvaLog(null, "", "GetAllProdutoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ProdutoRepository", "GetAllProdutoByPartial", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Produto> GetAllProdutoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" select " + (maxInstances > 0 ? "TOP (@maxInstances)" : "") + " * from [Produto] ");

                    strGetAll.Append(@" where ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" and PDT_FlagAtivo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" order by {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);

                    var lista = _db.Query<Produto>(newStrGetAll.ToString(),
                        new
                        {
                            strValorExato = strValorExato,
                            maxInstances = maxInstances
                        }).AsEnumerable();

                    if (lista != null && lista.Count() > 0 && join)
                    {
                        foreach (var obj in lista)
                        {
                            var _UsuarioRepo = new UsuarioRepository();
                            obj.UsuarioInsercao = _UsuarioRepo.GetUsuarioById(obj.PDT_UsuarioInsercaoId, true);
                        }
                    }
                    salvaLog(null, "", "GetAllProdutoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "ProdutoRepository", "GetAllProdutoByValorExato", e.InnerException.ToString(), e.Message, e.StackTrace, strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }
    }
}
