using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class All
    {
        public static IRole Get(int idRole)
        {
            IRole[] roles = { new Житель(), new Житель(), new Бандит(), new Алкоголик(), new Волшебник(), new Доктор(), new Подросток(), new Священник(), new Киллер(), new Самоубийца(), new Сыщик() };
            return roles[idRole];
        }
    }
}
