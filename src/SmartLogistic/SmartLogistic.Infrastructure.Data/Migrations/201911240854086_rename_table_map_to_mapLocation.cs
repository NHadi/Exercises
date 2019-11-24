namespace SmartLogistic.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_table_map_to_mapLocation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Maps", newName: "MapLocations");
            AddColumn("dbo.MapLocations", "Address", c => c.String());
            DropColumn("dbo.MapLocations", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MapLocations", "Title", c => c.String());
            DropColumn("dbo.MapLocations", "Address");
            RenameTable(name: "dbo.MapLocations", newName: "Maps");
        }
    }
}
