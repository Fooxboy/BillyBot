using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Missions:IDataCommand
    {
        public string Name => "Задания";
        public string Help => "Раздел для работы с заданиями.";
        public string FullHelp => "Команда для работы с заданиями." +
            "\nДОСТУПНЫЕ ПОДКОМАНДЫ:" +
            "\n - создать  - Создание нового задания" +
            "\n - список - Вывод всех заданий" +
            "\n - статус - Вывод информации о Ваших созданных заданиях" +
            "\n - проверить - проверяет статус выполнения заданий.";
    }
}
