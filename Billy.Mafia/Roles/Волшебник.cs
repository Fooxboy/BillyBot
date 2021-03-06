using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class Волшебник : IRole
    {
        public string Name => "Волшебник";
        public string Caption => "ГРОМ И МОЛНИЯ! ДА ЭТО ЖЕ ВСЕМОГУЩИЙ ВОЛШЕБНИК! Ну а что он может-то? Все? Ахаха, далеко нет. Он может БОЛЬШЕ чем все! Но, правда, не в этой игре. Ну а тут его силы ограничены. С каким-то шансом(зачем вам цифры, мы же не на математике) он может узнать чью-то роль. И даже обратить время назад! Ну а Русским Языком - он сможет отменить действие какого-либо игрока. Советую подружиться с Волшебником :) ";
        public string Message => "Вы только что сбежали из ХОГВАРЦА! Вы - ВОЛШЕБНИК! Конечно, Вы не такой мастер  в магии, как Ваши учителя, но кое-какие козыри в кармане у Вас есть :)";
        public int Id => 4;
        public RoleEnum type => RoleEnum.Одиночки;
    }
}
