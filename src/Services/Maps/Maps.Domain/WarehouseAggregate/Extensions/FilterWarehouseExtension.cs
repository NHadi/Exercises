using Maps.Domain.WarehouseAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.WarehouseAggregate.Extensions
{
    public static class FilterWarehouseExtension
    {
        public static async Task<IEnumerable<Warehouse>> FilterByCriteriaAsync(this Task<IEnumerable<Warehouse>> data, FilterCriteriaWarehouseType filterCriteria, string[] keywoard)
        {
            var qry = data.GetAwaiter().GetResult();
            
            switch (filterCriteria)
            {
                case FilterCriteriaWarehouseType.Default:
                    break;
                case FilterCriteriaWarehouseType.Address:
                    qry = qry.FilterByAddress(keywoard[0]).AsQueryable();
                    break;
                case FilterCriteriaWarehouseType.Lat:
                    qry = qry.FilterByLat(keywoard[0]).AsQueryable();
                    break;
                case FilterCriteriaWarehouseType.Lng:
                    qry = qry.FilterByLng(keywoard[0]).AsQueryable();
                    break;
                case FilterCriteriaWarehouseType.LatLng:
                    qry = qry.FilterByLatLng(keywoard[0], keywoard[1]).AsQueryable();
                    break;
                default:
                    break;
            }


            return await Task.Run(() => qry);
        }
        public static IEnumerable<Warehouse> FilterByCriteria(this IEnumerable<Warehouse> data, FilterCriteriaWarehouseType filterCriteria, string[] keywoard)
        {
            var qry = data.AsQueryable();
            switch (filterCriteria)
            {
                case FilterCriteriaWarehouseType.Default:                    
                    break;
                case FilterCriteriaWarehouseType.Address:
                    qry = data.FilterByAddress(keywoard[0]).AsQueryable();
                    break;
                case FilterCriteriaWarehouseType.Lat:
                    qry = data.FilterByLat(keywoard[0]).AsQueryable();
                    break;
                case FilterCriteriaWarehouseType.Lng:
                    qry = data.FilterByLng(keywoard[0]).AsQueryable();
                    break;
                case FilterCriteriaWarehouseType.LatLng:
                    qry = data.FilterByLatLng(keywoard[0], keywoard[1]).AsQueryable();
                    break;
                default:
                    break;
            }
            

            return qry;
        }
        public static IEnumerable<Warehouse> FilterByAddress(this IEnumerable<Warehouse> data, string keyword)
            => data.Where(x => x.Address == keyword);

        public static IEnumerable<Warehouse> FilterByLat(this IEnumerable<Warehouse> data, string keyword)
            => data.Where(x => x.Location.Latitude == keyword);

        public static IEnumerable<Warehouse> FilterByLng(this IEnumerable<Warehouse> data, string keyword)
            => data.Where(x => x.Location.Longitude == keyword);
        public static IEnumerable<Warehouse> FilterByLatLng(this IEnumerable<Warehouse> data, string lat, string lng)
            => data.Where(x => x.Location.Longitude == lng && x.Location.Latitude == lat);

    }
}
