using EntVisionLibraries.Common.Data;
using EntVisionLibraries.Common.Interface;
using EntVisionLibraries.EntityFramework.Common;
using EntVisionLibraries.MicroOrmDapper.Common;
using Ninject.Modules;

namespace EntVisionLibraries.Bootsraper
{
    public class EntVisionLibraryBootsraper : NinjectModule
    {

        public override void Load()
        {
            Bind<IConnectionFactory>().To<ConnectionFactory>();

            //EntityFramework
            Bind(typeof(EntityFrameworkReadOnlyRepository<,>)).To(typeof(IReadOnlyRepository<>)).InSingletonScope();
            Bind(typeof(EntityFrameworkRepository<,>)).To(typeof(IRepository<>)).InSingletonScope();
            //MicroOrm Dapper
            Bind(typeof(MicroOrmDapperRepository<>)).To(typeof(IMicroOrmRepository<>)).InSingletonScope();
        }
    }
}
