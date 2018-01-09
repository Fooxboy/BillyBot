using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class FieldOfDreams : IDataCommand
    {
        public string Name => "Пч";
        public string Help => "Игра в Поле Чудес! ";
        public string FullHelp => "Полное описание.";

        public static string NoIdOrAnwser = $"Вы не указали ID или ОТВЕТ. Укажите в таком виде: Билли, пч отв ID ОТВЕТ";
        public static string NoId = "Неверный ID.";
        public static string NoCreator = "Вы не создатель этой игры.";
        public static string ReadyCreateAnswer = "Вы добавлили ответ к игре! Чтобы привязать игру к определённой беседе и начать играть, напишите в нужной беседе: Билли пч зайти ID.";
        public static string NoQuesstion = "Вы не указали вопрос.";
        public static string ReadyCreate(int id)
        {
            return $"Вы успешно создали игру! Теперь нужно добавить ответ к вашему вопросу! Чтобы добавить ответ напишите: Билли, пч отв {id} ОТВЕТ\n ВНИМАНИЕ: ОТВЕТОМ МОЖЕТ БЫТЬ ТОЛЬКО ОДНО СЛОВО!";

        }
        public static string NotCommand = "Неверная подкоманда!";
        public static string InDialog = "Команда доступна только в личном диалоге.";
        public static string InChat = "Команда доступна только в групповых чатах.";
        public static string NotId = "Вы не указали ID.";
        public static string NoStarted = "Нельзя присоединиться к игре, в которой не задан ответ.";
        public static string GameEnd = "Нельзя присоединиться к игре, которая завершена.";
        public static string GameInChatId = "Эта игра привязана к другой групповой беседе.";
        public static string UserInPlayOther = "Вы уже находитесь в другой игре. Напишите: Билли, пч выйти";
        public static string ReadyEnter = "Вы успешно присоединились к текущей игре!";
        public static string IsNotCreatorAdd = "Эта игра ещё не привязана к определённой групповой беседе. Для начала её нужно привязать. Это может сделать только создатель этой игры.";
        public static string ReadyAdded = "Вы успешно привязали игру к текущей беседе! Теперь другие смогут к ней присоединиться!";
        public static string ReadyLeave = "Вы успешно покинули игру.";
        public static string InNotGame = "Вы не находитесь в какой-либо игре.";
        public static string NoChar = "Вы не указали букву!";
        public static string GameIsComptele = "Игра уже завершена. Выйдите с неё. Напишите: Билли, пч выйти";
        public static string ReadyLose = "Вы не угадали букву!";
        public static string ReadyWin(int count, string proccesing, bool competed)
        {
            string result = null;
            if(competed)
            {
                result = $"ВЫ УСПЕШНО УГАДАЛИ {count} БУКВ(да, да, мне было лень.)!" +
                    $"\nТекущий прогресс: {proccesing}" +
                    $"\nДА! ВЫ ЗАКОНЧИЛИ ИГРУ! НАЧНИТЕ НОВУЮ!" +
                    $"\nНо для начала выйдите с этой, написав: Билли, пч выйти " +
                    $"\nДа, мне лень было сделать авт. выход)()()((";
            }else
            {
                result = $"ВЫ УСПЕШНО УГАДАЛИ {count} БУКВ(да, да, мне было лень.)!" +
                    $"\nТекущий прогресс: {proccesing}" +
                    $"\nПродолжайте! Я в вас верю! У вас все получится!";
            }

            return result;
        }
        public static string NoWord = "Вы не указали слово!";
        public static string WinWord = "ВЫ УГАДАЛИ СЛОВО! УРАА!" +
            "\nИгра закончена. Начинайте новую!" +
            "\nНо для начала выйдите с этой, написав: Билли, пч выйти" +
            "\nДа, я ленивый, мне было лень делать это автоматически)()(";
        public static string LoseWord = "ХАХАХАХ, НЕТ, НЕ ВЕРНО! Какой самоуверненный. Нет, не верно.";
    }
}
