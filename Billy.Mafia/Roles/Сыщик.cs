using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class Сыщик : IRole
    {
        public string Name => "Сыщик";
        public string Caption => "Местный наёмный сыщик. Может найти кого-угодно, но не факт, что он будет точен.";
        public string Message => "Воу! Воу! Вы - местный сыщик. Найти для вас бандитов - как раз плюнуть! Но результат будет не очень точен :)";
        public int Id => 10;
        public RoleEnum type => RoleEnum.Жители;
    }
}
