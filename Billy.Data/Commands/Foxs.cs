using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Foxs : IDataCommand
    {
        public string Name => "Фоксы";
        public string Help => "Команда для управления Вашим счётом Фоксов.";
        public string FullHelp => "Скоро будет!";
        public static string Buy(string url, long UserId, int countDonate)
        {
            string text = $"ПОКУПКА ФОКСОВ:" +
                $"\nЦена: 1 Российский рубль = 1 Фокс" +
                $"\nДля того чтобы купить Фоксы Вам нужно перевести определённую сумму на Qiwi кошелёк: 9094413184" +
                $"\nВ комментарии к платежу написать: {UserId}_{countDonate}" +
                $"\nЕсли Вы не укажите комментарий, автоматическая система проверки платежа не сможет Вам зачислить Фоксы автоматически." +
                $"\nЕсли Вы не указали комментарий с ID, напишите [fooxboy|Разработчику] ." +
                $"\nЕсли Вы хотите оплатить с кошелька QIWI просто перейдите по ссылке:" +
                $"\n{url}" +
                $"\nПерейдя по ссылке вы попадёте в QIWI Wallet форму с заполненными полями, Вы сможете изменить сумму платежа.";
            return text;
        }

        public static string NoCommand = "Вы не указали подкоманду. Доступные подкоманды: купить, вывыести, проверить, баланс.";
        public static string Balance(int count)
        {
            string text = $"Ваш баланс: {count} фоксов.";
            return text;
        }
        public static string NoPay = "Ваш платёж не найден. Если Вы точно оплатили, напишите [fooxboy|разработчику].";
        public static string ReadyPay(long id, int foxs, int balance)
        {
            string text = $"" +
                $"\n=============================" +
                $"\nЧЕК №1" +
                $"\nТИП ПЛАТЕЖА: Покупка Фоксов." +
                $"\nПользователь: {id}" +
                $"\nСУММА: {foxs}" +
                $"\nЗачислено на счёт: {foxs}" +
                $"\nТекущий баланс: {balance}" +
                $"\n=============================ы";
            return text;
        }
        public static string ReadyExitPay(int sum, long id)
        {
            string text = $"\n=========================" +
                $"\nЧЕК №1" +
                $"\nТИП ПЛАТЕЖА: Вывод фоксов." +
                $"\nПользователь: {id}" +
                $"\nСУММА: {sum}" +
                $"\nОСТАТОК ФОКСОВ: 0" +
                $"\nСТАТУС ПЛАТЕЖА: Выполняется" +
                $"\n=========================" +
                $"Если перевод не произошёл, обратитесь к [fooxboy|разработчику].";
            return text;
        }

        public static string NoWallet = "Вы не указали кошелёк для оплаты. Вывод доступен только на Qiwi кошелёк." +
            "\nНомер указывать в формате: 79001112233";
        public static string NotCommand = "Неизвестная подкоманда. Доступные: Проверить, Баланс, Купить, Вывести";
    }
}
