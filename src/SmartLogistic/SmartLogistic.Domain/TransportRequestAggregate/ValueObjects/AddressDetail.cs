﻿using EntVisionLibraries.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.TransportRequestAggregate.ValueObjects
{
    public class AddressDetail : ValueObject
    {
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public AddressDetail(string address, double lat, double lng)
        {
            Address = address;
            Latitude = lat;
            Longitude = lng;
        }

        public AddressDetail(string address)
        {
            Address = address;
        }

        public AddressDetail()
        {

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
