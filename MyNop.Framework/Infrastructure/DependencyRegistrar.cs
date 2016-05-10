using Autofac;
using Autofac.Builder;
//mvc和api混合的应用程序, 需要同时引用两个dll
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Nop.Core.Data;
using Nop.Core.Fakes;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyNop.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //SetupResolveRules
            //SetupResolveRules(builder);
            
            
            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

            //每次依赖都使用一个新的数据库对象
            builder.Register<IDbContext>(c => new NopObjectContext()).InstancePerDependency();
            //注册工作单元
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();

            //注册泛型仓储
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            

            //注册服务
            builder.RegisterType<Nop.Services.Users.UserService>() .As<Nop.Services.Users.IUserService>().InstancePerLifetimeScope();

            builder.RegisterApiControllers(typeFinder.GetAssemblies().ToArray());
            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
            
        }

        /// <summary>
        /// 给某个dll注入的规则例子
        /// </summary>
        /// <param name="builder"></param>
        private static void SetupResolveRules(ContainerBuilder builder)
        {

            var assembly = Assembly.Load("s2s.BLL");   //根据程序集名称加载程序集
            builder.RegisterAssemblyTypes(assembly).SingleInstance();//每次都返回同一个实例
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();

        }


        public int Order
        {
            get { return 0; }
        }
    }
}
