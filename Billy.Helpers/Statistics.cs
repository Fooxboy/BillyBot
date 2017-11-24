using System;
using System.Collections.Generic;
using System.Text;


namespace Billy.Helpers
{
    public static class Statistics
    {
        public static void NewMessage(this Models.User user)
        {
            user.CountMessage = user.CountMessage + 1;
        }
    }
}
