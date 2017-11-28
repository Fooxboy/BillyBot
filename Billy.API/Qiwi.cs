using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Billy.API
{
    public class Qiwi
    {
        public static Models.Qiwi.Profile Profile()
        {
            string json = Request("person-profile", "profile/current?");
            Models.Qiwi.Profile profile = JsonConvert.DeserializeObject<Models.Qiwi.Profile>(json);
            return profile;
        }

        public static Models.Qiwi.Balance Balance()
        {
            string json = Request("funding-sources", "accounts/current");
            var balance = JsonConvert.DeserializeObject<Models.Qiwi.Balance>(json);
            return balance;
        }

        public static void Commision()
        {
            
        }

        public static Models.Qiwi.Payment PaymentHistory(long rows)
        {
            string json = Request("payment-history", $"persons/9094413184/payments?rows={rows}&operation=ALL");
            var payments = JsonConvert.DeserializeObject<Models.Qiwi.Payment>(json);
            return payments;
        }

        public static string Request(string method, string parametr)
        {
             string Token = "433242ad3c1f95e0dbdfc159c4df89e9";
             string url = $"https://edge.qiwi.com/{method}/v1/{parametr}";

            var request = HttpWebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.Accept, "application/json");
            request.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var stream = response.GetResponseStream();
            string text;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }

        //string method, string parametr, 
        public static string RequestPost(string data)
        {
            string Token = "433242ad3c1f95e0dbdfc159c4df89e9";
            string url = $"https://edge.qiwi.com/sinap/providers/99/onlineCommission";
            var request = HttpWebRequest.Create(url);
            request.Method = "Post";
            request.ContentType = "application/x-www-form-urlencoded";
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(data);
            request.ContentLength = bytes.Length;
            request.Headers.Add(HttpRequestHeader.Accept, "application/json");
            request.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token}");
            using(var streamOne = request.GetRequestStream())
            {
                streamOne.Write(bytes, 0, bytes.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            string text;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }
    }
}
