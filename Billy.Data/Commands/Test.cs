﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Test :IDataCommand
    {
        public string Help => "Тестовая Функция";

        public string FullHelp => "Команда доступная только для тестеров. Отвечает какую-то дичь.";
    }
}
