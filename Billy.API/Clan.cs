using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.API
{
    public class Clan : Models.Clan
    {
        private int  _id;
        public Clan(int id)
        {
            _id = id;
        }    
        Database.Methods method = new Database.Methods("Clans");
        public override int Id
        {
            get
            {
                return _id;
            }
        }

        public static bool Is(int Id)
        {
            Database.Methods method = new Database.Methods("Clans");
            return method.Check(Id);
        }

        public static int New(string name, long userCreator)
        {
            var method = new Database.Methods("Clans");
            string fields = @"`Id`, `Name`, `Members`, `Creator`, `Date`";
            var clan = new API.Clan(228161);
            var id = clan.Creator;
            string values = $@"'{id}', '{name}', {userCreator} , {userCreator}, '{DateTime.Now}'";
            method.Add(fields, values);
            clan.Creator += 1;
            return Convert.ToInt32(id);
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

        public override string Members
        {
            get
            {
                return (string)method.GetFromId(_id, "Members");
            }set
            {
                method.EditField(_id, "Members", value);
            }
        }
     

        public override string Date
        {
            get
            {
                return (string)method.GetFromId(_id, "Date");
            }set
            {
                method.EditField(_id, "Date", value);
            }
        }

        public override long Creator
        {
            get =>  (long)method.GetFromId(_id, "Creator");
            set =>  method.EditField(_id, "Creator", value);
        }
    }
}
