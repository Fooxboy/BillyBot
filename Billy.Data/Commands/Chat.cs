using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Chat : IDataCommand
    {
        public string Name => "Чат";
        public string Help => "Команда для работы с текущим чатом.";
        public string FullHelp => "С помощью этой команды Вы можете настроить текущий чат." +
            "\nКоманда доступна только с привелегии VIP." +
            "\nДоступные подкоманды:" +
            "\nтблок - Блокирует текущее название." +
            "\nтанблок - Разблокирует текущее название." +
            "\nфблок - Блокирует текущую фотографию диалога." +
            "\nфанблок - Раблокирует текущую фотографию диалога." +
            "\nнастройки - Текущие настройки чата.";

        public static string TitleNoBlocked = "Название групповой беседы не заблокировано.";
        public static string TitleNotUnBlock = "Вы не можете разблокировать название текущей беседы. Это могут те, кто сохранил название и создатель групповой беседы.";
        public static string TitleReadyUnBlock = "Вы успешно разблокировали название групповой беседы!";
        public static string TitleIsBlocked = "Название текущей беседы уже заблокировано.";
        public static string TitleReadyBlock = "Вы успешно заблокировали текущее название.";

        public static string NoChat = "Этот диалог не является групповой беседой.";
        public static string NoAccess = "У Вас нет доступа к этой команде. Чтобы его получить купите привелегию VIP или выше.";
        public static string NoCommand = "Неизвестная подкоманда.";
        public static string NotCommand = "Вы не указали подкоманду.";

        public static string PhotoNotBlocked = "Главная фотография групповой беседы не заблокирована.";
        public static string PhotoNotUnBlock = "Вы не можете разблокировать главную фотографию беседы. Это могут те, кто заблокировал фотографию и создатель групповой беседы.";
        public static string PhotoReadyUnBlock = "Вы успешно раблокировали главную фотографию текущей групповой беседы.";
        public static string PhotoIsBlocked = "Главная фотография групповой беседы уже заблокирована.";
        public static string PhotoNotAttach = "Прикрепите к сообщению фотографию.";
        public static string PhotoNoAttach = "Вы прикрепили не фотографию. Пожайлуйста, прикрепите фотографию, чтобы заблокировать её изменение.";
        public static string PhotoReadyBlock = "Вы успешно заблокировали главную фотографию групповой беседы.";
    }
}
