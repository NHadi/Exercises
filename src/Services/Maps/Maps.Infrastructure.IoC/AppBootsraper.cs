using EntVisionLibraries.Bootsraper;
using Maps.Domain.DeliveryAggregate.Interface;
using Maps.Domain.MapsAggregate.Interface;
using Maps.Domain.MapsAggregate.Interfaces;
using Maps.Domain.WarehouseAggregate;
using Maps.Domain.WarehouseAggregate.Interface;
using Maps.Infrastructure.Data;
using Maps.Infrastructure.Data.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;
using Warehouses.Infrastructure.Data.Repositories;

namespace Maps.Infrastructure.IoC
{
    public class AppBootsraper : NinjectModule
    {

        public override void Load()
        {
            //RegisterLibrary
            Bind<EntVisionLibraryBootsraper>().ToSelf();

            Bind<MapContext>()
             .ToSelf()
             .InRequestScope();

            Bind<IMapRepository>().To<MapRepository>();
            Bind<IWarehouseRepository>().To<WarehouseRepository>();
            Bind<IDeliveryRepository>().To<DeliveryRepository>();            
        }
    }
    
}
