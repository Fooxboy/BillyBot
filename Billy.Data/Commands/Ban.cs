using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Ban :IDataCommand
    {
        public string Name => "Бан";
        public string Help => "Управление банами.";
        public string FullHelp => "Команда предназначена для управления банами пользователей." +
            "\nДоступные команды:" +
            "-Бан + <время> <причина> (пересланное сообщение с пользователем)" +
            "\nКоманда доступна только от привелегии Diamond." +
            "\nПРИМЕЧАНИЕ: Вы не сможете забанить пользователя, у которого привелегия выше Вашей.";
        public static string ReadyBan = "Вы успешно заблокировали пользователя.";
        public static string ReadyUnBan = "Вы успешно разблокировали пользователя.";
        public static string NoAccess = "У Вас нет доступа к команде. Купите привелегию от Diamond или выше";
        public static string NoUser = "Пользователь не является пользователем бота.";
        public static string NotBans = "У пользователя нет бана.";
        public static string NoTime = "Не указано время бана. ";
        public static string NotCommand = "Неизвестная подкоманда.";
        public static string NoCommand = "Не указана подкоманда.";
        public static string NoId = "Вы не переслали сообщение с пользователем!";
    }
}
