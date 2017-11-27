using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Music : IDataCommand
    {
        public string Name => "Трек";
        public string Help => "Отправляет ссылку на файл для загрузки.";
        public string FullHelp => "Команда позволяет получить прямой файл для загрузки файла музыки." +
            "\nИСПОЛЬЗОВАНИЕ:" +
            "\n-трек (прикреплённые треки)" +
            "\nВ ответ вы получите прямые сслыки для загрузки этих треков." +
            "\nДоступно от Premium и выше.";
        public static string NoAccess = "У вас нет доступа к команде. Чтобы его получить, купите привелегию Premium или выше.";
        public static string NoAttach = "Вы не прикрепили файл с музыкой!";
        public static string Ready = "Список ссылок:";
    }
}
