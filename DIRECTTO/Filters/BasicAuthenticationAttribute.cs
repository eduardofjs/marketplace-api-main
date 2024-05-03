using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Data.Repositories;
using System.Threading;
using System.Security.Principal;
using CriptoODGT.Class;
using log4net;

namespace DIRECTTO.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    base.OnAuthorization(actionContext);
        //}
        public override bool AllowMultiple { get { return false; } }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                ///decoding authToken we get decode value in 'Username:Password' format
                var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                //spliting decodeauthToken using ':'
                var arrUserNameandPassword = decodeauthToken.Split(':');

                //at 0th postion of array we get username and at 1st we get password
                if (IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]))
                {
                    //setting current principle
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(arrUserNameandPassword[0]), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request
                 .CreateResponse(HttpStatusCode.Unauthorized);
            }

        }

        public static bool IsAuthorizedUser(string Username, string Password)
        {
            try
            {
                return true;
                UsuarioRepository _UsuarioRepository = new UsuarioRepository();
                var usuario = _UsuarioRepository.GetUsuarioLogin(Username, Cripto.EncryptString(Password, ReadString("ChaveCripto")));

                //se existe, volta usuario completo com pessoa
                if (usuario != null && usuario.USR_Id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                throw;
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