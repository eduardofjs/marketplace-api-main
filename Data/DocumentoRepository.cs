
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
    public class DocumentoRepository : RepositoryBase, IDocumentoRepository
    {
        
        public Documento InsertDocumento(Documento objDocumento)
        {
            StringBuilder strInsert = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strInsert.Append("INSERT INTO Documento ");
                    strInsert.Append("(DOC_TipoDocumentoId, DOC_UsuarioId, DOC_Nome, DOC_PathUrl, DOC_DataCriacao, DOC_Ativo)");
                    strInsert.Append(@" VALUES (@DOC_TipoDocumentoId, @DOC_UsuarioId, @DOC_Nome, @DOC_PathUrl, GETDATE(), @DOC_Ativo);");
                    strInsert.Append("SELECT CAST(SCOPE_IDENTITY() as int)");

                    var queryInsert = _db.Query<int>(strInsert.ToString(),
                        new
                        {
                            DOC_TipoDocumentoId = objDocumento.DOC_TipoDocumentoId,
                            DOC_UsuarioId = objDocumento.DOC_UsuarioId,
                            DOC_Nome = objDocumento.DOC_Nome,
                            DOC_PathUrl = objDocumento.DOC_PathUrl,
                            DOC_Ativo = objDocumento.DOC_Ativo                            
                        });

                    if (queryInsert != null && queryInsert.First() > 0)
                        objDocumento.DOC_Id = queryInsert.First();

                    salvaLog(objDocumento.Log, "", "InsertDocumento", strInsert.ToString());
                    return objDocumento;
                }
            }
            catch (Exception e)
            {    
                salvaLogError(objDocumento.Log, "DocumentoRepository", "InsertDocumento", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strInsert.ToString());

                salvaLog(objDocumento.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return new Documento();
            }
        }


        public bool UpdateDocumento(Documento objDocumento)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append(" UPDATE Documento ");
                    strUpdate.Append(@" SET DOC_TipoDocumentoId = @DOC_TipoDocumentoId
                        , DOC_UsuarioId = @DOC_UsuarioId
                        , DOC_Nome = @DOC_Nome
                        , DOC_PathUrl = @DOC_PathUrl
                        , DOC_Ativo = @DOC_Ativo
                         where DOC_Id = @DOC_Id ");

                    _db.Execute(
                          strUpdate.ToString(),
                           new
                           {
                                DOC_TipoDocumentoId = objDocumento.DOC_TipoDocumentoId,
                                DOC_UsuarioId = objDocumento.DOC_UsuarioId,
                                DOC_Nome = objDocumento.DOC_Nome,
                                DOC_PathUrl = objDocumento.DOC_PathUrl,
                                DOC_Ativo = objDocumento.DOC_Ativo,
                            
                                DOC_Id = objDocumento.DOC_Id                            
                           });
                }
                salvaLog(objDocumento.Log, "", "UpdateDocumento", strUpdate.ToString());
                return true;

            }
            catch (Exception e)
            {   
                salvaLogError(objDocumento.Log, "DocumentoRepository", "UpdateDocumento", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                    
                salvaLog(objDocumento.Log,  e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");                
                return false;
            }
        }

        public bool AtivarDocumento(int DOC_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE Documento SET ");
                    strUpdate.Append(" DOC_Ativo = @DOC_Ativo ");
                    strUpdate.Append(" WHERE DOC_Id = @DOC_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            DOC_Ativo = 1,
                                            DOC_Id = DOC_Id
                                        });
                }
                salvaLog(null, "", "AtivarDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "DocumentoRepository", "AtivarDocumento", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public bool DeletarDocumento(int DOC_Id)
        {
            StringBuilder strUpdate = new StringBuilder();
            try
            {

                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strUpdate.Append("UPDATE Documento SET ");
                    strUpdate.Append(" DOC_Ativo = @DOC_Ativo ");
                    strUpdate.Append(" WHERE DOC_Id = @DOC_Id ");

                    _db.Execute(
                         strUpdate.ToString(),
                                        new
                                        {
                                            DOC_Ativo = 0,
                                            DOC_Id = DOC_Id
                                        });
                }
                salvaLog(null, "", "DeletarDocumento", strUpdate.ToString());
                return true;
            }
            catch (Exception e)
            {
                salvaLogError(null, "DocumentoRepository", "DeletarDocumento", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strUpdate.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return false;
            }
        }

        public Documento GetDocumentoById(int DOC_Id, bool join)
        {
            StringBuilder strGet = new StringBuilder();
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGet.Append("SELECT * FROM Documento ");
                    if(join)
                    {
                        strGet.Append(@" INNER JOIN TipoDocumento ON TDC_Id = DOC_TipoDocumentoId ");
                        strGet.Append(@" LEFT JOIN Usuario ON USR_Id = DOC_UsuarioId ");                            
                    }

                    strGet.Append(" WHERE DOC_Id = @DOC_Id");                    

                    Documento obj = null;
                    if (join)
                    {
                        obj = _db.Query<Documento, TipoDocumento, Usuario, Documento>(strGet.ToString(),
                            (objDocumento, objTipoDocumento, objUsuario) =>
                            {
                                objDocumento.TipoDocumento = objTipoDocumento;
                                objDocumento.Usuario = objUsuario;

                                return objDocumento;
                            }, new { DOC_Id = DOC_Id },
                            splitOn: "TDC_Id, USR_Id").FirstOrDefault();
                    }
                    else
                    {
                        obj = _db.Query<Documento>(strGet.ToString(), new { DOC_Id = DOC_Id }).FirstOrDefault();
                    }

                    if (obj != null)
                    {

                        if (!string.IsNullOrEmpty(obj.DOC_PathUrl))
                            obj.DOC_PathUrl = ReadString("CGL_UrlImagem") + obj.DOC_PathUrl.Replace("\\", "/");
                    }

                    salvaLog(null, "", "GetDocumentoById", strGet.ToString());
                    return obj;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "DocumentoRepository", "GetDocumentoById", e.InnerException == null ? "" : e.InnerException.ToString(), e.Message, e.StackTrace, strGet.ToString());
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

        public IEnumerable<Documento> GetAllDocumento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * FROM Documento ");
                    if(join)
                    {
                        strGetAll.Append(@" INNER JOIN TipoDocumento ON TDC_Id = DOC_TipoDocumentoId ");
                        strGetAll.Append(@" LEFT JOIN Usuario ON USR_Id = DOC_UsuarioId ");
                    }
                    if (fSomenteAtivos)
                        strGetAll.Append(" WHERE DOC_Ativo= 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {0} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), order_by);

                    
                    IEnumerable<Documento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Documento, TipoDocumento,Usuario, Documento>(newStrGetAll.ToString(),
                            (objDocumento, objTipoDocumento, objUsuario) =>
                            {
                                objDocumento.TipoDocumento = objTipoDocumento;
                                objDocumento.Usuario = objUsuario;

                                return objDocumento;
                            }, new { maxInstances = maxInstances },
                            splitOn: "TDC_Id, USR_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Documento>(newStrGetAll.ToString(), new { maxInstances = maxInstances }).AsEnumerable();
                    }

                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            if (!string.IsNullOrEmpty(item.DOC_PathUrl))
                                item.DOC_PathUrl = ReadString("CGL_UrlImagem") + item.DOC_PathUrl.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllDocumento", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "DocumentoRepository", "GetAllDocumento", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }   

        public IEnumerable<Documento> GetAllDocumentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * FROM Documento ");
                         
                    if(join)
                    {
                        strGetAll.Append(@" INNER JOIN TipoDocumento ON TDC_Id = DOC_TipoDocumentoId ");
                        strGetAll.Append(@" LEFT JOIN Usuario ON USR_Id = DOC_UsuarioId ");
                    }

                    strGetAll.Append(@" WHERE ({0} like @strPartial) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND DOC_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaPartial, order_by);

                    IEnumerable<Documento> lista = null;
                    if (join)
                    {
                        lista = _db.Query<Documento, TipoDocumento, Usuario, Documento>(newStrGetAll.ToString(),
                            (objDocumento, objTipoDocumento, objUsuario) =>
                            {
                                objDocumento.TipoDocumento = objTipoDocumento;
                                objDocumento.Usuario = objUsuario;

                                return objDocumento;
                            },
                            new
                            {
                                strPartial = "%" + strPartial + "%",
                                maxInstances = maxInstances
                            }, splitOn: "TDC_Id, CAS_Id, USR_Id").AsEnumerable();
                    }
                    else
                    {
                        lista = _db.Query<Documento>(newStrGetAll.ToString(),
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
                            if (!string.IsNullOrEmpty(item.DOC_PathUrl))
                                item.DOC_PathUrl = ReadString("CGL_UrlImagem") + item.DOC_PathUrl.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllDocumentoByPartial", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "DocumentoRepository", "GetAllDocumentoByPartial", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }


        public IEnumerable<Documento> GetAllDocumentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            StringBuilder strGetAll = new StringBuilder();
            var newStrGetAll = "";
            try
            {
                using (_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DIRECTTO"].ConnectionString))
                {
                    strGetAll.Append(@" SELECT " + (maxInstances > 0 ? "TOP (@maxInstances)" : "TOP 1000") +" * FROM Documento ");
                    
                    if(join)
                    {
                        strGetAll.Append(@" INNER JOIN TipoDocumento ON TDC_Id = DOC_TipoDocumentoId ");
                        strGetAll.Append(@" LEFT JOIN Usuario ON USR_Id = DOC_UsuarioId ");
                    }

                    strGetAll.Append(@" WHERE ({0} = @strValorExato) ");

                    if (fSomenteAtivos)
                        strGetAll.Append(" AND DOC_Ativo = 1 ");

                    if (order_by != "")
                        strGetAll.Append(" ORDER BY {1} ");

                    newStrGetAll = String.Format(strGetAll.ToString(), ColunaParaValorExato, order_by);
                    IEnumerable<Documento> lista = null;
                    if (join)
                    {
                         lista = _db.Query<Documento, TipoDocumento, Usuario, Documento>(newStrGetAll.ToString(),
                         (objDocumento, objTipoDocumento, objUsuario) =>
                         {
                             objDocumento.TipoDocumento = objTipoDocumento;
                             objDocumento.Usuario = objUsuario;

                             return objDocumento;
                            },
                            new
                            {
                                strValorExato = strValorExato,
                                maxInstances = maxInstances
                            }, splitOn: "TDC_Id, USR_Id").AsEnumerable();                      
                    }
                    else
                    {
                        lista = _db.Query<Documento>(newStrGetAll.ToString(),
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
                            if (!string.IsNullOrEmpty(item.DOC_PathUrl))
                                item.DOC_PathUrl = ReadString("CGL_UrlImagem") + item.DOC_PathUrl.Replace("\\", "/");
                        }
                    }

                    salvaLog(null, "", "GetAllDocumentoByValorExato", strGetAll.ToString() + " " + newStrGetAll);
                    return lista;
                }
            }
            catch (Exception e)
            {
                salvaLogError(null, "DocumentoRepository", "GetAllDocumentoByValorExato", e.InnerException == null ? "" :e.InnerException.ToString(), e.Message, e.StackTrace,  strGetAll.ToString() + " " + newStrGetAll);
                salvaLog(e.Message + " " + e.InnerException + "\n" + e.StackTrace + "\n" + "\n");
                return null;
            }
        }

    }
}
