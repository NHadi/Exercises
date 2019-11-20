using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.MapsAggregate.Extensions
{
    public static class MapDirectionExtension
    {
        public static IEnumerable<MapDirectionStep> ShortestDistance(this IEnumerable<MapDirectionStep> data)
            => data.OrderBy(x => x.Direction.Distance);
        public static IEnumerable<MapDirectionStep> ShortestDuration(this IEnumerable<MapDirectionStep> data)
            => data.OrderBy(x => x.Direction.Duration);
        public static IEnumerable<MapDirectionStep> LongestDistance(this IEnumerable<MapDirectionStep> data)
            => data.OrderBy(x => x.Direction.Distance);
        public static IEnumerable<MapDirectionStep> LongestDuration(this IEnumerable<MapDirectionStep> data)
            => data.OrderBy(x => x.Direction.Duration);        
    }
}
