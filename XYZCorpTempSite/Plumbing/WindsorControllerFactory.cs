using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace XYZCorpTempSite.Plumbing
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;
        private IKernel Kernel { get { return _kernel; } }

        public WindsorControllerFactory(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }
            _kernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, 
                    string.Format("The controller for path {0} could not be found", 
                    requestContext.HttpContext.Request.Path));
            }

            return (IController) Kernel.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            Kernel.ReleaseComponent(controller);
        }
    }
}