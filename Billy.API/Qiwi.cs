using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Billy.API
{
    public class Qiwi
    {
        private string Token = "433242ad3c1f95e0dbdfc159c4df89e9";

        public void Get()
        {
            string url = "https://edge.qiwi.com/person-profile/v1/profile/current?";
            var request = HttpWebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.Accept, "application/json");
            request.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token}");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            string text;
            using(StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }
        }
    }
}
