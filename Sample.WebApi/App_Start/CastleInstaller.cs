using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Sample.Data.Repository.Base.Interface;
using Sample.Data;
using Sample.Data.Repository.Base;
using Sample.Service.Base.Interface;

namespace Sample.WebApi.App_Start
{
    public class CastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IContextProvider<ProductDbContext>>()
                .ImplementedBy<ContextProvider<ProductDbContext>>()
                .LifestylePerWebRequest()
                
                );

            container.Register(
                Component.For<ProductDbContext>()
                .ImplementedBy<ProductDbContext>()
                .LifestylePerWebRequest()
                );


            container.Register(
               Classes.FromAssemblyNamed("Sample.Data")
               .BasedOn<IRepository>()
                .WithServiceDefaultInterfaces()
             .LifestylePerWebRequest()
               );

            container.Register(
              Classes.FromAssemblyNamed("Sample.Service")
              .BasedOn<IService>()
               .WithServiceDefaultInterfaces()
             .LifestylePerWebRequest()

              );
            container.Register(
                Classes.FromAssemblyNamed("Sample.Model")
                .Pick()
                .Configure(r=> r.LifestylePerWebRequest())
                
                );

            container.Register(
              Classes.FromThisAssembly()
              .Pick()
              .Configure(r => r.LifestylePerWebRequest())

              );

        }
    }
}