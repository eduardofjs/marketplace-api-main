﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using log4net;

namespace DIRECTTO.Handlers
{
    public class ControllerHttpHandler : DelegatingHandler
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var corrId = Guid.NewGuid();
            var requestMethod = request.Method.Method.ToString();
            var requestUri = request.RequestUri.ToString();
            //var ipAddress = request.GetOwinContext().Request.RemoteIpAddress;

            var requestMessage = await request.Content.ReadAsStringAsync();
            //await LogMessageAsync(corrId, requestUri, ipAddress, "Request", requestMethod, request.Headers.ToString(), requestMessage, string.Empty);
            log.Debug($"Request - corrId: {corrId}, requestUri: {requestUri}, requestMessage: {requestMessage}");

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var responseMessage = await response.Content.ReadAsStringAsync();
            //await LogMessageAsync(corrId, requestUri, ipAddress, "Response", requestMethod, response.Headers.ToString(), responseMessage, ((int)response.StatusCode).ToString() + "-" + response.ReasonPhrase);
            log.Debug($"Response - corrId: {corrId}, requestUri: {requestUri}, responseMessage: {responseMessage}, responseStatus: { ((int)response.StatusCode).ToString() }");
            
            return response;
        }

    }

    
}