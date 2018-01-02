using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Test :IDataCommand
    {
        public string Name => "Тест";
        public string Help => "Тест";

        public string FullHelp => "Команда доступная только для тестеров. Отвечает какую-то дичь.";

        public static string Complete = "Тест";
    }
}
