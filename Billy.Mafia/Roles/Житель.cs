using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public class Житель : IRole
    {
        public string Name => "Житель";
        public string Caption => "Это обычный житель. Он ничего не может. А ему и не нужно.";
        public string Message => "Вы ЖИТЕЛЬ! Вы просто сидите в своём домике возле города и смотрите, попивая горячий чай, вокруг.";
        public int Id => 1;
        public RoleEnum type => RoleEnum.Жители;
    }
}
