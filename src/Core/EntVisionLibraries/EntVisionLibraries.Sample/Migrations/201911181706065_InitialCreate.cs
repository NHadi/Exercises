namespace EntVisionLibraries.Sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        From_Id = c.Guid(),
                        To_Id = c.Guid(),
                        Warehouse_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.From_Id)
                .ForeignKey("dbo.Maps", t => t.To_Id)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id)
                .Index(t => t.From_Id)
                .Index(t => t.To_Id)
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deliveries", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.Deliveries", "To_Id", "dbo.Maps");
            DropForeignKey("dbo.Deliveries", "From_Id", "dbo.Maps");
            DropIndex("dbo.Deliveries", new[] { "Warehouse_Id" });
            DropIndex("dbo.Deliveries", new[] { "To_Id" });
            DropIndex("dbo.Deliveries", new[] { "From_Id" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.Maps");
            DropTable("dbo.Deliveries");
        }
    }
}
