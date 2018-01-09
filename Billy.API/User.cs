using System;
using System.Collections.Generic;
using System.Text;
using Billy.Enums;

namespace Billy.API
{
    public class User : Models.User
    {
        private long _id;
        public User(long id)
        {
            _id = id;
        }

        public User(long? id)
        {
            _id = id.Value;
        }
        Database.Methods method = new Database.Methods("Users");
        public override long Id
        {
            get
            {
                return _id;
            }
        }

        public static void New(long id)
        {
            var method = new Database.Methods("Users");
            string fields = @"`Id`, `Name`, `DateReg`";
            string name = Data.GetVk().Users.Get(id).FirstName;
            string values = $@"'{id}', '{name}', '{DateTime.Now}'";
            method.Add(fields, values);
        }

        public override string Name
        {
            get
            {
                return (string)method.GetFromId(_id, "Name");
            }set
            {
                method.EditField(_id, "Name", value);
            }
        }

        public override bool Ban
        {
            get
            {
                return (long)method.GetFromId(_id, "Ban") == 1;
            }set
            {
                int values = Convert.ToInt32(value);
                method.EditField(_id, "Ban", values);
            }
        }

        public override int Foxs
        {
            get
            {
                return System.Convert.ToInt32((long)method.GetFromId(_id, "Money"));
            }set
            {
                method.EditField(_id, "Money", value);
            }
        }

        public override int CountMessage
        {
            get
            {
                return Convert.ToInt32((long)method.GetFromId(_id, "CoutMessage"));
            }set
            {
                method.EditField(_id, "CoutMessage", value);
            }
        }

        public static bool Is(long user_id)
        {
            Database.Methods method = new Database.Methods("Users");
            return method.Check(user_id);
        }

        public override Enums.Billy.Donate Donate
        {
            get
            {
                int num = System.Convert.ToInt32((long)method.GetFromId(_id, "Donate"));
                return (Enums.Billy.Donate)num;
            }set
            {
                int donate = (int)value;
                method.EditField(_id, "Donate", donate);
            }
        }

        public override string DateRegistation
        {
            get
            {
                return (string)method.GetFromId(_id, "DateReg");
            }
        }

        public override bool Settings
        {
            get
            {
                return Convert.ToBoolean((long)method.GetFromId(_id, "Settings"));
            }set
            {
                long result = Convert.ToInt64(value);
                method.EditField(_id, "Settings", result);
            }
        }

        public override int DonateCount
        {
            get
            {
                return Convert.ToInt32((long)method.GetFromId(_id, "DonateCount"));
            }set
            {
                method.EditField(_id, "DonateCount", value);
            }
        }

       public override int Clan
       {
            get => Convert.ToInt32((long)method.GetFromId(_id, "Clan"));
            set => method.EditField(_id, "Clan", value);
       }

        public override int FieldOfDreams
        {
            get => Convert.ToInt32((long)method.GetFromId(_id, "FieldOfDreams"));
            set => method.EditField(_id, "FieldOfDreams", value);
        }
    }
}
