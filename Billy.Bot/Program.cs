using System;
using Billy.LongPoll;

namespace Billy.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Billy.API.Database.Methods methods = new API.Database.Methods("Users");
            var result = methods.GetFromId(1, "Name");
            Console.WriteLine(result);
            API.User.New(228);
            var user = new API.User(228);
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Foxs);
            Console.ReadLine();
        }
    }
}
