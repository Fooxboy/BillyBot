using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class Священник : IRole
    {
        public string Name => "Священник";
        public string Caption => "Служитель местной церкви. Про его жизнь никто ничего не знают, но ходят слухи, что он может вызвать самого БОГА!";
        public string Message => "А Вам не надоели эти стены? Пора в БОЙ! Вы - Священник! Вы можете вызвать САМОГО БОГА! Но это, если он только захочет :)";
        public int Id => 7;
        public RoleEnum type => RoleEnum.Жители;
    }
}
