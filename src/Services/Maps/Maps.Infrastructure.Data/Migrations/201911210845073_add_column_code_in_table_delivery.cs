namespace Maps.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_code_in_table_delivery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deliveries", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deliveries", "Code");
        }
    }
}
