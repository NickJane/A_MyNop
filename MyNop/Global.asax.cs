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
using System.Web.Http;
namespace MyNop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);//webapi必须在mvc路由之前注册. 我艹
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            
            Nop.Core.Infrastructure.MyEngineContext.Initialize(false);

            
        }
    }
}
