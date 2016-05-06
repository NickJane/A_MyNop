using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nop.Core;
using Nop.Data;
using Nop.Services;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.WebApi;
using Nop.Core.Data;
using System.Reflection;

namespace MyApi.Infrastructure
{
    public class DependencyRegistrar: IDependencyRegistrar
    {
        public void Register(Autofac.ContainerBuilder builder, Nop.Core.Infrastructure.ITypeFinder typeFinder)
        {
            //每次依赖都使用一个新的数据库对象
            builder.Register<IDbContext>(c => new NopObjectContext()).InstancePerDependency();
            //注册工作单元
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();

            //注册泛型仓储
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();



            //注册服务
            builder.RegisterType<Nop.Services.Users.UserService>().As<Nop.Services.Users.IUserService>().InstancePerLifetimeScope();

            //apicontrollers
            builder.RegisterApiControllers(typeFinder.GetAssemblies().ToArray());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}