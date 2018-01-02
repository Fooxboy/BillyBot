using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class Киллер : IRole
    {
        public string Name => "Киллер";
        public string Caption => "Никто не знает откуда он появился в их маленькой деревеньке. Да и про него никто даже не знает. Но в деревне убили целую семью, говорят, что это он их.";
        public string Message => "Пиу-пиу. Вы просто убийца! ВЫ - КИЛЛЕР! Человек, который работает в тени. Ваша цель - убить всех в деревне. Но сможете ли вы это?";
        public int Id => 8;
        public RoleEnum type => RoleEnum.Одиночки;
    }
}
