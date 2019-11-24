namespace SmartLogistic.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_type_data_int_in_lat_and_lng_to_double : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TransportRequests", "Pickup_Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.TransportRequests", "Pickup_Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.TransportRequests", "Delivery_Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.TransportRequests", "Delivery_Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TransportRequests", "Delivery_Longitude", c => c.Int(nullable: false));
            AlterColumn("dbo.TransportRequests", "Delivery_Latitude", c => c.Int(nullable: false));
            AlterColumn("dbo.TransportRequests", "Pickup_Longitude", c => c.Int(nullable: false));
            AlterColumn("dbo.TransportRequests", "Pickup_Latitude", c => c.Int(nullable: false));
        }
    }
}
