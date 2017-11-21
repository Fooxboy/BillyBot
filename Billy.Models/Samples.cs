using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models
{
    public class Samples
    {
        public class AccessDonate
        {
            public static List<Enums.Billy.Donate> All = new List<Enums.Billy.Donate>()
            {
                Enums.Billy.Donate.User,
                Enums.Billy.Donate.Vip,
                Enums.Billy.Donate.Premium,
                Enums.Billy.Donate.Diamond,
                Enums.Billy.Donate.Admin,
                Enums.Billy.Donate.Tester
            };

            public static List<Enums.Billy.Donate> OnlyInsiders = new List<Enums.Billy.Donate>()
            {
                Enums.Billy.Donate.Tester,
                Enums.Billy.Donate.Admin
            };

            public static List<Enums.Billy.Donate> Vip = new List<Enums.Billy.Donate>()
            {
                Enums.Billy.Donate.Vip,
                Enums.Billy.Donate.Premium,
                Enums.Billy.Donate.Diamond,
                Enums.Billy.Donate.Admin
            };

            public static List<Enums.Billy.Donate> Premuim = new List<Enums.Billy.Donate>()
            {
                Enums.Billy.Donate.Premium,
                Enums.Billy.Donate.Diamond,
                Enums.Billy.Donate.Admin
            };

            public static List<Enums.Billy.Donate> Diamond = new List<Enums.Billy.Donate>()
            {
                Enums.Billy.Donate.Diamond,
                Enums.Billy.Donate.Admin
            };

            public static List<Enums.Billy.Donate> OnlyAdmin = new List<Enums.Billy.Donate>()
            {
                Enums.Billy.Donate.Admin
            };
        }
    }
}
