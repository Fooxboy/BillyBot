using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Data.Commands
{
    public class Profile : IDataCommand
    {
        public string Name => "Профиль";
        public string Help => "Показывает ваш профиль.";
        public string FullHelp => "Эта команда поможет узнать о вас больше! Команда выводит информацию о Вас." +
            "\nИспользование:" +
            "\nБилли, профиль." +
            "\nОт Vip и выше есть доступ для просмотра чужих профилей:" +
            "\nБилли, профиль <id>" +
            "\nАльтернативный вид команды:" +
            "\nБилли, профиль (пересланное сообщение с пользователем)";
        public static string ProfileGet(User user)
        {
            string text = $"Профиль пользователя {user.Name}" +
                $"\nИмя: {user.Name}" +
                $"\nФоксы: {user.Foxs}";
            return text;
        }
        public static string NoAccess = "У Вас нет доступа к просмотру профилей других пользователей. Купите привелегию Vip или выше.";
        public static string NoUser = "Этого пользователя нет в базе данных пользователей бота.";
        public static string NoUserId = "Вы указали неверный User_id!";
    }
}
