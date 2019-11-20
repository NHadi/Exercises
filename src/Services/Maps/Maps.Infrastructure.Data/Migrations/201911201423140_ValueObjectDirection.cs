namespace Maps.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValueObjectDirection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MapDirections", "Direction_DistanceText", c => c.String());
            AddColumn("dbo.MapDirections", "Direction_Distance", c => c.Int(nullable: false));
            AddColumn("dbo.MapDirections", "Direction_DurationText", c => c.String());
            AddColumn("dbo.MapDirections", "Direction_Duration", c => c.Int(nullable: false));
            AddColumn("dbo.MapDirections", "Direction_Instructions", c => c.String());
            AddColumn("dbo.MapDirections", "Direction_TravelMode", c => c.String());
            AddColumn("dbo.MapDirectionSteps", "Direction_DistanceText", c => c.String());
            AddColumn("dbo.MapDirectionSteps", "Direction_Distance", c => c.Int(nullable: false));
            AddColumn("dbo.MapDirectionSteps", "Direction_DurationText", c => c.String());
            AddColumn("dbo.MapDirectionSteps", "Direction_Duration", c => c.Int(nullable: false));
            AddColumn("dbo.MapDirectionSteps", "Direction_Instructions", c => c.String());
            AddColumn("dbo.MapDirectionSteps", "Direction_TravelMode", c => c.String());
            DropColumn("dbo.MapDirections", "DistanceText");
            DropColumn("dbo.MapDirections", "Distance");
            DropColumn("dbo.MapDirections", "DurationText");
            DropColumn("dbo.MapDirections", "Duration");
            DropColumn("dbo.MapDirections", "Instructions");
            DropColumn("dbo.MapDirections", "TravelMode");
            DropColumn("dbo.MapDirectionSteps", "DistanceText");
            DropColumn("dbo.MapDirectionSteps", "Distance");
            DropColumn("dbo.MapDirectionSteps", "DurationText");
            DropColumn("dbo.MapDirectionSteps", "Duration");
            DropColumn("dbo.MapDirectionSteps", "Instructions");
            DropColumn("dbo.MapDirectionSteps", "TravelMode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MapDirectionSteps", "TravelMode", c => c.String());
            AddColumn("dbo.MapDirectionSteps", "Instructions", c => c.String());
            AddColumn("dbo.MapDirectionSteps", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.MapDirectionSteps", "DurationText", c => c.String());
            AddColumn("dbo.MapDirectionSteps", "Distance", c => c.Int(nullable: false));
            AddColumn("dbo.MapDirectionSteps", "DistanceText", c => c.String());
            AddColumn("dbo.MapDirections", "TravelMode", c => c.String());
            AddColumn("dbo.MapDirections", "Instructions", c => c.String());
            AddColumn("dbo.MapDirections", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.MapDirections", "DurationText", c => c.String());
            AddColumn("dbo.MapDirections", "Distance", c => c.Int(nullable: false));
            AddColumn("dbo.MapDirections", "DistanceText", c => c.String());
            DropColumn("dbo.MapDirectionSteps", "Direction_TravelMode");
            DropColumn("dbo.MapDirectionSteps", "Direction_Instructions");
            DropColumn("dbo.MapDirectionSteps", "Direction_Duration");
            DropColumn("dbo.MapDirectionSteps", "Direction_DurationText");
            DropColumn("dbo.MapDirectionSteps", "Direction_Distance");
            DropColumn("dbo.MapDirectionSteps", "Direction_DistanceText");
            DropColumn("dbo.MapDirections", "Direction_TravelMode");
            DropColumn("dbo.MapDirections", "Direction_Instructions");
            DropColumn("dbo.MapDirections", "Direction_Duration");
            DropColumn("dbo.MapDirections", "Direction_DurationText");
            DropColumn("dbo.MapDirections", "Direction_Distance");
            DropColumn("dbo.MapDirections", "Direction_DistanceText");
        }
    }
}
