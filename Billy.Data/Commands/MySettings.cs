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
        public static string Settings = "1-Показывать ник. Доступные значения: Да|Нет" +
            "\n2-Показывать сообщество(если оно у Вас есть). Доступные значения: Да|Нет";
        public static string NotCreate = "У Вас не созданы пользовательские настройки. Чтобы создать напишите: Билли, мои настройки создать";
        public static string Ready(string answer)
        {
            string text = $"Вы успешно заменили параметр на {answer}.";
            return text;
        }
        public static string NotId = "Вы не указали ID настройки.";
        public static string NotParametr = "Вы не указали значение параметра.";
        public static string NoParametr = "Вы ввели недопустимое значение параметра.";
        public static string NoId = "Вы указали несуществующий ID параметра.";
        public static string ReadyReset = "Вы успешно сбросили Ваши параметры.";
        public static string NoSetting = "Вы можете только получить доступ к команде Мои настройки :/";
    }
}
