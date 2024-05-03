using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Swagger.Net;

//[assembly: WebActivator.PreApplicationStartMethod(typeof(DIRECTTO.App_Start.SwaggerNet), "PreStart")]
//[assembly: WebActivator.PostApplicationStartMethod(typeof(DIRECTTO.App_Start.SwaggerNet), "PostStart")]
namespace DIRECTTO.App_Start
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class SwaggerNet
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        public static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\Swagger.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
        public static void PreStart() 
        {
            RouteTable.Routes.MapHttpRoute(
                name: "SwaggerApi",
                routeTemplate: "api/docs/{controller}",
                defaults: new { swagger = true }
            );            
        }
        
        public static void PostStart() 
        {
            var config = GlobalConfiguration.Configuration;

            config.Filters.Add(new SwaggerActionFilter());
            
            try
            {
                config.Services.Replace(typeof(IDocumentationProvider),
                   new XmlCommentDocumentationProvider(GetXmlCommentsPath()));
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Please enable \"XML documentation file\" in project properties with default (bin\\DIRECTTO.XML) value or edit value in App_Start\\SwaggerNet.cs");
            }
        }
    }
}