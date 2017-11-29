using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Donate :IDataCommand
    {
        public string Name => "Донат";
        public string Help => "Команда для работы с донатом.";
        public string FullHelp => "В процессе..";

        public static string Buy = "Для того, чтобы купить привелегию, нужно сначала узнать ID привелегии" +
            "\nНапишите: Билли, донат список." +
            "\nЧтобы купить определённую привелегию напишите: Билли, донат купить <id привелегии>";
        public static string NoMoney = "У Вас не хватает денег для покупки этой привелегии.";
        public static string NotId = "Неверный формат ID привелегии. Для того чтобы узнать ID привелегии напишите: Билли донат список";
        public static string NoId = "Неверный ID привелегии. Для того чтобы узнать ID привелегии напишите: Билли донат список";
        public static string Ready = "Успешная покупка привелегии.";
        public static string NoCommand = "Вы не указали подкоманду. Доступные подкоманды:" +
            "\n Список" +
            "\nКупить";
        public static string ListDonat = "Список доступных привелегий:" +
            "\n===VIP===" +
            "\nЦена:69 Фоксов" +
            "\nID: 2" +
            "\nДоступные команды:" +
            "\nВ разработке." +
            "\n===Premium===" +
            "\nЦена: 100 Фоксов" +
            "\nID: 3" +
            "\nДоступные команды:" +
            "\nВ разработке." +
            "\n===Diamond===" +
            "\nЦена: 250 Фоксов" +
            "\nID: 4" +
            "\nДоступные команды:" +
            "\nВ разработке." +
            "\nДля того, чтобы купить определённую привелегию, напишите: Билли донат купить <id привелегии>";

        public static string Check(long UserId, bool result, int sum, int sumFoxs, string textServer)
        {
            string text =
                $"\n==============================" +
                $"\nЧЕК О ПОКУПКЕ №1" +
                $"\nОПЕРАЦИЯ: Покупка привелегии" +
                $"\nПОЛЬЗОВАТЕЛЬ: {UserId}" +
                $"\nРЕЗУЛЬТАТ: {result}" +
                $"\nСУММА: {sum}" +
                $"\nСнято со счёта: {sumFoxs}" +
                $"\nОТВЕТ СЕРВЕРА:" +
                $"\n{textServer}" +
                $"\n==============================";
            return text;
        }

    }
}
