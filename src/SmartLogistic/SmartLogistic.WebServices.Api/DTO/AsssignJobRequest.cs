using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLogistic.WebServices.Api.DTO
{
    public class AsssignJobRequest
    {
        public string PickupAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public string PreferredDeliveryTime { get; set; }
        public string PackingDetails { get; set; }
    }
}