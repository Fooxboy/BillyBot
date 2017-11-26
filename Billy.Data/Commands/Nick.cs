using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Nick :IDataCommand
    {
        public string Name => "Ник";
        public string Help => "Управлением ником";
        public string FullHelp => "Команда предназначена для смены ника." +
            "\nДоступные команды:" +
            "\nНик сменить <новый ник>" +
            "\nПРИМЕЧАНИЕ: в нике может быть только ОДНО слово." +
            "\nДля привелегии VIP и выше доступно изменение ника другим пользователям:" +
            "\nНик сменить <новый ник> (пересланное сообщение с пользователем)" +
            "\nПРИМЕЧАНИЕ: Вы не сможете изменить ник пользователю с привелегией выше Вашей.";

        public static string Ready = "Вы уcпешно сменили ник!";
        public static string NoAccess = "У Вас не хватает прав для этой команды.";
        public static string NotNick = "Вы не указали ник!";
        public static string NoAccessDonate = "Вы не можете изменить ник пользователю, у которого привелегия больше Вашей!";
        public static string NoUser = "Пользователя нет в базе данных.";

    }
}
