
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using Autofac.Core.Lifetime;
using Nop.Core.Infrastructure.DependencyManagement;
namespace Nop.Core.Infrastructure
{
    public class MyNopEngine
    {
        private IContainer container;
        public MyNopEngine() { 
            
        }

        public void Initialize()
        {
            var builder = new ContainerBuilder();

            var typeFinder = new WebAppTypeFinder(); //containerManager.Resolve<ITypeFinder>();
            Action<ContainerBuilder> action = (x =>
            {
                var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
                var drInstances = new List<IDependencyRegistrar>();
                foreach (var drType in drTypes)
                    drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
                //sort
                drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
                foreach (var dependencyRegistrar in drInstances)
                    dependencyRegistrar.Register(x, typeFinder);
            });
            action.Invoke(builder);

            
            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        public T Resolve<T>() where T : class
        {

            return container.Resolve<T>();
        }
    }
}
