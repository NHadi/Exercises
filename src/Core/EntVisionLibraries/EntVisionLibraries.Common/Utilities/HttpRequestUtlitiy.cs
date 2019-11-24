using EntVisionLibraries.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace EntVisionLibraries.Common.Utilities.Interfaces
{

    public class HttpRequestUtlitiy<T>
    {        
        private string ProcessRequest(HttpRequestType requestType, string url, object param = null, string token = null)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            
            if (token != null)
                httpWebRequest.Headers.Add("Authorization", "Bearer " + token);


            if (requestType != HttpRequestType.GET)
            {
                httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = requestType.GetString();

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(param));
                }
            }            

            string ResponseString = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                ResponseString = streamReader.ReadToEnd();
            }

            return ResponseString;
        }
        public T Request(HttpRequestType requestType, string url, object param = null, string token = null)
        {
            try
            {
                T result;
                var ResponseString = ProcessRequest(requestType, url, param, token);
                var jsonObject = (JObject)JsonConvert.DeserializeObject(ResponseString);

                if (jsonObject["Results"] != null)
                {
                    result = JsonConvert.DeserializeObject<T>(jsonObject["Results"].ToString());
                }
                else
                {
                    result = JsonConvert.DeserializeObject<T>(jsonObject.ToString());
                }


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IEnumerable<T> Requests(HttpRequestType requestType, string url, object param = null, string token = null)
        {
            try
            {
                var result = new List<T>();
                var ResponseString = ProcessRequest(requestType, url, param, token);

                var jsonObject = (JObject)JsonConvert.DeserializeObject(ResponseString);

                if (jsonObject["Results"] != null)
                {
                    result = JsonConvert.DeserializeObject<List<T>>(jsonObject["Results"].ToString());
                }
                else
                {
                    result = JsonConvert.DeserializeObject<List<T>>(jsonObject.ToString());
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
      
    }
}
