using System;
using Billy.Models;

namespace Helpers
{
    public static class Command
    {
        public static bool CanExecute(this ICommand cmd, string command)
        {
            return cmd.Name == command;
        }
    }
}
