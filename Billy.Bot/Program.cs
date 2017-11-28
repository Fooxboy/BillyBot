using System;
using Billy.LongPoll;
using Billy.Commands;
using System.Threading;
using System.Collections.Generic;
using VkNet;

namespace Billy.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Инициализация....");
            Render.Initialization();
            Console.WriteLine("Хелло!");
            /* var Starter = new Starter();
                Thread threadLongPoll = new Thread(Starter.Run);
                threadLongPoll.Name = "LongPoll";
                Console.WriteLine("Старт потока LongPoll");
                threadLongPoll.Start();*/

            var model = new Models.Qiwi.Commission.Post();
            model.account = "9081895927";

            var paymentMethod = new Models.Qiwi.Commission.Post.PaymentMethod();
            paymentMethod.accountId = "634";
            paymentMethod.type = "Account";
            model.paymentMethod = paymentMethod;

            var purchaseTotals = new Models.Qiwi.Commission.Post.PurchaseTotals();
            var total = new Models.Qiwi.Commission.Post.PurchaseTotals.Total();
            total.amount = 100;
            total.currency = "643";
            purchaseTotals.total = total;
            model.purchaseTotals = purchaseTotals;

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            string response = API.Qiwi.RequestPost(json);
            Console.WriteLine(response);
            Console.ReadLine();

        }
    }
}
