using EntVisionLibraries.Common.Domain;
using EntVisionLibraries.Common.Interface;
using SmartLogistic.Domain.MapAggregate.Enums;
using SmartLogistic.Domain.MapAggregate.Extensions;
using SmartLogistic.Domain.MapAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.MapAggregate
{
    public class MapDirection : Entity<Guid>, IAggregateRoot
    {
        public MapDirection()
        {

        }

        public MapDirection(Map start, Map end, Direction direction, List<MapDirectionStep> steps)
        {
            Start = start;
            End = end;
            Direction = direction;
            Steps = steps;
        }

        public Map Start { get;  set; }
        public Map End { get;  set; }
        public Direction Direction { get;  set; }
        
        public List<MapDirectionStep> Steps { get; set; }


        #region Domain Function

        public void AddDirectionStep(Direction direction, string instructions, string travelMode)
        {
            var existingDirectionStep = Steps.Where(x => x.Direction.Equals(direction)).FirstOrDefault();

            if (existingDirectionStep == null)
            {
                var directionStep = new MapDirectionStep(direction, instructions, travelMode);
                Steps.Add(directionStep);
            }
        }

        public MapDirectionStep GetStepLocation(Direction location)
        {
            foreach (var item in Steps)
                if (item.Direction.Equals(location))
                    return item;
            return null;
        }

        public double GetTotalDuration()
            => Steps.Sum(item => item.Direction.Duration);

        public double GetTotalDistance()
            => Steps.Sum(item => item.Direction.Distance);

        public double GetLongestDistance()
            => Steps.Max(x => x.Direction.Distance);

        public double GetShortestDistance()
            => Steps.Min(x => x.Direction.Distance);

        public double GetLongestDuration()
          => Steps.Max(x => x.Direction.Duration);

        public double GetShortestDuration()
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
