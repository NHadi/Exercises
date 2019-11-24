using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.Common.Enums
{
    public enum HttpRequestType
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public static class HttpRequestTypeExtension
    {
        public static string GetString(this HttpRequestType requestType)
        {
            string result = string.Empty;
            switch (requestType)
            {
                case HttpRequestType.GET:
                    result = Global.Method.GET;
                    break;
                case HttpRequestType.POST:
                    result = Global.Method.POST;
                    break;
                case HttpRequestType.PUT:
                    result = Global.Method.PUT;
                    break;
                case HttpRequestType.DELETE:
                    result = Global.Method.DELETE;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
