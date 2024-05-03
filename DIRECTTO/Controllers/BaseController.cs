using Data.Repositories;
using DIRECTTO.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using DIRECTTO.Helpers;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Threading;
using System.Text;
using log4net;

namespace DIRECTTO.Controllers
{
    [MyBasicAuthenticationFilter]    [LogActionFilter]
    public class BaseController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string urlWebAPI_Pagarme = System.Configuration.ConfigurationManager.AppSettings["urlWebAPI_Pagarme"];
        public string ID_API_Pagarme = System.Configuration.ConfigurationManager.AppSettings["API_Key_Pagarme"];
        public string CRIPTO_PAGARME = System.Configuration.ConfigurationManager.AppSettings["Criptografia_PAGARME"];

        public class ResponseJson
        {
            public string statusRetorno { get; set; }

            public string mensagem { get; set; }

            public dynamic objetoRetorno { get; set; }
            public dynamic objetoRetornoInsert { get; set; }
            public dynamic objetoID { get; set; }
            public int idGenerico { get; set; }
        }

        [Route("api/Base/EnviarImagem")]
        [HttpPost]
        public HttpResponseMessage EnviarImagem(string nome_arquivo, string nome_pasta)
        {
            try
            {
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    var httpRequest = HttpContext.Current.Request;

                    foreach (string file in httpRequest.Files)
                    {
                        var filePath = "";
                        var filePathGravacao = "";
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                        var postedFile = httpRequest.Files[file];
                        if (postedFile != null && postedFile.ContentLength > 0)
                        {
                            int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB

                            IList<string> AllowedFileExtensions = new List<string> { ".jpeg", ".jpg", ".png" };
                            var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                            var extension = ext.ToLower();
                            if (!AllowedFileExtensions.Contains(extension))
                            {
                                var message = string.Format("Por favor, envie uma imagem do tipo jpg ou .png.");

                                dict.Add("error", message);
                                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                            }
                            else if (postedFile.ContentLength > MaxContentLength)
                            {
                                var message = string.Format("Por favor, envie uma imagem de no máximo 5 mb.");

                                dict.Add("error", message);
                                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                            }
                            else
                            {
                                if (!File.Exists(RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\"))
                                {
                                    Directory.CreateDirectory(RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\");
                                }
                                Bitmap bmp = new Bitmap(postedFile.InputStream);
                                //filePath = RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\" + nome_arquivo + extension;
                                //filePathGravacao = "\\" + nome_pasta + "\\" + nome_arquivo + extension;

                                filePath = RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\" + nome_arquivo;
                                filePathGravacao = "\\" + nome_pasta + "\\" + nome_arquivo;

                                bmp.Save(filePath);
                            }
                        }

                        Dictionary<string, string> lista = new Dictionary<string, string>();
                        lista.Add("mensagem", "Imagem salva com sucesso.");
                        //lista.Add("path", filePath);
                        lista.Add("path", filePathGravacao);

                        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                        return Request.CreateResponse(HttpStatusCode.Created, lista);
                        //return true;
                    }
                    var res = string.Format("Por favor, envie uma imagem.");
                    dict.Add("error", res);
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, res);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Algo aconteceu");

            }
            catch (Exception e)
            {
                log.Error("Error", e);
                throw;
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Algo aconteceu");
        }

        [Route("api/Base/EnviarPDF")]
        [HttpPost]
        public HttpResponseMessage EnviarPDF(string nome_arquivo, string nome_pasta)
        {
            try
            {
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    var httpRequest = HttpContext.Current.Request;

                    foreach (string file in httpRequest.Files)
                    {
                        var filePath = "";
                        var filePathGravacao = "";
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                        var postedFile = httpRequest.Files[file];
                        if (postedFile != null && postedFile.ContentLength > 0)
                        {
                            int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB

                            IList<string> AllowedFileExtensions = new List<string> { ".pdf" };
                            var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                            var extension = ext.ToLower();
                            if (!AllowedFileExtensions.Contains(extension))
                            {
                                var message = string.Format("Por favor, envie um arquivo do tipo .pdf");

                                dict.Add("error", message);
                                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                            }
                            else if (postedFile.ContentLength > MaxContentLength)
                            {
                                var message = string.Format("Por favor, envie um pdf de no máximo 5 mb.");

                                dict.Add("error", message);
                                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                            }
                            else
                            {
                                if (!File.Exists(RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\"))
                                {
                                    Directory.CreateDirectory(RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\");
                                }
                                //Bitmap bmp = new Bitmap(postedFile.InputStream);
                                filePath = RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\" + nome_arquivo + "_" + DateTime.Now.ToString("yyyyMMddHHmm") + extension;
                                filePathGravacao = "\\" + nome_pasta + "\\" + nome_arquivo + "_" + DateTime.Now.ToString("yyyyMMddHHmm") + extension;
                                //bmp.Save(filePath);
                                System.IO.File.WriteAllBytes(filePath, ReadData(postedFile.InputStream));
                            }
                        }

                        Dictionary<string, string> lista = new Dictionary<string, string>();
                        lista.Add("mensagem", "PDF salvo com sucesso.");
                        //lista.Add("path", filePath);
                        lista.Add("path", filePathGravacao);

                        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                        return Request.CreateResponse(HttpStatusCode.Created, lista);
                        //return true;
                    }
                    var res = string.Format("Por favor, envie um pdf.");
                    dict.Add("error", res);
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, res);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Algo aconteceu");

            }
            catch (Exception e)
            {
                log.Error("Error", e);
                throw;
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Algo aconteceu");
        }

        [Route("api/Base/EnviarVideo")]
        [HttpPost]
        public HttpResponseMessage EnviarVideo(string nome_arquivo, string nome_pasta)
        {
            try
            {
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    var httpRequest = HttpContext.Current.Request;

                    foreach (string file in httpRequest.Files)
                    {
                        var filePath = "";
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                        var postedFile = httpRequest.Files[file];
                        if (postedFile != null && postedFile.ContentLength > 0)
                        {
                            int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB

                            IList<string> AllowedFileExtensions = new List<string> { ".mp4" };
                            var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                            var extension = ext.ToLower();
                            if (!AllowedFileExtensions.Contains(extension))
                            {
                                var message = string.Format("Por favor, envie um arquivo do tipo .mp4");

                                dict.Add("error", message);
                                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                            }
                            //else if (postedFile.ContentLength > MaxContentLength)
                            //{
                            //    var message = string.Format("Por favor, envie um mp4 de no máximo 5 mb.");
                            //
                            //    dict.Add("error", message);
                            //    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                            //}
                            else
                            {
                                if (!File.Exists(RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\"))
                                {
                                    Directory.CreateDirectory(RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\");
                                }
                                //Bitmap bmp = new Bitmap(postedFile.InputStream);
                                filePath = RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\" + nome_arquivo + "_" + DateTime.Now.ToString("yyyyMMddHHmm") + extension;
                                //bmp.Save(filePath);
                                System.IO.File.WriteAllBytes(filePath, ReadData(postedFile.InputStream));
                            }
                        }

                        Dictionary<string, string> lista = new Dictionary<string, string>();
                        lista.Add("mensagem", "video salvo com sucesso.");
                        lista.Add("path", filePath);

                        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                        return Request.CreateResponse(HttpStatusCode.Created, lista);
                        //return true;
                    }
                    var res = string.Format("Por favor, envie um video com extensão mp4.");
                    dict.Add("error", res);
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, res);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Algo aconteceu");

            }
            catch (Exception e)
            {
                log.Error("Error", e);
                throw;
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Algo aconteceu");
        }

        [Route("api/Base/EnviarHTML")]
        [HttpPost]
        public HttpResponseMessage EnviarHTML(string nome_arquivo, string nome_pasta)
        {
            try
            {
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    var httpRequest = HttpContext.Current.Request;

                    foreach (string file in httpRequest.Files)
                    {
                        var filePath = "";
                        var filePathGravacao = "";
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                        var postedFile = httpRequest.Files[file];
                        if (postedFile != null && postedFile.ContentLength > 0)
                        {
                            int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB

                            IList<string> AllowedFileExtensions = new List<string> { ".html" };
                            var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                            var extension = ext.ToLower();
                            if (!AllowedFileExtensions.Contains(extension))
                            {
                                var message = string.Format("Por favor, envie um arquivo do tipo .html");

                                dict.Add("error", message);
                                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                            }
                            else if (postedFile.ContentLength > MaxContentLength)
                            {
                                var message = string.Format("Por favor, envie um html de no máximo 5 mb.");

                                dict.Add("error", message);
                                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                            }
                            else
                            {
                                if (!File.Exists(RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\"))
                                {
                                    Directory.CreateDirectory(RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\");
                                }
                                //Bitmap bmp = new Bitmap(postedFile.InputStream);
                                filePath = RepositoryBase.ReadString("CGL_PathImagem") + "\\" + nome_pasta + "\\" + nome_arquivo + "_" + DateTime.Now.ToString("yyyyMMddHHmm") + extension;
                                filePathGravacao = "\\" + nome_pasta + "\\" + nome_arquivo + "_" + DateTime.Now.ToString("yyyyMMddHHmm") + extension;
                                //bmp.Save(filePath);
                                System.IO.File.WriteAllBytes(filePath, ReadData(postedFile.InputStream));
                            }
                        }

                        Dictionary<string, string> lista = new Dictionary<string, string>();
                        lista.Add("mensagem", "HTML salvo com sucesso.");
                        //lista.Add("path", filePath);
                        lista.Add("path", filePathGravacao);

                        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                        return Request.CreateResponse(HttpStatusCode.Created, lista);
                        //return true;
                    }
                    var res = string.Format("Por favor, envie um HTML.");
                    dict.Add("error", res);
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, res);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Algo aconteceu");

            }
            catch (Exception e)
            {
                log.Error("Error", e);
                throw;
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Algo aconteceu");
        }
        private byte[] ReadData(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];

            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        public static string RemoveNaoNumericos(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return text;
            }
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }

        public async Task<IRestResponse> pagarme_PostObjectRestAsync<T>(string ComplementoUrl, object objetoPut)
        {
            var client = new RestClient(urlWebAPI_Pagarme + ComplementoUrl);

            var request = new RestRequest(Method.POST);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json; charset=utf-8");
            //request.AddHeader("Authorization", "Basic " + AUTH_Pagarme);
            //request.AddHeader("Authorization", "Basic " + ID_API_Pagarme);
            string UserName = ID_API_Pagarme;
            string Password = "";            
            var byteArray = Encoding.UTF8.GetBytes($"{UserName}:{Password}");
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("application/json", JsonConvert.SerializeObject(objetoPut), ParameterType.RequestBody);
            
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            EventWaitHandle executedCallBack = new AutoResetEvent(false);
            TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();
            IRestResponse res = new RestResponse();

            client.ExecuteAsync<RestResponse>(request, response =>
            {
                res = response;
                tcs.TrySetResult(res);
                executedCallBack.Set();
            });

            return await tcs.Task;


        }

        public async Task<IRestResponse> Pagarme_PostObjectRestAsync<T>(string ComplementoUrl, object objetoPut)
        {
            var client = new RestClient(urlWebAPI_Pagarme + ComplementoUrl);

            var request = new RestRequest(Method.POST);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");
            //request.AddHeader("authorization", "Basic " + ID_API_Pagarme);
            string UserName = ID_API_Pagarme;
            string Password = "";
            var byteArray = Encoding.UTF8.GetBytes($"{UserName}:{Password}");
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));
            request.RequestFormat = DataFormat.Json;

            request.AddBody((T)objetoPut);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            EventWaitHandle executedCallBack = new AutoResetEvent(false);
            TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();
            IRestResponse res = new RestResponse();

            client.ExecuteAsync<RestResponse>(request, response =>
            {
                res = response;
                tcs.TrySetResult(res);
                executedCallBack.Set();
            });

            return await tcs.Task;


        }
        public async Task<IRestResponse> Pagarme_GetObjectRestAsync<T>(string ComplementoUrl, object objetoPut)
        {
            var client = new RestClient(urlWebAPI_Pagarme + ComplementoUrl);

            var request = new RestRequest(Method.GET);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");
            //request.AddHeader("authorization", "Basic " + ID_API_Pagarme);
            string UserName = ID_API_Pagarme;
            string Password = "";
            var byteArray = Encoding.UTF8.GetBytes($"{UserName}:{Password}");
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));
            request.RequestFormat = DataFormat.Json;

            request.AddBody((T)objetoPut);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            EventWaitHandle executedCallBack = new AutoResetEvent(false);
            TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();
            IRestResponse res = new RestResponse();

            client.ExecuteAsync<RestResponse>(request, response =>
            {
                res = response;
                tcs.TrySetResult(res);
                executedCallBack.Set();
            });

            return await tcs.Task;


        }
        public async Task<IRestResponse> Pagarme_GetObjectRestAsync<T>(string ComplementoUrl)
        {
            var client = new RestClient(urlWebAPI_Pagarme + ComplementoUrl);

            var request = new RestRequest(Method.GET);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");
            //request.AddHeader("authorization", "Basic " + ID_API_Pagarme);
            string UserName = ID_API_Pagarme;
            string Password = "";
            var byteArray = Encoding.UTF8.GetBytes($"{UserName}:{Password}");
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));
            request.RequestFormat = DataFormat.Json;

            //request.AddBody((T)objetoPut);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            EventWaitHandle executedCallBack = new AutoResetEvent(false);
            TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();
            IRestResponse res = new RestResponse();

            client.ExecuteAsync<RestResponse>(request, response =>
            {
                res = response;
                tcs.TrySetResult(res);
                executedCallBack.Set();
            });

            return await tcs.Task;


        }
        public async Task<IRestResponse> Pagarme_DeleteObjectRestAsync<T>(string ComplementoUrl)
        {
            var client = new RestClient(urlWebAPI_Pagarme + ComplementoUrl);

            var request = new RestRequest(Method.DELETE);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");
            //request.AddHeader("authorization", "Basic " + ID_API_Pagarme);
            string UserName = ID_API_Pagarme;
            string Password = "";
            var byteArray = Encoding.UTF8.GetBytes($"{UserName}:{Password}");
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));
            request.RequestFormat = DataFormat.Json;

            //request.AddBody((T)objetoPut);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            EventWaitHandle executedCallBack = new AutoResetEvent(false);
            TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();
            IRestResponse res = new RestResponse();

            client.ExecuteAsync<RestResponse>(request, response =>
            {
                res = response;
                tcs.TrySetResult(res);
                executedCallBack.Set();
            });

            return await tcs.Task;


        }
    }
}

