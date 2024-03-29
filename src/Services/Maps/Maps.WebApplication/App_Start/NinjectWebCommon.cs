﻿[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Maps.WebApplication.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Maps.WebApplication.App_Start.NinjectWebCommon), "Stop")]

namespace Maps.WebApplication.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using EntVisionLibraries.Bootsraper;
    using Maps.Domain.DeliveryAggregate.Interface;
    using Maps.Domain.MapsAggregate.Interface;
    using Maps.Domain.MapsAggregate.Interfaces;
    using Maps.Domain.WarehouseAggregate;
    using Maps.Domain.WarehouseAggregate.Interface;
    using Maps.Infrastructure.Data;
    using Maps.Infrastructure.Data.Repositories;
    using Maps.WebApplication.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Warehouses.Infrastructure.Data.Repositories;

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

            kernel.Bind<MapContext>()
             .ToSelf()
             .InRequestScope();

            kernel.Bind<IMapRepository>().To<MapRepository>();
            kernel.Bind<IWarehouseRepository>().To<WarehouseRepository>();
            kernel.Bind<IDeliveryRepository>().To<DeliveryRepository>();

            kernel.Bind<IMapService>().To<MapService>();
            kernel.Bind<IWarehouseService>().To<WarehouseService>();
            kernel.Bind<IDeliveryService>().To<DeliveryService>();
        }
    }
}
