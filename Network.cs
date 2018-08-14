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

        /// <summary>
        /// Uploads a file to a server
        /// </summary>
        /// <param name="uri">URI of the remote resource to which the file will be uploaded</param>
        /// <param name="file">file path relative to the directory of the program's executable file</param>
        public static void UploadFile(string uri, string file) {
            new WebClient().UploadFile(uri, new FileInfo(file).FullName);
        }
    }
}
