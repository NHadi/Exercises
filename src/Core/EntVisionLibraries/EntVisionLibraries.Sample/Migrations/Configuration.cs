namespace EntVisionLibraries.Sample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntVisionLibraries.Sample.Models.SmartLogisticContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EntVisionLibraries.Sample.Models.SmartLogisticContext";
        }

        protected override void Seed(EntVisionLibraries.Sample.Models.SmartLogisticContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
