using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class Бандит : IRole
    {
        public string Name => "Бандит";
        public string Caption => "БЕРЕГИСЬ! Бойся бандитов! Они могут объединяться в группы и наносить удары ВМЕСТЕ! Не советую вставать ему на пути!";
        public string Message => "КРУТО! Ты - настоящий БАНДИТ! ПОШУМИМ? Нет, ахахах. Вы должны победить всех остальных. Можете даже объедениться в группу с другими бандитами, если их, конечно, не прибили :). ПОКАЖИ КТО ТУТ НАСТОЯЩИЙ БАНДИТ!";
        public int Id => 2;
        public RoleEnum type => RoleEnum.Разбойники;
    }
}
