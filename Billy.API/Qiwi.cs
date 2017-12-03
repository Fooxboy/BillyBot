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

        public static Models.Qiwi.Payments.Result Payments(int count, string number, string idOperator = "99")
        {
            string text;
            using (var reader = new StreamReader("Payments.txt"))
            {
                text = reader.ReadToEnd();
            }

            var countId = Int64.Parse(text);
            countId++;

            var model = new Models.Qiwi.Payments.Post
            {
                id = countId.ToString(),
                comment = "Вывод средств BillyBot",
                sum = new Models.Qiwi.Payments.Post.Sum
                {
                    amount = count,
                    currency = "643"
                },
                paymentMethod = new Models.Qiwi.Payments.Post.PaymentMethod
                {
                    type = "Account",
                    accountId = "643"
                },
                fields = new Models.Qiwi.Payments.Post.Fields
                {
                    account = number,
                }
            };

            string postJson = JsonConvert.SerializeObject(model);
            string json = RequestPost($"sinap/api/v2/terms/{idOperator}/payments", postJson);

            var response = JsonConvert.DeserializeObject<Models.Qiwi.Payments.Result>(json);
            return response;
        }

        public static void PayPhone(string number, int count)
        {
            //TODO: Доделать.
            string ph = System.Web.HttpUtility.UrlEncode(number);
            Console.WriteLine(ph);
            RequestPostPhone($"phone=%2B{ph}");
            Console.ReadLine();
        }

        public static string GetUrl(long idUser)
        {
            string url = $"https://qiwi.com/payment/form/99?currency=643&amountInteger=50&currency=643&extra[‘comment’]={idUser}&extra[‘account’]=79094413184";
            return url;
        }

        public static Models.Qiwi.Balance Balance()
        {
            string json = Request("funding-sources", "accounts/current");
            var balance = JsonConvert.DeserializeObject<Models.Qiwi.Balance>(json);
            return balance;
        }

        public static Models.Qiwi.Commission.Result Commision(string account, int count, string id)
        {
            var model = new Models.Qiwi.Commission.Post
            {
                account = account,
                paymentMethod = new Models.Qiwi.Commission.Post.PaymentMethod
                {
                    type = "Account",
                    accountId = "643"
                },
                purchaseTotals = new Models.Qiwi.Commission.Post.PurchaseTotals
                {
                    total = new Models.Qiwi.Commission.Post.PurchaseTotals.Total
                    {
                        amount = count,
                        currency = "643"
                    }
                }
            };

            string data = JsonConvert.SerializeObject(model);
            string json = RequestPost($"sinap/providers/{id}/form", data);

            var modelResult = JsonConvert.DeserializeObject<Models.Qiwi.Commission.Result>(json);
            return modelResult;
        }

        public static Models.Qiwi.Payment PaymentHistory(long rows)
        {
            string json = Request($"https://edge.qiwi.com/payment-history/v1/persons/79094413184/payments?rows={rows}");
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

        public static string Request(string url)
        {
            string Token = "433242ad3c1f95e0dbdfc159c4df89e9";

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

        public static string RequestPost(string method,string data)
        {
            string Token = "433242ad3c1f95e0dbdfc159c4df89e9";
            string url = $"https://edge.qiwi.com/{method}";
            var request = HttpWebRequest.Create(url);
            request.Method = "Post";
            request.ContentType = "application/json";
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(data);
            request.ContentLength = bytes.Length;
            request.Headers.Add(HttpRequestHeader.Accept, "application/json");
            request.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token}");
            Stream st = request.GetRequestStream();
            st.Write(bytes, 0, bytes.Length);
            st.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            string text;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }

        public static string RequestPostPhone(string data)
        {
            string Token = "433242ad3c1f95e0dbdfc159c4df89e9";
            string url = $"https://qiwi.com/mobile/detect.action";
            var request = HttpWebRequest.Create(url);
            request.Method = "Post";
            request.ContentType = "application/x-www-form-urlencoded";
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(data);
            request.ContentLength = bytes.Length;
            request.Headers.Add(HttpRequestHeader.Accept, "application/json");
            request.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token}");
            Stream st = request.GetRequestStream();
            st.Write(bytes, 0, bytes.Length);
            st.Close();
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
