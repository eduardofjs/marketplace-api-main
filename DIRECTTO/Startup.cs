using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DIRECTTO.Startup))]

namespace DIRECTTO
{
    public partial class Startup
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            log.Info("Marketplace Api Started!");
        }
    }
}
