using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia.Roles
{
    public interface IRole
    {
        string Name { get; }
        string Caption { get; }
        string Message { get; }
        int Id { get; }
        RoleEnum type { get; }
    }
    public enum RoleEnum
    {
        Жители = 1,
        Разбойники = 2,
        Одиночки =3
    }
}
