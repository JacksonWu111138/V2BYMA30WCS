using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.V2BYMA30
{
    public class clsTool
    {
        public static string HttpPost(string url, string body)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.MediaType = "utf-8";
            request.ContentType = "application/json";
            byte[] buffer = Encoding.UTF8.GetBytes(body);
            request.ContentLength = buffer.Length;
            using (Stream newStream = request.GetRequestStream())
            {
                newStream.Write(buffer, 0, buffer.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {

                return reader.ReadToEnd();
            }
        }

        public static string HttpPost(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.MediaType = "utf-8";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {

                return reader.ReadToEnd();
            }
        }
    }
}
