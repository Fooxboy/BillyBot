using System;
using Billy.LongPoll;

namespace Billy.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello World!");
                Starter starter = new Starter();
                starter.Start();
            }
           
        }
    }
}
