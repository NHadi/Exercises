[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SmartLogistic.WebServices.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SmartLogistic.WebServices.Api.App_Start.NinjectWebCommon), "Stop")]


namespace SmartLogistic.WebServices.Api.App_Start
{
    using EntVisionLibraries.Bootsraper;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using SmartLogistic.Domain.MapAggregate.Interfaces;
    using SmartLogistic.Domain.MapAggregate.Services;
    using SmartLogistic.Domain.TransportRequestAggregate.Intefaces;
    using SmartLogistic.Domain.TransportRequestAggregate.Services;
    using SmartLogistic.Infrastructure.Data;
    using SmartLogistic.Infrastructure.Data.Repositories;
    using System;
    using System.Web;
    using System.Web.Http;



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

                //////Register Bootsraper
                //kernel.Bind<AppBootsraper>().ToSelf();

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
            //RegisterLibrary
            kernel.Bind<EntVisionLibraryBootsraper>().ToSelf();

            kernel.Bind<SmartLogisticContext>()
             .ToSelf()
             .InRequestScope();

            kernel.Bind<IMapRepository>().To<MapRepository>();
            kernel.Bind<ITransportRequestRepository>().To<TransportRequestRepository>();

            kernel.Bind<ITransportManagementService>().To<TransportManagementService>();
            kernel.Bind<IMapManagementService>().To<MapManagementService>();
            
        }
    }
}