
using DIRECTTO;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace DIRECTTO
{
    public class SwaggerConfig
    {
        public static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\Swagger.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.ApiKey("apiKey")
                     .Description("API Key Authentication")
                     .Name("X-ApiKey")
                     .In("header");

                    c.SingleApiVersion("v1", "DIRECTTO");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .EnableSwaggerUi(c =>
                {

                });

        }
    }
}
