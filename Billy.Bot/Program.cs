using System;
using Billy.LongPoll;
using Billy.Commands;
using System.Threading;

namespace Billy.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Инициализация....");
            Render.Initialization();
           // while (true)
          //  {

                Console.WriteLine("Хелло!");
                var Starter = new Starter();
                Thread threadLongPoll = new Thread(Starter.Run);
                threadLongPoll.Name = "LongPoll";
            Console.WriteLine("Старт потока LongPoll");
                threadLongPoll.Start();

           // }
           
        }
    }
}
