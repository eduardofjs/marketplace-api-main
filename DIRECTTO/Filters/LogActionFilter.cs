using Data.Repositories;
using Domain.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Script.Serialization;

namespace DIRECTTO.Filters
{
    public class LogActionFilter : ActionFilterAttribute//, IActionFilter
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override bool AllowMultiple { get { return false; } }
                
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            try
            {
                List<Log> lista = new List<Log>();
                StringBuilder str = new StringBuilder();
                StringBuilder value = new StringBuilder();
                Log log = new Log();
                var method = filterContext.Request.RequestUri.AbsolutePath;
                var parameters = filterContext.ActionArguments.ToList();

                RepositoryBase.salvaLog("DIRECTTO DEBUG - > " + method);

                RepositoryBase.salvaLog("DIRECTTO DEBUG - > " + parameters.Count());

              

                if (parameters.Count > 1)
                {
                    if (method.ToLower().Contains("/login") && parameters.First(x => x.Key.Equals("senha")).Key != null)
                    {
                        parameters.RemoveAll(x => x.Key.Equals("senha"));
                    }
                    else
                    {
                        if (parameters.Where(x => x.Key.Equals("Log")) != null && parameters.First(x => x.Key.Equals("Log")).Key != null)
                        {
                            log = (Log)parameters.First(x => x.Key.Equals("Log")).Value;
                            parameters.RemoveAll(x => x.Key.Equals("Log"));
                        }
                    }
                }
                else if (parameters.Count == 1 && parameters[0].Value.GetType().ToString() == "Log")
                {
                    log = parameters[0].Value as Log;
                }

                //if (parameters != null && parameters.Count() > 0)
                //{
                //    var tipo = parameters[0].Value.GetType().ToString();
                //    log.LOG_ParametroJson = new JavaScriptSerializer().Serialize(parameters);
                //    log.LOG_Metodo = method;

                //    LogRepository _LogRepository = new LogRepository();
                //    Log logRetorno = _LogRepository.InsertLog(log);

                //    if(logRetorno != null)
                //        log.LOG_Id = logRetorno.LOG_Id;

                //}

                //Livia agora é com vc precisa colocar esse id de volta no filterContext para o id do Log chegar na repository, pois precisamos gravar a query dessa transação.
            }
            catch (Exception e)
            {
                log.Error("Error", e);
            }

            //this.OnActionExecuting(filterContext);
            //base.OnActionExecuting(filterContext);
        }

    }
}