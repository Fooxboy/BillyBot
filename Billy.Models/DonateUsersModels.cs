using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models
{
    public class DonateUsersModels
    {
        public List<User> users { get; set; }

        public class User
        {
            public long Id { get; set; }
            public List<long> IDsPay { get; set; }
        }
    }
}
