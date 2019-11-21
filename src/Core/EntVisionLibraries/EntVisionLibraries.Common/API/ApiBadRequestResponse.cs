using EntVisionLibraries.Common.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.Common.API
{
    public class ApiBadRequestResponse : ApiResponse
    {
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<EntityValidationFailure> Errors { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object ErrorDetail { get; set; }

        public ApiBadRequestResponse(int statusCode, string message)
            : base(statusCode)
        {
            Message = message;            
        }

        public ApiBadRequestResponse(int statusCode, object message)
            : base(statusCode)
        {
            Message = JsonConvert.SerializeObject(message);
        }

        public ApiBadRequestResponse(int statusCode, IList<EntityValidationFailure> message)
           : base(statusCode)
        {
            Message = "Something Wrong, please check in error messages";
            Errors = message;
        }

        public ApiBadRequestResponse(int statusCode, IList<EntityValidationFailure> message, object data)
          : base(statusCode)
        {
            Message = "Something Wrong, please check in error messages";
            Errors = message;
            ErrorDetail = data;
        }
    }
}
