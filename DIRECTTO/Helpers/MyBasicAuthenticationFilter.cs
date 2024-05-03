using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace DIRECTTO.Helpers
{
    public class MyBasicAuthenticationFilter : BasicAuthenticationFilter
    {

        public MyBasicAuthenticationFilter()
        { }

        public MyBasicAuthenticationFilter(bool active)
            : base(active)
        { }


        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            //Authorization:Basic  
            if (username == "AccessDirecttoDevAPI" && password == "rt89723hkjbsdfjhwer928374jbsnfmjhwgjhwg")
                return true;

            return false;
        }
    }
}