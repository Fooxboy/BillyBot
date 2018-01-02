using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class Подросток : IRole
    {
        public string Name => "Подросток";
        public string Caption => "Это депрессивный подросток. Он настолько несобран, что не может выбрать человека на голосовании.";
        public string Message => "ОГО ЧУВАК! Да, ты - подросток :( Ничего в этом хорошего для тебя нет. Из-за депрессии ты сможешь проголосвать вообще за рандомного чела. Но зато ты можешь наслождаться сурпризами. Поверь, они будут :)";
        public int Id => 6;
        public RoleEnum type => RoleEnum.Одиночки;
    }
}
