using EntVisionLibraries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntVisionLibraries.Sample.Models
{
    public class Maps : Entity<Guid>
    {        
        public string Title { get; set; }
        public string Content { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}