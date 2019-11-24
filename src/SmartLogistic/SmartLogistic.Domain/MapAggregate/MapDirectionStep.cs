using EntVisionLibraries.Common.Domain;
using SmartLogistic.Domain.MapAggregate.ValueObjects;
using System;

namespace SmartLogistic.Domain.MapAggregate
{
    public class MapDirectionStep : Entity<Guid>
    {
        public MapDirectionStep()
        {

        }
        public MapDirectionStep(Direction direction, string instructions, string travelMode)
        {
            Direction = direction;
            Instructions = instructions;
            TravelMode = travelMode;
        }

        public Direction Direction { get; set; }
        public string Instructions { get; set; }
        public string TravelMode { get; set; }
    }
}