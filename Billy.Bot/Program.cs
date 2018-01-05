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
             var Starter = new Starter();
                  Thread threadLongPoll = new Thread(Starter.Run);
                  threadLongPoll.Name = "LongPoll";
                  Console.WriteLine("Старт потока LongPoll");
                  threadLongPoll.Start(); 

          
        }
    }
}
