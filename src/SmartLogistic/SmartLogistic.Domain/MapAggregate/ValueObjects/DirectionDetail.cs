using EntVisionLibraries.Common.Domain;
using System.Collections.Generic;

namespace SmartLogistic.Domain.MapAggregate.ValueObjects
{
    public class Direction: ValueObject
    {
        public double Distance { get;  set; }
        public string DistanceText { get;  set; }
        public double Duration { get;  set; }
        public string DurationText { get;  set; }

        public Direction(double distance, string distanceText, double duration, string durationText)
        {
            Distance = distance;
            DistanceText = distanceText;
            Duration = duration;
            DurationText = durationText;
        }

        public Direction()
        {

        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Distance;
            yield return DistanceText;
            yield return Duration;
            yield return DurationText;
        }
    }
}
