using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace JX
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (null == authCookie)
            {
                return;
            }
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            if (null == authTicket)
            {
                //could not decrypt cookie
                return;
            }
            //get the role
            string[] roles = authTicket.UserData.Split(new[] { ',' });
            var id = new FormsIdentity(authTicket);
            Context.User = new GenericPrincipal(id, roles);
        }
    }
}
