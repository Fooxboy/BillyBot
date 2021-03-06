using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public interface IDataCommand
    {
        string Name { get;  }
        string Help { get; }
        string FullHelp { get; }
    }
}
