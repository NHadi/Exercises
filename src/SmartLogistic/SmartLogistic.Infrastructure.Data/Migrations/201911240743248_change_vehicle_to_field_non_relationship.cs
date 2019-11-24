namespace SmartLogistic.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_vehicle_to_field_non_relationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransportRequests", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.TransportRequests", new[] { "Vehicle_Id" });
            AddColumn("dbo.TransportRequests", "Vehicle", c => c.String());
            DropColumn("dbo.TransportRequests", "Vehicle_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransportRequests", "Vehicle_Id", c => c.Guid());
            DropColumn("dbo.TransportRequests", "Vehicle");
            CreateIndex("dbo.TransportRequests", "Vehicle_Id");
            AddForeignKey("dbo.TransportRequests", "Vehicle_Id", "dbo.Vehicles", "Id");
        }
    }
}
