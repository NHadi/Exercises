namespace SmartLogistic.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_delivery_time_to_field_non_relationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransportRequests", "PreferredDeliveryTime_Id", "dbo.DeliveryTimes");
            DropIndex("dbo.TransportRequests", new[] { "PreferredDeliveryTime_Id" });
            AddColumn("dbo.TransportRequests", "PreferredDeliveryTime", c => c.String());
            DropColumn("dbo.TransportRequests", "PreferredDeliveryTime_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransportRequests", "PreferredDeliveryTime_Id", c => c.Guid());
            DropColumn("dbo.TransportRequests", "PreferredDeliveryTime");
            CreateIndex("dbo.TransportRequests", "PreferredDeliveryTime_Id");
            AddForeignKey("dbo.TransportRequests", "PreferredDeliveryTime_Id", "dbo.DeliveryTimes", "Id");
        }
    }
}
