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
    }
}
