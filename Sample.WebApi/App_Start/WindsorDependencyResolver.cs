using System.Web.Http.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core;
using Castle.MicroKernel.Context;
using Castle.Windsor;

namespace Sample.WebApi.App_Start
{
    internal sealed class WindsorDependencyResolver : IDependencyResolver
    {

        private readonly IWindsorContainer container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container==null)
            {
                throw new ArgumentException(nameof(container));
                
            }

            this.container = container;
        }


        public object GetService(Type t)
        {
            return this.container.Kernel.HasComponent(t) ? this.container.Resolve(t) : null;
        }


        public IEnumerable<object> GetServices(Type T)
        {
            return this.container.ResolveAll(T).Cast<object>().ToArray();
        }


        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this.container);
        }

        public void Dispose()
        {
            this.container?.Dispose();
        }

     
    }
}