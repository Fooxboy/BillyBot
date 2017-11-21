using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Helpers
{
    public static class Command
    {
        public static bool CanExecute(this ICommand cmd, string command)
        {
            return cmd.Name.ToLower() == command.ToLower();
        }
    }
}
