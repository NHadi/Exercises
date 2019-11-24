using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLogistic.Domain.MapAggregate
{ 
    public class AddressComponent
    {
        public AddressComponent(string longName , string shortName)
        {
            LongName = longName;
            ShortName = shortName;
        }

        public string LongName { get; set; }
        public string ShortName { get; set; }
        public List<string> Types { get; set; }

    }
}