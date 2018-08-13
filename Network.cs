using System.Collections.Generic;
using System.Net;
using System.IO;

namespace IDK {

    /// <summary>
    /// Class that performs networking operations
    /// </summary>
    class Network {

        /// <summary>
        /// Makes an HTTP web request
        /// </summary>
        /// <param name="uri">URI of the resource</param>
        /// <param name="method">http method to be used</param>
        /// <param name="headers">http headers for the request</param>
        /// <returns></returns>
        public static Stream MakeHttpRequest(string uri, string method, Dictionary<HttpRequestHeader, string> headers) {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            request.Method = method;
            request.Timeout = 60000;

            if (!ReferenceEquals(headers, null)) {
                foreach (KeyValuePair<HttpRequestHeader, string> header in headers) {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            WebResponse response = request.GetResponse();
            
            return response.GetResponseStream();
        }
    }
}
