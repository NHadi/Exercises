namespace Maps.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        Destination_Id = c.Guid(),
                        Direction_Id = c.Guid(),
                        Warehouse_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.Destination_Id)
                .ForeignKey("dbo.MapDirections", t => t.Direction_Id)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id)
                .Index(t => t.Destination_Id)
                .Index(t => t.Direction_Id)
                .Index(t => t.Warehouse_Id);
            
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
                        DistanceText = c.String(),
                        Distance = c.Int(nullable: false),
                        DurationText = c.String(),
                        Duration = c.Int(nullable: false),
                        Instructions = c.String(),
                        TravelMode = c.String(),
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
                        DistanceText = c.String(),
                        Distance = c.Int(nullable: false),
                        DurationText = c.String(),
                        Duration = c.Int(nullable: false),
                        Instructions = c.String(),
                        TravelMode = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        Location_Id = c.Guid(),
                        MapDirection_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.Location_Id)
                .ForeignKey("dbo.MapDirections", t => t.MapDirection_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.MapDirection_Id);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        Location_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deliveries", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.Warehouses", "Location_Id", "dbo.Maps");
            DropForeignKey("dbo.Deliveries", "Direction_Id", "dbo.MapDirections");
            DropForeignKey("dbo.MapDirectionSteps", "MapDirection_Id", "dbo.MapDirections");
            DropForeignKey("dbo.MapDirectionSteps", "Location_Id", "dbo.Maps");
            DropForeignKey("dbo.MapDirections", "Start_Id", "dbo.Maps");
            DropForeignKey("dbo.MapDirections", "End_Id", "dbo.Maps");
            DropForeignKey("dbo.Deliveries", "Destination_Id", "dbo.Maps");
            DropIndex("dbo.Warehouses", new[] { "Location_Id" });
            DropIndex("dbo.MapDirectionSteps", new[] { "MapDirection_Id" });
            DropIndex("dbo.MapDirectionSteps", new[] { "Location_Id" });
            DropIndex("dbo.MapDirections", new[] { "Start_Id" });
            DropIndex("dbo.MapDirections", new[] { "End_Id" });
            DropIndex("dbo.Deliveries", new[] { "Warehouse_Id" });
            DropIndex("dbo.Deliveries", new[] { "Direction_Id" });
            DropIndex("dbo.Deliveries", new[] { "Destination_Id" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.MapDirectionSteps");
            DropTable("dbo.MapDirections");
            DropTable("dbo.Maps");
            DropTable("dbo.Deliveries");
        }
    }
}
