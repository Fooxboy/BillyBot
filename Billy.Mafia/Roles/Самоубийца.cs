using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class Самоубийца : IRole
    {
        public string Name => "Самоубийца";
        public string Caption => "Одиночка.. Единственная его цель - чтобы его убили при голосовании. Он за это получит бонус :)";
        public string Message => "Хах! Вы -  самоубийца. Вы должны любой ценой умереть при голосовании! За это ты получишь бонус)0)0";
        public int Id => 9;
        public RoleEnum type => RoleEnum.Одиночки;
    }
}
