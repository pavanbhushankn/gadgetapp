using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Sample.WebApi.App_Start;
using System.Data.Entity;
using Sample.Data;
namespace Sample.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;
        protected void Application_Start()
        {
            ConfigureWindsor(GlobalConfiguration.Configuration);
         
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(_container);
            configuration.DependencyResolver = dependencyResolver;
        }

        protected void Application_End()
        {
            _container.Dispose();
            base.Dispose();
        }
    }
}
