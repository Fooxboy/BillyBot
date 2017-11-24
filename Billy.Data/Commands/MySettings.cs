using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class MySettings: IDataCommand
    {
        public string Name => "мои";
        public string Help => "Команда для настройки Вашего профиля.";
        public string FullHelp => "С помощью этой команды можно настроить обращение к Вам." +
            "\nНапример, можно убрать обращение, сообщество и другое." +
            "\nКоманда достуна от Premium  и выше." +
            "\nСписок подкоманд:" +
            "\n-мои настройки создать" +
            "\n-мои настройки - краткий вывод настроек" +
            "\n-мои натройки изменить <id параметра> <Значение> - Изменяет выбранную настройку." +
            "\n-мои настройки сбросить - Сбрасывает Ваши настройки к параметрам по умолчанию.";

        public static string ReadyCreate = "Вы успешно создали файл настроек. " +
            "\nЧтобы получить помощь по изменению, напишите:" +
            "\nБилли, мои настройки";
        public static string IsCreate = "У Вас уже есть созданный файл настроек.";
        public static string NoAccess = "У Вас нет доступа к этой команде. Чтобы его получить купите привелегию от Premium.";
    }
}
