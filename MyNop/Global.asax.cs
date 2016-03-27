using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;
using System.Reflection;
using Nop.Core.Data;
using Nop.Data;
namespace MyNop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Nop.Core.Infrastructure.MyEngineContext.Initialize(false);

            

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
