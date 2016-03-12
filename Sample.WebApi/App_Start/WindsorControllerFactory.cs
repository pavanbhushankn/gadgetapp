using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sample.WebApi.App_Start
{
    public class WindsorControllerFactory: DefaultControllerFactory
    {

        private readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            if (container==null)
            {
                throw new ArgumentException(nameof(container)); 
            }
            this.container = container;
        }


        public override void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            disposable?.Dispose();
            this.container.Release(controller);
        }


      protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            if (controllerType ==null)
            {
                throw new HttpException(404, $"The controller for path '{context.HttpContext.Request.Path}' could not be found or it does not implement IController.");

            }
            return this.container.Resolve(controllerType) as IController;
        }
    }
}