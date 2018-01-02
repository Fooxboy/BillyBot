using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class Доктор: IRole
    {
        public string Name => "Доктор";
        public string Caption => "Его судьба, конечно, сложилась не очень хорошо. Его жена умерла при родах. С этого момента он стал врачём. Он единственный лекарь в деревне. Иногда, если он захочет, сможет вылечить от СМЕРТИ.";
        public string Message => "Вы местный иисус. Вы - ДОКТОР. Ваше предназначение только одно - СПАСИТЕ ЖИТЕЛЕЙ ОТ СМЕРТИ!";
        public int Id => 5;
        public RoleEnum type => RoleEnum.Жители;

    }
}
