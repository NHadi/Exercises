using EntVisionLibraries.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.MapsAggregate.ValueObjects
{
    public class DirectionProperties : ValueObject
    {
        public string DistanceText { get; private set; }
        public int Distance { get; private set; }
        public string DurationText { get; private set; }
        public int Duration { get; private set; }
        public string Instructions { get; private set; }
        public string TravelMode { get; private set; }

        public DirectionProperties(string distanceText, int distance, string durationText, int duration, string instruction, string travelMode)
        {
            Distance = distance;
            DistanceText = distanceText;
            Duration = duration;
            DurationText = durationText;
            Instructions = instruction;
            TravelMode = travelMode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return DistanceText;
            yield return Distance;
            yield return DurationText;
            yield return Duration;
            yield return Instructions;
            yield return TravelMode;            
        }
    }
}
