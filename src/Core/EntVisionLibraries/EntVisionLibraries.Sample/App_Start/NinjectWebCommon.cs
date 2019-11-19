[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EntVisionLibraries.Sample.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EntVisionLibraries.Sample.App_Start.NinjectWebCommon), "Stop")]

namespace EntVisionLibraries.Sample.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using EntVisionLibraries.Bootsraper;
    using EntVisionLibraries.Common.Data;
    using EntVisionLibraries.Common.Interface;
    using EntVisionLibraries.EntityFramework.Common;
    using EntVisionLibraries.MicroOrmDapper.Common;
    using EntVisionLibraries.Sample.Models;
    using EntVisionLibraries.Sample.Repositories;
    using EntVisionLibraries.Sample.Repositories.Interface;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //Register Library
                kernel.Bind<EntVisionLibraryBootsraper>().ToSelf();

                RegisterServices(kernel);

                // Install our Ninject-based IDependencyResolver into the Web API config
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind<SmartLogisticContext>()
             .ToSelf()
             .InRequestScope();

            kernel.Bind<IMapsRepository>().To<MapsRepository>();
        }        
    }
}
