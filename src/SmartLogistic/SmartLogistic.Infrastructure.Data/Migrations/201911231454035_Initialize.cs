namespace SmartLogistic.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryTimes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MapDirections",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Direction_Distance = c.Double(nullable: false),
                        Direction_DistanceText = c.String(),
                        Direction_Duration = c.Double(nullable: false),
                        Direction_DurationText = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        End_Id = c.Guid(),
                        Start_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.End_Id)
                .ForeignKey("dbo.Maps", t => t.Start_Id)
                .Index(t => t.End_Id)
                .Index(t => t.Start_Id);
            
            CreateTable(
                "dbo.MapDirectionSteps",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Direction_Distance = c.Double(nullable: false),
                        Direction_DistanceText = c.String(),
                        Direction_Duration = c.Double(nullable: false),
                        Direction_DurationText = c.String(),
                        Instructions = c.String(),
                        TravelMode = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransportRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Pickup_Address = c.String(),
                        Pickup_Latitude = c.Int(nullable: false),
                        Pickup_Longitude = c.Int(nullable: false),
                        Delivery_Address = c.String(),
                        Delivery_Latitude = c.Int(nullable: false),
                        Delivery_Longitude = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        PackingDetails = c.String(),
                        ScheduledDeliveryTime = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        PreferredDeliveryTime_Id = c.Guid(),
                        RouteDetail_Id = c.Guid(),
                        Status_Id = c.Guid(),
                        Vehicle_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryTimes", t => t.PreferredDeliveryTime_Id)
                .ForeignKey("dbo.MapDirections", t => t.RouteDetail_Id)
                .ForeignKey("dbo.JobStatus", t => t.Status_Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.PreferredDeliveryTime_Id)
                .Index(t => t.RouteDetail_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        Area_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleAreas", t => t.Area_Id)
                .Index(t => t.Area_Id);
            
            CreateTable(
                "dbo.VehicleAreas",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransportRequests", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Area_Id", "dbo.VehicleAreas");
            DropForeignKey("dbo.TransportRequests", "Status_Id", "dbo.JobStatus");
            DropForeignKey("dbo.TransportRequests", "RouteDetail_Id", "dbo.MapDirections");
            DropForeignKey("dbo.TransportRequests", "PreferredDeliveryTime_Id", "dbo.DeliveryTimes");
            DropForeignKey("dbo.MapDirections", "Start_Id", "dbo.Maps");
            DropForeignKey("dbo.MapDirections", "End_Id", "dbo.Maps");
            DropIndex("dbo.Vehicles", new[] { "Area_Id" });
            DropIndex("dbo.TransportRequests", new[] { "Vehicle_Id" });
            DropIndex("dbo.TransportRequests", new[] { "Status_Id" });
            DropIndex("dbo.TransportRequests", new[] { "RouteDetail_Id" });
            DropIndex("dbo.TransportRequests", new[] { "PreferredDeliveryTime_Id" });
            DropIndex("dbo.MapDirections", new[] { "Start_Id" });
            DropIndex("dbo.MapDirections", new[] { "End_Id" });
            DropTable("dbo.VehicleAreas");
            DropTable("dbo.Vehicles");
            DropTable("dbo.TransportRequests");
            DropTable("dbo.MapDirectionSteps");
            DropTable("dbo.MapDirections");
            DropTable("dbo.Maps");
            DropTable("dbo.JobStatus");
            DropTable("dbo.DeliveryTimes");
        }
    }
}
