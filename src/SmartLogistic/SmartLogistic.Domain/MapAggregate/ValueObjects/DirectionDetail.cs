using EntVisionLibraries.Common.Domain;
using System.Collections.Generic;

namespace SmartLogistic.Domain.MapAggregate.ValueObjects
{
    public class Direction: ValueObject
    {
        public double Distance { get; private set; }
        public string DistanceText { get; private set; }
        public double Duration { get; private set; }
        public string DurationText { get; private set; }

        public Direction(double distance, string distanceText, double duration, string durationText)
        {
            Distance = distance;
            DistanceText = distanceText;
            Duration = duration;
            DurationText = durationText;
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
