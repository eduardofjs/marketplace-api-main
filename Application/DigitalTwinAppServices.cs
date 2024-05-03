
using Application.Interfaces;
using Application.Handlers;
using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using log4net;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Application
{
    public class DigitalTwinAppServices : IDigitalTwinAppServices
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public readonly HttpClient _HttpClient;
        public readonly string _UrlDigitalTwin;
        public readonly string _TokenDigitalTwin;

        public DigitalTwinAppServices()
        {
            //_HttpClient = new HttpClient(new AppHttpHandler( new HttpClientHandler()));
            // https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/httpclient-message-handlers
            _HttpClient = HttpClientFactory.Create(new AppHttpHandler());

            // Ler os parametros de url e token
            _UrlDigitalTwin = ReadString("UrlDigitalTwin");
            _TokenDigitalTwin = ReadString("TokenDigitalTwin");
        }

        public async Task<String> Login()
        {
            try
            {
                log.Debug("Iniciando login");

                // Ler user e pass
                DigitalTwinLoginDto login = new DigitalTwinLoginDto(
                    ReadString("UserDigitalTwin"), ReadString("PasswordDigitalTwin"));

                log.Debug("login" + login);


                // Definir o body
                var requestContent = new StringContent(
                   JsonSerializer.Serialize(login),
                   Encoding.UTF8,
                   "application/json"
                );

                log.Debug("requestContent" + requestContent);

                using (var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, _UrlDigitalTwin + "/login"))
                {
                    // Setar o conteudo da request e o header
                    requestMessage.Content = requestContent;
                    requestMessage.Headers.Add("Authorization", "Bearer " + _TokenDigitalTwin);

                    // Enviar e ler o response token
                    var response = await _HttpClient.SendAsync(requestMessage).ConfigureAwait(false);
                    var contents = await response.Content.ReadAsStringAsync();
                    DigitalTwinLoginResponseDto responseDto = JsonSerializer.Deserialize<DigitalTwinLoginResponseDto>(contents);
                    log.Debug("responseDto" + responseDto);
                    return responseDto.AccessToken;
                }
            }
            catch(Exception e)
            {
                log.Error("Error", e);
                return null;
            }
            
        }

        public async void InsertProduct(DigitalTwinProductDto Product, string AccessToken = null)
        {
            try
            {
                log.Debug("Inserindo product na CERTI");

                // Gerar um token se nao vier
                var innerAccessToken = AccessToken;
                if (AccessToken == null)
                {
                    innerAccessToken = await Login().ConfigureAwait(false);
                }

                log.Debug("innerAccessToken: " + innerAccessToken);

                // Definir o body
                var requestContent = new StringContent(
                    JsonSerializer.Serialize(Product),
                    Encoding.UTF8,
                    "application/json"
                );

                log.Debug("requestContent: " + requestContent);

                using (var requestMessage =
                    new HttpRequestMessage(HttpMethod.Post, _UrlDigitalTwin + "/products"))
                {
                    // Setar o conteudo da request e o header
                    requestMessage.Content = requestContent;
                    requestMessage.Headers.Add("Authorization", "Bearer " + innerAccessToken);

                    // Enviar e ler o response token
                    await _HttpClient.SendAsync(requestMessage).ConfigureAwait(false);
                }
            }
            catch(Exception e)
            {
                log.Error("Error", e);
            }
            
        }

        public async void UpdateProduct(DigitalTwinProductDto Product, string AccessToken)
        {
            try
            {
                log.Debug("Atualizando product na CERTI");

                // Gerar um token se nao vier
                var innerAccessToken = AccessToken;
                if (AccessToken == null)
                {
                    innerAccessToken = await Login().ConfigureAwait(false);
                }

                log.Debug("innerAccessToken: " + innerAccessToken);

                // Definir o body
                var requestContent = new StringContent(
                   JsonSerializer.Serialize(Product),
                   Encoding.UTF8,
                   "application/json"
                );

                log.Debug("requestContent: " + requestContent);

                using (var requestMessage =
                  new HttpRequestMessage(HttpMethod.Put, _UrlDigitalTwin + string.Format("/products/external/{0}", Product.ExternalId)))
                {
                    // Setar o conteudo da request e o header
                    requestMessage.Content = requestContent;
                    requestMessage.Headers.Add("Authorization", "Bearer " + innerAccessToken);

                    // Enviar e ler o response token
                    await _HttpClient.SendAsync(requestMessage).ConfigureAwait(false);
                }

            }
            catch (Exception e)
            {
                log.Error("Error", e);
            }


        }

        public async void InsertCompany(DigitalTwinCompanyDto Company, string AccessToken = null)
        {
            try
            {
                log.Debug("Inserindo company na CERTI");

                // Gerar um token se nao vier
                var innerAccessToken = AccessToken;
                if (AccessToken == null)
                {
                    innerAccessToken = await Login().ConfigureAwait(false);
                }

                log.Debug("innerAccessToken: " + innerAccessToken);

                // Serializar o body
                var jsonOptions = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };
                log.Debug("jsonOptions: " + jsonOptions);

                var jsonBody = JsonSerializer.Serialize(Company, jsonOptions);
                log.Debug("jsonBody: " + jsonBody);

                var requestContent = new StringContent(
                   jsonBody,
                   Encoding.UTF8,
                   "application/json"
                );

                log.Debug("requestContent: " + requestContent);

                using (var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, _UrlDigitalTwin + "/companies"))
                {
                    // Setar o conteudo da request e o header
                    requestMessage.Content = requestContent;
                    //requestMessage.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    requestMessage.Headers.Add("Authorization", "Bearer " + innerAccessToken);
                
                    // Enviar e ler o response token
                    await _HttpClient.SendAsync(requestMessage).ConfigureAwait(false);
                }


            }
            catch (Exception e)
            {
                log.Error("Error", e);
            }     

        }

        

        public async void UpdateCompany(DigitalTwinCompanyDto Company, string AccessToken)
        {

            try
            {
                log.Debug("Atualizando company na CERTI");

                // Gerar um token se nao vier
                var innerAccessToken = AccessToken;
                if (AccessToken == null)
                {
                    innerAccessToken = await Login().ConfigureAwait(false);
                }

                log.Debug("innerAccessToken: " + innerAccessToken);

                // Definir o body
                var requestContent = new StringContent(
                   JsonSerializer.Serialize(Company),
                   Encoding.UTF8,
                   "application/json"
                );

                log.Debug("requestContent: " + requestContent);

                using (var requestMessage =
                new HttpRequestMessage(HttpMethod.Put, _UrlDigitalTwin + string.Format("/companies/external/{0}", Company.ExternalId)))
                {
                    // Setar o conteudo da request e o header
                    requestMessage.Content = requestContent;
                    requestMessage.Headers.Add("Authorization", "Bearer " + innerAccessToken);

                    // Enviar e ler o response token
                    await _HttpClient.SendAsync(requestMessage).ConfigureAwait(false);
                }

            }
            catch (Exception e)
            {
                log.Error("Error", e);
            }
           
        }

        public static string ReadString(string key)
        {
            try
            {
                System.Configuration.AppSettingsReader rd = new System.Configuration.AppSettingsReader();
                return rd.GetValue(key, typeof(String)).ToString();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

    }
}

