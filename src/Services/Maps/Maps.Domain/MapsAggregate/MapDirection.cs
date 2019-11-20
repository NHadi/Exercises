using EntVisionLibraries.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maps.Domain.MapsAggregate.Extensions;
using Maps.Domain.MapsAggregate.ValueObjects;
using Maps.Domain.MapsAggregate.Enums;

namespace Maps.Domain.MapsAggregate
{
    public class MapDirection : Entity<Guid>
    {
        public MapDirection()
        {
            Steps = new List<MapDirectionStep>();
            Start = new Map();
            End = new Map();
        }

        public MapDirection(Map start, Map end, DirectionProperties direction, List<MapDirectionStep> steps)
        {
            Start = start;
            End = end;
            Direction = direction;
            Steps = steps;
        }

        public Map Start { get; set; }
        public Map End { get; set; }
        public DirectionProperties Direction { get; set; }
        public List<MapDirectionStep> Steps { get; set; }

        #region Domain Function
        public MapDirectionStep GetStepLocation(Map location)
        {
            foreach (var item in Steps)
                if (item.Location.Equals(location))
                    return item;
            return null;
        }

        public int GetTotalDuration()
            => Steps.Sum(item => item.Direction.Duration);

        public int GetTotalDistance()
            => Steps.Sum(item => item.Direction.Distance);

        public int GetLongestDistance()
            => Steps.Max(x => x.Direction.Distance);

        public int GetShortestDistance()
            => Steps.Min(x => x.Direction.Distance);

        public int GetLongestDuration()
          => Steps.Max(x => x.Direction.Duration);

        public int GetShortestDuration()
            => Steps.Min(x => x.Direction.Duration);

        public MapDirectionStep GetShortestLocation(DirectionType direction)
        {
            var result = new MapDirectionStep();
            switch (direction)
            {
                case DirectionType.Distantance:
                    result = Steps.ShortestDistance()
                        .FirstOrDefault();
                    break;
                case DirectionType.Duration:
                    result = Steps.ShortestDuration()
                        .FirstOrDefault();
                    break;
                case DirectionType.DistanceAndDuration:
                    result = Steps.ShortestDistance()
                            .ShortestDuration()
                        .FirstOrDefault();
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }

        public MapDirectionStep GetLongestLocation(DirectionType direction)
        {
            var result = new MapDirectionStep();
            switch (direction)
            {
                case DirectionType.Distantance:
                    result = Steps.LongestDistance()
                        .FirstOrDefault();
                    break;
                case DirectionType.Duration:
                    result = Steps.LongestDuration()
                        .FirstOrDefault();
                    break;
                case DirectionType.DistanceAndDuration:
                    result = Steps.LongestDistance()
                            .LongestDuration()
                        .FirstOrDefault();
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }
        #endregion
    }
}
