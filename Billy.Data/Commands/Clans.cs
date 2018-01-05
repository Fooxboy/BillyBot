using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Clans : IDataCommand
    {
        public string Name => "Клан";
        public string Help => "Команда для работы с кланом.";
        public string FullHelp => "Олала";

        public static string NoClan = "Вы не находитесь в клане. Вступите в него!";
        public static string InClan = "Вы уже находитесь в клане. Выйдите сначала с него!";
        public static string NoIdClan = "Вы не указали Id клана.";
        public static string ReadyJoin = "Вы успешно выступили в клан!";
        public static string NoForwardMessage = "Вы не переслали сообщение с участником!";
        public static string NotUser = "Этот пользователь не является пользователем бота.";
        public static string UserInClan = "Пользователь уже находится в клане.";
        public static string ReadyAdd = "Вы успешно добавили пользователя в свой клан.";
        public static string ReadyLeave = "Вы успешно покинули клан.";
        public static string NotNameClan = "Вы не указали имя клана.";
        public static string ReadyCreate = "Вы успешно создали клан!";
        public static string Info(Models.Clan clan, string nameCreator, string members)
        {
            string result = $"===ИНФОРМАЦИЯ О КЛАНЕ===" +
                $"\nНАЗВАНИЕ: {clan.Name}" +
                $"\nID: {clan.Id}" +
                $"\nУЧАСТНИКИ: \n {members}" +
                $"\nСОЗДАТЕЛЬ: [{clan.Creator}|{nameCreator}]" +
                $"\nДАТА СОЗДАНИЯ: {clan.Date}";
            return result;
        }

    }
}
